using Guna.UI2.WinForms;

namespace Hotel_System
{
    partial class BookingControl
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Component Designer generated code

        private void InitializeComponent()
        {
            this.txtPhoneNumber = new Guna2TextBox();

            // 
            // txtPhoneNumber
            // 
            this.txtPhoneNumber.BorderColor = Color.Black;
            this.txtPhoneNumber.BorderRadius = 6;
            this.txtPhoneNumber.DefaultText = "";
            this.txtPhoneNumber.DisabledState.BorderColor = Color.FromArgb(208, 208, 208);
            this.txtPhoneNumber.DisabledState.FillColor = Color.FromArgb(226, 226, 226);
            this.txtPhoneNumber.DisabledState.ForeColor = Color.FromArgb(138, 138, 138);
            this.txtPhoneNumber.DisabledState.PlaceholderForeColor = Color.FromArgb(138, 138, 138);
            this.txtPhoneNumber.FocusedState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtPhoneNumber.Font = new Font("Segoe UI", 9F);
            this.txtPhoneNumber.HoverState.BorderColor = Color.FromArgb(94, 148, 255);
            this.txtPhoneNumber.Location = new Point(722, 35);
            this.txtPhoneNumber.Margin = new Padding(3, 4, 3, 4);
            this.txtPhoneNumber.Name = "txtPhoneNumber";
            this.txtPhoneNumber.PlaceholderText = "";
            this.txtPhoneNumber.SelectedText = "";
            this.txtPhoneNumber.Size = new Size(352, 36);
            this.txtPhoneNumber.TabIndex = 62;
        }

        #endregion

        // =========================
        // BUTTONS
        // =========================

        private Guna2Button btnadd;
        private Guna2Button btnupdate;
        private Guna2Button btncancel;
        private Guna2Button btnclear;

        // =========================
        // GROUPBOXES
        // =========================

        private GroupBox gbookinglist;

        private Guna2GroupBox CustomerInfo;
        private Guna2GroupBox dgvbooking;
        private Guna2GroupBox RoomStatus;

        // =========================
        // DATAGRIDVIEW
        // =========================

        private DataGridView dgvbookinglist;

        private DataGridViewTextBoxColumn BookingID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Reason;

        // =========================
        // TEXTBOXES
        // =========================

        private Guna2TextBox txtPassport;
        private Guna2TextBox txtPhoneNumber;
        private Guna2TextBox txtEmail;
        private Guna2TextBox txtAddress;

        private Guna2TextBox txtBookingID;
        private Guna2TextBox txtsubTotal;
        private Guna2TextBox txtdiscount;
        private Guna2TextBox txtTotalPrice;

        // =========================
        // COMBOBOXES
        // =========================

        private Guna2ComboBox cmbRoomType;
        private Guna2ComboBox cmbCustomerNamer;

        // =========================
        // DATETIME PICKERS
        // =========================

        private Guna2DateTimePicker guna2DateTimePicker3;
        private Guna2DateTimePicker guna2DateTimePicker4;
    }
}