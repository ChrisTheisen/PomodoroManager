
namespace Pomodoro
{
    partial class PomodoroManager
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.splitMain = new System.Windows.Forms.SplitContainer();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlTimers = new System.Windows.Forms.Panel();
            this.btnAddSpan = new System.Windows.Forms.Button();
            this.btnStopAll = new System.Windows.Forms.Button();
            this.btnStartAll = new System.Windows.Forms.Button();
            this.pnlPomodoros = new System.Windows.Forms.Panel();
            this.btnAddPom = new System.Windows.Forms.Button();
            this.btnReset = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).BeginInit();
            this.splitMain.Panel1.SuspendLayout();
            this.splitMain.Panel2.SuspendLayout();
            this.splitMain.SuspendLayout();
            this.SuspendLayout();
            // 
            // splitMain
            // 
            this.splitMain.BackColor = System.Drawing.Color.Black;
            this.splitMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitMain.Location = new System.Drawing.Point(0, 0);
            this.splitMain.Name = "splitMain";
            // 
            // splitMain.Panel1
            // 
            this.splitMain.Panel1.BackColor = System.Drawing.SystemColors.Control;
            this.splitMain.Panel1.Controls.Add(this.label1);
            this.splitMain.Panel1.Controls.Add(this.pnlTimers);
            this.splitMain.Panel1.Controls.Add(this.btnAddSpan);
            // 
            // splitMain.Panel2
            // 
            this.splitMain.Panel2.BackColor = System.Drawing.SystemColors.Control;
            this.splitMain.Panel2.Controls.Add(this.btnReset);
            this.splitMain.Panel2.Controls.Add(this.btnStopAll);
            this.splitMain.Panel2.Controls.Add(this.btnStartAll);
            this.splitMain.Panel2.Controls.Add(this.pnlPomodoros);
            this.splitMain.Panel2.Controls.Add(this.btnAddPom);
            this.splitMain.Size = new System.Drawing.Size(1021, 450);
            this.splitMain.SplitterDistance = 180;
            this.splitMain.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(3, 38);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Drag Time Types to Pomodoros";
            // 
            // pnlTimers
            // 
            this.pnlTimers.BackColor = System.Drawing.SystemColors.Control;
            this.pnlTimers.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlTimers.Location = new System.Drawing.Point(0, 54);
            this.pnlTimers.Name = "pnlTimers";
            this.pnlTimers.Size = new System.Drawing.Size(180, 396);
            this.pnlTimers.TabIndex = 2;
            // 
            // btnAddSpan
            // 
            this.btnAddSpan.Location = new System.Drawing.Point(12, 12);
            this.btnAddSpan.Name = "btnAddSpan";
            this.btnAddSpan.Size = new System.Drawing.Size(143, 23);
            this.btnAddSpan.TabIndex = 1;
            this.btnAddSpan.Text = "Add Time Type";
            this.btnAddSpan.UseVisualStyleBackColor = true;
            this.btnAddSpan.Click += new System.EventHandler(this.btnAddSpan_Click);
            // 
            // btnStopAll
            // 
            this.btnStopAll.Location = new System.Drawing.Point(565, 12);
            this.btnStopAll.Name = "btnStopAll";
            this.btnStopAll.Size = new System.Drawing.Size(87, 23);
            this.btnStopAll.TabIndex = 5;
            this.btnStopAll.Text = "Stop All";
            this.btnStopAll.UseVisualStyleBackColor = true;
            this.btnStopAll.Click += new System.EventHandler(this.btnStopAll_Click);
            // 
            // btnStartAll
            // 
            this.btnStartAll.Location = new System.Drawing.Point(658, 12);
            this.btnStartAll.Name = "btnStartAll";
            this.btnStartAll.Size = new System.Drawing.Size(87, 23);
            this.btnStartAll.TabIndex = 4;
            this.btnStartAll.Text = "Start All";
            this.btnStartAll.UseVisualStyleBackColor = true;
            this.btnStartAll.Click += new System.EventHandler(this.btnStartAll_Click);
            // 
            // pnlPomodoros
            // 
            this.pnlPomodoros.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.pnlPomodoros.Location = new System.Drawing.Point(0, 41);
            this.pnlPomodoros.Name = "pnlPomodoros";
            this.pnlPomodoros.Size = new System.Drawing.Size(837, 409);
            this.pnlPomodoros.TabIndex = 3;
            // 
            // btnAddPom
            // 
            this.btnAddPom.Location = new System.Drawing.Point(3, 12);
            this.btnAddPom.Name = "btnAddPom";
            this.btnAddPom.Size = new System.Drawing.Size(143, 23);
            this.btnAddPom.TabIndex = 2;
            this.btnAddPom.Text = "Add Pomodoro";
            this.btnAddPom.UseVisualStyleBackColor = true;
            this.btnAddPom.Click += new System.EventHandler(this.btnAddPom_Click);
            // 
            // btnReset
            // 
            this.btnReset.Location = new System.Drawing.Point(472, 12);
            this.btnReset.Name = "btnReset";
            this.btnReset.Size = new System.Drawing.Size(87, 23);
            this.btnReset.TabIndex = 6;
            this.btnReset.Text = "Reset All";
            this.btnReset.UseVisualStyleBackColor = true;
            this.btnReset.Click += new System.EventHandler(this.btnReset_Click);
            // 
            // PomodoroManager
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1021, 450);
            this.Controls.Add(this.splitMain);
            this.Name = "PomodoroManager";
            this.Text = "Pomodoro Manager";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.PomodoroManager_FormClosing);
            this.splitMain.Panel1.ResumeLayout(false);
            this.splitMain.Panel1.PerformLayout();
            this.splitMain.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitMain)).EndInit();
            this.splitMain.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitMain;
        private System.Windows.Forms.Panel pnlTimers;
        private System.Windows.Forms.Button btnAddSpan;
        private System.Windows.Forms.Panel pnlPomodoros;
        private System.Windows.Forms.Button btnAddPom;
        private System.Windows.Forms.Button btnStopAll;
        private System.Windows.Forms.Button btnStartAll;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnReset;
    }
}

