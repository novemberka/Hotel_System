namespace Hotel_System
{
    partial class History_Room
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
            Customer_history = new GroupBox();
            label25 = new Label();
            dataGridView1 = new DataGridView();
            BookingID = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            Note = new DataGridViewTextBoxColumn();
            label17 = new Label();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            panel1 = new Panel();
            search = new Label();
            iconPictureBox1 = new FontAwesome.Sharp.IconPictureBox();
            btnFilter = new Guna.UI2.WinForms.Guna2Button();
            Booking_Status = new Guna.UI2.WinForms.Guna2ComboBox();
            label3 = new Label();
            RoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Customer_history.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SelectDateRoport.SuspendLayout();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).BeginInit();
            SuspendLayout();
            // 
            // Customer_history
            // 
            Customer_history.Controls.Add(label25);
            Customer_history.Controls.Add(dataGridView1);
            Customer_history.Controls.Add(label17);
            Customer_history.FlatStyle = FlatStyle.Flat;
            Customer_history.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Customer_history.ForeColor = Color.MidnightBlue;
            Customer_history.Location = new Point(21, 203);
            Customer_history.Name = "Customer_history";
            Customer_history.Size = new Size(1411, 472);
            Customer_history.TabIndex = 17;
            Customer_history.TabStop = false;
            Customer_history.Text = "Room History";
            // 
            // label25
            // 
            label25.AutoSize = true;
            label25.BackColor = Color.White;
            label25.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label25.ForeColor = Color.Black;
            label25.Location = new Point(759, 176);
            label25.Name = "label25";
            label25.Size = new Size(0, 20);
            label25.TabIndex = 45;
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BookingID, CustomerName, PhoneNumber, Room, CheckIn, Checkout, Status, Note });
            dataGridView1.Location = new Point(0, 29);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1455, 800);
            dataGridView1.TabIndex = 27;
            // 
            // BookingID
            // 
            BookingID.HeaderText = "Booking ID";
            BookingID.MinimumWidth = 6;
            BookingID.Name = "BookingID";
            BookingID.Resizable = DataGridViewTriState.True;
            BookingID.Width = 150;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Customer Name";
            CustomerName.MinimumWidth = 6;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 200;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 200;
            // 
            // Room
            // 
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 150;
            // 
            // CheckIn
            // 
            CheckIn.HeaderText = "Check In";
            CheckIn.MinimumWidth = 6;
            CheckIn.Name = "CheckIn";
            CheckIn.Width = 125;
            // 
            // Checkout
            // 
            Checkout.HeaderText = "Check Out";
            Checkout.MinimumWidth = 6;
            Checkout.Name = "Checkout";
            Checkout.Width = 125;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // Note
            // 
            Note.HeaderText = "Note";
            Note.MinimumWidth = 6;
            Note.Name = "Note";
            Note.Width = 280;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.White;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(580, 155);
            label17.Name = "label17";
            label17.Size = new Size(0, 20);
            label17.TabIndex = 26;
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(panel1);
            SelectDateRoport.Controls.Add(btnFilter);
            SelectDateRoport.Controls.Add(Booking_Status);
            SelectDateRoport.Controls.Add(label3);
            SelectDateRoport.Controls.Add(RoomType);
            SelectDateRoport.Controls.Add(label2);
            SelectDateRoport.Controls.Add(ToDate);
            SelectDateRoport.Controls.Add(label1);
            SelectDateRoport.Controls.Add(FromDate);
            SelectDateRoport.Controls.Add(lbCustomerName);
            SelectDateRoport.FillColor = Color.White;
            SelectDateRoport.Location = new Point(27, 3);
            SelectDateRoport.Name = "SelectDateRoport";
            SelectDateRoport.Radius = 8;
            SelectDateRoport.ShadowColor = Color.LightSteelBlue;
            SelectDateRoport.ShadowDepth = 80;
            SelectDateRoport.ShadowShift = 10;
            SelectDateRoport.Size = new Size(1405, 180);
            SelectDateRoport.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(search);
            panel1.Controls.Add(iconPictureBox1);
            panel1.Location = new Point(883, 40);
            panel1.Name = "panel1";
            panel1.Size = new Size(381, 41);
            panel1.TabIndex = 46;
            // 
            // search
            // 
            search.AutoSize = true;
            search.BackColor = Color.White;
            search.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            search.ForeColor = Color.FromArgb(64, 64, 64);
            search.Location = new Point(19, 8);
            search.Name = "search";
            search.Size = new Size(61, 23);
            search.TabIndex = 63;
            search.Text = "Search";
            // 
            // iconPictureBox1
            // 
            iconPictureBox1.BackColor = Color.White;
            iconPictureBox1.ForeColor = Color.FromArgb(64, 64, 64);
            iconPictureBox1.IconChar = FontAwesome.Sharp.IconChar.Search;
            iconPictureBox1.IconColor = Color.FromArgb(64, 64, 64);
            iconPictureBox1.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPictureBox1.IconSize = 23;
            iconPictureBox1.Location = new Point(333, 9);
            iconPictureBox1.Name = "iconPictureBox1";
            iconPictureBox1.Size = new Size(26, 23);
            iconPictureBox1.TabIndex = 9;
            iconPictureBox1.TabStop = false;
            // 
            // btnFilter
            // 
            btnFilter.BorderRadius = 4;
            btnFilter.CustomizableEdges = customizableEdges1;
            btnFilter.DisabledState.BorderColor = Color.DarkGray;
            btnFilter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFilter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFilter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFilter.FillColor = Color.Navy;
            btnFilter.Font = new Font("Segoe UI", 7.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(763, 46);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges2;
            btnFilter.Size = new Size(63, 32);
            btnFilter.TabIndex = 27;
            btnFilter.Text = "Filter";
            // 
            // Booking_Status
            // 
            Booking_Status.BackColor = Color.Transparent;
            Booking_Status.BorderColor = Color.Silver;
            Booking_Status.BorderRadius = 8;
            Booking_Status.CustomizableEdges = customizableEdges3;
            Booking_Status.DrawMode = DrawMode.OwnerDrawFixed;
            Booking_Status.DropDownStyle = ComboBoxStyle.DropDownList;
            Booking_Status.FocusedColor = Color.FromArgb(94, 148, 255);
            Booking_Status.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            Booking_Status.Font = new Font("Segoe UI", 10F);
            Booking_Status.ForeColor = Color.FromArgb(68, 88, 112);
            Booking_Status.ItemHeight = 30;
            Booking_Status.Items.AddRange(new object[] { "Completed", "Check-In", "Check-Out", "Cancelled" });
            Booking_Status.Location = new Point(29, 122);
            Booking_Status.Name = "Booking_Status";
            Booking_Status.ShadowDecoration.CustomizableEdges = customizableEdges4;
            Booking_Status.Size = new Size(210, 36);
            Booking_Status.TabIndex = 26;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(29, 99);
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
            RoomType.CustomizableEdges = customizableEdges5;
            RoomType.DrawMode = DrawMode.OwnerDrawFixed;
            RoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            RoomType.FocusedColor = Color.FromArgb(94, 148, 255);
            RoomType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            RoomType.Font = new Font("Segoe UI", 10F);
            RoomType.ForeColor = Color.FromArgb(68, 88, 112);
            RoomType.ItemHeight = 30;
            RoomType.Items.AddRange(new object[] { "All", "Single", "Double", "VIP" });
            RoomType.Location = new Point(427, 122);
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
            label2.Location = new Point(427, 99);
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
            ToDate.Size = new Size(296, 36);
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
            // History_Room
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Customer_history);
            Controls.Add(SelectDateRoport);
            Name = "History_Room";
            Size = new Size(1455, 800);
            Customer_history.ResumeLayout(false);
            Customer_history.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox1).EndInit();
            ResumeLayout(false);
            Hotel_System.UI.UiTheme.ApplyPageDesign(this);
        }

        #endregion

        private GroupBox Customer_history;
        private Label label25;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn BookingID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Status;
        private DataGridViewTextBoxColumn Note;
        private Label label17;
        private Guna.UI2.WinForms.Guna2ShadowPanel SelectDateRoport;
        private Panel panel1;
        private Label search;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox1;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private Guna.UI2.WinForms.Guna2ComboBox Booking_Status;
        private Label label3;
        private Guna.UI2.WinForms.Guna2ComboBox RoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Label lbCustomerName;
    }
}
