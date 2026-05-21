using Hotel_System.Properties.Config;
using Hotel_System.Services;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Hotel_System.Models;
using Hotel_System.Report;
using Hotel_System.UI;


namespace Hotel_System
{

    public partial class CustomerControl : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();
        private bool _suppressPhoneLookup;
        private readonly RadioButton rbOther = new()
        {
            AutoSize = true,
            BackColor = Color.Transparent,
            Text = "Other"
        };

        public CustomerControl()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            WireLookupEvents();

        }

        private void BuildModernLayout()
        {
            txtCustomerID.PlaceholderText = "Auto ID";
            txtCustomerID.ReadOnly = true;
            txtFullName.PlaceholderText = "Enter full name";
            txtPhone.PlaceholderText = "Enter phone number";
            txtEmail.PlaceholderText = "Enter email";
            txtAddress.PlaceholderText = "Enter address";
            txtIDCard.PlaceholderText = "Enter ID card number";

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 4;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 560F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            page.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Customer Directory",
                "Register guests, update contact details, and keep the customer list clean and easy to review.",
                "Guest Profiles",
                ResponsiveFormLayout.CreateReportButton((_, _) =>
                    ReportLauncher.ShowForm(this, () => new Customer_Report(), "Customer Report"))), 0, 0);

            var fields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(fields, 0, 0, FullNameLabel, txtCustomerID);
            ResponsiveFormLayout.AddField(fields, 1, 0, label3, txtFullName);
            ResponsiveFormLayout.AddField(fields, 2, 0, genderLbl, ResponsiveFormLayout.Inline(rbMale, rbFemale, rbOther));
            ResponsiveFormLayout.AddField(fields, 3, 0, label2, txtPhone);
            ResponsiveFormLayout.AddField(fields, 4, 0, label1, txtEmail);
            ResponsiveFormLayout.AddField(fields, 5, 0, label4, txtAddress);
            ResponsiveFormLayout.AddField(fields, 6, 0, label5, txtIDCard);
            ResponsiveFormLayout.FillCard(CustomerInfo, fields, "Customer Information");

            page.Controls.Add(CustomerInfo, 0, 1);
            Add.Visible = false;
            page.Controls.Add(ResponsiveFormLayout.ActionBar(Update, Delete), 0, 2);

            ResponsiveFormLayout.ConfigureGrid(dataGridView1);
            ResponsiveFormLayout.DockGrid(CustomerList, dataGridView1, "Customer List");
            page.Controls.Add(CustomerList, 0, 3);

            ResponsiveFormLayout.Install(this, page, 980, 1140);
        }

        private void WireLookupEvents()
        {
            txtPhone.Leave += (_, _) => TryAutoFillCustomerFromPhone();
            txtPhone.KeyDown += TxtPhone_KeyDown;
        }

        private void TxtPhone_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            TryAutoFillCustomerFromPhone();
        }

        private void TryAutoFillCustomerFromPhone()
        {
            if (_suppressPhoneLookup)
            {
                return;
            }

            string phone = txtPhone.Text.Trim();
            if (phone.Length < 6)
            {
                return;
            }

            try
            {
                Customer? customer = _customerService.FindByPhone(phone);
                if (customer == null)
                {
                    return;
                }

                _suppressPhoneLookup = true;
                txtCustomerID.Text = customer.CustomerID > 0 ? customer.CustomerID.ToString() : string.Empty;
                txtFullName.Text = customer.FullName;
                txtPhone.Text = customer.Phone;
                txtEmail.Text = customer.Email;
                txtAddress.Text = customer.Address;
                txtIDCard.Text = customer.IDCardNumber;
                rbMale.Checked = customer.Gender.Equals("Male", StringComparison.OrdinalIgnoreCase);
                rbFemale.Checked = customer.Gender.Equals("Female", StringComparison.OrdinalIgnoreCase);
                rbOther.Checked = customer.Gender.Equals("Other", StringComparison.OrdinalIgnoreCase);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Phone lookup failed: " + ex.Message);
            }
            finally
            {
                _suppressPhoneLookup = false;
            }
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void CustomerControl_Load(object sender, EventArgs e)
        {
            RefreshGrid();

        }
        private void RefreshGrid()
        {
            try
            {
                // Prevent duplicate columns as seen in Screenshot 2026-04-26 160453.png
                dataGridView1.AutoGenerateColumns = false;
                dataGridView1.DataSource = _customerService.GetCustomerList();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void lblGust_Enter(object sender, EventArgs e)
        {

        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void lbGust_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void CustomerInfo_Click(object sender, EventArgs e)
        {

        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                // Mapping UI fields to the Model
                var newCustomer = new Customer
                {
                    FullName = txtFullName.Text,
                    Gender = SelectedGender(),
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
            // Check if an ID is actually selected (referencing Screenshot 2026-04-26 145136.png)
            if (!int.TryParse(txtCustomerID.Text, out int id))
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
            if (!int.TryParse(txtCustomerID.Text, out int customerId))
            {
                MessageBox.Show("Please select a customer from the list first.");
                return;
            }

            try
            {
                var updatedCustomer = new Customer
                {
                    CustomerID = customerId,
                    FullName = txtFullName.Text,
                    Gender = SelectedGender(),
                    Phone = txtPhone.Text,
                    Email = txtEmail.Text,
                    Address = txtAddress.Text,
                    IDCardNumber = txtIDCard.Text
                };

                // Execute the update through the service layer
                if (_customerService.UpdateCustomer(updatedCustomer))
                {
                    MessageBox.Show("Customer updated successfully!");
                    RefreshGrid(); // Refresh the DataGridView from Screenshot 2026-04-26 160453.png
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

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void genderLbl_Click(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
                if (row.IsNewRow)
                {
                    return;
                }

                txtCustomerID.Text = CellText(row, "CustomerID");
                txtFullName.Text = CellText(row, "FullName");

                string gender = CellText(row, "Gender");
                rbMale.Checked = (gender == "Male");
                rbFemale.Checked = (gender == "Female");
                rbOther.Checked = (gender == "Other");

                txtPhone.Text = CellText(row, "Phone");
                txtEmail.Text = CellText(row, "Email");
                txtAddress.Text = CellText(row, "Address");
                txtIDCard.Text = CellText(row, "IDCardNumber");
            }
        }

        private static string CellText(DataGridViewRow row, string columnName)
        {
            return row.DataGridView?.Columns.Contains(columnName) == true
                ? row.Cells[columnName].Value?.ToString() ?? string.Empty
                : string.Empty;
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

        private string SelectedGender()
        {
            if (rbFemale.Checked)
            {
                return "Female";
            }

            if (rbOther.Checked)
            {
                return "Other";
            }

            return "Male";
        }

        private void CustomerList_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {

        }

        private void iconPictureBox4_Click(object sender, EventArgs e)
        {

        }
    }
}

