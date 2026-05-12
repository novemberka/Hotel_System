using System;
using System.Data;
using System.Windows.Forms;
using System.IO;


namespace Hotel_System
{
    public partial class Report_Customer : UserControl
    {
        private readonly Services.CustomerService service;

        public Report_Customer()
        {
            InitializeComponent();
            service = new Services.CustomerService();
        }

        private void ReportCustomer_Load(object sender, EventArgs e)
        {

        }


        private void LoadReport(DateTime? from, DateTime? to)
        {
            try
            {
                string fullName = cmbCustomerName.Text.Trim();
                string roomType = cmbRoomType.SelectedItem?.ToString() == "All"
                                  ? "" : cmbRoomType.SelectedItem?.ToString() ?? "";

                DataTable dt = service.GetCustomerReport(from, to, fullName, roomType, "");

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = dt;

                if (dt.Columns.Contains("CustomerID") && dgvCustomers.Columns.Contains("CustomerID"))
                    dgvCustomers.Columns["CustomerID"].DataPropertyName = "CustomerID";
                if (dt.Columns.Contains("FullName") && dgvCustomers.Columns.Contains("FullName"))
                    dgvCustomers.Columns["FullName"].DataPropertyName = "FullName";
                if (dt.Columns.Contains("Gender") && dgvCustomers.Columns.Contains("Gender"))
                    dgvCustomers.Columns["Gender"].DataPropertyName = "Gender";
                if (dt.Columns.Contains("PhoneNumber") && dgvCustomers.Columns.Contains("PhoneNumber"))
                    dgvCustomers.Columns["PhoneNumber"].DataPropertyName = "PhoneNumber";
                if (dt.Columns.Contains("Email") && dgvCustomers.Columns.Contains("Email"))
                    dgvCustomers.Columns["Email"].DataPropertyName = "Email";
                if (dt.Columns.Contains("Address") && dgvCustomers.Columns.Contains("Address"))
                    dgvCustomers.Columns["Address"].DataPropertyName = "Address";
                if (dgvCustomers.Columns.Contains("Column6"))
                    dgvCustomers.Columns["Column6"].Visible = false;
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

 

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}