using Hotel_System.Reports;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Reportroom : UserControl
    {
        private readonly RoomService _service = new RoomService();
        private DataTable _currentData = new DataTable();

        public Reportroom()
        {
            InitializeComponent();
            Load += (s, e) =>
            {
                // Fix DataPropertyName bindings to match the query column names
                RoomNumber.DataPropertyName = "RoomNumber";
                typeroom.DataPropertyName   = "TypeName";
                Floor.DataPropertyName      = "Floor";
                price.DataPropertyName      = "PricePerNight";
                Status.DataPropertyName     = "Status";

                dgvCustomers.AutoGenerateColumns = false;

                btnflitter.Click      += (_, __) => LoadData();
                iconPictureBox6.Click += iconPictureBox6_Click;
            };
        }

        private void LoadData()
        {
            try
            {
                dgvCustomers.DataSource = new DataTable();
                dgvCustomers.Refresh();

                string roomNum  = txtRoomNumber.Text.Trim();
                string floor    = guna2TextBox2.Text.Trim();
                string roomType = RoomType.SelectedItem?.ToString() ?? "";

                _currentData = _service.GetRoomReport(roomNum, floor, roomType);

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = _currentData;
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
                    "Room Report",
                    rdlcData,
                    DateTime.Today,
                    DateTime.Today,
                    new[]
                    {
                        ("RoomNumber",    "Room Number",    1.5, "Center"),
                        ("TypeName",      "Room Type",      1.5, "Center"),
                        ("Floor",         "Floor",          1.2, "Center"),
                        ("PricePerNight", "Price/Night",    1.3, "Right"),
                        ("Status",        "Status",         1.5, "Center"),
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
            dt.Columns.Add("RoomNumber");
            dt.Columns.Add("TypeName");
            dt.Columns.Add("Floor");
            dt.Columns.Add("PricePerNight");
            dt.Columns.Add("Status");

            foreach (DataRow src in source.Rows)
            {
                dt.Rows.Add(
                    src["RoomNumber"]?.ToString()    ?? "",
                    src["TypeName"]?.ToString()      ?? "",
                    src["Floor"]?.ToString()         ?? "",
                    src["PricePerNight"] == DBNull.Value ? "0" : src["PricePerNight"].ToString(),
                    src["Status"]?.ToString()        ?? ""
                );
            }
            return dt;
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void SelectDateRoport_Paint(object sender, EventArgs e) { }
        private void lblRoomNumber_Click(object sender, EventArgs e) { }
        private void Reportroom_Load(object sender, EventArgs e) { }
    }
}
