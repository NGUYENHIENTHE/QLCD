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
    public partial class HoKhau : Form
    {
        private IDriver _neo4jDriver;
        public HoKhau()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
        }

        private void HoKhau_Load(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private async void txtXacNhan_Click(object sender, EventArgs e)
        {
            string msHoKhau = txtMsHoKhau.Text.Trim();
            string maSoTo = txtMaSoTo.Text.Trim();
            string cccd = txtCCCD.Text.Trim();
            string doUuTien = txtDoUuTien.Text.Trim();
            string ngay = txtNgay.Text.Trim();
            string thang = txtThang.Text.Trim();
            string nam = txtNam.Text.Trim();
            string cccdNguoiDangKy = txtCCCDNguoiDangKy.Text.Trim();
            string soDangKy = txtSoDangKy.Text.Trim();

            if (string.IsNullOrEmpty(msHoKhau) || string.IsNullOrEmpty(cccd) ||
                string.IsNullOrEmpty(doUuTien) || string.IsNullOrEmpty(ngay) ||
                string.IsNullOrEmpty(thang) || string.IsNullOrEmpty(nam) ||
                string.IsNullOrEmpty(cccdNguoiDangKy) || string.IsNullOrEmpty(soDangKy))
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

                    // Nếu tồn tại thì tạo node SoHoKhau
                    string createCypherQuery = @"
                    CREATE (:SoHoKhau {
                        MsHoKhau: $msHoKhau, 
                        cccd: $cccd, 
                        DoUuTien: $doUuTien, 
                        Ngay: $ngay, 
                        Thang: $thang, 
                        Nam: $nam, 
                        CCCDNguoiDangKy: $cccdNguoiDangKy, 
                        SoDangKy: $soDangKy
                    })";

                    await session.RunAsync(createCypherQuery, new
                    {
                        msHoKhau,
                        cccd,
                        doUuTien,
                        ngay,
                        thang,
                        nam,
                        cccdNguoiDangKy,
                        soDangKy
                    });
                }

                MessageBox.Show("Lưu hộ khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ClearFields(); // Xóa các trường nhập liệu sau khi lưu thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void txtLamMoi_Click(object sender, EventArgs e)
        {
            ClearFields();
        }
        private void ClearFields()
        {
            txtMsHoKhau.Clear();
            txtMaSoTo.Clear();
            txtCCCD.Clear();
            txtDoUuTien.Clear();
            txtNgay.Clear();
            txtThang.Clear();
            txtNam.Clear();
            txtCCCDNguoiDangKy.Clear();
            txtSoDangKy.Clear();
        }
    }
}
