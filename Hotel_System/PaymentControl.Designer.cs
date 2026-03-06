namespace Hotel_System
{
    partial class PaymentControl
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
            panel1 = new Panel();
            dataGridView1 = new DataGridView();
            PaymentID = new DataGridViewTextBoxColumn();
            CustomerName = new DataGridViewTextBoxColumn();
            RoomNumber = new DataGridViewTextBoxColumn();
            TotalAmount = new DataGridViewTextBoxColumn();
            PaymentDate = new DataGridViewTextBoxColumn();
            btnPay = new Button();
            btnClear = new Button();
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
            label7 = new Label();
            label1 = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(dataGridView1);
            panel1.Controls.Add(btnPay);
            panel1.Controls.Add(btnClear);
            panel1.Controls.Add(textBox5);
            panel1.Controls.Add(textBox2);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(textBox1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(textBox3);
            panel1.Controls.Add(textBox4);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(53, 33);
            panel1.Margin = new Padding(50);
            panel1.Name = "panel1";
            panel1.Padding = new Padding(50);
            panel1.Size = new Size(1703, 734);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // dataGridView1
            // 
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToOrderColumns = true;
            dataGridView1.BackgroundColor = Color.White;
            dataGridView1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridView1.Columns.AddRange(new DataGridViewColumn[] { PaymentID, CustomerName, RoomNumber, TotalAmount, PaymentDate });
            dataGridView1.Location = new Point(737, 0);
            dataGridView1.Name = "dataGridView1";
            dataGridView1.RowHeadersWidth = 51;
            dataGridView1.Size = new Size(966, 734);
            dataGridView1.TabIndex = 26;
            dataGridView1.CellContentClick += dataGridView1_CellContentClick;
            // 
            // PaymentID
            // 
            PaymentID.DividerWidth = 1;
            PaymentID.HeaderText = "PaymentID";
            PaymentID.MinimumWidth = 20;
            PaymentID.Name = "PaymentID";
            PaymentID.Width = 170;
            // 
            // CustomerName
            // 
            CustomerName.HeaderText = "Customer Name";
            CustomerName.MinimumWidth = 20;
            CustomerName.Name = "CustomerName";
            CustomerName.Width = 200;
            // 
            // RoomNumber
            // 
            RoomNumber.HeaderText = "Room Number";
            RoomNumber.MinimumWidth = 20;
            RoomNumber.Name = "RoomNumber";
            RoomNumber.Width = 150;
            // 
            // TotalAmount
            // 
            TotalAmount.HeaderText = "Total Amount";
            TotalAmount.MinimumWidth = 20;
            TotalAmount.Name = "TotalAmount";
            TotalAmount.Width = 200;
            // 
            // PaymentDate
            // 
            PaymentDate.HeaderText = "Payment Date";
            PaymentDate.MinimumWidth = 20;
            PaymentDate.Name = "PaymentDate";
            PaymentDate.Width = 200;
            // 
            // btnPay
            // 
            btnPay.BackColor = Color.DarkTurquoise;
            btnPay.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnPay.ForeColor = Color.White;
            btnPay.Location = new Point(233, 483);
            btnPay.Name = "btnPay";
            btnPay.Size = new Size(116, 46);
            btnPay.TabIndex = 25;
            btnPay.Text = "Pay";
            btnPay.UseVisualStyleBackColor = false;
            // 
            // btnClear
            // 
            btnClear.BackColor = Color.DarkTurquoise;
            btnClear.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnClear.ForeColor = Color.White;
            btnClear.Location = new Point(381, 483);
            btnClear.Name = "btnClear";
            btnClear.Size = new Size(116, 46);
            btnClear.TabIndex = 24;
            btnClear.Text = "Clear";
            btnClear.UseVisualStyleBackColor = false;
            // 
            // textBox5
            // 
            textBox5.BorderStyle = BorderStyle.FixedSingle;
            textBox5.Location = new Point(208, 333);
            textBox5.Multiline = true;
            textBox5.Name = "textBox5";
            textBox5.Size = new Size(399, 44);
            textBox5.TabIndex = 23;
            textBox5.TextChanged += textBox5_TextChanged;
            // 
            // textBox2
            // 
            textBox2.BorderStyle = BorderStyle.FixedSingle;
            textBox2.Location = new Point(208, 404);
            textBox2.Multiline = true;
            textBox2.Name = "textBox2";
            textBox2.Size = new Size(399, 44);
            textBox2.TabIndex = 22;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = Color.White;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.ForeColor = Color.Black;
            label5.Location = new Point(54, 425);
            label5.Name = "label5";
            label5.Size = new Size(123, 23);
            label5.TabIndex = 21;
            label5.Text = "Payment Date";
            label5.Click += label5_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.White;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.Black;
            label4.Location = new Point(53, 354);
            label4.Name = "label4";
            label4.Size = new Size(124, 23);
            label4.TabIndex = 20;
            label4.Text = "Total  Amount";
            // 
            // textBox1
            // 
            textBox1.BorderStyle = BorderStyle.FixedSingle;
            textBox1.Location = new Point(208, 264);
            textBox1.Multiline = true;
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(399, 44);
            textBox1.TabIndex = 19;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = Color.White;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.Black;
            label3.Location = new Point(53, 285);
            label3.Name = "label3";
            label3.Size = new Size(128, 23);
            label3.TabIndex = 18;
            label3.Text = "Room Number";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = Color.White;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.Black;
            label2.Location = new Point(53, 144);
            label2.Name = "label2";
            label2.Size = new Size(103, 23);
            label2.TabIndex = 17;
            label2.Text = "Payment ID";
            // 
            // textBox3
            // 
            textBox3.BorderStyle = BorderStyle.FixedSingle;
            textBox3.Location = new Point(208, 194);
            textBox3.Multiline = true;
            textBox3.Name = "textBox3";
            textBox3.Size = new Size(399, 44);
            textBox3.TabIndex = 16;
            textBox3.TextChanged += textBox3_TextChanged;
            // 
            // textBox4
            // 
            textBox4.BorderStyle = BorderStyle.FixedSingle;
            textBox4.Location = new Point(208, 123);
            textBox4.Multiline = true;
            textBox4.Name = "textBox4";
            textBox4.Size = new Size(399, 44);
            textBox4.TabIndex = 15;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = Color.White;
            label6.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.Black;
            label6.Location = new Point(53, 215);
            label6.Name = "label6";
            label6.Size = new Size(139, 23);
            label6.TabIndex = 14;
            label6.Text = "Customer Name";
            label6.Click += label6_Click;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = Color.White;
            label7.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.ForeColor = Color.DarkGray;
            label7.Location = new Point(53, 144);
            label7.Name = "label7";
            label7.Size = new Size(0, 23);
            label7.TabIndex = 13;
            label7.Click += label7_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.DarkTurquoise;
            label1.Font = new Font("Segoe UI", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.White;
            label1.Location = new Point(265, 17);
            label1.Name = "label1";
            label1.Size = new Size(255, 31);
            label1.TabIndex = 0;
            label1.Text = "Payment Management";
            // 
            // PaymentControl
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.White;
            Controls.Add(panel1);
            Margin = new Padding(2);
            Name = "PaymentControl";
            Padding = new Padding(50);
            Size = new Size(1805, 828);
            Load += PaymentControl_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dataGridView1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private TextBox textBox3;
        private TextBox textBox4;
        private Label label6;
        private Label label7;
        private TextBox textBox5;
        private TextBox textBox2;
        private Label label5;
        private Label label4;
        private TextBox textBox1;
        private Label label3;
        private Label label2;
        private Button btnPay;
        private Button btnClear;
        private DataGridView dataGridView1;
        private DataGridViewTextBoxColumn PaymentID;
        private DataGridViewTextBoxColumn CustomerName;
        private DataGridViewTextBoxColumn RoomNumber;
        private DataGridViewTextBoxColumn TotalAmount;
        private DataGridViewTextBoxColumn PaymentDate;
    }
}
