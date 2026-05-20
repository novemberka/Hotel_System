using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.PrintForms
{
    public partial class ReceiptForm : Form
    {
        public ReceiptForm()
        {
            InitializeComponent();
            SetupGrid();
            AddHeader();
            ArrangeControls();
        }

        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            txtInvoiceDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void AddHeader()
        {
            
            Label lblHotel = new Label();
            lblHotel.Text = "SYSTEM HOTEL";
            lblHotel.Font = new Font("Times New Roman", 20, FontStyle.Bold);
            lblHotel.ForeColor = Color.DarkViolet;
            lblHotel.BorderStyle = BorderStyle.FixedSingle;
            lblHotel.Padding = new Padding(8, 4, 8, 4);
            lblHotel.AutoSize = true;
            lblHotel.Location = new Point(320, 18);
            this.Controls.Add(lblHotel);

            
            Label lblAddress = new Label();
            lblAddress.Text = "Address: St 2004, Sen Sok, Phnom Penh";
            lblAddress.Font = new Font("Segoe UI", 10);
            lblAddress.AutoSize = true;
            lblAddress.Location = new Point(245, 78);
            this.Controls.Add(lblAddress);

         
            Label lblTel = new Label();
            lblTel.Text = "Tel: 097 967 9172";
            lblTel.Font = new Font("Segoe UI", 10);
            lblTel.AutoSize = true;
            lblTel.Location = new Point(330, 103);
            this.Controls.Add(lblTel);

           
            Label lblEmail = new Label();
            lblEmail.Text = "Email: hotel09@gmail.com";
            lblEmail.Font = new Font("Segoe UI", 10);
            lblEmail.AutoSize = true;
            lblEmail.Location = new Point(305, 128);
            this.Controls.Add(lblEmail);

           
            Label lblInvoice = new Label();
            lblInvoice.Text = "Invoice";
            lblInvoice.Font = new Font("Times New Roman", 16, FontStyle.Bold);
            lblInvoice.ForeColor = Color.Black;
            lblInvoice.BorderStyle = BorderStyle.FixedSingle;
            lblInvoice.Padding = new Padding(16, 4, 16, 4);
            lblInvoice.AutoSize = true;
            lblInvoice.Location = new Point(355, 158);
            this.Controls.Add(lblInvoice);
        }

        private void ArrangeControls()
        {
            
            lblCustomerName.Location = new Point(25, 210);
            txtCustomerName.Location = new Point(170, 207);
            txtCustomerName.Size = new Size(200, 27);

            lblPhoneNumber.Location = new Point(25, 245);
            txtPhoneNumber.Location = new Point(170, 242);
            txtPhoneNumber.Size = new Size(200, 27);

            lblPaymentby.Location = new Point(25, 280);
            txtPaymentby.Location = new Point(170, 277);
            txtPaymentby.Size = new Size(200, 27);

        
            lblInvoiceNo.Location = new Point(560, 210);
            txtInvoiceNo.Location = new Point(680, 207);
            txtInvoiceNo.Size = new Size(190, 27);

            lblBooking.Location = new Point(560, 245);
            txtBooking.Location = new Point(680, 242);
            txtBooking.Size = new Size(190, 27);

            lblInvoiceDate.Location = new Point(560, 280);
            txtInvoiceDate.Location = new Point(680, 277);
            txtInvoiceDate.Size = new Size(190, 27);

           
            dgvReceipt.Location = new Point(25, 325);
            dgvReceipt.Size = new Size(880, 230);

            
            lblSubtotal.Location = new Point(630, 572);
            txtSubTotal.Location = new Point(750, 568);
            txtSubTotal.Size = new Size(155, 27);

            lblDiscount.Location = new Point(630, 608);
            txtDiscount.Location = new Point(750, 604);
            txtDiscount.Size = new Size(155, 27);

            lblTotalAmount.Location = new Point(600, 644);
            txtTotalAmount.Location = new Point(750, 640);
            txtTotalAmount.Size = new Size(155, 27);

            
            Label lblThank = new Label();
            lblThank.Text = "Thank you for coming!!";
            lblThank.Font = new Font("Segoe UI", 12, FontStyle.Bold | FontStyle.Italic);
            lblThank.ForeColor = Color.DarkBlue;
            lblThank.AutoSize = true;
            lblThank.Location = new Point(330, 690);
            this.Controls.Add(lblThank);

            Label lblWelcome = new Label();
            lblWelcome.Text = "We look forward to welcoming you again!";
            lblWelcome.Font = new Font("Segoe UI", 10);
            lblWelcome.AutoSize = true;
            lblWelcome.Location = new Point(265, 720);
            this.Controls.Add(lblWelcome);
        }
        public void AdjustGridHeight()
        {
            int totalHeight = dgvReceipt.ColumnHeadersHeight;
            foreach (DataGridViewRow row in dgvReceipt.Rows)
                totalHeight += row.Height;
            totalHeight += 2;
            dgvReceipt.Height = totalHeight;

          
            int bottom = dgvReceipt.Location.Y + dgvReceipt.Height + 15;

            lblSubtotal.Location = new Point(630, bottom);
            txtSubTotal.Location = new Point(750, bottom - 4);
            lblDiscount.Location = new Point(630, bottom + 36);
            txtDiscount.Location = new Point(750, bottom + 32);
            lblTotalAmount.Location = new Point(600, bottom + 72);
            txtTotalAmount.Location = new Point(750, bottom + 68);
        }

        private void SetupGrid()
        {
            dgvReceipt.Columns.Clear();

            dgvReceipt.Columns.Add("No", "No.");
            dgvReceipt.Columns.Add("Description", "Description");
            dgvReceipt.Columns.Add("Qty", "QTY");
            dgvReceipt.Columns.Add("Price", "Price");
            dgvReceipt.Columns.Add("Discount", "Discount");
            dgvReceipt.Columns.Add("Amount", "Amount");

            dgvReceipt.Columns[0].Width = 50;
            dgvReceipt.Columns[1].Width = 290;
            dgvReceipt.Columns[2].Width = 80;
            dgvReceipt.Columns[3].Width = 120;
            dgvReceipt.Columns[4].Width = 140;
            dgvReceipt.Columns[5].Width = 140;

            dgvReceipt.RowHeadersVisible = false;
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.ReadOnly = true;
            dgvReceipt.BorderStyle = BorderStyle.FixedSingle;
            dgvReceipt.RowTemplate.Height = 30;
            dgvReceipt.ColumnHeadersHeight = 35;
            dgvReceipt.GridColor = Color.LightGray;
            dgvReceipt.EnableHeadersVisualStyles = false;
            


            dgvReceipt.BackgroundColor = Color.White;

         
            dgvReceipt.ColumnHeadersDefaultCellStyle.BackColor = Color.White;
            dgvReceipt.ColumnHeadersDefaultCellStyle.ForeColor = Color.Black;
            dgvReceipt.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
            dgvReceipt.ColumnHeadersDefaultCellStyle.SelectionBackColor = Color.White;
            dgvReceipt.ColumnHeadersDefaultCellStyle.SelectionForeColor = Color.Black;

          
            dgvReceipt.DefaultCellStyle.BackColor = Color.White;
            dgvReceipt.DefaultCellStyle.ForeColor = Color.Black;
            dgvReceipt.DefaultCellStyle.Font = new Font("Segoe UI", 10);
            dgvReceipt.DefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dgvReceipt.DefaultCellStyle.SelectionForeColor = Color.White;

            
            dgvReceipt.AlternatingRowsDefaultCellStyle.BackColor = Color.White;
            dgvReceipt.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            dgvReceipt.AlternatingRowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 102, 204);
            dgvReceipt.AlternatingRowsDefaultCellStyle.SelectionForeColor = Color.White;
        }
    }
}