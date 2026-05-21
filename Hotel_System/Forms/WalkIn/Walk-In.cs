using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Hotel_System.Services;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class Walk_In : UserControl
    {
        private readonly RoomService _roomService = new RoomService();

        public Walk_In()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            ConfigureDatabaseBackedChoices();
        }

        private void BuildModernLayout()
        {
            txtCustomerName.PlaceholderText = "Customer name";
            txtID.PlaceholderText = "ID card / passport";
            txtPhoneNumber.PlaceholderText = "Phone number";
            txtRoomNumber.PlaceholderText = "Room number";
            txtAmountPaid.PlaceholderText = "Amount paid";
            txtBalanceDue.PlaceholderText = "Balance due";
            txtTotalPrice.PlaceholderText = "Total price";

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 6;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 300F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 560F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 360F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 64F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Walk-In Registration",
                "Register same-day guests, choose services, and complete payment details in a cleaner front-desk layout.",
                "Same-Day Stay"), 0, 0);

            var customerFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(customerFields, 0, 0, lbCustomerName, txtCustomerName);
            ResponsiveFormLayout.AddField(customerFields, 1, 0, label20, ResponsiveFormLayout.Inline(CheckboxFemale, CheckboxMale));
            ResponsiveFormLayout.AddField(customerFields, 2, 0, label1, txtID);
            ResponsiveFormLayout.AddField(customerFields, 3, 0, label19, txtPhoneNumber);
            ResponsiveFormLayout.FillCard(WalkinCustomer, customerFields, "Customer Information");
            page.Controls.Add(WalkinCustomer, 0, 1);

            var bookingFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(bookingFields, 0, 0, label5, ComboRoomType);
            ResponsiveFormLayout.AddField(bookingFields, 1, 0, label4, txtRoomNumber);
            ResponsiveFormLayout.AddField(bookingFields, 2, 0, label6, ComBoRoomStatus);
            ResponsiveFormLayout.AddField(bookingFields, 3, 0, label2, TimeWalkInCheckOut);
            ResponsiveFormLayout.AddField(bookingFields, 4, 0, label3, TimeWalkInCheckIn);
            ResponsiveFormLayout.AddField(bookingFields, 5, 0, label7, NumeriAdults);
            ResponsiveFormLayout.AddField(bookingFields, 6, 0, label8, NumeriChildren);
            ResponsiveFormLayout.FillCard(BookingInfo, bookingFields, "Booking Information");
            page.Controls.Add(BookingInfo, 0, 2);

            ResponsiveFormLayout.FillCard(GroupService, ResponsiveFormLayout.Inline(CheckBoxBreakfast, CheckBoxAirportPickup, CheckBoxExtraBed), "Services (optional)");
            page.Controls.Add(GroupService, 0, 3);

            var paymentFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(paymentFields, 0, 0, label12, ComBoPayment);
            ResponsiveFormLayout.AddField(paymentFields, 1, 0, label9, txtAmountPaid);
            ResponsiveFormLayout.AddField(paymentFields, 2, 0, label10, txtBalanceDue);
            ResponsiveFormLayout.AddField(paymentFields, 3, 0, label11, txtTotalPrice);
            ResponsiveFormLayout.FillCard(GroupPayment, paymentFields, "Payment Information");
            page.Controls.Add(GroupPayment, 0, 4);

            page.Controls.Add(ResponsiveFormLayout.ActionBar(btnCheck, btnSave, btnCancel), 0, 5);

            ResponsiveFormLayout.Install(this, page, 980, 1720);
        }

        private void ConfigureDatabaseBackedChoices()
        {
            ComBoRoomStatus.Items.Clear();
            ComBoRoomStatus.Items.AddRange(DatabaseUiValues.GetRoomStatuses().Cast<object>().ToArray());
            ComBoRoomStatus.SelectedItem = "Available";

            ComBoPayment.Items.Clear();
            ComBoPayment.Items.AddRange(DatabaseUiValues.GetPaymentMethods().Cast<object>().ToArray());
            if (ComBoPayment.Items.Count > 0)
            {
                ComBoPayment.SelectedIndex = 0;
            }

            try
            {
                DataTable roomTypes = _roomService.GetRoomTypes();
                ComboRoomType.Items.Clear();

                foreach (DataRow row in roomTypes.Rows)
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName))
                    {
                        ComboRoomType.Items.Add(typeName);
                    }
                }

                if (ComboRoomType.Items.Count > 0)
                {
                    ComboRoomType.SelectedIndex = 0;
                }
            }
            catch
            {
                // keep the screen usable when the database is not available at design/run startup
            }
        }

        private void WalkinCustomer_Click(object sender, EventArgs e)
        {

        }

        private void ComboRoomType_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TimeWalkInCheckIn_ValueChanged(object sender, EventArgs e)
        {

        }

        private void BookingInfo_Click(object sender, EventArgs e)
        {

        }

        private void ComBoRoomStatus_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void CheckBoxBreakfast_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {
        }

        private void booking_menu_Click(object sender, EventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

        private void txtCustomerName_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
