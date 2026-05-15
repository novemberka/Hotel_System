using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.PrintForms
{
    partial class ReceiptForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            dgvReceipt = new DataGridView();
            txtSubTotal = new TextBox();
            txtDiscount = new TextBox();
            txtTotalAmount = new TextBox();
            txtPaymentby = new TextBox();
            txtCustomerName = new TextBox();
            txtPhoneNumber = new TextBox();
            txtInvoiceDate = new TextBox();
            txtBooking = new TextBox();
            txtInvoiceNo = new TextBox();
            lblSubtotal = new Label();
            lblDiscount = new Label();
            lblTotalAmount = new Label();
            lblPaymentby = new Label();
            lblCustomerName = new Label();
            lblPhoneNumber = new Label();
            lblInvoiceDate = new Label();
            lblBooking = new Label();
            lblInvoiceNo = new Label();
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).BeginInit();
            SuspendLayout();
            // 
            // dgvReceipt
            // 
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.BackgroundColor = Color.White;
            dgvReceipt.ColumnHeadersHeight = 29;
            dgvReceipt.Location = new Point(25, 325);
            dgvReceipt.Name = "dgvReceipt";
            dgvReceipt.ReadOnly = true;
            dgvReceipt.RowHeadersVisible = false;
            dgvReceipt.RowHeadersWidth = 51;
            dgvReceipt.Size = new Size(845, 230);
            dgvReceipt.TabIndex = 0;
            // 
            // txtSubTotal
            // 
            txtSubTotal.BorderStyle = BorderStyle.None;
            txtSubTotal.Location = new Point(750, 568);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(120, 20);
            txtSubTotal.TabIndex = 7;
            // 
            // txtDiscount
            // 
            txtDiscount.BorderStyle = BorderStyle.None;
            txtDiscount.Location = new Point(750, 604);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(120, 20);
            txtDiscount.TabIndex = 8;
            // 
            // txtTotalAmount
            // 
            txtTotalAmount.BorderStyle = BorderStyle.None;
            txtTotalAmount.Location = new Point(750, 640);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(120, 20);
            txtTotalAmount.TabIndex = 9;
            // 
            // txtPaymentby
            // 
            txtPaymentby.BorderStyle = BorderStyle.None;
            txtPaymentby.Location = new Point(170, 277);
            txtPaymentby.Name = "txtPaymentby";
            txtPaymentby.Size = new Size(200, 20);
            txtPaymentby.TabIndex = 3;
            // 
            // txtCustomerName
            // 
            txtCustomerName.BorderStyle = BorderStyle.None;
            txtCustomerName.Location = new Point(170, 207);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 20);
            txtCustomerName.TabIndex = 1;
            // 
            // txtPhoneNumber
            // 
            txtPhoneNumber.BorderStyle = BorderStyle.None;
            txtPhoneNumber.Location = new Point(170, 242);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(200, 20);
            txtPhoneNumber.TabIndex = 2;
            // 
            // txtInvoiceDate
            // 
            txtInvoiceDate.BorderStyle = BorderStyle.None;
            txtInvoiceDate.Location = new Point(680, 277);
            txtInvoiceDate.Name = "txtInvoiceDate";
            txtInvoiceDate.Size = new Size(190, 20);
            txtInvoiceDate.TabIndex = 6;
            // 
            // txtBooking
            // 
            txtBooking.BorderStyle = BorderStyle.None;
            txtBooking.Location = new Point(680, 242);
            txtBooking.Name = "txtBooking";
            txtBooking.Size = new Size(190, 20);
            txtBooking.TabIndex = 5;
            // 
            // txtInvoiceNo
            // 
            txtInvoiceNo.BorderStyle = BorderStyle.None;
            txtInvoiceNo.Location = new Point(680, 207);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.Size = new Size(190, 20);
            txtInvoiceNo.TabIndex = 4;
            // 
            // lblSubtotal
            // 
            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F);
            lblSubtotal.Location = new Point(630, 572);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Size = new Size(92, 23);
            lblSubtotal.TabIndex = 7;
            lblSubtotal.Text = "Total Price:";
            // 
            // lblDiscount
            // 
            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F);
            lblDiscount.Location = new Point(630, 608);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Size = new Size(81, 23);
            lblDiscount.TabIndex = 8;
            lblDiscount.Text = "Discount:";
            // 
            // lblTotalAmount
            // 
            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(600, 644);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Size = new Size(124, 23);
            lblTotalAmount.TabIndex = 9;
            lblTotalAmount.Text = "Total Amount:";
            // 
            // lblPaymentby
            // 
            lblPaymentby.AutoSize = true;
            lblPaymentby.Font = new Font("Segoe UI", 10F);
            lblPaymentby.Location = new Point(25, 280);
            lblPaymentby.Name = "lblPaymentby";
            lblPaymentby.Size = new Size(85, 23);
            lblPaymentby.TabIndex = 3;
            lblPaymentby.Text = "Payment :";
            // 
            // lblCustomerName
            // 
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F);
            lblCustomerName.Location = new Point(25, 210);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Size = new Size(144, 23);
            lblCustomerName.TabIndex = 0;
            lblCustomerName.Text = "Customer Name :";
            // 
            // lblPhoneNumber
            // 
            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 10F);
            lblPhoneNumber.Location = new Point(25, 245);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Size = new Size(136, 23);
            lblPhoneNumber.TabIndex = 2;
            lblPhoneNumber.Text = "Phone Number :";
            // 
            // lblInvoiceDate
            // 
            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Font = new Font("Segoe UI", 10F);
            lblInvoiceDate.Location = new Point(560, 280);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Size = new Size(114, 23);
            lblInvoiceDate.TabIndex = 6;
            lblInvoiceDate.Text = "Invoice Date :";
            // 
            // lblBooking
            // 
            lblBooking.AutoSize = true;
            lblBooking.Font = new Font("Segoe UI", 10F);
            lblBooking.Location = new Point(560, 245);
            lblBooking.Name = "lblBooking";
            lblBooking.Size = new Size(103, 23);
            lblBooking.TabIndex = 5;
            lblBooking.Text = "Booking ID :";
            // 
            // lblInvoiceNo
            // 
            lblInvoiceNo.AutoSize = true;
            lblInvoiceNo.Font = new Font("Segoe UI", 10F);
            lblInvoiceNo.Location = new Point(560, 210);
            lblInvoiceNo.Name = "lblInvoiceNo";
            lblInvoiceNo.Size = new Size(100, 23);
            lblInvoiceNo.TabIndex = 4;
            lblInvoiceNo.Text = "InvoiceNo. :";
            // 
            // ReceiptForm
            // 
            BackColor = Color.White;
            ClientSize = new Size(898, 760);
            Controls.Add(lblCustomerName);
            Controls.Add(txtCustomerName);
            Controls.Add(lblPhoneNumber);
            Controls.Add(txtPhoneNumber);
            Controls.Add(lblPaymentby);
            Controls.Add(txtPaymentby);
            Controls.Add(lblInvoiceNo);
            Controls.Add(txtInvoiceNo);
            Controls.Add(lblBooking);
            Controls.Add(txtBooking);
            Controls.Add(lblInvoiceDate);
            Controls.Add(txtInvoiceDate);
            Controls.Add(dgvReceipt);
            Controls.Add(lblSubtotal);
            Controls.Add(txtSubTotal);
            Controls.Add(lblDiscount);
            Controls.Add(txtDiscount);
            Controls.Add(lblTotalAmount);
            Controls.Add(txtTotalAmount);
            Name = "ReceiptForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Receipt Invoice";
            Load += ReceiptForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvReceipt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        // Public controls
        public DataGridView dgvReceipt;
        public TextBox txtSubTotal;
        public TextBox txtDiscount;
        public TextBox txtTotalAmount;
        public TextBox txtPaymentby;
        public TextBox txtCustomerName;
        public TextBox txtPhoneNumber;
        public TextBox txtInvoiceDate;
        public TextBox txtBooking;
        public TextBox txtInvoiceNo;

        private Label lblSubtotal;
        private Label lblDiscount;
        private Label lblTotalAmount;
        private Label lblPaymentby;
        private Label lblCustomerName;
        private Label lblPhoneNumber;
        private Label lblInvoiceDate;
        private Label lblBooking;
        private Label lblInvoiceNo;
    }
}