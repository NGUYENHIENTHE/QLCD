namespace GUI
{
    partial class DangNhap
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtMaNV = new TextBox();
            txtMatKhau = new TextBox();
            btnDangNhap = new Button();
            pictureBox2 = new PictureBox();
            pictureBox1 = new PictureBox();
            label1 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // txtMaNV
            // 
            txtMaNV.BorderStyle = BorderStyle.FixedSingle;
            txtMaNV.Location = new Point(374, 246);
            txtMaNV.MaximumSize = new Size(500, 30);
            txtMaNV.Name = "txtMaNV";
            txtMaNV.Size = new Size(261, 27);
            txtMaNV.TabIndex = 0;
            txtMaNV.TextChanged += txtMaNV_TextChanged;
            // 
            // txtMatKhau
            // 
            txtMatKhau.BorderStyle = BorderStyle.FixedSingle;
            txtMatKhau.Location = new Point(374, 298);
            txtMatKhau.MaximumSize = new Size(500, 30);
            txtMatKhau.Name = "txtMatKhau";
            txtMatKhau.Size = new Size(261, 27);
            txtMatKhau.TabIndex = 1;
            // 
            // btnDangNhap
            // 
            btnDangNhap.BackColor = Color.OrangeRed;
            btnDangNhap.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnDangNhap.Location = new Point(359, 350);
            btnDangNhap.Name = "btnDangNhap";
            btnDangNhap.Size = new Size(276, 64);
            btnDangNhap.TabIndex = 2;
            btnDangNhap.Text = "Đăng nhập";
            btnDangNhap.UseVisualStyleBackColor = false;
            btnDangNhap.Click += btnDangNhap_Click;
            // 
            // pictureBox2
            // 
            pictureBox2.Image = Properties.Resources.pass;
            pictureBox2.Location = new Point(320, 287);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(30, 38);
            pictureBox2.TabIndex = 4;
            pictureBox2.TabStop = false;
            pictureBox2.Click += pictureBox2_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.user;
            pictureBox1.Location = new Point(320, 246);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(32, 27);
            pictureBox1.TabIndex = 3;
            pictureBox1.TabStop = false;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Tahoma", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.Red;
            label1.Location = new Point(254, 57);
            label1.Name = "label1";
            label1.Size = new Size(490, 28);
            label1.TabIndex = 5;
            label1.Text = "PHẦN MỀM QUẢN LÝ DỮ LIỆU CÔNG DÂN";
            // 
            // DangNhap
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            BackgroundImage = Properties.Resources.bg1;
            ClientSize = new Size(963, 489);
            Controls.Add(label1);
            Controls.Add(pictureBox2);
            Controls.Add(pictureBox1);
            Controls.Add(btnDangNhap);
            Controls.Add(txtMatKhau);
            Controls.Add(txtMaNV);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Name = "DangNhap";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang Đăng Nhập";
            Load += DangNhap_Load;
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtMaNV;
        private TextBox txtMatKhau;
        private Button btnDangNhap;
        private PictureBox pictureBox2;
        private PictureBox pictureBox1;
        private Label label1;
    }
}
