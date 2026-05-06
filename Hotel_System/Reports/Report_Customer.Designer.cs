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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges35 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges36 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges37 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges38 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges39 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges40 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            SelectDateRoport = new Guna.UI2.WinForms.Guna2ShadowPanel();
            btnFilter = new Guna.UI2.WinForms.Guna2Button();
            txtFullName = new Guna.UI2.WinForms.Guna2TextBox();
            label4 = new Label();
            cmbRoomType = new Guna.UI2.WinForms.Guna2ComboBox();
            label2 = new Label();
            ToDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            label1 = new Label();
            FromDate = new Guna.UI2.WinForms.Guna2DateTimePicker();
            lbCustomerName = new Label();
            Customer = new Guna.UI2.WinForms.Guna2ShadowPanel();
            dgvCustomers = new DataGridView();
            CustomerID = new DataGridViewTextBoxColumn();
            FullName = new DataGridViewTextBoxColumn();
            Gender = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Email = new DataGridViewTextBoxColumn();
            Address = new DataGridViewTextBoxColumn();
            Column6 = new DataGridViewTextBoxColumn();
            iconPDF = new FontAwesome.Sharp.IconPictureBox();
            iconExcel = new FontAwesome.Sharp.IconPictureBox();
            iconPrint = new FontAwesome.Sharp.IconPictureBox();
            label5 = new Label();
            SelectDateRoport.SuspendLayout();
            Customer.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPDF).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconExcel).BeginInit();
            ((System.ComponentModel.ISupportInitialize)iconPrint).BeginInit();
            SuspendLayout();
            // 
            // SelectDateRoport
            // 
            SelectDateRoport.BackColor = Color.Transparent;
            SelectDateRoport.Controls.Add(btnFilter);
            SelectDateRoport.Controls.Add(txtFullName);
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
            // btnFilter
            // 
            btnFilter.BorderRadius = 8;
            btnFilter.CustomizableEdges = customizableEdges31;
            btnFilter.DisabledState.BorderColor = Color.DarkGray;
            btnFilter.DisabledState.CustomBorderColor = Color.DarkGray;
            btnFilter.DisabledState.FillColor = Color.FromArgb(169, 169, 169);
            btnFilter.DisabledState.ForeColor = Color.FromArgb(141, 141, 141);
            btnFilter.FillColor = Color.FromArgb(0, 192, 0);
            btnFilter.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnFilter.ForeColor = Color.White;
            btnFilter.Location = new Point(693, 45);
            btnFilter.Name = "btnFilter";
            btnFilter.ShadowDecoration.CustomizableEdges = customizableEdges32;
            btnFilter.Size = new Size(74, 32);
            btnFilter.TabIndex = 59;
            btnFilter.Text = "Filter";
            btnFilter.Click += btnFilter_Click;
            // 
            // txtFullName
            // 
            txtFullName.BorderColor = Color.Silver;
            txtFullName.BorderRadius = 6;
            txtFullName.CustomizableEdges = customizableEdges33;
            txtFullName.DefaultText = "";
            txtFullName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtFullName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtFullName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtFullName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtFullName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFullName.Font = new Font("Segoe UI", 9F);
            txtFullName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtFullName.Location = new Point(29, 120);
            txtFullName.Margin = new Padding(3, 4, 3, 4);
            txtFullName.Name = "txtFullName";
            txtFullName.PlaceholderText = "";
            txtFullName.SelectedText = "";
            txtFullName.ShadowDecoration.CustomizableEdges = customizableEdges34;
            txtFullName.Size = new Size(299, 36);
            txtFullName.TabIndex = 55;
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
            cmbRoomType.CustomizableEdges = customizableEdges35;
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
            cmbRoomType.ShadowDecoration.CustomizableEdges = customizableEdges36;
            cmbRoomType.Size = new Size(210, 36);
            cmbRoomType.TabIndex = 24;
            cmbRoomType.SelectedIndexChanged += RoomType_SelectedIndexChanged;
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
            ToDate.CustomizableEdges = customizableEdges37;
            ToDate.FillColor = Color.White;
            ToDate.FocusedColor = Color.White;
            ToDate.Font = new Font("Segoe UI", 9F);
            ToDate.Format = DateTimePickerFormat.Long;
            ToDate.Location = new Point(396, 45);
            ToDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            ToDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            ToDate.Name = "ToDate";
            ToDate.ShadowDecoration.CustomizableEdges = customizableEdges38;
            ToDate.Size = new Size(271, 36);
            ToDate.TabIndex = 22;
            ToDate.Value = new DateTime(2026, 3, 22, 0, 25, 41, 535);
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(396, 22);
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
            FromDate.CustomizableEdges = customizableEdges39;
            FromDate.FillColor = Color.White;
            FromDate.FocusedColor = Color.White;
            FromDate.Font = new Font("Segoe UI", 9F);
            FromDate.Format = DateTimePickerFormat.Long;
            FromDate.Location = new Point(29, 45);
            FromDate.MaxDate = new DateTime(9998, 12, 31, 0, 0, 0, 0);
            FromDate.MinDate = new DateTime(1753, 1, 1, 0, 0, 0, 0);
            FromDate.Name = "FromDate";
            FromDate.ShadowDecoration.CustomizableEdges = customizableEdges40;
            FromDate.Size = new Size(247, 36);
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
            // Customer
            // 
            Customer.BackColor = Color.Transparent;
            Customer.Controls.Add(dgvCustomers);
            Customer.Controls.Add(iconPDF);
            Customer.Controls.Add(iconExcel);
            Customer.Controls.Add(iconPrint);
            Customer.Controls.Add(label5);
            Customer.FillColor = Color.White;
            Customer.Location = new Point(13, 219);
            Customer.Name = "Customer";
            Customer.Radius = 8;
            Customer.ShadowColor = Color.LightSteelBlue;
            Customer.ShadowDepth = 80;
            Customer.ShadowShift = 10;
            Customer.Size = new Size(1405, 557);
            Customer.TabIndex = 9;
            Customer.Paint += Customer_Paint;
            // 
            // dgvCustomers
            // 
            dgvCustomers.BackgroundColor = Color.White;
            dgvCustomers.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCustomers.Columns.AddRange(new DataGridViewColumn[] { CustomerID, FullName, Gender, PhoneNumber, Email, Address, Column6 });
            dgvCustomers.Location = new Point(29, 57);
            dgvCustomers.Name = "dgvCustomers";
            dgvCustomers.RowHeadersWidth = 51;
            dgvCustomers.Size = new Size(1333, 456);
            dgvCustomers.TabIndex = 32;
            dgvCustomers.CellContentClick += dgvCustomers_CellContentClick_1;
            // 
            // CustomerID
            // 
            CustomerID.HeaderText = "Customer ID";
            CustomerID.MinimumWidth = 6;
            CustomerID.Name = "CustomerID";
            CustomerID.Width = 125;
            // 
            // FullName
            // 
            FullName.HeaderText = "Full Name";
            FullName.MinimumWidth = 6;
            FullName.Name = "FullName";
            FullName.Width = 200;
            // 
            // Gender
            // 
            Gender.HeaderText = "Gender";
            Gender.MinimumWidth = 6;
            Gender.Name = "Gender";
            Gender.Width = 125;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 200;
            // 
            // Email
            // 
            Email.HeaderText = "Email";
            Email.MinimumWidth = 6;
            Email.Name = "Email";
            Email.Width = 250;
            // 
            // Address
            // 
            Address.HeaderText = "Address";
            Address.MinimumWidth = 6;
            Address.Name = "Address";
            Address.Width = 200;
            // 
            // Column6
            // 
            Column6.HeaderText = "Column6";
            Column6.MinimumWidth = 6;
            Column6.Name = "Column6";
            Column6.Width = 200;
            // 
            // iconPDF
            // 
            iconPDF.BackColor = Color.White;
            iconPDF.ForeColor = Color.Red;
            iconPDF.IconChar = FontAwesome.Sharp.IconChar.FilePdf;
            iconPDF.IconColor = Color.Red;
            iconPDF.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPDF.Location = new Point(1330, 16);
            iconPDF.Margin = new Padding(2);
            iconPDF.Name = "iconPDF";
            iconPDF.Size = new Size(32, 32);
            iconPDF.TabIndex = 31;
            iconPDF.TabStop = false;
            iconPDF.Click += iconPDF_Click;
            // 
            // iconExcel
            // 
            iconExcel.BackColor = Color.White;
            iconExcel.ForeColor = Color.Green;
            iconExcel.IconChar = FontAwesome.Sharp.IconChar.FileExcel;
            iconExcel.IconColor = Color.Green;
            iconExcel.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconExcel.Location = new Point(1282, 16);
            iconExcel.Margin = new Padding(2);
            iconExcel.Name = "iconExcel";
            iconExcel.Size = new Size(32, 32);
            iconExcel.TabIndex = 30;
            iconExcel.TabStop = false;
            iconExcel.Click += iconExcel_Click;
            // 
            // iconPrint
            // 
            iconPrint.BackColor = Color.White;
            iconPrint.ForeColor = Color.Black;
            iconPrint.IconChar = FontAwesome.Sharp.IconChar.Print;
            iconPrint.IconColor = Color.Black;
            iconPrint.IconFont = FontAwesome.Sharp.IconFont.Auto;
            iconPrint.Location = new Point(1231, 16);
            iconPrint.Margin = new Padding(2);
            iconPrint.Name = "iconPrint";
            iconPrint.Size = new Size(32, 32);
            iconPrint.TabIndex = 29;
            iconPrint.TabStop = false;
            iconPrint.Click += iconPictureBox5_Click;
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
            Controls.Add(Customer);
            Controls.Add(SelectDateRoport);
            Name = "Report_Customer";
            Size = new Size(1447, 811);
            SelectDateRoport.ResumeLayout(false);
            SelectDateRoport.PerformLayout();
            Customer.ResumeLayout(false);
            Customer.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCustomers).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPDF).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconExcel).EndInit();
            ((System.ComponentModel.ISupportInitialize)iconPrint).EndInit();
            ResumeLayout(false);
        }

        #endregion
        private Guna.UI2.WinForms.Guna2ShadowPanel SelectDateRoport;
        private Guna.UI2.WinForms.Guna2TextBox txtFullName;
        private Label label4;
        private Guna.UI2.WinForms.Guna2ComboBox cmbRoomType;
        private Label label2;
        private Guna.UI2.WinForms.Guna2DateTimePicker ToDate;
        private Label label1;
        private Guna.UI2.WinForms.Guna2DateTimePicker FromDate;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2ShadowPanel Customer;
        private FontAwesome.Sharp.IconPictureBox iconPDF;
        private FontAwesome.Sharp.IconPictureBox iconExcel;
        private FontAwesome.Sharp.IconPictureBox iconPrint;
        private Label label5;
        private Guna.UI2.WinForms.Guna2Button btnFilter;
        private DataGridView dgvCustomers;
        private DataGridViewTextBoxColumn CustomerID;
        private DataGridViewTextBoxColumn FullName;
        private DataGridViewTextBoxColumn Gender;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Email;
        private DataGridViewTextBoxColumn Address;
        private DataGridViewTextBoxColumn Column6;
    }
}
