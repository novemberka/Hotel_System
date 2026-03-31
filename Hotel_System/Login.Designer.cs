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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            boxProfile = new Guna.UI2.WinForms.Guna2CirclePictureBox();
            linkForgotpassword = new LinkLabel();
            label2 = new Label();
            lbusername = new Label();
            txtpassword = new Guna.UI2.WinForms.Guna2TextBox();
            txtusername = new Guna.UI2.WinForms.Guna2TextBox();
            lbLogin = new Label();
            guna2PictureBox1 = new Guna.UI2.WinForms.Guna2PictureBox();
            btnlogin = new Guna.UI2.WinForms.Guna2GradientButton();
            ((System.ComponentModel.ISupportInitialize)boxProfile).BeginInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).BeginInit();
            SuspendLayout();
            // 
            // boxProfile
            // 
            boxProfile.ImageRotate = 0F;
            boxProfile.InitialImage = null;
            boxProfile.Location = new Point(207, 37);
            boxProfile.Name = "boxProfile";
            boxProfile.ShadowDecoration.CustomizableEdges = customizableEdges1;
            boxProfile.ShadowDecoration.Mode = Guna.UI2.WinForms.Enums.ShadowMode.Circle;
            boxProfile.Size = new Size(87, 82);
            boxProfile.SizeMode = PictureBoxSizeMode.StretchImage;
            boxProfile.TabIndex = 53;
            boxProfile.TabStop = false;
            boxProfile.Click += guna2CirclePictureBox1_Click;
            // 
            // linkForgotpassword
            // 
            linkForgotpassword.AutoSize = true;
            linkForgotpassword.BackColor = Color.Navy;
            linkForgotpassword.DisabledLinkColor = Color.White;
            linkForgotpassword.LinkBehavior = LinkBehavior.NeverUnderline;
            linkForgotpassword.LinkColor = Color.White;
            linkForgotpassword.Location = new Point(275, 393);
            linkForgotpassword.Name = "linkForgotpassword";
            linkForgotpassword.Size = new Size(129, 20);
            linkForgotpassword.TabIndex = 6;
            linkForgotpassword.TabStop = true;
            linkForgotpassword.Text = "Forgot Password ?";
            linkForgotpassword.LinkClicked += linkLabel1_LinkClicked;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(111, 303);
            label2.Name = "label2";
            label2.Size = new Size(70, 20);
            label2.TabIndex = 5;
            label2.Text = "Password";
            label2.Click += label2_Click_1;
            // 
            // lbusername
            // 
            lbusername.AutoSize = true;
            lbusername.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lbusername.ForeColor = Color.White;
            lbusername.Location = new Point(106, 209);
            lbusername.Name = "lbusername";
            lbusername.Size = new Size(75, 20);
            lbusername.TabIndex = 4;
            lbusername.Text = "Username";
            lbusername.Click += lable1_Click_1;
            // 
            // txtpassword
            // 
            txtpassword.BorderColor = Color.Gray;
            txtpassword.BorderRadius = 8;
            txtpassword.CustomizableEdges = customizableEdges2;
            txtpassword.DefaultText = "";
            txtpassword.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtpassword.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtpassword.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtpassword.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtpassword.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtpassword.Font = new Font("Segoe UI", 9F);
            txtpassword.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtpassword.Location = new Point(106, 244);
            txtpassword.Margin = new Padding(3, 4, 3, 4);
            txtpassword.Name = "txtpassword";
            txtpassword.PlaceholderText = "";
            txtpassword.SelectedText = "";
            txtpassword.ShadowDecoration.CustomizableEdges = customizableEdges3;
            txtpassword.Size = new Size(298, 42);
            txtpassword.TabIndex = 3;
            txtpassword.TextChanged += txtpassword_TextChanged;
            // 
            // txtusername
            // 
            txtusername.BorderColor = Color.Gray;
            txtusername.BorderRadius = 8;
            txtusername.CustomizableEdges = customizableEdges4;
            txtusername.DefaultText = "";
            txtusername.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtusername.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtusername.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtusername.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtusername.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtusername.Font = new Font("Segoe UI", 9F);
            txtusername.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtusername.Location = new Point(106, 336);
            txtusername.Margin = new Padding(3, 4, 3, 4);
            txtusername.Name = "txtusername";
            txtusername.PlaceholderText = "";
            txtusername.SelectedText = "";
            txtusername.ShadowDecoration.CustomizableEdges = customizableEdges5;
            txtusername.Size = new Size(298, 42);
            txtusername.TabIndex = 2;
            txtusername.TextChanged += guna2TextBox1_TextChanged;
            // 
            // lbLogin
            // 
            lbLogin.AutoSize = true;
            lbLogin.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbLogin.ForeColor = Color.White;
            lbLogin.Location = new Point(146, 144);
            lbLogin.Name = "lbLogin";
            lbLogin.Size = new Size(219, 28);
            lbLogin.TabIndex = 1;
            lbLogin.Text = "Hello , Welcom Back !";
            lbLogin.Click += label1_Click;
            // 
            // guna2PictureBox1
            // 
            guna2PictureBox1.BackColor = Color.Navy;
            guna2PictureBox1.BorderRadius = 40;
            guna2PictureBox1.CustomizableEdges = customizableEdges6;
            guna2PictureBox1.FillColor = Color.Transparent;
            guna2PictureBox1.Image = (Image)resources.GetObject("guna2PictureBox1.Image");
            guna2PictureBox1.ImageRotate = 0F;
            guna2PictureBox1.Location = new Point(166, 13);
            guna2PictureBox1.Name = "guna2PictureBox1";
            guna2PictureBox1.ShadowDecoration.CustomizableEdges = customizableEdges7;
            guna2PictureBox1.Size = new Size(83, 83);
            guna2PictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            guna2PictureBox1.TabIndex = 0;
            guna2PictureBox1.TabStop = false;
            guna2PictureBox1.Click += guna2PictureBox1_Click;
            // 
            // btnlogin
            // 
            btnlogin.BorderRadius = 8;
            btnlogin.CustomizableEdges = customizableEdges8;
            btnlogin.DisabledState.BorderColor = Color.DarkGray;
            btnlogin.DisabledState.CustomBorderColor = Color.DarkGray;
            btnlogin.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnlogin.DisabledState.FillColor2 = Color.FromArgb(169, 169, 169);
            btnlogin.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnlogin.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnlogin.ForeColor = Color.White;
            btnlogin.Location = new Point(106, 437);
            btnlogin.Name = "btnlogin";
            btnlogin.ShadowDecoration.CustomizableEdges = customizableEdges9;
            btnlogin.Size = new Size(288, 49);
            btnlogin.TabIndex = 54;
            btnlogin.Text = "LOGIN";
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Navy;
            ClientSize = new Size(513, 636);
            Controls.Add(btnlogin);
            Controls.Add(linkForgotpassword);
            Controls.Add(boxProfile);
            Controls.Add(txtpassword);
            Controls.Add(label2);
            Controls.Add(lbLogin);
            Controls.Add(lbusername);
            Controls.Add(txtusername);
            DoubleBuffered = true;
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(2);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Form1";
            Load += Login_Load;
            ((System.ComponentModel.ISupportInitialize)boxProfile).EndInit();
            ((System.ComponentModel.ISupportInitialize)guna2PictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Guna.UI2.WinForms.Guna2PictureBox guna2PictureBox1;

        private Label lbLogin;
        private Guna.UI2.WinForms.Guna2TextBox txtusername;
        private Guna.UI2.WinForms.Guna2TextBox txtpassword;
        private Label lbusername;
        private Label label2;
        private LinkLabel linkForgotpassword;

        private Guna.UI2.WinForms.Guna2CirclePictureBox boxProfile;
        private Guna.UI2.WinForms.Guna2GradientButton btnlogin;
    }
}
