using ScottPlot;
using ScottPlot.WinForms;
using System;
using System.Linq;
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

        private void LoadRevenueChart()
        {
            var plt = formsPlot1.Plot;
            plt.Clear();

            double[] revenue = { 2500, 1400, 3800, 3900, 4800, 3800, 4400 };
            double[] xs = Enumerable.Range(0, revenue.Length).Select(x => (double)x).ToArray();
            string[] days = { "Mon", "Tue", "Wed", "Thu", "Fri", "Sat", "Sun" };

            var line = plt.Add.Scatter(xs, revenue);
            line.LineWidth = 2;
            line.MarkerSize = 8;

            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xs, days);
            plt.Title("Weekly Revenue");
            plt.Axes.Left.Label.Text = "Revenue ($)";
            plt.Axes.Bottom.Label.Text = "Day";
            plt.Grid.IsVisible = true;

            formsPlot1.Refresh();
        }

        private void LoadPieChart()
        {
            var plt = formsPlot2.Plot;
            plt.Clear();

            double[] values = { 50, 30, 10, 10 };
            string[] labels = { "Available", "Occupied", "Cleaning", "Maintenance" };

            var pie = plt.Add.Pie(values);

            for (int i = 0; i < pie.Slices.Count; i++)
                pie.Slices[i].Label = $"{labels[i]} {values[i]}%";

            pie.ExplodeFraction = 0.05;
            pie.Slices[0].FillColor = Colors.Green;
            pie.Slices[1].FillColor = Colors.Blue;
            pie.Slices[2].FillColor = Colors.Orange;
            pie.Slices[3].FillColor = Colors.Red;

            plt.Title("Room Status Distribution");
            formsPlot2.Refresh();
        }

        private void label1_Click(object sender, EventArgs e) { }
        private void iconPictureBox1_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void DashboardControl_Load(object sender, EventArgs e) { }
        private void formsPlot1_Load(object sender, EventArgs e) { }
    }
}
