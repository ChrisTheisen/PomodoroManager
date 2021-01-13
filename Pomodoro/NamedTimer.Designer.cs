
namespace Pomodoro
{
    partial class NamedTimer
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
            this.btnDel = new System.Windows.Forms.Button();
            this.lblName = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.pnlColor = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // btnDel
            // 
            this.btnDel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnDel.BackColor = System.Drawing.Color.Red;
            this.btnDel.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnDel.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnDel.Location = new System.Drawing.Point(147, 0);
            this.btnDel.Margin = new System.Windows.Forms.Padding(0);
            this.btnDel.Name = "btnDel";
            this.btnDel.Size = new System.Drawing.Size(15, 18);
            this.btnDel.TabIndex = 10;
            this.btnDel.Text = "X";
            this.btnDel.UseVisualStyleBackColor = false;
            this.btnDel.Click += new System.EventHandler(this.btnDel_Click);
            // 
            // lblName
            // 
            this.lblName.AutoSize = true;
            this.lblName.Location = new System.Drawing.Point(0, 0);
            this.lblName.Name = "lblName";
            this.lblName.Size = new System.Drawing.Size(35, 13);
            this.lblName.TabIndex = 11;
            this.lblName.Text = "Name";
            this.lblName.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // lblDuration
            // 
            this.lblDuration.AutoSize = true;
            this.lblDuration.Location = new System.Drawing.Point(0, 22);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(43, 13);
            this.lblDuration.TabIndex = 12;
            this.lblDuration.Text = "0:00:00";
            this.lblDuration.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // pnlColor
            // 
            this.pnlColor.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.pnlColor.BackColor = System.Drawing.Color.Blue;
            this.pnlColor.Location = new System.Drawing.Point(142, 25);
            this.pnlColor.Name = "pnlColor";
            this.pnlColor.Size = new System.Drawing.Size(20, 19);
            this.pnlColor.TabIndex = 13;
            this.pnlColor.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            // 
            // NamedTimer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.Controls.Add(this.pnlColor);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.lblName);
            this.Controls.Add(this.btnDel);
            this.Margin = new System.Windows.Forms.Padding(1);
            this.Name = "NamedTimer";
            this.Size = new System.Drawing.Size(162, 43);
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.StartDrag);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button btnDel;
        private System.Windows.Forms.Label lblName;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Panel pnlColor;
    }
}
