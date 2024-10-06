namespace GUI
{
    partial class FormMain
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
            btnOpenTraCuu = new Button();
            button2 = new Button();
            button3 = new Button();
            nutdangky = new Button();
            button5 = new Button();
            label1 = new Label();
            lb_MaNV = new Label();
            panel1 = new Panel();
            label4 = new Label();
            label3 = new Label();
            label2 = new Label();
            lb_sodan = new Label();
            button6 = new Button();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // btnOpenTraCuu
            // 
            btnOpenTraCuu.Location = new Point(18, 184);
            btnOpenTraCuu.Margin = new Padding(4);
            btnOpenTraCuu.Name = "btnOpenTraCuu";
            btnOpenTraCuu.Size = new Size(275, 70);
            btnOpenTraCuu.TabIndex = 0;
            btnOpenTraCuu.Text = "Tra Cứu";
            btnOpenTraCuu.UseVisualStyleBackColor = true;
            btnOpenTraCuu.Click += btnOpenTraCuu_Click;
            // 
            // button2
            // 
            button2.Location = new Point(18, 279);
            button2.Margin = new Padding(4);
            button2.Name = "button2";
            button2.Size = new Size(275, 70);
            button2.TabIndex = 1;
            button2.Text = "Thông Tin";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // button3
            // 
            button3.Location = new Point(18, 371);
            button3.Margin = new Padding(4);
            button3.Name = "button3";
            button3.Size = new Size(275, 70);
            button3.TabIndex = 2;
            button3.Text = "Biểu Đồ";
            button3.UseVisualStyleBackColor = true;
            // 
            // nutdangky
            // 
            nutdangky.Location = new Point(15, 470);
            nutdangky.Margin = new Padding(4);
            nutdangky.Name = "nutdangky";
            nutdangky.Size = new Size(275, 70);
            nutdangky.TabIndex = 3;
            nutdangky.Text = "Đăng kí";
            nutdangky.UseVisualStyleBackColor = true;
            nutdangky.Click += button4_Click;
            // 
            // button5
            // 
            button5.Location = new Point(15, 564);
            button5.Margin = new Padding(4);
            button5.Name = "button5";
            button5.Size = new Size(275, 70);
            button5.TabIndex = 4;
            button5.Text = "Tài khoản";
            button5.UseVisualStyleBackColor = true;
            button5.Click += button5_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.ForeColor = Color.IndianRed;
            label1.Location = new Point(1096, 31);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(111, 30);
            label1.TabIndex = 5;
            label1.Text = "Xin chào :";
            label1.Click += label1_Click;
            // 
            // lb_MaNV
            // 
            lb_MaNV.AutoSize = true;
            lb_MaNV.Location = new Point(1225, 34);
            lb_MaNV.Margin = new Padding(4, 0, 4, 0);
            lb_MaNV.Name = "lb_MaNV";
            lb_MaNV.Size = new Size(59, 25);
            lb_MaNV.TabIndex = 6;
            lb_MaNV.Text = "label2";
            // 
            // panel1
            // 
            panel1.BorderStyle = BorderStyle.FixedSingle;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label3);
            panel1.Location = new Point(324, 184);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1118, 571);
            panel1.TabIndex = 7;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label4.ForeColor = Color.RoyalBlue;
            label4.Location = new Point(771, 0);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(211, 25);
            label4.TabIndex = 1;
            label4.Text = "Thống kê theo giới tính";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 9F, FontStyle.Bold | FontStyle.Italic, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.RoyalBlue;
            label3.Location = new Point(226, 0);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(197, 25);
            label3.TabIndex = 0;
            label3.Text = "Thống kê theo độ tuổi";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(379, 68);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(73, 32);
            label2.TabIndex = 8;
            label2.Text = "Tổng";
            // 
            // lb_sodan
            // 
            lb_sodan.AutoSize = true;
            lb_sodan.Font = new Font("Segoe UI", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lb_sodan.Location = new Point(461, 68);
            lb_sodan.Margin = new Padding(4, 0, 4, 0);
            lb_sodan.Name = "lb_sodan";
            lb_sodan.Size = new Size(83, 32);
            lb_sodan.TabIndex = 9;
            lb_sodan.Text = "label3";
            // 
            // button6
            // 
            button6.Location = new Point(15, 672);
            button6.Margin = new Padding(4);
            button6.Name = "button6";
            button6.Size = new Size(275, 68);
            button6.TabIndex = 10;
            button6.Text = "Thoát";
            button6.UseVisualStyleBackColor = true;
            // 
            // FormMain
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.bg2;
            ClientSize = new Size(1458, 782);
            Controls.Add(button6);
            Controls.Add(lb_sodan);
            Controls.Add(label2);
            Controls.Add(panel1);
            Controls.Add(lb_MaNV);
            Controls.Add(label1);
            Controls.Add(button5);
            Controls.Add(nutdangky);
            Controls.Add(button3);
            Controls.Add(button2);
            Controls.Add(btnOpenTraCuu);
            Margin = new Padding(4);
            Name = "FormMain";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Trang chủ";
            Load += FormMain_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button btnOpenTraCuu;
        private Button button2;
        private Button button3;
        private Button nutdangky;
        private Button button5;
        private Label label1;
        private Label lb_MaNV;
        private Panel panel1;

        private Label label2;
        private Label lb_sodan;
        private Button button6;
        private Label label4;
        private Label label3;
    }
}