using Hotel_System.Reports;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Report_Customer : UserControl
    {
        private readonly Services.CustomerService service;
        private DataTable _currentData = new DataTable();

        public Report_Customer()
        {
            InitializeComponent();
            service = new Services.CustomerService();

            Load += (s, e) =>
            {
                FromDate.Value = new DateTime(DateTime.Today.Year, DateTime.Today.Month, 1);
                ToDate.Value   = DateTime.Today;
                dgvCustomers.AutoGenerateColumns = false;
                btnflitter.Click += (_, __) => LoadReport(FromDate.Value.Date, ToDate.Value.Date);
                iconPictureBox6.Click += iconPictureBox6_Click;
            };
        }

        private void ReportCustomer_Load(object sender, EventArgs e) { }

        private void LoadReport(DateTime? from, DateTime? to)
        {
            try
            {
                dgvCustomers.DataSource = new DataTable();
                dgvCustomers.Refresh();

                string fullName = cmbCustomerName.Text.Trim() == "All" ? "" : cmbCustomerName.Text.Trim();
                string roomType = cmbRoomType.SelectedItem?.ToString() == "All"
                                  ? "" : cmbRoomType.SelectedItem?.ToString() ?? "";

                _currentData = service.GetCustomerReport(from, to, fullName, roomType, "");

                dgvCustomers.DataSource = _currentData;

                // Fix DataPropertyName to match actual query column names
                if (_currentData.Columns.Contains("CustomerID") && dgvCustomers.Columns.Contains("CustomerID"))
                    dgvCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
                if (_currentData.Columns.Contains("FullName") && dgvCustomers.Columns.Contains("Full_name"))
                    dgvCustomers.Columns["Full_name"].DataPropertyName = "FullName";
                if (_currentData.Columns.Contains("Gender") && dgvCustomers.Columns.Contains("gender"))
                    dgvCustomers.Columns["gender"].DataPropertyName = "Gender";
                if (_currentData.Columns.Contains("PhoneNumber") && dgvCustomers.Columns.Contains("PhoneNumber"))
                    dgvCustomers.Columns["PhoneNumber"].DataPropertyName = "PhoneNumber";
                if (_currentData.Columns.Contains("Email") && dgvCustomers.Columns.Contains("email"))
                    dgvCustomers.Columns["email"].DataPropertyName = "Email";
                if (_currentData.Columns.Contains("IDCardNumber") && dgvCustomers.Columns.Contains("idcard_number"))
                    dgvCustomers.Columns["idcard_number"].DataPropertyName = "IDCardNumber";
                if (_currentData.Columns.Contains("Address") && dgvCustomers.Columns.Contains("address"))
                    dgvCustomers.Columns["address"].DataPropertyName = "Address";
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load report: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            LoadReport(FromDate.Value.Date, ToDate.Value.Date);
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
                    "Customer Report",
                    rdlcData,
                    FromDate.Value.Date,
                    ToDate.Value.Date,
                    new[]
                    {
                        ("CustomerID",   "Customer ID",  1.2, "Center"),
                        ("FullName",     "Full Name",    1.8, "Left"),
                        ("Gender",       "Gender",       0.9, "Center"),
                        ("PhoneNumber",  "Phone",        1.4, "Center"),
                        ("Email",        "Email",        2.2, "Left"),
                        ("IDCardNumber", "ID Card",      1.5, "Center"),
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
            dt.Columns.Add("CustomerID");
            dt.Columns.Add("FullName");
            dt.Columns.Add("Gender");
            dt.Columns.Add("PhoneNumber");
            dt.Columns.Add("Email");
            dt.Columns.Add("IDCardNumber");

            foreach (DataRow src in source.Rows)
            {
                dt.Rows.Add(
                    src.Table.Columns.Contains("CustomerID")   ? src["CustomerID"]?.ToString()   ?? "" : "",
                    src.Table.Columns.Contains("FullName")     ? src["FullName"]?.ToString()     ?? "" : "",
                    src.Table.Columns.Contains("Gender")       ? src["Gender"]?.ToString()       ?? "" : "",
                    src.Table.Columns.Contains("PhoneNumber")  ? src["PhoneNumber"]?.ToString()  ?? "" : "",
                    src.Table.Columns.Contains("Email")        ? src["Email"]?.ToString()        ?? "" : "",
                    src.Table.Columns.Contains("IDCardNumber") ? src["IDCardNumber"]?.ToString() ?? "" : ""
                );
            }
            return dt;
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e) { }
    }
}
