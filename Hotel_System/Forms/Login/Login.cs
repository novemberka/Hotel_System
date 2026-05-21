using System.Drawing.Drawing2D;
using Hotel_System.UI;
using Hotel_System.Properties.Config;
using Microsoft.Data.SqlClient;

namespace Hotel_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
            ApplyLoginDesign();
        }

        private void ApplyLoginDesign()
        {
            BackColor = Color.FromArgb(232, 245, 254);
            Text = "Hotel Management System";
            AcceptButton = btnlogin;
            MinimumSize = new Size(920, 620);
            closeButton.Visible = false;
            minimizeButton.Visible = false;
            WindowChrome.AddWindowButtons(this, this, Close, top: 16, right: 14);
            Resize += (_, _) => CenterLoginCard();

            mainCard.BackColor = Color.Transparent;
            mainCard.FillColor = Color.White;
            mainCard.BorderRadius = 16;

            guna2Panel1.FillColor = Color.White;
            guna2Panel1.BackColor = Color.White;

            lbLogin.Text = "Welcome back";
            lbLogin.Font = new Font("Segoe UI", 18F, FontStyle.Bold);
            lbLogin.ForeColor = Color.FromArgb(24, 31, 42);

            lbusername.ForeColor = Color.FromArgb(45, 55, 72);
            label2.ForeColor = Color.FromArgb(45, 55, 72);
            linkForgotpassword.LinkColor = Color.FromArgb(24, 96, 190);
            linkForgotpassword.ActiveLinkColor = Color.FromArgb(5, 91, 181);
            linkForgotpassword.BackColor = Color.Transparent;

            txtusername.PlaceholderText = "Enter username";
            txtpassword.PlaceholderText = "Enter password";
            txtusername.FillColor = Color.FromArgb(239, 244, 254);
            txtpassword.FillColor = Color.FromArgb(239, 244, 254);
            txtusername.BorderThickness = 0;
            txtpassword.BorderThickness = 0;
            txtusername.BorderRadius = 8;
            txtpassword.BorderRadius = 8;

            btnlogin.Text = "Sign In";
            btnlogin.BorderRadius = 8;
            btnlogin.FillColor = Color.FromArgb(31, 126, 220);
            btnlogin.FillColor2 = Color.FromArgb(5, 91, 181);
            btnlogin.Font = new Font("Segoe UI", 10F, FontStyle.Bold);

            guna2PictureBox1.BackColor = Color.Transparent;
            guna2PictureBox1.FillColor = Color.Transparent;
            heroIconCircle.Image = CreateHotelBadge();
            heroIconCircle.SizeMode = PictureBoxSizeMode.CenterImage;
            CenterLoginCard();
        }

        private void CenterLoginCard()
        {
            mainCard.Location = new Point(
                Math.Max(24, (ClientSize.Width - mainCard.Width) / 2),
                Math.Max(58, (ClientSize.Height - mainCard.Height) / 2));
        }

        private static Bitmap CreateHotelBadge()
        {
            Bitmap bitmap = new(72, 72);
            using Graphics graphics = Graphics.FromImage(bitmap);
            graphics.SmoothingMode = SmoothingMode.AntiAlias;
            graphics.Clear(Color.Transparent);

            using SolidBrush blue = new(Color.FromArgb(19, 111, 211));
            using Pen bluePen = new(Color.FromArgb(19, 111, 211), 4)
            {
                StartCap = LineCap.Round,
                EndCap = LineCap.Round
            };

            graphics.FillRectangle(blue, 22, 18, 28, 42);
            graphics.FillRectangle(blue, 12, 34, 48, 26);
            graphics.FillRectangle(Brushes.White, 29, 45, 14, 15);

            for (int x = 27; x <= 42; x += 15)
            {
                graphics.FillRectangle(Brushes.White, x, 25, 6, 6);
                graphics.FillRectangle(Brushes.White, x, 35, 6, 6);
            }

            graphics.DrawLine(bluePen, 16, 34, 36, 14);
            graphics.DrawLine(bluePen, 56, 34, 36, 14);
            return bitmap;
        }




        private void Login_Load(object sender, EventArgs e)
        {
           // txtusername.Text = txtpassword.Text;
            txtpassword.PasswordChar = '*';

        }



        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }

            try
            {
                DbConnection db = new DbConnection();
                using (SqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT TOP 1 FullName, Role, ImagePath FROM admins WHERE Username=@username AND Password=@password";
                    using SqlCommand cmd = new SqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string fullName = reader["FullName"]?.ToString() ?? "Hotel Admin";
                        string role = reader["Role"]?.ToString() ?? "Administrator";
                        string imgPath = reader["ImagePath"] != DBNull.Value
                            ? reader["ImagePath"]?.ToString() ?? string.Empty
                            : string.Empty;

                        Dashboard dashboard = new(fullName, role, imgPath);
                        WindowChrome.MatchWindow(this, dashboard);
                        dashboard.Show();
                        Hide();
                    }
                    else
                    {
                        MessageBox.Show("Invalid username or password!");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void lable1_Click_1(object sender, EventArgs e) { }

        private void txtpassword_TextChanged(object sender, EventArgs e) { }
        private void label7_Click(object sender, EventArgs e) { }
        private void label6_Click(object sender, EventArgs e) { }
        private void label8_Click(object sender, EventArgs e) { }
        private void guna2Panel1_Paint(object sender, PaintEventArgs e) { }
        private void guna2Panel1_Paint_1(object sender, PaintEventArgs e) { }
        private void guna2PictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void guna2TextBox1_TextChanged(object sender, EventArgs e) { }
        // Event handler referenced by Login.Designer.cs for the circle picture box
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e) { }
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }
        // Event handler referenced by Login.Designer.cs for the forgot-password link
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) { }

        // Added missing event handlers referenced by Login.Designer.cs
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}

