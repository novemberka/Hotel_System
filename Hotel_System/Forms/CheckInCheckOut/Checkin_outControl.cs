using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Hotel_System.Models;
using Hotel_System.Report;
using Hotel_System.Services;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class Checkin_outControl : UserControl
    {
        private readonly CustomerService _customerService = new CustomerService();
        private readonly RoomService _roomService = new RoomService();
        private readonly CheckInService _checkInService = new CheckInService();
        private bool _suppressPhoneLookup;
        private int _currentBookingId;
        private string _currentBookingStatus = string.Empty;

        public Checkin_outControl()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            ConfigureLookupInputs();
            LoadRoomTypeChoices();
        }

        private void BuildModernLayout()
        {
            guna2TextBox12.PlaceholderText = "Customer name";
            guna2TextBox9.PlaceholderText = "ID / passport";
            guna2TextBox13.PlaceholderText = "Phone number";
            guna2TextBox2.PlaceholderText = "Sub total";
            guna2TextBox3.PlaceholderText = "Discount";
            guna2TextBox1.PlaceholderText = "Total price";
            guna2TextBox11.PlaceholderText = "Deposit";
            guna2TextBox10.PlaceholderText = "Remaining";

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 4;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 760F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 500F));
            page.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Check-In / Check-Out",
                "Keep the same workflow while making guest verification, stay totals, and payment follow-up easier to scan.",
                "Front Desk",
                ResponsiveFormLayout.CreateReportButton((_, _) =>
                    ReportLauncher.ShowReportChooser(
                        this,
                        "Front Desk Reports",
                        ("Check-In Report", () => new Checkin_Report()),
                        ("Check-Out Report", () => new Checkout_Report())))), 0, 0);

            var guestFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(guestFields, 0, 0, label10, guna2TextBox12);
            ResponsiveFormLayout.AddField(guestFields, 1, 0, label15, guna2TextBox13);
            ResponsiveFormLayout.AddField(guestFields, 2, 0, label9, guna2TextBox9);
            ResponsiveFormLayout.AddField(guestFields, 3, 0, label12, guna2ComboBox5);
            ResponsiveFormLayout.AddField(guestFields, 4, 0, label14, guna2ComboBox3);
            ResponsiveFormLayout.AddField(guestFields, 5, 0, label3, guna2DateTimePicker3);
            ResponsiveFormLayout.AddField(guestFields, 6, 0, label6, guna2DateTimePicker4);
            ResponsiveFormLayout.AddField(guestFields, 7, 0, label11, guna2TextBox2);
            ResponsiveFormLayout.AddField(guestFields, 8, 0, label5, guna2TextBox3);
            ResponsiveFormLayout.AddField(guestFields, 9, 0, label4, guna2TextBox1);
            ResponsiveFormLayout.FillCard(guna2GroupBox1, guestFields, "Customer / Stay Information");
            page.Controls.Add(guna2GroupBox1, 0, 1);

            var paymentFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(paymentFields, 0, 0, label1, guna2ComboBox4);
            ResponsiveFormLayout.AddField(paymentFields, 1, 0, label7, guna2TextBox11);
            ResponsiveFormLayout.AddField(paymentFields, 2, 0, label2, guna2TextBox10);
            ResponsiveFormLayout.FillCard(CustomerInfo, paymentFields, "Payment Method");
            var paymentStack = ResponsiveFormLayout.Rows(
                new RowStyle(SizeType.Percent, 100F),
                new RowStyle(SizeType.Absolute, 64F));
            paymentStack.Controls.Add(CustomerInfo, 0, 0);
            paymentStack.Controls.Add(ResponsiveFormLayout.ActionBar(btnPrint, btnUpdate, guna2Button1, btnClear), 0, 1);
            page.Controls.Add(paymentStack, 0, 2);

            ResponsiveFormLayout.ConfigureGrid(dataGridView1);
            ConfigureFrontDeskGrid();
            ResponsiveFormLayout.DockGrid(gReservatonlist, dataGridView1, "Current Customer / Booking");
            page.Controls.Add(gReservatonlist, 0, 3);

            ResponsiveFormLayout.Install(this, page, 980, 1700);
        }

        private void ConfigureLookupInputs()
        {
            guna2ComboBox4.Items.Clear();
            guna2ComboBox4.Items.AddRange(DatabaseUiValues.GetPaymentMethods().Cast<object>().ToArray());
            if (guna2ComboBox4.Items.Count > 0)
            {
                guna2ComboBox4.SelectedIndex = 0;
            }

            guna2TextBox13.Leave += (_, _) => TryAutoFillFromPhone();
            guna2TextBox13.KeyDown += PhoneLookup_KeyDown;
            btnPrint.Click += CheckIn_Click;
            guna2Button1.Click += CheckOut_Click;
            btnUpdate.Click += UpdateStay_Click;
            btnClear.Click += Clear_Click;
            dataGridView1.CellClick += FrontDeskGrid_CellClick;
            guna2TextBox3.TextChanged += (_, _) => RecalculateTotals();
            guna2TextBox11.TextChanged += (_, _) => RecalculateTotals();
            guna2DateTimePicker3.ValueChanged += (_, _) => RecalculateTotals();
            guna2DateTimePicker4.ValueChanged += (_, _) => RecalculateTotals();
            guna2TextBox12.ReadOnly = true;
            guna2TextBox9.ReadOnly = true;
            guna2TextBox2.ReadOnly = true;
            guna2TextBox1.ReadOnly = true;
            UpdateFrontDeskActionButtons();
        }

        private void ConfigureFrontDeskGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            BookingID.DataPropertyName = "customer_name";
            PhoneNumber.DataPropertyName = "phone_number";
            Room.DataPropertyName = "room";
            CheckIn.DataPropertyName = "check_in";
            Checkout.DataPropertyName = "check_out";
            TotelPrice.DataPropertyName = "total_price";
            Payment.DataPropertyName = "payment";
            Status.DataPropertyName = "status";
            dataGridView1.CellFormatting += FrontDeskGrid_CellFormatting;
        }

        private void PhoneLookup_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
            TryAutoFillFromPhone();
        }

        private void LoadRoomTypeChoices()
        {
            try
            {
                DataTable roomTypes = _roomService.GetRoomTypes();
                guna2ComboBox5.Items.Clear();
                guna2ComboBox3.Items.Clear();

                foreach (DataRow row in roomTypes.Rows)
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName) && !guna2ComboBox5.Items.Contains(typeName))
                    {
                        guna2ComboBox5.Items.Add(typeName);
                    }
                }

                DataTable rooms = _roomService.GetRooms();
                foreach (DataRow row in rooms.Rows)
                {
                    string roomNumber = row["RoomNumber"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(roomNumber) && !guna2ComboBox3.Items.Contains(roomNumber))
                    {
                        guna2ComboBox3.Items.Add(roomNumber);
                    }
                }
            }
            catch
            {
                // keep the form usable even if lookup options cannot be loaded yet
            }
        }

        private void TryAutoFillFromPhone()
        {
            if (_suppressPhoneLookup)
            {
                return;
            }

            string phone = guna2TextBox13.Text.Trim();
            if (phone.Length < 6)
            {
                return;
            }

            try
            {
                CustomerBookingLookup? lookup = _customerService.FindLatestBookingByPhone(phone);
                if (lookup == null)
                {
                    return;
                }

                _suppressPhoneLookup = true;
                _currentBookingId = lookup.BookingID;
                SetCurrentBookingStatus(lookup.BookingStatus);
                guna2TextBox12.Text = lookup.Customer.FullName;
                guna2TextBox13.Text = lookup.Customer.Phone;
                guna2TextBox9.Text = lookup.Customer.IDCardNumber;

                SetComboValue(guna2ComboBox5, lookup.RoomType);
                SetComboValue(guna2ComboBox3, lookup.RoomNumber);

                if (lookup.CheckInDate.HasValue)
                {
                    guna2DateTimePicker3.Value = lookup.CheckInDate.Value;
                }

                if (lookup.CheckOutDate.HasValue)
                {
                    guna2DateTimePicker4.Value = lookup.CheckOutDate.Value;
                }

                int nights = 1;
                if (lookup.CheckInDate.HasValue && lookup.CheckOutDate.HasValue)
                {
                    nights = Math.Max(1, (lookup.CheckOutDate.Value.Date - lookup.CheckInDate.Value.Date).Days);
                }

                decimal subTotal = lookup.TotalPrice > 0 ? lookup.TotalPrice : lookup.PricePerNight * nights;
                guna2TextBox2.Text = subTotal > 0 ? subTotal.ToString("0.00") : string.Empty;
                guna2TextBox3.Text = string.IsNullOrWhiteSpace(guna2TextBox3.Text) ? "0.00" : guna2TextBox3.Text;
                guna2TextBox11.Text = lookup.Deposit > 0 ? lookup.Deposit.ToString("0.00") : guna2TextBox11.Text;
                RecalculateTotals();
                UpdateFrontDeskActionButtons();
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

        private static void SetComboValue(Guna.UI2.WinForms.Guna2ComboBox comboBox, string value)
        {
            if (string.IsNullOrWhiteSpace(value))
            {
                return;
            }

            if (!comboBox.Items.Contains(value))
            {
                comboBox.Items.Add(value);
            }

            comboBox.SelectedItem = value;
        }

        private void Checkin_outControl_Load(object sender, EventArgs e)
        {
            RefreshFrontDeskGrid();
        }

        private void RefreshFrontDeskGrid()
        {
            try
            {
                dataGridView1.DataSource = _checkInService.GetFrontDeskBookings();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load front desk bookings: " + ex.Message);
            }
        }

        private void CheckIn_Click(object? sender, EventArgs e)
        {
            try
            {
                EnsureCurrentBooking();
                if (_checkInService.CheckIn(_currentBookingId))
                {
                    SetCurrentBookingStatus("Checked In");
                    MessageBox.Show("Check-in completed.");
                    RefreshFrontDeskGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check-in failed: " + ex.Message);
            }
        }

        private void CheckOut_Click(object? sender, EventArgs e)
        {
            try
            {
                EnsureCurrentBooking();
                RecalculateTotals();
                if (_checkInService.CheckOut(
                    _currentBookingId,
                    ParseMoney(guna2TextBox2.Text),
                    ParseMoney(guna2TextBox3.Text),
                    ParseMoney(guna2TextBox1.Text),
                    ParseMoney(guna2TextBox11.Text),
                    guna2ComboBox4.Text))
                {
                    SetCurrentBookingStatus("Checked Out");
                    MessageBox.Show("Check-out completed.");
                    ClearFrontDeskFields();
                    RefreshFrontDeskGrid();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Check-out failed: " + ex.Message);
            }
        }

        private void UpdateStay_Click(object? sender, EventArgs e)
        {
            try
            {
                EnsureCurrentBooking();
                RecalculateTotals();
                if (_checkInService.UpdateBookingAmounts(
                    _currentBookingId,
                    guna2DateTimePicker3.Value.Date,
                    guna2DateTimePicker4.Value.Date,
                    ParseMoney(guna2TextBox1.Text),
                    ParseMoney(guna2TextBox11.Text)))
                {
                    MessageBox.Show("Stay information updated.");
                    RefreshFrontDeskGrid();
                    UpdateFrontDeskActionButtons();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update failed: " + ex.Message);
            }
        }

        private void Clear_Click(object? sender, EventArgs e)
        {
            ClearFrontDeskFields();
        }

        private void FrontDeskGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || dataGridView1.Rows[e.RowIndex].DataBoundItem is not DataRowView row)
            {
                return;
            }

            _currentBookingId = Convert.ToInt32(row["BookingID"], CultureInfo.InvariantCulture);
            SetCurrentBookingStatus(row["status"]?.ToString() ?? string.Empty);
            guna2TextBox12.Text = row["customer_name"]?.ToString() ?? string.Empty;
            guna2TextBox13.Text = row["phone_number"]?.ToString() ?? string.Empty;
            SetComboValue(guna2ComboBox3, row["room"]?.ToString() ?? string.Empty);

            if (DateTime.TryParse(row["check_in"]?.ToString(), out DateTime checkIn))
            {
                guna2DateTimePicker3.Value = checkIn;
            }

            if (DateTime.TryParse(row["check_out"]?.ToString(), out DateTime checkOut))
            {
                guna2DateTimePicker4.Value = checkOut;
            }

            guna2TextBox2.Text = FormatMoney(row["total_price"]);
            guna2TextBox3.Text = "0.00";
            RecalculateTotals();
            UpdateFrontDeskActionButtons();
        }

        private void FrontDeskGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.ColumnIndex < 0)
            {
                return;
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if ((columnName == "CheckIn" || columnName == "Checkout") && DateTime.TryParse(e.Value.ToString(), out DateTime date))
            {
                e.Value = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
            else if (columnName == "TotelPrice" && decimal.TryParse(e.Value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount))
            {
                e.Value = amount.ToString("0.00", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
        }

        private void RecalculateTotals()
        {
            decimal subTotal = ParseMoney(guna2TextBox2.Text);
            decimal discount = ParseMoney(guna2TextBox3.Text);
            decimal deposit = ParseMoney(guna2TextBox11.Text);
            decimal total = Math.Max(0M, subTotal - discount);
            decimal remaining = Math.Max(0M, total - deposit);
            guna2TextBox1.Text = total > 0 ? total.ToString("0.00", CultureInfo.InvariantCulture) : string.Empty;
            guna2TextBox10.Text = remaining > 0 ? remaining.ToString("0.00", CultureInfo.InvariantCulture) : "0.00";
        }

        private void EnsureCurrentBooking()
        {
            if (_currentBookingId <= 0)
            {
                TryAutoFillFromPhone();
            }

            if (_currentBookingId <= 0)
            {
                throw new InvalidOperationException("Please enter a booked phone number or select a row first.");
            }
        }

        private void ClearFrontDeskFields()
        {
            _currentBookingId = 0;
            SetCurrentBookingStatus(string.Empty);
            guna2TextBox12.Clear();
            guna2TextBox13.Clear();
            guna2TextBox9.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox1.Clear();
            guna2TextBox11.Clear();
            guna2TextBox10.Clear();
            guna2DateTimePicker3.Value = DateTime.Today;
            guna2DateTimePicker4.Value = DateTime.Today.AddDays(1);
            UpdateFrontDeskActionButtons();
        }

        private void SetCurrentBookingStatus(string? status)
        {
            _currentBookingStatus = status?.Trim() ?? string.Empty;
            UpdateFrontDeskActionButtons();
        }

        private void UpdateFrontDeskActionButtons()
        {
            bool hasBooking = _currentBookingId > 0;
            bool isCheckedIn = IsCurrentStatus("Checked In");
            bool isCheckedOut = IsCurrentStatus("Checked Out");

            btnPrint.Enabled = hasBooking && !isCheckedIn && !isCheckedOut;
            guna2Button1.Enabled = hasBooking && isCheckedIn && !isCheckedOut;
            btnUpdate.Enabled = hasBooking;
        }

        private bool IsCurrentStatus(string status)
        {
            return _currentBookingStatus.Equals(status, StringComparison.OrdinalIgnoreCase);
        }

        private static decimal ParseMoney(string? value)
        {
            return decimal.TryParse(value?.Replace("$", string.Empty).Trim(), NumberStyles.Number, CultureInfo.CurrentCulture, out decimal current)
                ? current
                : decimal.TryParse(value?.Replace("$", string.Empty).Trim(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal invariant)
                    ? invariant
                    : 0M;
        }

        private static string FormatMoney(object? value)
        {
            return decimal.TryParse(value?.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount)
                ? amount.ToString("0.00", CultureInfo.InvariantCulture)
                : string.Empty;
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void textBox14_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label9_Click(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void gReservatonlist_Enter(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void lblGust_Enter(object sender, EventArgs e)
        {

        }
    }
}
