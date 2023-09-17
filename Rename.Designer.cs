namespace UTAUColours2023
{
    partial class Rename
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Rename));
            this.RenameTextBox = new System.Windows.Forms.TextBox();
            this.renRenameButton = new System.Windows.Forms.Button();
            this.renCancelButton = new System.Windows.Forms.Button();
            this.renNewNameLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // RenameTextBox
            // 
            this.RenameTextBox.Location = new System.Drawing.Point(12, 25);
            this.RenameTextBox.Name = "RenameTextBox";
            this.RenameTextBox.Size = new System.Drawing.Size(238, 20);
            this.RenameTextBox.TabIndex = 0;
            // 
            // renRenameButton
            // 
            this.renRenameButton.Location = new System.Drawing.Point(54, 51);
            this.renRenameButton.Name = "renRenameButton";
            this.renRenameButton.Size = new System.Drawing.Size(75, 23);
            this.renRenameButton.TabIndex = 1;
            this.renRenameButton.Text = "&Rename";
            this.renRenameButton.UseVisualStyleBackColor = true;
            this.renRenameButton.Click += new System.EventHandler(this.RenameButton_Click);
            // 
            // renCancelButton
            // 
            this.renCancelButton.Location = new System.Drawing.Point(135, 51);
            this.renCancelButton.Name = "renCancelButton";
            this.renCancelButton.Size = new System.Drawing.Size(75, 23);
            this.renCancelButton.TabIndex = 1;
            this.renCancelButton.Text = "&Cancel";
            this.renCancelButton.UseVisualStyleBackColor = true;
            this.renCancelButton.Click += new System.EventHandler(this.renCancelButton_Click);
            // 
            // renNewNameLabel
            // 
            this.renNewNameLabel.AutoSize = true;
            this.renNewNameLabel.Location = new System.Drawing.Point(9, 7);
            this.renNewNameLabel.Name = "renNewNameLabel";
            this.renNewNameLabel.Size = new System.Drawing.Size(99, 13);
            this.renNewNameLabel.TabIndex = 2;
            this.renNewNameLabel.Text = "New Theme Name:";
            // 
            // Rename
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(262, 82);
            this.Controls.Add(this.renNewNameLabel);
            this.Controls.Add(this.renCancelButton);
            this.Controls.Add(this.renRenameButton);
            this.Controls.Add(this.RenameTextBox);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Rename";
            this.Text = "Rename Theme";
            this.Load += new System.EventHandler(this.Rename_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox RenameTextBox;
        private System.Windows.Forms.Button renRenameButton;
        private System.Windows.Forms.Button renCancelButton;
        private System.Windows.Forms.Label renNewNameLabel;
    }
}