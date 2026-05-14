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

            // ── dgvReceipt ──
            // NOTE: No DataGridViewCellStyle set here — all styles handled in SetupGrid()
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.RowHeadersVisible = false;
            dgvReceipt.ReadOnly = true;
            dgvReceipt.Location = new Point(25, 325);
            dgvReceipt.Name = "dgvReceipt";
            dgvReceipt.Size = new Size(880, 230);
            dgvReceipt.TabIndex = 0;
            dgvReceipt.BorderStyle = BorderStyle.FixedSingle;
            dgvReceipt.RowHeadersWidth = 51;
            dgvReceipt.BackgroundColor = Color.White;   // no gray

            // ── txtCustomerName ──
            txtCustomerName.Location = new Point(170, 207);
            txtCustomerName.Name = "txtCustomerName";
            txtCustomerName.Size = new Size(200, 27);
            txtCustomerName.TabIndex = 1;

            // ── txtPhoneNumber ──
            txtPhoneNumber.Location = new Point(170, 242);
            txtPhoneNumber.Name = "txtPhoneNumber";
            txtPhoneNumber.Size = new Size(200, 27);
            txtPhoneNumber.TabIndex = 2;

            // ── txtPaymentby ──
            txtPaymentby.Location = new Point(170, 277);
            txtPaymentby.Name = "txtPaymentby";
            txtPaymentby.Size = new Size(200, 27);
            txtPaymentby.TabIndex = 3;

            // ── txtInvoiceNo ──
            txtInvoiceNo.Location = new Point(680, 207);
            txtInvoiceNo.Name = "txtInvoiceNo";
            txtInvoiceNo.Size = new Size(190, 27);
            txtInvoiceNo.TabIndex = 4;

            // ── txtBooking ──
            txtBooking.Location = new Point(680, 242);
            txtBooking.Name = "txtBooking";
            txtBooking.Size = new Size(190, 27);
            txtBooking.TabIndex = 5;

            // ── txtInvoiceDate ──
            txtInvoiceDate.Location = new Point(680, 277);
            txtInvoiceDate.Name = "txtInvoiceDate";
            txtInvoiceDate.Size = new Size(190, 27);
            txtInvoiceDate.TabIndex = 6;

            // ── txtSubTotal ──
            txtSubTotal.Location = new Point(750, 568);
            txtSubTotal.Name = "txtSubTotal";
            txtSubTotal.Size = new Size(155, 27);
            txtSubTotal.TabIndex = 7;

            // ── txtDiscount ──
            txtDiscount.Location = new Point(750, 604);
            txtDiscount.Name = "txtDiscount";
            txtDiscount.Size = new Size(155, 27);
            txtDiscount.TabIndex = 8;

            // ── txtTotalAmount ──
            txtTotalAmount.Location = new Point(750, 640);
            txtTotalAmount.Name = "txtTotalAmount";
            txtTotalAmount.Size = new Size(155, 27);
            txtTotalAmount.TabIndex = 9;

            // ── Labels ──
            lblCustomerName.AutoSize = true;
            lblCustomerName.Font = new Font("Segoe UI", 10F);
            lblCustomerName.Location = new Point(25, 210);
            lblCustomerName.Name = "lblCustomerName";
            lblCustomerName.Text = "Customer Name :";

            lblPhoneNumber.AutoSize = true;
            lblPhoneNumber.Font = new Font("Segoe UI", 10F);
            lblPhoneNumber.Location = new Point(25, 245);
            lblPhoneNumber.Name = "lblPhoneNumber";
            lblPhoneNumber.Text = "Phone Number :";

            lblPaymentby.AutoSize = true;
            lblPaymentby.Font = new Font("Segoe UI", 10F);
            lblPaymentby.Location = new Point(25, 280);
            lblPaymentby.Name = "lblPaymentby";
            lblPaymentby.Text = "Payment :";

            lblInvoiceNo.AutoSize = true;
            lblInvoiceNo.Font = new Font("Segoe UI", 10F);
            lblInvoiceNo.Location = new Point(560, 210);
            lblInvoiceNo.Name = "lblInvoiceNo";
            lblInvoiceNo.Text = "InvoiceNo. :";

            lblBooking.AutoSize = true;
            lblBooking.Font = new Font("Segoe UI", 10F);
            lblBooking.Location = new Point(560, 245);
            lblBooking.Name = "lblBooking";
            lblBooking.Text = "Booking ID :";

            lblInvoiceDate.AutoSize = true;
            lblInvoiceDate.Font = new Font("Segoe UI", 10F);
            lblInvoiceDate.Location = new Point(560, 280);
            lblInvoiceDate.Name = "lblInvoiceDate";
            lblInvoiceDate.Text = "Invoice Date :";

            lblSubtotal.AutoSize = true;
            lblSubtotal.Font = new Font("Segoe UI", 10F);
            lblSubtotal.Location = new Point(630, 572);
            lblSubtotal.Name = "lblSubtotal";
            lblSubtotal.Text = "Total Price:";

            lblDiscount.AutoSize = true;
            lblDiscount.Font = new Font("Segoe UI", 10F);
            lblDiscount.Location = new Point(630, 608);
            lblDiscount.Name = "lblDiscount";
            lblDiscount.Text = "Discount:";

            lblTotalAmount.AutoSize = true;
            lblTotalAmount.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            lblTotalAmount.Location = new Point(600, 644);
            lblTotalAmount.Name = "lblTotalAmount";
            lblTotalAmount.Text = "Total Amount:";

            // ── Form ──
            BackColor = Color.White;
            ClientSize = new Size(930, 760);
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "Receipt Invoice";
            Name = "ReceiptForm";
            this.Load += new System.EventHandler(this.ReceiptForm_Load);

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