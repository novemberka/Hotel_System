using System;
using System.Drawing;
using System.Windows.Forms;
using DrawingFont = System.Drawing.Font;

namespace Hotel_System.PrintForms
{
    partial class InvoiceBooking
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            panelMain = new Panel();
            lblHotelName = new Label();
            lbAddress = new Label();
            lbTel = new Label();
            lbemail = new Label();
            lbCustomerName = new Label();
            lbPhoneNumber = new Label();
            lbPaymentby = new Label();
            lbInvoiceNo = new Label();
            lbbookingID = new Label();
            lbDate = new Label();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtPayment = new TextBox();
            txtInvoiceNo = new TextBox();
            txtbookingID = new TextBox();
            txtDate = new TextBox();
            dgvBookingInvoice = new DataGridView();
            lblGrandTotal = new Label();
            lblTotalValue = new Label();
            label4 = new Label();
            label5 = new Label();
            No = new DataGridViewTextBoxColumn();
            Description = new DataGridViewTextBoxColumn();
            RoomNumber = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            CheckInDate = new DataGridViewTextBoxColumn();
            CheckOutDate = new DataGridViewTextBoxColumn();
            Total = new DataGridViewTextBoxColumn();
            panelMain.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).BeginInit();
            SuspendLayout();
            // 
            // panelMain
            // 
            panelMain.BackColor = Color.White;
            panelMain.BorderStyle = BorderStyle.FixedSingle;
            panelMain.Controls.Add(lblHotelName);
            panelMain.Controls.Add(lbAddress);
            panelMain.Controls.Add(lbTel);
            panelMain.Controls.Add(lbemail);
            panelMain.Controls.Add(lbCustomerName);
            panelMain.Controls.Add(lbPhoneNumber);
            panelMain.Controls.Add(lbPaymentby);
            panelMain.Controls.Add(lbInvoiceNo);
            panelMain.Controls.Add(lbbookingID);
            panelMain.Controls.Add(lbDate);
            panelMain.Controls.Add(txtCustomerName);
            panelMain.Controls.Add(txtPhoneNumber);
            panelMain.Controls.Add(txtPayment);
            panelMain.Controls.Add(txtInvoiceNo);
            panelMain.Controls.Add(txtbookingID);
            panelMain.Controls.Add(txtDate);
            panelMain.Controls.Add(dgvBookingInvoice);
            panelMain.Controls.Add(lblGrandTotal);
            panelMain.Controls.Add(lblTotalValue);
            panelMain.Location = new Point(10, 10);
            panelMain.Name = "panelMain";
            panelMain.Size = new Size(1070, 730);
            panelMain.TabIndex = 0;
            // 
            // lblHotelName
            // 
            lblHotelName.AutoSize = true;
            lblHotelName.Font = new Font("Segoe UI", 20F, FontStyle.Bold);
            lblHotelName.ForeColor = Color.DarkSlateBlue;
            lblHotelName.Location = new Point(390, 20);
            lblHotelName.Name = "lblHotelName";
            lblHotelName.Size = new Size(266, 46);
            lblHotelName.TabIndex = 0;
            lblHotelName.Text = "LUXURY HOTEL";
            // 
            // lbAddress
            // 
            lbAddress.AutoSize = true;
            lbAddress.Font = new Font("Segoe UI", 10F);
            lbAddress.Location = new Point(355, 70);
            lbAddress.Name = "lbAddress";
            lbAddress.Size = new Size(310, 23);
            lbAddress.TabIndex = 1;
            lbAddress.Text = "Address: St 2004, Sen Sok, Phnom Penh";
            // 
            // lbTel
            // 
            lbTel.AutoSize = true;
            lbTel.Font = new Font("Segoe UI", 10F);
            lbTel.Location = new Point(420, 95);
            lbTel.Name = "lbTel";
            lbTel.Size = new Size(139, 23);
            lbTel.TabIndex = 2;
            lbTel.Text = "Tel: 097 967 9172";
            // 
            // lbemail
            // 
            lbemail.AutoSize = true;
            lbemail.Font = new Font("Segoe UI", 10F);
            lbemail.Location = new Point(385, 120);
            lbemail.Name = "lbemail";
            lbemail.Size = new Size(212, 23);
            lbemail.TabIndex = 3;
            lbemail.Text = "Email: hotel09@gmail.com";
            // 
            // lbCustomerName
            // 
            lbCustomerName.Location = new Point(40, 180);
            lbCustomerName.Name = "lbCustomerName";
            lbCustomerName.Size = new Size(100, 23);
            lbCustomerName.TabIndex = 4;
            lbCustomerName.Text = "Customer Name :";
            // 
            // lbPhoneNumber
            // 
            lbPhoneNumber.Location = new Point(40, 220);
            lbPhoneNumber.Name = "lbPhoneNumber";
            lbPhoneNumber.Size = new Size(100, 23);
            lbPhoneNumber.TabIndex = 5;
            lbPhoneNumber.Text = "Phone Number :";
            // 
            // lbPaymentby
            // 
            lbPaymentby.Location = new Point(40, 260);
            lbPaymentby.Name = "lbPaymentby";
            lbPaymentby.Size = new Size(100, 23);
            lbPaymentby.TabIndex = 6;
            lbPaymentby.Text = "Payment By :";
            // 
            // lbInvoiceNo
            // 
            lbInvoiceNo.Location = new Point(700, 180);
            lbInvoiceNo.Name = "lbInvoiceNo";
            lbInvoiceNo.Size = new Size(100, 23);
            lbInvoiceNo.TabIndex = 7;
            lbInvoiceNo.Text = "Invoice No :";
            // 
            // lbbookingID
            // 
            lbbookingID.Location = new Point(700, 220);
            lbbookingID.Name = "lbbookingID";
            lbbookingID.Size = new Size(100, 23);
            lbbookingID.TabIndex = 8;
            lbbookingID.Text = "Booking ID :";
            // 
            // lbDate
            // 
            lbDate.Location = new Point(700, 260);
            lbDate.Name = "lbDate";
            lbDate.Size = new Size(100, 23);
            lbDate.TabIndex = 9;
            lbDate.Text = "Invoice Date :";
            // 
            // txtCustomerName
            // 
            txtCustomerName.Location = new Point(190, 175);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.ReadOnly = true;
            txtCustomerName.Size = new Size(220, 27);
            txtCustomerName.TabIndex = 10;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.Location = new Point(190, 215);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.ReadOnly = true;
            txtPhoneNumber.Size = new Size(220, 27);
            txtPhoneNumber.TabIndex = 11;
            // 
            // txtPayment
            // 
            txtPayment.Location = new Point(190, 255);
            txtPayment.Name = "txtPayment";
            txtPayment.ReadOnly = true;
            txtPayment.Size = new Size(220, 27);
            txtPayment.TabIndex = 12;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.Location = new Point(820, 175);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.ReadOnly = true;
            txtInvoiceNo.Size = new Size(200, 27);
            txtInvoiceNo.TabIndex = 13;
            // 
            // txtbookingID
            // 
            txtbookingID.Location = new Point(820, 215);
            txtbookingID.Name = "txtbookingID";
            txtbookingID.ReadOnly = true;
            txtbookingID.Size = new Size(200, 27);
            txtbookingID.TabIndex = 14;
            // 
            // txtDate
            // 
            txtDate.Location = new Point(820, 255);
            txtDate.Name = "txtDate";
            txtDate.ReadOnly = true;
            txtDate.Size = new Size(200, 27);
            txtDate.TabIndex = 15;
            // 
            // dgvBookingInvoice
            // 
            dgvBookingInvoice.AllowUserToAddRows = false;
            dgvBookingInvoice.AllowUserToDeleteRows = false;
            dgvBookingInvoice.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBookingInvoice.BackgroundColor = Color.White;
            dgvBookingInvoice.ColumnHeadersHeight = 29;
            dgvBookingInvoice.Columns.AddRange(new DataGridViewColumn[] { No, Description, RoomNumber, RoomType, CheckInDate, CheckOutDate, Total });
            dgvBookingInvoice.Location = new Point(40, 330);
            dgvBookingInvoice.Name = "dgvBookingInvoice";
            dgvBookingInvoice.RowHeadersVisible = false;
            dgvBookingInvoice.RowHeadersWidth = 51;
            dgvBookingInvoice.Size = new Size(980, 250);
            dgvBookingInvoice.TabIndex = 16;
            dgvBookingInvoice.CellContentClick += dgvBookingInvoice_CellContentClick;
            // 
            // lblGrandTotal
            // 
            lblGrandTotal.AutoSize = true;
            lblGrandTotal.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            lblGrandTotal.Location = new Point(760, 600);
            lblGrandTotal.Name = "lblGrandTotal";
            lblGrandTotal.Size = new Size(126, 25);
            lblGrandTotal.TabIndex = 17;
            lblGrandTotal.Text = "Grand Total :";
            // 
            // lblTotalValue
            // 
            lblTotalValue.AutoSize = true;
            lblTotalValue.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            lblTotalValue.ForeColor = Color.DarkGreen;
            lblTotalValue.Location = new Point(900, 598);
            lblTotalValue.Name = "lblTotalValue";
            lblTotalValue.Size = new Size(65, 28);
            lblTotalValue.TabIndex = 18;
            lblTotalValue.Text = "$0.00";
            // 
            // label4
            // 
            label4.Location = new Point(0, 0);
            label4.Name = "label4";
            label4.Size = new Size(100, 23);
            label4.TabIndex = 0;
            // 
            // label5
            // 
            label5.Location = new Point(0, 0);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 0;
            // 
            // No
            // 
            No.HeaderText = "No";
            No.MinimumWidth = 6;
            No.Name = "No";
            // 
            // Description
            // 
            Description.HeaderText = "Description";
            Description.MinimumWidth = 6;
            Description.Name = "Description";
            // 
            // RoomNumber
            // 
            RoomNumber.HeaderText = "RoomNumber";
            RoomNumber.MinimumWidth = 6;
            RoomNumber.Name = "RoomNumber";
            // 
            // RoomType
            // 
            RoomType.HeaderText = "RoomType";
            RoomType.MinimumWidth = 6;
            RoomType.Name = "RoomType";
            // 
            // CheckInDate
            // 
            CheckInDate.HeaderText = "CheckInDate";
            CheckInDate.MinimumWidth = 6;
            CheckInDate.Name = "CheckInDate";
            // 
            // CheckOutDate
            // 
            CheckOutDate.HeaderText = "CheckOutDate";
            CheckOutDate.MinimumWidth = 6;
            CheckOutDate.Name = "CheckOutDate";
            // 
            // Total
            // 
            Total.HeaderText = "Total";
            Total.MinimumWidth = 6;
            Total.Name = "Total";
            // 
            // InvoiceBooking
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.WhiteSmoke;
            ClientSize = new Size(1100, 760);
            Controls.Add(panelMain);
            Name = "InvoiceBooking";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Invoice Booking";
            panelMain.ResumeLayout(false);
            panelMain.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvBookingInvoice).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panelMain;

        private Label lblHotelName;
        private Label lbAddress;
        private Label lbTel;
        private Label lbemail;

        private Label lbCustomerName;
        private Label lbPhoneNumber;
        private Label lbPaymentby;

        private Label lbInvoiceNo;
        private Label lbbookingID;
        private Label lbDate;

        private TextBox txtCustomerName;
        private TextBox txtPhoneNumber;
        private TextBox txtPayment;

        private TextBox txtInvoiceNo;
        private TextBox txtbookingID;
        private TextBox txtDate;

        private DataGridView dgvBookingInvoice;

        private Label lblGrandTotal;
        private Label lblTotalValue;

        private Label label4;
        private Label label5;
        private DataGridViewTextBoxColumn No;
        private DataGridViewTextBoxColumn Description;
        private DataGridViewTextBoxColumn RoomNumber;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn CheckInDate;
        private DataGridViewTextBoxColumn CheckOutDate;
        private DataGridViewTextBoxColumn Total;
    }
}