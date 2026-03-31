namespace Hotel_System
{
    partial class RoomControl
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(RoomControl));
            button1 = new Button();
            textBox1 = new TextBox();
            label2 = new Label();
            button2 = new Button();
            button3 = new Button();
            button4 = new Button();
            button5 = new Button();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            textBox2 = new TextBox();
            textBox3 = new TextBox();
            pictureBox1 = new PictureBox();
            label7 = new Label();
            dataGridView1 = new DataGridView();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            PaymentID = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            RoomNumber = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            PaymentDate = new DataGridViewTextBoxColumn();
            comboBox2 = new ComboBox();
            comboBox1 = new ComboBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = Color.MidnightBlue;
            button1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.Transparent;
            button1.Location = new Point(123, 477);
            button1.Name = "button1";
            button1.Size = new Size(120, 44);
            button1.TabIndex = 7;
            button1.Tag = "";
            button1.Text = "Add";
            button1.UseVisualStyleBackColor = false;
            // 
            // textBox1
            // 
            textBox1.Location = new Point(253, 133);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(368, 39);
            textBox1.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.Control;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(123, 146);
            label2.Name = "label2";
            label2.Size = new Size(85, 23);
            label2.TabIndex = 6;
            label2.Text = "Room ID:";
            label2.Click += label2_Click;
            // 
            // button2
            // 
            button2.Location = new Point(264, 477);
            button2.Name = "button2";
            button2.Size = new Size(120, 44);
            button2.TabIndex = 7;
            button2.Text = "Update";
            button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            button3.Location = new Point(410, 478);
            button3.Name = "button3";
            button3.Size = new Size(120, 44);
            button3.TabIndex = 8;
            button3.Text = "Delete";
            button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            button4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button4.Location = new Point(720, 476);
            button4.Name = "button4";
            button4.Size = new Size(120, 44);
            button4.TabIndex = 9;
            button4.Text = "Clear";
            button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            button5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            button5.Location = new Point(569, 476);
            button5.Name = "button5";
            button5.Size = new Size(120, 44);
            button5.TabIndex = 10;
            button5.Text = "Search";
            button5.UseVisualStyleBackColor = true;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(123, 197);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 11;
            label3.Text = "Room Number:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(123, 259);
            label4.Name = "label4";
            label4.Size = new Size(105, 23);
            label4.TabIndex = 12;
            label4.Text = "Room Type:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(123, 321);
            label5.Name = "label5";
            label5.Size = new Size(49, 23);
            label5.TabIndex = 13;
            label5.Text = "Price";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(123, 374);
            label6.Name = "label6";
            label6.Size = new Size(60, 23);
            label6.TabIndex = 14;
            label6.Text = "Status";
            // 
            // textBox2
            // 
            textBox2.Location = new Point(253, 305);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(368, 39);
            textBox2.TabIndex = 15;
            // 
            // textBox3
            // 
            textBox3.Location = new Point(253, 194);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(368, 39);
            textBox3.TabIndex = 16;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(859, 133);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(569, 373);
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            pictureBox1.Click += pictureBox1_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.Gainsboro;
            label7.Cursor = Cursors.IBeam;
            label7.FlatStyle = FlatStyle.Popup;
            label7.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label7.ForeColor = SystemColors.ActiveCaptionText;
            label7.Location = new Point(1093, 107);
            label7.Name = "label7";
            label7.Size = new Size(111, 23);
            label7.TabIndex = 19;
            label7.Text = "Type of room";
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { PaymentID, CustomerName, RoomNumber, TotalAmount, PaymentDate });
            dataGridView1.Location = new Point(90, 540);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(1246, 313);
            dataGridView1.TabIndex = 27;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Available", "Occupied", "Reserved", "Maintenance" });
            comboBox2.Location = new Point(253, 369);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(368, 28);
            comboBox2.TabIndex = 17;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Single Room", "", "Double Room", "Deluxe Room", "Luxury Room", "Family Room" });
            comboBox1.Location = new Point(253, 254);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(368, 28);
            comboBox1.TabIndex = 4;
            // 
            // PaymentID
            // 
            PaymentID.DividerWidth = 1;
            PaymentID.HeaderText = "Room ID";
            PaymentID.MinimumWidth = 20;
            PaymentID.Name = "PaymentID";
            PaymentID.Width = 170;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Number";
            CustomerName.MinimumWidth = 20;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 200;
            // 
            // RoomNumber
            // 
            RoomNumber.HeaderText = "Type";
            RoomNumber.MinimumWidth = 20;
            RoomNumber.Name = "RoomNumber";
            RoomNumber.Width = 150;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Price";
            TotalAmount.MinimumWidth = 20;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Width = 200;
            // 
            // PaymentDate
            // 
            PaymentDate.HeaderText = "Status";
            PaymentDate.MinimumWidth = 20;
            PaymentDate.Name = "PaymentDate";
            PaymentDate.Width = 200;
            // 
            // comboBox2
            // 
            comboBox2.FormattingEnabled = true;
            comboBox2.Items.AddRange(new object[] { "Available", "Occupied", "Reserved", "Maintenance" });
            comboBox2.Location = new Point(253, 369);
            comboBox2.Name = "comboBox2";
            comboBox2.Size = new Size(368, 28);
            comboBox2.TabIndex = 17;
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Single Room", "", "Double Room", "Deluxe Room", "Luxury Room", "Family Room" });
            comboBox1.Location = new Point(253, 254);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(368, 28);
            comboBox1.TabIndex = 4;
            // 
            // label1
            // 
            label1.BackColor = Color.MidnightBlue;
            label1.Dock = DockStyle.Top;
            label1.Font = new Font("Segoe UI", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Transparent;
            label1.Location = new Point(0, 0);
            label1.Name = "label1";
            label1.Size = new Size(1447, 90);
            label1.TabIndex = 0;
            label1.Text = "Room Manangement";
            label1.TextAlign = ContentAlignment.MiddleCenter;
            // 
            // RoomControl
            // 
            AutoScaleDimensions = new SizeF(9F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(dataGridView1);
            Controls.Add(label7);
            Controls.Add(pictureBox1);
            Controls.Add(comboBox2);
            Controls.Add(textBox3);
            Controls.Add(textBox2);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(button5);
            Controls.Add(button4);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(label2);
            Controls.Add(comboBox1);
            Controls.Add(textBox1);
            Controls.Add(button1);
            Controls.Add(label1);
            Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            Margin = new Padding(2);
            Name = "RoomControl";
            Size = new Size(1447, 791);
            Load += RoomControl_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button button1;
        private TextBox textBox1;
        private Label label2;
        private Button button2;
        private Button button3;
        private Button button4;
        private Button button5;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox textBox2;
        private TextBox textBox3;
        private PictureBox pictureBox1;
        private Label label7;
        private DataGridView dataGridView1;
        private ComboBox comboBox2;
        private ComboBox comboBox1;
        private DataGridViewTextBoxColumn PaymentID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn RoomNumber;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn PaymentDate;
        private Label label1;
    }
}