namespace UTAUColours2023
{
    partial class About
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(About));
            this.aboutUC2023Label = new System.Windows.Forms.Label();
            this.closeAboutButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // aboutUC2023Label
            // 
            this.aboutUC2023Label.AutoSize = true;
            this.aboutUC2023Label.Location = new System.Drawing.Point(103, 17);
            this.aboutUC2023Label.Name = "aboutUC2023Label";
            this.aboutUC2023Label.Size = new System.Drawing.Size(262, 78);
            this.aboutUC2023Label.TabIndex = 0;
            this.aboutUC2023Label.Text = "UTAU Colours 2023 is based\r\non the original utaucolors program\r\nby Ameya-P\r\n\r\nTra" +
    "nslation, Coding, and Design by HowlingFoxRouko\r\nIcon by Kotozaki";
            this.aboutUC2023Label.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // closeAboutButton
            // 
            this.closeAboutButton.Location = new System.Drawing.Point(155, 103);
            this.closeAboutButton.Name = "closeAboutButton";
            this.closeAboutButton.Size = new System.Drawing.Size(75, 23);
            this.closeAboutButton.TabIndex = 1;
            this.closeAboutButton.Text = "&Close";
            this.closeAboutButton.UseVisualStyleBackColor = true;
            this.closeAboutButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::UTAUColours2023.Properties.Resources.UTAUColoursIcon;
            this.pictureBox1.Location = new System.Drawing.Point(10, 8);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(87, 87);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // About
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(370, 134);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.closeAboutButton);
            this.Controls.Add(this.aboutUC2023Label);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "About";
            this.Text = "About";
            this.Load += new System.EventHandler(this.About_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label aboutUC2023Label;
        private System.Windows.Forms.Button closeAboutButton;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}