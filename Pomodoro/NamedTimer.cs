using System;
using System.Drawing;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class NamedTimer : UserControl
    {
        public NamedTimer(string timerName, TimeSpan timeSpan, Color color)
        {
            InitializeComponent();

            lblName.Text = timerName;
            lblDuration.Text = timeSpan.ToString("hh\\:mm\\:ss\\.f");
            pnlColor.BackColor = color;
            this.timeSpan = timeSpan;
        }

        public Chime Chime { get; set; }

        private TimeSpan timeSpan { get; set; }
        public TimeSpan TimeSpan
        {
            get { return timeSpan; }
        }

        public string TimerName
        {
            get { return lblName.Text; }
        }

        public Color TimerColor { get { return pnlColor.BackColor; } }

        private void StartDrag(object sender, MouseEventArgs e)
        {
            var dragItem = new PomSpan(new NamedPomodoro("TEMP"), TimerColor, TimerName, TimeSpan, Chime);
            DoDragDrop(dragItem, DragDropEffects.Move);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            var root = FindForm();
            (root as PomodoroManager).UpdateTimerTypeLocations(this);
            Dispose();
        }


    }
}
