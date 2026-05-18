using Hotel_System.PrintForms;
using MySql.Data.MySqlClient;
using System;
using System.Windows.Forms;

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
            // Keep only the behavior settings, remove the structural settings
            dgvPayment.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayment.MultiSelect = false;
            dgvPayment.ReadOnly = true;

            // Load your data
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
                    WHERE b.Status = 'CheckOut' 
                    AND b.BookingID NOT IN (SELECT BookingID FROM payments WHERE PaymentStatus = 'Paid')";

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
            if (cmbCustomerName.SelectedItem == null) return;

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
                    if (days <= 0) days = 1;

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
                        SELECT co.CheckOutID 
                        FROM checkouts co
                        INNER JOIN checkins ci ON co.CheckInID = ci.CheckInID
                        INNER JOIN bookings b ON ci.BookingID = b.BookingID
                        WHERE b.BookingID = @BookingID AND b.Status = 'CheckOut'
                        LIMIT 1";

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
                        (InvoiceNo, CheckOutID, AmountPaid, PaymentMethod, PaymentStatus, BookingID) 
                        VALUES 
                        (@InvoiceNo, @CheckOutID, @Amount, @Method, 'Paid', @BookingID);
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
                LoadCustomers();
                MessageBox.Show("Payment Successful!");

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

            int paymentID = Convert.ToInt32(dgvPayment.CurrentRow.Cells[0].Value);
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
                        Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd")
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
                    f.txtInvoiceDate.Text = Convert.ToDateTime(reader["PaymentDate"]).ToString("yyyy-MM-dd");

                 
                    DateTime checkIn = Convert.ToDateTime(reader["CheckInDate"]);
                    DateTime checkOut = Convert.ToDateTime(reader["CheckOutDate"]);
                    int nights = (checkOut - checkIn).Days;
                    if (nights <= 0) nights = 1;

                    decimal totalAmount = Convert.ToDecimal(reader["AmountPaid"]);
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

                    f.ShowDialog();
                }
                reader.Close();
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

        public override string ToString() => Text;
    }
}