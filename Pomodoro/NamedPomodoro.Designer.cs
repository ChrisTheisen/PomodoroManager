
namespace Pomodoro
{
    partial class NamedPomodoro
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.lblName = new System.Windows.Forms.Label();
            this.pnlPom = new System.Windows.Forms.Panel();
            this.btnGo = new System.Windows.Forms.Button();
            this.lblCurrent = new System.Windows.Forms.Label();
            this.timer = new System.Windows.Forms.Timer(this.components);
            this.btnStop = new System.Windows.Forms.Button();
            this.pnlProgress = new System.Windows.Forms.Panel();
            this.lblElapsed = new System.Windows.Forms.Label();
            this.btnDel = new System.Windows.Forms.Button();
            this.btnFF = new System.Windows.Forms.Button();
            this.btnF = new System.Windows.Forms.Button();
            this.btnR = new System.Windows.Forms.Button();
            this.btnRR = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(3, 2);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(57, 13);
            this.lblName.TabIndex = 0;
            this.lblName.Text = "Pom Timer";
            // 
            // pnlPom
            // 
            this.pnlPom.AllowDrop = true;
            this.pnlPom.BackColor = System.Drawing.Color.White;
            this.pnlPom.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPom.Location = new System.Drawing.Point(0, 18);
            this.pnlPom.Name = "pnlPom";
            this.pnlPom.Size = new System.Drawing.Size(699, 30);
            this.pnlPom.TabIndex = 1;
            this.pnlPom.DragDrop += new System.Windows.Forms.DragEventHandler(this.pnlPom_DragDrop);
            this.pnlPom.DragEnter += new System.Windows.Forms.DragEventHandler(this.pnlPom_DragEnter);
            this.pnlPom.DragOver += new System.Windows.Forms.DragEventHandler(this.pnlPom_DragOver);
            this.pnlPom.DragLeave += new System.EventHandler(this.pnlPom_DragLeave);
            // 
            // btnGo
            // 
            this.btnGo.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnGo.Location = new System.Drawing.Point(651, -4);
            this.btnGo.Margin = new System.Windows.Forms.Padding(0);
            this.btnGo.Name = "btnGo";
            this.btnGo.Size = new System.Drawing.Size(23, 23);
            this.btnGo.TabIndex = 0;
            this.btnGo.Text = "►";
            this.btnGo.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnGo.UseVisualStyleBackColor = true;
            this.btnGo.Click += new System.EventHandler(this.btnGo_Click);
            // 
            // lblCurrent
            // 
            this.lblCurrent.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.lblCurrent.AutoSize = true;
            this.lblCurrent.Location = new System.Drawing.Point(317, 2);
            this.lblCurrent.Name = "lblCurrent";
            this.lblCurrent.Size = new System.Drawing.Size(64, 13);
            this.lblCurrent.TabIndex = 2;
            this.lblCurrent.Text = "Current Item";
            // 
            // timer
            // 
            this.timer.Tick += new System.EventHandler(this.timer_Tick);
            // 
            // btnStop
            // 
            this.btnStop.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnStop.Enabled = false;
            this.btnStop.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStop.Location = new System.Drawing.Point(628, -4);
            this.btnStop.Margin = new System.Windows.Forms.Padding(0);
            this.btnStop.Name = "btnStop";
            this.btnStop.Size = new System.Drawing.Size(23, 23);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "▬";
            this.btnStop.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnStop.UseVisualStyleBackColor = true;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // pnlProgress
            // 
            this.pnlProgress.BackColor = System.Drawing.Color.Red;
            this.pnlProgress.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.pnlProgress.Location = new System.Drawing.Point(0, 28);
            this.pnlProgress.Name = "pnlProgress";
            this.pnlProgress.Size = new System.Drawing.Size(3, 20);
            this.pnlProgress.TabIndex = 4;
            // 
            // lblElapsed
            // 
            this.lblElapsed.AutoSize = true;
            this.lblElapsed.Location = new System.Drawing.Point(66, 2);
            this.lblElapsed.Name = "lblElapsed";
            this.lblElapsed.Size = new System.Drawing.Size(28, 13);
            this.lblElapsed.TabIndex = 5;
            this.lblElapsed.Text = "0:00";
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Red;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(676, -4);
            this.btnDel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(23, 23);
            this.btnDel.TabIndex = 6;
            this.btnDel.Text = "X";
            this.btnDel.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // btnFF
            // 
            this.btnFF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnFF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFF.Location = new System.Drawing.Point(605, -4);
            this.btnFF.Margin = new System.Windows.Forms.Padding(0);
            this.btnFF.Name = "btnFF";
            this.btnFF.Size = new System.Drawing.Size(23, 23);
            this.btnFF.TabIndex = 7;
            this.btnFF.Text = "»";
            this.btnFF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnFF.UseVisualStyleBackColor = true;
            this.btnFF.Click += new System.EventHandler(this.btnFF_Click);
            // 
            // btnF
            // 
            this.btnF.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnF.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnF.Location = new System.Drawing.Point(582, -4);
            this.btnF.Margin = new System.Windows.Forms.Padding(0);
            this.btnF.Name = "btnF";
            this.btnF.Size = new System.Drawing.Size(23, 23);
            this.btnF.TabIndex = 8;
            this.btnF.Text = ">";
            this.btnF.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnF.UseVisualStyleBackColor = true;
            this.btnF.Click += new System.EventHandler(this.btnF_Click);
            // 
            // btnR
            // 
            this.btnR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnR.Location = new System.Drawing.Point(559, -4);
            this.btnR.Margin = new System.Windows.Forms.Padding(0);
            this.btnR.Name = "btnR";
            this.btnR.Size = new System.Drawing.Size(23, 23);
            this.btnR.TabIndex = 9;
            this.btnR.Text = "<";
            this.btnR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnR.UseVisualStyleBackColor = true;
            this.btnR.Click += new System.EventHandler(this.btnR_Click);
            // 
            // btnRR
            // 
            this.btnRR.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnRR.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnRR.Location = new System.Drawing.Point(536, -4);
            this.btnRR.Margin = new System.Windows.Forms.Padding(0);
            this.btnRR.Name = "btnRR";
            this.btnRR.Size = new System.Drawing.Size(23, 23);
            this.btnRR.TabIndex = 10;
            this.btnRR.Text = "«";
            this.btnRR.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            this.btnRR.UseVisualStyleBackColor = true;
            this.btnRR.Click += new System.EventHandler(this.btnRR_Click);
            // 
            // NamedPomodoro
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.lblElapsed);
            this.Controls.Add(this.pnlProgress);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.pnlPom);
            this.Controls.Add(this.btnGo);
            this.Controls.Add(this.btnStop);
            this.Controls.Add(this.btnDel);
            this.Controls.Add(this.btnRR);
            this.Controls.Add(this.btnR);
            this.Controls.Add(this.btnF);
            this.Controls.Add(this.btnFF);
            this.Controls.Add(this.lblCurrent);
            this.Name = "NamedPomodoro";
            this.Size = new System.Drawing.Size(699, 48);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Panel pnlPom;
        private System.Windows.Forms.Button btnGo;
        private System.Windows.Forms.Label lblCurrent;
        private System.Windows.Forms.Timer timer;
        private System.Windows.Forms.Button btnStop;
        private System.Windows.Forms.Panel pnlProgress;
        private System.Windows.Forms.Label lblElapsed;
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Button btnFF;
        private System.Windows.Forms.Button btnF;
        private System.Windows.Forms.Button btnR;
        private System.Windows.Forms.Button btnRR;
    }
}
