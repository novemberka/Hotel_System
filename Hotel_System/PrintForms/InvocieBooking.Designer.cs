namespace Hotel_System.PrintForms
{
    partial class InvocieBooking
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
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges11 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            Guna.UI2.WinForms.Suite.CustomizableEdges customizableEdges12 = new Guna.UI2.WinForms.Suite.CustomizableEdges();
            label5 = new Label();
            label4 = new Label();
            dgvBookingInvoice = new DataGridView();
            No = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            RoomNumber = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            CheckInDate = new DataGridViewTextBoxColumn();
            CheckOutDate = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            txtPayment = new Guna.UI2.WinForms.Guna2TextBox();
            lbPaymentby = new Label();
            txtPhoneNumber = new Guna.UI2.WinForms.Guna2TextBox();
            txtCustomerName = new Guna.UI2.WinForms.Guna2TextBox();
            lbPhoneNumber = new Label();
            lbCustomerName = new Label();
            txtDate = new Guna.UI2.WinForms.Guna2TextBox();
            lbDate = new Label();
            txtbookingID = new Guna.UI2.WinForms.Guna2TextBox();
            txtInvoiceNo = new Guna.UI2.WinForms.Guna2TextBox();
            lbbookingID = new Label();
            lbInvoiceNo = new Label();
            lbemail = new Label();
            lbTel = new Label();
            lbAddress = new Label();
            txtbooking = new TextBox();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(340, 661);
            label5.Name = "label5";
            label5.Size = new Size(287, 20);
            label5.TabIndex = 89;
            label5.Text = "We look forward to welcoming you again!";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Navy;
            label4.Location = new Point(387, 627);
            label4.Name = "label4";
            label4.Size = new Size(175, 20);
            label4.TabIndex = 88;
            label4.Text = "Thank you for coming!!";
            // 
            // dgvBookingInvoice
            // 
            dgvBookingInvoice.AllowUserToAddRows = false;
            dgvBookingInvoice.AllowUserToOrderColumns = true;
            dgvBookingInvoice.BackgroundColor = Color.White;
            dgvBookingInvoice.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBookingInvoice.Columns.AddRange(new DataGridViewColumn[] { No, Description, RoomNumber, RoomType, CheckInDate, CheckOutDate, Status });
            dgvBookingInvoice.Location = new Point(42, 246);
            dgvBookingInvoice.Name = "dgvBookingInvoice";
            dgvBookingInvoice.RowHeadersVisible = false;
            dgvBookingInvoice.RowHeadersWidth = 51;
            dgvBookingInvoice.Size = new Size(910, 200);
            dgvBookingInvoice.TabIndex = 87;
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
            // txtPayment
            // 
            txtPayment.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtPayment.CustomizableEdges = customizableEdges1;
            txtPayment.DefaultText = "";
            txtPayment.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPayment.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPayment.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPayment.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPayment.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayment.Font = new Font("Segoe UI", 9F);
            txtPayment.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPayment.Location = new Point(175, 185);
            txtPayment.Margin = new Padding(3, 4, 3, 4);
            txtPayment.Name = "txtPayment";
            txtPayment.PlaceholderText = "";
            txtPayment.SelectedText = "";
            txtPayment.ShadowDecoration.CustomizableEdges = customizableEdges2;
            txtPayment.Size = new Size(141, 25);
            txtPayment.TabIndex = 86;
            // 
            // lbPaymentby
            // 
            lbPaymentby.AutoSize = true;
            lbPaymentby.Location = new Point(42, 190);
            lbPaymentby.Name = "lbPaymentby";
            lbPaymentby.Size = new Size(92, 20);
            lbPaymentby.TabIndex = 85;
            lbPaymentby.Text = "Payment by: ";
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtPhoneNumber.CustomizableEdges = customizableEdges3;
            txtPhoneNumber.DefaultText = "";
            txtPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Font = new Font("Segoe UI", 9F);
            txtPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtPhoneNumber.Location = new Point(175, 157);
            txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.PlaceholderText = "";
            txtPhoneNumber.SelectedText = "";
            txtPhoneNumber.ShadowDecoration.CustomizableEdges = customizableEdges4;
            txtPhoneNumber.Size = new Size(141, 25);
            txtPhoneNumber.TabIndex = 84;
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtCustomerName.CustomizableEdges = customizableEdges5;
            txtCustomerName.DefaultText = "";
            txtCustomerName.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtCustomerName.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtCustomerName.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtCustomerName.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtCustomerName.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCustomerName.Font = new Font("Segoe UI", 9F);
            txtCustomerName.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtCustomerName.Location = new Point(175, 126);
            txtCustomerName.Margin = new Padding(3, 4, 3, 4);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.PlaceholderText = "";
            txtCustomerName.SelectedText = "";
            txtCustomerName.ShadowDecoration.CustomizableEdges = customizableEdges6;
            txtCustomerName.Size = new Size(141, 25);
            txtCustomerName.TabIndex = 83;
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.AutoSize = true;
            lbPhoneNumber.Location = new Point(42, 158);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(119, 20);
            lbPhoneNumber.TabIndex = 82;
            lbPhoneNumber.Text = "Phone Number : ";
            // 
            // lbCustomerName
            // 
            lbCustomerName.AutoSize = true;
            lbCustomerName.Location = new Point(42, 131);
            lbCustomerName.Name = "lbCustomerName";
            lbCustomerName.Size = new Size(127, 20);
            lbCustomerName.TabIndex = 81;
            lbCustomerName.Text = "Customer Name : ";
            // 
            // txtDate
            // 
            txtDate.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtDate.CustomizableEdges = customizableEdges7;
            txtDate.DefaultText = "";
            txtDate.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtDate.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtDate.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtDate.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtDate.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDate.Font = new Font("Segoe UI", 9F);
            txtDate.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtDate.Location = new Point(792, 180);
            txtDate.Margin = new Padding(3, 4, 3, 4);
            txtDate.Name = "txtDate";
            txtDate.PlaceholderText = "";
            txtDate.SelectedText = "";
            txtDate.ShadowDecoration.CustomizableEdges = customizableEdges8;
            txtDate.Size = new Size(141, 25);
            txtDate.TabIndex = 80;
            // 
            // lbDate
            // 
            lbDate.AutoSize = true;
            lbDate.Location = new Point(665, 190);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(103, 20);
            lbDate.TabIndex = 79;
            lbDate.Text = "Invoice Date : ";
            // 
            // txtbookingID
            // 
            txtbookingID.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtbookingID.CustomizableEdges = customizableEdges9;
            txtbookingID.DefaultText = "";
            txtbookingID.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtbookingID.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtbookingID.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtbookingID.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtbookingID.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbookingID.Font = new Font("Segoe UI", 9F);
            txtbookingID.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtbookingID.Location = new Point(792, 147);
            txtbookingID.Margin = new Padding(3, 4, 3, 4);
            txtbookingID.Name = "txtbookingID";
            txtbookingID.PlaceholderText = "";
            txtbookingID.SelectedText = "";
            txtbookingID.ShadowDecoration.CustomizableEdges = customizableEdges10;
            txtbookingID.Size = new Size(141, 25);
            txtbookingID.TabIndex = 78;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.BorderStyle = System.Drawing.Drawing2D.DashStyle.Custom;
            txtInvoiceNo.CustomizableEdges = customizableEdges11;
            txtInvoiceNo.DefaultText = "";
            txtInvoiceNo.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            txtInvoiceNo.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            txtInvoiceNo.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            txtInvoiceNo.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            txtInvoiceNo.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInvoiceNo.Font = new Font("Segoe UI", 9F);
            txtInvoiceNo.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            txtInvoiceNo.Location = new Point(792, 114);
            txtInvoiceNo.Margin = new Padding(3, 4, 3, 4);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.PlaceholderText = "";
            txtInvoiceNo.SelectedText = "";
            txtInvoiceNo.ShadowDecoration.CustomizableEdges = customizableEdges12;
            txtInvoiceNo.Size = new Size(141, 25);
            txtInvoiceNo.TabIndex = 77;
            // 
            // lbbookingID
            // 
            lbbookingID.AutoSize = true;
            lbbookingID.Location = new Point(674, 158);
            lbbookingID.Name = "lbbookingID";
            lbbookingID.Size = new Size(94, 20);
            lbbookingID.TabIndex = 76;
            lbbookingID.Text = "Booking ID : ";
            // 
            // lbInvoiceNo
            // 
            lbInvoiceNo.AutoSize = true;
            lbInvoiceNo.Location = new Point(674, 131);
            lbInvoiceNo.Name = "lbInvoiceNo";
            lbInvoiceNo.Size = new Size(90, 20);
            lbInvoiceNo.TabIndex = 75;
            lbInvoiceNo.Text = "InvoiceNo. : ";
            // 
            // lbemail
            // 
            lbemail.AutoSize = true;
            lbemail.Location = new Point(371, 163);
            lbemail.Name = "lbemail";
            lbemail.Size = new Size(187, 20);
            lbemail.TabIndex = 74;
            lbemail.Text = "Email: hotal09@gmail.com";
            // 
            // lbTel
            // 
            lbTel.AutoSize = true;
            lbTel.Location = new Point(407, 131);
            lbTel.Name = "lbTel";
            lbTel.Size = new Size(123, 20);
            lbTel.TabIndex = 73;
            lbTel.Text = "Tel: 097 967 9172";
            // 
            // lbAddress
            // 
            lbAddress.AutoSize = true;
            lbAddress.Location = new Point(340, 100);
            lbAddress.Name = "lbAddress";
            lbAddress.Size = new Size(261, 20);
            lbAddress.TabIndex = 72;
            lbAddress.Text = "Address: St 2004,Sen Sok, Phnom Penh";
            // 
            // txtbooking
            // 
            txtbooking.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            txtbooking.ForeColor = Color.FromArgb(64, 0, 64);
            txtbooking.Location = new Point(412, 41);
            txtbooking.Multiline = true;
            txtbooking.Name = "txtbooking";
            txtbooking.Size = new Size(150, 37);
            txtbooking.TabIndex = 71;
            txtbooking.Text = "Hotel Name";
            // 
            // InvocieBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(985, 729);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(dgvBookingInvoice);
            Controls.Add(txtPayment);
            Controls.Add(lbPaymentby);
            Controls.Add(txtPhoneNumber);
            Controls.Add(txtCustomerName);
            Controls.Add(lbPhoneNumber);
            Controls.Add(lbCustomerName);
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
            Name = "InvocieBooking";
            Text = "InvocieBooking";
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label5;
        private Label label4;
        private DataGridView dgvBookingInvoice;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn RoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn CheckInDate;
        private DataGridViewTextBoxColumn CheckOutDate;
        private DataGridViewTextBoxColumn Status;
        private Guna.UI2.WinForms.Guna2TextBox txtPayment;
        private Label lbPaymentby;
        private Guna.UI2.WinForms.Guna2TextBox txtPhoneNumber;
        private Guna.UI2.WinForms.Guna2TextBox txtCustomerName;
        private Label lbPhoneNumber;
        private Label lbCustomerName;
        private Guna.UI2.WinForms.Guna2TextBox txtDate;
        private Label lbDate;
        private Guna.UI2.WinForms.Guna2TextBox txtbookingID;
        private Guna.UI2.WinForms.Guna2TextBox txtInvoiceNo;
        private Label lbbookingID;
        private Label lbInvoiceNo;
        private Label lbemail;
        private Label lbTel;
        private Label lbAddress;
        private TextBox txtbooking;
    }
}