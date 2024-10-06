using DAL;
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
    public partial class CongDan : Form
    {
        public string MaNV { get; set; } // Biến lưu mã nhân viên

        public string CCCD { get; set; }
        public string HoTen { get; set; }
        public string GioiTinh { get; set; }
        public DateTime NgaySinh { get; set; }
        public string QueQuan { get; set; }
        public string ThuongTru { get; set; }

        public CongDan()
        {
            InitializeComponent();
            KhoaTextbox();
        }
        private void KhoaTextbox()
        {
            txtCCCD.Enabled = false;
            txtTen.Enabled = false;
            txtGioiTinh.Enabled = false;
            txtQueQuan.Enabled = false;
            txtThuongTru.Enabled = false;
        }
        private void MoTextbox()
        {
            txtCCCD.Enabled = true;
            txtTen.Enabled = true;
            txtGioiTinh.Enabled = true;
            txtQueQuan.Enabled = true;
            txtThuongTru.Enabled = true;
        }
        private void CongDan_Load(object sender, EventArgs e)
        {
            // Hiển thị dữ liệu vào các điều khiển
            txtCCCD.Text = CCCD;
            txtTen.Text = HoTen;
            txtGioiTinh.Text = GioiTinh;
            if (NgaySinh < DateNgaySinh.MinDate || NgaySinh > DateNgaySinh.MaxDate)
            {
                DateNgaySinh.Value = DateTime.Today; // Gán giá trị mặc định
            }
            else
            {
                DateNgaySinh.Value = NgaySinh; // Gán giá trị hợp lệ
            }
            txtQueQuan.Text = QueQuan;
            txtThuongTru.Text = ThuongTru;
        }

        private void btnSuaChiTietCongDan_Click(object sender, EventArgs e)
        {
            MoTextbox();


        }

        private async void btnCapNhatChiTietCongDan_Click(object sender, EventArgs e)
        {
            //var dal = new CongDanDAL();

            //// Lấy thông tin từ các textbox
            //string cccd = txtCCCD.Text;
            //string hoTen = txtTen.Text;
            //string gioiTinh = txtGioiTinh.Text;
            //DateTime ngaySinh = DateNgaySinh.Value;
            //string queQuan = txtQueQuan.Text;
            //string thuongTru = txtThuongTru.Text;

            //// Gọi phương thức cập nhật công dân
            //await dal.CapNhatCongDan(cccd, hoTen, gioiTinh, ngaySinh, queQuan, thuongTru);

            //MessageBox.Show("Công dân đã được cập nhật thành công!");

            //// Khóa lại các textbox sau khi cập nhật
            //KhoaTextbox();



            var dal = new CongDanDAL();

            // Lấy thông tin từ các textbox
            string cccd = txtCCCD.Text;
            string hoTen = txtTen.Text;
            string gioiTinh = txtGioiTinh.Text;
            DateTime ngaySinh = DateNgaySinh.Value;
            string queQuan = txtQueQuan.Text;
            string thuongTru = txtThuongTru.Text;

            // Gọi phương thức cập nhật công dân
            await dal.CapNhatCongDan(cccd, hoTen, gioiTinh, ngaySinh, queQuan, thuongTru);

            MessageBox.Show("Công dân đã được cập nhật thành công!");

            // Tìm instance của FormTraCuu
            var formTraCuu = Application.OpenForms.OfType<TraCuu>().FirstOrDefault();
            if (formTraCuu != null)
            {
                // Gọi phương thức LoadAllCitizens để làm mới dữ liệu
                await formTraCuu.LoadAllCitizens();
            }

            // Khóa lại các textbox sau khi cập nhật
            KhoaTextbox();
        }


        private void btnXoaChiTietCongDan_Click(object sender, EventArgs e)
        {

            var confirmResult = MessageBox.Show("Bạn có chắc chắn muốn xóa thông tin công dân này?",
                                                "Xác nhận xóa",
                                                MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                // Thực hiện xóa công dân
                var dal = new CongDanDAL();
                dal.XoaCongDan(txtCCCD.Text);

                MessageBox.Show("Công dân đã được xóa thành công!");

                // Xóa dữ liệu trên giao diện sau khi xóa thành công
                txtCCCD.Clear();
                txtTen.Clear();
                txtGioiTinh.Clear();
                txtQueQuan.Clear();
                txtThuongTru.Clear();
                DateNgaySinh.Value = DateTime.Now;
            }

        }
       
        private void btnVeTrangChu_Click(object sender, EventArgs e)
        {

            // Tạo instance của FormMain và truyền vào thông tin nếu cần
            FormMain formMain = new FormMain(MaNV); // Nếu MaNV không cần truyền, có thể bỏ qua tham số

            // Hiển thị form chính (FormMain)
            formMain.Show();

            // Đóng form hiện tại (Form CongDan)
            this.Close();
        }
    }
}
