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

        public Dashboard()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.None;
            this.WindowState = FormWindowState.Maximized;



        }
        private void LoadUserControl(UserControl uc)
        {
            Content.Controls.Clear();
            uc.Dock = DockStyle.Fill;
            Content.Controls.Add(uc);
        }


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



        private void SetupReportMenu()
        {
            const int BTN_H = 53;
            const int SUB_H = 42;

            // Defensive: ensure required controls exist
            if (tableLayoutPanel1 == null || panel1 == null)
                return;

            if (report_menu != null)
            {
                _reportBtn = report_menu;
                _reportBtn.Click += (s, e) => ToggleReportMenu(BTN_H, SUB_H);
            }

            _subMenuBtns.Clear();
            // Add only non-null submenu buttons
            if (report_booking != null) _subMenuBtns.Add(report_booking);
            if (report_checkinout != null) _subMenuBtns.Add(report_checkinout);
            if (report_customer != null) _subMenuBtns.Add(report_customer);
            if (report_payment != null) _subMenuBtns.Add(report_payment);
            if (report_room != null) _subMenuBtns.Add(report_room);

            if (report_booking != null)
                report_booking.Click += (s, e) => NavigateReport(new Report_Booking(), "Booking Report");
            if (report_checkinout != null)
                report_checkinout.Click += (s, e) => NavigateReport(new Report_CheckInCheckOut(), "CheckIn / CheckOut Report");
            if (report_customer != null)
                report_customer.Click += (s, e) => NavigateReport(new Report_Customer(), "Customer Report");
            if (report_payment != null)
                report_payment.Click += (s, e) => NavigateReport(new Report_Payment(), "Payment Report");
            if (report_room != null)
                report_room.Click += (s, e) => NavigateReport(new Reportroom(), "Room Report");

            tableLayoutPanel1.Width = panel1.ClientSize.Width;
            RefreshTableHeight();
        }

        private void ToggleReportMenu(int btnH, int subH)
        {
            _reportExpanded = !_reportExpanded;

            if (_reportBtn != null)
                _reportBtn.Text = _reportExpanded ? "  Report  ▲" : "  Report";

            // Only update row styles that exist
            if (tableLayoutPanel1 != null)
            {
                for (int row = 7; row <= 11; row++)
                {
                    if (row < tableLayoutPanel1.RowStyles.Count)
                        tableLayoutPanel1.RowStyles[row].Height = _reportExpanded ? subH : 0;
                }
            }

            foreach (var btn in _subMenuBtns)
                btn.Visible = _reportExpanded;

            tableLayoutPanel1.PerformLayout();
            RefreshTableHeight();
        }

        private void RefreshTableHeight()
        {
            if (tableLayoutPanel1 == null)
                return;

            int total = 0;
            for (int i = 0; i < tableLayoutPanel1.RowCount &&
                             i < tableLayoutPanel1.RowStyles.Count; i++)
            {
                total += (int)tableLayoutPanel1.RowStyles[i].Height;
            }

            tableLayoutPanel1.Height = total;
        }

        private void NavigateReport(UserControl uc, string title)
        {
            lblTittle.Text = title;
            LoadUserControl(uc);
        }


        private void Dashboard_Load(object sender, EventArgs e)
        {
            try
            {
                if (profile != null)
                {
                    GraphicsPath gp = new GraphicsPath();
                    gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
                    profile.Region = new Region(gp);
                }

                SetupReportMenu();
            }
            catch (Exception ex)
            {
                // Surface a friendly message but don't crash the whole form
                MessageBox.Show("Dashboard initialization error: " + ex.Message);
            }
        }


        private void tableLayoutPanel1_Paint(object sender, EventArgs e) { }
        private void panel3_Paint(object sender, EventArgs e) { }
        private void contentPanel_Paint(object sender, EventArgs e) { }
        private void pictureBox2_Click(object sender, EventArgs e) { }
        private void panel2_Paint(object sender, EventArgs e) { }
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }
        private void panel1_Paint(object sender, EventArgs e) { }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Minimized;
        }

        private void lblTittle_Click(object sender, EventArgs e)
        {

        }

        private void logout_menu_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show(
        "Are you sure you want to logout?",
        "Logout Confirmation",
        MessageBoxButtons.YesNo,
        MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                Login login = new Login();
                login.Show();

                this.Hide();
            }

        }
    }
}
