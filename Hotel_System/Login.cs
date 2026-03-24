using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.IO;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();
        }
<<<<<<< HEAD
=======




>>>>>>> 445b99bcfe4e84349f3c85d532352d6ca27b264b
        private void Login_Load(object sender, EventArgs e)
        {
            txtusername.Text = txtpassword.Text;
            txtpassword.PasswordChar = '*';
<<<<<<< HEAD
            try
            {
               
                string appDataFolder = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "HotelSystem"
                );
=======
>>>>>>> 445b99bcfe4e84349f3c85d532352d6ca27b264b

                if (Directory.Exists(appDataFolder))
                {
                    var files = Directory.GetFiles(appDataFolder, "profile_picture.*");
                    if (files.Length > 0)
                    {
                        try
                        {
                            guna2CirclePictureBox1.Image = Image.FromFile(files[0]);
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
<<<<<<< HEAD
            if(username == "admin" && password == "admin")
            {
                LoginSuccess(username);
            }
            else
            {
                LoginFailed();
            }
=======
>>>>>>> 445b99bcfe4e84349f3c85d532352d6ca27b264b
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
<<<<<<< HEAD
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
                        guna2CirclePictureBox1.Image = selectedImage;

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

        private void iconButton1_Click(object sender, EventArgs e)
=======
>>>>>>> 445b99bcfe4e84349f3c85d532352d6ca27b264b
        {

            MessageBox.Show("Please contact the system administrator to reset your password.",
                "Forgot Password", MessageBoxButtons.OK, MessageBoxIcon.Information);

<<<<<<< HEAD
=======

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

>>>>>>> 445b99bcfe4e84349f3c85d532352d6ca27b264b
        }
    }

