namespace Hotel_System
{
    partial class Report_Booking
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
            DataGridView Booking_Report;
            DataGridViewCellStyle dataGridViewCellStyle3 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges21 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges22 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges23 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges24 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Booking = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            txtSearchCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            Booking_Status = new Guna.UI2.WinForms.Guna2ComboBox();
            label3 = new Label();
            RoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            label5 = new Label();
            Report_Summary = new Guna.UI2.WinForms.Guna2ShadowPanel();
            guna2ShadowPanel4 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            label13 = new Label();
            label14 = new Label();
            guna2ShadowPanel3 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox3 = new FontAwesome.Sharp.IconPictureBox();
            label11 = new Label();
            label12 = new Label();
            guna2ShadowPanel2 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            label8 = new Label();
            label10 = new Label();
            guna2ShadowPanel1 = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            label7 = new Label();
            label6 = new Label();
            label9 = new Label();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            Booking_Report = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Booking_Report).BeginInit();
            SelectDateRoport.SuspendLayout();
            Booking_list.SuspendLayout();
            Report_Summary.SuspendLayout();
            guna2ShadowPanel4.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            guna2ShadowPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).BeginInit();
            guna2ShadowPanel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            guna2ShadowPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).BeginInit();
            SuspendLayout();
            // 
            // Booking_Report
            // 
            Booking_Report.BackgroundColor = Color.White;
            Booking_Report.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booking_Report.Columns.AddRange(new DataGridViewColumn[] { Booking, CustomerName, PhoneNumber, Room, dataGridViewTextBoxColumn1, CheckIn, Checkout, Status, Note });
            Booking_Report.Location = new Point(29, 68);
            Booking_Report.Name = "Booking_Report";
            Booking_Report.RowHeadersWidth = 51;
            Booking_Report.Size = new Size(1350, 265);
            Booking_Report.TabIndex = 28;
            Booking_Report.CellContentClick += Booking_Report_CellContentClick_1;
            // 
            // Booking
            // 
            Booking.DataPropertyName = "booking_id";
            dataGridViewCellStyle3.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Booking.DefaultCellStyle = dataGridViewCellStyle3;
            Booking.HeaderText = "Booking ID";
            Booking.MinimumWidth = 6;
            Booking.Name = "Booking";
            Booking.Width = 150;
            // 
            // CustomerName
            // 
            CustomerName.DataPropertyName = "customer_name";
            CustomerName.HeaderText = "Customer Name";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 160;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "phone_number";
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 180;
            // 
            // Room
            // 
            Room.DataPropertyName = "room";
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 125;
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.DataPropertyName = "room_type";
            dataGridViewTextBoxColumn1.HeaderText = "Room Type";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            dataGridViewTextBoxColumn1.Width = 150;
            // 
            // CheckIn
            // 
            CheckIn.DataPropertyName = "check-in";
            CheckIn.HeaderText = "Check In";
            CheckIn.MinimumWidth = 6;
            CheckIn.Name = "CheckIn";
            CheckIn.Width = 125;
            // 
            // Checkout
            // 
            Checkout.DataPropertyName = "check-out";
            Checkout.HeaderText = "Check Out";
            Checkout.MinimumWidth = 6;
            Checkout.Name = "Checkout";
            Checkout.Width = 125;
            // 
            // Status
            // 
            Status.DataPropertyName = "status";
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 150;
            // 
            // Note
            // 
            Note.DataPropertyName = "note";
            Note.HeaderText = "Note";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            Note.Width = 140;
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(txtSearchCustomer);
            SelectDateRoport.Controls.Add(label4);
            SelectDateRoport.Controls.Add(Booking_Status);
            SelectDateRoport.Controls.Add(label3);
            SelectDateRoport.Controls.Add(RoomType);
            SelectDateRoport.Controls.Add(label2);
            SelectDateRoport.Controls.Add(ToDate);
            SelectDateRoport.Controls.Add(label1);
            SelectDateRoport.Controls.Add(FromDate);
            SelectDateRoport.Controls.Add(lbCustomerName);
            SelectDateRoport.FillColor = Color.White;
            SelectDateRoport.Location = new Point(23, 3);
            SelectDateRoport.Name = "SelectDateRoport";
            SelectDateRoport.Radius = 8;
            SelectDateRoport.ShadowColor = Color.LightSteelBlue;
            SelectDateRoport.ShadowDepth = 80;
            SelectDateRoport.ShadowShift = 10;
            SelectDateRoport.Size = new Size(1405, 180);
            SelectDateRoport.TabIndex = 1;
            SelectDateRoport.Paint += guna2ShadowPanel1_Paint;
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.BorderColor = Color.Silver;
            txtSearchCustomer.BorderRadius = 6;
            txtSearchCustomer.CustomizableEdges = customizableEdges21;
            txtSearchCustomer.DefaultText = "";
            txtSearchCustomer.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtSearchCustomer.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtSearchCustomer.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtSearchCustomer.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtSearchCustomer.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchCustomer.Font = new Font("Segoe UI", 9F);
            txtSearchCustomer.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtSearchCustomer.Location = new Point(29, 120);
            txtSearchCustomer.Margin = new Padding(3, 4, 3, 4);
            txtSearchCustomer.Name = "txtSearchCustomer";
            txtSearchCustomer.PlaceholderText = "";
            txtSearchCustomer.SelectedText = "";
            txtSearchCustomer.ShadowDecoration.CustomizableEdges = customizableEdges22;
            txtSearchCustomer.Size = new Size(492, 36);
            txtSearchCustomer.TabIndex = 55;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(29, 96);
            label4.Name = "label4";
            label4.Size = new Size(119, 20);
            label4.TabIndex = 27;
            label4.Text = "Customer Name";
            // 
            // Booking_Status
            // 
            Booking_Status.BackColor = Color.Transparent;
            Booking_Status.BorderColor = Color.Silver;
            Booking_Status.BorderRadius = 8;
            Booking_Status.CustomizableEdges = customizableEdges23;
            Booking_Status.DrawMode = DrawMode.OwnerDrawFixed;
            Booking_Status.DropDownStyle = ComboBoxStyle.DropDownList;
            Booking_Status.FocusedColor = Color.FromArgb(94, 148, 255);
            Booking_Status.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Booking_Status.Font = new Font("Segoe UI", 10F);
            Booking_Status.ForeColor = Color.FromArgb(68, 88, 112);
            Booking_Status.ItemHeight = 30;
            Booking_Status.Items.AddRange(new object[] { "Completed", "Check-In", "Check-Out", "Cancelled" });
            Booking_Status.Location = new Point(836, 120);
            Booking_Status.Name = "Booking_Status";
            Booking_Status.ShadowDecoration.CustomizableEdges = customizableEdges24;
            Booking_Status.Size = new Size(210, 36);
            Booking_Status.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(836, 96);
            label3.Name = "label3";
            label3.Size = new Size(111, 20);
            label3.TabIndex = 25;
            label3.Text = "Booking Status";
            // 
            // RoomType
            // 
            RoomType.BackColor = Color.Transparent;
            RoomType.BorderColor = Color.Silver;
            RoomType.BorderRadius = 8;
            RoomType.CustomizableEdges = customizableEdges25;
            RoomType.DrawMode = DrawMode.OwnerDrawFixed;
            RoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            RoomType.FocusedColor = Color.FromArgb(94, 148, 255);
            RoomType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            RoomType.Font = new Font("Segoe UI", 10F);
            RoomType.ForeColor = Color.FromArgb(68, 88, 112);
            RoomType.ItemHeight = 30;
            RoomType.Items.AddRange(new object[] { "All", "Single", "Double", "VIP" });
            RoomType.Location = new Point(836, 45);
            RoomType.Name = "RoomType";
            RoomType.ShadowDecoration.CustomizableEdges = customizableEdges26;
            RoomType.Size = new Size(210, 36);
            RoomType.TabIndex = 24;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(836, 22);
            label2.Name = "label2";
            label2.Size = new Size(85, 20);
            label2.TabIndex = 23;
            label2.Text = "Room Type";
            // 
            // ToDate
            // 
            ToDate.BackColor = Color.White;
            ToDate.BorderRadius = 8;
            ToDate.Checked = true;
            ToDate.CustomizableEdges = customizableEdges27;
            ToDate.FillColor = Color.White;
            ToDate.FocusedColor = Color.White;
            ToDate.Font = new Font("Segoe UI", 9F);
            ToDate.Format = DateTimePickerFormat.Long;
            ToDate.Location = new Point(427, 45);
            ToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            ToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            ToDate.Name = "ToDate";
            ToDate.ShadowDecoration.CustomizableEdges = customizableEdges28;
            ToDate.Size = new Size(315, 36);
            ToDate.TabIndex = 22;
            ToDate.Value = new DateTime(2026, 3, 22, 0, 25, 41, 535);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(427, 22);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 21;
            label1.Text = "To Date";
            // 
            // FromDate
            // 
            FromDate.BackColor = Color.White;
            FromDate.BorderRadius = 8;
            FromDate.Checked = true;
            FromDate.CustomizableEdges = customizableEdges29;
            FromDate.FillColor = Color.White;
            FromDate.FocusedColor = Color.White;
            FromDate.Font = new Font("Segoe UI", 9F);
            FromDate.Format = DateTimePickerFormat.Long;
            FromDate.Location = new Point(29, 45);
            FromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            FromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            FromDate.Name = "FromDate";
            FromDate.ShadowDecoration.CustomizableEdges = customizableEdges30;
            FromDate.Size = new Size(296, 36);
            FromDate.TabIndex = 20;
            FromDate.Value = new DateTime(2026, 3, 22, 0, 25, 41, 535);
            FromDate.ValueChanged += FromDate_ValueChanged;
            // 
            // lbCustomerName
            // 
            lbCustomerName.AutoSize = true;
            lbCustomerName.BackColor = Color.White;
            lbCustomerName.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbCustomerName.ForeColor = Color.Black;
            lbCustomerName.Location = new Point(29, 22);
            lbCustomerName.Name = "lbCustomerName";
            lbCustomerName.Size = new Size(81, 20);
            lbCustomerName.TabIndex = 19;
            lbCustomerName.Text = "From Date";
            // 
            // Booking_list
            // 
            Booking_list.BackColor = Color.Transparent;
            Booking_list.Controls.Add(iconPictureBox7);
            Booking_list.Controls.Add(iconPictureBox6);
            Booking_list.Controls.Add(iconPictureBox5);
            Booking_list.Controls.Add(label5);
            Booking_list.Controls.Add(Booking_Report);
            Booking_list.FillColor = Color.White;
            Booking_list.Location = new Point(23, 383);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 425);
            Booking_list.TabIndex = 3;
            Booking_list.Paint += guna2ShadowPanel1_Paint_1;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Navy;
            label5.Location = new Point(29, 16);
            label5.Name = "label5";
            label5.Size = new Size(181, 25);
            label5.TabIndex = 20;
            label5.Text = "Booking Report List";
            // 
            // Report_Summary
            // 
            Report_Summary.BackColor = Color.Transparent;
            Report_Summary.Controls.Add(guna2ShadowPanel4);
            Report_Summary.Controls.Add(guna2ShadowPanel3);
            Report_Summary.Controls.Add(guna2ShadowPanel2);
            Report_Summary.Controls.Add(guna2ShadowPanel1);
            Report_Summary.Controls.Add(label9);
            Report_Summary.FillColor = Color.White;
            Report_Summary.Location = new Point(23, 189);
            Report_Summary.Name = "Report_Summary";
            Report_Summary.Radius = 8;
            Report_Summary.ShadowColor = Color.LightSteelBlue;
            Report_Summary.ShadowDepth = 80;
            Report_Summary.ShadowShift = 10;
            Report_Summary.Size = new Size(1405, 199);
            Report_Summary.TabIndex = 6;
            // 
            // guna2ShadowPanel4
            // 
            guna2ShadowPanel4.BackColor = Color.Transparent;
            guna2ShadowPanel4.Controls.Add(iconPictureBox4);
            guna2ShadowPanel4.Controls.Add(label13);
            guna2ShadowPanel4.Controls.Add(label14);
            guna2ShadowPanel4.FillColor = Color.Purple;
            guna2ShadowPanel4.Location = new Point(1074, 61);
            guna2ShadowPanel4.Name = "guna2ShadowPanel4";
            guna2ShadowPanel4.Radius = 6;
            guna2ShadowPanel4.ShadowColor = Color.DodgerBlue;
            guna2ShadowPanel4.Size = new Size(211, 100);
            guna2ShadowPanel4.TabIndex = 23;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.BackColor = Color.Blue;
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Bed;
            iconPictureBox4.IconColor = Color.White;
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.Location = new Point(165, 13);
            iconPictureBox4.Margin = new Padding(2);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(32, 32);
            iconPictureBox4.TabIndex = 21;
            iconPictureBox4.TabStop = false;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(80, 57);
            label13.Name = "label13";
            label13.Size = new Size(48, 28);
            label13.TabIndex = 22;
            label13.Text = "100";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(15, 13);
            label14.Name = "label14";
            label14.Size = new Size(90, 28);
            label14.TabIndex = 21;
            label14.Text = "Booking";
            // 
            // guna2ShadowPanel3
            // 
            guna2ShadowPanel3.BackColor = Color.Transparent;
            guna2ShadowPanel3.Controls.Add(iconPictureBox3);
            guna2ShadowPanel3.Controls.Add(label11);
            guna2ShadowPanel3.Controls.Add(label12);
            guna2ShadowPanel3.FillColor = Color.LimeGreen;
            guna2ShadowPanel3.Location = new Point(760, 61);
            guna2ShadowPanel3.Name = "guna2ShadowPanel3";
            guna2ShadowPanel3.Radius = 6;
            guna2ShadowPanel3.ShadowColor = Color.DodgerBlue;
            guna2ShadowPanel3.Size = new Size(211, 100);
            guna2ShadowPanel3.TabIndex = 23;
            // 
            // iconPictureBox3
            // 
            iconPictureBox3.BackColor = Color.Blue;
            iconPictureBox3.IconChar = FontAwesome.Sharp.IconChar.Bed;
            iconPictureBox3.IconColor = Color.White;
            iconPictureBox3.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox3.Location = new Point(165, 13);
            iconPictureBox3.Margin = new Padding(2);
            iconPictureBox3.Name = "iconPictureBox3";
            iconPictureBox3.Size = new Size(32, 32);
            iconPictureBox3.TabIndex = 21;
            iconPictureBox3.TabStop = false;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.White;
            label11.Location = new Point(80, 57);
            label11.Name = "label11";
            label11.Size = new Size(48, 28);
            label11.TabIndex = 22;
            label11.Text = "100";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(15, 13);
            label12.Name = "label12";
            label12.Size = new Size(90, 28);
            label12.TabIndex = 21;
            label12.Text = "Booking";
            // 
            // guna2ShadowPanel2
            // 
            guna2ShadowPanel2.BackColor = Color.Transparent;
            guna2ShadowPanel2.Controls.Add(iconPictureBox2);
            guna2ShadowPanel2.Controls.Add(label8);
            guna2ShadowPanel2.Controls.Add(label10);
            guna2ShadowPanel2.FillColor = Color.Salmon;
            guna2ShadowPanel2.Location = new Point(444, 61);
            guna2ShadowPanel2.Name = "guna2ShadowPanel2";
            guna2ShadowPanel2.Radius = 6;
            guna2ShadowPanel2.ShadowColor = Color.DodgerBlue;
            guna2ShadowPanel2.Size = new Size(211, 100);
            guna2ShadowPanel2.TabIndex = 21;
            // 
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.Blue;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Bed;
            iconPictureBox2.IconColor = Color.White;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.Location = new Point(165, 13);
            iconPictureBox2.Margin = new Padding(2);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(32, 32);
            iconPictureBox2.TabIndex = 21;
            iconPictureBox2.TabStop = false;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.White;
            label8.Location = new Point(80, 57);
            label8.Name = "label8";
            label8.Size = new Size(48, 28);
            label8.TabIndex = 22;
            label8.Text = "100";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.White;
            label10.Location = new Point(15, 13);
            label10.Name = "label10";
            label10.Size = new Size(90, 28);
            label10.TabIndex = 21;
            label10.Text = "Booking";
            // 
            // guna2ShadowPanel1
            // 
            guna2ShadowPanel1.BackColor = Color.Transparent;
            guna2ShadowPanel1.Controls.Add(iconPictureBox1);
            guna2ShadowPanel1.Controls.Add(label7);
            guna2ShadowPanel1.Controls.Add(label6);
            guna2ShadowPanel1.FillColor = Color.Blue;
            guna2ShadowPanel1.Location = new Point(114, 61);
            guna2ShadowPanel1.Name = "guna2ShadowPanel1";
            guna2ShadowPanel1.Radius = 6;
            guna2ShadowPanel1.ShadowColor = Color.DodgerBlue;
            guna2ShadowPanel1.Size = new Size(211, 100);
            guna2ShadowPanel1.TabIndex = 20;
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.Blue;
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Bed;
            iconPictureBox1.IconColor = Color.White;
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.Location = new Point(165, 13);
            iconPictureBox1.Margin = new Padding(2);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(32, 32);
            iconPictureBox1.TabIndex = 21;
            iconPictureBox1.TabStop = false;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.White;
            label7.Location = new Point(80, 57);
            label7.Name = "label7";
            label7.Size = new Size(48, 28);
            label7.TabIndex = 22;
            label7.Text = "100";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 13);
            label6.Name = "label6";
            label6.Size = new Size(90, 28);
            label6.TabIndex = 21;
            label6.Text = "Booking";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Navy;
            label9.Location = new Point(29, 22);
            label9.Name = "label9";
            label9.Size = new Size(157, 25);
            label9.TabIndex = 19;
            label9.Text = "Report Summary";
            // 
            // iconPictureBox5
            // 
            iconPictureBox5.BackColor = Color.White;
            iconPictureBox5.ForeColor = Color.Black;
            iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Print;
            iconPictureBox5.IconColor = Color.Black;
            iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox5.Location = new Point(1074, 16);
            iconPictureBox5.Margin = new Padding(2);
            iconPictureBox5.Name = "iconPictureBox5";
            iconPictureBox5.Size = new Size(32, 32);
            iconPictureBox5.TabIndex = 29;
            iconPictureBox5.TabStop = false;
            // 
            // iconPictureBox6
            // 
            iconPictureBox6.BackColor = Color.White;
            iconPictureBox6.ForeColor = Color.Green;
            iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            iconPictureBox6.IconColor = Color.Green;
            iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox6.Location = new Point(1120, 16);
            iconPictureBox6.Margin = new Padding(2);
            iconPictureBox6.Name = "iconPictureBox6";
            iconPictureBox6.Size = new Size(32, 32);
            iconPictureBox6.TabIndex = 30;
            iconPictureBox6.TabStop = false;
            // 
            // iconPictureBox7
            // 
            iconPictureBox7.BackColor = Color.White;
            iconPictureBox7.ForeColor = Color.Red;
            iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconPictureBox7.IconColor = Color.Red;
            iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox7.Location = new Point(1170, 16);
            iconPictureBox7.Margin = new Padding(2);
            iconPictureBox7.Name = "iconPictureBox7";
            iconPictureBox7.Size = new Size(32, 32);
            iconPictureBox7.TabIndex = 31;
            iconPictureBox7.TabStop = false;
            // 
            // Report_Booking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Report_Summary);
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_Booking";
            Size = new Size(1455, 811);
            Load += Report_Booking_Load;
            ((System.ComponentModel.ISupportInitialize)Booking_Report).EndInit();
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            Booking_list.ResumeLayout(false);
            Booking_list.PerformLayout();
            Report_Summary.ResumeLayout(false);
            Report_Summary.PerformLayout();
            guna2ShadowPanel4.ResumeLayout(false);
            guna2ShadowPanel4.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            guna2ShadowPanel3.ResumeLayout(false);
            guna2ShadowPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox3).EndInit();
            guna2ShadowPanel2.ResumeLayout(false);
            guna2ShadowPanel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            guna2ShadowPanel1.ResumeLayout(false);
            guna2ShadowPanel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Guna.UI2.WinForms.Guna2ShadowPanel SelectDateRoport;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Guna.UI2.WinForms.Guna2ComboBox RoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox Booking_Status;
        private Label label3;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchCustomer;
        private Guna.UI2.WinForms.Guna2ShadowPanel Booking_list;
        private DataGridView Booking_Report;
        private Label label5;
        private DataGridViewTextBoxColumn Booking;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
        private Guna.UI2.WinForms.Guna2ShadowPanel Report_Summary;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel4;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private Label label13;
        private Label label14;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel3;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox3;
        private Label label11;
        private Label label12;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel2;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private Label label8;
        private Label label10;
        private Guna.UI2.WinForms.Guna2ShadowPanel guna2ShadowPanel1;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label label7;
        private Label label6;
        private Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
    }
}
