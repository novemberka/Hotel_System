namespace Hotel_System
{
    partial class Report_Payment
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            txtSearchCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            label3 = new Label();
            RoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Report_Summary = new Guna.UI2.WinForms.Guna2ShadowPanel();
            ptotal_price = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox4 = new FontAwesome.Sharp.IconPictureBox();
            lbTotal_amount = new Label();
            label14 = new Label();
            ptotalPrice = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lbService_charge = new Label();
            label = new Label();
            pbooking = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            lbRoomService = new Label();
            label6 = new Label();
            label9 = new Label();
            iconPictureBox2 = new FontAwesome.Sharp.IconPictureBox();
            CustomerName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Room_Service = new DataGridViewTextBoxColumn();
            Service_charge = new DataGridViewTextBoxColumn();
            Total_Amount = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            txtRoomNumber = new Guna.UI2.WinForms.Guna2TextBox();
            Booking_Report = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Booking_Report).BeginInit();
            Booking_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            SelectDateRoport.SuspendLayout();
            Report_Summary.SuspendLayout();
            ptotal_price.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).BeginInit();
            ptotalPrice.SuspendLayout();
            pbooking.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).BeginInit();
            SuspendLayout();
            // 
            // Booking_Report
            // 
            Booking_Report.BackgroundColor = Color.White;
            Booking_Report.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booking_Report.Columns.AddRange(new DataGridViewColumn[] { CustomerName, PhoneNumber, Room, dataGridViewTextBoxColumn1, CheckIn, Checkout, Room_Service, Service_charge, Total_Amount, Payment });
            Booking_Report.Location = new Point(29, 68);
            Booking_Report.Name = "Booking_Report";
            Booking_Report.RowHeadersWidth = 51;
            Booking_Report.Size = new Size(1350, 265);
            Booking_Report.TabIndex = 28;
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
            Booking_list.Location = new Point(25, 378);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 425);
            Booking_list.TabIndex = 8;
            // 
            // iconPictureBox7
            // 
            iconPictureBox7.BackColor = Color.White;
            iconPictureBox7.ForeColor = Color.Red;
            iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconPictureBox7.IconColor = Color.Red;
            iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox7.Location = new Point(1274, 16);
            iconPictureBox7.Margin = new Padding(2);
            iconPictureBox7.Name = "iconPictureBox7";
            iconPictureBox7.Size = new Size(32, 32);
            iconPictureBox7.TabIndex = 31;
            iconPictureBox7.TabStop = false;
            // 
            // iconPictureBox6
            // 
            iconPictureBox6.BackColor = Color.White;
            iconPictureBox6.ForeColor = Color.Green;
            iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            iconPictureBox6.IconColor = Color.Green;
            iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox6.Location = new Point(1323, 16);
            iconPictureBox6.Margin = new Padding(2);
            iconPictureBox6.Name = "iconPictureBox6";
            iconPictureBox6.Size = new Size(32, 32);
            iconPictureBox6.TabIndex = 30;
            iconPictureBox6.TabStop = false;
            // 
            // iconPictureBox5
            // 
            iconPictureBox5.BackColor = Color.White;
            iconPictureBox5.ForeColor = Color.Black;
            iconPictureBox5.IconChar = FontAwesome.Sharp.IconChar.Print;
            iconPictureBox5.IconColor = Color.Black;
            iconPictureBox5.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox5.Location = new Point(1226, 16);
            iconPictureBox5.Margin = new Padding(2);
            iconPictureBox5.Name = "iconPictureBox5";
            iconPictureBox5.Size = new Size(32, 32);
            iconPictureBox5.TabIndex = 29;
            iconPictureBox5.TabStop = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Navy;
            label5.Location = new Point(29, 16);
            label5.Name = "label5";
            label5.Size = new Size(185, 25);
            label5.TabIndex = 20;
            label5.Text = "Payment Report List";
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(txtRoomNumber);
            SelectDateRoport.Controls.Add(txtSearchCustomer);
            SelectDateRoport.Controls.Add(label4);
            SelectDateRoport.Controls.Add(label3);
            SelectDateRoport.Controls.Add(RoomType);
            SelectDateRoport.Controls.Add(label2);
            SelectDateRoport.Controls.Add(ToDate);
            SelectDateRoport.Controls.Add(label1);
            SelectDateRoport.Controls.Add(FromDate);
            SelectDateRoport.Controls.Add(lbCustomerName);
            SelectDateRoport.FillColor = Color.White;
            SelectDateRoport.Location = new Point(25, -2);
            SelectDateRoport.Name = "SelectDateRoport";
            SelectDateRoport.Radius = 8;
            SelectDateRoport.ShadowColor = Color.LightSteelBlue;
            SelectDateRoport.ShadowDepth = 80;
            SelectDateRoport.ShadowShift = 10;
            SelectDateRoport.Size = new Size(1405, 180);
            SelectDateRoport.TabIndex = 7;
            // 
            // txtSearchCustomer
            // 
            txtSearchCustomer.BorderColor = Color.Silver;
            txtSearchCustomer.BorderRadius = 6;
            txtSearchCustomer.CustomizableEdges = customizableEdges3;
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
            txtSearchCustomer.ShadowDecoration.CustomizableEdges = customizableEdges4;
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
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(836, 96);
            label3.Name = "label3";
            label3.Size = new Size(110, 20);
            label3.TabIndex = 25;
            label3.Text = "Room Number";
            // 
            // RoomType
            // 
            RoomType.BackColor = Color.Transparent;
            RoomType.BorderColor = Color.Silver;
            RoomType.BorderRadius = 8;
            RoomType.CustomizableEdges = customizableEdges5;
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
            RoomType.ShadowDecoration.CustomizableEdges = customizableEdges6;
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
            ToDate.CustomizableEdges = customizableEdges7;
            ToDate.FillColor = Color.White;
            ToDate.FocusedColor = Color.White;
            ToDate.Font = new Font("Segoe UI", 9F);
            ToDate.Format = DateTimePickerFormat.Long;
            ToDate.Location = new Point(427, 45);
            ToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            ToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            ToDate.Name = "ToDate";
            ToDate.ShadowDecoration.CustomizableEdges = customizableEdges8;
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
            FromDate.CustomizableEdges = customizableEdges9;
            FromDate.FillColor = Color.White;
            FromDate.FocusedColor = Color.White;
            FromDate.Font = new Font("Segoe UI", 9F);
            FromDate.Format = DateTimePickerFormat.Long;
            FromDate.Location = new Point(29, 45);
            FromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            FromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            FromDate.Name = "FromDate";
            FromDate.ShadowDecoration.CustomizableEdges = customizableEdges10;
            FromDate.Size = new Size(296, 36);
            FromDate.TabIndex = 20;
            FromDate.Value = new DateTime(2026, 3, 22, 0, 25, 41, 535);
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
            // Report_Summary
            // 
            Report_Summary.BackColor = Color.Transparent;
            Report_Summary.Controls.Add(ptotal_price);
            Report_Summary.Controls.Add(ptotalPrice);
            Report_Summary.Controls.Add(pbooking);
            Report_Summary.Controls.Add(label9);
            Report_Summary.FillColor = Color.White;
            Report_Summary.Location = new Point(22, 173);
            Report_Summary.Name = "Report_Summary";
            Report_Summary.Radius = 8;
            Report_Summary.ShadowColor = Color.LightSteelBlue;
            Report_Summary.ShadowDepth = 80;
            Report_Summary.ShadowShift = 10;
            Report_Summary.Size = new Size(1405, 199);
            Report_Summary.TabIndex = 9;
            // 
            // ptotal_price
            // 
            ptotal_price.BackColor = Color.Transparent;
            ptotal_price.Controls.Add(iconPictureBox4);
            ptotal_price.Controls.Add(lbTotal_amount);
            ptotal_price.Controls.Add(label14);
            ptotal_price.FillColor = Color.DarkBlue;
            ptotal_price.Location = new Point(928, 61);
            ptotal_price.Name = "ptotal_price";
            ptotal_price.Radius = 6;
            ptotal_price.ShadowColor = Color.DarkBlue;
            ptotal_price.ShadowDepth = 60;
            ptotal_price.ShadowShift = 4;
            ptotal_price.Size = new Size(211, 100);
            ptotal_price.TabIndex = 23;
            // 
            // iconPictureBox4
            // 
            iconPictureBox4.BackColor = Color.DarkBlue;
            iconPictureBox4.IconChar = FontAwesome.Sharp.IconChar.Receipt;
            iconPictureBox4.IconColor = Color.White;
            iconPictureBox4.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox4.Location = new Point(165, 13);
            iconPictureBox4.Margin = new Padding(2);
            iconPictureBox4.Name = "iconPictureBox4";
            iconPictureBox4.Size = new Size(32, 32);
            iconPictureBox4.TabIndex = 21;
            iconPictureBox4.TabStop = false;
            // 
            // lbTotal_amount
            // 
            lbTotal_amount.AutoSize = true;
            lbTotal_amount.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotal_amount.ForeColor = Color.White;
            lbTotal_amount.Location = new Point(80, 57);
            lbTotal_amount.Name = "lbTotal_amount";
            lbTotal_amount.Size = new Size(84, 28);
            lbTotal_amount.TabIndex = 22;
            lbTotal_amount.Text = "$24500";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label14.ForeColor = Color.White;
            label14.Location = new Point(15, 13);
            label14.Name = "label14";
            label14.Size = new Size(141, 28);
            label14.TabIndex = 21;
            label14.Text = "Total Amount";
            // 
            // ptotalPrice
            // 
            ptotalPrice.BackColor = Color.Transparent;
            ptotalPrice.Controls.Add(iconPictureBox2);
            ptotalPrice.Controls.Add(lbService_charge);
            ptotalPrice.Controls.Add(label);
            ptotalPrice.FillColor = Color.Indigo;
            ptotalPrice.Location = new Point(614, 61);
            ptotalPrice.Name = "ptotalPrice";
            ptotalPrice.Radius = 6;
            ptotalPrice.ShadowColor = Color.Indigo;
            ptotalPrice.ShadowDepth = 60;
            ptotalPrice.ShadowShift = 3;
            ptotalPrice.Size = new Size(211, 100);
            ptotalPrice.TabIndex = 21;
            // 
            // lbService_charge
            // 
            lbService_charge.AutoSize = true;
            lbService_charge.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbService_charge.ForeColor = Color.White;
            lbService_charge.Location = new Point(80, 57);
            lbService_charge.Name = "lbService_charge";
            lbService_charge.Size = new Size(48, 28);
            lbService_charge.TabIndex = 22;
            lbService_charge.Text = "200";
            // 
            // label
            // 
            label.AutoSize = true;
            label.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label.ForeColor = Color.White;
            label.Location = new Point(15, 13);
            label.Name = "label";
            label.Size = new Size(151, 28);
            label.TabIndex = 21;
            label.Text = "Service charge";
            // 
            // pbooking
            // 
            pbooking.BackColor = Color.Transparent;
            pbooking.Controls.Add(iconPictureBox1);
            pbooking.Controls.Add(lbRoomService);
            pbooking.Controls.Add(label6);
            pbooking.FillColor = Color.Blue;
            pbooking.Location = new Point(313, 61);
            pbooking.Name = "pbooking";
            pbooking.Radius = 6;
            pbooking.ShadowColor = Color.Blue;
            pbooking.ShadowDepth = 60;
            pbooking.ShadowShift = 3;
            pbooking.Size = new Size(211, 100);
            pbooking.TabIndex = 20;
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
            // lbRoomService
            // 
            lbRoomService.AutoSize = true;
            lbRoomService.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbRoomService.ForeColor = Color.White;
            lbRoomService.Location = new Point(80, 57);
            lbRoomService.Name = "lbRoomService";
            lbRoomService.Size = new Size(48, 28);
            lbRoomService.TabIndex = 22;
            lbRoomService.Text = "100";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(15, 13);
            label6.Name = "label6";
            label6.Size = new Size(142, 28);
            label6.TabIndex = 21;
            label6.Text = "Room Service";
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
            // iconPictureBox2
            // 
            iconPictureBox2.BackColor = Color.Indigo;
            iconPictureBox2.IconChar = FontAwesome.Sharp.IconChar.Calculator;
            iconPictureBox2.IconColor = Color.White;
            iconPictureBox2.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox2.Location = new Point(171, 13);
            iconPictureBox2.Margin = new Padding(2);
            iconPictureBox2.Name = "iconPictureBox2";
            iconPictureBox2.Size = new Size(32, 32);
            iconPictureBox2.TabIndex = 21;
            iconPictureBox2.TabStop = false;
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
            CheckIn.Width = 120;
            // 
            // Checkout
            // 
            Checkout.DataPropertyName = "check-out";
            Checkout.HeaderText = "Check Out";
            Checkout.MinimumWidth = 6;
            Checkout.Name = "Checkout";
            Checkout.Width = 120;
            // 
            // Room_Service
            // 
            Room_Service.DataPropertyName = "room_service";
            Room_Service.HeaderText = "Room Service";
            Room_Service.MinimumWidth = 6;
            Room_Service.Name = "Room_Service";
            Room_Service.Width = 150;
            // 
            // Service_charge
            // 
            Service_charge.DataPropertyName = "service_charge";
            Service_charge.HeaderText = "Service Charge";
            Service_charge.MinimumWidth = 6;
            Service_charge.Name = "Service_charge";
            Service_charge.Width = 150;
            // 
            // Total_Amount
            // 
            Total_Amount.DataPropertyName = "total_amount";
            Total_Amount.HeaderText = "Total Amount";
            Total_Amount.MinimumWidth = 6;
            Total_Amount.Name = "Total_Amount";
            Total_Amount.Width = 140;
            // 
            // Payment
            // 
            Payment.DataPropertyName = "payment";
            Payment.HeaderText = "Payment";
            Payment.MinimumWidth = 6;
            Payment.Name = "Payment";
            Payment.Width = 125;
            // 
            // txtRoomNumber
            // 
            txtRoomNumber.BorderColor = Color.Black;
            txtRoomNumber.BorderRadius = 6;
            txtRoomNumber.CustomizableEdges = customizableEdges1;
            txtRoomNumber.DefaultText = "";
            txtRoomNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtRoomNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtRoomNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtRoomNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtRoomNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoomNumber.Font = new Font("Segoe UI", 9F);
            txtRoomNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtRoomNumber.Location = new Point(837, 120);
            txtRoomNumber.Margin = new Padding(3, 4, 3, 4);
            txtRoomNumber.Name = "txtRoomNumber";
            txtRoomNumber.PlaceholderText = "";
            txtRoomNumber.SelectedText = "";
            txtRoomNumber.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtRoomNumber.Size = new Size(209, 36);
            txtRoomNumber.TabIndex = 56;
            // 
            // Report_Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Report_Summary);
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_Payment";
            Size = new Size(1455, 800);
            Load += Report_Payment_Load;
            ((System.ComponentModel.ISupportInitialize)Booking_Report).EndInit();
            Booking_list.ResumeLayout(false);
            Booking_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            Report_Summary.ResumeLayout(false);
            Report_Summary.PerformLayout();
            ptotal_price.ResumeLayout(false);
            ptotal_price.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox4).EndInit();
            ptotalPrice.ResumeLayout(false);
            ptotalPrice.PerformLayout();
            pbooking.ResumeLayout(false);
            pbooking.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox2).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel Booking_list;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private Label label5;
        private Guna.UI2.WinForms.Guna2ShadowPanel SelectDateRoport;
        private Guna.UI2.WinForms.Guna2TextBox txtSearchCustomer;
        private Label label4;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox RoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2ShadowPanel Report_Summary;
        private Guna.UI2.WinForms.Guna2ShadowPanel ptotal_price;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox4;
        private Label lbTotal_amount;
        private Label label14;
        private Guna.UI2.WinForms.Guna2ShadowPanel ptotalPrice;
        private Label lbService_charge;
        private Label label;
        private Guna.UI2.WinForms.Guna2ShadowPanel pbooking;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Label lbRoomService;
        private Label label6;
        private Label label9;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox2;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Room_Service;
        private DataGridViewTextBoxColumn Service_charge;
        private DataGridViewTextBoxColumn Total_Amount;
        private DataGridViewTextBoxColumn Payment;
        private Guna.UI2.WinForms.Guna2TextBox txtRoomNumber;
    }
}
