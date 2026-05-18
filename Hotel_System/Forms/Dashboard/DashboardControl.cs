using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using ScottPlot;
using ScottPlot.WinForms;
using System.Windows.Forms;
using MySql.Data.MySqlClient;

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

            // 1. Initialize revenue array for 7 days (Index 0 = Sun, 1 = Mon ... 6 = Sat)
            // However, we usually display Mon-Sun. Let's handle the mapping.
            double[] weeklyRevenue = new double[7];
            string[] days = { "Sun", "Mon", "Tue", "Wed", "Thu", "Fri", "Sat" };

            string connectionString = "server=localhost;database=hoteldb;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query: Get total amount paid grouped by day for the CURRENT WEEK
                    string query = @"
                SELECT DAYOFWEEK(PaymentDate) as DayNum, SUM(AmountPaid) as Total
                FROM payments
                WHERE YEARWEEK(PaymentDate, 1) = YEARWEEK(CURDATE(), 1)
                GROUP BY DAYOFWEEK(PaymentDate)";

                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        // MySQL DAYOFWEEK: 1 = Sun, 2 = Mon, ..., 7 = Sat
                        int dayIndex = Convert.ToInt32(reader["DayNum"]) - 1;
                        weeklyRevenue[dayIndex] = Convert.ToDouble(reader["Total"]);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine("Revenue Chart Error: " + ex.Message);
                }
            }

            // 2. Prepare X-axis positions
            double[] xs = Enumerable.Range(0, 7).Select(x => (double)x).ToArray();

            // 3. Add to Plot
            var line = plt.Add.Scatter(xs, weeklyRevenue);
            line.LineWidth = 3;
            line.MarkerSize = 10;
            line.Color = Colors.RoyalBlue;

            // 4. Set X-axis labels to the 'days' array
            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xs, days);

            // Styling
            plt.Title("Live Weekly Revenue ($)");
            plt.Axes.Left.Label.Text = "Total Earned";
            plt.Axes.Bottom.Label.Text = "Day of Week";
            plt.Grid.IsVisible = true;

            // Optional: Fill area under the line
            line.FillY = true;
            line.FillYColor = Colors.RoyalBlue.WithAlpha(0.2);

            formsPlot1.Refresh();
        }

        // 🥧 PIE CHART (ScottPlot 5 SAFE VERSION)
        private void LoadPieChart()
        {
            var plt = formsPlot2.Plot;
            plt.Clear();

            // 1. Fetch real data from database
            double available = 0, occupied = 0, reserved = 0;
            string connectionString = "server=localhost;database=hoteldb;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();
                    // Query to count rooms grouped by status
                    string query = "SELECT Status, COUNT(*) as count FROM rooms GROUP BY Status";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    MySqlDataReader reader = cmd.ExecuteReader();

                    while (reader.Read())
                    {
                        string status = reader["Status"].ToString().ToLower();
                        int count = Convert.ToInt32(reader["count"]);

                        if (status == "available") available = count;
                        else if (status == "occupied" || status == "checkedin") occupied = count;
                        else if (status == "reserved" || status == "pending") reserved = count;
                    }
                }
                catch (Exception ex)
                {
                    // Fallback to zeros if DB fails
                    Console.WriteLine("Pie Chart Error: " + ex.Message);
                }
            }

            // 2. Prepare Data for ScottPlot
            double[] values = { available, occupied, reserved };
            string[] labels = { "Available", "Occupied", "Reserved" };

            // Avoid empty pie chart errors if all values are 0
            if (available == 0 && occupied == 0 && reserved == 0) { values = new double[] { 1 }; labels = new string[] { "No Data" }; }

            var pie = plt.Add.Pie(values);

            // 3. Styling
            for (int i = 0; i < pie.Slices.Count; i++)
            {
                // Only show label if the count is greater than 0
                if (values[i] > 0)
                    pie.Slices[i].Label = $"{labels[i]} ({values[i]})";

                // Match colors to status
                if (labels[i] == "Available") pie.Slices[i].FillColor = Colors.Green;
                else if (labels[i] == "Occupied") pie.Slices[i].FillColor = Colors.Red;
                else if (labels[i] == "Reserved") pie.Slices[i].FillColor = Colors.Orange;
            }

            pie.ExplodeFraction = 0.05;
            plt.Title("Live Room Status Distribution");

            // Transparent background to match dashboard UI if needed
            plt.FigureBackground.Color = Colors.Transparent;

            formsPlot2.Refresh();
        }
        private void FetchDashboardStats()
        {
            string connectionString = "server=localhost;database=hoteldb;uid=root;pwd=;";

            using (MySqlConnection conn = new MySqlConnection(connectionString))
            {
                try
                {
                    conn.Open();

                    // 1. Total Guests (All unique customers)
                    string qGuest = "SELECT COUNT(*) FROM customers";
                    MySqlCommand cmdGuest = new MySqlCommand(qGuest, conn);
                    totalGuests.Text = cmdGuest.ExecuteScalar().ToString();

                    // 2. Total Rooms (All rooms in the system)
                    string qRooms = "SELECT COUNT(*) FROM rooms";
                    MySqlCommand cmdRooms = new MySqlCommand(qRooms, conn);
                    TotalRooms.Text = cmdRooms.ExecuteScalar().ToString();

                    // 3. Total Check-Ins (Active bookings currently checked in)
                    string qCheckIn = "SELECT COUNT(*) FROM checkins";
                    MySqlCommand cmdCheckIn = new MySqlCommand(qCheckIn, conn);
                    totalCheckIn.Text = cmdCheckIn.ExecuteScalar().ToString();

                    // 4. Total Check-Outs (Completed checkouts)
                    string qCheckOut = "SELECT COUNT(*) FROM checkouts";
                    MySqlCommand cmdCheckOut = new MySqlCommand(qCheckOut, conn);
                    totalCheckOut.Text = cmdCheckOut.ExecuteScalar().ToString();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error fetching stats: " + ex.Message);
                }
            }
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
            FetchDashboardStats();
            LoadCharts(); // Refresh charts as well
        }

        private void formsPlot1_Load(object sender, EventArgs e)
        {

        }

        private void TotalRooms_Click(object sender, EventArgs e)
        {

        }

        private void totalGuests_Click(object sender, EventArgs e)
        {

        }

        private void totalCheckOut_Click(object sender, EventArgs e)
        {

        }
    }
}
