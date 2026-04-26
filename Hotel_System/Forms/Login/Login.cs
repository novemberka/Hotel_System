using System;
using System.Drawing;
using System.Drawing.Drawing2D;

using System.IO;
using System.Windows.Forms;

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
            txtusername.Text = txtpassword.Text;
            txtpassword.PasswordChar = '*';

            try
            {
               
                string appDataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "HotelSystem"
                );


                if (Directory.Exists(appDataFolder))
                {
                    var files = Directory.GetFiles(appDataFolder, "profile_picture.*");
                    if (files.Length > 0)
                    {
                        try
                        {
                            boxProfile.Image = Image.FromFile(files[0]);
                        }
                        catch
                        {
                            // ignore and continue with default image
                        }
                    }
                }
            }
            catch
            {
                // ignore any errors loading a saved profile picture
            }
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
                // Create connection from your DbConnection class
                DbConnection db = new DbConnection();
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();

                    // Parameterized query (safe)
                    string query = "SELECT * FROM admins WHERE Username=@username AND Password=@password";
                    MySqlCommand cmd = new MySqlCommand(query, conn);
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    MySqlDataReader reader = cmd.ExecuteReader();

                    if (reader.Read())
                    {
                        // Successful login
                        string fullName = reader["FullName"].ToString();
                        string role = reader["Role"].ToString();

                        MessageBox.Show($"Welcome {fullName} ({role})!");

                        // Open Dashboard form or main app
                        Dashboard dashboard = new Dashboard();
                        dashboard.Show();
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


            if(username == "admin" && password == "admin")
            {
                LoginSuccess(username);
            }
            else
            {
                LoginFailed();
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
        private void guna2CirclePictureBox1_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp;*.gif";
                openFileDialog.FilterIndex = 1;
                openFileDialog.RestoreDirectory = true;

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        string selectedFilePath = openFileDialog.FileName;
                        Image selectedImage = Image.FromFile(selectedFilePath);

                        // Set the image to the CirclePictureBox
                        boxProfile.Image = selectedImage;

                        // Optional: Save the image path to user settings or database
                        SaveProfilePicture(selectedFilePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Failed to load image: {ex.Message}",
                            "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void SaveProfilePicture(string imagePath)
        {
            try
            {
                // Optionally persist the chosen path in user settings if available.
                // The project may not include a Settings class, so skip that step here.
                string appDataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "HotelSystem"
                );

                if (!Directory.Exists(appDataFolder))
                    Directory.CreateDirectory(appDataFolder);

                string destinationPath = Path.Combine(appDataFolder, "profile_picture" +
                    Path.GetExtension(imagePath));

                File.Copy(imagePath, destinationPath, overwrite: true);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Could not save profile picture: {ex.Message}",
                    "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }



        // Removed duplicate SaveProfilePicture overload (kept single implementation above)

        // Designer event handler stubs (one copy each)

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
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void iconButton1_Click(object sender, EventArgs e) { }

    }

}
