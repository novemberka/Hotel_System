using Hotel_System.PrintForms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using MySql.Data.MySqlClient;
using System;
using System.Diagnostics;
using System.IO;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;
using PdfFont = iTextSharp.text.Font;
using PdfRectangle = iTextSharp.text.Rectangle;
namespace Hotel_System
{
    public partial class PaymentControl : UserControl
    {
        string connectionString =
            "server=localhost;database=hoteldb;uid=root;pwd=;";

        public PaymentControl()
        {
            InitializeComponent();

            this.Load += PaymentControl_Load;
            btnPay.Click += btnPayNow_Click;
            btnPrintRecicpt.Click += btnPrint_Click;
            btnClear.Click += btnClear_Click;
            btnPDF.Click += btnPDF_Click;
        }

        private void dgvPayment_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                dgvPayment.Rows[e.RowIndex].Selected = true;
            }
        }

        private void PaymentControl_Load(object sender, EventArgs e)
        {
            cmbPaymentType.Items.Clear();
            cmbPaymentType.Items.Add("Cash");
            cmbPaymentType.Items.Add("Card");
            cmbPaymentType.Items.Add("Bank");
            cmbPaymentType.Items.Add("Other");

            dgvPayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayment.MultiSelect = false;
            dgvPayment.ReadOnly = true;
            dgvPayment.AllowUserToAddRows = false;
            dgvPayment.AllowUserToDeleteRows = false;
            dgvPayment.RowHeadersVisible = false;
            dgvPayment.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayment.RowTemplate.Height = 35;

            SetupPaymentGrid();
            LoadCustomers();
            LoadPayments();

            cmbCustomerName.SelectedIndexChanged += cmbCustomerName_SelectedIndexChanged;
            dgvPayment.CellClick += dgvPayment_CellClick;
        }

        private void LoadCustomers()
        {
            cmbCustomerName.Items.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT b.BookingID, c.FullName
                FROM bookings b
                INNER JOIN customers c ON b.CustomerID = c.CustomerID
                INNER JOIN checkins ci ON b.BookingID = ci.BookingID
                INNER JOIN checkouts co ON ci.CheckInID = co.CheckInID
                WHERE b.Status != 'Completed'";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    cmbCustomerName.Items.Add(
                        new ComboBoxItem(
                            reader["FullName"].ToString(),
                            reader["BookingID"].ToString()
                        )
                    );
                }

                reader.Close();
            }
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbCustomerName.SelectedItem == null)
                return;

            ComboBoxItem item = (ComboBoxItem)cmbCustomerName.SelectedItem;
            int bookingID = Convert.ToInt32(item.Value);

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT r.RoomNumber, rt.TypeName, rt.PricePerNight,
                       b.CheckInDate, b.CheckOutDate
                FROM bookings b
                INNER JOIN rooms r ON b.RoomID = r.RoomID
                INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE b.BookingID = @BookingID";

                MySqlCommand cmd = new MySqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@BookingID", bookingID);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    txtRoomType.Text = reader["TypeName"].ToString();
                    txtRoomNumber.Text = reader["RoomNumber"].ToString();

                    DateTime checkIn = Convert.ToDateTime(reader["CheckInDate"]);
                    DateTime checkOut = Convert.ToDateTime(reader["CheckOutDate"]);

                    CheckInDate.Value = checkIn;
                    CheckOutDate.Value = checkOut;

                    decimal price = Convert.ToDecimal(reader["PricePerNight"]);

                    int days = (checkOut - checkIn).Days;

                    if (days <= 0)
                        days = 1;

                    txtTotalAmount.Text = (price * days).ToString("0.00");
                }

                reader.Close();
            }
        }

        private void btnPayNow_Click(object sender, EventArgs e)
        {
            try
            {
                if (cmbCustomerName.SelectedItem == null ||
                    cmbPaymentType.SelectedItem == null)
                {
                    MessageBox.Show("Select customer and payment type!");
                    return;
                }

                ComboBoxItem item = (ComboBoxItem)cmbCustomerName.SelectedItem;
                int bookingID = Convert.ToInt32(item.Value);

                decimal amount = Convert.ToDecimal(txtTotalAmount.Text);
                string method = cmbPaymentType.Text;
                string invoiceNo = GenerateInvoiceNo();

                int paymentID = 0;

                using (MySqlConnection conn = new MySqlConnection(connectionString))
                {
                    conn.Open();

                    string getCheckout = @"
                    SELECT c.CheckOutID
                    FROM checkouts c
                    INNER JOIN checkins i ON c.CheckInID = i.CheckInID
                    WHERE i.BookingID = @BookingID";

                    MySqlCommand cmd = new MySqlCommand(getCheckout, conn);
                    cmd.Parameters.AddWithValue("@BookingID", bookingID);

                    object result = cmd.ExecuteScalar();

                    if (result == null)
                    {
                        MessageBox.Show("Customer not checked out yet!");
                        return;
                    }

                    int checkOutID = Convert.ToInt32(result);

                    string insert = @"
                    INSERT INTO payments
                    (InvoiceNo, CheckOutID, AmountPaid, PaymentMethod, PaymentStatus, BookingID, IsPrinted)
                    VALUES
                    (@InvoiceNo, @CheckOutID, @Amount, @Method, 'Paid', @BookingID, 0);

                    SELECT LAST_INSERT_ID();";

                    MySqlCommand cmdInsert = new MySqlCommand(insert, conn);

                    cmdInsert.Parameters.AddWithValue("@InvoiceNo", invoiceNo);
                    cmdInsert.Parameters.AddWithValue("@CheckOutID", checkOutID);
                    cmdInsert.Parameters.AddWithValue("@Amount", amount);
                    cmdInsert.Parameters.AddWithValue("@Method", method);
                    cmdInsert.Parameters.AddWithValue("@BookingID", bookingID);

                    paymentID = Convert.ToInt32(cmdInsert.ExecuteScalar());

                    string updateBooking = @"
                    UPDATE bookings
                    SET Status = 'Completed'
                    WHERE BookingID = @BookingID";

                    MySqlCommand cmdUpdate = new MySqlCommand(updateBooking, conn);
                    cmdUpdate.Parameters.AddWithValue("@BookingID", bookingID);

                    cmdUpdate.ExecuteNonQuery();
                }

                LoadPayments();

                MessageBox.Show("Payment Successful!");

                OpenReceipt(paymentID);

                ClearForm();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dgvPayment.CurrentRow == null)
            {
                MessageBox.Show("Select payment row!");
                return;
            }

            int paymentID =
                Convert.ToInt32(dgvPayment.CurrentRow.Cells[0].Value);

            OpenReceipt(paymentID);
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            ClearForm();
            dgvPayment.ClearSelection();
        }

        private void ClearForm()
        {
            cmbCustomerName.SelectedIndex = -1;
            cmbPaymentType.SelectedIndex = -1;

            txtRoomType.Clear();
            txtRoomNumber.Clear();
            txtTotalAmount.Clear();
        }

        private string GenerateInvoiceNo()
        {
            string year = DateTime.Now.Year.ToString();
            string prefix = "INV-" + year + "-";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT InvoiceNo
                FROM payments
                WHERE InvoiceNo LIKE @Prefix
                ORDER BY PaymentID DESC
                LIMIT 1";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@Prefix", prefix + "%");

                object result = cmd.ExecuteScalar();

                int nextNumber = 1;

                if (result != null)
                {
                    string lastInvoice = result.ToString();
                    string[] parts = lastInvoice.Split('-');

                    nextNumber = Convert.ToInt32(parts[2]) + 1;
                }

                return prefix + nextNumber.ToString("0000");
            }
        }

        private void SetupPaymentGrid()
        {
            dgvPayment.Columns.Clear();
            dgvPayment.AutoGenerateColumns = false;

            dgvPayment.Columns.Add("PaymentID", "PaymentID");
            dgvPayment.Columns.Add("BookingID", "BookingID");
            dgvPayment.Columns.Add("CustomerName", "Customer Name");
            dgvPayment.Columns.Add("RoomType", "Room Type");
            dgvPayment.Columns.Add("RoomNumber", "Room Number");
            dgvPayment.Columns.Add("Amount", "Total Price");
            dgvPayment.Columns.Add("Method", "Payment Type");
            dgvPayment.Columns.Add("Date", "Payment Date");

            dgvPayment.Columns[0].Visible = false;
            dgvPayment.Columns[1].Visible = false;
        }

        private void LoadPayments()
        {
            dgvPayment.Rows.Clear();

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                string query = @"
                SELECT 
                    p.PaymentID,
                    b.BookingID,
                    c.FullName,
                    rt.TypeName,
                    r.RoomNumber,
                    p.AmountPaid,
                    p.PaymentMethod,
                    p.PaymentDate
                FROM payments p
                INNER JOIN bookings b ON p.BookingID = b.BookingID
                INNER JOIN customers c ON b.CustomerID = c.CustomerID
                INNER JOIN rooms r ON b.RoomID = r.RoomID
                INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE p.PaymentStatus = 'Paid'
                ORDER BY p.PaymentDate DESC";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                conn.Open();

                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    dgvPayment.Rows.Add(
                        reader["PaymentID"],
                        reader["BookingID"],
                        reader["FullName"],
                        reader["TypeName"],
                        reader["RoomNumber"],
                        reader["AmountPaid"],
                        reader["PaymentMethod"],
                        Convert.ToDateTime(reader["PaymentDate"])
                            .ToString("yyyy-MM-dd")
                    );
                }

                reader.Close();
            }
        }

        private void OpenReceipt(int paymentID)
        {
            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                SELECT p.PaymentID, p.InvoiceNo, b.BookingID,
                       c.FullName, c.Phone,
                       rt.TypeName, r.RoomNumber,
                       p.AmountPaid, p.PaymentMethod, p.PaymentDate,
                       b.CheckInDate, b.CheckOutDate
                FROM payments p
                INNER JOIN bookings b ON p.BookingID = b.BookingID
                INNER JOIN customers c ON b.CustomerID = c.CustomerID
                INNER JOIN rooms r ON b.RoomID = r.RoomID
                INNER JOIN roomtypes rt ON r.RoomTypeID = rt.RoomTypeID
                WHERE p.PaymentID = @PaymentID";

                MySqlCommand cmd = new MySqlCommand(query, conn);

                cmd.Parameters.AddWithValue("@PaymentID", paymentID);

                MySqlDataReader reader = cmd.ExecuteReader();

                if (reader.Read())
                {
                    ReceiptForm f = new ReceiptForm();

                    f.txtInvoiceNo.Text = reader["InvoiceNo"].ToString();
                    f.txtBooking.Text = reader["BookingID"].ToString();
                    f.txtCustomerName.Text = reader["FullName"].ToString();
                    f.txtPhoneNumber.Text = reader["Phone"].ToString();
                    f.txtPaymentby.Text = reader["PaymentMethod"].ToString();

                    f.txtInvoiceDate.Text =
                        Convert.ToDateTime(reader["PaymentDate"])
                        .ToString("yyyy-MM-dd");

                    DateTime checkIn =
                        Convert.ToDateTime(reader["CheckInDate"]);

                    DateTime checkOut =
                        Convert.ToDateTime(reader["CheckOutDate"]);

                    int nights = (checkOut - checkIn).Days;

                    if (nights <= 0)
                        nights = 1;

                    decimal totalAmount =
                        Convert.ToDecimal(reader["AmountPaid"]);

                    decimal pricePerNight = totalAmount / nights;

                    f.txtSubTotal.Text = totalAmount.ToString("0.00");
                    f.txtDiscount.Text = "0";
                    f.txtTotalAmount.Text = totalAmount.ToString("0.00");

                    f.dgvReceipt.Rows.Clear();

                    f.dgvReceipt.Rows.Add(
                        1,
                        reader["TypeName"].ToString(),
                        nights,
                        pricePerNight.ToString("0.00"),
                        "0",
                        totalAmount.ToString("0.00")
                    );
                    f.AdjustGridHeight();

                    f.ShowDialog();
                }

                reader.Close();
            }
        }
        private void AddHeaderCell(PdfPTable table, string text)
        {
            PdfFont font = FontFactory.GetFont(
                FontFactory.HELVETICA_BOLD,
                11,
                BaseColor.WHITE);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));

            cell.BackgroundColor = new BaseColor(52, 73, 94);
            cell.HorizontalAlignment = Element.ALIGN_CENTER;
            cell.Padding = 8;

            table.AddCell(cell);
        }

        private void AddBodyCell(PdfPTable table, string text)
        {
            PdfFont font = FontFactory.GetFont(
                FontFactory.HELVETICA,
                10,
                BaseColor.BLACK);

            PdfPCell cell = new PdfPCell(new Phrase(text, font));

            cell.Padding = 7;
            cell.HorizontalAlignment = Element.ALIGN_CENTER;

            table.AddCell(cell);
        }

        private void AddCell(PdfPTable table, string text, bool isHeader)
        {
            PdfFont font;

            if (isHeader)
            {
                font = FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD,
                    10,
                    BaseColor.BLACK);
            }
            else
            {
                font = FontFactory.GetFont(
                    FontFactory.HELVETICA,
                    10,
                    BaseColor.BLACK);
            }

            PdfPCell cell = new PdfPCell(new Phrase(text, font));

            cell.Padding = 8;

            if (isHeader)
            {
                cell.BackgroundColor =
                    new BaseColor(230, 230, 230);
            }

            table.AddCell(cell);
        }

        private void AddTotalCell(PdfPTable table, string text)
        {
            PdfFont font = FontFactory.GetFont(
                FontFactory.HELVETICA_BOLD,
                11);

            PdfPCell cell = new PdfPCell(
                new Phrase(text, font));

            cell.Padding = 8;
            cell.Border = PdfRectangle.NO_BORDER;

            table.AddCell(cell);
        }

        private void AddTotalValueCell(PdfPTable table, string text)
        {
            PdfFont font = FontFactory.GetFont(
                FontFactory.HELVETICA,
                11);

            PdfPCell cell = new PdfPCell(
                new Phrase(text, font));

            cell.Padding = 8;
            cell.HorizontalAlignment = Element.ALIGN_RIGHT;
            cell.Border = PdfRectangle.NO_BORDER;

            table.AddCell(cell);
        }

        private void ExportInvoicePDF(
    string invoiceNo,
    string customerName,
    string roomNumber,
    string checkIn,
    string checkOut,
    decimal totalAmount)
        {
            try
            {
                string folder = @"C:\HotelInvoices";

                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }

                string filePath = Path.Combine(folder, invoiceNo + ".pdf");

                Document doc = new Document(PageSize.A4, 40f, 40f, 40f, 40f);

                PdfWriter.GetInstance(doc,
                    new FileStream(filePath, FileMode.Create));

                doc.Open();

                
                PdfFont titleFont = FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD, 24, BaseColor.DARK_GRAY);

                PdfFont headerFont = FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD, 12, BaseColor.WHITE);

                PdfFont normalFont = FontFactory.GetFont(
                    FontFactory.HELVETICA, 11, BaseColor.BLACK);

                PdfFont boldFont = FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD, 11, BaseColor.BLACK);

                PdfFont totalFont = FontFactory.GetFont(
                    FontFactory.HELVETICA_BOLD, 14, BaseColor.BLACK);

             
                Paragraph hotelTitle = new Paragraph(
                    "LUXURY HOTEL\n",
                    titleFont);

                hotelTitle.Alignment = Element.ALIGN_CENTER;

                doc.Add(hotelTitle);

                Paragraph address = new Paragraph(
                    "Phnom Penh, Cambodia\nPhone: +855 12 345 678\n\n",
                    normalFont);

                address.Alignment = Element.ALIGN_CENTER;

                doc.Add(address);

               
                PdfPTable invoiceTable = new PdfPTable(2);
                invoiceTable.WidthPercentage = 100;
                invoiceTable.SetWidths(new float[] { 50f, 50f });

                PdfPCell leftCell = new PdfPCell();
                leftCell.Border = PdfRectangle.NO_BORDER;

                leftCell.AddElement(new Paragraph(
                    "Invoice No: " + invoiceNo, boldFont));

                leftCell.AddElement(new Paragraph(
                    "Invoice Date: " + DateTime.Now.ToString("yyyy-MM-dd"),
                    normalFont));

                PdfPCell rightCell = new PdfPCell();
                rightCell.Border = PdfRectangle.NO_BORDER;
                rightCell.HorizontalAlignment = Element.ALIGN_RIGHT;

                rightCell.AddElement(new Paragraph(
                    "PAYMENT RECEIPT",
                    boldFont));

                invoiceTable.AddCell(leftCell);
                invoiceTable.AddCell(rightCell);

                doc.Add(invoiceTable);

                doc.Add(new Paragraph("\n"));

          
                PdfPTable customerTable = new PdfPTable(2);
                customerTable.WidthPercentage = 100;
                customerTable.SpacingAfter = 20f;

                customerTable.SetWidths(new float[] { 30f, 70f });

                AddCell(customerTable, "Customer Name", true);
                AddCell(customerTable, customerName, false);

                AddCell(customerTable, "Room Number", true);
                AddCell(customerTable, roomNumber, false);

                AddCell(customerTable, "Check In", true);
                AddCell(customerTable, checkIn, false);

                AddCell(customerTable, "Check Out", true);
                AddCell(customerTable, checkOut, false);

                doc.Add(customerTable);

                
                PdfPTable table = new PdfPTable(4);

                table.WidthPercentage = 100;

                table.SetWidths(new float[] { 40f, 20f, 20f, 20f });

                
                AddHeaderCell(table, "Description");
                AddHeaderCell(table, "Days");
                AddHeaderCell(table, "Price");
                AddHeaderCell(table, "Total");

                
                int nights = 1;

                DateTime inDate = Convert.ToDateTime(checkIn);
                DateTime outDate = Convert.ToDateTime(checkOut);

                nights = (outDate - inDate).Days;

                if (nights <= 0)
                    nights = 1;

                decimal pricePerNight = totalAmount / nights;

                AddBodyCell(table, "Room Accommodation");
                AddBodyCell(table, nights.ToString());
                AddBodyCell(table, "$ " + pricePerNight.ToString("0.00"));
                AddBodyCell(table, "$ " + totalAmount.ToString("0.00"));

                doc.Add(table);

                doc.Add(new Paragraph("\n"));

                
                PdfPTable totalTable = new PdfPTable(2);

                totalTable.WidthPercentage = 40;
                totalTable.HorizontalAlignment = Element.ALIGN_RIGHT;

                AddTotalCell(totalTable, "Subtotal");
                AddTotalValueCell(totalTable,
                    "$ " + totalAmount.ToString("0.00"));

                AddTotalCell(totalTable, "Discount");
                AddTotalValueCell(totalTable, "$ 0.00");

                AddTotalCell(totalTable, "Grand Total");
                AddTotalValueCell(totalTable,
                    "$ " + totalAmount.ToString("0.00"));

                doc.Add(totalTable);

                doc.Add(new Paragraph("\n\n"));

                
                Paragraph footer = new Paragraph(
                    "Thank you for staying with us!\nWe hope to see you again.",
                    normalFont);

                footer.Alignment = Element.ALIGN_CENTER;

                doc.Add(footer);

                doc.Close();

                
                Process.Start(new ProcessStartInfo()
                {
                    FileName = filePath,
                    UseShellExecute = true
                });
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Error: " + ex.Message);
            }
        }

        private void btnPDF_Click(object sender, EventArgs e)
        {
            try
            {
                if (dgvPayment.CurrentRow == null)
                {
                    MessageBox.Show("Please select a payment first!");
                    return;
                }

                string invoiceNo =
                    dgvPayment.CurrentRow.Cells["PaymentID"]
                    .Value.ToString();

                string customerName =
                    dgvPayment.CurrentRow.Cells["CustomerName"]
                    .Value.ToString();

                string roomNumber =
                    dgvPayment.CurrentRow.Cells["RoomNumber"]
                    .Value.ToString();

                string checkIn =
                    DateTime.Now.ToString("yyyy-MM-dd");

                string checkOut =
                    DateTime.Now.ToString("yyyy-MM-dd");

                decimal totalAmount =
                    Convert.ToDecimal(
                        dgvPayment.CurrentRow.Cells["Amount"].Value);

                ExportInvoicePDF(
                    invoiceNo,
                    customerName,
                    roomNumber,
                    checkIn,
                    checkOut,
                    totalAmount
                );

                MessageBox.Show("PDF exported successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show("PDF Error: " + ex.Message);
            }
        }
    }

    public class ComboBoxItem
    {
        public string Text { get; set; }
        public string Value { get; set; }

        public ComboBoxItem(string text, string value)
        {
            Text = text;
            Value = value;
        }

        public override string ToString()
        {
            return Text;
        }
    }
}