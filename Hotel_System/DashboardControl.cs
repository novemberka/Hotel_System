using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ScottPlot;
using ScottPlot.WinForms;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class DashboardControl : UserControl
    {
        public DashboardControl()
        {
            InitializeComponent();
            LoadCharts();
        }
        private void LoadCharts()
        {
            LoadRevenueChart();
            LoadPieChart();
        }

        // 📈 LINE CHART
        private void LoadRevenueChart()
        {
            var plt = formsPlot1.Plot;
            plt.Clear();

            double[] revenue = { 2500, 1400, 3800, 3900, 4800, 3800, 4400 };
            double[] xs = Enumerable.Range(0, revenue.Length).Select(x => (double)x).ToArray();
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            // ✅ ScottPlot 5 requires X + Y
            var line = plt.Add.Scatter(xs, revenue);
            line.LineWidth = 2;
            line.MarkerSize = 8;

            // ✅ Set X labels
            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(
                xs, days
            );

            // Titles
            plt.Title("Weekly Revenue");
            plt.Axes.Left.Label.Text = "Revenue ($)";
            plt.Axes.Bottom.Label.Text = "Day";

            // ✅ FIX GRID (ScottPlot 5)
            plt.Grid.IsVisible = true;

            formsPlot1.Refresh();
        }

        // 🥧 PIE CHART (ScottPlot 5 SAFE VERSION)
        private void LoadPieChart()
        {
            var plt = formsPlot2.Plot;
            plt.Clear();

            double[] values = { 50, 30, 10, 10 };
            string[] labels = { "Available", "Occupied", "Cleaning", "Maintenance" };

            var pie = plt.Add.Pie(values);

            // ✅ SAFE way (no API issues)
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].Label = $"{labels[i]} {values[i]}%";
            }

            // Optional styling
            pie.ExplodeFraction = 0.05;

            // Colors (match your UI)
            pie.Slices[0].FillColor = Colors.Green;
            pie.Slices[1].FillColor = Colors.Blue;
            pie.Slices[2].FillColor = Colors.Orange;
            pie.Slices[3].FillColor = Colors.Red;

            plt.Title("Room Status Distribution");

            formsPlot2.Refresh();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void DashboardControl_Load(object sender, EventArgs e)
        {

        }
    }
}
