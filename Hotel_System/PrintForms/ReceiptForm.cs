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


            this.Text = "Receipt";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            SetupGrid();
            AddHeader();
        }
        private void ReceiptForm_Load(object sender, EventArgs e)
        {
            // optional: default values
            txtInvoiceDate.Text = DateTime.Now.ToString("yyyy-MM-dd");
        }

        private void AddHeader()
        {
            Label lblHotel = new Label();
            lblHotel.Text = "SUNRISE HOTEL";
            lblHotel.Font = new Font("Segoe UI", 20, FontStyle.Bold);
            lblHotel.AutoSize = true;
            lblHotel.Location = new Point(250, 20);
            this.Controls.Add(lblHotel);

            Label lblReceipt = new Label();
            lblReceipt.Text = "PAYMENT RECEIPT";
            lblReceipt.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            lblReceipt.AutoSize = true;
            lblReceipt.Location = new Point(280, 70);
            this.Controls.Add(lblReceipt);
        }

        private void SetupGrid()
        {
            dgvReceipt.Columns.Clear();

            dgvReceipt.Columns.Add("No", "No");
            dgvReceipt.Columns.Add("RoomType", "Room Type");
            dgvReceipt.Columns.Add("RoomNo", "Room No");
            dgvReceipt.Columns.Add("Qty", "Qty");
            dgvReceipt.Columns.Add("Price", "Price");
            dgvReceipt.Columns.Add("Total", "Total");

            dgvReceipt.AutoSizeColumnsMode =
                DataGridViewAutoSizeColumnsMode.Fill;

            dgvReceipt.RowHeadersVisible = false;
            dgvReceipt.AllowUserToAddRows = false;
            dgvReceipt.ReadOnly = true;

            dgvReceipt.EnableHeadersVisualStyles = false;

            dgvReceipt.ColumnHeadersDefaultCellStyle.BackColor =
                Color.Navy;

            dgvReceipt.ColumnHeadersDefaultCellStyle.ForeColor =
                Color.White;

            dgvReceipt.ColumnHeadersDefaultCellStyle.Font =
                new Font("Segoe UI", 10, FontStyle.Bold);

            dgvReceipt.DefaultCellStyle.Font =
                new Font("Segoe UI", 10);

            dgvReceipt.RowTemplate.Height = 30;
        }
    }
}