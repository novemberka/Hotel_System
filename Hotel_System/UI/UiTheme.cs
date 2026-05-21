using FontAwesome.Sharp;
using Guna.UI2.WinForms;
using System.Drawing;
using System.Windows.Forms;

namespace Hotel_System.UI
{
    internal static class UiTheme
    {
        private static readonly HashSet<Control> ResponsiveRoots = new();

        public static readonly Color Sidebar = Color.FromArgb(30, 43, 64);
        public static readonly Color SidebarHover = Color.FromArgb(40, 57, 84);
        public static readonly Color SidebarActive = Color.FromArgb(47, 128, 255);
        public static readonly Color Header = Color.White;
        public static readonly Color PageBackground = Color.FromArgb(238, 243, 251);
        public static readonly Color TextPrimary = Color.FromArgb(31, 42, 62);
        public static readonly Color TextMuted = Color.FromArgb(113, 128, 150);
        public static readonly Color Border = Color.FromArgb(224, 231, 242);
        public static readonly Color InputFill = Color.White;
        public static readonly Color CardShadow = Color.FromArgb(210, 220, 236);
        public static readonly Color CardTint = Color.FromArgb(247, 250, 255);
        public static readonly Color Success = Color.FromArgb(20, 148, 102);
        public static readonly Color Warning = Color.FromArgb(232, 141, 40);
        public static readonly Color Danger = Color.FromArgb(214, 69, 69);
        public static readonly Color Info = Color.FromArgb(14, 116, 144);

        public static readonly Font MenuFont = new("Segoe UI", 10.5F, FontStyle.Bold);
        public static readonly Font TitleFont = new("Segoe UI", 16F, FontStyle.Bold);
        public static readonly Font BodyFont = new("Segoe UI", 10F, FontStyle.Regular);
        public static readonly Font LabelFont = new("Segoe UI Semibold", 9F, FontStyle.Bold);

        public static void StyleSidebarButton(IconButton button)
        {
            button.BackColor = Sidebar;
            button.FlatAppearance.BorderSize = 0;
            button.FlatAppearance.MouseOverBackColor = SidebarHover;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Regular);
            button.ForeColor = Color.FromArgb(232, 238, 248);
            button.IconColor = Color.FromArgb(156, 172, 196);
            button.IconSize = 18;
            button.ImageAlign = ContentAlignment.MiddleLeft;
            button.Padding = new Padding(20, 0, 0, 0);
            button.TextAlign = ContentAlignment.MiddleLeft;
            button.TextImageRelation = TextImageRelation.ImageBeforeText;
        }

        public static void SetSidebarButtonActive(IconButton button, bool isActive)
        {
            button.BackColor = isActive ? SidebarActive : Sidebar;
            button.IconColor = isActive ? Color.White : Color.FromArgb(156, 172, 196);
            button.ForeColor = isActive ? Color.White : Color.FromArgb(232, 238, 248);
            button.Font = new Font("Segoe UI", 9.5F, isActive ? FontStyle.Bold : FontStyle.Regular);
        }

        public static void ApplyPageDesign(Control root)
        {
            root.SuspendLayout();
            root.BackColor = PageBackground;
            root.Font = BodyFont;
            EnableResponsivePage(root);
            StyleChildren(root);
            AddSectionBreathingRoom(root);
            root.ResumeLayout();
        }

        public static void EnableResponsivePage(Control root)
        {
            ConfigureScrollableRoot(root);
            ApplyResponsiveAnchors(root);
            UpdateResponsiveSurface(root);

            if (ResponsiveRoots.Add(root))
            {
                root.Resize += (_, _) => UpdateResponsiveSurface(root);
                root.Disposed += (_, _) => ResponsiveRoots.Remove(root);
            }
        }

        public static void ApplyLoginDesign(Form loginForm, Guna2Panel loginPanel, Guna2GradientButton loginButton)
        {
            loginForm.BackColor = Sidebar;
            loginForm.Text = "Hotel Management System";
            StyleChildren(loginPanel);

            loginPanel.FillColor = Color.FromArgb(255, 255, 255);
            loginPanel.BackColor = Color.Transparent;
            loginPanel.BorderRadius = 18;
            loginPanel.BorderColor = Color.FromArgb(226, 232, 240);
            loginPanel.BorderThickness = 1;

            StyleGradientButton(loginButton, SidebarActive, Color.FromArgb(27, 69, 214));
            loginButton.BorderRadius = 10;
            loginButton.Font = new Font("Segoe UI", 10.5F, FontStyle.Bold);
        }

