using Microsoft.Reporting.WinForms;
using System.Data;
using System.Drawing.Drawing2D;
using System.Globalization;

namespace Hotel_System.Report
{
    public class RdlcReportForm : Form
    {
        private static readonly Color[] Palette =
        {
            Color.FromArgb(65, 125, 226),
            Color.FromArgb(31, 176, 129),
            Color.FromArgb(80, 196, 212),
            Color.FromArgb(244, 94, 104),
            Color.FromArgb(246, 176, 78),
            Color.FromArgb(111, 91, 219)
        };

        private static readonly Color PageBackground = Color.FromArgb(237, 243, 251);
        private static readonly Color CardBackground = Color.White;
        private static readonly Color CardBorder = Color.FromArgb(215, 226, 242);
        private static readonly Color Ink = Color.FromArgb(15, 31, 56);
        private static readonly Color MutedInk = Color.FromArgb(91, 111, 145);
        private static readonly Color SoftBlue = Color.FromArgb(232, 241, 255);

        private readonly string reportTitle;
        private readonly string reportFileName;
        private readonly Func<DataTable> loadData;
        private readonly ReportViewer reportViewer = new();
        private readonly DataGridView reportGrid = new();
        private readonly MiniSeriesChart lineChart = new() { ChartMode = MiniChartMode.Line, Title = "Trend" };
        private readonly MiniSeriesChart barChart = new() { ChartMode = MiniChartMode.Bar, Title = "Category" };
        private readonly MiniSeriesChart areaChart = new() { ChartMode = MiniChartMode.Area, Title = "Summary Trend" };
        private readonly DonutSummaryChart donutChart = new();
        private readonly Label recordsValue = new();
        private readonly Label amountValue = new();
        private readonly Label categoryValue = new();
        private readonly Label generatedValue = new();
        private readonly Label amountTitle = new();
        private readonly Label categoryTitle = new();
        private readonly Label gridTitle = new();
        private readonly Label gridSubtitle = new();
        private DataTable reportData = new();

        protected RdlcReportForm(string reportTitle, string reportFileName, Func<DataTable> loadData)
        {
            this.reportTitle = reportTitle;
            this.reportFileName = reportFileName;
            this.loadData = loadData;
            ConfigureWindow();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            Text = reportTitle;
            WindowState = FormWindowState.Maximized;
            RefreshReportData();
        }

