namespace GUI
{
    partial class ThemCongDan
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            label7 = new Label();
            txtCCCD = new TextBox();
            txtHoTen = new TextBox();
            txtQueQuan = new TextBox();
            txtThuongTru = new TextBox();
            dtpNgaySinh = new DateTimePicker();
            comboGioiTinh = new ComboBox();
            btnThem = new Button();
            button2 = new Button();
            btn_back = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(332, 94);
            label1.Name = "label1";
            label1.Size = new Size(215, 23);
            label1.TabIndex = 0;
            label1.Text = "Thêm công dân vào CSDL";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(111, 186);
            label2.Name = "label2";
            label2.Size = new Size(47, 20);
            label2.TabIndex = 1;
            label2.Text = "CCCD";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(111, 234);
            label3.Name = "label3";
            label3.Size = new Size(75, 20);
            label3.TabIndex = 2;
            label3.Text = "Họ và Tên";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(111, 279);
            label4.Name = "label4";
            label4.Size = new Size(68, 20);
            label4.TabIndex = 3;
            label4.Text = "Giới Tính";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(438, 177);
            label5.Name = "label5";
            label5.Size = new Size(74, 20);
            label5.TabIndex = 4;
            label5.Text = "Ngày sinh";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(438, 219);
            label6.Name = "label6";
            label6.Size = new Size(75, 20);
            label6.TabIndex = 5;
            label6.Text = "Quê Quán";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(431, 270);
            label7.Name = "label7";
            label7.Size = new Size(82, 20);
            label7.TabIndex = 6;
            label7.Text = "Thường trú";
            // 
            // txtCCCD
            // 
            txtCCCD.BorderStyle = BorderStyle.FixedSingle;
            txtCCCD.Location = new Point(222, 187);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(125, 27);
            txtCCCD.TabIndex = 7;
            // 
            // txtHoTen
            // 
            txtHoTen.BorderStyle = BorderStyle.FixedSingle;
            txtHoTen.Location = new Point(222, 234);
            txtHoTen.Name = "txtHoTen";
            txtHoTen.Size = new Size(125, 27);
            txtHoTen.TabIndex = 8;
            // 
            // txtQueQuan
            // 
            txtQueQuan.BorderStyle = BorderStyle.FixedSingle;
            txtQueQuan.Location = new Point(533, 217);
            txtQueQuan.Name = "txtQueQuan";
            txtQueQuan.Size = new Size(188, 27);
            txtQueQuan.TabIndex = 10;
            // 
            // txtThuongTru
            // 
            txtThuongTru.BorderStyle = BorderStyle.FixedSingle;
            txtThuongTru.Location = new Point(533, 268);
            txtThuongTru.Name = "txtThuongTru";
            txtThuongTru.Size = new Size(188, 27);
            txtThuongTru.TabIndex = 11;
            // 
            // dtpNgaySinh
            // 
            dtpNgaySinh.Location = new Point(533, 175);
            dtpNgaySinh.Name = "dtpNgaySinh";
            dtpNgaySinh.Size = new Size(250, 27);
            dtpNgaySinh.TabIndex = 12;
            // 
            // comboGioiTinh
            // 
            comboGioiTinh.FormattingEnabled = true;
            comboGioiTinh.Items.AddRange(new object[] { "Nam", "Nữ" });
            comboGioiTinh.Location = new Point(222, 275);
            comboGioiTinh.Name = "comboGioiTinh";
            comboGioiTinh.Size = new Size(151, 28);
            comboGioiTinh.TabIndex = 13;
            // 
            // btnThem
            // 
            btnThem.Location = new Point(257, 346);
            btnThem.Name = "btnThem";
            btnThem.Size = new Size(157, 35);
            btnThem.TabIndex = 14;
            btnThem.Text = "Thêm ";
            btnThem.UseVisualStyleBackColor = true;
            btnThem.Click += btnThem_Click;
            // 
            // button2
            // 
            button2.Location = new Point(431, 346);
            button2.Name = "button2";
            button2.Size = new Size(157, 35);
            button2.TabIndex = 15;
            button2.Text = "Làm mới";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // btn_back
            // 
            btn_back.Location = new Point(710, 421);
            btn_back.Name = "btn_back";
            btn_back.Size = new Size(157, 35);
            btn_back.TabIndex = 16;
            btn_back.Text = "Trở Về";
            btn_back.UseVisualStyleBackColor = true;
            btn_back.Click += btn_back_Click;
            // 
            // ThemCongDan
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg5;
            ClientSize = new Size(879, 468);
            Controls.Add(btn_back);
            Controls.Add(button2);
            Controls.Add(btnThem);
            Controls.Add(comboGioiTinh);
            Controls.Add(dtpNgaySinh);
            Controls.Add(txtThuongTru);
            Controls.Add(txtQueQuan);
            Controls.Add(txtHoTen);
            Controls.Add(txtCCCD);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "ThemCongDan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Thêm Công dân";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Label label7;
        private TextBox txtCCCD;
        private TextBox txtHoTen;
        private TextBox txtQueQuan;
        private TextBox txtThuongTru;
        private DateTimePicker dtpNgaySinh;
        private ComboBox comboGioiTinh;
        private Button btnThem;
        private Button button2;
        private Button btn_back;
    }
}