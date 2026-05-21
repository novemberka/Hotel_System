using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Hotel_System.Properties.Config;
using Hotel_System.UI;
using Microsoft.Data.SqlClient;

namespace Hotel_System
{
    public partial class DashboardControl : UserControl
    {
        private DashboardStats stats = DashboardStats.Empty;
        private Label? roomsValueLabel;
        private Label? guestsValueLabel;
        private Label? checkInsValueLabel;
        private Label? checkOutsValueLabel;
        private Label? availableRoomsLabel;
        private Label? revenueSummaryLabel;
        private Label? roomStatusSummaryLabel;
        private Label? availableStatusLabel;
        private Label? occupiedStatusLabel;
        private Label? reservedStatusLabel;
        private DashboardDonutControl? roomsDonut;
        private DashboardDonutControl? guestsDonut;
        private DashboardDonutControl? checkInsDonut;

        public DashboardControl()
        {
            InitializeComponent();
            ApplyDashboardDesign();
            LoadDashboardStats();
            LoadCharts();
        }

        private void ApplyDashboardDesign()
        {
            SuspendLayout();
            BackColor = Color.FromArgb(242, 247, 253);
            Padding = new Padding(0);

            formsPlot1.Parent?.Controls.Remove(formsPlot1);
            formsPlot2.Parent?.Controls.Remove(formsPlot2);
            Controls.Clear();

            TableLayoutPanel root = new()
            {
                BackColor = Color.FromArgb(242, 247, 253),
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 4
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 172F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 198F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 122F));

            Guna2Panel overviewBanner = ResponsiveFormLayout.CreateBanner(
                "Hotel Operations Overview",
                "Track room inventory, active guests, revenue, and front-desk movement from one calm workspace.",
                "Today");
            overviewBanner.MinimumSize = new Size(0, 162);
            overviewBanner.Padding = new Padding(34, 30, 34, 30);
            root.Controls.Add(overviewBanner, 0, 0);

