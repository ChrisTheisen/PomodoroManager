using System;
using System.Drawing;
using System.Windows.Forms;


//CustomPomodoro
//TODO: save timer types
//TODO: save named poms
//TODO: load saved data

//NamedPomodoro:
//TODO: context menu to edit named pomodoros?
//TODO: pause while dragging or lock while running?


namespace Pomodoro
{
    public partial class PomodoroManager : Form
    {
        public PomodoroManager()
        {
            InitializeComponent();
        }

        private Chime CustomChime()
        {
            using var chimeModal = new CustomChimeModal();
            var chimeResult = chimeModal.ShowDialog();
            if (chimeResult == DialogResult.OK)
            {
                return new Chime(chimeModal.Notes);
            }
            else
            {
                return new Chime();
            }
        }

        private void btnAddSpan_Click(object sender, EventArgs e)
        {

            using var modal = new TimerModal();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
            {
                if (!string.IsNullOrEmpty(modal.TimerName) && modal.TimeSpan.Ticks > 0)
                {
                    var newTimer = new NamedTimer(modal.TimerName, modal.TimeSpan, modal.TimerColor)
                    {
                        Location = new Point(5, 50 * pnlTimers.Controls.Count + 5),
                        Size = new Size(pnlTimers.Width - 20, 48),
                        Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                        Chime = modal.Chime
                    };

                    if (newTimer.Chime.Notes == null)
                    {
                        newTimer.Chime = CustomChime();
                    }

                    pnlTimers.Controls.Add(newTimer);
                }
            }
            modal.Dispose();

        }

        private void btnAddPom_Click(object sender, EventArgs e)
        {
            using var modal = new NewPomodoroModal();
            var result = modal.ShowDialog();
            if (result == DialogResult.OK)
            {
                var newPom = new NamedPomodoro(modal.PomodoroName)
                {
                    Location = new Point(5, 50 * pnlPomodoros.Controls.Count + 5),
                    Size = new Size(pnlPomodoros.Width - 20, 48),
                    Anchor = AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Top,
                    Chime = modal.Chime
                };

                if (newPom.Chime.Notes == null)
                {
                    newPom.Chime = CustomChime();
                }

                pnlPomodoros.Controls.Add(newPom);
            }
        }

        public void UpdateTimerTypeLocations(NamedTimer timerToRemove)
        {
            pnlTimers.Controls.Remove(timerToRemove);
            for (var i = 0; i < pnlTimers.Controls.Count; i++)
            {
                pnlTimers.Controls[i].Location = new Point(5, 50 * i + 5);
            }
        }

        public void UpdatePomLocations(NamedPomodoro pomToRemove)
        {
            pnlPomodoros.Controls.Remove(pomToRemove);
            for (var i = 0; i < pnlPomodoros.Controls.Count; i++)
            {
                pnlPomodoros.Controls[i].Location = new Point(5, 50 * i + 5);
            }
        }

        private void btnStartAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < pnlPomodoros.Controls.Count; i++)
            {
                (pnlPomodoros.Controls[i] as NamedPomodoro).Go();
            }
        }

        private void btnStopAll_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < pnlPomodoros.Controls.Count; i++)
            {
                (pnlPomodoros.Controls[i] as NamedPomodoro).Stop();
            }
        }

        private void PomodoroManager_FormClosing(object sender, FormClosingEventArgs e)
        {
            for (var i = 0; i < pnlPomodoros.Controls.Count; i++)
            {
                (pnlPomodoros.Controls[i] as NamedPomodoro).Chime.End();
            }

        }

        private void btnReset_Click(object sender, EventArgs e)
        {
            for (var i = 0; i < pnlPomodoros.Controls.Count; i++)
            {
                (pnlPomodoros.Controls[i] as NamedPomodoro).Reset();
            }
        }

    }
}
