using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Hotel_System.Models;
using Hotel_System.Report;
using Hotel_System.Services;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class BookingControl : UserControl
    {
        private readonly BookingService _bookingService = new BookingService();
        private readonly RoomService _roomService = new RoomService();
        private Guna2TextBox? selectedRoomIdBox;
        private Guna2TextBox? selectedRoomNumberBox;
        private Guna2ComboBox? roomFilterType;
        private Guna2TextBox? roomFilterBed;
        private Guna2ComboBox? roomFilterCapacity;
        private Guna2TextBox? roomFilterMaxPrice;
        private DataGridView? availableRoomsGrid;
        private Guna2TextBox? bookingNightsBox;
        private bool syncingBookingDates;

        public BookingControl()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            ConfigureDatabaseBackedInputs();
            LoadNextBookingId();
        }

        private void BuildModernLayout()
        {
            BorderStyle = BorderStyle.None;
            label18.Text = "Check-Out Date:";
            guna2TextBox1.PlaceholderText = "Customer name";
            guna2TextBox2.PlaceholderText = "Phone number";
            guna2TextBox11.PlaceholderText = "Address";
            guna2TextBox10.PlaceholderText = "Email";
            guna2TextBox3.PlaceholderText = "ID / passport";
            guna2TextBox4.PlaceholderText = "Booking ID";
            guna2TextBox4.ReadOnly = true;
            bookingNightsBox = new Guna2TextBox { PlaceholderText = "Number of nights", Text = "1" };
            guna2TextBox6.PlaceholderText = "Sub total";
            guna2TextBox6.ReadOnly = true;
            guna2TextBox7.PlaceholderText = "Price / night";
            guna2TextBox8.PlaceholderText = "Discount";
            guna2TextBox9.PlaceholderText = "Total price";
            guna2TextBox9.ReadOnly = true;

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 7;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 440F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 800F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 500F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 170F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 86F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 560F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Reservation Workspace",
                "Use the same booking logic as before, but with a calmer layout for guest details, dates, prices, and room status.",
                "Bookings",
                ResponsiveFormLayout.CreateReportButton((_, _) =>
                    ReportLauncher.ShowForm(this, () => new Booking_Report(), "Booking Report"))), 0, 0);

            var customerFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(customerFields, 0, 0, label1, guna2TextBox1);
            ResponsiveFormLayout.AddField(customerFields, 1, 0, label4, guna2TextBox2);
            ResponsiveFormLayout.AddField(customerFields, 2, 0, label3, guna2TextBox11);
            ResponsiveFormLayout.AddField(customerFields, 3, 0, label2, guna2TextBox10);
            ResponsiveFormLayout.AddField(customerFields, 4, 0, label5, guna2TextBox3);
            ResponsiveFormLayout.FillCard(CustomerInfo, customerFields, "Customer Information");
            page.Controls.Add(CustomerInfo, 0, 1);

            var bookingFields = ResponsiveFormLayout.FieldGrid(1);
            selectedRoomIdBox = CreateReadOnlyTextBox("Select a room from the table below");
            selectedRoomNumberBox = CreateReadOnlyTextBox("Selected room number");
            ResponsiveFormLayout.AddField(bookingFields, 0, 0, label14, guna2TextBox4);
            ResponsiveFormLayout.AddField(bookingFields, 1, 0, new Label { Text = "Room ID:" }, selectedRoomIdBox);
            ResponsiveFormLayout.AddField(bookingFields, 2, 0, new Label { Text = "Room Number:" }, selectedRoomNumberBox);
            ResponsiveFormLayout.AddField(bookingFields, 3, 0, label26, guna2ComboBox2);
            ResponsiveFormLayout.AddField(bookingFields, 4, 0, label29, guna2DateTimePicker3);
            ResponsiveFormLayout.AddField(bookingFields, 5, 0, label18, guna2DateTimePicker4);
            ResponsiveFormLayout.AddField(bookingFields, 6, 0, new Label { Text = "Number of Nights:" }, bookingNightsBox);
            ResponsiveFormLayout.AddField(bookingFields, 7, 0, label13, guna2TextBox7);
            ResponsiveFormLayout.AddField(bookingFields, 8, 0, label16, guna2TextBox8);
            ResponsiveFormLayout.AddField(bookingFields, 9, 0, label20, guna2TextBox6);
            ResponsiveFormLayout.AddField(bookingFields, 10, 0, label15, guna2TextBox9);
            ResponsiveFormLayout.FillCard(guna2GroupBox1, bookingFields, "Booking Information");
            page.Controls.Add(guna2GroupBox1, 0, 2);

            ResponsiveFormLayout.FillCard(guna2GroupBox2, CreateAvailableRoomPicker(), "Available Rooms");
            page.Controls.Add(guna2GroupBox2, 0, 3);

            var statusFields = ResponsiveFormLayout.FieldGrid(1, 70);
            ResponsiveFormLayout.AddField(statusFields, 0, 0, label19, guna2ComboBox1);
            ResponsiveFormLayout.FillCard(RoomStatus, statusFields, "Room Status");
            page.Controls.Add(RoomStatus, 0, 4);
            page.Controls.Add(ResponsiveFormLayout.ActionBar(btnadd, btnupdate, btncancel, btnclear), 0, 5);

            ResponsiveFormLayout.ConfigureGrid(dataGridView1);
            ConfigureBookingGrid();
            ResponsiveFormLayout.DockGrid(gReservatonlist, dataGridView1, "Reservation List");
            ConfigureReservationListHeight();
            page.Controls.Add(gReservatonlist, 0, 6);

            WireBookingCalculations();
            ResponsiveFormLayout.Install(this, page, 980, 2740);
        }

        private void ConfigureBookingGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            BookingID.DataPropertyName = "BookingID";
            GuestName.DataPropertyName = "GuestName";
            PhoneNumber.DataPropertyName = "PhoneNumber";
            Room.DataPropertyName = "Room";
            CheckIn.DataPropertyName = "CheckInDate";
            Checkout.DataPropertyName = "CheckOutDate";
            Status.DataPropertyName = "Status";
            EnsureBookingColumn("Nights", "Nights", "Nights", 70, Status.Index);
            EnsureBookingColumn("PricePerNight", "Price / Night", "PricePerNight", 95, Status.Index);
            EnsureBookingColumn("Discount", "Discount", "Discount", 85, Status.Index);
            EnsureBookingColumn("TotalPrice", "Total", "TotalPrice", 95, Status.Index);
            dataGridView1.CellClick -= BookingGrid_CellClick;
            dataGridView1.CellClick += BookingGrid_CellClick;
            dataGridView1.CellFormatting -= BookingGrid_CellFormatting;
            dataGridView1.CellFormatting += BookingGrid_CellFormatting;
        }

        private void ConfigureReservationListHeight()
        {
            gReservatonlist.MinimumSize = new Size(0, 540);
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
            dataGridView1.ColumnHeadersHeight = 52;
            dataGridView1.RowTemplate.Height = 42;
            dataGridView1.ScrollBars = ScrollBars.Both;
            dataGridView1.AutoSizeRowsMode = DataGridViewAutoSizeRowsMode.None;
        }

        private void EnsureBookingColumn(string name, string headerText, string dataPropertyName, float fillWeight, int displayIndex)
        {
            if (dataGridView1.Columns.Contains(name))
            {
                return;
            }

            DataGridViewTextBoxColumn column = new()
            {
                Name = name,
                HeaderText = headerText,
                DataPropertyName = dataPropertyName,
                FillWeight = fillWeight,
                ReadOnly = true
            };
            dataGridView1.Columns.Add(column);
            column.DisplayIndex = Math.Max(0, Math.Min(displayIndex, dataGridView1.Columns.Count - 1));
        }

        private Guna2TextBox CreateReadOnlyTextBox(string placeholder)
        {
            return new Guna2TextBox
            {
                PlaceholderText = placeholder,
                ReadOnly = true,
                Tag = null
            };
        }

        private Control CreateAvailableRoomPicker()
        {
            TableLayoutPanel layout = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 1,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                MinimumSize = new Size(0, 388),
                Padding = new Padding(0, 2, 0, 0),
                RowCount = 2
            };
            layout.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            layout.RowStyles.Add(new RowStyle(SizeType.Absolute, 96F));
            layout.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));

            TableLayoutPanel filters = new()
            {
                BackColor = Color.Transparent,
                ColumnCount = 6,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = new Padding(0, 0, 0, 10),
                RowCount = 2
            };
            filters.RowStyles.Add(new RowStyle(SizeType.Absolute, 28F));
            filters.RowStyles.Add(new RowStyle(SizeType.Absolute, 46F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 24F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 16F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 18F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));
            filters.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 12F));

            roomFilterType = new Guna2ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            roomFilterBed = new Guna2TextBox { Dock = DockStyle.Fill, PlaceholderText = "King / Queen / Twin" };
            roomFilterCapacity = new Guna2ComboBox { Dock = DockStyle.Fill, DropDownStyle = ComboBoxStyle.DropDownList };
            roomFilterMaxPrice = new Guna2TextBox { Dock = DockStyle.Fill, PlaceholderText = "Max price" };

            roomFilterCapacity.Items.Add("Any");
            for (int i = 1; i <= 8; i++)
            {
                roomFilterCapacity.Items.Add(i.ToString(CultureInfo.InvariantCulture));
            }
            roomFilterCapacity.SelectedIndex = 0;

            Guna2Button searchButton = new()
            {
                Dock = DockStyle.Fill,
                Text = "Search"
            };
            Guna2Button resetButton = new()
            {
                Dock = DockStyle.Fill,
                Text = "Reset"
            };

            searchButton.Click += (_, _) => LoadAvailableRooms();
            resetButton.Click += (_, _) => ResetAvailableRoomFilters();
            roomFilterBed.KeyDown += RoomFilter_KeyDown;
            roomFilterMaxPrice.KeyDown += RoomFilter_KeyDown;

            AddFilter(filters, 0, "Room Type", roomFilterType);
            AddFilter(filters, 1, "Bed", roomFilterBed);
            AddFilter(filters, 2, "Capacity", roomFilterCapacity);
            AddFilter(filters, 3, "Max Price", roomFilterMaxPrice);
            AddFilter(filters, 4, string.Empty, searchButton);
            AddFilter(filters, 5, string.Empty, resetButton);

            availableRoomsGrid = CreateAvailableRoomsGrid();
            layout.Controls.Add(filters, 0, 0);
            layout.Controls.Add(availableRoomsGrid, 0, 1);
            return layout;
        }

        private static void AddFilter(TableLayoutPanel filters, int column, string labelText, Control editor)
        {
            filters.Controls.Add(new Label
            {
                AutoSize = false,
                Dock = DockStyle.Fill,
                ForeColor = UiTheme.TextMuted,
                Text = labelText,
                TextAlign = ContentAlignment.MiddleLeft
            }, column, 0);

            editor.Margin = new Padding(0, 0, 10, 0);
            filters.Controls.Add(editor, column, 1);
        }

        private DataGridView CreateAvailableRoomsGrid()
        {
            DataGridView grid = new()
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                ReadOnly = true
            };

            ResponsiveFormLayout.ConfigureGrid(grid);
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomID", HeaderText = "Room ID", Name = "RoomID", FillWeight = 70 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomNumber", HeaderText = "Number", Name = "RoomNumber", FillWeight = 80 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "RoomType", HeaderText = "Type", Name = "RoomType", FillWeight = 120 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "BedType", HeaderText = "Bed", Name = "BedType", FillWeight = 120 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Capacity", HeaderText = "Capacity", Name = "Capacity", FillWeight = 80 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "PricePerNight", HeaderText = "Price / Night", Name = "PricePerNight", FillWeight = 100 });
            grid.Columns.Add(new DataGridViewTextBoxColumn { DataPropertyName = "Status", HeaderText = "Status", Name = "Status", FillWeight = 95 });
            grid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "SelectRoom",
                Text = "Select",
                UseColumnTextForButtonValue = true,
                FillWeight = 80
            });

            grid.CellContentClick += AvailableRoomsGrid_CellContentClick;
            grid.CellDoubleClick += AvailableRoomsGrid_CellDoubleClick;
            grid.CellFormatting += AvailableRoomsGrid_CellFormatting;
            return grid;
        }

        private void RoomFilter_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            LoadAvailableRooms();
        }

        private void LoadAvailableRooms()
        {
            if (availableRoomsGrid == null)
            {
                return;
            }

            try
            {
                string? roomType = roomFilterType?.SelectedIndex > 0 ? roomFilterType.Text : null;
                string? bedType = string.IsNullOrWhiteSpace(roomFilterBed?.Text) ? null : roomFilterBed.Text;
                int? capacity = int.TryParse(roomFilterCapacity?.Text, out int capacityValue) ? capacityValue : null;
                decimal? maxPrice = TryParseMoney(roomFilterMaxPrice?.Text, out decimal priceValue) ? priceValue : null;

                DataTable rooms = _roomService.GetAvailableRooms(roomType, bedType, capacity, maxPrice);
                availableRoomsGrid.DataSource = rooms;
                availableRoomsGrid.Visible = true;
            }
            catch
            {
                availableRoomsGrid.DataSource = null;
                availableRoomsGrid.Visible = true;
            }
        }

        private void RefreshBookings(string? searchText = null)
        {
            try
            {
                dataGridView1.DataSource = _bookingService.GetBookings(searchText);
            }
            catch (Exception ex)
            {
                ShowError("Failed to load bookings", ex);
            }
        }

        private void ResetAvailableRoomFilters()
        {
            if (roomFilterType?.Items.Count > 0)
            {
                roomFilterType.SelectedIndex = 0;
            }

            if (roomFilterCapacity?.Items.Count > 0)
            {
                roomFilterCapacity.SelectedIndex = 0;
            }

            if (roomFilterBed != null)
            {
                roomFilterBed.Text = string.Empty;
            }

            if (roomFilterMaxPrice != null)
            {
                roomFilterMaxPrice.Text = string.Empty;
            }
            LoadAvailableRooms();
        }

        private void AvailableRoomsGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (availableRoomsGrid == null || e.RowIndex < 0 || e.ColumnIndex < 0 || availableRoomsGrid.Columns[e.ColumnIndex].Name != "SelectRoom")
            {
                return;
            }

            SelectAvailableRoom(availableRoomsGrid.Rows[e.RowIndex]);
        }

        private void AvailableRoomsGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (availableRoomsGrid == null || e.RowIndex < 0)
            {
                return;
            }

            SelectAvailableRoom(availableRoomsGrid.Rows[e.RowIndex]);
        }

        private void AvailableRoomsGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (availableRoomsGrid == null || e.Value == null)
            {
                return;
            }

            string columnName = availableRoomsGrid.Columns[e.ColumnIndex].Name;
            if (columnName == "RoomID" && int.TryParse(e.Value.ToString(), out int roomId))
            {
                e.Value = FormatDisplayId(roomId);
                e.FormattingApplied = true;
            }
            else if (columnName == "PricePerNight" && TryParseMoney(e.Value.ToString(), out decimal price))
            {
                e.Value = price.ToString("0.00", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
        }

        private void SelectAvailableRoom(DataGridViewRow row)
        {
            if (row.DataBoundItem is not DataRowView room)
            {
                return;
            }

            int roomId = Convert.ToInt32(room["RoomID"], CultureInfo.InvariantCulture);
            string roomNumber = room["RoomNumber"]?.ToString() ?? string.Empty;
            string roomType = room["RoomType"]?.ToString() ?? string.Empty;
            string price = room["PricePerNight"]?.ToString() ?? string.Empty;

            if (selectedRoomIdBox != null)
            {
                selectedRoomIdBox.Text = FormatDisplayId(roomId);
                selectedRoomIdBox.Tag = roomId;
            }

            if (selectedRoomNumberBox != null)
            {
                selectedRoomNumberBox.Text = roomNumber;
                selectedRoomNumberBox.Tag = roomNumber;
            }

            if (!string.IsNullOrWhiteSpace(roomType))
            {
                guna2ComboBox2.Text = roomType;
            }

            if (TryParseMoney(price, out decimal priceValue))
            {
                guna2TextBox7.Text = priceValue.ToString("0.00", CultureInfo.InvariantCulture);
            }

            CalculateBookingTotals();
        }

        private void BookingGrid_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            FillFormFromBookingRow(dataGridView1.Rows[e.RowIndex]);
        }

        private void BookingGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.Value == null || e.ColumnIndex < 0)
            {
                return;
            }

            string columnName = dataGridView1.Columns[e.ColumnIndex].Name;
            if (columnName == "BookingID" && int.TryParse(e.Value.ToString(), out int bookingId))
            {
                e.Value = FormatDisplayId(bookingId);
                e.FormattingApplied = true;
            }
            else if ((columnName == "CheckIn" || columnName == "Checkout") && DateTime.TryParse(e.Value.ToString(), out DateTime date))
            {
                e.Value = date.ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
            else if ((columnName == "PricePerNight" || columnName == "Discount" || columnName == "TotalPrice")
                && TryParseMoney(e.Value.ToString(), out decimal amount))
            {
                e.Value = amount.ToString("0.00", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
        }

        private void FillFormFromBookingRow(DataGridViewRow row)
        {
            if (row.DataBoundItem is not DataRowView booking)
            {
                return;
            }

            int bookingId = Convert.ToInt32(booking["BookingID"], CultureInfo.InvariantCulture);
            int roomId = Convert.ToInt32(booking["RoomID"], CultureInfo.InvariantCulture);

            guna2TextBox4.Text = FormatDisplayId(bookingId);
            guna2TextBox1.Text = booking["GuestName"]?.ToString() ?? string.Empty;
            guna2TextBox2.Text = booking["PhoneNumber"]?.ToString() ?? string.Empty;
            guna2TextBox11.Text = booking["Address"]?.ToString() ?? string.Empty;
            guna2TextBox10.Text = booking["Email"]?.ToString() ?? string.Empty;
            guna2TextBox3.Text = booking["IDCardNumber"]?.ToString() ?? string.Empty;
            guna2ComboBox2.Text = booking["RoomType"]?.ToString() ?? string.Empty;
            guna2ComboBox1.Text = booking["Status"]?.ToString() ?? "Reserved";
            bookingNightsBox!.Text = booking["Nights"]?.ToString() ?? "1";
            guna2TextBox7.Text = FormatMoney(booking["PricePerNight"]);
            guna2TextBox8.Text = FormatMoney(booking["Discount"]);
            guna2TextBox9.Text = FormatMoney(booking["TotalPrice"]);

            if (selectedRoomIdBox != null)
            {
                selectedRoomIdBox.Text = FormatDisplayId(roomId);
                selectedRoomIdBox.Tag = roomId;
            }

            if (selectedRoomNumberBox != null)
            {
                selectedRoomNumberBox.Text = booking["Room"]?.ToString() ?? string.Empty;
                selectedRoomNumberBox.Tag = selectedRoomNumberBox.Text;
            }

            if (DateTime.TryParse(booking["CheckInDate"]?.ToString(), out DateTime checkIn))
            {
                guna2DateTimePicker3.Value = checkIn;
            }

            if (DateTime.TryParse(booking["CheckOutDate"]?.ToString(), out DateTime checkOut))
            {
                guna2DateTimePicker4.Value = checkOut;
            }
        }

        private void WireBookingCalculations()
        {
            guna2DateTimePicker3.ValueChanged += BookingDate_ValueChanged;
            guna2DateTimePicker4.ValueChanged += BookingDate_ValueChanged;
            if (bookingNightsBox != null)
            {
                bookingNightsBox.TextChanged += BookingNights_TextChanged;
            }
            guna2TextBox7.TextChanged += (_, _) => CalculateBookingTotals();
            guna2TextBox8.TextChanged += (_, _) => CalculateBookingTotals();
        }

        private void BookingDate_ValueChanged(object? sender, EventArgs e)
        {
            if (syncingBookingDates)
            {
                return;
            }

            int nights = Math.Max(1, (guna2DateTimePicker4.Value.Date - guna2DateTimePicker3.Value.Date).Days);
            syncingBookingDates = true;
            if (bookingNightsBox != null && bookingNightsBox.Text != nights.ToString(CultureInfo.InvariantCulture))
            {
                bookingNightsBox.Text = nights.ToString(CultureInfo.InvariantCulture);
            }
            syncingBookingDates = false;
            CalculateBookingTotals();
        }

        private void BookingNights_TextChanged(object? sender, EventArgs e)
        {
            if (syncingBookingDates)
            {
                CalculateBookingTotals();
                return;
            }

            if (!int.TryParse(bookingNightsBox?.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int nights) || nights <= 0)
            {
                CalculateBookingTotals();
                return;
            }

            syncingBookingDates = true;
            guna2DateTimePicker4.Value = guna2DateTimePicker3.Value.Date.AddDays(nights);
            syncingBookingDates = false;
            CalculateBookingTotals();
        }

        private void CalculateBookingTotals()
        {
            decimal pricePerNight = TryParseMoney(guna2TextBox7.Text, out decimal price) ? price : 0M;
            decimal discount = TryParseMoney(guna2TextBox8.Text, out decimal discountValue) ? discountValue : 0M;
            int nights = int.TryParse(bookingNightsBox?.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int value)
                ? Math.Max(1, value)
                : Math.Max(1, (guna2DateTimePicker4.Value.Date - guna2DateTimePicker3.Value.Date).Days);
            decimal subTotal = pricePerNight * nights;
            decimal total = Math.Max(0M, subTotal - discount);

            guna2TextBox6.Text = subTotal > 0 ? subTotal.ToString("0.00", CultureInfo.InvariantCulture) : string.Empty;
            guna2TextBox9.Text = total > 0 ? total.ToString("0.00", CultureInfo.InvariantCulture) : string.Empty;
        }

        private static bool TryParseMoney(string? value, out decimal amount)
        {
            return decimal.TryParse(value, NumberStyles.Number, CultureInfo.CurrentCulture, out amount)
                || decimal.TryParse(value, NumberStyles.Number, CultureInfo.InvariantCulture, out amount);
        }

        private Booking BuildBookingFromFields(bool requireId)
        {
            int bookingId = ParseDisplayId(guna2TextBox4.Text);
            int roomId = GetSelectedRoomId();

            if (requireId && bookingId <= 0)
            {
                throw new InvalidOperationException("Please select a booking first.");
            }

            return new Booking
            {
                BookingID = bookingId,
                RoomID = roomId,
                CheckInDate = guna2DateTimePicker3.Value.Date,
                CheckOutDate = guna2DateTimePicker4.Value.Date,
                Nights = int.TryParse(bookingNightsBox?.Text, NumberStyles.Integer, CultureInfo.InvariantCulture, out int nights) ? Math.Max(1, nights) : 1,
                Status = string.IsNullOrWhiteSpace(guna2ComboBox1.Text) ? "Reserved" : guna2ComboBox1.Text.Trim(),
                PricePerNight = TryParseMoney(guna2TextBox7.Text, out decimal pricePerNight) ? pricePerNight : 0M,
                Discount = TryParseMoney(guna2TextBox8.Text, out decimal discount) ? discount : 0M,
                TotalPrice = TryParseMoney(guna2TextBox9.Text, out decimal total) ? total : 0M,
                Deposit = 0M
            };
        }

        private Customer BuildCustomerFromFields()
        {
            return new Customer
            {
                FullName = guna2TextBox1.Text.Trim(),
                Phone = guna2TextBox2.Text.Trim(),
                Email = guna2TextBox10.Text.Trim(),
                Address = guna2TextBox11.Text.Trim(),
                IDCardNumber = guna2TextBox3.Text.Trim()
            };
        }

        private int GetSelectedRoomId()
        {
            if (selectedRoomIdBox?.Tag is int taggedRoomId && taggedRoomId > 0)
            {
                return taggedRoomId;
            }

            return ParseDisplayId(selectedRoomIdBox?.Text ?? string.Empty);
        }

        private static int ParseDisplayId(string value)
        {
            return int.TryParse(value.Trim(), NumberStyles.Integer, CultureInfo.InvariantCulture, out int id) ? id : 0;
        }

        private static string FormatMoney(object? value)
        {
            return decimal.TryParse(value?.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal amount)
                ? amount.ToString("0.00", CultureInfo.InvariantCulture)
                : string.Empty;
        }

        private void ClearBookingFields()
        {
            LoadNextBookingId();
            guna2TextBox1.Clear();
            guna2TextBox2.Clear();
            guna2TextBox11.Clear();
            guna2TextBox10.Clear();
            guna2TextBox3.Clear();
            guna2TextBox6.Clear();
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2TextBox9.Clear();
            if (bookingNightsBox != null)
            {
                bookingNightsBox.Text = "1";
            }

            if (selectedRoomIdBox != null)
            {
                selectedRoomIdBox.Clear();
                selectedRoomIdBox.Tag = null;
            }

            if (selectedRoomNumberBox != null)
            {
                selectedRoomNumberBox.Clear();
                selectedRoomNumberBox.Tag = null;
            }

            if (guna2ComboBox2.Items.Count > 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }

            guna2ComboBox1.SelectedItem = "Reserved";
            guna2DateTimePicker3.Value = DateTime.Today;
            guna2DateTimePicker4.Value = DateTime.Today.AddDays(1);
        }

        private static void ShowError(string title, Exception ex)
        {
            MessageBox.Show(
                $"{title}:\n{ex.Message}",
                "Hotel Management System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }

        private void LoadNextBookingId()
        {
            try
            {
                guna2TextBox4.Text = FormatDisplayId(_bookingService.GetNextBookingId());
            }
            catch
            {
                guna2TextBox4.Text = string.Empty;
            }
        }

        private static string FormatDisplayId(int id)
        {
            return id <= 0 ? string.Empty : id.ToString("D4");
        }

        private void ConfigureDatabaseBackedInputs()
        {
            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.AddRange(DatabaseUiValues.GetBookingStatuses().Cast<object>().ToArray());
            guna2ComboBox1.SelectedItem = "Reserved";

            try
            {
                DataTable roomTypes = _roomService.GetRoomTypes();
                guna2ComboBox2.Items.Clear();
                roomFilterType?.Items.Clear();
                roomFilterType?.Items.Add("All room types");

                foreach (DataRow row in roomTypes.Rows)
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName))
                    {
                        guna2ComboBox2.Items.Add(typeName);
                        roomFilterType?.Items.Add(typeName);
                    }
                }

                if (guna2ComboBox2.Items.Count > 0)
                {
                    guna2ComboBox2.SelectedIndex = 0;
                }

                if (roomFilterType?.Items.Count > 0)
                {
                    roomFilterType.SelectedIndex = 0;
                }
            }
            catch
            {
                // Keep the form usable when the database is not available yet.
            }

            LoadAvailableRooms();
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void btnClear_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void lblGustInfo_Enter(object sender, EventArgs e)
        {

        }

        private void lblGustInfo_Enter_1(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void BookingControl_Load(object sender, EventArgs e)
        {
            RefreshBookings();
            LoadAvailableRooms();
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel5_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel8_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label23_Click(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void label21_Click(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click_1(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label22_Click(object sender, EventArgs e)
        {

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click_1(object sender, EventArgs e)
        {

        }

        private void textBox9_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {

        }

        private void panel7_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel11_Paint(object sender, PaintEventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged_1(object sender, EventArgs e)
        {
        }

        private void textBox13_TextChanged(object sender, EventArgs e)
        {
        }

        private void textBox11_TextChanged(object sender, EventArgs e)
        {
        }

        private void label15_Click(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridView1.Rows.Count)
            {
                FillFormFromBookingRow(dataGridView1.Rows[e.RowIndex]);
            }
        }

        private void lbStatus_Click(object sender, EventArgs e)
        {

        }

        private void lblGust_Enter(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void CustomerInfo_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void label15_Click_1(object sender, EventArgs e)
        {
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void textBox12_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox11_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void label6_Click_1(object sender, EventArgs e)
        {

        }

        private void CustomerInfo_Click_1(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged_1(object sender, EventArgs e)
        {
        }

        private void dateTimePicker2_ValueChanged_1(object sender, EventArgs e)
        {
        }

        private void dateTimePicker1_ValueChanged_2(object sender, EventArgs e)
        {
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void textBox3_TextChanged_2(object sender, EventArgs e)
        {
        }

        private void guna2GroupBox1_Click_1(object sender, EventArgs e)
        {

        }

        private void label26_Click(object sender, EventArgs e)
        {

        }

        private void label26_Click_1(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void label27_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click_1(object sender, EventArgs e)
        {
        }

        private void btnadd_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateBookingTotals();
                if (_bookingService.AddBooking(BuildBookingFromFields(requireId: false), BuildCustomerFromFields()))
                {
                    MessageBox.Show("Booking saved successfully.");
                    ClearBookingFields();
                    RefreshBookings();
                    LoadAvailableRooms();
                }
            }
            catch (Exception ex)
            {
                ShowError("Add booking failed", ex);
            }
        }

        private void guna2TextBox5_TextChanged(object sender, EventArgs e)
        {

        }

        private void btnclear_Click_1(object sender, EventArgs e)
        {
            ClearBookingFields();
            RefreshBookings();
        }

        private void btncancel_Click(object sender, EventArgs e)
        {
            int bookingId = ParseDisplayId(guna2TextBox4.Text);
            if (bookingId <= 0)
            {
                MessageBox.Show("Please select a booking first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Cancel this booking and release the room?",
                "Confirm Cancel",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (_bookingService.CancelBooking(bookingId))
                {
                    MessageBox.Show("Booking cancelled successfully.");
                    ClearBookingFields();
                    RefreshBookings();
                    LoadAvailableRooms();
                }
            }
            catch (Exception ex)
            {
                ShowError("Cancel booking failed", ex);
            }
        }

        private void btnupdate_Click(object sender, EventArgs e)
        {
            try
            {
                CalculateBookingTotals();
                if (_bookingService.UpdateBooking(BuildBookingFromFields(requireId: true), BuildCustomerFromFields()))
                {
                    MessageBox.Show("Booking updated successfully.");
                    ClearBookingFields();
                    RefreshBookings();
                    LoadAvailableRooms();
                }
            }
            catch (Exception ex)
            {
                ShowError("Update booking failed", ex);
            }
        }

        private void gReservatonlist_Enter(object sender, EventArgs e)
        {

        }

        private void guna2TextBox4_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void guna2DateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label19_Click(object sender, EventArgs e)
        {

        }

        private void RoomStatus_Click(object sender, EventArgs e)
        {

        }

        private void guna2GroupBox2_Click(object sender, EventArgs e)
        {

        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