            TableLayoutPanel metricGrid = new()
            {
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 0, 18)
            };
            metricGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            metricGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            metricGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.34F));

            metricGrid.Controls.Add(CreateMetricCard(
                "Total Rooms",
                "Inventory count",
                out roomsValueLabel,
                out roomsDonut,
                Color.FromArgb(69, 125, 226),
                "available now"), 0, 0);

            metricGrid.Controls.Add(CreateMetricCard(
                "Guest Profiles",
                "Total customers",
                out guestsValueLabel,
                out guestsDonut,
                Color.FromArgb(28, 174, 123),
                "stored records"), 1, 0);

            metricGrid.Controls.Add(CreateMetricCard(
                "Check-Ins",
                "Today",
                out checkInsValueLabel,
                out checkInsDonut,
                Color.FromArgb(83, 194, 207),
                "front-desk flow"), 2, 0);

            TableLayoutPanel chartGrid = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(0)
            };
            chartGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            chartGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            chartGrid.Controls.Add(CreateChartCard(
                "Weekly Revenue",
                "Payments collected over the last 7 days",
                formsPlot1,
                out revenueSummaryLabel), 0, 0);
            chartGrid.Controls.Add(CreateChartCard(
                "Room Status",
                "Availability mix by current room state",
                formsPlot2,
                out roomStatusSummaryLabel,
                CreateStatusLegend()), 1, 0);

            TableLayoutPanel bottomGrid = new()
            {
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 20, 0, 0)
            };
            bottomGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 68F));
            bottomGrid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 32F));
            bottomGrid.Controls.Add(CreateActivityCard(), 0, 0);
            bottomGrid.Controls.Add(CreateBuyerCard(), 1, 0);

            root.Controls.Add(metricGrid, 0, 1);
            root.Controls.Add(chartGrid, 0, 2);
            root.Controls.Add(bottomGrid, 0, 3);
            Controls.Add(root);
            ResumeLayout(false);
        }

        private static Guna2Panel CreateCard()
        {
            return new Guna2Panel
            {
                BackColor = Color.Transparent,
                BorderColor = Color.FromArgb(224, 233, 246),
                BorderRadius = 14,
                BorderThickness = 1,
                FillColor = Color.White,
                Dock = DockStyle.Fill,
                Margin = new Padding(12, 0, 12, 0),
                Padding = new Padding(24),
                ShadowDecoration =
                {
                    BorderRadius = 14,
                    Color = Color.FromArgb(218, 228, 243),
                    Depth = 7,
                    Enabled = true
                }
            };
        }

        private static Control CreateMetricCard(
            string titleLine1,
            string titleLine2,
            out Label valueLabel,
            out DashboardDonutControl donut,
            Color accentColor,
            string helperText)
        {
            Guna2Panel card = CreateCard();
            card.Padding = new Padding(18, 22, 18, 22);

            Panel accent = new()
            {
                BackColor = accentColor,
                Dock = DockStyle.Left,
                Width = 4
            };

            donut = new DashboardDonutControl
            {
                AccentColor = accentColor,
                Location = new Point(26, 30),
                Percent = 0
            };

            Label titleLabel = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(47, 59, 86),
                Location = new Point(164, 34),
                Text = $"{titleLine1}\n{titleLine2}"
            };

            valueLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 19F, FontStyle.Bold),
                ForeColor = Color.FromArgb(18, 31, 54),
                Location = new Point(164, 94),
                Text = "0"
            };

            Label helper = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 8.5F),
                ForeColor = Color.FromArgb(139, 154, 178),
                Location = new Point(164, 138),
                Text = helperText
            };

            card.Controls.Add(accent);
            card.Controls.Add(donut);
            card.Controls.Add(titleLabel);
            card.Controls.Add(valueLabel);
            card.Controls.Add(helper);
            return card;
        }

        private static Control CreateChartCard(
            string title,
            string subtitle,
            ScottPlot.WinForms.FormsPlot plot,
            out Label summaryLabel,
            Control? footer = null)
        {
            Guna2Panel card = CreateCard();
            card.Padding = new Padding(24, 20, 24, 20);

            TableLayoutPanel layout = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                RowCount = footer == null ? 2 : 3
            };
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 58F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            if (footer != null)
            {
                layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            }

            TableLayoutPanel header = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            header.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 150F));

            TableLayoutPanel titleStack = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                RowCount = 2
            };
            titleStack.RowStyles.Add(new RowStyle(SizeType.Absolute, 26F));
            titleStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label titleLabel = new()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 35, 57),
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label subtitleLabel = new()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.8F),
                ForeColor = Color.FromArgb(126, 143, 169),
                Text = subtitle,
                TextAlign = ContentAlignment.TopLeft
            };

            summaryLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 118, 225),
                Text = "",
                TextAlign = ContentAlignment.MiddleRight
            };

            plot.Dock = DockStyle.Fill;
            plot.Margin = Padding.Empty;
            plot.DisplayScale = 1.25F;
            plot.BackColor = Color.White;

            titleStack.Controls.Add(titleLabel, 0, 0);
            titleStack.Controls.Add(subtitleLabel, 0, 1);
            header.Controls.Add(titleStack, 0, 0);
            header.Controls.Add(summaryLabel, 1, 0);
            layout.Controls.Add(header, 0, 0);
            layout.Controls.Add(plot, 0, 1);
            if (footer != null)
            {
                footer.Margin = new Padding(0, 10, 0, 0);
                layout.Controls.Add(footer, 0, 2);
            }

            card.Controls.Add(layout);
            return card;
        }

        private Control CreateStatusLegend()
        {
            TableLayoutPanel legend = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = new Padding(2, 0, 2, 0),
                RowCount = 1
            };

            for (int i = 0; i < 3; i++)
            {
                legend.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 33.33F));
            }
            legend.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            legend.Controls.Add(CreateLegendItem(Color.FromArgb(69, 125, 226), out availableStatusLabel), 0, 0);
            legend.Controls.Add(CreateLegendItem(Color.FromArgb(83, 194, 207), out occupiedStatusLabel), 1, 0);
            legend.Controls.Add(CreateLegendItem(Color.FromArgb(238, 96, 105), out reservedStatusLabel), 2, 0);
            return legend;
        }

        private static Control CreateLegendItem(Color color, out Label valueLabel)
        {
            TableLayoutPanel row = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(0),
                Padding = Padding.Empty
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 16F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            Panel dot = new()
            {
                BackColor = color,
                Margin = new Padding(0, 14, 6, 14),
                Size = new Size(9, 9)
            };

            valueLabel = new Label
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 8.2F),
                ForeColor = Color.FromArgb(91, 105, 129),
                TextAlign = ContentAlignment.MiddleLeft
            };

            row.Controls.Add(dot, 0, 0);
            row.Controls.Add(valueLabel, 1, 0);
            return row;
        }

        private Control CreateActivityCard()
        {
            Guna2Panel card = CreateCard();
            card.Padding = new Padding(28, 18, 28, 18);

            Label title = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 35, 57),
                Location = new Point(26, 20),
                Text = "Live Hotel Activity"
            };

            checkOutsValueLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 22F, FontStyle.Bold),
                ForeColor = Color.FromArgb(31, 126, 220),
                Location = new Point(28, 54),
                Text = "0"
            };

            Label detail = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9F),
                ForeColor = Color.FromArgb(143, 154, 173),
                Location = new Point(92, 70),
                Text = "check-outs today"
            };

            Guna2Panel badge = new()
            {
                BackColor = Color.Transparent,
                BorderRadius = 10,
                FillColor = Color.FromArgb(232, 242, 255),
                Size = new Size(88, 34)
            };
            Label badgeLabel = new()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI Semibold", 8.6F, FontStyle.Bold),
                ForeColor = Color.FromArgb(49, 118, 225),
                Text = "Today",
                TextAlign = ContentAlignment.MiddleCenter
            };
            badge.Controls.Add(badgeLabel);
            card.Resize += (_, _) => badge.Location = new Point(card.Width - 118, 22);

            card.Controls.Add(title);
            card.Controls.Add(checkOutsValueLabel);
            card.Controls.Add(detail);
            card.Controls.Add(badge);
            return card;
        }

        private Control CreateBuyerCard()
        {
            Guna2Panel card = CreateCard();
            card.Padding = new Padding(28, 18, 28, 18);

            Label title = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 10.5F, FontStyle.Bold),
                ForeColor = Color.FromArgb(24, 35, 57),
                Location = new Point(26, 20),
                Text = "Room Availability"
            };

            availableRoomsLabel = new Label
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI", 9.4F),
                ForeColor = Color.FromArgb(101, 116, 142),
                Location = new Point(26, 66),
                Text = "Available rooms: 0"
            };

            Label filter = new()
            {
                AutoSize = true,
                BackColor = Color.Transparent,
                Font = new Font("Segoe UI Semibold", 8.6F, FontStyle.Bold),
                ForeColor = Color.FromArgb(28, 174, 123),
                Location = new Point(card.Width - 88, 24),
                Text = "Live"
            };
            card.Resize += (_, _) => filter.Location = new Point(card.Width - 88, 24);

            card.Controls.Add(title);
            card.Controls.Add(filter);
            card.Controls.Add(availableRoomsLabel);
            return card;
        }

        private void LoadDashboardStats()
        {
            try
            {
                stats = DashboardStats.Load();
            }
            catch
            {
                stats = DashboardStats.Empty;
            }

            roomsValueLabel!.Text = stats.TotalRooms.ToString();
            guestsValueLabel!.Text = stats.TotalGuests.ToString();
            checkInsValueLabel!.Text = stats.TodayCheckIns.ToString();
            checkOutsValueLabel!.Text = stats.TodayCheckOuts.ToString();
            availableRoomsLabel!.Text = $"Available rooms: {stats.AvailableRooms}";
            decimal weeklyTotal = (decimal)stats.WeeklyRevenue.Sum();
            revenueSummaryLabel!.Text = weeklyTotal > 0 ? $"${weeklyTotal:0.00}" : "No payments";
            roomStatusSummaryLabel!.Text = stats.TotalRooms > 0 ? $"{stats.AvailableRooms}/{stats.TotalRooms} open" : "No rooms";
            availableStatusLabel!.Text = $"Available  {stats.AvailableRooms}";
            occupiedStatusLabel!.Text = $"Occupied  {stats.OccupiedRooms}";
            reservedStatusLabel!.Text = $"Reserved  {stats.ReservedRooms}";

            int roomBase = Math.Max(stats.TotalRooms, 1);
            roomsDonut!.Percent = stats.TotalRooms == 0 ? 0 : (int)Math.Round(stats.AvailableRooms * 100D / roomBase);
            guestsDonut!.Percent = stats.TotalGuests == 0 ? 0 : Math.Min(100, Math.Max(12, stats.TotalGuests * 8));

            int movementTotal = Math.Max(stats.TodayCheckIns + stats.TodayCheckOuts, 1);
            checkInsDonut!.Percent = stats.TodayCheckIns == 0 ? 0 : (int)Math.Round(stats.TodayCheckIns * 100D / movementTotal);
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

            double[] revenue = stats.WeeklyRevenue.Length == 7
                ? stats.WeeklyRevenue.Select(value => Math.Max(0, value)).ToArray()
                : new double[7];
            double[] xs = Enumerable.Range(0, revenue.Length).Select(x => (double)x).ToArray();
            string[] days = Enumerable.Range(0, 7)
                .Select(offset => DateTime.Today.AddDays(offset - 6).ToString("ddd"))
                .ToArray();

            var bars = Enumerable.Range(0, revenue.Length)
                .Select(index => new ScottPlot.Bar
                {
                    Position = index,
                    Value = revenue[index],
                    Size = 0.44,
                    FillColor = ScottPlot.Color.FromHex(index == revenue.Length - 1 ? "#3176E1" : "#AFCBF4"),
                    LineColor = ScottPlot.Color.FromHex(index == revenue.Length - 1 ? "#3176E1" : "#AFCBF4"),
                    LineWidth = 0
                })
                .ToArray();
            plt.Add.Bars(bars);

            plt.Axes.Bottom.TickGenerator = new ScottPlot.TickGenerators.NumericManual(xs, days);
            plt.Title("");
            plt.Axes.Left.Label.Text = "";
            plt.Axes.Bottom.Label.Text = "";
            plt.FigureBackground.Color = ScottPlot.Colors.White;
            plt.DataBackground.Color = ScottPlot.Colors.White;
            plt.Axes.Color(ScottPlot.Color.FromHex("#8DA0BC"));
            plt.Grid.MajorLineColor = ScottPlot.Color.FromHex("#EEF2F7");
            plt.Grid.MinorLineColor = ScottPlot.Color.FromHex("#F7F9FC");
            plt.Axes.SetLimits(-0.65, 6.65, 0, Math.Max(100, revenue.Max() * 1.25));

            formsPlot1.Refresh();
        }

        private void LoadPieChart()
        {
            var plt = formsPlot2.Plot;
            plt.Clear();

            double[] values =
            {
                Math.Max(stats.AvailableRooms, 0),
                Math.Max(stats.OccupiedRooms, 0),
                Math.Max(stats.ReservedRooms, 0)
            };
            if (values.Sum() <= 0)
            {
                values = new double[] { 1 };
            }

            double total = values.Sum();
            var pie = plt.Add.Pie(values);

            for (int i = 0; i < pie.Slices.Count; i++)
            {
                pie.Slices[i].Label = string.Empty;
            }

            pie.ExplodeFraction = 0.02;
            pie.DonutFraction = 0.62;
            pie.Radius = 0.74;
            pie.SliceLabelDistance = 0.72;
            pie.LineWidth = 2;
            pie.LineColor = ScottPlot.Colors.White;
            pie.Slices[0].FillColor = ScottPlot.Color.FromHex("#457DE2");
            if (pie.Slices.Count > 1)
            {
                pie.Slices[1].FillColor = ScottPlot.Color.FromHex("#53C2CF");
            }
            if (pie.Slices.Count > 2)
            {
                pie.Slices[2].FillColor = ScottPlot.Color.FromHex("#EE6069");
            }

            plt.Title("");
            plt.FigureBackground.Color = ScottPlot.Colors.White;
            plt.DataBackground.Color = ScottPlot.Colors.White;
            plt.HideAxesAndGrid();
            plt.Axes.SetLimits(-1.05, 1.05, -1.05, 1.05);
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

        private sealed class DashboardStats
        {
            public static DashboardStats Empty { get; } = new()
            {
                WeeklyRevenue = new double[7]
            };

            public int TotalRooms { get; private init; }
            public int TotalGuests { get; private init; }
            public int TodayCheckIns { get; private init; }
            public int TodayCheckOuts { get; private init; }
            public int AvailableRooms { get; private init; }
            public int OccupiedRooms { get; private init; }
            public int ReservedRooms { get; private init; }
            public double[] WeeklyRevenue { get; private init; } = new double[7];

            public static DashboardStats Load()
            {
                using SqlConnection connection = new DbConnection().GetConnection();
                connection.Open();

                double[] weeklyRevenue = LoadWeeklyRevenue(connection);

                return new DashboardStats
                {
                    TotalRooms = Count(connection, "SELECT COUNT(*) FROM rooms"),
                    TotalGuests = Count(connection, "SELECT COUNT(*) FROM customers"),
                    TodayCheckIns = Count(connection, "SELECT COUNT(*) FROM checkins WHERE CAST(CheckInDate AS date) = CAST(GETDATE() AS date)"),
                    TodayCheckOuts = Count(connection, "SELECT COUNT(*) FROM checkouts WHERE CAST(CheckOutDate AS date) = CAST(GETDATE() AS date)"),
                    AvailableRooms = Count(connection, "SELECT COUNT(*) FROM rooms WHERE Status = 'Available'"),
                    OccupiedRooms = Count(connection, "SELECT COUNT(*) FROM rooms WHERE Status = 'Occupied'"),
                    ReservedRooms = Count(connection, "SELECT COUNT(*) FROM rooms WHERE Status IN ('Reserved', 'Reserved/Booked')"),
                    WeeklyRevenue = weeklyRevenue
                };
            }

            private static int Count(SqlConnection connection, string sql)
            {
                using SqlCommand command = new(sql, connection);
                object? value = command.ExecuteScalar();
                return value == null || value == DBNull.Value ? 0 : Convert.ToInt32(value);
            }

            private static double[] LoadWeeklyRevenue(SqlConnection connection)
            {
                double[] revenue = new double[7];
                DateTime startDate = DateTime.Today.AddDays(-6);

                using SqlCommand command = connection.CreateCommand();
                command.CommandText = @"
                    SELECT CAST(PaymentDate AS date) AS RevenueDate, SUM(AmountPaid) AS Total
                    FROM payments
                    WHERE PaymentDate >= @StartDate
                      AND PaymentDate < DATEADD(day, 1, CAST(GETDATE() AS date))
                    GROUP BY CAST(PaymentDate AS date)";
                command.Parameters.AddWithValue("@StartDate", startDate);

                using SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    DateTime revenueDate = Convert.ToDateTime(reader["RevenueDate"]);
                    int index = (revenueDate.Date - startDate).Days;
                    if (index >= 0 && index < revenue.Length)
                    {
                        revenue[index] = Convert.ToDouble(reader["Total"]);
                    }
                }

                return revenue;
            }
        }
    }
}

