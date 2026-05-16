using Hotel_System.Reports;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Report_Booking : UserControl
    {
        private readonly BookingService _service = new BookingService();
        private DataTable _currentData = new DataTable();
        private DataGridView? _grid;

        public Report_Booking()
        {
            InitializeComponent();
        }

        private void Report_Booking_Load(object sender, EventArgs e)
        {
            _grid = FindGrid(Booking_list);

            FromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            ToDate.Value   = DateTime.Today;

            if (_grid != null) _grid.AutoGenerateColumns = false;

            // Load room types from DB
            try
            {
                var rt = new Repositories.BookingRepository();
                // reuse CustomerRepository's GetAllRoomTypes which queries roomtypes table
                var repo = new Repositories.CustomerRepository();
                var types = repo.GetAllRoomTypes();
                RoomType.Items.Clear();
                RoomType.Items.Add("All");
                foreach (System.Data.DataRow row in types.Rows)
                    RoomType.Items.Add(row["TypeName"].ToString());
                RoomType.SelectedIndex = 0;
            }
            catch { }

            btnflitter.Click += (s, ev) => LoadData();
        }

        private DataGridView? FindGrid(Control parent)
        {
            foreach (Control c in parent.Controls)
            {
                if (c is DataGridView dg) return dg;
                var found = FindGrid(c);
                if (found != null) return found;
            }
            return null;
        }

        private void LoadData()
        {
            try
            {
                _currentData = new DataTable();
                if (_grid != null) { _grid.DataSource = _currentData; _grid.Refresh(); }

                string roomType     = RoomType.SelectedItem?.ToString() ?? "";
                string customerName = txtSearchCustomer.Text.Trim();

                _currentData = _service.GetBookingReport(
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    roomType,
                    customerName);

                if (_grid != null)
                {
                    _grid.AutoGenerateColumns = false;
                    _grid.DataSource = _currentData;
                }

                UpdateSummary();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummary()
        {
            decimal totalAmount = 0, amountPaid = 0, balanceDue = 0;

            foreach (DataRow row in _currentData.Rows)
            {
                totalAmount += row["TotalAmount"] == DBNull.Value ? 0 : Convert.ToDecimal(row["TotalAmount"]);
                amountPaid  += row["AmountPaid"]  == DBNull.Value ? 0 : Convert.ToDecimal(row["AmountPaid"]);
                balanceDue  += row["BalanceDue"]  == DBNull.Value ? 0 : Convert.ToDecimal(row["BalanceDue"]);
            }

            if (lbltotalbeforedis != null) lbltotalbeforedis.Text = "Totel Before Discount:  " + totalAmount.ToString("N2");
            if (lbldiscount != null)       lbldiscount.Text       = "Discount:  "              + amountPaid.ToString("N2");
            if (lbltotalAfterdis != null)  lbltotalAfterdis.Text  = "Totel After Discount:  "  + (totalAmount - balanceDue).ToString("N2");
            if (lblGrandtotal != null)     lblGrandtotal.Text     = "Grand Total:  "           + balanceDue.ToString("N2");
        }

        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            if (_currentData.Rows.Count == 0)
            {
                MessageBox.Show("No data to display. Please click Filter first.",
                    "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            try
            {
                var rdlcData = BuildRdlcTable(_currentData);
                new ReportPreviewForm(
                    "Booking Report",
                    rdlcData,
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    new[]
                    {
                        ("BookingID",    "Booking ID",    1.0, "Center"),
                        ("CustomerName", "Customer Name", 1.8, "Left"),
                        ("PhoneNumber",  "Phone",         1.3, "Center"),
                        ("Room",         "Room",          1.0, "Center"),
                        ("RoomType",     "Room Type",     1.3, "Center"),
                        ("CheckIn",      "Check In",      1.5, "Center"),
                        ("CheckOut",     "Check Out",     1.5, "Center"),
                        ("TotalAmount",  "Total ($)",     1.2, "Right"),
                        ("Status",       "Status",        1.2, "Center"),
                    }
                ).Show(this);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null) msg += "\n\nDetail: " + ex.InnerException.Message;
                MessageBox.Show("Cannot open report: " + msg,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataTable BuildRdlcTable(DataTable source)
        {
            var dt = new DataTable();
            dt.Columns.Add("BookingID");
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("Room");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("CheckIn");
            dt.Columns.Add("CheckOut");
            dt.Columns.Add("TotalAmount");
            dt.Columns.Add("Status");

            foreach (DataRow src in source.Rows)
            {
                dt.Rows.Add(
                    source.Columns.Contains("booking_id")    ? src["booking_id"]?.ToString()    ?? "" : "",
                    source.Columns.Contains("customer_name") ? src["customer_name"]?.ToString() ?? "" : "",
                    source.Columns.Contains("phone_number")  ? src["phone_number"]?.ToString()  ?? "" : "",
                    source.Columns.Contains("room")          ? src["room"]?.ToString()          ?? "" : "",
                    source.Columns.Contains("room_type")     ? src["room_type"]?.ToString()     ?? "" : "",
                    source.Columns.Contains("check-in")      ? src["check-in"]?.ToString()      ?? "" : "",
                    source.Columns.Contains("check-out")     ? src["check-out"]?.ToString()     ?? "" : "",
                    source.Columns.Contains("TotalAmount") && src["TotalAmount"] != DBNull.Value ? src["TotalAmount"].ToString() : "0",
                    source.Columns.Contains("status")        ? src["status"]?.ToString()        ?? "" : ""
                );
            }

            return dt;
        }

        private void guna2Panel1_Paint(object sender, EventArgs e) { }
        private void guna2ShadowPanel1_Paint(object sender, EventArgs e) { }
        private void guna2ShadowPanel1_Paint_1(object sender, EventArgs e) { }
        private void TimeWalkInCheckOut_ValueChanged(object sender, EventArgs e) { }
        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e) { }
        private void FromDate_ValueChanged(object sender, EventArgs e) { }
        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Booking_Report_CellContentClick(object sender, DataGridViewCellEventArgs e) { }
        private void Booking_Roport_Enter(object sender, EventArgs e) { }
        private void Booking_Roport_Enter_1(object sender, EventArgs e) { }
        private void label9_Click(object sender, EventArgs e) { }
        private void Booking_Report_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }
        private void label12_Click(object sender, EventArgs e) { }
    }
}
