using System;
using System.ComponentModel;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Pomodoro
{
    public class CustomNote : Panel
    {
        public Note Note { get; set; }

        Label lblF { get; set; }
        Label lblD { get; set; }
        NumericUpDown numF { get; set; }
        NumericUpDown numD { get; set; }
        Button btnPlay { get; set; }

        public CustomNote()
        {
            InitializeComponent();
        }

        public CustomNote(bool isRest)
        {
            InitializeComponent();
            Note.IsRest = isRest;
            if (isRest)
            {
                lblF.Text = "Rest";
                numF.Visible = false;
            }
        }

        public void SetDuration(int duration)
        {
            Note.Duration = duration;
            numD.Value = duration;
        }

        private void NumF_ValueChanged(object sender, EventArgs e)
        {
            Note.Frequency = (int)numF.Value;
        }

        private void NumD_ValueChanged(object sender, EventArgs e)
        {
            Note.Duration = (int)numD.Value;
            (FindForm() as CustomChimeModal).FixNotes();
        }

        private void BtnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        public void Play()
        {
            if (Note.IsRest)
            {
                Thread.Sleep(Note.Duration);
            }
            else
            {
                Console.Beep(Note.Frequency, Note.Duration);
            }
        }

        private IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            components = new Container();

            lblF = new Label
            {
                Location = new Point(0, 0),
                Size = new Size(Width, 14),
                AutoSize = false,
                Text = "Frequency"
            };

            lblD = new Label
            {
                Location = new Point(0, 40),
                Size = new Size(Width, 14),
                AutoSize = false,
                Text = "Duration"
            };

            numF = new NumericUpDown
            {
                Location = new Point(5, 14),
                Minimum = 37,
                Maximum = 32767,
                Value = 220,
                Size = new Size(50, 16)
            };

            numD = new NumericUpDown
            {
                Location = new Point(5, 54),
                Minimum = 64,
                Maximum = 1024,
                Value = 128,
                Size = new Size(45, 16)
            };

            btnPlay = new Button()
            {
                Dock = DockStyle.Bottom,
                Text = "►",
                TextAlign = ContentAlignment.MiddleCenter
            };

            BorderStyle = BorderStyle.FixedSingle;
            Height = 109;
            Width = Chime.eighth / 2;
            Note = new Note((int)numF.Value, (int)numD.Value);

            numD.ValueChanged += NumD_ValueChanged;
            numF.ValueChanged += NumF_ValueChanged;

            btnPlay.Click += BtnPlay_Click;

            Controls.Add(lblF);
            Controls.Add(lblD);
            Controls.Add(numF);
            Controls.Add(numD);
            Controls.Add(btnPlay);
        }
    }
}