        private static void StyleChildren(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                StyleControl(child);
                StyleChildren(child);
            }
        }

        private static void AddSectionBreathingRoom(Control parent)
        {
            foreach (Control child in parent.Controls)
            {
                if (child.Dock == DockStyle.Top || child.Dock == DockStyle.Fill || IsResponsivePageSurface(child))
                {
                    AddSectionBreathingRoom(child);
                    continue;
                }

                if (child.Margin == Padding.Empty)
                {
                    child.Margin = new Padding(0, 0, 18, 22);
                }

                AddSectionBreathingRoom(child);
            }
        }

        private static void ConfigureScrollableRoot(Control root)
        {
            if (root is ScrollableControl scrollable && root is not Form)
            {
                scrollable.AutoScroll = true;
                scrollable.AutoScrollMargin = new Size(24, 24);
            }
        }

        private static void ApplyResponsiveAnchors(Control parent)
        {
            Size parentSize = parent.ClientSize;
            if (parentSize.Width <= 0 || parentSize.Height <= 0)
            {
                return;
            }

            foreach (Control child in parent.Controls)
            {
                if (IsResponsivePageSurface(child))
                {
                    ApplyResponsiveAnchors(child);
                    continue;
                }

                if (child.Dock == DockStyle.None)
                {
                    AnchorStyles anchor = child.Anchor | AnchorStyles.Top | AnchorStyles.Left;
                    bool wide = child.Width >= parentSize.Width * 0.55;
                    bool tall = child.Height >= parentSize.Height * 0.40;
                    bool touchesRight = child.Right >= parentSize.Width - 80;
                    bool touchesBottom = child.Bottom >= parentSize.Height - 80;

                    if (child is DataGridView || wide || touchesRight)
                    {
                        anchor |= AnchorStyles.Right;
                    }

                    if (child is DataGridView || tall || touchesBottom)
                    {
                        anchor |= AnchorStyles.Bottom;
                    }

                    child.Anchor = anchor;
                }

                ApplyResponsiveAnchors(child);
            }
        }

        private static void UpdateResponsiveSurface(Control root)
        {
            if (root is ScrollableControl scrollable && root is not Form)
            {
                scrollable.AutoScrollMinSize = CalculateMinimumSurface(root);
            }

            ResizeLargeDirectChildren(root);
        }

        private static Size CalculateMinimumSurface(Control root)
        {
            int right = 0;
            int bottom = 0;

            foreach (Control child in root.Controls)
            {
                if (!child.Visible || child.Dock != DockStyle.None)
                {
                    continue;
                }

                if (IsResponsivePageSurface(child))
                {
                    continue;
                }

                right = Math.Max(right, child.Right);
                bottom = Math.Max(bottom, child.Bottom);
            }

            return new Size(
                Math.Max(0, right + 28),
                Math.Max(0, bottom + 28));
        }

        private static void ResizeLargeDirectChildren(Control root)
        {
            if (root.ClientSize.Width <= 0 || root.ClientSize.Height <= 0)
            {
                return;
            }

            foreach (Control child in root.Controls)
            {
                if (!child.Visible || child.Dock != DockStyle.None)
                {
                    continue;
                }

                bool shouldGrowWidth = child is DataGridView ||
                    child.Width >= 700 ||
                    child.Right >= root.ClientSize.Width - 80;

                if (shouldGrowWidth && root.ClientSize.Width > child.Left + 360)
                {
                    child.Width = Math.Max(320, root.ClientSize.Width - child.Left - 28);
                }

                bool shouldGrowHeight = child is DataGridView ||
                    child.Bottom >= root.ClientSize.Height - 80;

                if (shouldGrowHeight && root.ClientSize.Height > child.Top + 220)
                {
                    child.Height = Math.Max(180, root.ClientSize.Height - child.Top - 28);
                }
            }
        }

        private static void StyleControl(Control control)
        {
            switch (control)
            {
                case Guna2GroupBox groupBox:
                    StyleGroupBox(groupBox);
                    break;
                case Guna2TextBox textBox:
                    StyleTextBox(textBox);
                    break;
                case Guna2ComboBox comboBox:
                    StyleComboBox(comboBox);
                    break;
                case Guna2GradientButton gradientButton:
                    StyleGradientButton(gradientButton, SidebarActive, Color.FromArgb(27, 69, 214));
                    break;
                case Guna2Button button:
                    StyleButton(button);
                    break;
                case Guna2DateTimePicker dateTimePicker:
                    StyleDateTimePicker(dateTimePicker);
                    break;
                case Guna2NumericUpDown numericUpDown:
                    StyleNumericUpDown(numericUpDown);
                    break;
                case Guna2Panel panel:
                    StylePanel(panel);
                    break;
                case Guna2ShadowPanel shadowPanel:
                    StyleShadowPanel(shadowPanel);
                    break;
                case Guna2CheckBox checkBox:
                    StyleCheckBox(checkBox);
                    break;
                case DataGridView dataGridView:
                    StyleDataGrid(dataGridView);
                    break;
                case Label label:
                    StyleLabel(label);
                    break;
                case GroupBox groupBox:
                    StyleGroupBox(groupBox);
                    break;
                case Button button:
                    StyleButton(button);
                    break;
                case RadioButton radioButton:
                    StyleRadioButton(radioButton);
                    break;
                case TabControl tabControl:
                    StyleTabControl(tabControl);
                    break;
                case IconPictureBox icon:
                    icon.BackColor = Color.Transparent;
                    break;
                case PictureBox pictureBox:
                    pictureBox.BackColor = Color.Transparent;
                    break;
            }
        }

        private static bool IsResponsivePageSurface(Control control)
        {
            return control.Tag is string tag && tag == "ResponsivePageSurface";
        }

        private static void StyleGroupBox(Guna2GroupBox groupBox)
        {
            groupBox.BackColor = Color.Transparent;
            groupBox.FillColor = Color.White;
            groupBox.BorderColor = Border;
            groupBox.BorderRadius = 14;
            groupBox.BorderThickness = 1;
            groupBox.CustomBorderColor = Color.White;
            groupBox.CustomBorderThickness = new Padding(0, 40, 0, 0);
            groupBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox.ForeColor = TextPrimary;
            groupBox.Padding = new Padding(26, 56, 26, 24);
            groupBox.AutoScroll = false;
            groupBox.ShadowDecoration.BorderRadius = 14;
            groupBox.ShadowDecoration.Color = CardShadow;
            groupBox.ShadowDecoration.Depth = 8;
            groupBox.ShadowDecoration.Enabled = true;
        }

        private static void StyleGroupBox(GroupBox groupBox)
        {
            groupBox.BackColor = Color.White;
            groupBox.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            groupBox.ForeColor = TextPrimary;
            groupBox.AutoSize = false;
        }

        private static void StyleTextBox(Guna2TextBox textBox)
        {
            textBox.BorderColor = Border;
            textBox.BorderRadius = 8;
            textBox.FillColor = Color.FromArgb(248, 250, 254);
            textBox.Font = BodyFont;
            textBox.ForeColor = TextPrimary;
            textBox.FocusedState.BorderColor = SidebarActive;
            textBox.FocusedState.FillColor = Color.White;
            textBox.HoverState.BorderColor = Color.FromArgb(148, 163, 184);
            textBox.PlaceholderForeColor = Color.FromArgb(148, 163, 184);
            textBox.Cursor = Cursors.IBeam;
        }

        private static void StyleComboBox(Guna2ComboBox comboBox)
        {
            comboBox.BorderColor = Border;
            comboBox.BorderRadius = 8;
            comboBox.FillColor = Color.FromArgb(248, 250, 254);
            comboBox.Font = BodyFont;
            comboBox.ForeColor = TextPrimary;
            comboBox.FocusedState.BorderColor = SidebarActive;
            comboBox.ItemHeight = Math.Max(comboBox.ItemHeight, 30);
            comboBox.Cursor = Cursors.Hand;
        }

        private static void StyleButton(Guna2Button button)
        {
            button.BorderRadius = 8;
            button.FillColor = ButtonColor(button.Text);
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.HoverState.FillColor = Color.FromArgb(33, 103, 223);
            button.Animated = true;
            button.Cursor = Cursors.Hand;
            button.ShadowDecoration.BorderRadius = 8;
            button.ShadowDecoration.Color = Color.FromArgb(214, 225, 240);
            button.ShadowDecoration.Depth = 6;
            button.ShadowDecoration.Enabled = true;
        }

        private static void StyleGradientButton(Guna2GradientButton button, Color fill, Color fill2)
        {
            button.FillColor = fill;
            button.FillColor2 = fill2;
            button.ForeColor = Color.White;
            button.Font = new Font("Segoe UI", 9.5F, FontStyle.Bold);
            button.Animated = true;
            button.Cursor = Cursors.Hand;
        }

        private static void StyleButton(Button button)
        {
            button.BackColor = ButtonColor(button.Text);
            button.FlatAppearance.BorderSize = 0;
            button.FlatStyle = FlatStyle.Flat;
            button.Font = new Font("Segoe UI", 9F, FontStyle.Bold);
            button.ForeColor = Color.White;
            button.UseVisualStyleBackColor = false;
        }

        private static void StyleDateTimePicker(Guna2DateTimePicker dateTimePicker)
        {
            dateTimePicker.BorderColor = Border;
            dateTimePicker.BorderRadius = 8;
            dateTimePicker.Checked = true;
            dateTimePicker.FillColor = Color.FromArgb(248, 250, 254);
            dateTimePicker.Font = BodyFont;
            dateTimePicker.ForeColor = TextPrimary;
        }

        private static void StyleNumericUpDown(Guna2NumericUpDown numericUpDown)
        {
            numericUpDown.BorderColor = Border;
            numericUpDown.BorderRadius = 8;
            numericUpDown.FillColor = Color.FromArgb(248, 250, 254);
            numericUpDown.Font = BodyFont;
            numericUpDown.ForeColor = TextPrimary;
            numericUpDown.UpDownButtonFillColor = SidebarActive;
        }

        private static void StylePanel(Guna2Panel panel)
        {
            panel.BackColor = Color.Transparent;
            panel.FillColor = Color.White;
            panel.BorderColor = Border;
            panel.BorderRadius = Math.Max(panel.BorderRadius, 14);
            panel.BorderThickness = Math.Max(panel.BorderThickness, 1);
            panel.ShadowDecoration.BorderRadius = Math.Max(panel.BorderRadius, 14);
            panel.ShadowDecoration.Color = CardShadow;
            panel.ShadowDecoration.Depth = 8;
            panel.ShadowDecoration.Enabled = true;
        }

        private static void StyleShadowPanel(Guna2ShadowPanel panel)
        {
            panel.BackColor = Color.Transparent;
            panel.FillColor = Color.White;
            panel.Radius = 12;
            panel.ShadowColor = CardShadow;
            panel.Padding = new Padding(Math.Max(panel.Padding.Left, 10));
        }

        private static void StyleCheckBox(Guna2CheckBox checkBox)
        {
            checkBox.BackColor = Color.Transparent;
            checkBox.Font = BodyFont;
            checkBox.ForeColor = TextPrimary;
            checkBox.CheckedState.FillColor = SidebarActive;
            checkBox.UncheckedState.BorderColor = Border;
            checkBox.UncheckedState.FillColor = Color.White;
        }

        private static void StyleRadioButton(RadioButton radioButton)
        {
            radioButton.BackColor = Color.Transparent;
            radioButton.Font = BodyFont;
            radioButton.ForeColor = TextPrimary;
        }

        private static void StyleTabControl(TabControl tabControl)
        {
            tabControl.Font = new Font("Segoe UI Semibold", 10F, FontStyle.Bold);
            tabControl.Multiline = false;
        }

        private static void StyleLabel(Label label)
        {
            if (label.Font.Size <= 10.5F)
            {
                label.Font = LabelFont;
            }

            if (label.ForeColor == Color.Black || label.ForeColor == Color.FromArgb(64, 64, 64))
            {
                label.ForeColor = TextMuted;
            }

            if (label.BackColor == Color.White || label.BackColor == Color.Azure)
            {
                label.BackColor = Color.Transparent;
            }
        }

        private static void StyleDataGrid(DataGridView dataGridView)
        {
            dataGridView.BackgroundColor = Color.White;
            dataGridView.BorderStyle = BorderStyle.None;
            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.ColumnHeadersBorderStyle = DataGridViewHeaderBorderStyle.None;
            dataGridView.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(244, 247, 252);
            dataGridView.ColumnHeadersDefaultCellStyle.ForeColor = TextMuted;
            dataGridView.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI Semibold", 9.5F, FontStyle.Bold);
            dataGridView.ColumnHeadersDefaultCellStyle.Padding = new Padding(14, 0, 8, 0);
            dataGridView.ColumnHeadersHeight = Math.Max(dataGridView.ColumnHeadersHeight, 44);
            dataGridView.DefaultCellStyle.BackColor = Color.White;
            dataGridView.DefaultCellStyle.ForeColor = TextPrimary;
            dataGridView.DefaultCellStyle.Font = BodyFont;
            dataGridView.DefaultCellStyle.Padding = new Padding(14, 0, 8, 0);
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(219, 234, 254);
            dataGridView.DefaultCellStyle.SelectionForeColor = TextPrimary;
            dataGridView.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(249, 252, 255);
            dataGridView.EnableHeadersVisualStyles = false;
            dataGridView.GridColor = Color.FromArgb(235, 240, 247);
            dataGridView.RowHeadersVisible = false;
            dataGridView.RowTemplate.Height = Math.Max(dataGridView.RowTemplate.Height, 46);
            dataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView.AllowUserToAddRows = false;
            dataGridView.AllowUserToResizeRows = false;
            dataGridView.MultiSelect = false;
            if (dataGridView.Dock == DockStyle.None)
            {
                dataGridView.Anchor |= AnchorStyles.Right | AnchorStyles.Bottom;
            }

            dataGridView.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            dataGridView.DefaultCellStyle.SelectionBackColor = Color.FromArgb(231, 241, 255);
        }

        private static Color ButtonColor(string? text)
        {
            string label = text?.ToLowerInvariant() ?? string.Empty;

            if (label.Contains("delete") || label.Contains("cancel"))
            {
                return Danger;
            }

            if (label.Contains("clear") || label.Contains("reset"))
            {
                return TextMuted;
            }

            if (label.Contains("secondary"))
            {
                return Info;
            }

            return SidebarActive;
        }
    }
}
