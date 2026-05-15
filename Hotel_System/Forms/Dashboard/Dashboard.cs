using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Dashboard : Form
    {
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
            LoadUserControl(new Report_Booking());
        }

        private void logout_menu_Click(object sender, EventArgs e)
        {
            Login login = new Login();
            login.Show();
            this.Hide();
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);
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
