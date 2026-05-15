using Hotel_System.Models;
using Hotel_System.Services;
using System;
using System.Data;
using System.Windows.Forms;

namespace Hotel_System
{
    public partial class RoomControl : UserControl
    {
        private readonly RoomService _roomService = new RoomService();

        public RoomControl()
        {
            InitializeComponent();
            dataGridView2.CellClick += new DataGridViewCellEventHandler(dataGridView2_CellClick);
        }

        private void RoomControl_Load(object sender, EventArgs e)
        {
            LoadGrid();
            FillRoomTypeComboBox();
        }

        private void LoadGrid()
        {
            try
            {
                dataGridView2.AutoGenerateColumns = false;
                dataGridView2.Columns["RoomID"]!.DataPropertyName = "RoomID";
                dataGridView2.Columns["RoomNumber"]!.DataPropertyName = "RoomNumber";
                dataGridView2.Columns["TypeName"]!.DataPropertyName = "TypeName";
                dataGridView2.Columns["PricePerNight"]!.DataPropertyName = "PricePerNight";
                dataGridView2.Columns["Floor"]!.DataPropertyName = "Floor";
                dataGridView2.Columns["Status"]!.DataPropertyName = "Status";
                dataGridView2.Columns["RoomTypeID"]!.DataPropertyName = "RoomTypeID";
                dataGridView2.Columns["RoomTypeID"]!.Visible = false;
                dataGridView2.DataSource = _roomService.GetRooms();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading grid: " + ex.Message);
            }
        }

        private void FillRoomTypeComboBox()
        {
            cmbRoomType.SelectedIndexChanged -= new EventHandler(cmbRoomType_SelectedIndexChanged);
            try
            {
                DataTable types = _roomService.GetRoomTypeList();
                if (types != null && types.Rows.Count > 0)
                {
                    cmbRoomType.DataSource = types;
                    cmbRoomType.DisplayMember = "TypeName";
                    cmbRoomType.ValueMember = "RoomTypeID";
                    cmbRoomType.SelectedIndex = -1;
                    txtFloor.ReadOnly = true;
                    txtPrice.ReadOnly = true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error filling room types: " + ex.Message);
            }
            finally
            {
                cmbRoomType.SelectedIndexChanged += new EventHandler(cmbRoomType_SelectedIndexChanged);
            }
        }

        private void cmbRoomType_SelectedIndexChanged(object? sender, EventArgs e)
        {
            if (cmbRoomType.SelectedIndex != -1 && cmbRoomType.SelectedItem is DataRowView row)
            {
                txtPrice.Text = row["PricePerNight"].ToString();
                txtFloor.Text = row["Floor"].ToString();
            }
        }

        private void Add_Click(object sender, EventArgs e)
        {
            try
            {
                var room = GetModelFromUI();
                if (_roomService.AddRoom(room))
                {
                    MessageBox.Show("Room Created Successfully!");
                    LoadGrid();
                    ClearFields();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Add Error: " + ex.Message);
            }
        }

        private void Update_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text))
            {
                MessageBox.Show("Please select a room from the list first.");
                return;
            }

            try
            {
                var updatedRoom = new Room
                {
                    RoomID = int.Parse(txtRoomID.Text),
                    RoomNumber = txtRoomNumber.Text,
                    RoomTypeID = Convert.ToInt32(cmbRoomType.SelectedValue),
                    Status = cmbStatus.Text
                };

                if (_roomService.UpdateRoom(updatedRoom))
                {
                    MessageBox.Show("Room updated successfully!");
                    LoadGrid();
                    ClearFields();
                }
                else
                {
                    MessageBox.Show("Update failed. Please check your database connection.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Update Error: " + ex.Message);
            }
        }

        private void Delete_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtRoomID.Text)) return;

            var confirm = MessageBox.Show("Are you sure you want to delete this room?",
                "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                try
                {
                    if (_roomService.DeleteRoom(int.Parse(txtRoomID.Text)))
                    {
                        MessageBox.Show("Room Deleted.");
                        LoadGrid();
                        ClearFields();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Delete Error: " + ex.Message);
                }
            }
        }

        private void dataGridView2_CellClick(object? sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dataGridView2.Rows[e.RowIndex];
                txtRoomID.Text = row.Cells["RoomID"].Value?.ToString() ?? "";
                txtRoomNumber.Text = row.Cells["RoomNumber"].Value?.ToString() ?? "";
                txtFloor.Text = row.Cells["Floor"].Value?.ToString() ?? "";
                txtPrice.Text = row.Cells["PricePerNight"].Value?.ToString() ?? "";
                cmbStatus.Text = row.Cells["Status"].Value?.ToString() ?? "";

                if (row.Cells["RoomTypeID"].Value != null)
                    cmbRoomType.SelectedValue = row.Cells["RoomTypeID"].Value!;
            }
        }

        private Room GetModelFromUI()
        {
            if (cmbRoomType.SelectedIndex == -1)
                throw new Exception("Please select a Room Type before saving.");

            return new Room
            {
                RoomNumber = txtRoomNumber.Text,
                RoomTypeID = Convert.ToInt32(cmbRoomType.SelectedValue),
                Status = cmbStatus.Text
            };
        }

        private void ClearFields()
        {
            txtRoomID.Clear();
            txtRoomNumber.Clear();
            cmbRoomType.SelectedIndex = -1;
            cmbRoomType.Text = "";
            cmbStatus.SelectedIndex = -1;
            txtFloor.Clear();
            txtPrice.Clear();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            ClearFields();
            LoadGrid();
        }
    }
}
