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

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;

            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
                guna2CirclePictureBox1.Image = Image.FromFile(imgPath);
        }

        private void LoadUserControl(UserControl uc)
        {
            Content.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            Content.Controls.Add(uc);
        }

        // ── Menu handlers ────────────────────────────────────────────────────

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
            const int BTN_H = 53;
            const int SUB_H = 42;

            _reportBtn = report_menu;
            _reportBtn.Click += (s, e) => ToggleReportMenu(BTN_H, SUB_H);

            _subMenuBtns.Clear();
            _subMenuBtns.Add(report_booking);
            _subMenuBtns.Add(report_checkinout);
            _subMenuBtns.Add(report_customer);
            _subMenuBtns.Add(report_payment);
            _subMenuBtns.Add(report_room);

            report_booking.Click    += (s, e) => NavigateReport(new Report_Booking(),  "Booking Report");
            report_checkinout.Click += (s, e) => NavigateReport(new Report_CheckOut(), "CheckIn / CheckOut Report");
            report_customer.Click   += (s, e) => NavigateReport(new Report_Customer(), "Customer Report");
            report_payment.Click    += (s, e) => NavigateReport(new Report_Payment(),  "Payment Report");
            report_room.Click       += (s, e) => NavigateReport(new Reportroom(),      "Room Report");

            tableLayoutPanel1.Width = panel1.ClientSize.Width;
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
