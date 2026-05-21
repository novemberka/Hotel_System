using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using Guna.UI2.WinForms;
using Hotel_System.Models;
using Hotel_System.Report;
using Hotel_System.Services;
using Hotel_System.UI;

namespace Hotel_System
{
    public partial class PaymentControl : UserControl
    {
        private readonly PaymentService paymentService = new();
        private readonly RoomService roomService = new();
        private Guna2TextBox? phoneNumberBox;
        private bool suppressPhoneLookup;

        public PaymentControl()
        {
            InitializeComponent();
            BuildModernLayout();
            UiTheme.ApplyPageDesign(this);
            WirePaymentEvents();
            LoadRoomTypes();
        }

        private void BuildModernLayout()
        {
            guna2TextBox10.PlaceholderText = "Customer name";
            phoneNumberBox = new Guna2TextBox { PlaceholderText = "Enter phone number to load checkout" };
            txtRoomNumber.PlaceholderText = "Room number";
            guna2TextBox2.PlaceholderText = "Room charge";
            guna2TextBox3.PlaceholderText = "Service charges";
            guna2TextBox1.PlaceholderText = "Discount";
            guna2TextBox4.PlaceholderText = "Tax";
            guna2TextBox5.PlaceholderText = "Total amount";
            guna2TextBox11.PlaceholderText = "Card number";
            RbtnCash.Text = "Cash";
            RbtnCreditCard.Text = "Credit Card";
            RbtnTransfer.Text = "Transfer";
            btnPay.Text = "Pay Now";

            var page = ResponsiveFormLayout.CreatePage();
            page.RowCount = 5;
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 140F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 540F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 440F));
            page.RowStyles.Add(new RowStyle(SizeType.Absolute, 360F));
            page.RowStyles.Add(new RowStyle(SizeType.Percent, 100F));
            page.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100F));
            page.Controls.Add(ResponsiveFormLayout.CreateBanner(
                "Payment Desk",
                "Review stay charges, confirm a payment method, and finish guest payments with a cleaner single-column flow.",
                "Billing",
                ResponsiveFormLayout.CreateReportButton((_, _) =>
                    ReportLauncher.ShowForm(this, () => new Payment_Report(), "Payment Report"))), 0, 0);

            var stayFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(stayFields, 0, 0, label14, guna2TextBox10);
            ResponsiveFormLayout.AddField(stayFields, 1, 0, new Label { Text = "Phone Number:" }, phoneNumberBox);
            ResponsiveFormLayout.AddField(stayFields, 2, 0, label12, guna2ComboBox2);
            ResponsiveFormLayout.AddField(stayFields, 3, 0, label13, txtRoomNumber);
            ResponsiveFormLayout.AddField(stayFields, 4, 0, label7, guna2DateTimePicker5);
            ResponsiveFormLayout.AddField(stayFields, 5, 0, label1, guna2DateTimePicker4);
            ResponsiveFormLayout.FillCard(guna2GroupBox1, stayFields, "Customer Information");
            page.Controls.Add(guna2GroupBox1, 0, 1);

            var amountFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddField(amountFields, 0, 0, label23, guna2TextBox2);
            ResponsiveFormLayout.AddField(amountFields, 1, 0, label20, guna2TextBox3);
            ResponsiveFormLayout.AddField(amountFields, 2, 0, label19, guna2TextBox1);
            ResponsiveFormLayout.AddField(amountFields, 3, 0, label17, guna2TextBox4);
            ResponsiveFormLayout.AddField(amountFields, 4, 0, label15, guna2TextBox5);
            ResponsiveFormLayout.FillCard(guna2GroupBox2, amountFields, "Payment Detail");
            page.Controls.Add(guna2GroupBox2, 0, 2);

            var methodFields = ResponsiveFormLayout.FieldGrid(1);
            ResponsiveFormLayout.AddWide(methodFields, 0, new Label { Text = "Payment Method:" }, ResponsiveFormLayout.Inline(RbtnCash, RbtnCreditCard, RbtnTransfer));
            ResponsiveFormLayout.AddField(methodFields, 1, 0, label9, guna2TextBox11);
            ResponsiveFormLayout.AddField(methodFields, 2, 0, label10, guna2DateTimePicker1);
            ResponsiveFormLayout.FillCard(guna2GroupBox3, methodFields, "Payment Method");
            page.Controls.Add(guna2GroupBox3, 0, 3);

            page.Controls.Add(ResponsiveFormLayout.ActionBar(btnPay, btnPrint, btnCancel), 0, 4);

            ResponsiveFormLayout.Install(this, page, 980, 1640);
        }

        private void WirePaymentEvents()
        {
            btnPay.Click += Pay_Click;
            btnCancel.Click += (_, _) => ClearPaymentFields();
            if (phoneNumberBox != null)
            {
                phoneNumberBox.TextChanged += PhoneNumberBox_TextChanged;
                phoneNumberBox.KeyDown += PhoneNumberBox_KeyDown;
                phoneNumberBox.Leave += (_, _) => LoadPaymentFromPhone(showNotFound: false);
            }

            txtRoomNumber.TextChanged += RoomNumberBox_TextChanged;
            txtRoomNumber.KeyDown += RoomNumberBox_KeyDown;
            guna2TextBox2.TextChanged += (_, _) => CalculateTotal();
            guna2TextBox3.TextChanged += (_, _) => CalculateTotal();
            guna2TextBox1.TextChanged += (_, _) => CalculateTotal();
            guna2TextBox4.TextChanged += (_, _) => CalculateTotal();
        }

        private void PhoneNumberBox_TextChanged(object? sender, EventArgs e)
        {
            if (suppressPhoneLookup || phoneNumberBox == null)
            {
                return;
            }

            string phone = phoneNumberBox.Text.Trim();
            if (phone.Length >= 6)
            {
                LoadPaymentFromPhone(showNotFound: false);
            }
        }

        private void PhoneNumberBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            e.SuppressKeyPress = true;
            LoadPaymentFromPhone(showNotFound: true);
        }

        private void LoadPaymentFromPhone(bool showNotFound)
        {
            LoadPaymentFromPhone(phoneNumberBox?.Text, showNotFound);
        }

        private void LoadPaymentFromPhone(string? phoneText, bool showNotFound)
        {
            if (suppressPhoneLookup)
            {
                return;
            }

            string phone = phoneText?.Trim() ?? string.Empty;
            if (phone.Length < 3)
            {
                return;
            }

            try
            {
                PaymentLookup? lookup = paymentService.FindLatestCheckedOutStayByPhone(phone);
                if (lookup == null)
                {
                    if (showNotFound)
                    {
                        MessageBox.Show("No customer or booking data was found for this phone number.");
                    }
                    return;
                }

                FillPaymentFields(lookup);
            }
            catch (Exception ex)
            {
                if (showNotFound)
                {
                    MessageBox.Show("Phone lookup failed: " + ex.Message);
                }
            }
        }

        private void RoomNumberBox_TextChanged(object? sender, EventArgs e)
        {
            if (suppressPhoneLookup)
            {
                return;
            }

            string possiblePhone = txtRoomNumber.Text.Trim();
            if (LooksLikePhoneNumber(possiblePhone))
            {
                LoadPaymentFromPhone(possiblePhone, showNotFound: false);
            }
        }

        private void RoomNumberBox_KeyDown(object? sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter || !LooksLikePhoneNumber(txtRoomNumber.Text))
            {
                return;
            }

            e.SuppressKeyPress = true;
            LoadPaymentFromPhone(txtRoomNumber.Text, showNotFound: true);
        }

        private void FillPaymentFields(PaymentLookup lookup)
        {
            suppressPhoneLookup = true;
            try
            {
                if (phoneNumberBox != null)
                {
                    phoneNumberBox.Text = lookup.Phone;
                }

                guna2TextBox10.Text = lookup.CustomerName;
                guna2ComboBox2.Text = lookup.RoomType;
                txtRoomNumber.Text = lookup.RoomNumber;
                if (lookup.CheckInDate.HasValue && IsPickerDateValid(guna2DateTimePicker5, lookup.CheckInDate.Value))
                {
                    guna2DateTimePicker5.Value = lookup.CheckInDate.Value;
                }

                if (lookup.CheckOutDate.HasValue && IsPickerDateValid(guna2DateTimePicker4, lookup.CheckOutDate.Value))
                {
                    guna2DateTimePicker4.Value = lookup.CheckOutDate.Value;
                }

                guna2TextBox2.Text = FormatMoney(lookup.RoomCharge);
                guna2TextBox3.Text = FormatMoney(lookup.ServiceCharge);
                guna2TextBox1.Text = FormatMoney(lookup.Discount);
                guna2TextBox4.Text = FormatMoney(lookup.Tax);
                decimal amountDue = lookup.HasPayment && lookup.Remaining > 0 ? lookup.Remaining : lookup.TotalAmount;
                guna2TextBox5.Text = FormatMoney(amountDue);
                UpdatePayButtonState(lookup);
            }
            finally
            {
                suppressPhoneLookup = false;
            }
        }

        private void LoadRoomTypes()
        {
            try
            {
                DataTable roomTypes = roomService.GetRoomTypes();
                guna2ComboBox2.Items.Clear();
                foreach (DataRow row in roomTypes.Rows)
                {
                    string typeName = row["TypeName"]?.ToString() ?? string.Empty;
                    if (!string.IsNullOrWhiteSpace(typeName))
                    {
                        guna2ComboBox2.Items.Add(typeName);
                    }
                }

                if (guna2ComboBox2.Items.Count > 0)
                {
                    guna2ComboBox2.SelectedIndex = 0;
                }
            }
            catch
            {
                // Keep payment entry usable if lookup data is unavailable.
            }
        }

        private void Pay_Click(object? sender, EventArgs e)
        {
            try
            {
                CalculateTotal();
                string lookupPhone = phoneNumberBox?.Text.Trim() ?? string.Empty;
                string method = SelectedPaymentMethod();
                if (paymentService.SavePayment(
                    guna2TextBox10.Text,
                    txtRoomNumber.Text,
                    ParseMoney(guna2TextBox5.Text),
                    ParseMoney(guna2TextBox2.Text),
                    ParseMoney(guna2TextBox3.Text),
                    method))
                {
                    MessageBox.Show("Payment saved successfully.");
                    if (!string.IsNullOrWhiteSpace(lookupPhone))
                    {
                        LoadPaymentFromPhone(lookupPhone, showNotFound: false);
                    }
                    else
                    {
                        btnPay.Enabled = false;
                        btnPay.Text = "Saved";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Payment failed: " + ex.Message);
            }
        }

        private void CalculateTotal()
        {
            decimal roomCharge = ParseMoney(guna2TextBox2.Text);
            decimal serviceCharge = ParseMoney(guna2TextBox3.Text);
            decimal discount = ParseMoney(guna2TextBox1.Text);
            decimal tax = ParseMoney(guna2TextBox4.Text);
            decimal total = Math.Max(0M, roomCharge + serviceCharge + tax - discount);
            guna2TextBox5.Text = total > 0 ? total.ToString("0.00", CultureInfo.InvariantCulture) : string.Empty;
        }

        private string SelectedPaymentMethod()
        {
            if (RbtnCreditCard.Checked)
            {
                return "Credit Card";
            }

            if (RbtnTransfer.Checked)
            {
                return "Transfer";
            }

            return "Cash";
        }

        private void ClearPaymentFields()
        {
            guna2TextBox10.Clear();
            if (phoneNumberBox != null)
            {
                phoneNumberBox.Clear();
            }
            txtRoomNumber.Clear();
            guna2TextBox2.Clear();
            guna2TextBox3.Clear();
            guna2TextBox1.Clear();
            guna2TextBox4.Clear();
            guna2TextBox5.Clear();
            guna2TextBox11.Clear();
            RbtnCash.Checked = true;
            btnPay.Enabled = true;
            btnPay.Text = "Pay Now";
        }

        private static decimal ParseMoney(string? value)
        {
            string normalized = value?.Replace("$", string.Empty).Trim() ?? string.Empty;
            return decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.CurrentCulture, out decimal current)
                ? current
                : decimal.TryParse(normalized, NumberStyles.Number, CultureInfo.InvariantCulture, out decimal invariant)
                    ? invariant
                    : 0M;
        }

        private static string FormatMoney(decimal value)
        {
            return value > 0 ? value.ToString("0.00", CultureInfo.InvariantCulture) : string.Empty;
        }

        private static bool LooksLikePhoneNumber(string value)
        {
            string trimmed = value.Trim();
            return trimmed.Length >= 6 && trimmed.All(char.IsDigit);
        }

        private static bool IsPickerDateValid(Guna2DateTimePicker picker, DateTime value)
        {
            return value >= picker.MinDate && value <= picker.MaxDate;
        }

        private void UpdatePayButtonState(PaymentLookup lookup)
        {
            bool isPaid = lookup.HasPayment
                && (IsPaidStatus(lookup.PaymentStatus) || (lookup.Remaining <= 0 && lookup.TotalAmount > 0));
            btnPay.Enabled = lookup.HasCheckout && !isPaid;
            btnPay.Text = isPaid ? "Paid" : lookup.HasCheckout ? "Pay Now" : "Checkout First";
        }

        private static bool IsPaidStatus(string status)
        {
            return status.Trim().Equals("Paid", StringComparison.OrdinalIgnoreCase);
        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void PaymentControl_Load(object sender, EventArgs e)
        {

        }

        private void panel1_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_2(object sender, PaintEventArgs e)
        {

        }

        private void panel1_Paint_3(object sender, PaintEventArgs e)
        {

        }

        private void guna2GroupBox1_Click(object sender, EventArgs e)
        {

        }

        private void btnPrint_Click(object sender, EventArgs e)
        {
            ReportLauncher.ShowForm(this, () => new Payment_Report(), "Payment Report");
        }
    }
}
