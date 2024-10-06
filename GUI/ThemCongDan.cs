using System;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;


namespace GUI
{
    public partial class ThemCongDan : Form
    {
        private IDriver _neo4jDriver;
        public string MaNV { get; set; }

        public ThemCongDan()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();

        }

        private async void btnThem_Click(object sender, EventArgs e)
        {

            // Lấy thông tin từ các điều khiển
            string cccd = txtCCCD.Text.Trim();
            string hoten = txtHoTen.Text.Trim();
            string gioitinh = comboGioiTinh.SelectedItem?.ToString(); // Lấy giá trị từ ComboBox
            DateTime ngaysinh = dtpNgaySinh.Value;
            string quequan = txtQueQuan.Text.Trim();
            string thuongtru = txtThuongTru.Text.Trim();

            // Kiểm tra các trường đã nhập đầy đủ chưa
            if (string.IsNullOrEmpty(cccd))
            {
                MessageBox.Show("Vui lòng nhập CCCD.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(hoten))
            {
                MessageBox.Show("Vui lòng nhập họ tên.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(gioitinh))
            {
                MessageBox.Show("Vui lòng chọn giới tính.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ngaysinh == null)
            {
                MessageBox.Show("Vui lòng chọn ngày sinh.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(quequan))
            {
                MessageBox.Show("Vui lòng nhập quê quán.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrEmpty(thuongtru))
            {
                MessageBox.Show("Vui lòng nhập thường trú.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Kiểm tra nếu CCCD đã tồn tại
            var checkQuery = "MATCH (c:CongDan) WHERE c.cccd = $cccd RETURN c";
            var checkParameters = new { cccd = cccd };

            using (var session = _neo4jDriver.AsyncSession())
            {
                var result = await session.RunAsync(checkQuery, checkParameters);

                if (await result.FetchAsync())
                {
                    // Nếu CCCD đã tồn tại
                    MessageBox.Show("CCCD đã tồn tại. Vui lòng kiểm tra lại.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return; // Không thực hiện thêm công dân
                }

                // Thêm công dân vào cơ sở dữ liệu
                var query = "CREATE (c:CongDan {cccd: $cccd, hoten: $hoten, gioitinh: $gioitinh, ngaysinh: $ngaysinh, quequan: $quequan, thuongtru: $thuongtru})";
                var parameters = new
                {
                    cccd = cccd,
                    hoten = hoten,
                    gioitinh = gioitinh,
                    ngaysinh = ngaysinh,
                    quequan = quequan,
                    thuongtru = thuongtru
                };

                await session.RunAsync(query, parameters);
            }

            // Hiển thị thông báo thành công
            MessageBox.Show("Đã thêm công dân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Nếu bạn muốn xóa dữ liệu sau khi thêm thành công
            button2_Click(sender, e); // Gọi phương thức để làm trống các trường
        }

        private void button2_Click(object sender, EventArgs e)
        {
            // Làm trống các trường nhập liệu
            txtCCCD.Text = string.Empty;         // Làm trống TextBox CCCD
            txtHoTen.Text = string.Empty;        // Làm trống TextBox Họ tên
            comboGioiTinh.SelectedIndex = -1;    // Đặt ComboBox Giới tính về trạng thái không chọn
            dtpNgaySinh.Value = DateTime.Now;    // Đặt DatePicker Ngày sinh về ngày hiện tại
            txtQueQuan.Text = string.Empty;      // Làm trống TextBox Quê quán
            txtThuongTru.Text = string.Empty;    // Làm trống TextBox Thường trú

        }

        private void btn_back_Click(object sender, EventArgs e)
        {
            // Khi quay lại FormMain, bạn có thể truyền lại MaNV
            FormMain formMain = new FormMain(this.MaNV); // Truyền lại MaNV
            formMain.Show();

            // Đóng form hiện tại
            this.Close();
        }
    }
}
