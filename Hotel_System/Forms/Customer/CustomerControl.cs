using Hotel_System.Models;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class CustomerControl : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();

        public CustomerControl()
        {
            InitializeComponent();
        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            RefreshGrid();
        }

        private void RefreshGrid()
        {
            try
            {
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _customerService.GetCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                var newCustomer = new Customer
                {
                    FullName = txtFullName.Text,
                    Gender = rbMale.Checked ? "Male" : "Female",
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    IDCardNumber = txtIDCard.Text
                };

                if (_customerService.AddCustomer(newCustomer))
                {
                    MessageBox.Show("Customer saved successfully!");
                    RefreshGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer from the list to delete.");
                return;
            }

            var confirmResult = MessageBox.Show("Are you sure to delete this customer?",
                                                "Confirm Delete",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    int id = int.Parse(txtCustomerID.Text);
                    if (_customerService.DeleteCustomer(id))
                    {
                        MessageBox.Show("Customer deleted successfully!");
                        RefreshGrid();
                        ClearFields();
                    }
                    else
                    {
                        MessageBox.Show("Delete failed. The record might no longer exist.");
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Error: " + ex.Message);
                }
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtCustomerID.Text))
            {
                MessageBox.Show("Please select a customer from the list first.");
                return;
            }

            try
            {
                var updatedCustomer = new Customer
                {
                    CustomerID = int.Parse(txtCustomerID.Text),
                    FullName = txtFullName.Text,
                    Gender = rbMale.Checked ? "Male" : "Female",
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    IDCardNumber = txtIDCard.Text
                };

                if (_customerService.UpdateCustomer(updatedCustomer))
                {
                    MessageBox.Show("Customer updated successfully!");
                    RefreshGrid();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Update failed. Please check your data.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                txtCustomerID.Text = row.Cells["CustomerID"].Value?.ToString() ?? "";
                txtFullName.Text = row.Cells["FullName"].Value?.ToString() ?? "";

                string gender = row.Cells["Gender"].Value?.ToString() ?? "";
                rbMale.Checked = (gender == "Male");
                rbFemale.Checked = (gender == "Female");

                txtPhone.Text = row.Cells["Phone"].Value?.ToString() ?? "";
                txtEmail.Text = row.Cells["Email"].Value?.ToString() ?? "";
                txtAddress.Text = row.Cells["Address"].Value?.ToString() ?? "";
                txtIDCard.Text = row.Cells["IDCardNumber"].Value?.ToString() ?? "";
            }
        }

        private void ClearFields()
        {
            txtCustomerID.Clear();
            txtFullName.Clear();
            txtPhone.Clear();
            txtEmail.Clear();
            txtAddress.Clear();
            txtIDCard.Clear();
            rbMale.Checked = true;
        }

        private void panel1_Paint(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void lblGust_Enter(object sender, EventArgs e) { }
        private void textBox6_TextChanged(object sender, EventArgs e) { }
        private void guna2TextBox5_TextChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void lbGust_Click(object sender, EventArgs e) { }
        private void label4_Click(object sender, EventArgs e) { }
        private void CustomerInfo_Click(object sender, EventArgs e) { }
        private void guna2Button2_Click(object sender, EventArgs e) { }
        private void radioButton2_CheckedChanged(object sender, EventArgs e) { }
        private void genderLbl_Click(object sender, EventArgs e) { }
        private void CustomerList_Enter(object sender, EventArgs e) { }
        private void guna2TextBox4_TextChanged(object sender, EventArgs e) { }
        private void radioButton1_CheckedChanged(object sender, EventArgs e) { }
        private void label2_Click(object sender, EventArgs e) { }
        private void groupBox1_Enter(object sender, EventArgs e) { }
        private void guna2Button1_Click(object sender, EventArgs e) { }
        private void iconPictureBox4_Click(object sender, EventArgs e) { }
    }
}
