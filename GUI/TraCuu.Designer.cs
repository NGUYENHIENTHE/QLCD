namespace GUI
{
    partial class TraCuu
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
            txtTimKiem = new TextBox();
            btnTimkiem = new Button();
            label1 = new Label();
            label2 = new Label();
            dataCD = new DataGridView();
            btnQuayLai = new Button();
            LtnLammoi = new Button();
            btnXemChiTiet = new Button();
            btnThemCongDan = new Button();
            btnXoaCongDan = new Button();
            ((System.ComponentModel.ISupportInitialize)dataCD).BeginInit();
            SuspendLayout();
            // 
            // txtTimKiem
            // 
            txtTimKiem.BorderStyle = BorderStyle.FixedSingle;
            txtTimKiem.Location = new Point(237, 65);
            txtTimKiem.Name = "txtTimKiem";
            txtTimKiem.Size = new Size(355, 27);
            txtTimKiem.TabIndex = 1;
            // 
            // btnTimkiem
            // 
            btnTimkiem.Location = new Point(610, 61);
            btnTimkiem.Name = "btnTimkiem";
            btnTimkiem.Size = new Size(137, 33);
            btnTimkiem.TabIndex = 2;
            btnTimkiem.Text = "Tìm kiếm";
            btnTimkiem.UseVisualStyleBackColor = true;
            btnTimkiem.Click += btnTimkiem_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(384, 13);
            label1.Name = "label1";
            label1.Size = new Size(289, 28);
            label1.TabIndex = 3;
            label1.Text = "Tìm kiếm trong Cơ sở dữ liệu";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 7.8F, FontStyle.Italic, GraphicsUnit.Point, 0);
            label2.Location = new Point(239, 97);
            label2.Name = "label2";
            label2.Size = new Size(128, 17);
            label2.TabIndex = 4;
            label2.Text = "Nhập tên hoặc CCCD";
            // 
            // dataCD
            // 
            dataCD.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataCD.Location = new Point(12, 153);
            dataCD.Name = "dataCD";
            dataCD.RowHeadersWidth = 51;
            dataCD.Size = new Size(839, 391);
            dataCD.TabIndex = 5;
            // 
            // btnQuayLai
            // 
            btnQuayLai.Location = new Point(889, 12);
            btnQuayLai.Name = "btnQuayLai";
            btnQuayLai.Size = new Size(110, 36);
            btnQuayLai.TabIndex = 6;
            btnQuayLai.Text = "Quay lại";
            btnQuayLai.UseVisualStyleBackColor = true;
            btnQuayLai.Click += btnQuayLai_Click;
            // 
            // LtnLammoi
            // 
            LtnLammoi.Location = new Point(872, 325);
            LtnLammoi.Name = "LtnLammoi";
            LtnLammoi.Size = new Size(102, 58);
            LtnLammoi.TabIndex = 7;
            LtnLammoi.Text = "Làm mới";
            LtnLammoi.UseVisualStyleBackColor = true;
            LtnLammoi.Click += LtnLammoi_Click;
            // 
            // btnXemChiTiet
            // 
            btnXemChiTiet.Location = new Point(872, 153);
            btnXemChiTiet.Name = "btnXemChiTiet";
            btnXemChiTiet.Size = new Size(102, 56);
            btnXemChiTiet.TabIndex = 9;
            btnXemChiTiet.Text = "Xem thông tin";
            btnXemChiTiet.UseVisualStyleBackColor = true;
            btnXemChiTiet.Click += btnXemChiTiet_Click;
            // 
            // btnThemCongDan
            // 
            btnThemCongDan.Location = new Point(872, 215);
            btnThemCongDan.Name = "btnThemCongDan";
            btnThemCongDan.Size = new Size(102, 49);
            btnThemCongDan.TabIndex = 10;
            btnThemCongDan.Text = "Thêm";
            btnThemCongDan.UseVisualStyleBackColor = true;
            btnThemCongDan.Click += btnThemCongDan_Click;
            // 
            // btnXoaCongDan
            // 
            btnXoaCongDan.Location = new Point(872, 270);
            btnXoaCongDan.Name = "btnXoaCongDan";
            btnXoaCongDan.Size = new Size(102, 49);
            btnXoaCongDan.TabIndex = 11;
            btnXoaCongDan.Text = "Xóa";
            btnXoaCongDan.UseVisualStyleBackColor = true;
            btnXoaCongDan.Click += btnXoaCongDan_Click;
            // 
            // TraCuu
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg3;
            ClientSize = new Size(1011, 582);
            Controls.Add(btnXoaCongDan);
            Controls.Add(btnThemCongDan);
            Controls.Add(btnXemChiTiet);
            Controls.Add(LtnLammoi);
            Controls.Add(btnQuayLai);
            Controls.Add(dataCD);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(btnTimkiem);
            Controls.Add(txtTimKiem);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Name = "TraCuu";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tra cứu";
            Load += TraCuu_Load;
            ((System.ComponentModel.ISupportInitialize)dataCD).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private TextBox txtTimKiem;
        private Button btnTimkiem;
        private Label label1;
        private Label label2;
        private DataGridView dataCD;
        private Button btnQuayLai;
        private Button LtnLammoi;
        private Button btnXemChiTiet;
        private Button btnThemCongDan;
        private Button btnXoaCongDan;
    }
}