using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;

namespace Pomodoro
{
    public partial class CustomChimeModal : Form
    {
        public CustomChimeModal()
        {
            InitializeComponent();
        }

        public List<Note> Notes
        {
            get
            {
                List<Note> output = new List<Note>();

                foreach (var c in pnlChimeNotes.Controls)
                {
                    output.Add((c as CustomNote).Note);
                }

                return output;
            }
        }

        private int total
        {
            get
            {
                var output = 0;

                foreach (var note in Notes) { output += note.Duration; }

                return output;
            }
        }

        public void Play()
        {
            var notes = Notes;
            for(var i=0;i<notes.Count;i++) {
                if (notes[i].IsRest)
                {
                    Thread.Sleep(notes[i].Duration);
                }
                else
                {
                    Console.Beep(notes[i].Frequency, notes[i].Duration);
                }
            }
        }

        public void FixNotes()
        {
            while (total > Chime.whole * 2)
            {
                var delta = total - (Chime.whole * 2);
                var last = (pnlChimeNotes.Controls[pnlChimeNotes.Controls.Count - 1] as CustomNote);
                var newDuration = last.Note.Duration - delta;

                if (delta > last.Note.Duration || newDuration < Chime.sixteenth)
                {
                    pnlChimeNotes.Controls.Remove(last);
                }
                else
                {
                    last.SetDuration(newDuration);
                }
            }


            var x = 0;
            for (var i = 0; i < pnlChimeNotes.Controls.Count; i++)
            {
                var cn = (pnlChimeNotes.Controls[i] as CustomNote);

                var w = pnlChimeNotes.Width * cn.Note.Duration / Chime.whole / 2;

                cn.Width = w;
                cn.Location = new Point(x, 0);
                x += w;
            }
        }

        private void btnPlay_Click(object sender, EventArgs e)
        {
            Play();
        }

        private void btnRest_Click(object sender, EventArgs e)
        {
            var x = pnlChimeNotes.Controls.Count == 0 ? 0 :
                pnlChimeNotes.Controls[pnlChimeNotes.Controls.Count - 1].Location.X + pnlChimeNotes.Controls[pnlChimeNotes.Controls.Count - 1].Width;
            var cnote = new CustomNote(true)
            {
                Location = new Point(x, 0)
            };
            pnlChimeNotes.Controls.Add(cnote);
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {

            if (total >= Chime.whole * 2) { return; }

            var x = pnlChimeNotes.Controls.Count == 0 ? 0 : 
                pnlChimeNotes.Controls[pnlChimeNotes.Controls.Count - 1].Location.X + pnlChimeNotes.Controls[pnlChimeNotes.Controls.Count - 1].Width;
            var cnote = new CustomNote()
            {
                Location = new Point(x, 0)
            };
            pnlChimeNotes.Controls.Add(cnote);
        }

        private void btnDel_Click(object sender, EventArgs e)
        {
            pnlChimeNotes.Controls.RemoveAt(pnlChimeNotes.Controls.Count - 1);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.OK;
            Close();
        }
    }
}
