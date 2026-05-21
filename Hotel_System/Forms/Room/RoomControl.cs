using Hotel_System.Models;
using Hotel_System.Report;
using Hotel_System.Services;
using Hotel_System.UI;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class RoomControl : UserControl
    {
        private readonly RoomService roomService = new();
        private DataGridView? roomTypesGrid;

        public RoomControl()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            WireEvents();
            ConfigureGrid();
            ConfigureInputs();
            LoadNextRoomId();
        }

        private void BuildModernLayout()
        {
            label1.Text = "Bed Type:";

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 5;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 760F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 470F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            page.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Room Management",
                "Manage room types, pricing, and availability with a clearer layout for editing and faster room selection.",
                "Rooms",
                ResponsiveFormLayout.CreateReportButton((_, _) =>
                    ReportLauncher.ShowForm(this, () => new Room_Report(), "Room Report"))), 0, 0);

            var roomFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(roomFields, 0, 0, label14, guna2TextBox4);
            ResponsiveFormLayout.AddField(roomFields, 1, 0, label16, guna2TextBox7);
            ResponsiveFormLayout.AddField(roomFields, 2, 0, label26, guna2ComboBox2);
            ResponsiveFormLayout.AddField(roomFields, 3, 0, label15, guna2TextBox1);
            ResponsiveFormLayout.AddField(roomFields, 4, 0, label29, guna2TextBox8);
            ResponsiveFormLayout.AddField(roomFields, 5, 0, label1, guna2TextBox2);
            ResponsiveFormLayout.AddField(roomFields, 6, 0, label18, guna2TextBox6);
            ResponsiveFormLayout.AddField(roomFields, 7, 0, label13, guna2TextBox3);
            ResponsiveFormLayout.AddField(roomFields, 8, 0, label20, guna2TextBox9);
            ResponsiveFormLayout.AddField(roomFields, 9, 0, label2, guna2ComboBox1);
            ResponsiveFormLayout.FillCard(guna2GroupBox1, roomFields, "Room Management");
            page.Controls.Add(guna2GroupBox1, 0, 1);

            ResponsiveFormLayout.FillCard(guna2GroupBox2, CreateRoomTypeSelection(), "Room Type Selection");
            page.Controls.Add(guna2GroupBox2, 0, 2);
            page.Controls.Add(ResponsiveFormLayout.ActionBar(Add, Update, Delete, guna2Button1, guna2Button2), 0, 3);

            GroupBox inventoryCard = new();
            ResponsiveFormLayout.ConfigureGrid(dataGridView1);
            ResponsiveFormLayout.DockGrid(inventoryCard, dataGridView1, "Room Inventory");
            page.Controls.Add(inventoryCard, 0, 4);

            ResponsiveFormLayout.Install(this, page, 980, 1760);
        }

        private Control CreateRoomTypeSelection()
        {
            Panel host = new()
            {
                BackColor = Color.Transparent,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                Padding = new Padding(0, 4, 0, 0)
            };

            roomTypesGrid = new DataGridView
            {
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                AutoGenerateColumns = false,
                Dock = DockStyle.Fill,
                Margin = Padding.Empty,
                ReadOnly = true
            };
            ResponsiveFormLayout.ConfigureGrid(roomTypesGrid);
            roomTypesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "TypeName",
                HeaderText = "Room Type",
                Name = "TypeName",
                FillWeight = 170
            });
            roomTypesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "Capacity",
                HeaderText = "Capacity",
                Name = "Capacity",
                FillWeight = 90
            });
            roomTypesGrid.Columns.Add(new DataGridViewTextBoxColumn
            {
                DataPropertyName = "PricePerNight",
                HeaderText = "Price / Night",
                Name = "PricePerNight",
                FillWeight = 120
            });
            roomTypesGrid.Columns.Add(new DataGridViewButtonColumn
            {
                HeaderText = "",
                Name = "SelectRoomType",
                Text = "Select",
                UseColumnTextForButtonValue = true,
                FillWeight = 90
            });
            roomTypesGrid.CellContentClick += RoomTypesGrid_CellContentClick;
            roomTypesGrid.CellDoubleClick += RoomTypesGrid_CellDoubleClick;
            roomTypesGrid.CellFormatting += RoomTypesGrid_CellFormatting;

            host.Controls.Add(roomTypesGrid);
            return host;
        }

        private void RoomControl_Load(object sender, EventArgs e)
        {
            LoadRoomTypes();
            RefreshGrid();
        }

        private void WireEvents()
        {
            Add.Click += Add_Click;
            Update.Click += Update_Click;
            Delete.Click += Delete_Click;
            guna2Button1.Click += Search_Click;
            guna2Button2.Click += Reset_Click;
            dataGridView1.CellClick += DataGridView1_CellClick;
        }

        private void ConfigureInputs()
        {
            guna2TextBox4.PlaceholderText = "Auto ID";
            guna2TextBox4.ReadOnly = true;
            guna2TextBox7.PlaceholderText = "e.g. 101";
            guna2TextBox8.PlaceholderText = "e.g. 1";
            guna2TextBox2.PlaceholderText = "King / Queen / Twin";
            guna2TextBox6.PlaceholderText = "Guests";
            guna2TextBox3.PlaceholderText = "Price per night";
            guna2TextBox1.PlaceholderText = "Optional total";
            guna2TextBox9.PlaceholderText = "e.g. 32 sqm";

            guna2ComboBox1.Items.Clear();
            guna2ComboBox1.Items.AddRange(DatabaseUiValues.GetRoomStatuses().Cast<object>().ToArray());
            guna2ComboBox1.SelectedItem = "Available";
        }

        private void LoadNextRoomId()
        {
            try
            {
                guna2TextBox4.Text = FormatDisplayId(roomService.GetNextRoomId());
            }
            catch
            {
                guna2TextBox4.Text = string.Empty;
            }
        }

        private void ConfigureGrid()
        {
            dataGridView1.AutoGenerateColumns = false;
            Column1.DataPropertyName = "RoomID";
            Column2.DataPropertyName = "RoomNumber";
            Column3.DataPropertyName = "RoomType";
            Column4.DataPropertyName = "Floor";
            Column5.DataPropertyName = "BedType";
            Column6.DataPropertyName = "Capacity";
            Column7.DataPropertyName = "PricePerNight";
            Column8.DataPropertyName = "Status";
        }

        private void LoadRoomTypes()
        {
            try
            {
                DataTable roomTypes = roomService.GetRoomTypes();
                if (roomTypesGrid != null)
                {
                    roomTypesGrid.DataSource = roomTypes;
                }

                guna2ComboBox2.Items.Clear();

                foreach (DataRow row in roomTypes.Rows)
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName))
                    {
                        guna2ComboBox2.Items.Add(typeName);
                    }
                }

                if (guna2ComboBox2.Items.Count > 0 && string.IsNullOrWhiteSpace(guna2ComboBox2.Text))
                {
                    guna2ComboBox2.SelectedIndex = 0;
                }
            }
            catch (Exception ex)
            {
                ShowError("Failed to load room types", ex);
            }
        }

        private void RoomTypesGrid_CellContentClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (roomTypesGrid == null || e.RowIndex < 0 || e.ColumnIndex < 0 || roomTypesGrid.Columns[e.ColumnIndex].Name != "SelectRoomType")
            {
                return;
            }

            SelectRoomTypeFromGrid(roomTypesGrid.Rows[e.RowIndex]);
        }

        private void RoomTypesGrid_CellDoubleClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (roomTypesGrid == null || e.RowIndex < 0)
            {
                return;
            }

            SelectRoomTypeFromGrid(roomTypesGrid.Rows[e.RowIndex]);
        }

        private void RoomTypesGrid_CellFormatting(object? sender, DataGridViewCellFormattingEventArgs e)
        {
            if (roomTypesGrid == null || e.Value == null)
            {
                return;
            }

            if (roomTypesGrid.Columns[e.ColumnIndex].Name == "PricePerNight"
                && decimal.TryParse(e.Value.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
            {
                e.Value = price.ToString("0.00", CultureInfo.InvariantCulture);
                e.FormattingApplied = true;
            }
        }

        private void SelectRoomTypeFromGrid(DataGridViewRow row)
        {
            if (row.DataBoundItem is not DataRowView roomType)
            {
                return;
            }

            guna2ComboBox2.Text = roomType["TypeName"]?.ToString() ?? string.Empty;
            guna2TextBox6.Text = roomType["Capacity"]?.ToString() ?? string.Empty;

            if (decimal.TryParse(roomType["PricePerNight"]?.ToString(), NumberStyles.Number, CultureInfo.InvariantCulture, out decimal price))
            {
                guna2TextBox3.Text = price.ToString("0.00", CultureInfo.InvariantCulture);
            }
        }

        private void RefreshGrid(string? searchText = null)
        {
            try
            {
                dataGridView1.DataSource = roomService.GetRooms(searchText);
            }
            catch (Exception ex)
            {
                ShowError("Failed to load rooms", ex);
            }
        }

        private void Add_Click(object? sender, EventArgs e)
        {
            try
            {
                if (roomService.AddRoom(BuildRoomFromFields(requireId: false)))
                {
                    MessageBox.Show("Room saved successfully.");
                    ClearFields();
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                ShowError("Add room failed", ex);
            }
        }

        private void Update_Click(object? sender, EventArgs e)
        {
            try
            {
                if (roomService.UpdateRoom(BuildRoomFromFields(requireId: true)))
                {
                    MessageBox.Show("Room updated successfully.");
                    ClearFields();
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                ShowError("Update room failed", ex);
            }
        }

        private void Delete_Click(object? sender, EventArgs e)
        {
            if (!int.TryParse(guna2TextBox4.Text, out int roomId))
            {
                MessageBox.Show("Please select a room first.");
                return;
            }

            DialogResult confirm = MessageBox.Show(
                "Delete this room?",
                "Confirm Delete",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Warning);

            if (confirm != DialogResult.Yes)
            {
                return;
            }

            try
            {
                if (roomService.DeleteRoom(roomId))
                {
                    MessageBox.Show("Room deleted successfully.");
                    ClearFields();
                    RefreshGrid();
                }
            }
            catch (Exception ex)
            {
                ShowError("Delete room failed", ex);
            }
        }

        private void Search_Click(object? sender, EventArgs e)
        {
            RefreshGrid(guna2TextBox7.Text);
        }

        private void Reset_Click(object? sender, EventArgs e)
        {
            ClearFields();
            RefreshGrid();
        }

        private void DataGridView1_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex < 0 || e.RowIndex >= dataGridView1.Rows.Count)
            {
                return;
            }

            DataGridViewRow row = dataGridView1.Rows[e.RowIndex];
            if (row.IsNewRow)
            {
                return;
            }

            string roomIdText = CellText(row, "Column1");
            guna2TextBox4.Text = int.TryParse(roomIdText, out int roomId)
                ? FormatDisplayId(roomId)
                : roomIdText;
            guna2TextBox7.Text = CellText(row, "Column2");
            guna2ComboBox2.Text = CellText(row, "Column3");
            guna2TextBox8.Text = CellText(row, "Column4");
            guna2TextBox2.Text = CellText(row, "Column5");
            guna2TextBox6.Text = CellText(row, "Column6");
            guna2TextBox3.Text = CellText(row, "Column7");
            guna2ComboBox1.Text = CellText(row, "Column8");
        }

        private Room BuildRoomFromFields(bool requireId)
        {
            int.TryParse(guna2TextBox4.Text, out int roomId);

            if (requireId && roomId <= 0)
            {
                throw new InvalidOperationException("Please select a room first.");
            }

            return new Room
            {
                RoomID = roomId,
                RoomNumber = guna2TextBox7.Text.Trim(),
                RoomType = guna2ComboBox2.Text.Trim(),
                Floor = ParseInt(guna2TextBox8.Text, "Floor"),
                BedType = guna2TextBox2.Text.Trim(),
                Capacity = ParseInt(guna2TextBox6.Text, "Capacity"),
                PricePerNight = ParseMoney(guna2TextBox3.Text, "Price per night"),
                Status = string.IsNullOrWhiteSpace(guna2ComboBox1.Text) ? "Available" : guna2ComboBox1.Text.Trim()
            };
        }

        private void SelectRoomType(string roomType)
        {
            guna2ComboBox2.Text = roomType;
        }

        private void ClearFields()
        {
            LoadNextRoomId();
            guna2TextBox7.Clear();
            guna2TextBox8.Clear();
            guna2TextBox2.Clear();
            guna2TextBox6.Clear();
            guna2TextBox3.Clear();
            guna2TextBox1.Clear();
            guna2TextBox9.Clear();
            if (guna2ComboBox2.Items.Count > 0)
            {
                guna2ComboBox2.SelectedIndex = 0;
            }
            guna2ComboBox1.SelectedItem = "Available";
        }

        private static string CellText(DataGridViewRow row, string columnName)
        {
            return row.DataGridView?.Columns.Contains(columnName) == true
                ? row.Cells[columnName].Value?.ToString() ?? string.Empty
                : string.Empty;
        }

        private static int ParseInt(string value, string fieldName)
        {
            if (int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out int number))
            {
                return number;
            }

            throw new InvalidOperationException($"{fieldName} must be a valid number.");
        }

        private static decimal ParseMoney(string value, string fieldName)
        {
            string normalized = value.Replace("$", string.Empty).Trim();
            if (decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal number))
            {
                return number;
            }

            throw new InvalidOperationException($"{fieldName} must be a valid amount.");
        }

        private static string FormatDisplayId(int id)
        {
            return id <= 0 ? string.Empty : id.ToString("D4");
        }

        private static void ShowError(string title, Exception ex)
        {
            MessageBox.Show(
                $"{title}:\n{ex.Message}",
                "Hotel Management System",
                MessageBoxButtons.OK,
                MessageBoxIcon.Error);
        }
    }
}
