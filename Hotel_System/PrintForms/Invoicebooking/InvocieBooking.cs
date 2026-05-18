using Hotel_System.Services;
using System;
using System.Data;
using System.Drawing.Printing;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.PrintForms
{
    public partial class InvoiceBooking : Form
    {
        private readonly InvoiceService _invoiceService =
            new InvoiceService();

        private int _bookingID;
        private PrintDocument printDocument =
            new PrintDocument();

        public InvoiceBooking(int bookingID)
        {
            InitializeComponent();

            _bookingID = bookingID;

            printDocument.PrintPage += PrintPage;

            this.Load += InvoiceBooking_Load;
        }

        private void InvoiceBooking_Load(object sender, EventArgs e)
        {
            LoadInvoice();
        }

        private void LoadInvoice()
        {
            try
            {
                DataTable dt =
                    _invoiceService.GetInvoiceData(_bookingID);

                if (dt == null || dt.Rows.Count == 0)
                {
                    MessageBox.Show("No data found");
                    return;
                }

                DataRow row = dt.Rows[0];

                txtInvoiceNo.Text = "INV-" + _bookingID;
                txtbookingID.Text = _bookingID.ToString();

                txtCustomerName.Text = row["FullName"].ToString();
                txtPhoneNumber.Text = row["Phone"].ToString();
                txtPayment.Text = row["PaymentBy"].ToString();
                txtDate.Text = DateTime.Now.ToString("yyyy-MM-dd");

                dgvBookingInvoice.Rows.Clear();

                dgvBookingInvoice.Rows.Add(
                    1,
                    "Room Booking",
                    row["RoomNumber"].ToString(),
                    row["RoomType"].ToString(),
                    Convert.ToDateTime(row["CheckInDate"]).ToString("yyyy-MM-dd"),
                    Convert.ToDateTime(row["CheckOutDate"]).ToString("yyyy-MM-dd"),
                    row["Total"].ToString(),
                    row["Status"].ToString()
                );

                lblTotalValue.Text =
                    "$" + row["Total"].ToString();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            PrintPreviewDialog preview =
                new PrintPreviewDialog();

            preview.Document = printDocument;
            preview.WindowState = FormWindowState.Maximized;
            preview.ShowDialog();
        }

        private void PrintPage(object sender, PrintPageEventArgs e)
        {
            Bitmap bmp =
                new Bitmap(panelMain.Width, panelMain.Height);

            panelMain.DrawToBitmap(
                bmp,
                new Rectangle(0, 0, panelMain.Width, panelMain.Height)
            );

            e.Graphics.DrawImage(
                bmp,
                e.MarginBounds.Left,
                e.MarginBounds.Top
            );
        }
        private void dgvBookingInvoice_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
        }

        private void panelMain_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}