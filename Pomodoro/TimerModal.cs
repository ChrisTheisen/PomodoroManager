using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class TimerModal : Form
    {
        public TimerModal()
        {
            InitializeComponent();

            numMinutes.Value = 1;

            Random randomGen = new Random();
            KnownColor[] names = (KnownColor[])Enum.GetValues(typeof(KnownColor));
            KnownColor randomColorName = names[randomGen.Next(names.Length)];
            btnColor.BackColor = Color.FromKnownColor(randomColorName);

            ddlChime.DataSource = Enum.GetValues(typeof(Chime.Prefab));
        }

        public TimerModal(string name, TimeSpan timeSpan, Color color)
        {
            InitializeComponent();

            txtName.Text = name;
            numHours.Value = timeSpan.Hours;
            numMinutes.Value = timeSpan.Minutes;
            numSeconds.Value = timeSpan.Seconds;
            btnColor.BackColor = color;

            ddlChime.DataSource = Enum.GetValues(typeof(Chime.Prefab));
        }

        public string TimerName { get { return txtName.Text; } }
        public TimeSpan TimeSpan { get { return new TimeSpan((int)numHours.Value, (int)numMinutes.Value, (int)numSeconds.Value); } }

        public Chime Chime { get { return new Chime((Chime.Prefab)ddlChime.SelectedItem); } }

        protected override void OnClosing(CancelEventArgs e)
        {
            if (DialogResult == DialogResult.OK && !isValid)
            {
                e.Cancel = true;
                txtName.Focus();
            }

            base.OnClosing(e);
        }

        public Color TimerColor { get { return btnColor.BackColor; } }
        private bool isValid
        {
            get{
                if (TimeSpan.Ticks == 0)
                {
                    numHours.BackColor = Color.Pink;
                    numMinutes.BackColor = Color.Pink;
                    numSeconds.BackColor = Color.Pink;
                }
                if (string.IsNullOrWhiteSpace(TimerName))
                {
                    txtName.BackColor = Color.Pink;
                }

                return TimeSpan > new TimeSpan(0) && !string.IsNullOrWhiteSpace(TimerName); 
            }
        }

        private void btnColor_Click(object sender, EventArgs e)
        {
            colorPicker.Color = TimerColor;
            if (colorPicker.ShowDialog() == DialogResult.OK)
            {
                btnColor.BackColor = colorPicker.Color;
            }
        }

        private void TimerModal_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
