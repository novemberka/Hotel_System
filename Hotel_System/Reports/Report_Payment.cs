using Hotel_System.Reports;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Report_Payment : UserControl
    {
        private readonly PaymentService _service = new PaymentService();
        private DataTable _currentData = new DataTable();
        private DataGridView? _grid;

        public Report_Payment()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                _grid = FindGrid(Booking_list);
                FromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                ToDate.Value   = DateTime.Today;
                if (_grid != null) _grid.AutoGenerateColumns = false;
                btnflitter.Click += (_, __) => LoadData();
                iconPictureBox6.Click += iconPictureBox6_Click;
            };
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
                if (_grid != null) { _grid.DataSource = new DataTable(); _grid.Refresh(); }

                string roomType = RoomType.SelectedItem?.ToString() ?? "";
                _currentData = _service.GetPaymentReport(
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    roomType);

                if (_grid != null)
                {
                    _grid.AutoGenerateColumns = false;
                    _grid.DataSource = _currentData;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading report: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
                    "Payment Report",
                    rdlcData,
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    new[]
                    {
                        ("CustomerName", "Customer Name",  1.8, "Left"),
                        ("PhoneNumber",  "Phone",          1.2, "Center"),
                        ("RoomType",     "Room Type",      1.2, "Center"),
                        ("CheckIn",      "Check In",       1.5, "Center"),
                        ("CheckOut",     "Check Out",      1.5, "Center"),
                        ("TotalAmount",  "Total ($)",      1.3, "Right"),
                        ("AmountPaid",   "Amount Paid",    1.3, "Right"),
                        ("Payment",      "Payment Method", 1.2, "Center"),
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
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("CheckIn");
            dt.Columns.Add("CheckOut");
            dt.Columns.Add("TotalAmount");
            dt.Columns.Add("AmountPaid");
            dt.Columns.Add("Payment");

            foreach (DataRow src in source.Rows)
            {
                dt.Rows.Add(
                    source.Columns.Contains("customer_name") ? src["customer_name"]?.ToString() ?? "" : "",
                    source.Columns.Contains("phone_number")  ? src["phone_number"]?.ToString()  ?? "" : "",
                    source.Columns.Contains("room_type")     ? src["room_type"]?.ToString()     ?? "" : "",
                    source.Columns.Contains("check-in")      ? src["check-in"]?.ToString()      ?? "" : "",
                    source.Columns.Contains("check-out")     ? src["check-out"]?.ToString()     ?? "" : "",
                    source.Columns.Contains("total_amount") && src["total_amount"] != DBNull.Value ? src["total_amount"]!.ToString() : "0",
                    source.Columns.Contains("AmountPaid")   && src["AmountPaid"]   != DBNull.Value ? src["AmountPaid"]!.ToString()   : "0",
                    source.Columns.Contains("payment")       ? src["payment"]?.ToString()       ?? "" : ""
                );
            }
            return dt;
        }

        private void Report_Payment_Load(object sender, EventArgs e) { }
        private void Report_Summary_Paint(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
    }
}
