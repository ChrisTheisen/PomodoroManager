using System;
using System.Collections.Generic;
using System.Drawing;
using System.Media;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class NamedPomodoro : UserControl
    {
        public string PomodoroName { get; set; }

        public Chime Chime = new Chime(Chime.Elise);

        List<PomSpan> pomSpans { get {
                var output = new List<PomSpan>();

                foreach (var c in pnlPom.Controls)
                {
                    if (c is PomSpan && c != dragPom) { output.Add(c as PomSpan); }
                }

                output.Sort((a, b) => a.Location.X.CompareTo(b.Location.X));

                return output;
            }
        }
        private CurrentPomInfo CurrentInfo
        {
            get
            {
                var x = 0L;
                var i = 0;
                while (i < pomSpans.Count && x <= elapsed.Ticks)
                {
                    x += pomSpans[i].TimeSpan.Ticks;
                    i++;
                }

                var output = new CurrentPomInfo()
                {
                    PomSpan = pomSpans[i - 1],
                    EndTicks = x
                };
                return output;
            }
        }

        private PomSpan dragPom { get; set; }
        private bool dragPomIsNew { get; set; }

        private TimeSpan elapsed = new TimeSpan(0);
        private PomSpan lastTickPOM = null;

        public NamedPomodoro(string name)
        {
            InitializeComponent();

            PomodoroName = name;
            lblName.Text = PomodoroName;
        }

        public TimeSpan GetTotalSpan() {
            long ticks = 0;
            foreach (var span in pomSpans)
            {
                ticks += span.TimeSpan.Ticks;
            }
            if (dragPom != null)
            {
                ticks += dragPom.TimeSpan.Ticks;
            }

            return new TimeSpan(ticks);
        }


        public void DeletePomSpan(PomSpan pomSpanToRemove)
        {
            pnlPom.Controls.Remove(pomSpanToRemove);
            UpdatePomSpans();
        }

        public void UpdatePomSpans()
        {
            var totalSpan = GetTotalSpan();
            var calculatedSpan = new TimeSpan();
            var x = 0;

            for (var i = 0; i < pomSpans.Count; i++)
            {
                var shift = dragPom != null && dragPom.Location.X < x ? dragPom.Width : 0;
                var w = Width * pomSpans[i].TimeSpan.TotalSeconds / totalSpan.TotalSeconds;
                pomSpans[i].Location = new Point((int)x + shift, 0);
                pomSpans[i].Size = new Size((int)w, pnlPom.Height);
                x += (int)w;

                calculatedSpan = calculatedSpan.Add(pomSpans[i].TimeSpan);
            }

            if (pomSpans.Count > 0 && dragPom == null)
            {
                var lastPom = pomSpans[pomSpans.Count - 1];
                lastPom.Width = pnlPom.Width - lastPom.Location.X;
            }
        }

        public void Go()
        {
            if (GetTotalSpan().TotalSeconds == 0) { return; }
            lastTickPOM = null;
            timer.Start();
            btnStop.Enabled = true;
            btnGo.Enabled = false;
        }

        public void Stop()
        {
            timer.Stop();
            btnStop.Enabled = false;
            btnGo.Enabled = true;
        }


        private void UpdatePomProgress()
        {
            var total = GetTotalSpan();
            var totalSeconds = total.TotalSeconds;
            var x = totalSeconds == 0 ? 0 : (float)(pnlPom.Width * elapsed.TotalSeconds / totalSeconds);

            pnlProgress.Location = new Point((int)x - 2, pnlProgress.Location.Y);

            var currentInfo = CurrentInfo;
            var currentSpan = currentInfo.PomSpan;

            var remaining = new TimeSpan(elapsed.Ticks - currentInfo.StartTicks);
            var formatString = currentSpan.TimeSpan.Hours > 0 ? "%h\\:mm\\:ss" : "%m\\:ss\\.f";
            lblCurrent.Text = $"{currentSpan.SpanName}[{remaining.ToString(formatString)}/{currentSpan.TimeSpan.ToString(formatString)}]";

            if (lastTickPOM != null && lastTickPOM != currentSpan)
            {
                lastTickPOM.Chime.Play();
            }
            lastTickPOM = currentSpan;

            formatString = total.Hours > 0 ? "%h\\:mm\\:ss" : "%m\\:ss\\.f";
            lblElapsed.Text = $"{elapsed.ToString(formatString)}/{GetTotalSpan().ToString(formatString)}";
        }

        internal void Reset()
        {
            elapsed = new TimeSpan(0);
            lastTickPOM = null;
        }

        private void pnlPom_DragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Move;
            if(e.Data.GetDataPresent(typeof(PomSpan))){

                dragPom = e.Data.GetData(typeof(PomSpan)) as PomSpan;

                if (!pnlPom.Controls.Contains(dragPom))
                {
                    var totalSpan = GetTotalSpan();

                    dragPomIsNew = true;
                    pnlPom.Controls.Add(dragPom);
                    dragPom.SetParentPomodoro(this);
                    dragPom.Width = (int)(Width * dragPom.TimeSpan.TotalSeconds / totalSpan.TotalSeconds);
                }
                else { dragPomIsNew = false; }

                dragPom.BringToFront();
            }
        }
        private void pnlPom_DragLeave(object sender, EventArgs e)
        {
            if (dragPomIsNew)
            {
                pnlPom.Controls.Remove(dragPom);
            }
            dragPom = null;
            UpdatePomSpans();
        }
        private void pnlPom_DragOver(object sender, DragEventArgs e)
        {
            if (dragPom != null)
            {
                var x = PointToClient(new Point(e.X, e.Y)).X;
                dragPom.Location = new Point(x-(dragPom.Size.Width / 2), pnlPom.Height - 4);
                UpdatePomSpans();
            }
        }
        private void pnlPom_DragDrop(object sender, DragEventArgs e)
        {
            var dropItem = e.Data.GetData(typeof(PomSpan));
            if (dropItem is PomSpan)
            {
                dragPom = null;
            }
            dragPomIsNew = false;
            UpdatePomSpans();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Go();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Stop();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            elapsed = elapsed.Add(new TimeSpan(timer.Interval * 10000));
            var max = GetTotalSpan();
            if (elapsed > max) { Chime.PlaySynchronous(); }//End of POM ding
            while (elapsed > max) { elapsed = elapsed.Subtract(max); }

            UpdatePomProgress();
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var root = FindForm();
            (root as PomodoroManager).UpdatePomLocations(this);
            Dispose();
        }

        private void btnRR_Click(object sender, EventArgs e)
        {
            Reset();
        }

        private void btnR_Click(object sender, EventArgs e)
        {
            var ticks = CurrentInfo.StartTicks;
            elapsed = new TimeSpan(ticks);
            lastTickPOM = null;
        }

        private void btnF_Click(object sender, EventArgs e)
        {
            var ticks = CurrentInfo.EndTicks;
            elapsed = new TimeSpan(ticks);
            lastTickPOM = null;
        }

        private void btnFF_Click(object sender, EventArgs e)
        {
            elapsed = GetTotalSpan();
            lastTickPOM = null;
        }
    }

    class CurrentPomInfo
    {
        public PomSpan PomSpan { get; set; }
        public long StartTicks { get { return EndTicks - PomSpan.TimeSpan.Ticks; } }
        public long EndTicks { get; set; }
    }


}
