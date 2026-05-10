namespace Hotel_System.PrintForms
{
    partial class BookingInvoice
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
            components = new System.ComponentModel.Container();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges25 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges26 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges27 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges28 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges29 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges30 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges31 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges32 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges33 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges34 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges35 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges36 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            txtbooking = new TextBox();
            lbAddress = new Label();
            lbTel = new Label();
            lbemail = new Label();
            lbInvoiceNo = new Label();
            lbbookingID = new Label();
            txtInvoiceNo = new Guna.UI2.WinForms.Guna2TextBox();
            txtbookingID = new Guna.UI2.WinForms.Guna2TextBox();
            lbDate = new Label();
            txtDate = new Guna.UI2.WinForms.Guna2TextBox();
            txtPayment = new Guna.UI2.WinForms.Guna2TextBox();
            label1 = new Label();
            txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            label2 = new Label();
            label3 = new Label();
            dgvBookingInvoice = new DataGridView();
            dbConnectionBindingSource = new BindingSource(components);
            label4 = new Label();
            label5 = new Label();
            No = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            RoomNumber = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            CheckInDate = new DataGridViewTextBoxColumn();
            CheckOutDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dbConnectionBindingSource).BeginInit();
            SuspendLayout();
            // 
            // txtbooking
            // 
            txtbooking.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtbooking.ForeColor = Color.FromArgb(64, 0, 64);
            txtbooking.Location = new Point(386, 18);
            txtbooking.Multiline = true;
            txtbooking.Name = "txtbooking";
            txtbooking.Size = new Size(150, 37);
            txtbooking.TabIndex = 0;
            txtbooking.Text = "Hotel Name";
            // 
            // lbAddress
            // 
            lbAddress.AutoSize = true;
            lbAddress.Location = new Point(328, 70);
            lbAddress.Name = "lbAddress";
            lbAddress.Size = new Size(261, 20);
            lbAddress.TabIndex = 1;
            lbAddress.Text = "Address: St 2004,Sen Sok, Phnom Penh";
            // 
            // lbTel
            // 
            lbTel.AutoSize = true;
            lbTel.Location = new Point(395, 101);
            lbTel.Name = "lbTel";
            lbTel.Size = new Size(123, 20);
            lbTel.TabIndex = 2;
            lbTel.Text = "Tel: 097 967 9172";
            // 
            // lbemail
            // 
            lbemail.AutoSize = true;
            lbemail.Location = new Point(359, 133);
            lbemail.Name = "lbemail";
            lbemail.Size = new Size(187, 20);
            lbemail.TabIndex = 3;
            lbemail.Text = "Email: hotal09@gmail.com";
            // 
            // lbInvoiceNo
            // 
            lbInvoiceNo.AutoSize = true;
            lbInvoiceNo.Location = new Point(662, 101);
            lbInvoiceNo.Name = "lbInvoiceNo";
            lbInvoiceNo.Size = new Size(90, 20);
            lbInvoiceNo.TabIndex = 4;
            lbInvoiceNo.Text = "InvoiceNo. : ";
            lbInvoiceNo.Click += label1_Click;
            // 
            // lbbookingID
            // 
            lbbookingID.AutoSize = true;
            lbbookingID.Location = new Point(662, 128);
            lbbookingID.Name = "lbbookingID";
            lbbookingID.Size = new Size(94, 20);
            lbbookingID.TabIndex = 5;
            lbbookingID.Text = "Booking ID : ";
            lbbookingID.Click += lbbookingID_Click;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtInvoiceNo.CustomizableEdges = customizableEdges25;
            txtInvoiceNo.DefaultText = "";
            txtInvoiceNo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtInvoiceNo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtInvoiceNo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtInvoiceNo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtInvoiceNo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInvoiceNo.Font = new Font("Segoe UI", 9F);
            txtInvoiceNo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInvoiceNo.Location = new Point(780, 84);
            txtInvoiceNo.Margin = new Padding(3, 4, 3, 4);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.PlaceholderText = "";
            txtInvoiceNo.SelectedText = "";
            txtInvoiceNo.ShadowDecoration.CustomizableEdges = customizableEdges26;
            txtInvoiceNo.Size = new Size(141, 25);
            txtInvoiceNo.TabIndex = 6;
            txtInvoiceNo.TextChanged += guna2TextBox1_TextChanged;
            // 
            // txtbookingID
            // 
            txtbookingID.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtbookingID.CustomizableEdges = customizableEdges27;
            txtbookingID.DefaultText = "";
            txtbookingID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbookingID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbookingID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbookingID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbookingID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbookingID.Font = new Font("Segoe UI", 9F);
            txtbookingID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbookingID.Location = new Point(780, 117);
            txtbookingID.Margin = new Padding(3, 4, 3, 4);
            txtbookingID.Name = "txtbookingID";
            txtbookingID.PlaceholderText = "";
            txtbookingID.SelectedText = "";
            txtbookingID.ShadowDecoration.CustomizableEdges = customizableEdges28;
            txtbookingID.Size = new Size(141, 25);
            txtbookingID.TabIndex = 7;
            // 
            // lbDate
            // 
            lbDate.AutoSize = true;
            lbDate.Location = new Point(653, 160);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(103, 20);
            lbDate.TabIndex = 8;
            lbDate.Text = "Invoice Date : ";
            // 
            // txtDate
            // 
            txtDate.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtDate.CustomizableEdges = customizableEdges29;
            txtDate.DefaultText = "";
            txtDate.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDate.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDate.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDate.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDate.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDate.Font = new Font("Segoe UI", 9F);
            txtDate.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDate.Location = new Point(780, 150);
            txtDate.Margin = new Padding(3, 4, 3, 4);
            txtDate.Name = "txtDate";
            txtDate.PlaceholderText = "";
            txtDate.SelectedText = "";
            txtDate.ShadowDecoration.CustomizableEdges = customizableEdges30;
            txtDate.Size = new Size(141, 25);
            txtDate.TabIndex = 9;
            // 
            // txtPayment
            // 
            txtPayment.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtPayment.CustomizableEdges = customizableEdges31;
            txtPayment.DefaultText = "";
            txtPayment.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPayment.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPayment.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPayment.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPayment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayment.Font = new Font("Segoe UI", 9F);
            txtPayment.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayment.Location = new Point(163, 155);
            txtPayment.Margin = new Padding(3, 4, 3, 4);
            txtPayment.Name = "txtPayment";
            txtPayment.PlaceholderText = "";
            txtPayment.SelectedText = "";
            txtPayment.ShadowDecoration.CustomizableEdges = customizableEdges32;
            txtPayment.Size = new Size(141, 25);
            txtPayment.TabIndex = 15;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(30, 160);
            label1.Name = "label1";
            label1.Size = new Size(76, 20);
            label1.TabIndex = 14;
            label1.Text = "Payment : ";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtPhoneNumber.CustomizableEdges = customizableEdges33;
            txtPhoneNumber.DefaultText = "";
            txtPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Font = new Font("Segoe UI", 9F);
            txtPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Location = new Point(163, 127);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "";
            txtPhoneNumber.SelectedText = "";
            txtPhoneNumber.ShadowDecoration.CustomizableEdges = customizableEdges34;
            txtPhoneNumber.Size = new Size(141, 25);
            txtPhoneNumber.TabIndex = 13;
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtCustomerName.CustomizableEdges = customizableEdges35;
            txtCustomerName.DefaultText = "";
            txtCustomerName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCustomerName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCustomerName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCustomerName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCustomerName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCustomerName.Font = new Font("Segoe UI", 9F);
            txtCustomerName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCustomerName.Location = new Point(163, 96);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "";
            txtCustomerName.SelectedText = "";
            txtCustomerName.ShadowDecoration.CustomizableEdges = customizableEdges36;
            txtCustomerName.Size = new Size(141, 25);
            txtCustomerName.TabIndex = 12;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(30, 128);
            label2.Name = "label2";
            label2.Size = new Size(119, 20);
            label2.TabIndex = 11;
            label2.Text = "Phone Number : ";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(30, 101);
            label3.Name = "label3";
            label3.Size = new Size(127, 20);
            label3.TabIndex = 10;
            label3.Text = "Customer Name : ";
            // 
            // dgvBookingInvoice
            // 
            dgvBookingInvoice.AllowUserToAddRows = false;
            dgvBookingInvoice.AllowUserToOrderColumns = true;
            dgvBookingInvoice.AutoGenerateColumns = false;
            dgvBookingInvoice.BackgroundColor = Color.White;
            dgvBookingInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingInvoice.Columns.AddRange(new DataGridViewColumn[] { No, Description, RoomNumber, RoomType, CheckInDate, CheckOutDate, Status });
            dgvBookingInvoice.DataSource = dbConnectionBindingSource;
            dgvBookingInvoice.Location = new Point(30, 216);
            dgvBookingInvoice.Name = "dgvBookingInvoice";
            dgvBookingInvoice.RowHeadersVisible = false;
            dgvBookingInvoice.RowHeadersWidth = 51;
            dgvBookingInvoice.Size = new Size(910, 200);
            dgvBookingInvoice.TabIndex = 17;
            dgvBookingInvoice.CellContentClick += dgvBookingInvoice_CellContentClick;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(375, 597);
            label4.Name = "label4";
            label4.Size = new Size(175, 20);
            label4.TabIndex = 69;
            label4.Text = "Thank you for coming!!";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(328, 631);
            label5.Name = "label5";
            label5.Size = new Size(287, 20);
            label5.TabIndex = 70;
            label5.Text = "We look forward to welcoming you again!";
            // 
            // No
            // 
            No.HeaderText = "No.";
            No.MinimumWidth = 6;
            No.Name = "No";
            No.Width = 50;
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            Description.Width = 180;
            // 
            // RoomNumber
            // 
            RoomNumber.HeaderText = "Room Number";
            RoomNumber.MinimumWidth = 6;
            RoomNumber.Name = "RoomNumber";
            RoomNumber.Width = 150;
            // 
            // RoomType
            // 
            RoomType.HeaderText = "RoomType";
            RoomType.MinimumWidth = 6;
            RoomType.Name = "RoomType";
            RoomType.Width = 120;
            // 
            // CheckInDate
            // 
            CheckInDate.HeaderText = "CheckIn Date";
            CheckInDate.MinimumWidth = 6;
            CheckInDate.Name = "CheckInDate";
            CheckInDate.Width = 150;
            // 
            // CheckOutDate
            // 
            CheckOutDate.HeaderText = "CheckOut Date";
            CheckOutDate.MinimumWidth = 6;
            CheckOutDate.Name = "CheckOutDate";
            CheckOutDate.Width = 150;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 125;
            // 
            // BookingInvoice
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvBookingInvoice);
            Controls.Add(txtPayment);
            Controls.Add(label1);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtCustomerName);
            Controls.Add(label2);
            Controls.Add(label3);
            Controls.Add(txtDate);
            Controls.Add(lbDate);
            Controls.Add(txtbookingID);
            Controls.Add(txtInvoiceNo);
            Controls.Add(lbbookingID);
            Controls.Add(lbInvoiceNo);
            Controls.Add(lbemail);
            Controls.Add(lbTel);
            Controls.Add(lbAddress);
            Controls.Add(txtbooking);
            Name = "BookingInvoice";
            Size = new Size(961, 771);
            Load += BookingInvoice_Load;
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).EndInit();
            ((System.ComponentModel.ISupportInitialize)dbConnectionBindingSource).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtbooking;
        private Label lbAddress;
        private Label lbTel;
        private Label lbemail;
        private Label lbInvoiceNo;
        private Label lbbookingID;
        private Guna.UI2.WinForms.Guna2TextBox txtInvoiceNo;
        private Guna.UI2.WinForms.Guna2TextBox txtbookingID;
        private Label lbDate;
        private Guna.UI2.WinForms.Guna2TextBox txtDate;
        private Guna.UI2.WinForms.Guna2TextBox txtPayment;
        private Label label1;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private Label label2;
        private Label label3;
        private DataGridView dgvBookingInvoice;
        private BindingSource dbConnectionBindingSource;
        private Label lbltotalAfterdis;
        private Label label4;
        private Label label5;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn RoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn CheckInDate;
        private DataGridViewTextBoxColumn CheckOutDate;
        private DataGridViewTextBoxColumn Status;
    }
}
