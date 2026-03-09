namespace Hotel_System
{
    partial class Login
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            profile = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            SuspendLayout();
            // 
            // profile
            // 
            profile.Image = Properties.Resources._0e7f6006e9273ec44255aaa391107a73;
            profile.Location = new Point(845, 415);
            profile.Name = "profile";
            profile.Size = new Size(60, 60);
            profile.SizeMode = PictureBoxSizeMode.StretchImage;
            profile.TabIndex = 1;
            profile.TabStop = false;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1750, 891);
            Controls.Add(profile);
            Name = "Login";
            Text = "Form1";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private PictureBox profile;
    }
}
