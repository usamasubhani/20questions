namespace BrainReader
{
    partial class SensorForm
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
            this.backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            this.yesProgressBar = new System.Windows.Forms.ProgressBar();
            this.noProgressBar = new System.Windows.Forms.ProgressBar();
            this.buttonYes = new System.Windows.Forms.Button();
            this.buttonNo = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // yesProgressBar
            // 
            this.yesProgressBar.Location = new System.Drawing.Point(211, 222);
            this.yesProgressBar.Name = "yesProgressBar";
            this.yesProgressBar.Size = new System.Drawing.Size(181, 23);
            this.yesProgressBar.TabIndex = 26;
            // 
            // noProgressBar
            // 
            this.noProgressBar.Location = new System.Drawing.Point(34, 222);
            this.noProgressBar.Name = "noProgressBar";
            this.noProgressBar.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.noProgressBar.RightToLeftLayout = true;
            this.noProgressBar.Size = new System.Drawing.Size(171, 23);
            this.noProgressBar.TabIndex = 27;
            // 
            // buttonYes
            // 
            this.buttonYes.BackColor = System.Drawing.SystemColors.MenuHighlight;
            this.buttonYes.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonYes.ForeColor = System.Drawing.SystemColors.ControlLight;
            this.buttonYes.Location = new System.Drawing.Point(294, 275);
            this.buttonYes.Name = "buttonYes";
            this.buttonYes.Size = new System.Drawing.Size(45, 22);
            this.buttonYes.TabIndex = 28;
            this.buttonYes.Text = "Yes";
            this.buttonYes.UseVisualStyleBackColor = false;
            this.buttonYes.Click += new System.EventHandler(this.buttonYes_Click);
            // 
            // buttonNo
            // 
            this.buttonNo.BackColor = System.Drawing.Color.Red;
            this.buttonNo.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonNo.ForeColor = System.Drawing.SystemColors.ControlLightLight;
            this.buttonNo.Location = new System.Drawing.Point(79, 273);
            this.buttonNo.Name = "buttonNo";
            this.buttonNo.Size = new System.Drawing.Size(45, 24);
            this.buttonNo.TabIndex = 29;
            this.buttonNo.Text = "No";
            this.buttonNo.UseVisualStyleBackColor = false;
            this.buttonNo.Click += new System.EventHandler(this.buttonNo_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Lucida Console", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 69);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(367, 45);
            this.label1.TabIndex = 30;
            this.label1.Text = "Answer the question by moving your head.\r\nMove right to say yes.\r\nMove left to sa" +
    "y No.";
            // 
            // SensorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(422, 370);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonNo);
            this.Controls.Add(this.buttonYes);
            this.Controls.Add(this.noProgressBar);
            this.Controls.Add(this.yesProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Location = new System.Drawing.Point(900, 50);
            this.Name = "SensorForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "SensorForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        public Accord.Controls.Vision.HeadController controller;
        private System.Windows.Forms.ProgressBar yesProgressBar;
        private System.Windows.Forms.ProgressBar noProgressBar;
        private System.Windows.Forms.Button buttonYes;
        private System.Windows.Forms.Button buttonNo;
        private System.Windows.Forms.Label label1;
    }
}