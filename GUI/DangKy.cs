using GUI;
using Neo4j.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class DangKy : Form
    {
        private IDriver _neo4jDriver;
        public string MaNV { get; set; }
        public DangKy()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain(MaNV); // Đảm bảo MaNV được truyền vào

            // Hiện form chính
            formMain.Show();

            // Đóng form TraCuu
            this.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            // Tạo form con KhaiSinh
            Khaisinh formKhaiSinh = new Khaisinh();
            formKhaiSinh.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formKhaiSinh.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formKhaiSinh.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formKhaiSinh);
            formKhaiSinh.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            HonNhan formHonNhan = new HonNhan();
            formHonNhan.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formHonNhan.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formHonNhan.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formHonNhan);
            formHonNhan.Show();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            CongDanTu formKhaiTu = new CongDanTu();
            formKhaiTu.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formKhaiTu.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formKhaiTu.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formKhaiTu);
            formKhaiTu.Show();
        }

        private void button8_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            DKCongDan formDKCongDan = new DKCongDan();
            formDKCongDan.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formDKCongDan.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formDKCongDan.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formDKCongDan);
            formDKCongDan.Show();
        }

        private void button6_Click(object sender, EventArgs e)
        {   
            panel1.Controls.Clear();

            HoKhau formHoKhau = new HoKhau();
            formHoKhau.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formHoKhau.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formHoKhau.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formHoKhau);
            formHoKhau.Show();
        }

        private void button7_Click(object sender, EventArgs e)
        {
            panel1.Controls.Clear();

            TamTru formTamTru = new TamTru();
            formTamTru.TopLevel = false;  // Đặt TopLevel thành false để nhúng vào Panel
            formTamTru.FormBorderStyle = FormBorderStyle.None;  // Loại bỏ viền của form con
            formTamTru.Dock = DockStyle.Fill;  // Cho phép form con chiếm toàn bộ Panel

            // Thêm form con vào Panel và hiển thị
            panel1.Controls.Add(formTamTru);
            formTamTru.Show();
        }
    }
}
