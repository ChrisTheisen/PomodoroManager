using System;
using System.ComponentModel;
using System.Drawing;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class NewPomodoroModal : Form
    {
        public NewPomodoroModal()
        {
            InitializeComponent();

            ddlChime.DataSource = Enum.GetValues(typeof(Chime.Prefab));
        }

        public NewPomodoroModal(string name)
        {
            InitializeComponent();

            txtName.Text = name;
            ddlChime.DataSource = Enum.GetValues(typeof(Chime.Prefab));
        }

        public string PomodoroName { get { return txtName.Text; } }
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

        private bool isValid
        {
            get{
                if (string.IsNullOrWhiteSpace(PomodoroName))
                {
                    txtName.BackColor = Color.Pink;
                }

                return !string.IsNullOrWhiteSpace(PomodoroName); 
            }
        }

        private void NewPomodoroModal_Activated(object sender, EventArgs e)
        {
            txtName.Focus();
        }
    }
}
