using System;
using System.Data;
using System.Drawing;
using System.Drawing.Printing;
using System.Windows.Forms;

namespace Hotel_System.UI
{
    internal static class ReportLauncher
    {
        public static void ShowForm(Control owner, Func<Form> createReport, string title)
        {
            try
            {
                Form reportWindow = createReport();
                reportWindow.Text = title;

                Form? parentForm = owner.FindForm();
                if (parentForm == null)
                {
                    reportWindow.Show();
                    return;
                }

                reportWindow.Show(parentForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to open {title}: {ex.Message}",
                    "Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void ShowReportChooser(Control owner, string title, params (string Label, Func<Form> CreateReport)[] reports)
        {
            Form chooser = new()
            {
                BackColor = UiTheme.PageBackground,
                Font = UiTheme.BodyFont,
                FormBorderStyle = FormBorderStyle.FixedDialog,
                MaximizeBox = false,
                MinimizeBox = false,
                StartPosition = FormStartPosition.CenterParent,
                Text = title,
                Size = new Size(360, 190)
            };

            FlowLayoutPanel actions = new()
            {
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.TopDown,
                Padding = new Padding(28),
                WrapContents = false
            };

            foreach ((string label, Func<Form> createReport) in reports)
            {
                Button button = new()
                {
                    Height = 42,
                    Text = label,
                    Width = 280
                };
                button.Click += (_, _) =>
                {
                    chooser.Close();
                    ShowForm(owner, createReport, label);
                };
                actions.Controls.Add(button);
            }

            chooser.Controls.Add(actions);
            Form? parentForm = owner.FindForm();
            chooser.ShowDialog(parentForm);
        }

        public static void ShowReport(Control owner, Func<UserControl> createReport, string title)
        {
            try
            {
                UserControl report = createReport();
                report.Dock = DockStyle.Fill;

                Form reportWindow = new()
                {
                    BackColor = UiTheme.PageBackground,
                    Font = UiTheme.BodyFont,
                    MinimumSize = new Size(980, 640),
                    StartPosition = FormStartPosition.CenterParent,
                    Text = title,
                    WindowState = FormWindowState.Maximized
                };
                reportWindow.Controls.Add(report);

                Form? parentForm = owner.FindForm();
                if (parentForm == null)
                {
                    reportWindow.Show();
                    return;
                }

                reportWindow.Show(parentForm);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    $"Unable to open {title}: {ex.Message}",
                    "Report",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        public static void ShowTableReport(Control owner, string title, Func<DataTable> loadData)
        {
            ShowReport(owner, () => CreateTableReport(title, loadData), title);
        }

        private static UserControl CreateTableReport(string title, Func<DataTable> loadData)
        {
            UserControl report = new()
            {
                BackColor = UiTheme.PageBackground,
                Dock = DockStyle.Fill,
                Padding = new Padding(28)
            };

            TableLayoutPanel layout = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                RowCount = 3
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 82F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 62F));

            Label heading = new()
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = UiTheme.TextPrimary,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            };

            DataGridView grid = new()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = true,
                BackgroundColor = Color.White,
                Dock = DockStyle.Fill,
                ReadOnly = true,
                ScrollBars = ScrollBars.Both
            };
            UiTheme.ApplyPageDesign(grid);
            grid.DataSource = loadData();

            FlowLayoutPanel actions = new()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.RightToLeft,
                Padding = new Padding(0, 10, 0, 0)
            };

            Button printButton = new()
            {
                Height = 42,
                Text = "Print",
                Width = 140
            };
            printButton.Click += (_, _) => PrintGrid(title, grid);
            actions.Controls.Add(printButton);

            layout.Controls.Add(heading, 0, 0);
            layout.Controls.Add(grid, 0, 1);
            layout.Controls.Add(actions, 0, 2);
            report.Controls.Add(layout);
            UiTheme.ApplyPageDesign(report);
            return report;
        }

        private static void PrintGrid(string title, DataGridView grid)
        {
            PrintDocument document = new();
            document.DocumentName = title;
            document.PrintPage += (_, e) =>
            {
                if (e.Graphics == null)
                {
                    return;
                }

                using Font titleFont = new("Segoe UI", 16F, FontStyle.Bold);
                using Font bodyFont = new("Segoe UI", 9F);
                using Brush textBrush = new SolidBrush(Color.Black);
                int y = e.MarginBounds.Top;
                e.Graphics.DrawString(title, titleFont, textBrush, e.MarginBounds.Left, y);
                y += 42;

                foreach (DataGridViewColumn column in grid.Columns)
                {
                    if (column.Visible)
                    {
                        e.Graphics.DrawString(column.HeaderText, bodyFont, textBrush, e.MarginBounds.Left, y);
                        y += 20;
                    }
                }
            };

            using PrintDialog dialog = new()
            {
                Document = document,
                UseEXDialog = true
            };

            if (dialog.ShowDialog() == DialogResult.OK)
            {
                document.Print();
            }
        }
    }
}
