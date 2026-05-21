using Guna.UI2.WinForms;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.UI
{
    internal static class ResponsiveFormLayout
    {
        private const int PagePadding = 36;
        private static readonly Color BannerBlue = Color.FromArgb(31, 126, 220);
        private static readonly Color BannerBlueSoft = Color.FromArgb(230, 241, 255);

        public static TableLayoutPanel CreatePage()
        {
            return new TableLayoutPanel
            {
                BackColor = UiTheme.PageBackground,
                ColumnCount = 1,
                Location = new Point(PagePadding, 30),
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                Tag = "ResponsivePageSurface"
            };
        }

        public static Guna2Panel CreateBanner(string title, string subtitle, string accent, Control? actionButton = null)
        {
            Guna2Panel banner = new()
            {
                BackColor = Color.Transparent,
                BorderColor = Color.FromArgb(223, 232, 244),
                BorderRadius = 16,
                BorderThickness = 1,
                Dock = DockStyle.Fill,
                FillColor = Color.White,
                Margin = new Padding(0, 0, 18, 22),
                MinimumSize = new Size(0, 132),
                Padding = new Padding(28, 24, 28, 24),
                ShadowDecoration =
                {
                    BorderRadius = 16,
                    Color = Color.FromArgb(215, 224, 238),
                    Depth = 10,
                    Enabled = true
                }
            };
            banner.Resize += (_, _) =>
            {
                banner.Height = Math.Max(banner.Height, 132);
            };

            TableLayoutPanel layout = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 2,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, actionButton == null ? 160F : 178F));

            TableLayoutPanel textStack = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                RowCount = 2
            };
            textStack.RowStyles.Add(new RowStyle(SizeType.Absolute, 42F));
            textStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            Label titleLabel = new()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 15.5F, FontStyle.Bold),
                ForeColor = UiTheme.TextPrimary,
                Text = title,
                TextAlign = ContentAlignment.MiddleLeft
            };

            Label subtitleLabel = new()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 9.5F),
                ForeColor = UiTheme.TextMuted,
                Text = subtitle,
                TextAlign = ContentAlignment.TopLeft
            };

            Guna2Panel accentPanel = new()
            {
                BackColor = Color.Transparent,
                BorderRadius = 12,
                Dock = actionButton == null ? DockStyle.Right : DockStyle.Fill,
                FillColor = BannerBlueSoft,
                Margin = Padding.Empty,
                Size = new Size(136, 74)
            };

            Label accentLabel = new()
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10.5F, FontStyle.Bold),
                ForeColor = BannerBlue,
                Text = accent,
                TextAlign = ContentAlignment.MiddleCenter
            };

            accentPanel.Controls.Add(accentLabel);
            textStack.Controls.Add(titleLabel, 0, 0);
            textStack.Controls.Add(subtitleLabel, 0, 1);
            layout.Controls.Add(textStack, 0, 0);

            if (actionButton == null)
            {
                layout.Controls.Add(accentPanel, 1, 0);
            }
            else
            {
                actionButton.Dock = DockStyle.Fill;
                actionButton.Margin = new Padding(0, 0, 0, 10);
                actionButton.MinimumSize = new Size(150, 42);

                TableLayoutPanel actionStack = new()
                {
                    BackColor = Color.Transparent,
                    ColumnCount = 1,
                    Dock = DockStyle.Fill,
                    Margin = Padding.Empty,
                    RowCount = 2
                };
                actionStack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
                actionStack.RowStyles.Add(new RowStyle(SizeType.Absolute, 52F));
                actionStack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
                actionStack.Controls.Add(actionButton, 0, 0);
                actionStack.Controls.Add(accentPanel, 0, 1);
                layout.Controls.Add(actionStack, 1, 0);
            }

            banner.Controls.Add(layout);
            return banner;
        }

        public static Guna2Button CreateReportButton(EventHandler clickHandler)
        {
            Guna2Button button = new()
            {
                Animated = true,
                BorderRadius = 10,
                FillColor = UiTheme.SidebarActive,
                Font = new Font("Segoe UI", 9.5F, FontStyle.Bold),
                ForeColor = Color.White,
                Text = "Print Report"
            };
            button.Click += clickHandler;
            return button;
        }

        public static TableLayoutPanel CreateCardStack(params Control[] cards)
        {
            TableLayoutPanel stack = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                RowCount = cards.Length
            };
            stack.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));

            for (int i = 0; i < cards.Length; i++)
            {
                stack.RowStyles.Add(new RowStyle(SizeType.Percent, 100F / Math.Max(1, cards.Length)));
                stack.Controls.Add(cards[i], 0, i);
            }

            return stack;
        }

        public static void Install(ScrollableControl root, TableLayoutPanel page, int minimumWidth, int minimumHeight)
        {
            root.SuspendLayout();
            root.AutoScroll = true;
            root.HorizontalScroll.Enabled = false;
            root.HorizontalScroll.Visible = false;
            root.BackColor = UiTheme.PageBackground;
            root.Padding = Padding.Empty;
            root.Controls.Clear();
            root.Controls.Add(page);

            void ResizePage()
            {
                int width = Math.Max(minimumWidth, root.ClientSize.Width - (PagePadding * 2));
                int height = Math.Max(
                    Math.Max(minimumHeight, Math.Max(RequiredHeight(page), PreferredHeight(page))),
                    root.ClientSize.Height - 52);
                page.Size = new Size(width, height);
                root.AutoScrollMinSize = new Size(page.Right + PagePadding, page.Bottom + PagePadding);
            }

            root.Resize -= RootResize;
            root.Resize += RootResize;
            ResizePage();
            root.ResumeLayout();

            void RootResize(object? sender, EventArgs e) => ResizePage();
        }

        public static TableLayoutPanel Columns(params float[] widths)
        {
            var layout = new TableLayoutPanel
            {
                BackColor = Color.Transparent,
                ColumnCount = widths.Length,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                RowCount = 1
            };

            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            foreach (float width in widths)
            {
                layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, width));
            }

            return layout;
        }

        public static TableLayoutPanel Rows(params RowStyle[] styles)
        {
            var layout = new TableLayoutPanel
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = Padding.Empty,
                RowCount = styles.Length
            };

            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            foreach (RowStyle style in styles)
            {
                layout.RowStyles.Add(style);
            }

            return layout;
        }

        public static TableLayoutPanel FieldGrid(int pairs = 2, int labelWidth = 145)
        {
            var grid = new TableLayoutPanel
            {
                BackColor = Color.Transparent,
                ColumnCount = pairs * 2,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = new Padding(14, 12, 14, 8)
            };

            for (int i = 0; i < pairs; i++)
            {
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Absolute, labelWidth));
                grid.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F / pairs));
            }

            return grid;
        }

        public static void AddField(TableLayoutPanel grid, int row, int pair, Label label, Control editor)
        {
            EnsureRows(grid, row + 1);
            NormalizeLabel(label);
            NormalizeEditor(editor);

            int column = pair * 2;
            grid.Controls.Add(label, column, row);
            grid.Controls.Add(editor, column + 1, row);
        }

        public static void AddWide(TableLayoutPanel grid, int row, Label label, Control editor)
        {
            EnsureRows(grid, row + 1);
            NormalizeLabel(label);
            NormalizeEditor(editor);

            grid.Controls.Add(label, 0, row);
            grid.Controls.Add(editor, 1, row);
            grid.SetColumnSpan(editor, Math.Max(1, grid.ColumnCount - 1));
        }

        public static FlowLayoutPanel Inline(params Control[] controls)
        {
            var flow = new FlowLayoutPanel
            {
                AutoSize = false,
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = Padding.Empty,
                Padding = new Padding(0, 4, 0, 0),
                WrapContents = true
            };

            foreach (Control control in controls)
            {
                control.Margin = new Padding(0, 2, 22, 2);
                flow.Controls.Add(control);
            }

            return flow;
        }

        public static FlowLayoutPanel ActionBar(params Control[] buttons)
        {
            var bar = new FlowLayoutPanel
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                FlowDirection = FlowDirection.LeftToRight,
                Margin = Padding.Empty,
                Padding = new Padding(0, 10, 0, 0),
                WrapContents = true
            };

            foreach (Control button in buttons)
            {
                button.Margin = new Padding(0, 0, 16, 8);
                button.MinimumSize = new Size(124, 42);
                button.Size = new Size(Math.Max(button.Width, 124), 44);
                bar.Controls.Add(button);
            }

            return bar;
        }

        public static void FillCard(Control card, Control content, string? title = null)
        {
            PrepareCard(card, title);
            card.Controls.Clear();
            bool useScrollViewport = content is ScrollableControl scrollable && scrollable.AutoScroll;

            content.Dock = useScrollViewport ? DockStyle.Fill : DockStyle.Top;
            content.Margin = Padding.Empty;
            content.Anchor = useScrollViewport
                ? AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right
                : AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;

            if (!useScrollViewport && content is TableLayoutPanel table)
            {
                table.AutoSize = true;
                table.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }
            else if (!useScrollViewport && content is FlowLayoutPanel flow)
            {
                flow.AutoSize = true;
                flow.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            }

            card.Controls.Add(content);
            if (!useScrollViewport)
            {
                LayoutCardContent(card, content);
                card.Resize += (_, _) => LayoutCardContent(card, content);
            }
        }

        public static void DockGrid(GroupBox card, DataGridView grid, string? title = null)
        {
            PrepareCard(card, title);
            card.Controls.Clear();
            grid.Dock = DockStyle.Fill;
            grid.Margin = Padding.Empty;
            grid.ScrollBars = ScrollBars.Both;
            card.Padding = new Padding(10, 28, 10, 10);
            card.Controls.Add(grid);
        }

        public static void PrepareCard(Control card, string? title = null)
        {
            card.Dock = DockStyle.Fill;
            card.Margin = new Padding(0, 0, 18, 22);
            card.MinimumSize = new Size(260, 120);

            if (!string.IsNullOrWhiteSpace(title))
            {
                card.Text = title;
            }

            if (card is Guna2GroupBox gunaGroup)
            {
                gunaGroup.AutoScroll = true;
                gunaGroup.Padding = new Padding(26, 56, 26, 24);
            }
            else if (card is GroupBox groupBox)
            {
                groupBox.Padding = new Padding(18, 36, 18, 18);
            }
        }

        public static void ConfigureGrid(DataGridView grid)
        {
            grid.Dock = DockStyle.Fill;
            grid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            grid.RowHeadersVisible = false;
            grid.ScrollBars = ScrollBars.Both;
        }

        private static void EnsureRows(TableLayoutPanel grid, int count)
        {
            while (grid.RowCount < count)
            {
                grid.RowCount++;
                grid.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            }
        }

        private static int RequiredHeight(TableLayoutPanel page)
        {
            int height = page.Padding.Vertical;

            foreach (RowStyle style in page.RowStyles)
            {
                if (style.SizeType == SizeType.Absolute)
                {
                    height += (int)Math.Ceiling(style.Height);
                }
            }

            return height + 80;
        }

        private static int PreferredHeight(Control control)
        {
            int bottom = control.Padding.Vertical;

            foreach (Control child in control.Controls)
            {
                if (!child.Visible)
                {
                    continue;
                }

                bottom = Math.Max(bottom, child.Bottom + child.Margin.Bottom);
            }

            return bottom + 40;
        }

        private static void LayoutCardContent(Control card, Control content)
        {
            int width = Math.Max(220, card.ClientSize.Width - card.Padding.Horizontal - 6);
            content.Location = new Point(card.Padding.Left, card.Padding.Top);
            content.Width = width;

            Size preferred = content.GetPreferredSize(new Size(width, 0));
            if (preferred.Height > 0)
            {
                content.Height = preferred.Height;
            }
        }

        private static void NormalizeLabel(Label label)
        {
            label.AutoSize = false;
            label.Dock = DockStyle.Fill;
            label.Margin = new Padding(0, 6, 14, 6);
            label.TextAlign = ContentAlignment.MiddleLeft;
        }

        private static void NormalizeEditor(Control editor)
        {
            editor.Dock = DockStyle.Fill;
            editor.Margin = new Padding(0, 8, 10, 8);
            editor.MinimumSize = new Size(160, 38);

            if (editor is Guna2TextBox textBox)
            {
                textBox.BorderRadius = 8;
            }
            else if (editor is Guna2ComboBox comboBox)
            {
                comboBox.BorderRadius = 8;
                comboBox.ItemHeight = Math.Max(comboBox.ItemHeight, 30);
            }
            else if (editor is Guna2DateTimePicker picker)
            {
                picker.BorderRadius = 8;
            }
            else if (editor is Guna2NumericUpDown numeric)
            {
                numeric.BorderRadius = 8;
            }
        }
    }
}
