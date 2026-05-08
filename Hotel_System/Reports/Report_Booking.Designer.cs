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
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges1 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges2 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges3 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges4 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges5 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges6 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges7 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges8 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges9 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges10 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
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
            btnflitter = new Guna.UI2.WinForms.Guna2Button();
            txtSearchCustomer = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            RoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            lblGrandtotal = new Label();
            lbldiscount = new Label();
            lbltotalAfterdis = new Label();
            lbltotalbeforedis = new Label();
            iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            Booking_Report = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Booking_Report).BeginInit();
            SelectDateRoport.SuspendLayout();
            Booking_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            SuspendLayout();
            // 
            // Booking_Report
            // 
            Booking_Report.AllowUserToAddRows = false;
            Booking_Report.BackgroundColor = Color.White;
            Booking_Report.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booking_Report.Columns.AddRange(new DataGridViewColumn[] { Booking, CustomerName, PhoneNumber, Room, dataGridViewTextBoxColumn1, CheckIn, Checkout, Status, Note });
            Booking_Report.Location = new Point(29, 68);
            Booking_Report.Name = "Booking_Report";
            Booking_Report.RowHeadersVisible = false;
            Booking_Report.RowHeadersWidth = 51;
            Booking_Report.Size = new Size(1350, 265);
            Booking_Report.TabIndex = 28;
            Booking_Report.CellContentClick += Booking_Report_CellContentClick_1;
            // 
            // Booking
            // 
            Booking.DataPropertyName = "booking_id";
            dataGridViewCellStyle1.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point, 0);
            Booking.DefaultCellStyle = dataGridViewCellStyle1;
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
            Note.Width = 170;
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(btnflitter);
            SelectDateRoport.Controls.Add(txtSearchCustomer);
            SelectDateRoport.Controls.Add(label4);
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
            // btnflitter
            // 
            btnflitter.BorderRadius = 8;
            btnflitter.CustomizableEdges = customizableEdges1;
            btnflitter.DisabledState.BorderColor = Color.DarkGray;
            btnflitter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnflitter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnflitter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnflitter.FillColor = Color.LimeGreen;
            btnflitter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnflitter.ForeColor = Color.White;
            btnflitter.Location = new Point(711, 45);
            btnflitter.Name = "btnflitter";
            btnflitter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnflitter.Size = new Size(71, 36);
            btnflitter.TabIndex = 63;
            btnflitter.Text = "Flitter";
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
            txtSearchCustomer.Size = new Size(377, 36);
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
            ToDate.Location = new Point(377, 45);
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
            label1.Location = new Point(377, 22);
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
            Booking_list.Controls.Add(lblGrandtotal);
            Booking_list.Controls.Add(lbldiscount);
            Booking_list.Controls.Add(lbltotalAfterdis);
            Booking_list.Controls.Add(lbltotalbeforedis);
            Booking_list.Controls.Add(iconPictureBox7);
            Booking_list.Controls.Add(iconPictureBox6);
            Booking_list.Controls.Add(iconPictureBox5);
            Booking_list.Controls.Add(label5);
            Booking_list.Controls.Add(Booking_Report);
            Booking_list.FillColor = Color.White;
            Booking_list.Location = new Point(23, 198);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 557);
            Booking_list.TabIndex = 3;
            Booking_list.Paint += guna2ShadowPanel1_Paint_1;
            // 
            // lblGrandtotal
            // 
            lblGrandtotal.AutoSize = true;
            lblGrandtotal.BackColor = Color.White;
            lblGrandtotal.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandtotal.ForeColor = Color.Black;
            lblGrandtotal.Location = new Point(1094, 461);
            lblGrandtotal.Name = "lblGrandtotal";
            lblGrandtotal.Size = new Size(116, 25);
            lblGrandtotal.TabIndex = 61;
            lblGrandtotal.Text = "Grand Total:";
            // 
            // lbldiscount
            // 
            lbldiscount.AutoSize = true;
            lbldiscount.BackColor = Color.White;
            lbldiscount.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldiscount.ForeColor = Color.Black;
            lbldiscount.Location = new Point(1113, 386);
            lbldiscount.Name = "lbldiscount";
            lbldiscount.Size = new Size(97, 25);
            lbldiscount.TabIndex = 60;
            lbldiscount.Text = " Discount:";
            // 
            // lbltotalAfterdis
            // 
            lbltotalAfterdis.AutoSize = true;
            lbltotalAfterdis.BackColor = Color.White;
            lbltotalAfterdis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalAfterdis.ForeColor = Color.Black;
            lbltotalAfterdis.Location = new Point(1022, 420);
            lbltotalAfterdis.Name = "lbltotalAfterdis";
            lbltotalAfterdis.Size = new Size(188, 25);
            lbltotalAfterdis.TabIndex = 59;
            lbltotalAfterdis.Text = "Totel After Discount:";
            // 
            // lbltotalbeforedis
            // 
            lbltotalbeforedis.AutoSize = true;
            lbltotalbeforedis.BackColor = Color.White;
            lbltotalbeforedis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalbeforedis.ForeColor = Color.Black;
            lbltotalbeforedis.Location = new Point(1009, 351);
            lbltotalbeforedis.Name = "lbltotalbeforedis";
            lbltotalbeforedis.Size = new Size(201, 25);
            lbltotalbeforedis.TabIndex = 58;
            lbltotalbeforedis.Text = "Totel Before Discount:";
            // 
            // iconPictureBox7
            // 
            iconPictureBox7.BackColor = Color.White;
            iconPictureBox7.ForeColor = Color.Red;
            iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconPictureBox7.IconColor = Color.Red;
            iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox7.Location = new Point(1326, 10);
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
            iconPictureBox6.Location = new Point(1279, 10);
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
            iconPictureBox5.Location = new Point(1230, 10);
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
            label5.Size = new Size(181, 25);
            label5.TabIndex = 20;
            label5.Text = "Booking Report List";
            // 
            // Report_Booking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_Booking";
            Size = new Size(1447, 811);
            Load += Report_Booking_Load;
            ((System.ComponentModel.ISupportInitialize)Booking_Report).EndInit();
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            Booking_list.ResumeLayout(false);
            Booking_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
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
        private Guna.UI2.WinForms.Guna2TextBox txtSearchCustomer;
        private Guna.UI2.WinForms.Guna2ShadowPanel Booking_list;
        private DataGridView Booking_Report;
        private Label label5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private DataGridViewTextBoxColumn Booking;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
        private Label lblGrandtotal;
        private Label lbldiscount;
        private Label lbltotalAfterdis;
        private Label lbltotalbeforedis;
        private Guna.UI2.WinForms.Guna2Button btnflitter;
    }
}
