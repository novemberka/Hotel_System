namespace Hotel_System
{
    partial class Dashboard
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
            panel1 = new Panel();
            pictureBox1 = new PictureBox();
            tableLayoutPanel1 = new TableLayoutPanel();
            logout_menu = new FontAwesome.Sharp.IconButton();
            payment_menu = new FontAwesome.Sharp.IconButton();
            customer_menu = new FontAwesome.Sharp.IconButton();
            checkin_checkout_menu = new FontAwesome.Sharp.IconButton();
            dashboard_menu = new FontAwesome.Sharp.IconButton();
            room_menu = new FontAwesome.Sharp.IconButton();
            booking_menu = new FontAwesome.Sharp.IconButton();
            panel2 = new Panel();
            profile = new PictureBox();
            contentPanel = new Panel();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tableLayoutPanel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)profile).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.DarkTurquoise;
            panel1.Controls.Add(pictureBox1);
            panel1.Controls.Add(tableLayoutPanel1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(0, 150, 0, 70);
            panel1.Size = new Size(238, 739);
            panel1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources._2eb6e65cddc26fd117cc3d8979b979b8_Photoroom_1;
            pictureBox1.Location = new Point(55, 29);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(105, 93);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 1;
            pictureBox1.TabStop = false;
            // 
            // tableLayoutPanel1
            // 
            tableLayoutPanel1.ColumnCount = 1;
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            tableLayoutPanel1.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 20F));
            tableLayoutPanel1.Controls.Add(logout_menu, 0, 6);
            tableLayoutPanel1.Controls.Add(payment_menu, 0, 5);
            tableLayoutPanel1.Controls.Add(customer_menu, 0, 4);
            tableLayoutPanel1.Controls.Add(checkin_checkout_menu, 0, 3);
            tableLayoutPanel1.Controls.Add(dashboard_menu, 0, 0);
            tableLayoutPanel1.Controls.Add(room_menu, 0, 2);
            tableLayoutPanel1.Controls.Add(booking_menu, 0, 1);
            tableLayoutPanel1.Dock = DockStyle.Fill;
            tableLayoutPanel1.Location = new Point(0, 150);
            tableLayoutPanel1.Name = "tableLayoutPanel1";
            tableLayoutPanel1.RowCount = 7;
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.RowStyles.Add(new RowStyle(SizeType.Percent, 12.5F));
            tableLayoutPanel1.Size = new Size(238, 519);
            tableLayoutPanel1.TabIndex = 0;
            tableLayoutPanel1.Paint += tableLayoutPanel1_Paint;
            // 
            // logout_menu
            // 
            logout_menu.BackColor = Color.DarkTurquoise;
            logout_menu.Dock = DockStyle.Fill;
            logout_menu.Enabled = false;
            logout_menu.FlatAppearance.BorderSize = 0;
            logout_menu.FlatStyle = FlatStyle.Flat;
            logout_menu.Font = new Font("Segoe UI", 10F);
            logout_menu.ForeColor = Color.White;
            logout_menu.IconChar = FontAwesome.Sharp.IconChar.ArrowRight;
            logout_menu.IconColor = Color.White;
            logout_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            logout_menu.IconSize = 35;
            logout_menu.ImageAlign = ContentAlignment.MiddleLeft;
            logout_menu.Location = new Point(3, 447);
            logout_menu.Name = "logout_menu";
            logout_menu.Padding = new Padding(10, 0, 0, 0);
            logout_menu.Size = new Size(232, 69);
            logout_menu.TabIndex = 7;
            logout_menu.Text = "Logout";
            logout_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            logout_menu.UseVisualStyleBackColor = false;
            logout_menu.Click += logout_menu_Click;
            // 
            // payment_menu
            // 
            payment_menu.BackColor = Color.DarkTurquoise;
            payment_menu.Dock = DockStyle.Fill;
            payment_menu.Enabled = false;
            payment_menu.FlatAppearance.BorderSize = 0;
            payment_menu.FlatStyle = FlatStyle.Flat;
            payment_menu.Font = new Font("Segoe UI", 10F);
            payment_menu.ForeColor = Color.White;
            payment_menu.IconChar = FontAwesome.Sharp.IconChar.Wallet;
            payment_menu.IconColor = Color.White;
            payment_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            payment_menu.IconSize = 35;
            payment_menu.ImageAlign = ContentAlignment.MiddleLeft;
            payment_menu.Location = new Point(3, 373);
            payment_menu.Name = "payment_menu";
            payment_menu.Padding = new Padding(10, 0, 0, 0);
            payment_menu.Size = new Size(232, 68);
            payment_menu.TabIndex = 6;
            payment_menu.Text = "Payment";
            payment_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            payment_menu.UseVisualStyleBackColor = false;
            payment_menu.Click += payment_menu_Click;
            // 
            // customer_menu
            // 
            customer_menu.BackColor = Color.DarkTurquoise;
            customer_menu.Dock = DockStyle.Fill;
            customer_menu.Enabled = false;
            customer_menu.FlatAppearance.BorderSize = 0;
            customer_menu.FlatStyle = FlatStyle.Flat;
            customer_menu.Font = new Font("Segoe UI", 10F);
            customer_menu.ForeColor = Color.White;
            customer_menu.IconChar = FontAwesome.Sharp.IconChar.UserFriends;
            customer_menu.IconColor = Color.White;
            customer_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            customer_menu.IconSize = 35;
            customer_menu.ImageAlign = ContentAlignment.MiddleLeft;
            customer_menu.Location = new Point(3, 299);
            customer_menu.Name = "customer_menu";
            customer_menu.Padding = new Padding(10, 0, 0, 0);
            customer_menu.Size = new Size(232, 68);
            customer_menu.TabIndex = 5;
            customer_menu.Text = "Customer";
            customer_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            customer_menu.UseVisualStyleBackColor = false;
            customer_menu.Click += customer_menu_Click;
            // 
            // checkin_checkout_menu
            // 
            checkin_checkout_menu.BackColor = Color.DarkTurquoise;
            checkin_checkout_menu.Dock = DockStyle.Fill;
            checkin_checkout_menu.Enabled = false;
            checkin_checkout_menu.FlatAppearance.BorderSize = 0;
            checkin_checkout_menu.FlatStyle = FlatStyle.Flat;
            checkin_checkout_menu.Font = new Font("Segoe UI", 10F);
            checkin_checkout_menu.ForeColor = Color.White;
            checkin_checkout_menu.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            checkin_checkout_menu.IconColor = Color.White;
            checkin_checkout_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            checkin_checkout_menu.IconSize = 35;
            checkin_checkout_menu.ImageAlign = ContentAlignment.MiddleLeft;
            checkin_checkout_menu.Location = new Point(3, 225);
            checkin_checkout_menu.Name = "checkin_checkout_menu";
            checkin_checkout_menu.Padding = new Padding(10, 0, 0, 0);
            checkin_checkout_menu.Size = new Size(232, 68);
            checkin_checkout_menu.TabIndex = 4;
            checkin_checkout_menu.Text = "CheckIn & CheckOut";
            checkin_checkout_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            checkin_checkout_menu.UseVisualStyleBackColor = false;
            checkin_checkout_menu.Click += iconButton4_Click;
            // 
            // dashboard_menu
            // 
            dashboard_menu.BackColor = Color.DarkTurquoise;
            dashboard_menu.Dock = DockStyle.Fill;
            dashboard_menu.Enabled = false;
            dashboard_menu.FlatAppearance.BorderSize = 0;
            dashboard_menu.FlatStyle = FlatStyle.Flat;
            dashboard_menu.Font = new Font("Segoe UI", 10F);
            dashboard_menu.ForeColor = Color.White;
            dashboard_menu.IconChar = FontAwesome.Sharp.IconChar.House;
            dashboard_menu.IconColor = Color.White;
            dashboard_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            dashboard_menu.IconSize = 35;
            dashboard_menu.ImageAlign = ContentAlignment.MiddleLeft;
            dashboard_menu.Location = new Point(3, 3);
            dashboard_menu.Name = "dashboard_menu";
            dashboard_menu.Padding = new Padding(10, 0, 0, 0);
            dashboard_menu.Size = new Size(232, 68);
            dashboard_menu.TabIndex = 3;
            dashboard_menu.Text = "Dashboard";
            dashboard_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            dashboard_menu.UseVisualStyleBackColor = false;
            dashboard_menu.Click += iconButton2_Click;
            // 
            // room_menu
            // 
            room_menu.BackColor = Color.DarkTurquoise;
            room_menu.Dock = DockStyle.Fill;
            room_menu.Enabled = false;
            room_menu.FlatAppearance.BorderSize = 0;
            room_menu.FlatStyle = FlatStyle.Flat;
            room_menu.Font = new Font("Segoe UI", 10F);
            room_menu.ForeColor = Color.White;
            room_menu.IconChar = FontAwesome.Sharp.IconChar.Bed;
            room_menu.IconColor = Color.White;
            room_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            room_menu.IconSize = 35;
            room_menu.ImageAlign = ContentAlignment.MiddleLeft;
            room_menu.Location = new Point(3, 151);
            room_menu.Name = "room_menu";
            room_menu.Padding = new Padding(10, 0, 0, 0);
            room_menu.Size = new Size(232, 68);
            room_menu.TabIndex = 2;
            room_menu.Text = "Room";
            room_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            room_menu.UseVisualStyleBackColor = false;
            room_menu.Click += room_menu_Click;
            // 
            // booking_menu
            // 
            booking_menu.BackColor = Color.DarkTurquoise;
            booking_menu.Dock = DockStyle.Fill;
            booking_menu.Enabled = false;
            booking_menu.FlatAppearance.BorderSize = 0;
            booking_menu.FlatStyle = FlatStyle.Flat;
            booking_menu.Font = new Font("Segoe UI", 10F);
            booking_menu.ForeColor = Color.White;
            booking_menu.IconChar = FontAwesome.Sharp.IconChar.CalendarCheck;
            booking_menu.IconColor = Color.White;
            booking_menu.IconFont = FontAwesome.Sharp.IconFont.Auto;
            booking_menu.IconSize = 35;
            booking_menu.ImageAlign = ContentAlignment.MiddleLeft;
            booking_menu.Location = new Point(3, 77);
            booking_menu.Name = "booking_menu";
            booking_menu.Padding = new Padding(10, 0, 0, 0);
            booking_menu.Size = new Size(232, 68);
            booking_menu.TabIndex = 0;
            booking_menu.Text = "Booking";
            booking_menu.TextImageRelation = TextImageRelation.ImageBeforeText;
            booking_menu.UseVisualStyleBackColor = false;
            booking_menu.Click += iconButton1_Click;
            // 
            // panel2
            // 
            panel2.BackColor = Color.RoyalBlue;
            panel2.Controls.Add(profile);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(238, 0);
            panel2.Name = "panel2";
            panel2.Size = new Size(1615, 77);
            panel2.TabIndex = 1;
            panel2.Paint += panel2_Paint;
            // 
            // profile
            // 
            profile.Image = Properties.Resources._0e7f6006e9273ec44255aaa391107a73;
            profile.Location = new Point(1532, 12);
            profile.Name = "profile";
            profile.Size = new Size(60, 60);
            profile.SizeMode = PictureBoxSizeMode.StretchImage;
            profile.TabIndex = 0;
            profile.TabStop = false;
            profile.Click += pictureBox2_Click;
            profile.Paint += profile_Paint;
            // 
            // contentPanel
            // 
            contentPanel.Location = new Point(448, 205);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1405, 534);
            contentPanel.TabIndex = 2;
            contentPanel.Paint += contentPanel_Paint;
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1853, 739);
            Controls.Add(contentPanel);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "Dashboard";
            Text = "Dashboard";
            Load += Dashboard_Load;
            panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tableLayoutPanel1.ResumeLayout(false);
            panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)profile).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Panel panel2;
        private FontAwesome.Sharp.IconButton booking_menu;
        private TableLayoutPanel tableLayoutPanel1;
        private FontAwesome.Sharp.IconButton logout_menu;
        private FontAwesome.Sharp.IconButton payment_menu;
        private FontAwesome.Sharp.IconButton customer_menu;
        private FontAwesome.Sharp.IconButton checkin_checkout_menu;
        private FontAwesome.Sharp.IconButton dashboard_menu;
        private FontAwesome.Sharp.IconButton room_menu;
        private PictureBox pictureBox1;
        private Panel contentPanel;
        private PictureBox profile;
    }
}