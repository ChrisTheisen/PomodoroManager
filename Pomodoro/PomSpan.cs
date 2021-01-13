using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pomodoro
{
    public class PomSpan : Panel
    {
        public TimeSpan TimeSpan { get; set; }
        ContextMenu menu = new ContextMenu();
        public string SpanName { get; set; }

        public Chime Chime = new Chime();
        private NamedPomodoro ParentPomodoro { get; set; }
        private ToolTip tt;
        private Label lbl;

        public PomSpan(NamedPomodoro pomodoro, Color color, string name, TimeSpan timeSpan)
        {
            BackColor = color;
            Name = name;
            TimeSpan = timeSpan;
            SpanName = name;
            ParentPomodoro = pomodoro;
            Chime = new Chime();

            InitializeComponents();
        }

        public PomSpan(NamedPomodoro pomodoro, Color color, string name, TimeSpan timeSpan, Chime chime)
        {
            BackColor = color;
            Name = name;
            TimeSpan = timeSpan;
            SpanName = name;
            ParentPomodoro = pomodoro;
            Chime = chime;

            InitializeComponents();
        }

        private void InitializeComponents()
        {

            BorderStyle = BorderStyle.FixedSingle;

            MouseClick += PomSpan_MouseClick;
            menu.MenuItems.Add("&Edit", new EventHandler(edit_click));
            menu.MenuItems.Add("&Delete", new EventHandler(delete_click));

            MouseDown += PomSpan_MouseDown;

            lbl = new Label
            {
                Location = new Point(0, 0),
                Text = ToString()
            };
            Controls.Add(lbl);

            lbl.MouseDown += PomSpan_MouseDown;
            lbl.MouseClick += PomSpan_MouseClick;

            tt = new ToolTip
            {
                InitialDelay = 0,
                AutoPopDelay = 5000,
                UseAnimation = false,
                UseFading = false
            };

            tt.SetToolTip(this, ToString());
            tt.SetToolTip(lbl, ToString());
        }

        public void SetParentPomodoro(NamedPomodoro namedPomodoro) { ParentPomodoro = namedPomodoro; }

        public override string ToString()
        {
            var formatString = TimeSpan.Hours > 0 ? "%h\\:mm\\:ss" : "%m\\:ss\\.f";
            var duration = TimeSpan.ToString(formatString);
            return $"{SpanName}[{duration}]";
        }


        private void PomSpan_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                DoDragDrop(this, DragDropEffects.Move);
            }
        }

        private void PomSpan_MouseClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                menu.Show(this, e.Location);
            }
        }

        private void edit_click(object sender, EventArgs e)
        {
            using var modal = new TimerModal(SpanName, TimeSpan, BackColor);
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(modal.TimerName) && modal.TimeSpan.Ticks > 0)
                {
                    SpanName = modal.TimerName;
                    TimeSpan = modal.TimeSpan;
                    BackColor = modal.TimerColor;

                    tt.SetToolTip(this, ToString());
                    tt.SetToolTip(lbl, ToString());
                    lbl.Text = ToString();

                    ParentPomodoro.UpdatePomSpans();
                }
            }
        }

        private void delete_click(object sender, EventArgs e)
        {
            ParentPomodoro.DeletePomSpan(this);

            Dispose();
        }
    }
}
