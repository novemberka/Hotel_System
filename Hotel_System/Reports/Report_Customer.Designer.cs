namespace Hotel_System
{
    partial class Report_Customer
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
            dgvCustomers = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            Full_name = new DataGridViewTextBoxColumn();
            gender = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            email = new DataGridViewTextBoxColumn();
            idcard_number = new DataGridViewTextBoxColumn();
            address = new DataGridViewTextBoxColumn();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            cmbCustomerName = new Guna.UI2.WinForms.Guna2ComboBox();
            btnflitter = new Guna.UI2.WinForms.Guna2Button();
            label4 = new Label();
            cmbRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Booking_list = new Guna.UI2.WinForms.Guna2ShadowPanel();
            iconPictureBox7 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox6 = new FontAwesome.Sharp.IconPictureBox();
            iconPictureBox5 = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            SelectDateRoport.SuspendLayout();
            Booking_list.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox7).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox6).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPictureBox5).BeginInit();
            SuspendLayout();
            // 
            // dgvCustomers
            // 
            dgvCustomers.AllowUserToAddRows = false;
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, Full_name, gender, PhoneNumber, email, idcard_number, address });
            dgvCustomers.Location = new Point(29, 53);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersVisible = false;
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(1350, 486);
            dgvCustomers.TabIndex = 28;
            // 
            // CustomerID
            // 
            CustomerID.DataPropertyName = "customer_id";
            CustomerID.HeaderText = "Customer ID";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 160;
            // 
            // Full_name
            // 
            Full_name.DataPropertyName = "full_name";
            Full_name.HeaderText = "Full Name";
            Full_name.MinimumWidth = 6;
            Full_name.Name = "Full_name";
            Full_name.Width = 125;
            // 
            // gender
            // 
            gender.HeaderText = "Gender";
            gender.MinimumWidth = 6;
            gender.Name = "gender";
            gender.Width = 125;
            // 
            // PhoneNumber
            // 
            PhoneNumber.DataPropertyName = "phone_number";
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 200;
            // 
            // email
            // 
            email.HeaderText = "Email";
            email.MinimumWidth = 6;
            email.Name = "email";
            email.Width = 250;
            // 
            // idcard_number
            // 
            idcard_number.DataPropertyName = "idcard_number";
            idcard_number.HeaderText = "IDCard Number";
            idcard_number.MinimumWidth = 6;
            idcard_number.Name = "idcard_number";
            idcard_number.Width = 250;
            // 
            // address
            // 
            address.HeaderText = "Address";
            address.MinimumWidth = 6;
            address.Name = "address";
            address.Width = 250;
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(cmbCustomerName);
            SelectDateRoport.Controls.Add(btnflitter);
            SelectDateRoport.Controls.Add(label4);
            SelectDateRoport.Controls.Add(cmbRoomType);
            SelectDateRoport.Controls.Add(label2);
            SelectDateRoport.Controls.Add(ToDate);
            SelectDateRoport.Controls.Add(label1);
            SelectDateRoport.Controls.Add(FromDate);
            SelectDateRoport.Controls.Add(lbCustomerName);
            SelectDateRoport.FillColor = Color.White;
            SelectDateRoport.Location = new Point(13, 17);
            SelectDateRoport.Name = "SelectDateRoport";
            SelectDateRoport.Radius = 8;
            SelectDateRoport.ShadowColor = Color.LightSteelBlue;
            SelectDateRoport.ShadowDepth = 80;
            SelectDateRoport.ShadowShift = 10;
            SelectDateRoport.Size = new Size(1405, 180);
            SelectDateRoport.TabIndex = 8;
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
            cmbCustomerName.TabIndex = 64;
            cmbCustomerName.SelectedIndexChanged += cmbCustomerName_SelectedIndexChanged;
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
            btnflitter.Location = new Point(716, 45);
            btnflitter.Name = "btnflitter";
            btnflitter.ShadowDecoration.CustomizableEdges = customizableEdges4;
            btnflitter.Size = new Size(71, 36);
            btnflitter.TabIndex = 63;
            btnflitter.Text = "Flitter";
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
            // cmbRoomType
            // 
            cmbRoomType.BackColor = Color.Transparent;
            cmbRoomType.BorderColor = Color.Silver;
            cmbRoomType.BorderRadius = 8;
            cmbRoomType.CustomizableEdges = customizableEdges5;
            cmbRoomType.DrawMode = DrawMode.OwnerDrawFixed;
            cmbRoomType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbRoomType.FocusedColor = Color.FromArgb(94, 148, 255);
            cmbRoomType.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            cmbRoomType.Font = new Font("Segoe UI", 10F);
            cmbRoomType.ForeColor = Color.FromArgb(68, 88, 112);
            cmbRoomType.ItemHeight = 30;
            cmbRoomType.Items.AddRange(new object[] { "All", "Single", "Double", "VIP" });
            cmbRoomType.Location = new Point(836, 45);
            cmbRoomType.Name = "cmbRoomType";
            cmbRoomType.ShadowDecoration.CustomizableEdges = customizableEdges6;
            cmbRoomType.Size = new Size(210, 36);
            cmbRoomType.TabIndex = 24;
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
            ToDate.Location = new Point(360, 45);
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
            label1.Location = new Point(360, 22);
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
            // Booking_list
            // 
            Booking_list.BackColor = Color.Transparent;
            Booking_list.Controls.Add(iconPictureBox7);
            Booking_list.Controls.Add(iconPictureBox6);
            Booking_list.Controls.Add(iconPictureBox5);
            Booking_list.Controls.Add(label5);
            Booking_list.Controls.Add(dgvCustomers);
            Booking_list.FillColor = Color.White;
            Booking_list.Location = new Point(13, 219);
            Booking_list.Name = "Booking_list";
            Booking_list.Radius = 8;
            Booking_list.ShadowColor = Color.LightSteelBlue;
            Booking_list.ShadowDepth = 80;
            Booking_list.ShadowShift = 10;
            Booking_list.Size = new Size(1405, 557);
            Booking_list.TabIndex = 9;
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
            label5.Size = new Size(191, 25);
            label5.TabIndex = 20;
            label5.Text = "Customer Report List";
            // 
            // Report_Customer
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            Controls.Add(Booking_list);
            Controls.Add(SelectDateRoport);
            Name = "Report_Customer";
            Size = new Size(1447, 811);
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
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
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2ShadowPanel Booking_list;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox7;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox6;
        private FontAwesome.Sharp.IconPictureBox iconPictureBox5;
        private Label label5;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn Full_name;
        private DataGridViewTextBoxColumn gender;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn email;
        private DataGridViewTextBoxColumn idcard_number;
        private DataGridViewTextBoxColumn address;
        private DataGridView dgvCustomers;
        private Guna.UI2.WinForms.Guna2Button btnflitter;
        private Guna.UI2.WinForms.Guna2ComboBox cmbCustomerName;
    }
}
