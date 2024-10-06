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
    public partial class TamTru : Form
    {
        private IDriver _neo4jDriver;
        public TamTru()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            // Lấy thông tin từ các trường nhập liệu
            string maSoTo = txtMaSoTo.Text.Trim();
            string hoTen = txtHoTen.Text.Trim();
            string ngaySinh = dtpNgaySinh.Value.ToString("yyyy-MM-dd");
            string thuongTru = txtThuongTru.Text.Trim();
            string tamTru = txtTamtru.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string lyDo = txtLyDo.Text.Trim();
            string tenCanBo = txtTenCanBo.Text.Trim();
            string noiDangKy = txtNoiDangKy.Text.Trim();
            string ngayDangKy = dtpNgayDangKy.Value.ToString("yyyy-MM-dd");
            string ngayKetThuc = dtpNgayKetThuc.Value.ToString("yyyy-MM-dd");

            // Kiểm tra xem có trường nào bị bỏ trống không
            if (string.IsNullOrEmpty(maSoTo) || string.IsNullOrEmpty(hoTen) ||
                string.IsNullOrEmpty(thuongTru) || string.IsNullOrEmpty(tamTru) ||
                string.IsNullOrEmpty(cccd) || string.IsNullOrEmpty(lyDo) ||
                string.IsNullOrEmpty(tenCanBo) || string.IsNullOrEmpty(noiDangKy))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Kiểm tra cccd phải tồn tại trong CongDan
            string checkCypherQuery = "MATCH (c:CongDan {cccd: $cccd}) RETURN c LIMIT 1";

            try
            {
                using (var session = _neo4jDriver.AsyncSession())
                {
                    var result = await session.RunAsync(checkCypherQuery, new { cccd });

                    if (await result.FetchAsync() == false)
                    {
                        MessageBox.Show("Không tìm thấy công dân với CCCD này!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }

                    // Nếu tồn tại thì tạo node TamTru
                    string createCypherQuery = @"
                    CREATE (:TamTru {
                        MaSoTo: $maSoTo, 
                        HoTen: $hoTen, 
                        NgaySinh: $ngaySinh, 
                        ThuongTru: $thuongTru, 
                        TamTru: $tamTru, 
                        CMND: $cccd, 
                        Lydo: $lyDo, 
                        TenCanBo: $tenCanBo, 
                        NoiDangKy: $noiDangKy, 
                        NgayDangKy: $ngayDangKy, 
                        NgayKetThuc: $ngayKetThuc
                    })";

                    await session.RunAsync(createCypherQuery, new
                    {
                        maSoTo,
                        hoTen,
                        ngaySinh,
                        thuongTru,
                        tamTru,
                        cccd,
                        lyDo,
                        tenCanBo,
                        noiDangKy,
                        ngayDangKy,
                        ngayKetThuc
                    });
                }

                MessageBox.Show("Lưu thông tin tạm trú thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // Xóa các trường nhập liệu sau khi lưu thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtMaSoTo.Clear();
            txtHoTen.Clear();
            dtpNgaySinh.Value = DateTime.Now;
            txtThuongTru.Clear();
            txtTamtru.Clear();
            txtCCCD.Clear();
            txtLyDo.Clear();
            txtTenCanBo.Clear();
            txtNoiDangKy.Clear();
            dtpNgayDangKy.Value = DateTime.Now;
            dtpNgayKetThuc.Value = DateTime.Now;
        }
    }
}
