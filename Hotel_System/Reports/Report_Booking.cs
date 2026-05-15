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

            // Default range: 1st of current month → today
            FromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
            ToDate.Value   = DateTime.Today;

            btnflitter.Click += (s, ev) => LoadData();
            LoadData();
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
                _currentData = _service.GetBookingReport(
                    FromDate.Value.Date,
                    ToDate.Value.Date);

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

            if (lbltotalbeforedis != null) lbltotalbeforedis.Text = totalAmount.ToString("N2");
            if (lbldiscount != null)       lbldiscount.Text       = amountPaid.ToString("N2");
            if (lbltotalAfterdis != null)  lbltotalAfterdis.Text  = (totalAmount - balanceDue).ToString("N2");
            if (lblGrandtotal != null)     lblGrandtotal.Text     = balanceDue.ToString("N2");
        }

        // Excel icon → open RDLC report preview
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
                new ReportPreviewForm(rdlcData, FromDate.Value.Date, ToDate.Value.Date).Show(this);
            }
            catch (Exception ex)
            {
                var msg = ex.Message;
                if (ex.InnerException != null) msg += "\n\nDetail: " + ex.InnerException.Message;
                MessageBox.Show("Cannot open report: " + msg,
                    "Report Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Maps _currentData columns to the field names declared in BookingReport.rdlc
        private static DataTable BuildRdlcTable(DataTable source)
        {
            var dt = new DataTable();
            dt.Columns.Add("CustomerName");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("RoomType");
            dt.Columns.Add("CheckInDate");
            dt.Columns.Add("CheckoutDate");
            dt.Columns.Add("TotalAmout");   // matches the typo in the RDLC
            dt.Columns.Add("BookingID");
            dt.Columns.Add("Room");
            dt.Columns.Add("Note");
            dt.Columns.Add("Status");

            foreach (DataRow src in source.Rows)
            {
                dt.Rows.Add(
                    src["customer_name"]?.ToString() ?? "",
                    src["phone_number"]?.ToString()  ?? "",
                    src["room_type"]?.ToString()     ?? "",
                    src["check-in"]?.ToString()      ?? "",
                    src["check-out"]?.ToString()     ?? "",
                    src["TotalAmount"] == DBNull.Value ? "0" : src["TotalAmount"].ToString(),
                    "",   // BookingID — not in SP output
                    "",   // Room      — not in SP output
                    "",   // Note
                    ""    // Status
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
