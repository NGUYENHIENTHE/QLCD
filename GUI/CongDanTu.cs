using System;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;

namespace GUI
{
    public partial class CongDanTu : Form
    {
        private IDriver _neo4jDriver;

        public CongDanTu()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver(); // Kết nối tới Neo4j
        }

        private async void btnXacNhan_Click(object sender, EventArgs e)
        {
            string cccdNguoiMat = txtCCCD.Text;
            string ngayMat = dtpNgayMat.Value.ToString("yyyy-MM-dd");
            string nguyenNhan = txtNguyenNhan.Text;
            string ngayDangKy = txtNgay.Text;
            string thangDangKy = txtThang.Text;
            string namDangKy = txtNam.Text;
            string cccdCanBo = txtCCCDCanBo.Text;

            if (string.IsNullOrWhiteSpace(cccdNguoiMat) || string.IsNullOrWhiteSpace(cccdCanBo))
            {
                MessageBox.Show("Vui lòng nhập đầy đủ thông tin CCCD.");
                return;
            }

            var queryCheck = @"
                MATCH (c:CongDan {cccd: $cccdNguoiMat})
                RETURN c";

            try
            {
                var session = _neo4jDriver.AsyncSession();
                var resultCheck = await session.RunAsync(queryCheck, new
                {
                    cccdNguoiMat = cccdNguoiMat
                });

                // Sử dụng FetchAsync để lấy danh sách các bản ghi và kiểm tra dữ liệu
                var records = await resultCheck.FetchAsync();
                if (!records)
                {
                    MessageBox.Show("CCCD không tồn tại.");
                    return;
                }

                // Nếu CCCD tồn tại, lưu thông tin vào CongDanTu
                var queryCreate = @"
                    MATCH (c:CongDan {cccd: $cccdNguoiMat})
                    CREATE (c)-[:TU]->(:CongDanTu {cccd: c.cccd, ngaymat: $ngayMat, nguyennhan: $nguyenNhan, ngaydk: $ngayDangKy, thangdk: $thangDangKy, namdk: $namDangKy, cccdCanbo: $cccdCanBo})
                    RETURN 'Đăng ký khai tử thành công' AS message";

                var resultCreate = await session.RunAsync(queryCreate, new
                {
                    cccdNguoiMat = cccdNguoiMat,
                    ngayMat = ngayMat,
                    nguyenNhan = nguyenNhan,
                    ngayDangKy = ngayDangKy,
                    thangDangKy = thangDangKy,
                    namDangKy = namDangKy,
                    cccdCanBo = cccdCanBo
                });

                var createRecord = await resultCreate.SingleAsync();
                MessageBox.Show(createRecord["message"].As<string>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Làm mới các trường nhập liệu
            txtCCCD.Clear();
            txtNguyenNhan.Clear();
            txtCCCDCanBo.Clear();
            dtpNgayMat.Value = DateTime.Now;
            txtNgay.Clear();
            txtThang.Clear();
            txtNam.Clear();
        }
    }
}
