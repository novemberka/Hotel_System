using Hotel_System.Services;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Report_Booking : UserControl
    {
        private ReportViewer reportViewer1;

        public Report_Booking()
        {
            InitializeComponent();
        }

        private void guna2Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void TimeWalkInCheckOut_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void FromDate_ValueChanged(object sender, EventArgs e)
        {

        }

        private void Report_Booking_Load(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Booking_Report_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void Booking_Roport_Enter(object sender, EventArgs e)
        {

        }

        private void Booking_Roport_Enter_1(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void guna2ShadowPanel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void Booking_Report_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label12_Click(object sender, EventArgs e)
        {

        }
        private void iconPictureBox6_Click(object sender, EventArgs e)
        {
            reportViewer1 = new ReportViewer();

            reportViewer1.Dock = DockStyle.Fill;

            this.Controls.Add(reportViewer1);

            LoadReport();
        }

        private void LoadReport()
        {
            BookingService service = new BookingService();

            DataTable dt = service.GetWalkInReport(
                FromDate.Value,
                ToDate.Value
            );

            reportViewer1.LocalReport.DataSources.Clear();

            reportViewer1.LocalReport.ReportPath =
                @"Reports\BookingReport.rdlc";

            ReportDataSource rds =
                new ReportDataSource("WalkInDataSet", dt);

            reportViewer1.LocalReport.DataSources.Add(rds);

            reportViewer1.RefreshReport();
        }

    }
}
