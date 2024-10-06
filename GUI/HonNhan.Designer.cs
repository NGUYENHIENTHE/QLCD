namespace GUI
{
    partial class HonNhan
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
            txtCccdNguoiChong = new TextBox();
            txtCccdNguoiVo = new TextBox();
            txtNoiDangKy = new TextBox();
            btnXacNhan = new Button();
            btnLamMoi = new Button();
            dtpNgayDangKy = new DateTimePicker();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(302, 51);
            label1.Name = "label1";
            label1.Size = new Size(209, 25);
            label1.TabIndex = 0;
            label1.Text = "GIẤY ĐĂNG KÝ KẾT HÔN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(25, 109);
            label2.Name = "label2";
            label2.Size = new Size(180, 25);
            label2.TabIndex = 1;
            label2.Text = "CCCD Người Chồng :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(404, 109);
            label3.Name = "label3";
            label3.Size = new Size(149, 25);
            label3.TabIndex = 2;
            label3.Text = "CCCD Người Vợ :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(25, 164);
            label4.Name = "label4";
            label4.Size = new Size(134, 25);
            label4.TabIndex = 3;
            label4.Text = "Ngày Đăng Ký :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(433, 170);
            label5.Name = "label5";
            label5.Size = new Size(120, 25);
            label5.TabIndex = 4;
            label5.Text = "Nơi Đăng Ký :";
            // 
            // txtCccdNguoiChong
            // 
            txtCccdNguoiChong.Location = new Point(216, 112);
            txtCccdNguoiChong.Name = "txtCccdNguoiChong";
            txtCccdNguoiChong.Size = new Size(150, 31);
            txtCccdNguoiChong.TabIndex = 5;
            // 
            // txtCccdNguoiVo
            // 
            txtCccdNguoiVo.Location = new Point(565, 111);
            txtCccdNguoiVo.Name = "txtCccdNguoiVo";
            txtCccdNguoiVo.Size = new Size(150, 31);
            txtCccdNguoiVo.TabIndex = 7;
            // 
            // txtNoiDangKy
            // 
            txtNoiDangKy.Location = new Point(565, 167);
            txtNoiDangKy.Name = "txtNoiDangKy";
            txtNoiDangKy.Size = new Size(150, 31);
            txtNoiDangKy.TabIndex = 8;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(221, 272);
            btnXacNhan.Name = "btnLuu";
            btnXacNhan.Size = new Size(112, 34);
            btnXacNhan.TabIndex = 9;
            btnXacNhan.Text = "Xác Nhận ";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnLuu_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(384, 272);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 34);
            btnLamMoi.TabIndex = 10;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dtpNgayDangKy
            // 
            dtpNgayDangKy.Location = new Point(163, 165);
            dtpNgayDangKy.Name = "dtpNgayDangKy";
            dtpNgayDangKy.Size = new Size(235, 31);
            dtpNgayDangKy.TabIndex = 11;
            // 
            // HonNhan
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(dtpNgayDangKy);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXacNhan);
            Controls.Add(txtNoiDangKy);
            Controls.Add(txtCccdNguoiVo);
            Controls.Add(txtCccdNguoiChong);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "HonNhan";
            Text = "HonNhan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox txtCccdNguoiChong;
        private TextBox textBox2;
        private TextBox txtCccdNguoiVo;
        private TextBox txtNoiDangKy;
        private Button btnXacNhan;
        private Button btnLamMoi;
        private DateTimePicker dtpNgayDangKy;
    }
}