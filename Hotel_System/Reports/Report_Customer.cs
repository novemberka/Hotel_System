using System;
using System.Data;
using System.Windows.Forms;
using System.IO;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class Report_Customer : UserControl
    {
        private readonly Services.CustomerService service;

        public Report_Customer()
        {
            InitializeComponent();
            UiTheme.ApplyPageDesign(this);
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
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName))
                    {
                        cmbRoomType.Items.Add(typeName);
                    }
                }

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
                string fullName = txtFullName.Text.Trim();
                string roomType = cmbRoomType.SelectedItem?.ToString() == "All"
                                  ? "" : cmbRoomType.SelectedItem?.ToString() ?? "";

                DataTable dt = service.GetCustomerReport(from, to, fullName, roomType, "");

                dgvCustomers.DataSource = null;
                dgvCustomers.DataSource = dt;

                BindColumn(dt, "CustomerID");
                BindColumn(dt, "FullName");
                BindColumn(dt, "Gender");
                BindColumn(dt, "PhoneNumber");
                BindColumn(dt, "Email");
                BindColumn(dt, "Address");

                if (dgvCustomers.Columns["Column6"] is DataGridViewColumn hiddenColumn)
                {
                    hiddenColumn.Visible = false;
                }
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

        private void BindColumn(DataTable table, string columnName)
        {
            if (table.Columns.Contains(columnName) &&
                dgvCustomers.Columns[columnName] is DataGridViewColumn gridColumn)
            {
                gridColumn.DataPropertyName = columnName;
            }
        }

        private void RoomType_SelectedIndexChanged(object? sender, EventArgs e) { }

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

                    if (visibleColumns == 0)
                    {
                        MessageBox.Show("No visible columns to export");
                        return;
                    }

                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    using (PdfWriter writer = new PdfWriter(fs))
                    using (PdfDocument pdf = new PdfDocument(writer))
                    using (Document document = new Document(pdf))
                    {
                        Table table = new Table(visibleColumns);

                        // ✅ Header
                        foreach (DataGridViewColumn col in dgvCustomers.Columns)
                        {
                            if (col.Visible)
                            {
                                table.AddCell(col.HeaderText);
                            }
                        }

                        // ✅ Data
                        foreach (DataGridViewRow row in dgvCustomers.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                foreach (DataGridViewCell cell in row.Cells)
                                {
                                    if (cell.OwningColumn?.Visible == true)
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
                    MessageBox.Show("Export failed:\n" + ex.Message);
                }
            }
        }
    }
}
