namespace GUI
{
    partial class CongDanTu
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
            label8 = new Label();
            txtCCCD = new TextBox();
            txtNguyenNhan = new TextBox();
            txtCCCDCanBo = new TextBox();
            btnXacNhan = new Button();
            btnLamMoi = new Button();
            dtpNgayMat = new DateTimePicker();
            txtNgay = new TextBox();
            txtThang = new TextBox();
            txtNam = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(329, 47);
            label1.Name = "label1";
            label1.Size = new Size(106, 25);
            label1.TabIndex = 0;
            label1.Text = "Giấy Báo Tử";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(72, 104);
            label2.Name = "label2";
            label2.Size = new Size(67, 25);
            label2.TabIndex = 1;
            label2.Text = "CCCD :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(40, 194);
            label3.Name = "label3";
            label3.Size = new Size(99, 25);
            label3.TabIndex = 2;
            label3.Text = "Ngày Mất :";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(72, 275);
            label4.Name = "label4";
            label4.Size = new Size(130, 25);
            label4.TabIndex = 3;
            label4.Text = "Nguyên Nhân :";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(410, 104);
            label5.Name = "label5";
            label5.Size = new Size(91, 25);
            label5.TabIndex = 4;
            label5.Text = "Ngày ĐK :";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(410, 159);
            label6.Name = "label6";
            label6.Size = new Size(98, 25);
            label6.TabIndex = 5;
            label6.Text = "Tháng ĐK :";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(410, 214);
            label7.Name = "label7";
            label7.Size = new Size(87, 25);
            label7.TabIndex = 6;
            label7.Text = "Năm ĐK :";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(410, 282);
            label8.Name = "label8";
            label8.Size = new Size(128, 25);
            label8.TabIndex = 7;
            label8.Text = "CCCD Cán Bộ :";
            // 
            // txtCCCD
            // 
            txtCCCD.Location = new Point(156, 107);
            txtCCCD.Name = "txtCCCD";
            txtCCCD.Size = new Size(150, 31);
            txtCCCD.TabIndex = 8;
            // 
            // txtNguyenNhan
            // 
            txtNguyenNhan.Location = new Point(208, 276);
            txtNguyenNhan.Name = "txtNguyenNhan";
            txtNguyenNhan.Size = new Size(150, 31);
            txtNguyenNhan.TabIndex = 10;
            // 
            // txtCCCDCanBo
            // 
            txtCCCDCanBo.Location = new Point(544, 276);
            txtCCCDCanBo.Name = "txtCCCDCanBo";
            txtCCCDCanBo.Size = new Size(150, 31);
            txtCCCDCanBo.TabIndex = 14;
            // 
            // btnXacNhan
            // 
            btnXacNhan.Location = new Point(194, 351);
            btnXacNhan.Name = "btnXacNhan";
            btnXacNhan.Size = new Size(112, 34);
            btnXacNhan.TabIndex = 15;
            btnXacNhan.Text = "Xác Nhận";
            btnXacNhan.UseVisualStyleBackColor = true;
            btnXacNhan.Click += btnXacNhan_Click;
            // 
            // btnLamMoi
            // 
            btnLamMoi.Location = new Point(364, 351);
            btnLamMoi.Name = "btnLamMoi";
            btnLamMoi.Size = new Size(112, 34);
            btnLamMoi.TabIndex = 16;
            btnLamMoi.Text = "Làm Mới";
            btnLamMoi.UseVisualStyleBackColor = true;
            btnLamMoi.Click += btnLamMoi_Click;
            // 
            // dtpNgayMat
            // 
            dtpNgayMat.Location = new Point(145, 194);
            dtpNgayMat.Name = "dtpNgayMat";
            dtpNgayMat.Size = new Size(231, 31);
            dtpNgayMat.TabIndex = 17;
            // 
            // txtNgay
            // 
            txtNgay.Location = new Point(516, 105);
            txtNgay.Name = "txtNgay";
            txtNgay.Size = new Size(80, 31);
            txtNgay.TabIndex = 18;
            // 
            // txtThang
            // 
            txtThang.Location = new Point(516, 160);
            txtThang.Name = "txtThang";
            txtThang.Size = new Size(80, 31);
            txtThang.TabIndex = 19;
            // 
            // txtNam
            // 
            txtNam.Location = new Point(513, 214);
            txtNam.Name = "txtNam";
            txtNam.Size = new Size(83, 31);
            txtNam.TabIndex = 20;
            // 
            // CongDanTu
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(txtNam);
            Controls.Add(txtThang);
            Controls.Add(txtNgay);
            Controls.Add(dtpNgayMat);
            Controls.Add(btnLamMoi);
            Controls.Add(btnXacNhan);
            Controls.Add(txtCCCDCanBo);
            Controls.Add(txtNguyenNhan);
            Controls.Add(txtCCCD);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "CongDanTu";
            Text = "CongDanTu";
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
        private Label label8;
        private TextBox txtCCCD;
        private TextBox txtNguyenNhan;
        private TextBox txtCCCDCanBo;
        private Button btnXacNhan;
        private Button btnLamMoi;
        private DateTimePicker dtpNgayMat;
        private TextBox txtNgay;
        private TextBox txtThang;
        private TextBox txtNam;
    }
}