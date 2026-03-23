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
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            lblGust = new GroupBox();
            textBox5 = new TextBox();
            label5 = new Label();
            textBox3 = new TextBox();
            label4 = new Label();
            textBox2 = new TextBox();
            label3 = new Label();
            textBox1 = new TextBox();
            label2 = new Label();
            textBox4 = new TextBox();
            lbGust = new Label();
            panel1 = new Panel();
            label1 = new Label();
            RoomAvailable = new Panel();
            label11 = new Label();
            label12 = new Label();
            panel6 = new Panel();
            label9 = new Label();
            label10 = new Label();
            panel5 = new Panel();
            label8 = new Label();
            label7 = new Label();
            panel4 = new Panel();
            panel3 = new Panel();
            label6 = new Label();
            groupBox1 = new GroupBox();
            textBox10 = new TextBox();
            lbBookingID = new Label();
            textBox9 = new TextBox();
            lbTotal = new Label();
            textBox8 = new TextBox();
            lbDis = new Label();
            textBox7 = new TextBox();
            label13 = new Label();
            comboBox1 = new ComboBox();
            dateTimePicker6 = new DateTimePicker();
            dateTimePicker5 = new DateTimePicker();
            label20 = new Label();
            label21 = new Label();
            textBox6 = new TextBox();
            label22 = new Label();
            label23 = new Label();
            label24 = new Label();
            btbAdd = new Button();
            btnClear = new Button();
            btnCancel = new Button();
            btnUpdate = new Button();
            panel7 = new Panel();
            comboBox2 = new ComboBox();
            label19 = new Label();
            panel11 = new Panel();
            lbStatus = new Label();
            gReservatonlist = new GroupBox();
            dataGridView1 = new DataGridView();
            BookingID = new DataGridViewTextBoxColumn();
            GuestName = new DataGridViewTextBoxColumn();
            PhoneNumber = new DataGridViewTextBoxColumn();
            Room = new DataGridViewTextBoxColumn();
            CheckIn = new DataGridViewTextBoxColumn();
            Checkout = new DataGridViewTextBoxColumn();
            Status = new DataGridViewTextBoxColumn();
            label17 = new Label();
            lblGust.SuspendLayout();
            panel1.SuspendLayout();
            RoomAvailable.SuspendLayout();
            panel3.SuspendLayout();
            groupBox1.SuspendLayout();
            panel7.SuspendLayout();
            panel11.SuspendLayout();
            gReservatonlist.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // lblGust
            // 
            lblGust.Controls.Add(textBox5);
            lblGust.Controls.Add(label5);
            lblGust.Controls.Add(textBox3);
            lblGust.Controls.Add(label4);
            lblGust.Controls.Add(textBox2);
            lblGust.Controls.Add(label3);
            lblGust.Controls.Add(textBox1);
            lblGust.Controls.Add(label2);
            lblGust.Controls.Add(textBox4);
            lblGust.Controls.Add(lbGust);
            lblGust.FlatStyle = FlatStyle.Flat;
            lblGust.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblGust.ForeColor = SystemColors.Highlight;
            lblGust.Location = new Point(14, 39);
            lblGust.Margin = new Padding(3, 2, 3, 2);
            lblGust.Name = "lblGust";
            lblGust.Padding = new Padding(3, 2, 3, 2);
            lblGust.Size = new Size(962, 134);
            lblGust.TabIndex = 0;
            lblGust.TabStop = false;
            lblGust.Text = "Gust Information";
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(621, 92);
            textBox5.Margin = new Padding(3, 2, 3, 2);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(314, 27);
            textBox5.TabIndex = 27;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(502, 103);
            label5.Name = "label5";
            label5.Size = new Size(79, 15);
            label5.TabIndex = 26;
            label5.Text = "ID / Passport:";
            label5.Click += label5_Click_1;
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(123, 92);
            textBox3.Margin = new Padding(3, 2, 3, 2);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(342, 27);
            textBox3.TabIndex = 25;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(64, 103);
            label4.Name = "label4";
            label4.Size = new Size(39, 15);
            label4.TabIndex = 24;
            label4.Text = "Email:";
            label4.Click += label4_Click;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(621, 16);
            textBox2.Margin = new Padding(3, 2, 3, 2);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(314, 27);
            textBox2.TabIndex = 23;
            textBox2.TextChanged += textBox2_TextChanged;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(502, 28);
            label3.Name = "label3";
            label3.Size = new Size(91, 15);
            label3.TabIndex = 22;
            label3.Text = "Phone Number:";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(123, 54);
            textBox1.Margin = new Padding(3, 2, 3, 2);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(812, 27);
            textBox1.TabIndex = 21;
            textBox1.TextChanged += textBox1_TextChanged;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(50, 65);
            label2.Name = "label2";
            label2.Size = new Size(52, 15);
            label2.TabIndex = 20;
            label2.Text = "Address:";
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(123, 16);
            textBox4.Margin = new Padding(3, 2, 3, 2);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(342, 27);
            textBox4.TabIndex = 19;
            // 
            // lbGust
            // 
            lbGust.AutoSize = true;
            lbGust.BackColor = Color.White;
            lbGust.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbGust.ForeColor = Color.Black;
            lbGust.Location = new Point(32, 28);
            lbGust.Name = "lbGust";
            lbGust.Size = new Size(69, 15);
            lbGust.TabIndex = 18;
            lbGust.Text = "Gust Name:";
            lbGust.Click += label2_Click;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.Highlight;
            panel1.Controls.Add(label1);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 2, 3, 2);
            panel1.Name = "panel1";
            panel1.Size = new Size(1271, 34);
            panel1.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(482, 0);
            label1.Name = "label1";
            label1.Size = new Size(242, 30);
            label1.TabIndex = 0;
            label1.Text = "Booking Management";
            // 
            // RoomAvailable
            // 
            RoomAvailable.BorderStyle = BorderStyle.FixedSingle;
            RoomAvailable.Controls.Add(label11);
            RoomAvailable.Controls.Add(label12);
            RoomAvailable.Controls.Add(panel6);
            RoomAvailable.Controls.Add(label9);
            RoomAvailable.Controls.Add(label10);
            RoomAvailable.Controls.Add(panel5);
            RoomAvailable.Controls.Add(label8);
            RoomAvailable.Controls.Add(label7);
            RoomAvailable.Controls.Add(panel4);
            RoomAvailable.Location = new Point(995, 67);
            RoomAvailable.Margin = new Padding(3, 2, 3, 2);
            RoomAvailable.Name = "RoomAvailable";
            RoomAvailable.Size = new Size(204, 106);
            RoomAvailable.TabIndex = 2;
            RoomAvailable.Paint += panel2_Paint_1;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.DarkOrange;
            label11.Location = new Point(128, 75);
            label11.Name = "label11";
            label11.Size = new Size(54, 15);
            label11.TabIndex = 26;
            label11.Text = "Reserved";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = Color.White;
            label12.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.Black;
            label12.Location = new Point(38, 75);
            label12.Name = "label12";
            label12.Size = new Size(60, 15);
            label12.TabIndex = 25;
            label12.Text = "Room 703";
            // 
            // panel6
            // 
            panel6.BackColor = Color.DarkOrange;
            panel6.Location = new Point(15, 75);
            panel6.Margin = new Padding(3, 2, 3, 2);
            panel6.Name = "panel6";
            panel6.Size = new Size(18, 15);
            panel6.TabIndex = 24;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Red;
            label9.Location = new Point(128, 45);
            label9.Name = "label9";
            label9.Size = new Size(58, 15);
            label9.TabIndex = 23;
            label9.Text = "Occupied";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(38, 45);
            label10.Name = "label10";
            label10.Size = new Size(60, 15);
            label10.TabIndex = 22;
            label10.Text = "Room 702";
            // 
            // panel5
            // 
            panel5.BackColor = Color.Red;
            panel5.ForeColor = SystemColors.ControlLight;
            panel5.Location = new Point(15, 45);
            panel5.Margin = new Padding(3, 2, 3, 2);
            panel5.Name = "panel5";
            panel5.Size = new Size(18, 15);
            panel5.TabIndex = 21;
            panel5.Paint += panel5_Paint;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(128, 15);
            label8.Name = "label8";
            label8.Size = new Size(55, 15);
            label8.TabIndex = 20;
            label8.Text = "Available";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(38, 15);
            label7.Name = "label7";
            label7.Size = new Size(60, 15);
            label7.TabIndex = 19;
            label7.Text = "Room 701";
            // 
            // panel4
            // 
            panel4.BackColor = Color.LawnGreen;
            panel4.Location = new Point(15, 15);
            panel4.Margin = new Padding(3, 2, 3, 2);
            panel4.Name = "panel4";
            panel4.Size = new Size(18, 15);
            panel4.TabIndex = 5;
            panel4.Paint += panel4_Paint;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.Highlight;
            panel3.BorderStyle = BorderStyle.FixedSingle;
            panel3.Controls.Add(label6);
            panel3.Location = new Point(995, 47);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(204, 24);
            panel3.TabIndex = 4;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(38, 1);
            label6.Name = "label6";
            label6.Size = new Size(116, 19);
            label6.TabIndex = 0;
            label6.Text = "Room Available";
            label6.TextAlign = ContentAlignment.MiddleLeft;
            // 
            // groupBox1
            // 
            groupBox1.Controls.Add(textBox10);
            groupBox1.Controls.Add(lbBookingID);
            groupBox1.Controls.Add(textBox9);
            groupBox1.Controls.Add(lbTotal);
            groupBox1.Controls.Add(textBox8);
            groupBox1.Controls.Add(lbDis);
            groupBox1.Controls.Add(textBox7);
            groupBox1.Controls.Add(label13);
            groupBox1.Controls.Add(comboBox1);
            groupBox1.Controls.Add(dateTimePicker6);
            groupBox1.Controls.Add(dateTimePicker5);
            groupBox1.Controls.Add(label20);
            groupBox1.Controls.Add(label21);
            groupBox1.Controls.Add(textBox6);
            groupBox1.Controls.Add(label22);
            groupBox1.Controls.Add(label23);
            groupBox1.Controls.Add(label24);
            groupBox1.FlatStyle = FlatStyle.Flat;
            groupBox1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            groupBox1.ForeColor = SystemColors.Highlight;
            groupBox1.Location = new Point(14, 184);
            groupBox1.Margin = new Padding(3, 2, 3, 2);
            groupBox1.Name = "groupBox1";
            groupBox1.Padding = new Padding(3, 2, 3, 2);
            groupBox1.Size = new Size(962, 170);
            groupBox1.TabIndex = 5;
            groupBox1.TabStop = false;
            groupBox1.Text = "Booking Information";
            groupBox1.Enter += groupBox1_Enter;
            // 
            // textBox10
            // 
            textBox10.BorderStyle = BorderStyle.FixedSingle;
            textBox10.Location = new Point(130, 22);
            textBox10.Margin = new Padding(3, 2, 3, 2);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(168, 27);
            textBox10.TabIndex = 39;
            // 
            // lbBookingID
            // 
            lbBookingID.AutoSize = true;
            lbBookingID.BackColor = Color.White;
            lbBookingID.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbBookingID.ForeColor = Color.Black;
            lbBookingID.Location = new Point(23, 32);
            lbBookingID.Name = "lbBookingID";
            lbBookingID.Size = new Size(70, 15);
            lbBookingID.TabIndex = 38;
            lbBookingID.Text = "Booking ID:";
            // 
            // textBox9
            // 
            textBox9.BorderStyle = BorderStyle.FixedSingle;
            textBox9.Location = new Point(621, 129);
            textBox9.Margin = new Padding(3, 2, 3, 2);
            textBox9.Multiline = true;
            textBox9.Name = "textBox9";
            textBox9.Size = new Size(219, 27);
            textBox9.TabIndex = 37;
            // 
            // lbTotal
            // 
            lbTotal.AutoSize = true;
            lbTotal.BackColor = Color.White;
            lbTotal.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbTotal.ForeColor = Color.Black;
            lbTotal.Location = new Point(502, 140);
            lbTotal.Name = "lbTotal";
            lbTotal.Size = new Size(68, 15);
            lbTotal.TabIndex = 36;
            lbTotal.Text = "Total Price :";
            // 
            // textBox8
            // 
            textBox8.BorderStyle = BorderStyle.FixedSingle;
            textBox8.Location = new Point(621, 92);
            textBox8.Margin = new Padding(3, 2, 3, 2);
            textBox8.Multiline = true;
            textBox8.Name = "textBox8";
            textBox8.Size = new Size(219, 27);
            textBox8.TabIndex = 35;
            // 
            // lbDis
            // 
            lbDis.AutoSize = true;
            lbDis.BackColor = Color.White;
            lbDis.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbDis.ForeColor = Color.Black;
            lbDis.Location = new Point(503, 103);
            lbDis.Name = "lbDis";
            lbDis.Size = new Size(74, 15);
            lbDis.TabIndex = 34;
            lbDis.Text = "Discount % :";
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Location = new Point(621, 56);
            textBox7.Margin = new Padding(3, 2, 3, 2);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(219, 27);
            textBox7.TabIndex = 33;
            textBox7.TextChanged += textBox7_TextChanged;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.BackColor = Color.White;
            label13.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.Black;
            label13.Location = new Point(503, 65);
            label13.Name = "label13";
            label13.Size = new Size(60, 15);
            label13.TabIndex = 32;
            label13.Text = "Sub Total:";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Single", "Double", "VIP" });
            comboBox1.Location = new Point(130, 132);
            comboBox1.Margin = new Padding(3, 2, 3, 2);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(166, 27);
            comboBox1.TabIndex = 31;
            // 
            // dateTimePicker6
            // 
            dateTimePicker6.Location = new Point(130, 97);
            dateTimePicker6.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker6.Name = "dateTimePicker6";
            dateTimePicker6.Size = new Size(166, 26);
            dateTimePicker6.TabIndex = 30;
            // 
            // dateTimePicker5
            // 
            dateTimePicker5.Location = new Point(133, 59);
            dateTimePicker5.Margin = new Padding(3, 2, 3, 2);
            dateTimePicker5.Name = "dateTimePicker5";
            dateTimePicker5.Size = new Size(166, 26);
            dateTimePicker5.TabIndex = 29;
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.BackColor = Color.White;
            label20.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label20.ForeColor = Color.Black;
            label20.Location = new Point(508, 116);
            label20.Name = "label20";
            label20.Size = new Size(0, 15);
            label20.TabIndex = 26;
            // 
            // label21
            // 
            label21.AutoSize = true;
            label21.BackColor = Color.White;
            label21.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label21.ForeColor = Color.Black;
            label21.Location = new Point(23, 136);
            label21.Name = "label21";
            label21.Size = new Size(70, 15);
            label21.TabIndex = 24;
            label21.Text = "Room Type:";
            label21.Click += label21_Click;
            // 
            // textBox6
            // 
            textBox6.BorderStyle = BorderStyle.FixedSingle;
            textBox6.Location = new Point(621, 16);
            textBox6.Margin = new Padding(3, 2, 3, 2);
            textBox6.Multiline = true;
            textBox6.Name = "textBox6";
            textBox6.Size = new Size(219, 27);
            textBox6.TabIndex = 23;
            // 
            // label22
            // 
            label22.AutoSize = true;
            label22.BackColor = Color.White;
            label22.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label22.ForeColor = Color.Black;
            label22.Location = new Point(502, 30);
            label22.Name = "label22";
            label22.Size = new Size(77, 15);
            label22.TabIndex = 22;
            label22.Text = "Price / Night:";
            label22.Click += label22_Click;
            // 
            // label23
            // 
            label23.AutoSize = true;
            label23.BackColor = Color.White;
            label23.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label23.ForeColor = Color.Black;
            label23.Location = new Point(23, 103);
            label23.Name = "label23";
            label23.Size = new Size(94, 15);
            label23.TabIndex = 20;
            label23.Text = "Check-Out Date:";
            label23.Click += label23_Click;
            // 
            // label24
            // 
            label24.AutoSize = true;
            label24.BackColor = Color.White;
            label24.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label24.ForeColor = Color.Black;
            label24.Location = new Point(23, 67);
            label24.Name = "label24";
            label24.Size = new Size(85, 15);
            label24.TabIndex = 18;
            label24.Text = "Check-In Date:";
            // 
            // btbAdd
            // 
            btbAdd.BackColor = SystemColors.Highlight;
            btbAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btbAdd.ForeColor = Color.White;
            btbAdd.Location = new Point(290, 368);
            btbAdd.Margin = new Padding(3, 2, 3, 2);
            btbAdd.Name = "btbAdd";
            btbAdd.Size = new Size(104, 33);
            btbAdd.TabIndex = 6;
            btbAdd.Text = "Add";
            btbAdd.UseVisualStyleBackColor = false;
            btbAdd.Click += button1_Click_1;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.Red;
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(728, 368);
            btnClear.Margin = new Padding(3, 2, 3, 2);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(104, 33);
            btnClear.TabIndex = 7;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            btnClear.Click += button2_Click_1;
            // 
            // btnCancel
            // 
            btnCancel.BackColor = SystemColors.Highlight;
            btnCancel.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnCancel.ForeColor = Color.White;
            btnCancel.Location = new Point(577, 368);
            btnCancel.Margin = new Padding(3, 2, 3, 2);
            btnCancel.Name = "btnCancel";
            btnCancel.Size = new Size(104, 33);
            btnCancel.TabIndex = 8;
            btnCancel.Text = "Cancel";
            btnCancel.UseVisualStyleBackColor = false;
            // 
            // btnUpdate
            // 
            btnUpdate.BackColor = SystemColors.Highlight;
            btnUpdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnUpdate.ForeColor = Color.White;
            btnUpdate.Location = new Point(438, 368);
            btnUpdate.Margin = new Padding(3, 2, 3, 2);
            btnUpdate.Name = "btnUpdate";
            btnUpdate.Size = new Size(104, 33);
            btnUpdate.TabIndex = 9;
            btnUpdate.Text = "Update";
            btnUpdate.UseVisualStyleBackColor = false;
            btnUpdate.Click += button4_Click;
            // 
            // panel7
            // 
            panel7.BorderStyle = BorderStyle.FixedSingle;
            panel7.Controls.Add(comboBox2);
            panel7.Controls.Add(label19);
            panel7.Location = new Point(995, 215);
            panel7.Margin = new Padding(3, 2, 3, 2);
            panel7.Name = "panel7";
            panel7.Size = new Size(204, 139);
            panel7.TabIndex = 10;
            panel7.Paint += panel7_Paint;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Available", "Occupied", "Reserved" });
            comboBox2.Location = new Point(75, 9);
            comboBox2.Margin = new Padding(3, 2, 3, 2);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(115, 23);
            comboBox2.TabIndex = 32;
            // 
            // label19
            // 
            label19.AutoSize = true;
            label19.BackColor = Color.White;
            label19.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label19.ForeColor = Color.Black;
            label19.Location = new Point(15, 15);
            label19.Name = "label19";
            label19.Size = new Size(43, 15);
            label19.TabIndex = 19;
            label19.Text = "Status:";
            // 
            // panel11
            // 
            panel11.BackColor = SystemColors.Highlight;
            panel11.BorderStyle = BorderStyle.FixedSingle;
            panel11.Controls.Add(lbStatus);
            panel11.Location = new Point(995, 192);
            panel11.Margin = new Padding(3, 2, 3, 2);
            panel11.Name = "panel11";
            panel11.Size = new Size(204, 24);
            panel11.TabIndex = 11;
            panel11.Paint += panel11_Paint;
            // 
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lbStatus.ForeColor = Color.White;
            lbStatus.Location = new Point(55, 0);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(93, 19);
            lbStatus.TabIndex = 0;
            lbStatus.Text = "Room Status";
            lbStatus.TextAlign = ContentAlignment.MiddleLeft;
            lbStatus.Click += lbStatus_Click;
            // 
            // gReservatonlist
            // 
            gReservatonlist.Controls.Add(dataGridView1);
            gReservatonlist.Controls.Add(label17);
            gReservatonlist.FlatStyle = FlatStyle.Flat;
            gReservatonlist.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gReservatonlist.ForeColor = SystemColors.Highlight;
            gReservatonlist.Location = new Point(14, 416);
            gReservatonlist.Margin = new Padding(3, 2, 3, 2);
            gReservatonlist.Name = "gReservatonlist";
            gReservatonlist.Padding = new Padding(3, 2, 3, 2);
            gReservatonlist.Size = new Size(1185, 196);
            gReservatonlist.TabIndex = 12;
            gReservatonlist.TabStop = false;
            gReservatonlist.Text = "Reservation List";
            // 
            // dataGridView1
            // 
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { BookingID, GuestName, PhoneNumber, Room, CheckIn, Checkout, Status });
            dataGridView1.Location = new Point(11, 22);
            dataGridView1.Margin = new Padding(3, 2, 3, 2);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1174, 170);
            dataGridView1.TabIndex = 27;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // BookingID
            // 
            BookingID.HeaderText = "Booking ID";
            BookingID.MinimumWidth = 6;
            BookingID.Name = "BookingID";
            BookingID.Resizable = DataGridViewTriState.True;
            BookingID.Width = 200;
            // 
            // GuestName
            // 
            GuestName.HeaderText = "Guest Name";
            GuestName.MinimumWidth = 6;
            GuestName.Name = "GuestName";
            GuestName.Width = 200;
            // 
            // PhoneNumber
            // 
            PhoneNumber.HeaderText = "Phone Number";
            PhoneNumber.MinimumWidth = 6;
            PhoneNumber.Name = "PhoneNumber";
            PhoneNumber.Width = 200;
            // 
            // Room
            // 
            Room.HeaderText = "Room";
            Room.MinimumWidth = 6;
            Room.Name = "Room";
            Room.Width = 150;
            // 
            // CheckIn
            // 
            CheckIn.HeaderText = "Check In";
            CheckIn.MinimumWidth = 6;
            CheckIn.Name = "CheckIn";
            CheckIn.Width = 200;
            // 
            // Checkout
            // 
            Checkout.HeaderText = "Check Out";
            Checkout.MinimumWidth = 6;
            Checkout.Name = "Checkout";
            Checkout.Width = 200;
            // 
            // Status
            // 
            Status.HeaderText = "Status";
            Status.MinimumWidth = 6;
            Status.Name = "Status";
            Status.Width = 200;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.BackColor = Color.White;
            label17.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label17.ForeColor = Color.Black;
            label17.Location = new Point(508, 116);
            label17.Name = "label17";
            label17.Size = new Size(0, 15);
            label17.TabIndex = 26;
            // 
            // BookingControl
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            BorderStyle = BorderStyle.FixedSingle;
            Controls.Add(gReservatonlist);
            Controls.Add(panel11);
            Controls.Add(panel7);
            Controls.Add(btnUpdate);
            Controls.Add(btnCancel);
            Controls.Add(btnClear);
            Controls.Add(btbAdd);
            Controls.Add(groupBox1);
            Controls.Add(panel3);
            Controls.Add(RoomAvailable);
            Controls.Add(panel1);
            Controls.Add(lblGust);
            Margin = new Padding(2);
            Name = "BookingControl";
            Size = new Size(1271, 620);
            Load += BookingControl_Load;
            lblGust.ResumeLayout(false);
            lblGust.PerformLayout();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            RoomAvailable.ResumeLayout(false);
            RoomAvailable.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            groupBox1.ResumeLayout(false);
            groupBox1.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            panel11.ResumeLayout(false);
            panel11.PerformLayout();
            gReservatonlist.ResumeLayout(false);
            gReservatonlist.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private GroupBox lblGust;
        private Panel panel1;
        private Label label1;
        private Label lbGust;
        private Label label3;
        private TextBox textBox1;
        private Label label2;
        private TextBox textBox4;
        private TextBox textBox3;
        private Label label4;
        private TextBox textBox2;
        private Panel RoomAvailable;
        private Panel panel3;
        private Label label6;
        private Panel panel4;
        private Label label7;
        private Label label8;
        private Label label11;
        private Label label12;
        private Panel panel6;
        private Label label9;
        private Label label10;
        private Panel panel5;
        private GroupBox groupBox1;
        private Label label20;
        private Label label21;
        private TextBox textBox6;
        private Label label22;
        private Label label23;
        private Label label24;
        private DateTimePicker dateTimePicker5;
        private DateTimePicker dateTimePicker6;
        private Label label5;
        private TextBox textBox5;
        private ComboBox comboBox1;
        private TextBox textBox7;
        private Label label13;
        private TextBox textBox9;
        private Label lbTotal;
        private TextBox textBox8;
        private Label lbDis;
        private Button btbAdd;
        private Button btnClear;
        private Button btnCancel;
        private Button btnUpdate;
        private Panel panel7;
        private Label label19;
        private Panel panel11;
        private Label lbStatus;
        private ComboBox comboBox2;
        private GroupBox gReservatonlist;
        private Label label17;
        private DataGridView dataGridView1;
        private TextBox textBox10;
        private Label lbBookingID;
        private DataGridViewTextBoxColumn BookingID;
        private DataGridViewTextBoxColumn GuestName;
        private DataGridViewTextBoxColumn PhoneNumber;
        private DataGridViewTextBoxColumn Room;
        private DataGridViewTextBoxColumn CheckIn;
        private DataGridViewTextBoxColumn Checkout;
        private DataGridViewTextBoxColumn Status;
    }
}