        private void ConfigureWindow()
        {
            Text = reportTitle;
            BackColor = PageBackground;
            StartPosition = FormStartPosition.CenterParent;
            WindowState = FormWindowState.Maximized;
            MinimumSize = new Size(1280, 820);

            ConfigureReportViewer(reportViewer);
            ConfigureGrid();

            TableLayoutPanel root = new()
            {
                BackColor = PageBackground,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Padding = new Padding(24, 22, 24, 24),
                RowCount = 4
            };
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 112F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 152F));
            root.RowStyles.Add(new RowStyle(SizeType.Absolute, 292F));
            root.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            root.Controls.Add(CreateHeader(), 0, 0);
            root.Controls.Add(CreateCardsRow(), 0, 1);
            root.Controls.Add(CreateChartsRow(), 0, 2);
            root.Controls.Add(CreateBottomRow(), 0, 3);
            Controls.Add(root);
        }

        private Control CreateHeader()
        {
            RoundedPanel header = CreateWhiteCard(new Padding(26, 18, 22, 18), new Padding(0, 0, 0, 14));
            header.BorderColor = Color.FromArgb(207, 220, 239);

            TableLayoutPanel layout = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 2,
                Dock = DockStyle.Fill
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 500F));

            TableLayoutPanel titleBlock = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            titleBlock.RowStyles.Add(new RowStyle(SizeType.Absolute, 40F));
            titleBlock.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label title = CreateTextLabel(reportTitle, 17F, FontStyle.Bold, Ink, ContentAlignment.MiddleLeft);
            Label subtitle = CreateTextLabel("Review live data, preview the report, or export a PDF for guests and hotel records.", 9.5F, FontStyle.Regular, MutedInk, ContentAlignment.TopLeft);
            titleBlock.Controls.Add(title, 0, 0);
            titleBlock.Controls.Add(subtitle, 0, 1);

            FlowLayoutPanel actions = new()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 13, 0, 13),
                WrapContents = false
            };
            actions.Controls.Add(CreateActionButton("Export PDF", (_, _) => ExportPdf()));
            actions.Controls.Add(CreateActionButton("Preview / Print", (_, _) => ShowPrintPreview()));
            actions.Controls.Add(CreateActionButton("Refresh", (_, _) => RefreshReportData()));

            layout.Controls.Add(titleBlock, 0, 0);
            layout.Controls.Add(actions, 1, 0);
            header.Controls.Add(layout);
            return header;
        }

        private Control CreateCardsRow()
        {
            TableLayoutPanel row = new()
            {
                BackColor = PageBackground,
                ColumnCount = 4,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };

            for (int i = 0; i < 4; i++)
            {
                row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 25F));
            }

            row.Controls.Add(CreateMetricCard("Records", "Loaded rows", recordsValue, Palette[0]), 0, 0);
            row.Controls.Add(CreateMetricCard("Total", "Numeric summary", amountValue, Palette[1], amountTitle), 1, 0);
            row.Controls.Add(CreateMetricCard("Category", "Distribution", categoryValue, Palette[2], categoryTitle), 2, 0);
            row.Controls.Add(CreateMetricCard("Generated", "Ready for print", generatedValue, Palette[3]), 3, 0);
            return row;
        }

        private Control CreateChartsRow()
        {
            TableLayoutPanel row = new()
            {
                BackColor = PageBackground,
                ColumnCount = 3,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 8, 0, 8)
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 22F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 56F));

            row.Controls.Add(CreateChartCard(lineChart), 0, 0);
            row.Controls.Add(CreateChartCard(barChart), 1, 0);
            row.Controls.Add(CreateChartCard(areaChart), 2, 0);
            return row;
        }

        private Control CreateBottomRow()
        {
            TableLayoutPanel row = new()
            {
                BackColor = PageBackground,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 8, 0, 0)
            };
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 72F));
            row.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 28F));
            row.Controls.Add(CreateGridCard(), 0, 0);
            row.Controls.Add(CreateChartCard(donutChart), 1, 0);
            return row;
        }

        private Control CreateGridCard()
        {
            RoundedPanel card = CreateWhiteCard(new Padding(18, 14, 18, 14));
            gridTitle.AutoSize = false;
            gridTitle.Dock = DockStyle.Top;
            gridTitle.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            gridTitle.ForeColor = Ink;
            gridTitle.Height = 30;
            gridTitle.Text = $"{reportTitle} Records";
            gridTitle.TextAlign = ContentAlignment.MiddleLeft;

            gridSubtitle.AutoSize = false;
            gridSubtitle.Dock = DockStyle.Top;
            gridSubtitle.Font = new Font("Segoe UI", 9F);
            gridSubtitle.ForeColor = MutedInk;
            gridSubtitle.Height = 26;
            gridSubtitle.Text = "Report rows loaded from database";
            gridSubtitle.TextAlign = ContentAlignment.MiddleLeft;

            Panel gridSurface = new()
            {
                BackColor = Color.White,
                Dock = DockStyle.Fill,
                Padding = new Padding(0, 8, 0, 0)
            };
            gridSurface.Controls.Add(reportGrid);

            card.Controls.Add(gridSurface);
            card.Controls.Add(gridSubtitle);
            card.Controls.Add(gridTitle);
            return card;
        }

        private static Control CreateMetricCard(string title, string subtitle, Label valueLabel, Color fillColor, Label? titleLabel = null)
        {
            RoundedPanel card = new()
            {
                BackColor = CardBackground,
                BorderColor = CardBorder,
                Dock = DockStyle.Fill,
                Margin = new Padding(0, 0, 14, 0),
                Padding = new Padding(18, 16, 18, 14),
                Radius = 16
            };

            Panel accent = new()
            {
                BackColor = fillColor,
                Dock = DockStyle.Left,
                Width = 5,
                Margin = Padding.Empty
            };

            TableLayoutPanel body = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = new Padding(14, 0, 0, 0),
                RowCount = 2
            };
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            body.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, 108F));
            body.RowStyles.Add(new RowStyle(SizeType.Absolute, 38F));
            body.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label heading = titleLabel ?? new Label();
            heading.AutoSize = false;
            heading.Dock = DockStyle.Fill;
            heading.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
            heading.ForeColor = Ink;
            heading.Text = title;
            heading.TextAlign = ContentAlignment.MiddleLeft;

            valueLabel.AutoSize = false;
            valueLabel.Dock = DockStyle.Fill;
            valueLabel.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            valueLabel.ForeColor = Ink;
            valueLabel.Text = "0";
            valueLabel.TextAlign = ContentAlignment.MiddleLeft;

            Label helper = new()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9F),
                ForeColor = MutedInk,
                Text = subtitle,
                TextAlign = ContentAlignment.TopLeft
            };

            Panel badge = new()
            {
                BackColor = Color.FromArgb(245, 248, 252),
                Dock = DockStyle.Fill,
                Margin = new Padding(8, 0, 0, 0)
            };
            badge.Paint += (_, e) =>
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle ring = new(22, 14, Math.Max(28, badge.Width - 44), Math.Max(28, badge.Height - 28));
                int size = Math.Min(ring.Width, ring.Height);
                ring = new Rectangle((badge.Width - size) / 2, (badge.Height - size) / 2, size, size);
                using Pen track = new(Color.FromArgb(226, 234, 246), 9F);
                using Pen stroke = new(fillColor, 9F) { StartCap = LineCap.Round, EndCap = LineCap.Round };
                e.Graphics.DrawArc(track, ring, -90, 360);
                e.Graphics.DrawArc(stroke, ring, -90, 265);
            };

            TableLayoutPanel textStack = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 2
            };
            textStack.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            textStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            textStack.Controls.Add(valueLabel, 0, 0);
            textStack.Controls.Add(helper, 0, 1);

            body.Controls.Add(heading, 0, 0);
            body.Controls.Add(textStack, 0, 1);
            body.Controls.Add(badge, 1, 0);
            body.SetRowSpan(badge, 2);

            card.Controls.Add(body);
            card.Controls.Add(accent);
            return card;
        }

        private static Control CreateChartCard(Control chart)
        {
            RoundedPanel card = CreateWhiteCard(new Padding(18, 14, 18, 14));
            chart.Dock = DockStyle.Fill;
            chart.Margin = Padding.Empty;
            card.Controls.Add(chart);
            return card;
        }

        private static RoundedPanel CreateWhiteCard()
        {
            return CreateWhiteCard(new Padding(16), new Padding(0, 0, 14, 0));
        }

        private static RoundedPanel CreateWhiteCard(Padding padding)
        {
            return CreateWhiteCard(padding, new Padding(0, 0, 14, 0));
        }

        private static RoundedPanel CreateWhiteCard(Padding padding, Padding margin)
        {
            return new RoundedPanel
            {
                BackColor = CardBackground,
                BorderColor = CardBorder,
                Dock = DockStyle.Fill,
                Margin = margin,
                Padding = padding,
                Radius = 16
            };
        }

        private static Button CreateActionButton(string text, EventHandler click)
        {
            Button button = new()
            {
                BackColor = Color.FromArgb(240, 245, 255),
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9F, FontStyle.Bold),
                ForeColor = Color.FromArgb(33, 91, 190),
                Height = 40,
                Margin = new Padding(10, 0, 0, 0),
                Text = text,
                Width = text.Contains('/') ? 146 : 108
            };
            button.FlatAppearance.BorderColor = Color.FromArgb(205, 218, 240);
            button.FlatAppearance.MouseDownBackColor = Color.FromArgb(219, 233, 255);
            button.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 240, 255);
            button.Click += click;
            return button;
        }

        private void ConfigureGrid()
        {
            reportGrid.AllowUserToAddRows = false;
            reportGrid.AllowUserToDeleteRows = false;
            reportGrid.AutoGenerateColumns = true;
            reportGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            reportGrid.BackgroundColor = Color.White;
            reportGrid.BorderStyle = BorderStyle.None;
            reportGrid.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            reportGrid.ColumnHeadersHeight = 54;
            reportGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            reportGrid.Dock = DockStyle.Fill;
            reportGrid.EnableHeadersVisualStyles = false;
            reportGrid.GridColor = Color.FromArgb(222, 228, 240);
            reportGrid.ReadOnly = true;
            reportGrid.RowHeadersVisible = false;
            reportGrid.RowTemplate.Height = 42;
            reportGrid.ScrollBars = ScrollBars.Both;
            reportGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            reportGrid.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(20, 34, 58);
            reportGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            reportGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            reportGrid.ColumnHeadersDefaultCellStyle.Padding = new Padding(10, 4, 10, 4);
            reportGrid.ColumnHeadersDefaultCellStyle.WrapMode = DataGridViewTriState.True;
            reportGrid.DefaultCellStyle.BackColor = Color.White;
            reportGrid.DefaultCellStyle.Font = new Font("Segoe UI", 9F);
            reportGrid.DefaultCellStyle.ForeColor = Ink;
            reportGrid.DefaultCellStyle.Padding = new Padding(10, 0, 10, 0);
            reportGrid.DefaultCellStyle.SelectionBackColor = Color.FromArgb(65, 125, 226);
            reportGrid.DefaultCellStyle.SelectionForeColor = Color.White;
            reportGrid.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            reportGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(247, 250, 255);
            reportGrid.DataBindingComplete += (_, _) => ApplyReportGridColumnLayout();
        }

        private static void ConfigureReportViewer(ReportViewer viewer, ZoomMode zoomMode = ZoomMode.PageWidth, int zoomPercent = 100)
        {
            viewer.Dock = DockStyle.Fill;
            viewer.ProcessingMode = ProcessingMode.Local;
            viewer.ShowBackButton = false;
            viewer.ShowCredentialPrompts = false;
            viewer.ShowDocumentMapButton = false;
            viewer.ShowExportButton = true;
            viewer.ShowFindControls = true;
            viewer.ShowPageNavigationControls = true;
            viewer.ShowPrintButton = true;
            viewer.ShowPromptAreaButton = false;
            viewer.ShowRefreshButton = true;
            viewer.ShowStopButton = false;
            viewer.ZoomMode = zoomMode;
            viewer.ZoomPercent = zoomPercent;
        }

        private void RefreshReportData()
        {
            try
            {
                reportData = loadData();
                reportGrid.DataSource = reportData;
                ApplyReportGridColumnLayout();
                BindReport(reportViewer, reportData);
                UpdateDashboard();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to load {reportTitle}: {ex.Message}", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ApplyReportGridColumnLayout()
        {
            if (reportGrid.Columns.Count == 0)
            {
                return;
            }

            foreach (DataGridViewColumn column in reportGrid.Columns)
            {
                column.SortMode = DataGridViewColumnSortMode.NotSortable;
                column.MinimumWidth = 110;
                column.Width = Math.Clamp(TextRenderer.MeasureText(column.HeaderText, reportGrid.ColumnHeadersDefaultCellStyle.Font).Width + 42, 120, 190);
            }

            foreach (string narrowColumn in new[] { "ID", "RoomID", "BookingID", "CheckInID", "CheckOutID", "Room", "Nights", "Floor", "Capacity", "Status" })
            {
                foreach (DataGridViewColumn column in reportGrid.Columns.Cast<DataGridViewColumn>().Where(c => c.Name.Contains(narrowColumn, StringComparison.OrdinalIgnoreCase)))
                {
                    column.Width = Math.Min(column.Width, narrowColumn == "Status" ? 145 : 130);
                }
            }

            foreach (string wideColumn in new[] { "Name", "Phone", "Email", "Address", "Date", "Method", "Type", "Amount", "Price", "Charge" })
            {
                foreach (DataGridViewColumn column in reportGrid.Columns.Cast<DataGridViewColumn>().Where(c => c.Name.Contains(wideColumn, StringComparison.OrdinalIgnoreCase)))
                {
                    column.Width = Math.Max(column.Width, wideColumn == "Address" ? 220 : 155);
                }
            }
        }

        private void UpdateDashboard()
        {
            DataColumn? numericColumn = FindPrimaryNumericColumn(reportData);
            DataColumn? categoryColumn = FindCategoryColumn(reportData);
            DataColumn? dateColumn = FindDateColumn(reportData);

            recordsValue.Text = reportData.Rows.Count.ToString("N0", CultureInfo.CurrentCulture);
            string numericTitle = PrettyName(numericColumn?.ColumnName ?? "Records");
            string categoryName = PrettyName(categoryColumn?.ColumnName ?? "Category");
            amountTitle.Text = numericTitle;
            amountValue.Text = FormatMetric(SumColumn(reportData, numericColumn));
            categoryTitle.Text = categoryName;
            categoryValue.Text = categoryColumn == null
                ? "None"
                : $"{GetCategoryCounts(reportData, categoryColumn).Count:N0} types";
            generatedValue.Text = DateTime.Now.ToString("HH:mm", CultureInfo.CurrentCulture);
            gridTitle.Text = $"{reportTitle} Records";
            gridSubtitle.Text = $"{reportData.Rows.Count:N0} rows loaded from the database";

            List<decimal> trend = BuildTrend(reportData, dateColumn, numericColumn);
            List<CategoryValue> categoryValues = BuildCategoryValues(reportData, categoryColumn);
            List<string> trendLabels = BuildTrendLabels(reportData, dateColumn, trend.Count);
            lineChart.Title = "Activity Trend";
            lineChart.Subtitle = dateColumn == null ? $"{numericTitle} by record order" : $"{numericTitle} by {PrettyName(dateColumn.ColumnName)}";
            areaChart.Title = "Summary Trend";
            areaChart.Subtitle = reportData.Rows.Count == 0 ? "Waiting for report data" : $"Latest {Math.Min(12, trend.Count)} points";
            barChart.Title = $"{categoryName} Breakdown";
            barChart.Subtitle = "Top categories";
            lineChart.SetValues(trend, trendLabels);
            areaChart.SetValues(trend, trendLabels);
            barChart.SetCategories(categoryValues);
            donutChart.SetCategories(categoryValues, $"{categoryName} Mix", $"{reportData.Rows.Count:N0} total records");
        }

        private void BindReport(ReportViewer viewer, DataTable data)
        {
            string reportPath = ResolveReportPath(reportFileName);
            viewer.LocalReport.ReportPath = reportPath;
            viewer.LocalReport.DataSources.Clear();
            viewer.LocalReport.DataSources.Add(new ReportDataSource("ReportData", data));
            viewer.RefreshReport();
        }

        private void ShowPrintPreview()
        {
            Form preview = new()
            {
                BackColor = Color.White,
                MinimumSize = new Size(1000, 680),
                StartPosition = FormStartPosition.CenterParent,
                Text = $"{reportTitle} Preview",
                WindowState = FormWindowState.Maximized
            };

            ReportViewer previewViewer = new();
            ConfigureReportViewer(previewViewer, ZoomMode.Percent, 125);
            BindReport(previewViewer, reportData);
            preview.Controls.Add(previewViewer);
            preview.Show(this);
        }

        private void ExportPdf()
        {
            try
            {
                BindReport(reportViewer, reportData);
                byte[] pdfBytes = reportViewer.LocalReport.Render("PDF");

                using SaveFileDialog dialog = new()
                {
                    AddExtension = true,
                    DefaultExt = "pdf",
                    FileName = $"{reportTitle.Replace('/', '-')}.pdf",
                    Filter = "PDF file (*.pdf)|*.pdf"
                };

                if (dialog.ShowDialog(this) == DialogResult.OK)
                {
                    File.WriteAllBytes(dialog.FileName, pdfBytes);
                    MessageBox.Show("Report exported to PDF successfully.", "Report", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Unable to export PDF: {ex.Message}", "Report", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static DataColumn? FindPrimaryNumericColumn(DataTable table)
        {
            string[] priority = { "Total", "Amount", "Price", "Charge", "Deposit", "Remaining", "Revenue", "Paid" };
            return table.Columns.Cast<DataColumn>()
                .Where(IsNumericColumn)
                .OrderByDescending(c => priority.Any(p => c.ColumnName.Contains(p, StringComparison.OrdinalIgnoreCase)))
                .FirstOrDefault();
        }

        private static DataColumn? FindCategoryColumn(DataTable table)
        {
            string[] priority = { "Status", "PaymentStatus", "PaymentMethod", "RoomType", "Gender", "BedType" };
            return table.Columns.Cast<DataColumn>()
                .Where(c => c.DataType == typeof(string) || c.DataType == typeof(object))
                .OrderByDescending(c => priority.Any(p => c.ColumnName.Equals(p, StringComparison.OrdinalIgnoreCase)))
                .ThenBy(c => c.Ordinal)
                .FirstOrDefault();
        }

        private static DataColumn? FindDateColumn(DataTable table)
        {
            return table.Columns.Cast<DataColumn>()
                .FirstOrDefault(c => c.DataType == typeof(DateTime) || c.ColumnName.Contains("Date", StringComparison.OrdinalIgnoreCase));
        }

        private static bool IsNumericColumn(DataColumn column)
        {
            Type type = Nullable.GetUnderlyingType(column.DataType) ?? column.DataType;
            return type == typeof(byte) || type == typeof(short) || type == typeof(int) || type == typeof(long) ||
                   type == typeof(float) || type == typeof(double) || type == typeof(decimal);
        }

        private static decimal SumColumn(DataTable table, DataColumn? column)
        {
            if (column == null)
            {
                return table.Rows.Count;
            }

            return table.Rows.Cast<DataRow>()
                .Where(row => row[column] != DBNull.Value)
                .Select(row => Convert.ToDecimal(row[column], CultureInfo.CurrentCulture))
                .DefaultIfEmpty()
                .Sum();
        }

        private static List<decimal> BuildTrend(DataTable table, DataColumn? dateColumn, DataColumn? numericColumn)
        {
            if (table.Rows.Count == 0)
            {
                return new List<decimal> { 0M };
            }

            if (dateColumn != null)
            {
                return table.Rows.Cast<DataRow>()
                    .Where(row => row[dateColumn] != DBNull.Value)
                    .GroupBy(row => Convert.ToDateTime(row[dateColumn], CultureInfo.CurrentCulture).Date)
                    .OrderBy(group => group.Key)
                    .Select(group => numericColumn == null ? group.Count() : group.Sum(row => row[numericColumn] == DBNull.Value ? 0M : Convert.ToDecimal(row[numericColumn], CultureInfo.CurrentCulture)))
                    .Take(12)
                    .ToList();
            }

            if (numericColumn != null)
            {
                return table.Rows.Cast<DataRow>()
                    .Where(row => row[numericColumn] != DBNull.Value)
                    .Select(row => Convert.ToDecimal(row[numericColumn], CultureInfo.CurrentCulture))
                    .Take(12)
                    .ToList();
            }

            return Enumerable.Range(1, Math.Min(12, table.Rows.Count)).Select(i => (decimal)i).ToList();
        }

        private static List<CategoryValue> BuildCategoryValues(DataTable table, DataColumn? categoryColumn)
        {
            if (categoryColumn == null || table.Rows.Count == 0)
            {
                return new List<CategoryValue> { new("Records", table.Rows.Count) };
            }

            return GetCategoryCounts(table, categoryColumn)
                .OrderByDescending(pair => pair.Value)
                .Take(6)
                .Select(pair => new CategoryValue(pair.Key, pair.Value))
                .ToList();
        }

        private static Dictionary<string, int> GetCategoryCounts(DataTable table, DataColumn categoryColumn)
        {
            return table.Rows.Cast<DataRow>()
                .Select(row => Convert.ToString(row[categoryColumn], CultureInfo.CurrentCulture))
                .Select(value => string.IsNullOrWhiteSpace(value) ? "Unknown" : value!)
                .GroupBy(value => value)
                .ToDictionary(group => group.Key, group => group.Count());
        }

        private static List<string> BuildSequentialLabels(int count)
        {
            return Enumerable.Range(1, Math.Max(1, count)).Select(i => i.ToString(CultureInfo.CurrentCulture)).ToList();
        }

        private static List<string> BuildTrendLabels(DataTable table, DataColumn? dateColumn, int fallbackCount)
        {
            if (dateColumn == null || table.Rows.Count == 0)
            {
                return BuildSequentialLabels(fallbackCount);
            }

            List<string> labels = table.Rows.Cast<DataRow>()
                .Where(row => row[dateColumn] != DBNull.Value)
                .GroupBy(row => Convert.ToDateTime(row[dateColumn], CultureInfo.CurrentCulture).Date)
                .OrderBy(group => group.Key)
                .Select(group => group.Key.ToString("MMM d", CultureInfo.CurrentCulture))
                .Take(12)
                .ToList();

            return labels.Count == 0 ? BuildSequentialLabels(fallbackCount) : labels;
        }

        private static string FormatMetric(decimal value)
        {
            return value >= 1000 ? value.ToString("N0", CultureInfo.CurrentCulture) : value.ToString("0.##", CultureInfo.CurrentCulture);
        }

        private static string PrettyName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
            {
                return "Total";
            }

            return string.Concat(name.Select((ch, index) => index > 0 && char.IsUpper(ch) ? " " + ch : ch.ToString()));
        }

        private static string ResolveReportPath(string reportFileName)
        {
            string[] candidates =
            {
                Path.Combine(Application.StartupPath, "Report", "rdcl", reportFileName),
                Path.Combine(AppContext.BaseDirectory, "Report", "rdcl", reportFileName),
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "Report", "rdcl", reportFileName),
                Path.Combine(AppContext.BaseDirectory, "..", "..", "..", "..", "Report", "rdcl", reportFileName)
            };

            foreach (string candidate in candidates)
            {
                string fullPath = Path.GetFullPath(candidate);
                if (File.Exists(fullPath))
                {
                    return fullPath;
                }
            }

            throw new FileNotFoundException($"Report file was not found: {reportFileName}");
        }

        private static Label CreateTextLabel(string text, float size, FontStyle style, Color color, ContentAlignment alignment)
        {
            return new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", size, style),
                ForeColor = color,
                Text = text,
                TextAlign = alignment
            };
        }

        private static GraphicsPath CreateRoundedPath(Rectangle bounds, int radius)
        {
            int diameter = Math.Max(2, radius * 2);
            Size size = new(diameter, diameter);
            Rectangle arc = new(bounds.Location, size);
            GraphicsPath path = new();

            path.AddArc(arc, 180, 90);
            arc.X = bounds.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = bounds.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = bounds.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
            return path;
        }

        private readonly record struct CategoryValue(string Label, int Value);

        private sealed class RoundedPanel : Panel
        {
            public int Radius { get; set; } = 16;
            public Color BorderColor { get; set; } = CardBorder;

            public RoundedPanel()
            {
                DoubleBuffered = true;
                SetStyle(ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer | ControlStyles.ResizeRedraw | ControlStyles.UserPaint, true);
            }

            protected override void OnResize(EventArgs eventargs)
            {
                base.OnResize(eventargs);
                if (Width <= 0 || Height <= 0)
                {
                    return;
                }

                using GraphicsPath path = CreateRoundedPath(new Rectangle(0, 0, Width, Height), Radius);
                Region?.Dispose();
                Region = new Region(path);
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                Rectangle bounds = new(0, 0, Width - 1, Height - 1);
                using GraphicsPath path = CreateRoundedPath(bounds, Radius);
                using SolidBrush fill = new(BackColor);
                using Pen border = new(BorderColor, 1F);
                e.Graphics.FillPath(fill, path);
                e.Graphics.DrawPath(border, path);
            }
        }

        private enum MiniChartMode
        {
            Line,
            Area,
            Bar
        }

        private sealed class MiniSeriesChart : Control
        {
            private readonly List<decimal> values = new();
            private readonly List<string> labels = new();
            private readonly List<CategoryValue> categories = new();

            public MiniChartMode ChartMode { get; init; }
            public string Title { get; set; } = "Chart";
            public string Subtitle { get; set; } = string.Empty;

            public MiniSeriesChart()
            {
                DoubleBuffered = true;
                BackColor = Color.White;
                Font = new Font("Segoe UI", 8F);
            }

            public void SetValues(IEnumerable<decimal> nextValues, IEnumerable<string> nextLabels)
            {
                values.Clear();
                labels.Clear();
                values.AddRange(nextValues);
                labels.AddRange(nextLabels);
                Invalidate();
            }

            public void SetCategories(IEnumerable<CategoryValue> nextCategories)
            {
                categories.Clear();
                categories.AddRange(nextCategories);
                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
                DrawTitle(e.Graphics);

                Rectangle plot = new(42, 62, Math.Max(10, Width - 70), Math.Max(10, Height - 98));
                if (!HasRenderableData())
                {
                    DrawEmptyState(e.Graphics, plot);
                    return;
                }

                DrawGrid(e.Graphics, plot);

                if (ChartMode == MiniChartMode.Bar)
                {
                    DrawBars(e.Graphics, plot);
                    return;
                }

                DrawLineOrArea(e.Graphics, plot);
            }

            private void DrawTitle(Graphics graphics)
            {
                using Brush titleBrush = new SolidBrush(Ink);
                using Brush subtitleBrush = new SolidBrush(MutedInk);
                using Font titleFont = new("Segoe UI", 11F, FontStyle.Bold);
                using Font subtitleFont = new("Segoe UI", 8.8F);
                graphics.DrawString(Title, titleFont, titleBrush, 2, 2);
                if (!string.IsNullOrWhiteSpace(Subtitle))
                {
                    graphics.DrawString(Subtitle, subtitleFont, subtitleBrush, 2, 26);
                }
            }

            private bool HasRenderableData()
            {
                if (ChartMode == MiniChartMode.Bar)
                {
                    return categories.Any(item => item.Value > 0);
                }

                return values.Any(value => value != 0M);
            }

            private static void DrawGrid(Graphics graphics, Rectangle plot)
            {
                using Pen gridPen = new(Color.FromArgb(224, 231, 242));
                using Pen axisPen = new(Color.FromArgb(187, 199, 219));
                for (int i = 0; i <= 4; i++)
                {
                    int y = plot.Top + (plot.Height * i / 4);
                    graphics.DrawLine(gridPen, plot.Left, y, plot.Right, y);
                }
                graphics.DrawRectangle(axisPen, plot);
            }

            public static void DrawEmptyState(Graphics graphics, Rectangle plot)
            {
                Rectangle empty = new(plot.Left, plot.Top, plot.Width, Math.Max(92, plot.Height));
                using GraphicsPath path = CreateRoundedPath(empty, 12);
                using Brush fill = new SolidBrush(Color.FromArgb(248, 251, 255));
                using Pen border = new(Color.FromArgb(223, 232, 246));
                graphics.FillPath(fill, path);
                graphics.DrawPath(border, path);

                using Brush textBrush = new SolidBrush(MutedInk);
                using Font font = new("Segoe UI", 9.4F, FontStyle.Bold);
                using StringFormat format = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                graphics.DrawString("No data to chart yet", font, textBrush, empty, format);
            }

            private void DrawLineOrArea(Graphics graphics, Rectangle plot)
            {
                List<decimal> series = values.Count == 0 ? new List<decimal> { 0M } : values;
                decimal max = Math.Max(1M, series.Max());
                decimal min = Math.Min(0M, series.Min());
                decimal span = Math.Max(1M, max - min);

                PointF[] points = series.Select((value, index) =>
                {
                    float x = plot.Left + (series.Count == 1 ? plot.Width / 2F : index * plot.Width / (series.Count - 1F));
                    float y = plot.Bottom - (float)((value - min) / span) * plot.Height;
                    return new PointF(x, y);
                }).ToArray();

                if (ChartMode == MiniChartMode.Area && points.Length > 1)
                {
                    PointF[] area = points.Concat(new[] { new PointF(points[^1].X, plot.Bottom), new PointF(points[0].X, plot.Bottom) }).ToArray();
                    using Brush fill = new SolidBrush(Color.FromArgb(90, 35, 180, 76));
                    graphics.FillPolygon(fill, area);
                }

                if (points.Length > 1)
                {
                    using Pen linePen = new(ChartMode == MiniChartMode.Area ? Palette[1] : Palette[0], 3F);
                    graphics.DrawLines(linePen, points);
                }

                foreach (PointF point in points)
                {
                    using Brush brush = new SolidBrush(ChartMode == MiniChartMode.Area ? Palette[1] : Palette[0]);
                    graphics.FillEllipse(brush, point.X - 3, point.Y - 3, 6, 6);
                }

                DrawBottomLabels(graphics, plot, labels.Count == series.Count ? labels : BuildSequentialLabels(series.Count));
            }

            private void DrawBars(Graphics graphics, Rectangle plot)
            {
                List<CategoryValue> data = categories.Count == 0 ? new List<CategoryValue> { new("Records", 0) } : categories;
                int max = Math.Max(1, data.Max(item => item.Value));
                int gap = 6;
                int barWidth = Math.Max(8, (plot.Width - gap * (data.Count + 1)) / Math.Max(1, data.Count));

                for (int i = 0; i < data.Count; i++)
                {
                    int height = (int)(plot.Height * (data[i].Value / (double)max));
                    int x = plot.Left + gap + i * (barWidth + gap);
                    int y = plot.Bottom - height;
                    using Brush brush = new SolidBrush(Palette[i % Palette.Length]);
                    graphics.FillRectangle(brush, x, y, barWidth, height);

                    using Brush textBrush = new SolidBrush(Color.FromArgb(70, 78, 96));
                    string label = data[i].Label.Length > 9 ? data[i].Label[..9] : data[i].Label;
                    graphics.TranslateTransform(x + barWidth / 2F, plot.Bottom + 6);
                    graphics.RotateTransform(-90);
                    graphics.DrawString(label, Font, textBrush, 0, 0);
                    graphics.ResetTransform();
                }
            }

            private void DrawBottomLabels(Graphics graphics, Rectangle plot, IReadOnlyList<string> bottomLabels)
            {
                if (bottomLabels.Count == 0)
                {
                    return;
                }

                using Brush textBrush = new SolidBrush(Color.FromArgb(112, 128, 157));
                using Font labelFont = new("Segoe UI", 7.6F);
                int step = Math.Max(1, bottomLabels.Count / 5);
                for (int i = 0; i < bottomLabels.Count; i += step)
                {
                    float x = plot.Left + (bottomLabels.Count == 1 ? plot.Width / 2F : i * plot.Width / (bottomLabels.Count - 1F));
                    string label = bottomLabels[i];
                    SizeF size = graphics.MeasureString(label, labelFont);
                    graphics.DrawString(label, labelFont, textBrush, x - size.Width / 2F, plot.Bottom + 8);
                }
            }
        }

        private sealed class DonutSummaryChart : Control
        {
            private readonly List<CategoryValue> categories = new();
            private string title = "Category Mix";
            private string subtitle = "Distribution";

            public DonutSummaryChart()
            {
                DoubleBuffered = true;
                BackColor = Color.White;
                Font = new Font("Segoe UI", 8.5F);
            }

            public void SetCategories(IEnumerable<CategoryValue> nextCategories, string nextTitle, string nextSubtitle)
            {
                categories.Clear();
                categories.AddRange(nextCategories);
                title = nextTitle;
                subtitle = nextSubtitle;
                Invalidate();
            }

            protected override void OnPaint(PaintEventArgs e)
            {
                base.OnPaint(e);
                e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;

                using Brush titleBrush = new SolidBrush(Color.FromArgb(28, 31, 43));
                using Brush subtitleBrush = new SolidBrush(MutedInk);
                using Font titleFont = new("Segoe UI", 11F, FontStyle.Bold);
                using Font subtitleFont = new("Segoe UI", 8.8F);
                e.Graphics.DrawString(title, titleFont, titleBrush, 2, 2);
                e.Graphics.DrawString(subtitle, subtitleFont, subtitleBrush, 2, 26);

                List<CategoryValue> data = categories.Count == 0 ? new List<CategoryValue> { new("No data", 1) } : categories;
                int total = Math.Max(1, data.Sum(item => item.Value));
                if (data.Sum(item => item.Value) == 0)
                {
                    Rectangle empty = new(12, 58, Math.Max(80, Width - 24), Math.Max(90, Height - 88));
                    MiniSeriesChart.DrawEmptyState(e.Graphics, empty);
                    return;
                }

                int legendHeight = data.Count * 24;
                int size = Math.Min(Width - 42, Height - 88 - legendHeight);
                size = Math.Max(128, size);
                Rectangle pie = new((Width - size) / 2, 58, size, size);
                float start = -90F;

                for (int i = 0; i < data.Count; i++)
                {
                    float sweep = data[i].Value * 360F / total;
                    using Brush brush = new SolidBrush(Palette[i % Palette.Length]);
                    e.Graphics.FillPie(brush, pie, start, sweep);
                    start += sweep;
                }

                int holeSize = (int)(size * 0.46);
                Rectangle hole = new(pie.Left + (size - holeSize) / 2, pie.Top + (size - holeSize) / 2, holeSize, holeSize);
                using Brush holeBrush = new SolidBrush(Color.White);
                e.Graphics.FillEllipse(holeBrush, hole);

                using Brush centerBrush = new SolidBrush(Ink);
                using Font centerFont = new("Segoe UI", 14F, FontStyle.Bold);
                using StringFormat centerFormat = new() { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center };
                e.Graphics.DrawString(total.ToString("N0", CultureInfo.CurrentCulture), centerFont, centerBrush, hole, centerFormat);

                int legendX = Math.Max(18, pie.Left);
                int legendY = pie.Bottom + 18;
                for (int i = 0; i < data.Count; i++)
                {
                    using Brush swatch = new SolidBrush(Palette[i % Palette.Length]);
                    using Brush text = new SolidBrush(Color.FromArgb(60, 68, 86));
                    Rectangle swatchRect = new(legendX, legendY + i * 22 + 3, 10, 10);
                    e.Graphics.FillRectangle(swatch, swatchRect);
                    e.Graphics.DrawString($"{data[i].Label}  {data[i].Value}", Font, text, legendX + 18, legendY + i * 22 - 1);
                }
            }
        }
    }
}
