using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;

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
            LoadRoomTypes();
            LoadReport(null, null);
        }

        private void LoadRoomTypes()
        {
            try
            {
                cmbRoomType.SelectedIndexChanged -= RoomType_SelectedIndexChanged;

                cmbRoomType.Items.Clear();
                cmbRoomType.Items.Add("All");

                DataTable dt = service.GetAllRoomTypes();
                foreach (DataRow row in dt.Rows)
                    cmbRoomType.Items.Add(row["TypeName"].ToString());

                cmbRoomType.SelectedIndex = 0;
                cmbRoomType.SelectedIndexChanged += RoomType_SelectedIndexChanged;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load room types: " + ex.Message,
                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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

        private void RoomType_SelectedIndexChanged(object sender, EventArgs e) { }

        private void label2_Click(object sender, EventArgs e) { }

        private void dgvCustomers_CellContentClick_1(object sender, DataGridViewCellEventArgs e) { }

        private void Customer_Paint(object sender, PaintEventArgs e) { }

        private void iconPictureBox5_Click(object sender, EventArgs e)


        {

        }


        private void iconExcel_Click(object sender, EventArgs e)
        {

        }

        private void iconPDF_Click(object sender, EventArgs e)
        {
            if (dgvCustomers.Rows.Count == 0)
            {
                MessageBox.Show("No data to export");
                return;
            }

            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "PDF File|*.pdf";
            sfd.FileName = $"CustomerReport_{DateTime.Now:yyyyMMdd_HHmmss}.pdf";

            if (sfd.ShowDialog() == DialogResult.OK)
            {
                try
                {

                    if (File.Exists(sfd.FileName))
                    {
                        File.Delete(sfd.FileName);
                    }


                    int visibleColumns = dgvCustomers.Columns
                        .Cast<DataGridViewColumn>()
                        .Count(c => c.Visible);

                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    using (PdfWriter writer = new PdfWriter(fs))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        Table table = new Table(visibleColumns);


                        foreach (DataGridViewColumn col in dgvCustomers.Columns)
                        {
                            if (col.Visible)
                            {
                                table.AddCell(col.HeaderText);
                            }
                        }


                        foreach (DataGridViewRow row in dgvCustomers.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.OwningColumn.Visible)
                                    {
                                        table.AddCell(cell.Value?.ToString() ?? "");
                                    }
                                }
                            }
                        }

                        document.Add(table);
                    }

                    MessageBox.Show("Exported to PDF successfully!");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ERROR:\n" + ex.Message);
                }
            }
        }

        private void cmbCustomerName_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}