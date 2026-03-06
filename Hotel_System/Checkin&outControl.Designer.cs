namespace Hotel_System
{
    partial class Checkin_outControl
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
            TabControl tabControl1;
            tabPage1 = new TabPage();
            btnAdd = new Button();
            btnupdate = new Button();
            textBox10 = new TextBox();
            textBox11 = new TextBox();
            label1 = new Label();
            label7 = new Label();
            textBox12 = new TextBox();
            label8 = new Label();
            label9 = new Label();
            textBox13 = new TextBox();
            textBox14 = new TextBox();
            label10 = new Label();
            textBox7 = new TextBox();
            textBox5 = new TextBox();
            textBox2 = new TextBox();
            label5 = new Label();
            label4 = new Label();
            textBox1 = new TextBox();
            label3 = new Label();
            label2 = new Label();
            textBox3 = new TextBox();
            textBox4 = new TextBox();
            label6 = new Label();
            tabPage2 = new TabPage();
            panel1 = new Panel();
            button1 = new Button();
            panel2 = new Panel();
            label12 = new Label();
            label11 = new Label();
            panel3 = new Panel();
            label13 = new Label();
            dgvCheckin = new DataGridView();
            Advancepayment = new DataGridViewTextBoxColumn();
            discount = new DataGridViewTextBoxColumn();
            SubTotal = new DataGridViewTextBoxColumn();
            NoAdults = new DataGridViewTextBoxColumn();
            NoChildren = new DataGridViewTextBoxColumn();
            NoOfDays = new DataGridViewTextBoxColumn();
            CheckOutDate = new DataGridViewTextBoxColumn();
            CheckInDate = new DataGridViewTextBoxColumn();
            RoomType = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            RoomID = new DataGridViewTextBoxColumn();
            tabControl1 = new TabControl();
            tabControl1.SuspendLayout();
            tabPage1.SuspendLayout();
            tabPage2.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCheckin).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage1);
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(39, 28);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1719, 785);
            tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            tabPage1.BackColor = Color.White;
            tabPage1.BorderStyle = BorderStyle.FixedSingle;
            tabPage1.Controls.Add(label11);
            tabPage1.Controls.Add(panel2);
            tabPage1.Controls.Add(button1);
            tabPage1.Controls.Add(btnAdd);
            tabPage1.Controls.Add(btnupdate);
            tabPage1.Controls.Add(textBox10);
            tabPage1.Controls.Add(textBox11);
            tabPage1.Controls.Add(label1);
            tabPage1.Controls.Add(label7);
            tabPage1.Controls.Add(textBox12);
            tabPage1.Controls.Add(label8);
            tabPage1.Controls.Add(label9);
            tabPage1.Controls.Add(textBox13);
            tabPage1.Controls.Add(textBox14);
            tabPage1.Controls.Add(label10);
            tabPage1.Controls.Add(textBox7);
            tabPage1.Controls.Add(textBox5);
            tabPage1.Controls.Add(textBox2);
            tabPage1.Controls.Add(label5);
            tabPage1.Controls.Add(label4);
            tabPage1.Controls.Add(textBox1);
            tabPage1.Controls.Add(label3);
            tabPage1.Controls.Add(label2);
            tabPage1.Controls.Add(textBox3);
            tabPage1.Controls.Add(textBox4);
            tabPage1.Controls.Add(label6);
            tabPage1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            tabPage1.ForeColor = Color.Black;
            tabPage1.Location = new Point(4, 29);
            tabPage1.Name = "tabPage1";
            tabPage1.Padding = new Padding(3);
            tabPage1.Size = new Size(1711, 752);
            tabPage1.TabIndex = 0;
            tabPage1.Text = "Check In";
            tabPage1.Click += tabPage1_Click;
            // 
            // btnAdd
            // 
            btnAdd.BackColor = Color.DarkTurquoise;
            btnAdd.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnAdd.ForeColor = Color.White;
            btnAdd.Location = new Point(1098, 495);
            btnAdd.Name = "btnAdd";
            btnAdd.Size = new Size(116, 46);
            btnAdd.TabIndex = 47;
            btnAdd.Text = "Add";
            btnAdd.UseVisualStyleBackColor = false;
            // 
            // btnupdate
            // 
            btnupdate.BackColor = Color.DarkTurquoise;
            btnupdate.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnupdate.ForeColor = Color.White;
            btnupdate.Location = new Point(1381, 495);
            btnupdate.Name = "btnupdate";
            btnupdate.Size = new Size(116, 46);
            btnupdate.TabIndex = 46;
            btnupdate.Text = "Search";
            btnupdate.UseVisualStyleBackColor = false;
            // 
            // textBox10
            // 
            textBox10.BorderStyle = BorderStyle.FixedSingle;
            textBox10.Location = new Point(1098, 191);
            textBox10.Multiline = true;
            textBox10.Name = "textBox10";
            textBox10.Size = new Size(399, 44);
            textBox10.TabIndex = 45;
            // 
            // textBox11
            // 
            textBox11.BorderStyle = BorderStyle.FixedSingle;
            textBox11.Location = new Point(1098, 263);
            textBox11.Multiline = true;
            textBox11.Name = "textBox11";
            textBox11.Size = new Size(399, 44);
            textBox11.TabIndex = 44;
            textBox11.TextChanged += textBox11_TextChanged;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.White;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Black;
            label1.Location = new Point(925, 212);
            label1.Name = "label1";
            label1.Size = new Size(120, 23);
            label1.TabIndex = 43;
            label1.Text = "No. Of Adults";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(925, 284);
            label7.Name = "label7";
            label7.Size = new Size(85, 23);
            label7.TabIndex = 42;
            label7.Text = "Sub Total";
            // 
            // textBox12
            // 
            textBox12.BorderStyle = BorderStyle.FixedSingle;
            textBox12.Location = new Point(1098, 116);
            textBox12.Multiline = true;
            textBox12.Name = "textBox12";
            textBox12.Size = new Size(399, 44);
            textBox12.TabIndex = 41;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = Color.White;
            label8.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(925, 364);
            label8.Name = "label8";
            label8.Size = new Size(100, 23);
            label8.TabIndex = 40;
            label8.Text = "Discount %";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = Color.White;
            label9.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label9.ForeColor = Color.Black;
            label9.Location = new Point(150, 516);
            label9.Name = "label9";
            label9.Size = new Size(106, 23);
            label9.TabIndex = 39;
            label9.Text = "No. Of Days";
            label9.Click += label9_Click;
            // 
            // textBox13
            // 
            textBox13.BorderStyle = BorderStyle.FixedSingle;
            textBox13.Location = new Point(1098, 343);
            textBox13.Multiline = true;
            textBox13.Name = "textBox13";
            textBox13.Size = new Size(399, 44);
            textBox13.TabIndex = 38;
            // 
            // textBox14
            // 
            textBox14.BorderStyle = BorderStyle.FixedSingle;
            textBox14.Location = new Point(1098, 418);
            textBox14.Multiline = true;
            textBox14.Name = "textBox14";
            textBox14.Size = new Size(399, 44);
            textBox14.TabIndex = 37;
            textBox14.TextChanged += textBox14_TextChanged;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = Color.White;
            label10.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label10.ForeColor = Color.Black;
            label10.Location = new Point(925, 137);
            label10.Name = "label10";
            label10.Size = new Size(136, 23);
            label10.TabIndex = 36;
            label10.Text = "No. Of Children";
            // 
            // textBox7
            // 
            textBox7.BorderStyle = BorderStyle.FixedSingle;
            textBox7.Location = new Point(348, 495);
            textBox7.Multiline = true;
            textBox7.Name = "textBox7";
            textBox7.Size = new Size(399, 44);
            textBox7.TabIndex = 35;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(348, 333);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(399, 44);
            textBox5.TabIndex = 33;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(348, 410);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(399, 44);
            textBox2.TabIndex = 32;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(150, 284);
            label5.Name = "label5";
            label5.Size = new Size(100, 23);
            label5.TabIndex = 31;
            label5.Text = "Room Type";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(150, 439);
            label4.Name = "label4";
            label4.Size = new Size(136, 23);
            label4.TabIndex = 30;
            label4.Text = "Check Out Date";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(348, 261);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(399, 44);
            textBox1.TabIndex = 29;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(150, 364);
            label3.Name = "label3";
            label3.Size = new Size(121, 23);
            label3.TabIndex = 28;
            label3.Text = "Check In Date";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(150, 137);
            label2.Name = "label2";
            label2.Size = new Size(80, 23);
            label2.TabIndex = 27;
            label2.Text = "Room ID";
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(348, 188);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(399, 44);
            textBox3.TabIndex = 26;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(348, 116);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(399, 44);
            textBox4.TabIndex = 25;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(150, 212);
            label6.Name = "label6";
            label6.Size = new Size(139, 23);
            label6.TabIndex = 24;
            label6.Text = "Customer Name";
            label6.Click += label6_Click;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(dgvCheckin);
            tabPage2.Controls.Add(panel3);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(1711, 722);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "Check In List";
            tabPage2.UseVisualStyleBackColor = true;
            tabPage2.Click += tabPage2_Click;
            // 
            // panel1
            // 
            panel1.Location = new Point(39, 57);
            panel1.Name = "panel1";
            panel1.Size = new Size(1715, 753);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button1
            // 
            button1.BackColor = Color.DarkTurquoise;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.White;
            button1.Location = new Point(1244, 493);
            button1.Name = "button1";
            button1.Size = new Size(116, 46);
            button1.TabIndex = 48;
            button1.Text = "Update";
            button1.UseVisualStyleBackColor = false;
            // 
            // panel2
            // 
            panel2.BackColor = Color.DarkTurquoise;
            panel2.Controls.Add(label12);
            panel2.Dock = DockStyle.Top;
            panel2.Location = new Point(3, 3);
            panel2.Name = "panel2";
            panel2.Size = new Size(1703, 59);
            panel2.TabIndex = 50;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label12.ForeColor = Color.White;
            label12.Location = new Point(687, 0);
            label12.Name = "label12";
            label12.Size = new Size(316, 41);
            label12.TabIndex = 0;
            label12.Text = "Check In Information";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.BackColor = Color.White;
            label11.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label11.ForeColor = Color.Black;
            label11.Location = new Point(925, 439);
            label11.Name = "label11";
            label11.Size = new Size(153, 23);
            label11.TabIndex = 51;
            label11.Text = "Advance Payment";
            // 
            // panel3
            // 
            panel3.BackColor = Color.DarkTurquoise;
            panel3.Controls.Add(label13);
            panel3.Dock = DockStyle.Top;
            panel3.Location = new Point(3, 3);
            panel3.Name = "panel3";
            panel3.Size = new Size(1705, 59);
            panel3.TabIndex = 51;
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label13.ForeColor = Color.White;
            label13.Location = new Point(687, 0);
            label13.Name = "label13";
            label13.Size = new Size(316, 41);
            label13.TabIndex = 0;
            label13.Text = "Check In Information";
            // 
            // dgvCheckin
            // 
            dgvCheckin.BackgroundColor = Color.White;
            dgvCheckin.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvCheckin.Columns.AddRange(new DataGridViewColumn[] { RoomID, CustomerName, RoomType, CheckInDate, CheckOutDate, NoOfDays, NoChildren, NoAdults, SubTotal, discount, Advancepayment });
            dgvCheckin.Location = new Point(6, 68);
            dgvCheckin.Name = "dgvCheckin";
            dgvCheckin.RowHeadersWidth = 51;
            dgvCheckin.Size = new Size(1702, 566);
            dgvCheckin.TabIndex = 52;
            // 
            // Advancepayment
            // 
            Advancepayment.HeaderText = "Advance Payment";
            Advancepayment.MinimumWidth = 6;
            Advancepayment.Name = "Advancepayment";
            Advancepayment.Width = 180;
            // 
            // discount
            // 
            discount.HeaderText = "Discount %";
            discount.MinimumWidth = 6;
            discount.Name = "discount";
            discount.Width = 125;
            // 
            // SubTotal
            // 
            SubTotal.HeaderText = "Sub Total";
            SubTotal.MinimumWidth = 6;
            SubTotal.Name = "SubTotal";
            SubTotal.Width = 125;
            // 
            // NoAdults
            // 
            NoAdults.HeaderText = "No. Adults";
            NoAdults.MinimumWidth = 6;
            NoAdults.Name = "NoAdults";
            NoAdults.Width = 130;
            // 
            // NoChildren
            // 
            NoChildren.HeaderText = "No. Of Children";
            NoChildren.MinimumWidth = 6;
            NoChildren.Name = "NoChildren";
            NoChildren.Width = 150;
            // 
            // NoOfDays
            // 
            NoOfDays.HeaderText = "No. Of Days";
            NoOfDays.MinimumWidth = 6;
            NoOfDays.Name = "NoOfDays";
            NoOfDays.Width = 130;
            // 
            // CheckOutDate
            // 
            CheckOutDate.HeaderText = "Check Out Date";
            CheckOutDate.MinimumWidth = 20;
            CheckOutDate.Name = "CheckOutDate";
            CheckOutDate.Width = 170;
            // 
            // CheckInDate
            // 
            CheckInDate.HeaderText = "Check In Date";
            CheckInDate.MinimumWidth = 20;
            CheckInDate.Name = "CheckInDate";
            CheckInDate.Width = 170;
            // 
            // RoomType
            // 
            RoomType.HeaderText = "Room Type";
            RoomType.MinimumWidth = 10;
            RoomType.Name = "RoomType";
            RoomType.Width = 170;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Customer Name";
            CustomerName.MinimumWidth = 20;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 190;
            // 
            // RoomID
            // 
            RoomID.HeaderText = "Room ID";
            RoomID.MinimumWidth = 20;
            RoomID.Name = "RoomID";
            RoomID.Width = 125;
            // 
            // Checkin_outControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "Checkin_outControl";
            Size = new Size(1455, 700);
            Load += Checkin_outControl_Load;
            tabControl1.ResumeLayout(false);
            tabPage1.ResumeLayout(false);
            tabPage1.PerformLayout();
            tabPage2.ResumeLayout(false);
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvCheckin).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private TabControl tabControl1;
        private TabPage tabPage1;
        private TabPage tabPage2;
        private TextBox textBox5;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private TextBox textBox7;
        private TextBox textBox10;
        private TextBox textBox11;
        private Label label1;
        private Label label7;
        private TextBox textBox12;
        private Label label8;
        private Label label9;
        private TextBox textBox13;
        private TextBox textBox14;
        private Label label10;
        private Button btnAdd;
        private Button btnupdate;
        private Button button1;
        private Panel panel2;
        private Label label12;
        private Label label11;
        private Panel panel3;
        private Label label13;
        private DataGridView dgvCheckin;
        private DataGridViewTextBoxColumn RoomID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn RoomType;
        private DataGridViewTextBoxColumn CheckInDate;
        private DataGridViewTextBoxColumn CheckOutDate;
        private DataGridViewTextBoxColumn NoOfDays;
        private DataGridViewTextBoxColumn NoChildren;
        private DataGridViewTextBoxColumn NoAdults;
        private DataGridViewTextBoxColumn SubTotal;
        private DataGridViewTextBoxColumn discount;
        private DataGridViewTextBoxColumn Advancepayment;
    }
}
