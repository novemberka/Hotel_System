using Hotel_System.Properties.Config;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TheArtOfDevHtmlRenderer.Adapters;

namespace Hotel_System
{
    public partial class RoomControl : UserControl
    {
        public RoomControl()
        {
            InitializeComponent();
        }
        private void LoadRoomData()
        {
            dataGridView2.AutoGenerateColumns = false;
            DbConnection db = new DbConnection();
            string query = "SELECT CustomerID, FullName, Gender, Phone, Email, Address, IDCardNumber FROM customers";

            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlDataAdapter adapter = new MySqlDataAdapter(query, conn))
                    {
                        DataTable dt = new DataTable();
                        adapter.Fill(dt);
                        dataGridView2.DataSource = dt; // Binds DB data to the UI grid
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void RoomControl_Load(object sender, EventArgs e)
        {
            LoadRoomData();
        }

        private void Delete_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            DbConnection db = new DbConnection();

            // Notice: customer_id is NOT in the list of columns or values anymore
            string query = "INSERT INTO rooms (RoomID, RoomName, RoomType, Price, Status) " +
                           "VALUES (@id, @name, @type, @price, @status)";
            try
            {
                using (MySqlConnection conn = db.GetConnection())
                {
                    conn.Open();
                    using (MySqlCommand cmd = new MySqlCommand(query, conn))
                    {
                        // We skip txtCustomerID.Text entirely
                        //cmd.Parameters.AddWithValue("@name", txtFullName.Text);
                        //cmd.Parameters.AddWithValue("@gender", rbMale.Checked ? "Male" : "Female");
                        //cmd.Parameters.AddWithValue("@phone", txtPhone.Text);
                        //cmd.Parameters.AddWithValue("@email", txtEmail.Text);
                        //cmd.Parameters.AddWithValue("@address", txtAddress.Text);
                        //cmd.Parameters.AddWithValue("@idcard", txtIDCard.Text);

                        cmd.ExecuteNonQuery();

                        MessageBox.Show("Room saved!");

                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
}
