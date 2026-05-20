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
                if (_grid != null)
                {
                    // 1. Unbind the grid completely to clear cache
                    _grid.DataSource = null;
                }

                string roomType = RoomType.SelectedItem?.ToString() ?? "";
                string customerName = txtSearchCustomer.Text.Trim();

                // 2. Fetch fresh database info
                _currentData = _service.GetBookingReport(
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    roomType,
                    customerName);

                if (_grid != null)
                {
                    _grid.AutoGenerateColumns = false;
                    // 3. Bind the freshly generated data table
                    _grid.DataSource = _currentData;
                    _grid.Refresh();
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
            decimal totalAmount = 0;

            foreach (DataRow row in _currentData.Rows)
            {
                if (_currentData.Columns.Contains("TotalAmount") &&
                    row["TotalAmount"] != DBNull.Value)
                {
                    totalAmount += Convert.ToDecimal(row["TotalAmount"]);
                }
            }

            if (lbltotalbeforedis != null)
                lbltotalbeforedis.Text = "Total Amount: " + totalAmount.ToString("N2");

            if (lbldiscount != null)
                lbldiscount.Text = "Discount: 0.00";

            if (lbltotalAfterdis != null)
                lbltotalAfterdis.Text = "Net Total: " + totalAmount.ToString("N2");

            if (lblGrandtotal != null)
                lblGrandtotal.Text = "Grand Total: " + totalAmount.ToString("N2");
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
                    src["BookingID"]?.ToString() ?? "",
                    src["CustomerName"]?.ToString() ?? "",
                    src["PhoneNumber"]?.ToString() ?? "",
                    src["Room"]?.ToString() ?? "",
                    src["RoomType"]?.ToString() ?? "",
                    src["CheckIn"]?.ToString() ?? "",
                    src["CheckOut"]?.ToString() ?? "",
                    src["TotalAmount"]?.ToString() ?? "0",
                    src["Status"]?.ToString() ?? ""
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
