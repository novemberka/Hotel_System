using Hotel_System.Models;
using Hotel_System.Services;
using Org.BouncyCastle.Asn1.Cmp;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class BookingControl : UserControl
    {
        private readonly BookingService _bookingService = new BookingService();
        public BookingControl()
        {
            InitializeComponent();
            dataGridViewBookings.CellClick += dataGridViewBookings_CellClick;
        }
        private void RefreshGrid()
        {
            var dt = _bookingService.GetBookingList();

            dataGridViewBookings.Columns.Clear(); // VERY IMPORTANT
            dataGridViewBookings.AutoGenerateColumns = true;
            dataGridViewBookings.DataSource = dt;
            // Apply Date-Only format (MM/dd/yyyy or dd/MM/yyyy based on your region)
            dataGridViewBookings.Columns["CheckInDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewBookings.Columns["CheckOutDate"].DefaultCellStyle.Format = "yyyy-MM-dd";

            // Optional: Apply it to BookingDate as well
            if (dataGridViewBookings.Columns.Contains("BookingDate"))
                dataGridViewBookings.Columns["BookingDate"].DefaultCellStyle.Format = "yyyy-MM-dd";
            dataGridViewBookings.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void BookingControl_Load(object sender, EventArgs e)
        {
            LoadCustomers();
            LoadAvailableRooms();
            RefreshGrid();
        }
        private void LoadCustomers()
        {
            // 1. Unsubscribe temporarily to prevent errors while loading
            cmbCustomer.SelectedIndexChanged -= cmbCustomer_SelectedIndexChanged;

            try
            {
                DataTable dt = _bookingService.GetCustomerList();

                if (dt != null && dt.Rows.Count > 0)
                {
                    cmbCustomer.DataSource = dt;
                    cmbCustomer.DisplayMember = "FullName"; // What the user sees
                    cmbCustomer.ValueMember = "CustomerID"; // The ID for the database

                    cmbCustomer.SelectedIndex = -1; // Start with nothing selected
                }
            }
            finally
            {
                // 2. Re-subscribe so the event works when the user clicks
                cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
            }
        }
        // Logic to fill top section based on selection 
        private void cmbCustomer_SelectedIndexChanged(object sender, EventArgs e)
        {
            // If the user hasn't selected anything yet, stop here
            if (cmbCustomer.SelectedIndex == -1) return;

            // Cast the SelectedItem to a DataRowView to access the hidden columns
            if (cmbCustomer.SelectedItem is DataRowView row)
            {
                try
                {
                    // CRITICAL: These names must match your SQL SELECT EXACTLY (Case Sensitive)
                    txtPhoneNumber.Text = row["Phone"]?.ToString();
                    txtAddress.Text = row["Address"]?.ToString();
                    txtEmail.Text = row["Email"]?.ToString();
                    txtIDCardNumber.Text = row["IDCardNumber"]?.ToString();
                }
                catch (Exception ex)
                {
                    // This will pop up if you typed a column name wrong (e.g., "Address" vs "address")
                    MessageBox.Show("Column missing: " + ex.Message);
                }
            }
        }
        private void cmbRoom_SelectedIndexChanged(object sender, EventArgs e)
        {
            // 1. If we are clearing (Index -1), stop immediately
            if (cmbRoom.SelectedIndex == -1) return;

            try
            {
                // 2. Just verify the selection is valid
                if (cmbRoom.SelectedItem is DataRowView row)
                {
                 
                }
            }
            catch { /* Ignore errors during clear */ }
        }
        private void LoadAvailableRooms()
        {
            DataTable dt = _bookingService.GetAvailableRoomList();

            if (dt != null && dt.Rows.Count > 0)
            {
                // 1. Clear any old data
                cmbRoom.DataSource = null;

                // 2. Set the "How to show it" properties FIRST
                cmbRoom.DisplayMember = "FullRoomName";
                cmbRoom.ValueMember = "RoomID";

                // 3. Attach the data LAST
                cmbRoom.DataSource = dt;

                cmbRoom.SelectedIndex = -1;
            }
            else
            {
                // If this pops up, your SQL query found 0 available rooms
                MessageBox.Show("No rooms with 'Available' status found in database!");
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                Booking newBooking = new Booking
                {
                    CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue),
                    RoomID = Convert.ToInt32(cmbRoom.SelectedValue),
                    BookingDate = DateTime.Now,
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Status = "Confirmed",
                    CreatedByAdminID = 1 // Hardcoded for now
                };

                if (_bookingService.CreateBooking(newBooking))
                {
                    MessageBox.Show("Booking successful!");
                    RefreshGrid();
                    LoadAvailableRooms();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message); // This will now show the detailed MySQL error
            }
        }
        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(txtBookingID.Text))
                {
                    MessageBox.Show("Please select a booking from the list first.");
                    return;
                }
                string currentStatus = dataGridViewBookings.CurrentRow.Cells["Status"].Value.ToString();
                // Create the update object INCLUDING the selected RoomID
                Booking updatedBooking = new Booking
                {
                    BookingID = int.Parse(txtBookingID.Text),
                    CustomerID = Convert.ToInt32(cmbCustomer.SelectedValue),
                    RoomID = Convert.ToInt32(cmbRoom.SelectedValue),
                    CheckInDate = dtpCheckIn.Value,
                    CheckOutDate = dtpCheckOut.Value,
                    Status = currentStatus // Uses the value from the grid
                };

                if (_bookingService.UpdateBooking(updatedBooking))
                {
                    MessageBox.Show("Booking updated successfully!");
                    RefreshGrid();
                    LoadAvailableRooms();
                    ClearForm();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }

        }
        private void dataGridViewBookings_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0) return;

            DataGridViewRow row = dataGridViewBookings.Rows[e.RowIndex];

            txtBookingID.Text = row.Cells["BookingID"].Value?.ToString();

            cmbCustomer.SelectedValue = row.Cells["CustomerID"].Value;
            cmbRoom.SelectedValue = row.Cells["RoomID"].Value;

            dtpBookingDate.Value = Convert.ToDateTime(row.Cells["BookingDate"].Value);
            dtpCheckIn.Value = Convert.ToDateTime(row.Cells["CheckInDate"].Value);
            dtpCheckOut.Value = Convert.ToDateTime(row.Cells["CheckOutDate"].Value);

        }
        
        private void ClearForm()
        {
            // 1. Stop the event from firing
            cmbRoom.SelectedIndexChanged -= cmbRoom_SelectedIndexChanged;

            // 2. Force the UI to clear the 'Text' part of the combo
            cmbRoom.SelectedIndex = -1;
            cmbRoom.Text = string.Empty;
            cmbRoom.SelectedItem = null;

            // 3. Clear everything else
            txtBookingID.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtIDCardNumber.Clear();

            cmbCustomer.SelectedIndex = -1;
            cmbCustomer.Text = "";

            // 4. Re-attach the event
            cmbRoom.SelectedIndexChanged += cmbRoom_SelectedIndexChanged;
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            // 1. Validation: Ensure a row is selected
            if (dataGridViewBookings.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking to cancel.");
                return;
            }

            // 2. Get the IDs from the DataGridView cells
            int bID = Convert.ToInt32(dataGridViewBookings.CurrentRow.Cells["BookingID"].Value);
            int rID = Convert.ToInt32(dataGridViewBookings.CurrentRow.Cells["RoomID"].Value);
            string currentStatus = dataGridViewBookings.CurrentRow.Cells["Status"].Value.ToString();

            // 3. Logic Check: Don't cancel if already cancelled or completed
            if (currentStatus == "Cancelled" || currentStatus == "Complete")
            {
                MessageBox.Show("This booking is already " + currentStatus + ".");
                return;
            }

            // 4. Confirmation Dialog
            var confirm = MessageBox.Show("Are you sure you want to cancel this booking?",
                                        "Confirm Cancellation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (_bookingService.CancelBooking(bID, rID))
                    {
                        MessageBox.Show("Booking cancelled and room released successfully.");
                        RefreshGrid(); // Refresh the list
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: " + ex.Message);
                }
            }
        }

        private void btnclear_Click(object sender, EventArgs e)
        {
            ClearForm();
            RefreshGrid();
        }
    }
}
