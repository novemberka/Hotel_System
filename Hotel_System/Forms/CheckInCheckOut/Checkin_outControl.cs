using Hotel_System.Models;
using Hotel_System.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class Checkin_outControl : UserControl
    {
        private CheckinCheckoutService _checkInService = new CheckinCheckoutService();
        private bool isClearing = false;
        public Checkin_outControl()
        {
            InitializeComponent();
            dataGridViewCheckInCheckOut.CellClick += dataGridViewCheckInCheckOut_CellClick;
        }

        // Helper to reliably obtain BookingID from the combo box
        private int? GetSelectedBookingID()
        {
            try
            {
                if (cmbBookingID.SelectedValue != null)
                {
                    // If it's a DataRowView, try to pull the BookingID field
                    if (cmbBookingID.SelectedValue is System.Data.DataRowView drv)
                    {
                        if (drv.Row.Table.Columns.Contains("BookingID"))
                            return Convert.ToInt32(drv["BookingID"]);
                    }

                    // Otherwise try direct conversion
                    return Convert.ToInt32(cmbBookingID.SelectedValue);
                }

                // Fallback to parsing the text
                if (!string.IsNullOrWhiteSpace(cmbBookingID.Text) &&
                    int.TryParse(cmbBookingID.Text, out int parsed))
                {
                    return parsed;
                }
            }
            catch
            {
                // ignore and return null
            }

            return null;
        }
        private void LoadOperationGrid()
        {
            try
            {
                DataTable dt = _checkInService.GetAllOperations();

                // Prevent duplicate columns
                dataGridViewCheckInCheckOut.Columns.Clear();

                // Auto generate fresh columns
                dataGridViewCheckInCheckOut.AutoGenerateColumns = true;

                // Load data
                dataGridViewCheckInCheckOut.DataSource = dt;

                // UI
                dataGridViewCheckInCheckOut.AutoSizeColumnsMode =
                    DataGridViewAutoSizeColumnsMode.Fill;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void Checkin_outControl_Load(object sender, EventArgs e)
        {
            LoadBookingIDs();
            LoadOperationGrid();
        }
        private void btnCheckIn_Click(object sender, EventArgs e)
        {
            // Ensure a booking is selected
            int? selId = GetSelectedBookingID();
            if (!selId.HasValue)
            {
                MessageBox.Show("Please select Booking ID");
                return;
            }

            // Normalize and check status
            if (!string.IsNullOrWhiteSpace(txtStatus.Text) &&
                txtStatus.Text.Trim().Equals("CheckIn", StringComparison.OrdinalIgnoreCase))
            {
                MessageBox.Show("Guest already checked in.");
                return;
            }

            try
            {
                CheckIn ci = new CheckIn()
                {
                    BookingID = selId.Value,
                    CustomerID = txtCustomer.Tag == null ? 0 : Convert.ToInt32(txtCustomer.Tag),
                    RoomID = txtRoom.Tag == null ? 0 : Convert.ToInt32(txtRoom.Tag),
                    CheckInDate = CheckInDate.Value,
                    CreatedByAdminID = 1
                };

                bool success = _checkInService.PerformCheckIn(ci);

                if (success)
                {
                    MessageBox.Show("Check-In Successful");
                    LoadOperationGrid(); // Update the list first
                    LoadBookingIDs();    // Refresh the dropdown
                    btnClear_Click(null, null); // Clear the fields so they don't look "stuck"
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void LoadBookingIDs()
        {

            try
            {
                isClearing = true;

                DataTable dt = _checkInService.GetPendingIDs();


                cmbBookingID.DataSource = null;

                cmbBookingID.DisplayMember = "BookingID";
                cmbBookingID.ValueMember = "BookingID";
                cmbBookingID.DataSource = dt;

                cmbBookingID.SelectedIndex = -1;

                isClearing = false;
            }
            catch (Exception ex)
            {
                isClearing = false;
                MessageBox.Show(ex.Message);
            }
        }
        private void cmbBookingID_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (isClearing)
                return;

            try
            {
                // Ensure item selected
                if (cmbBookingID.SelectedIndex == -1)
                    return;

                // Prevent DataRowView error
                if (cmbBookingID.SelectedValue == null)
                    return;

                if (cmbBookingID.SelectedValue is DataRowView)
                    return;

                // Get Booking ID
                int selectedID = Convert.ToInt32(cmbBookingID.SelectedValue);

                // Load booking details
                DataTable dt = _checkInService.GetBookingDetails(selectedID);

                // No data found
                if (dt.Rows.Count == 0)
                {
                    MessageBox.Show("No booking details found.");
                    return;
                }

                DataRow row = dt.Rows[0];

                // Load customer
                txtCustomer.Text = row["FullName"].ToString();

                // Load room
                txtRoom.Text = row["RoomNumber"].ToString();

                // Load status
                txtStatus.Text = row["Status"].ToString();

                // Load price
                txtPricePerNight.Text = row["PricePerNight"].ToString();

                // Load dates
                CheckInDate.Value = Convert.ToDateTime(row["CheckInDate"]);
                CheckOutDate.Value = Convert.ToDateTime(row["CheckOutDate"]);

                // Store hidden IDs
                txtCustomer.Tag = row["CustomerID"];
                txtRoom.Tag = row["RoomID"];

                // Calculate total
                CalculateTotalPrice();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        private void CalculateTotalPrice()
        {
            if (decimal.TryParse(txtPricePerNight.Text, out decimal price))
            {
                TimeSpan duration = CheckOutDate.Value.Date - CheckInDate.Value.Date;
                int days = duration.Days <= 0 ? 1 : duration.Days; // Minimum 1 night

                txtTotalPrice.Text = (price * days).ToString("N2"); // Format with 2 decimals
            }
        }
        private void dataGridViewCheckInCheckOut_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (e.RowIndex < 0)
                    return;

                DataGridViewRow row = dataGridViewCheckInCheckOut.Rows[e.RowIndex];

                // Get booking id and select it in the combo so SelectedValue/Index are correct
                int bookingID = Convert.ToInt32(row.Cells["BookingID"].Value);
                try
                {
                    cmbBookingID.SelectedValue = bookingID;
                }
                catch
                {
                    // If DataSource isn't loaded or selection fails, fall back to setting Text
                    cmbBookingID.Text = bookingID.ToString();
                }

                txtCustomer.Text = row.Cells["Customer"].Value.ToString();

                txtRoom.Text = row.Cells["Room"].Value.ToString();

                CheckInDate.Value =
                    Convert.ToDateTime(row.Cells["CheckInDate"].Value);

                CheckOutDate.Value =
                    Convert.ToDateTime(row.Cells["CheckOutDate"].Value);

                txtTotalPrice.Text =
                    row.Cells["TotalPrice"].Value.ToString();

                txtStatus.Text =
                    row.Cells["Status"].Value.ToString();

                DataTable dt = _checkInService.GetBookingDetails(bookingID);

                if (dt.Rows.Count > 0)
                {
                    txtPricePerNight.Text = dt.Rows[0]["PricePerNight"].ToString();

                    txtCustomer.Tag = dt.Rows[0]["CustomerID"];
                    txtRoom.Tag = dt.Rows[0]["RoomID"];
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnCheckOut_Click(object sender, EventArgs e)
        {
            try
            {
                int? selId = GetSelectedBookingID();
                if (!selId.HasValue)
                {
                    MessageBox.Show("Please select booking.");
                    return;
                }

                if (txtRoom.Tag == null)
                {
                    MessageBox.Show("Room information missing.");
                    return;
                }

                // 1. Check if already checked out
                if (!string.IsNullOrWhiteSpace(txtStatus.Text) &&
                    txtStatus.Text.Trim().Equals("CheckOut", StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("Guest already checked out.");
                    return;
                }

                // 2. Prepare data for the new repository signature
                int bookingID = selId.Value;
                int roomID = Convert.ToInt32(txtRoom.Tag);

                // Parse Total Price from the textbox
                decimal totalAmount = 0;
                decimal.TryParse(txtTotalPrice.Text, out totalAmount);

                // Current Admin ID (Set this to your logged-in user ID, or 1 for testing)
                int adminID = 1;

                // 3. Call the UPDATED service method
                bool success = _checkInService.PerformCheckOut(bookingID, roomID, totalAmount, adminID);

                if (success)
                {
                    MessageBox.Show("Check-Out Successful and Record Saved.");
                    LoadOperationGrid();
                    LoadBookingIDs();
                    btnClear_Click(null, null);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("UI Error: " + ex.Message);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            isClearing = true;

            cmbBookingID.SelectedIndex = -1;

            txtCustomer.Clear();
            txtRoom.Clear();
            txtStatus.Clear();
            txtPricePerNight.Clear();
            txtTotalPrice.Clear();

            txtCustomer.Tag = null;
            txtRoom.Tag = null;

            CheckInDate.Value = DateTime.Now;
            CheckOutDate.Value = DateTime.Now;

            isClearing = false;
        }

        
    }
}
