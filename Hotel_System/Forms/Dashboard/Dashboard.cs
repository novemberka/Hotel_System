using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Hotel_System
{
    public partial class Dashboard : Form
    {
        private void LoadUserControl(UserControl uc)
        {
            Content.Controls.Clear();  // Remove previous page
            uc.Dock = DockStyle.Fill;   // Fill the panel
            Content.Controls.Add(uc); // Add new page
        }
        public Dashboard(string fullName, string role, string imgPath)
        {
            InitializeComponent();
            // Load default page
            LoadUserControl(new DashboardControl());

            if (!string.IsNullOrEmpty(imgPath) && File.Exists(imgPath))
            {
                guna2CirclePictureBox1.Image = Image.FromFile(imgPath);
            }
            //else
            //{
            //    // Optional: default image
            //    guna2CirclePictureBox1.Image = Properties.Resources.default_user;
            //}
        }


        


        private void iconButton1_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Booking Management";
            LoadUserControl(new BookingControl());
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {


        }

        private void iconButton4_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Check-In & Check_Out";
            LoadUserControl(new Checkin_outControl());
        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void contentPanel_Paint(object sender, PaintEventArgs e)
        {

        }

        private void iconButton2_Click(object sender, EventArgs e)
        {
            lblTittle.Text = "Dashboard";
            LoadUserControl(new DashboardControl());
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

        private void pictureBox2_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void profile_Paint(object sender, PaintEventArgs e)
        {
            GraphicsPath gp = new GraphicsPath();
            gp.AddEllipse(0, 0, profile.Width - 1, profile.Height - 1);
            profile.Region = new Region(gp);
        }

        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
