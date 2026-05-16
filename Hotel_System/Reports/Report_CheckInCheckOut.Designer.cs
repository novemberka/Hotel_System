namespace Hotel_System
{
    partial class Report_CheckInCheckOut
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges13 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges14 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges15 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges16 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges17 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges18 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges19 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges20 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            CustomerName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            dataGridViewTextBoxColumn1 = new DataGridViewTextBoxColumn();
            Room_number = new DataGridViewTextBoxColumn();
            ID_passport = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Sub_total = new DataGridViewTextBoxColumn();
            discount = new DataGridViewTextBoxColumn();
            Total_price = new DataGridViewTextBoxColumn();
            Payment_method = new DataGridViewTextBoxColumn();
            deposit = new DataGridViewTextBoxColumn();
            remaining = new DataGridViewTextBoxColumn();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
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
            lblGrandtotal = new Label();
            lbldiscount = new Label();
            lbltotalAfterdis = new Label();
            lbltotalbeforedis = new Label();
            Booking_Report = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)Booking_Report).BeginInit();
            Booking_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            SelectDateRoport.SuspendLayout();
            SuspendLayout();
            // 
            // Booking_Report
            // 
            Booking_Report.AllowUserToAddRows = false;
            Booking_Report.BackgroundColor = Color.White;
            Booking_Report.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            Booking_Report.Columns.AddRange(new DataGridViewColumn[] { CustomerName, PhoneNumber, Room, dataGridViewTextBoxColumn1, Room_number, ID_passport, CheckIn, Checkout, Sub_total, discount, Total_price, Payment_method, deposit, remaining });
            Booking_Report.Location = new Point(29, 65);
            Booking_Report.Name = "Booking_Report";
            Booking_Report.RowHeadersVisible = false;
            Booking_Report.RowHeadersWidth = 51;
            Booking_Report.Size = new Size(1376, 265);
            Booking_Report.TabIndex = 28;
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
            // Room_number
            // 
            Room_number.DataPropertyName = "room_number";
            Room_number.HeaderText = "Room Number";
            Room_number.MinimumWidth = 6;
            Room_number.Name = "Room_number";
            Room_number.Width = 140;
            // 
            // ID_passport
            // 
            ID_passport.DataPropertyName = "id_passport";
            ID_passport.HeaderText = "ID/Passport";
            ID_passport.MinimumWidth = 6;
            ID_passport.Name = "ID_passport";
            ID_passport.Width = 125;
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
            // Sub_total
            // 
            Sub_total.DataPropertyName = "sub_total";
            Sub_total.HeaderText = "Sub Total";
            Sub_total.MinimumWidth = 6;
            Sub_total.Name = "Sub_total";
            Sub_total.Width = 125;
            // 
            // discount
            // 
            discount.DataPropertyName = "discount";
            discount.HeaderText = "Discount";
            discount.MinimumWidth = 6;
            discount.Name = "discount";
            discount.Width = 125;
            // 
            // Total_price
            // 
            Total_price.DataPropertyName = "total_price";
            Total_price.HeaderText = "Total Price";
            Total_price.MinimumWidth = 6;
            Total_price.Name = "Total_price";
            Total_price.Width = 125;
            // 
            // Payment_method
            // 
            Payment_method.DataPropertyName = "payment_method";
            Payment_method.HeaderText = "Payment Method";
            Payment_method.MinimumWidth = 6;
            Payment_method.Name = "Payment_method";
            Payment_method.Width = 125;
            // 
            // deposit
            // 
            deposit.DataPropertyName = "deposit";
            deposit.HeaderText = "Deposit";
            deposit.MinimumWidth = 6;
            deposit.Name = "deposit";
            deposit.Width = 125;
            // 
            // remaining
            // 
            remaining.DataPropertyName = "Remaining";
            remaining.HeaderText = "Remaining";
            remaining.MinimumWidth = 6;
            remaining.Name = "remaining";
            remaining.Width = 125;
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
            Booking_list.Location = new Point(25, 194);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 549);
            Booking_list.TabIndex = 8;
            // 
            // iconPictureBox7
            // 
            iconPictureBox7.BackColor = Color.White;
            iconPictureBox7.ForeColor = Color.Red;
            iconPictureBox7.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconPictureBox7.IconColor = Color.Red;
            iconPictureBox7.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox7.Location = new Point(1330, 16);
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
            iconPictureBox6.Location = new Point(1282, 16);
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
            iconPictureBox5.Location = new Point(1230, 16);
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
            label5.Size = new Size(280, 25);
            label5.TabIndex = 20;
            label5.Text = "Check-In_Check-Out Report List";
            // 
            // SelectDateRoport
            // 
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
            SelectDateRoport.Location = new Point(25, -2);
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
            cmbCustomerName.CustomizableEdges = customizableEdges11;
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
            cmbCustomerName.ShadowDecoration.CustomizableEdges = customizableEdges12;
            cmbCustomerName.Size = new Size(296, 36);
            cmbCustomerName.TabIndex = 65;
            // 
            // btnflitter
            // 
            btnflitter.BorderRadius = 8;
            btnflitter.CustomizableEdges = customizableEdges13;
            btnflitter.DisabledState.BorderColor = Color.DarkGray;
            btnflitter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnflitter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnflitter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnflitter.FillColor = Color.LimeGreen;
            btnflitter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnflitter.ForeColor = Color.White;
            btnflitter.Location = new Point(721, 45);
            btnflitter.Name = "btnflitter";
            btnflitter.ShadowDecoration.CustomizableEdges = customizableEdges14;
            btnflitter.Size = new Size(71, 36);
            btnflitter.TabIndex = 64;
            btnflitter.Text = "Flitter";
            btnflitter.Click += btnflitter_Click;
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
            RoomType.CustomizableEdges = customizableEdges15;
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
            RoomType.ShadowDecoration.CustomizableEdges = customizableEdges16;
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
            ToDate.CustomizableEdges = customizableEdges17;
            ToDate.FillColor = Color.White;
            ToDate.FocusedColor = Color.White;
            ToDate.Font = new Font("Segoe UI", 9F);
            ToDate.Format = DateTimePickerFormat.Long;
            ToDate.Location = new Point(385, 45);
            ToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            ToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            ToDate.Name = "ToDate";
            ToDate.ShadowDecoration.CustomizableEdges = customizableEdges18;
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
            label1.Location = new Point(385, 22);
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
            FromDate.CustomizableEdges = customizableEdges19;
            FromDate.FillColor = Color.White;
            FromDate.FocusedColor = Color.White;
            FromDate.Font = new Font("Segoe UI", 9F);
            FromDate.Format = DateTimePickerFormat.Long;
            FromDate.Location = new Point(29, 45);
            FromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            FromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            FromDate.Name = "FromDate";
            FromDate.ShadowDecoration.CustomizableEdges = customizableEdges20;
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
            // lblGrandtotal
            // 
            lblGrandtotal.AutoSize = true;
            lblGrandtotal.BackColor = Color.White;
            lblGrandtotal.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGrandtotal.ForeColor = Color.Black;
            lblGrandtotal.Location = new Point(1045, 462);
            lblGrandtotal.Name = "lblGrandtotal";
            lblGrandtotal.Size = new Size(116, 25);
            lblGrandtotal.TabIndex = 65;
            lblGrandtotal.Text = "Grand Total:";
            // 
            // lbldiscount
            // 
            lbldiscount.AutoSize = true;
            lbldiscount.BackColor = Color.White;
            lbldiscount.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbldiscount.ForeColor = Color.Black;
            lbldiscount.Location = new Point(1064, 387);
            lbldiscount.Name = "lbldiscount";
            lbldiscount.Size = new Size(97, 25);
            lbldiscount.TabIndex = 64;
            lbldiscount.Text = " Discount:";
            // 
            // lbltotalAfterdis
            // 
            lbltotalAfterdis.AutoSize = true;
            lbltotalAfterdis.BackColor = Color.White;
            lbltotalAfterdis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalAfterdis.ForeColor = Color.Black;
            lbltotalAfterdis.Location = new Point(973, 421);
            lbltotalAfterdis.Name = "lbltotalAfterdis";
            lbltotalAfterdis.Size = new Size(188, 25);
            lbltotalAfterdis.TabIndex = 63;
            lbltotalAfterdis.Text = "Totel After Discount:";
            // 
            // lbltotalbeforedis
            // 
            lbltotalbeforedis.AutoSize = true;
            lbltotalbeforedis.BackColor = Color.White;
            lbltotalbeforedis.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbltotalbeforedis.ForeColor = Color.Black;
            lbltotalbeforedis.Location = new Point(960, 352);
            lbltotalbeforedis.Name = "lbltotalbeforedis";
            lbltotalbeforedis.Size = new Size(201, 25);
            lbltotalbeforedis.TabIndex = 62;
            lbltotalbeforedis.Text = "Totel Before Discount:";
            // 
            // Report_CheckOut
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_CheckOut";
            Size = new Size(1455, 800);
            ((System.ComponentModel.ISupportInitialize)Booking_Report).EndInit();
            Booking_list.ResumeLayout(false);
            Booking_list.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).EndInit();
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
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn dataGridViewTextBoxColumn1;
        private DataGridViewTextBoxColumn Room_number;
        private DataGridViewTextBoxColumn ID_passport;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Sub_total;
        private DataGridViewTextBoxColumn discount;
        private DataGridViewTextBoxColumn Total_price;
        private DataGridViewTextBoxColumn Payment_method;
        private DataGridViewTextBoxColumn deposit;
        private DataGridViewTextBoxColumn remaining;
        private Guna.UI2.WinForms.Guna2Button btnflitter;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCustomerName;
        private Label lblGrandtotal;
        private Label lbldiscount;
        private Label lbltotalAfterdis;
        private Label lbltotalbeforedis;
    }
}
