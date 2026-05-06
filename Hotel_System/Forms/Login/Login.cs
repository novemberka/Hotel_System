using System.Drawing.Drawing2D;
using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;

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
           // txtusername.Text = txtpassword.Text;
            txtpassword.PasswordChar = '*';

        }



        private void btnlogin_Click(object sender, EventArgs e)
        {
            string username = txtusername.Text.Trim();
            string password = txtpassword.Text.Trim();

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter username and password!");
                return;
            }

            try
            {
                DbConnection db = new DbConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    string query = "SELECT * FROM admins WHERE Username=@username AND Password=@password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        string fullName = reader["FullName"].ToString();
                        string role = reader["Role"].ToString();
                        string imgPath = reader["ImagePath"] != DBNull.Value
                                              ? reader["ImagePath"].ToString() : null;
                        reader.Close();

                        Report_Customer_Form reportForm = new Report_Customer_Form();
                        reportForm.Show();
                        this.Hide();
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
