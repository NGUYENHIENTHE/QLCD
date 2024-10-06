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
    public partial class DKCongDan : Form
    {
        private IDriver _neo4jDriver;
        public DKCongDan()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string cccd = txtCCCD.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string gioiTinh = txtGioiTinh.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string queQuan = txtQueQuan.Text.Trim();
            string thuongTru = txtThuongTru.Text.Trim();
            string tamTru = txtTamTru.Text.Trim();
            string danToc = txtDanToc.Text.Trim();
            string honNhan = txtHonNhan.Text.Trim();
            string cccdCha = txtCCCDCha.Text.Trim();
            string cccdMe = txtCCCDMe.Text.Trim();

            if (string.IsNullOrWhiteSpace(cccd) ||
                string.IsNullOrWhiteSpace(hoTen) ||
                string.IsNullOrWhiteSpace(gioiTinh) ||
                string.IsNullOrWhiteSpace(queQuan) ||
                string.IsNullOrWhiteSpace(thuongTru) ||
                string.IsNullOrWhiteSpace(tamTru) ||
                string.IsNullOrWhiteSpace(danToc) ||
                string.IsNullOrWhiteSpace(honNhan) ||
                string.IsNullOrWhiteSpace(cccdCha) ||
                string.IsNullOrWhiteSpace(cccdMe))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return; // Dừng thực hiện nếu có trường bỏ trống
            }

            string cypherQuery = "CREATE (:CongDan {cccd: $cccd, hoten: $hoTen, gioitinh: $gioiTinh, ngaysinh: $ngaySinh, " +
                                 "quequan: $queQuan, thuongtru: $thuongTru, tamtru: $tamTru, dantoc: $danToc, " +
                                 "honnhan: $honNhan, cccdCha: $cccdCha, cccdMe: $cccdMe})";

            try
            {
                using (var session = _neo4jDriver.AsyncSession())
                {
                    // Chạy truy vấn
                    await session.RunAsync(cypherQuery, new
                    {
                        cccd,
                        hoTen,
                        gioiTinh,
                        ngaySinh,
                        queQuan,
                        thuongTru,
                        tamTru,
                        danToc,
                        honNhan,
                        cccdCha,
                        cccdMe
                    });
                }

                MessageBox.Show("Đăng ký thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // Xóa các trường nhập liệu sau khi lưu thành công
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
            txtCCCD.Clear();
            txtHoTen.Clear();
            txtGioiTinh.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtQueQuan.Clear();
            txtThuongTru.Clear();
            txtTamTru.Clear();
            txtDanToc.Clear();
            txtHonNhan.Clear();
            txtCCCDCha.Clear();
            txtCCCDMe.Clear();
        }
    }
}
