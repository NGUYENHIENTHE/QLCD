using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;

namespace GUI
{
    public partial class Khaisinh : Form
    {
        private IDriver _neo4jDriver;
        public Khaisinh()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }

        private async void button1_Click(object sender, EventArgs e)
        {
            try
            {
                // Kiểm tra xem có trường nào bị bỏ trống không
                if (string.IsNullOrWhiteSpace(txtMaSoTo.Text) ||
                    string.IsNullOrWhiteSpace(txtHovaTen.Text) ||
                    string.IsNullOrWhiteSpace(txtGioiTinh.Text) ||
                    string.IsNullOrWhiteSpace(txtDanToc.Text) ||
                    string.IsNullOrWhiteSpace(txtQuocTich.Text) ||
                    string.IsNullOrWhiteSpace(txtNoiSinh.Text) ||
                    string.IsNullOrWhiteSpace(txtHoTenCha.Text) ||
                    string.IsNullOrWhiteSpace(txtDanTocCha.Text) ||
                    string.IsNullOrWhiteSpace(txtQuocTichCha.Text) ||
                    string.IsNullOrWhiteSpace(txtHoTenMe.Text) ||
                    string.IsNullOrWhiteSpace(txtDanTocMe.Text) ||
                    string.IsNullOrWhiteSpace(txtQuocTichMe.Text) ||
                    string.IsNullOrWhiteSpace(txtNguoiDangKy.Text))
                {
                    MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Dừng thực hiện nếu có trường bỏ trống
                }

                // Lấy thông tin từ các trường nhập liệu
                int maSoTo = int.Parse(txtMaSoTo.Text.Trim());
                string hoTen = txtHovaTen.Text.Trim();
                string gioiTinh = txtGioiTinh.Text.Trim();
                string ngaySinh = dtpNgayThangNamSinh.Value.ToString("yyyy-MM-dd");
                string danToc = txtDanToc.Text.Trim();
                string quocTich = txtQuocTich.Text.Trim();
                string noiSinh = txtNoiSinh.Text.Trim();
                string hoTenCha = txtHoTenCha.Text.Trim();
                string danTocCha = txtDanTocCha.Text.Trim();
                string quocTichCha = txtQuocTichCha.Text.Trim();
                string hoTenMe = txtHoTenMe.Text.Trim();
                string danTocMe = txtDanTocMe.Text.Trim();
                string quocTichMe = txtQuocTichMe.Text.Trim();
                string nguoiDangKy = txtNguoiDangKy.Text.Trim();

                // Tạo câu lệnh Cypher để lưu dữ liệu
                var session = _neo4jDriver.AsyncSession();
                await session.RunAsync($@"
                    CREATE (k:KhaiSinh {{
                        MaSoTo: '{maSoTo}', 
                        HovaTen: '{hoTen}', 
                        GioiTinh: '{gioiTinh}',
                        NgayThangNamSinh: '{ngaySinh}', 
                        DanToc: '{danToc}', 
                        QuocTich: '{quocTich}',
                        NoiSinh: '{noiSinh}', 
                        HoTenCha: '{hoTenCha}', 
                        DanTocCha: '{danTocCha}',
                        QuocTichCha: '{quocTichCha}', 
                        HoTenMe: '{hoTenMe}', 
                        DanTocMe: '{danTocMe}',
                        QuocTichMe: '{quocTichMe}', 
                        NguoiDangKy: '{nguoiDangKy}'
                    }}) 
                    RETURN k
                ");

                MessageBox.Show("Lưu khai sinh thành công!");
                session.DisposeAsync();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtMaSoTo.Clear();
            txtHovaTen.Clear();
            txtGioiTinh.Clear();
            dtpNgayThangNamSinh.Value = DateTime.Now;
            txtDanToc.Clear();
            txtQuocTich.Clear();
            txtNoiSinh.Clear();
            txtHoTenCha.Clear();
            txtDanTocCha.Clear();
            txtQuocTichCha.Clear();
            txtHoTenMe.Clear();
            txtDanTocMe.Clear();
            txtQuocTichMe.Clear();
            txtNguoiDangKy.Clear();
        }
    }
}
