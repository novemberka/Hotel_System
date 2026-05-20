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
            CustomerName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Total_Amount = new DataGridViewTextBoxColumn();
            Room_Service = new DataGridViewTextBoxColumn();
            Payment = new DataGridViewTextBoxColumn();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cmbCustomerName = new Guna.UI2.WinForms.Guna2ComboBox();
            btnflitter = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            RoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Booking_Report = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Booking_Report).BeginInit();
            Booking_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            SelectDateRoport.SuspendLayout();
            SuspendLayout();
            // 
            // Booking_Report
            // 
            Booking_Report.AllowUserToAddRows = false;
            Booking_Report.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Booking_Report.BackgroundColor = Color.White;
            Booking_Report.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booking_Report.Columns.AddRange(new DataGridViewColumn[] { CustomerName, PhoneNumber, Room, dataGridViewTextBoxColumn1, CheckIn, Checkout, Total_Amount, Room_Service, Payment });
            Booking_Report.Location = new Point(29, 68);
            Booking_Report.Name = "Booking_Report";
            Booking_Report.RowHeadersVisible = false;
            Booking_Report.RowHeadersWidth = 51;
            Booking_Report.Size = new Size(1350, 458);
            Booking_Report.TabIndex = 28;
            // 
            // CustomerName
            // 
            CustomerName.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CustomerName.DataPropertyName = "customer_name";
            CustomerName.HeaderText = "Customer Name";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            // 
            // PhoneNumber
            // 
            PhoneNumber.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            PhoneNumber.DataPropertyName = "phone_number";
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            // 
            // Room
            // 
            Room.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Room.DataPropertyName = "room";
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            // 
            // dataGridViewTextBoxColumn1
            // 
            dataGridViewTextBoxColumn1.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            dataGridViewTextBoxColumn1.DataPropertyName = "room_type";
            dataGridViewTextBoxColumn1.HeaderText = "Room Type";
            dataGridViewTextBoxColumn1.MinimumWidth = 6;
            dataGridViewTextBoxColumn1.Name = "dataGridViewTextBoxColumn1";
            // 
            // CheckIn
            // 
            CheckIn.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            CheckIn.DataPropertyName = "check-in";
            CheckIn.HeaderText = "Check In";
            CheckIn.MinimumWidth = 6;
            CheckIn.Name = "CheckIn";
            // 
            // Checkout
            // 
            Checkout.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Checkout.DataPropertyName = "check-out";
            Checkout.HeaderText = "Check Out";
            Checkout.MinimumWidth = 6;
            Checkout.Name = "Checkout";
            // 
            // Total_Amount
            // 
            Total_Amount.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Total_Amount.DataPropertyName = "total_amount";
            Total_Amount.HeaderText = "Total Amount";
            Total_Amount.MinimumWidth = 6;
            Total_Amount.Name = "Total_Amount";
            // 
            // Room_Service
            // 
            Room_Service.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Room_Service.DataPropertyName = "AmountPaid";
            Room_Service.HeaderText = "Amount Paid";
            Room_Service.MinimumWidth = 6;
            Room_Service.Name = "Room_Service";
            // 
            // Payment
            // 
            Payment.AutoSizeMode = DataGridViewAutoSizeColumnMode.Fill;
            Payment.DataPropertyName = "payment";
            Payment.HeaderText = "Payment";
            Payment.MinimumWidth = 6;
            Payment.Name = "Payment";
            // 
            // Booking_list
            // 
            Booking_list.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            Booking_list.BackColor = Color.Transparent;
            Booking_list.Controls.Add(iconPictureBox6);
            Booking_list.Controls.Add(label5);
            Booking_list.Controls.Add(Booking_Report);
            Booking_list.FillColor = Color.White;
            Booking_list.Location = new Point(25, 197);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 549);
            Booking_list.TabIndex = 8;
            // 
            // iconPictureBox6
            // 
            iconPictureBox6.Anchor = AnchorStyles.Top | AnchorStyles.Right;
            iconPictureBox6.BackColor = Color.White;
            iconPictureBox6.ForeColor = Color.Green;
            iconPictureBox6.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            iconPictureBox6.IconColor = Color.Green;
            iconPictureBox6.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox6.Location = new Point(1347, 16);
            iconPictureBox6.Margin = new Padding(2);
            iconPictureBox6.Name = "iconPictureBox6";
            iconPictureBox6.Size = new Size(32, 32);
            iconPictureBox6.TabIndex = 30;
            iconPictureBox6.TabStop = false;
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
            SelectDateRoport.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(cmbCustomerName);
            SelectDateRoport.Controls.Add(btnflitter);
            SelectDateRoport.Controls.Add(label4);
            SelectDateRoport.Controls.Add(RoomType);
            SelectDateRoport.Controls.Add(label2);
            SelectDateRoport.Controls.Add(ToDate);
            SelectDateRoport.Controls.Add(label1);
            SelectDateRoport.Controls.Add(FromDate);
            SelectDateRoport.Controls.Add(lbCustomerName);
            SelectDateRoport.FillColor = Color.White;
            SelectDateRoport.Location = new Point(25, 3);
            SelectDateRoport.Name = "SelectDateRoport";
            SelectDateRoport.Radius = 8;
            SelectDateRoport.ShadowColor = Color.LightSteelBlue;
            SelectDateRoport.ShadowDepth = 80;
            SelectDateRoport.ShadowShift = 10;
            SelectDateRoport.Size = new Size(1405, 180);
            SelectDateRoport.TabIndex = 7;
            // 
            // cmbCustomerName
            // 
            cmbCustomerName.BackColor = Color.Transparent;
            cmbCustomerName.BorderColor = Color.Silver;
            cmbCustomerName.BorderRadius = 8;
            cmbCustomerName.CustomizableEdges = customizableEdges1;
            cmbCustomerName.DrawMode = DrawMode.OwnerDrawFixed;
            cmbCustomerName.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCustomerName.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbCustomerName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbCustomerName.Font = new Font("Segoe UI", 10F);
            cmbCustomerName.ForeColor = Color.FromArgb(68, 88, 112);
            cmbCustomerName.ItemHeight = 30;
            cmbCustomerName.Items.AddRange(new object[] { "All", "Single", "Double", "VIP" });
            cmbCustomerName.Location = new Point(29, 119);
            cmbCustomerName.Name = "cmbCustomerName";
            cmbCustomerName.ShadowDecoration.CustomizableEdges = customizableEdges2;
            cmbCustomerName.Size = new Size(296, 36);
            cmbCustomerName.TabIndex = 65;
            // 
            // btnflitter
            // 
            btnflitter.BorderRadius = 8;
            btnflitter.CustomizableEdges = customizableEdges3;
            btnflitter.DisabledState.BorderColor = Color.DarkGray;
            btnflitter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnflitter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnflitter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnflitter.FillColor = Color.LimeGreen;
            btnflitter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnflitter.ForeColor = Color.White;
            btnflitter.Location = new Point(729, 45);
            btnflitter.Name = "btnflitter";
            btnflitter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnflitter.Size = new Size(71, 36);
            btnflitter.TabIndex = 64;
            btnflitter.Text = "Filter";
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
            ToDate.Location = new Point(389, 45);
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
            label1.Location = new Point(389, 22);
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
            // Report_Payment
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_Payment";
            Size = new Size(1455, 800);
            Load += Report_Payment_Load;
            ((System.ComponentModel.ISupportInitialize)Booking_Report).EndInit();
            Booking_list.ResumeLayout(false);
            Booking_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel Booking_list;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private Label label5;
        private Guna.UI2.WinForms.Guna2ShadowPanel SelectDateRoport;
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox RoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2Button btnflitter;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCustomerName;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Total_Amount;
        private DataGridViewTextBoxColumn Room_Service;
        private DataGridViewTextBoxColumn Payment;
    }
}
