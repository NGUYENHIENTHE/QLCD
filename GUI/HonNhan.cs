using System;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver; // Thêm thư viện Neo4j driver

namespace GUI
{
    public partial class HonNhan : Form
    {
        private IDriver _neo4jDriver;

        public HonNhan()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
        }

        private async void btnLuu_Click(object sender, EventArgs e)
        {
            string cccdChong = txtCccdNguoiChong.Text;
            string cccdVo = txtCccdNguoiVo.Text;
            string ngayDangKy = dtpNgayDangKy.Value.ToString("yyyy-MM-dd");
            string noiDangKy = txtNoiDangKy.Text;

            if (string.IsNullOrWhiteSpace(cccdChong) || string.IsNullOrWhiteSpace(cccdVo))
            {
                MessageBox.Show("Vui lòng nhập đủ thông tin CCCD của người chồng và người vợ.");
                return;
            }

            // Kiểm tra CCCD của người chồng
            var queryCheckChong = @"
        MATCH (c1:CongDan {cccd: $cccdChong})
        RETURN c1";

            // Kiểm tra CCCD của người vợ
            var queryCheckVo = @"
        MATCH (c2:CongDan {cccd: $cccdVo})
        RETURN c2";

            try
            {
                var session = _neo4jDriver.AsyncSession();

                // Kiểm tra CCCD người chồng
                var resultCheckChong = await session.RunAsync(queryCheckChong, new { cccdChong = cccdChong });
                var recordsChong = await resultCheckChong.ToListAsync();

                if (recordsChong.Count == 0)
                {
                    MessageBox.Show("CCCD người chồng không tồn tại.");
                    return;
                }

                // Kiểm tra CCCD người vợ
                var resultCheckVo = await session.RunAsync(queryCheckVo, new { cccdVo = cccdVo });
                var recordsVo = await resultCheckVo.ToListAsync();

                if (recordsVo.Count == 0)
                {
                    MessageBox.Show("CCCD người vợ không tồn tại.");
                    return;
                }

                // Nếu cả hai tồn tại, thực hiện tạo quan hệ hôn nhân
                var queryCreate = @"
            MATCH (c1:CongDan {cccd: $cccdChong}), (c2:CongDan {cccd: $cccdVo})
            CREATE (c1)-[:KET_HON]->(:HonNhan {cccdNguoiChong: $cccdChong, cccdNguoiVo: $cccdVo, NgayDangKy: $ngayDangKy, NoiDangKy: $noiDangKy})
            RETURN 'Đăng ký hôn nhân thành công' AS message";

                var resultCreate = await session.RunAsync(queryCreate, new
                {
                    cccdChong = cccdChong,
                    cccdVo = cccdVo,
                    ngayDangKy = ngayDangKy,
                    noiDangKy = noiDangKy
                });

                var recordCreate = await resultCreate.SingleAsync();
                MessageBox.Show(recordCreate["message"].As<string>());
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Đã xảy ra lỗi: {ex.Message}");
            }
        }

        private void btnLamMoi_Click(object sender, EventArgs e)
        {
            // Làm mới các trường nhập liệu
            txtCccdNguoiChong.Clear();
            txtCccdNguoiVo.Clear();
            dtpNgayDangKy.Value = DateTime.Now;
            txtNoiDangKy.Clear();
        }
    }
}
