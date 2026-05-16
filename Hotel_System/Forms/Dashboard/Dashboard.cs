using FontAwesome.Sharp;
using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Dashboard : Form
    {
        private bool _reportExpanded = false;
        private IconButton? _reportBtn;
        private readonly System.Collections.Generic.List<IconButton> _subMenuBtns = new();

        public Dashboard(string fullName, string role, string imgPath)
        {
            InitializeComponent();
            LoadUserControl(new DashboardControl());

            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                guna2CirclePictureBox1.Image = Image.FromFile(imgPath);
        }

        private void LoadUserControl(UserControl uc)
        {
            Content.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            Content.Controls.Add(uc);
        }

        // ── Existing menu handlers ────────────────────────────────────────────

        private void iconButton1_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Booking Management";
            LoadUserControl(new BookingControl());
        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Dashboard";
            LoadUserControl(new DashboardControl());
        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Check-In & Check-Out";
            LoadUserControl(new Checkin_outControl());
        }

        private void room_menu_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Room Management";
            LoadUserControl(new RoomControl());
        }

        private void customer_menu_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Customer Management";
            LoadUserControl(new CustomerControl());
        }

        private void payment_menu_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Payment Management";
            LoadUserControl(new PaymentControl());
        }

        private void logout_menu_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        // ── Report accordion menu ────────────────────────────────────────────

        private void SetupReportMenu()
        {
            const int BTN_H = 55;   // main menu item height (px)
            const int SUB_H = 42;   // sub-item height (px)

            // Remove bottom padding so the table can use the full panel height
            // (logo occupies top 120 px; the rest = 800-120 = 680 px, enough for
            // 8 main rows×55 + 5 sub-rows×42 = 650 px even when fully expanded).
            panel1.Padding = new Padding(0, 120, 0, 0);

            // Switch tableLayoutPanel to manual sizing, placed right below logo.
            tableLayoutPanel1.Dock     = DockStyle.None;
            tableLayoutPanel1.Location = new Point(0, 120);
            tableLayoutPanel1.Width    = panel1.ClientSize.Width;
            tableLayoutPanel1.Anchor   = AnchorStyles.Top | AnchorStyles.Left |
                                         AnchorStyles.Right;

            // Convert all existing % rows → absolute BTN_H px.
            for (int i = 0; i < tableLayoutPanel1.RowStyles.Count; i++)
            {
                tableLayoutPanel1.RowStyles[i].SizeType = SizeType.Absolute;
                tableLayoutPanel1.RowStyles[i].Height   = BTN_H;
            }

            // Expand row count: Report(6) + 5 sub-items(7-11) + Logout(12)
            tableLayoutPanel1.RowCount = 13;
            while (tableLayoutPanel1.RowStyles.Count < 13)
                tableLayoutPanel1.RowStyles.Add(
                    new RowStyle(SizeType.Absolute, BTN_H));

            // Sub-item rows start collapsed.
            for (int i = 7; i <= 11; i++)
                tableLayoutPanel1.RowStyles[i].Height = 0;

            // Move Logout from row 6 → row 12.
            tableLayoutPanel1.SetCellPosition(
                logout_menu, new TableLayoutPanelCellPosition(0, 12));

            // Add Report parent button at row 6.
            _reportBtn = BuildMenuButton("  Report", IconChar.ChartBar);
            tableLayoutPanel1.Controls.Add(_reportBtn, 0, 6);
            _reportBtn.Click += (s, e) => ToggleReportMenu(BTN_H, SUB_H);

            // Add 5 sub-item buttons at rows 7–11 (initially hidden).
            (string Label, IconChar Icon, Action Nav)[] subs =
            {
                ("      Booking Report",
                    IconChar.BookOpen,
                    () => NavigateReport(new Report_Booking(),  "Booking Report")),
                ("      CheckIn/CheckOut",
                    IconChar.CalendarDay,
                    () => NavigateReport(new Report_CheckOut(), "CheckIn / CheckOut Report")),
                ("      Customer Report",
                    IconChar.Users,
                    () => NavigateReport(new Report_Customer(), "Customer Report")),
                ("      Payment Report",
                    IconChar.MoneyBill,
                    () => NavigateReport(new Report_Payment(),  "Payment Report")),
                ("      Room Report",
                    IconChar.Bed,
                    () => NavigateReport(new Reportroom(),      "Room Report")),
            };

            _subMenuBtns.Clear();
            for (int i = 0; i < subs.Length; i++)
            {
                var btn = BuildSubMenuButton(subs[i].Label, subs[i].Icon);
                btn.Visible = false;
                var nav = subs[i].Nav;
                btn.Click += (s, e) => nav();
                tableLayoutPanel1.Controls.Add(btn, 0, 7 + i);
                _subMenuBtns.Add(btn);
            }

            RefreshTableHeight();
        }

        private void ToggleReportMenu(int btnH, int subH)
        {
            _reportExpanded = !_reportExpanded;

            if (_reportBtn != null)
                _reportBtn.Text = _reportExpanded ? "  Report  ▲" : "  Report";

            for (int row = 7; row <= 11; row++)
                tableLayoutPanel1.RowStyles[row].Height = _reportExpanded ? subH : 0;

            foreach (var btn in _subMenuBtns)
                btn.Visible = _reportExpanded;

            tableLayoutPanel1.PerformLayout();
            RefreshTableHeight();
        }

        private void RefreshTableHeight()
        {
            int total = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount &&
                             i < tableLayoutPanel1.RowStyles.Count; i++)
                total += (int)tableLayoutPanel1.RowStyles[i].Height;

            tableLayoutPanel1.Height = total;
        }

        private void NavigateReport(UserControl uc, string title)
        {
            lblTittle.Text = title;
            LoadUserControl(uc);
        }

        // ── Button factory helpers ────────────────────────────────────────────

        private static IconButton BuildMenuButton(string text, IconChar icon)
        {
            var btn = new IconButton
            {
                Text                    = text,
                IconChar                = icon,
                BackColor               = Color.MidnightBlue,
                ForeColor               = Color.White,
                IconColor               = Color.White,
                IconFont                = IconFont.Auto,
                IconSize                = 30,
                ImageAlign              = ContentAlignment.MiddleLeft,
                TextImageRelation       = TextImageRelation.ImageBeforeText,
                Padding                 = new Padding(8, 0, 0, 0),
                Margin                  = new Padding(8),
                Font                    = new Font("Segoe UI", 10F),
                FlatStyle               = FlatStyle.Flat,
                Dock                    = DockStyle.Fill,
                UseVisualStyleBackColor = false,
                TextAlign               = ContentAlignment.MiddleLeft,
                Cursor                  = Cursors.Hand,
            };
            btn.FlatAppearance.BorderSize          = 0;
            btn.FlatAppearance.MouseOverBackColor  =
                Color.FromArgb(40, 60, 150);
            return btn;
        }

        private static IconButton BuildSubMenuButton(string text, IconChar icon)
        {
            var btn = new IconButton
            {
                Text                    = text,
                IconChar                = icon,
                BackColor               = Color.FromArgb(15, 32, 100),
                ForeColor               = Color.LightSteelBlue,
                IconColor               = Color.LightSteelBlue,
                IconFont                = IconFont.Auto,
                IconSize                = 20,
                ImageAlign              = ContentAlignment.MiddleLeft,
                TextImageRelation       = TextImageRelation.ImageBeforeText,
                Padding                 = new Padding(20, 0, 0, 0),
                Margin                  = new Padding(0),
                Font                    = new Font("Segoe UI", 9F),
                FlatStyle               = FlatStyle.Flat,
                Dock                    = DockStyle.Fill,
                UseVisualStyleBackColor = false,
                TextAlign               = ContentAlignment.MiddleLeft,
                Cursor                  = Cursors.Hand,
            };
            btn.FlatAppearance.BorderSize          = 0;
            btn.FlatAppearance.MouseOverBackColor  =
                Color.FromArgb(30, 55, 140);
            return btn;
        }

        // ── Lifecycle ────────────────────────────────────────────────────────

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);

            SetupReportMenu();
        }

        private void profile_Paint(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);
        }

        private void tableLayoutPanel1_Paint(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, EventArgs e) { }
        private void contentPanel_Paint(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, EventArgs e) { }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, EventArgs e) { }
    }
}
