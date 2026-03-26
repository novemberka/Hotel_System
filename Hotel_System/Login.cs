using System.Drawing.Drawing2D;

namespace Hotel_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }




        private void Login_Load(object sender, EventArgs e)
        {
            txtusername.Text = txtpassword.Text;
            txtpassword.PasswordChar = '*';

        }


        private void btnlogin_Click(object sender, EventArgs e)
        {
            // Intentional: event handler stub. Implement login logic here.
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();
            if (string.IsNullOrEmpty(username))
            {
                MessageBox.Show("Please enter your username.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtusername.Focus();
                return;
            }

            if (string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter your password.",
                    "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtpassword.Focus();
                return;
            }
        }
        private void LoginSuccess(string username = "")
        {
            MessageBox.Show($"Welcome{(string.IsNullOrEmpty(username) ? "" : ", " + username)}!",
                "Login Successful", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Dashboard dashboard = new Dashboard();
            dashboard.Show();
            this.Hide();
        }
        private void LoginFailed()
        {
            MessageBox.Show("Invalid username or password. Please try again.",
                "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
            txtpassword.Clear();
            txtpassword.Focus();
        }
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

            MessageBox.Show("Please contact the system administrator to reset your password.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);


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
        private void label1_Click_1(object sender, EventArgs e) { }
        private void label2_Click_1(object sender, EventArgs e) { }

        // Added missing event handlers referenced by Login.Designer.cs
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }

        private void iconButton1_Click(object sender, EventArgs e)
        {

        }
    }
}
