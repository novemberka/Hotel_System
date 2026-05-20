using Hotel_System.Models;
using Hotel_System.PrintForms;
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

            dtpBookingDate.Value = DateTime.Now;
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now;
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
                cmbRoom.DataSource = null;
                cmbRoom.Items.Clear();
                cmbRoom.Items.Add("No Rooms Available");
                cmbRoom.SelectedIndex = 0;
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
                    Status = "Pending",
                    CreatedByAdminID = 1
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
            // 1. Unsubscribe to prevent event triggers
            cmbCustomer.SelectedIndexChanged -= cmbCustomer_SelectedIndexChanged;
            cmbRoom.SelectedIndexChanged -= cmbRoom_SelectedIndexChanged;

            // 2. Clear TextBoxes
            txtBookingID.Clear();
            txtPhoneNumber.Clear();
            txtAddress.Clear();
            txtEmail.Clear();
            txtIDCardNumber.Clear();

            // 3. Reset ComboBoxes (The aggressive way)
            // Store the data source, null it, reset it.
            var customerDS = cmbCustomer.DataSource;
            cmbCustomer.DataSource = null;
            cmbCustomer.DataSource = customerDS;
            cmbCustomer.DisplayMember = "FullName";
            cmbCustomer.ValueMember = "CustomerID";
            cmbCustomer.SelectedIndex = -1;

            var roomDS = cmbRoom.DataSource;
            cmbRoom.DataSource = null;
            cmbRoom.DataSource = roomDS;
            cmbRoom.DisplayMember = "FullRoomName";
            cmbRoom.ValueMember = "RoomID";
            cmbRoom.SelectedIndex = -1;

            // 4. Dates
            dtpCheckIn.Value = DateTime.Now;
            dtpCheckOut.Value = DateTime.Now.AddDays(1);

            // 5. Re-subscribe
            cmbCustomer.SelectedIndexChanged += cmbCustomer_SelectedIndexChanged;
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
                        LoadAvailableRooms();
                        ClearForm();
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
            // 1. Clear the UI first
            ClearForm();

            // 2. Refresh the Grid
            RefreshGrid();

            // 3. IMPORTANT: Tell the grid to stop selecting the first row automatically
            dataGridViewBookings.ClearSelection();
            if (dataGridViewBookings.CurrentRow != null)
            {
                // This stops the 'CurrencyManager' from forcing a selection
                dataGridViewBookings.CurrentCell = null;
            }
        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            if (dataGridViewBookings.CurrentRow == null)
            {
                MessageBox.Show("Please select a booking first.");
                return;
            }

            // Get the ID from the selected row
            int bookingId = Convert.ToInt32(dataGridViewBookings.CurrentRow.Cells["BookingID"].Value);

            // Pass the ID to the form
            InvoiceBooking invoiceForm = new InvoiceBooking(bookingId);
            invoiceForm.ShowDialog();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
