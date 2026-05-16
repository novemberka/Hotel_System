using Hotel_System.Reports;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Report_CheckOut : UserControl
    {
        private readonly CheckoutService _service = new CheckoutService();
        private DataTable _currentData = new DataTable();
        private DataGridView? _grid;

        public Report_CheckOut()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                _grid = FindGrid(Booking_list);
                FromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                ToDate.Value   = DateTime.Today;
                if (_grid != null) _grid.AutoGenerateColumns = false;
                iconPictureBox6.Click += iconPictureBox6_Click;
            };
        }

        private void btnflitter_Click(object sender, EventArgs e) => LoadData();

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
                _currentData = _service.GetCheckOutReport(
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    roomType);

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

        private static decimal SafeSum(DataTable dt, string col)
        {
            if (!dt.Columns.Contains(col)) return 0;
            decimal total = 0;
            foreach (DataRow r in dt.Rows)
                total += r[col] == DBNull.Value ? 0 : Convert.ToDecimal(r[col]);
            return total;
        }

        private void UpdateSummary()
        {
            decimal subTotal = SafeSum(_currentData, "sub_total");
            decimal discount = SafeSum(_currentData, "discount");
            decimal totalPrice = subTotal - discount;

            if (lbltotalbeforedis != null) lbltotalbeforedis.Text = "Totel Before Discount:  " + subTotal.ToString("N2");
            if (lbldiscount != null)       lbldiscount.Text       = "Discount:  "              + discount.ToString("N2");
            if (lbltotalAfterdis != null)  lbltotalAfterdis.Text  = "Totel After Discount:  "  + totalPrice.ToString("N2");
            if (lblGrandtotal != null)     lblGrandtotal.Text     = "Grand Total:  "           + totalPrice.ToString("N2");
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
                    "Check-In / Check-Out Report",
                    rdlcData,
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    new[]
                    {
                        ("CustomerName", "Customer Name", 1.7, "Left"),
                        ("PhoneNumber",  "Phone",         1.2, "Center"),
                        ("Room",         "Room",          1.2, "Center"),
                        ("RoomType",     "Room Type",     1.2, "Center"),
                        ("RoomNumber",   "Room No.",      1.0, "Center"),
                        ("CheckIn",      "Check In",      1.5, "Center"),
                        ("CheckOut",     "Check Out",     1.5, "Center"),
                        ("SubTotal",     "Sub Total",     1.1, "Right"),
                        ("Discount",     "Discount",      1.0, "Right"),
                        ("TotalPrice",   "Total ($)",     1.1, "Right"),
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
            dt.Columns.Add("Room");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("RoomNumber");
            dt.Columns.Add("CheckIn");
            dt.Columns.Add("CheckOut");
            dt.Columns.Add("SubTotal");
            dt.Columns.Add("Discount");
            dt.Columns.Add("TotalPrice");

            foreach (DataRow src in source.Rows)
            {
                decimal sub  = source.Columns.Contains("sub_total") && src["sub_total"] != DBNull.Value
                               ? Convert.ToDecimal(src["sub_total"]) : 0;
                decimal disc = source.Columns.Contains("discount")  && src["discount"]  != DBNull.Value
                               ? Convert.ToDecimal(src["discount"])  : 0;

                dt.Rows.Add(
                    src["customer_name"]?.ToString() ?? "",
                    src["phone_number"]?.ToString()  ?? "",
                    source.Columns.Contains("room")        ? src["room"]?.ToString()        ?? "" : "",
                    src["room_type"]?.ToString()     ?? "",
                    src["room_number"]?.ToString()   ?? "",
                    src["check-in"]?.ToString()      ?? "",
                    src["check-out"]?.ToString()     ?? "",
                    sub.ToString("N2"),
                    disc.ToString("N2"),
                    (sub - disc).ToString("N2")
                );
            }
            return dt;
        }
    }
}
