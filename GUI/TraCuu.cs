using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;

namespace GUI
{
    public partial class TraCuu : Form
    {
        private IDriver _neo4jDriver;
        public string MaNV { get; set; }
        public TraCuu()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
        }

        private async void TraCuu_Load(object sender, EventArgs e)
        {
            await LoadAllCitizens();
        }
        public async Task LoadAllCitizens() // Đảm bảo phương thức là async và trả về Task
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (c:CongDan) RETURN c");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CCCD");
            dataTable.Columns.Add("Họ và tên");
            dataTable.Columns.Add("Giới tính");
            dataTable.Columns.Add("Ngày sinh");
            dataTable.Columns.Add("Quê quán");
            dataTable.Columns.Add("Thường trú");

            while (await result.FetchAsync())
            {
                var citizen = result.Current["c"].As<INode>();
                dataTable.Rows.Add(
                    citizen.Properties["cccd"].As<string>(),
                    citizen.Properties["hoten"].As<string>(),
                    citizen.Properties["gioitinh"].As<string>(),
                    citizen.Properties["ngaysinh"].As<DateTime>().ToString("dd/MM/yyyy"),
                    citizen.Properties["quequan"].As<string>(),
                    citizen.Properties["thuongtru"].As<string>()
                );
            }

            dataCD.DataSource = dataTable; // Cập nhật tên DataGridView ở đây
        }

        private async Task SearchCitizen(string keyword) // Đảm bảo phương thức là async và trả về Task
        {
            var query = "MATCH (c:CongDan) WHERE c.hoten CONTAINS $keyword OR c.cccd = $cccd RETURN c";
            var parameters = new { keyword = keyword, cccd = keyword };

            var result = await _neo4jDriver.AsyncSession().RunAsync(query, parameters);
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CCCD");
            dataTable.Columns.Add("Họ và tên");
            dataTable.Columns.Add("Giới tính");
            dataTable.Columns.Add("Ngày sinh");
            dataTable.Columns.Add("Quê quán");
            dataTable.Columns.Add("Thường trú");

            while (await result.FetchAsync())
            {
                var citizen = result.Current["c"].As<INode>();
                dataTable.Rows.Add(
                    citizen.Properties["cccd"].As<string>(),
                    citizen.Properties["hoten"].As<string>(),
                    citizen.Properties["gioitinh"].As<string>(),
                    citizen.Properties["ngaysinh"].As<DateTime>().ToString("dd/MM/yyyy"),
                    citizen.Properties["quequan"].As<string>(),
                    citizen.Properties["thuongtru"].As<string>()
                );
            }

            dataCD.DataSource = dataTable; // Cập nhật tên DataGridView ở đây
            dataCD.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;

            // Kiểm tra nếu không có dữ liệu
            if (dataTable.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy công dân nào với từ khóa đã nhập.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private async void btnTimkiem_Click(object sender, EventArgs e)
        {
            string keyword = txtTimKiem.Text.Trim(); // Lấy giá trị từ ô tìm kiếm

            if (!string.IsNullOrEmpty(keyword)) // Kiểm tra nếu ô tìm kiếm không rỗng
            {
                await SearchCitizen(keyword); // Gọi phương thức tìm kiếm
            }
            else
            {
                MessageBox.Show("Vui lòng nhập từ khóa tìm kiếm."); // Thông báo nếu ô tìm kiếm rỗng
            }
        }

        private void btnQuayLai_Click(object sender, EventArgs e)
        {
            FormMain formMain = new FormMain(MaNV); // Đảm bảo MaNV được truyền vào

            // Hiện form chính
            formMain.Show();

            // Đóng form TraCuu
            this.Close();
        }

        private async void LtnLammoi_Click(object sender, EventArgs e)
        {
            // Xóa nội dung của ô tìm kiếm
            txtTimKiem.Clear();

            // Tải lại dữ liệu đầy đủ vào DataGridView
            await LoadAllCitizens();

        }

        private void btnXemChiTiet_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataCD.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                var selectedRow = dataCD.SelectedRows[0];

                // Lấy dữ liệu từ hàng đã chọn
                string cccd = selectedRow.Cells["CCCD"].Value.ToString(); // Giả sử cột CCCD được đặt tên là "CCCD"
                string hoten = selectedRow.Cells["Họ và tên"].Value.ToString(); // Tên cột tương ứng
                string gioitinh = selectedRow.Cells["Giới tính"].Value.ToString(); // Tên cột tương ứng
                DateTime ngaysinh = DateTime.ParseExact(selectedRow.Cells["Ngày sinh"].Value.ToString(), "dd/MM/yyyy", null);
                string quequan = selectedRow.Cells["Quê quán"].Value.ToString(); // Tên cột tương ứng
                string thuongtru = selectedRow.Cells["Thường trú"].Value.ToString(); // Tên cột tương ứng

                // Mở form CongDan và truyền dữ liệu
                CongDan formCongDan = new CongDan
                {
                    CCCD = cccd,
                    HoTen = hoten,
                    GioiTinh = gioitinh,
                    NgaySinh = ngaysinh,
                    QueQuan = quequan,
                    ThuongTru = thuongtru
                };

                formCongDan.ShowDialog(); // Hiện form xem chi tiết
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một công dân để xem chi tiết.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private async void btnThemCongDan_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form ThemCongDan
            ThemCongDan formThemCongDan = new ThemCongDan();

            // Truyền MaNV từ FormMain sang ThemCongDan
            formThemCongDan.MaNV = this.MaNV; // Truyền MaNV hiện tại

            // Hiển thị form ThemCongDan
            formThemCongDan.Show();

            // Ẩn FormMain nếu cần thiết
            this.Hide();
        }

        private async void btnXoaCongDan_Click(object sender, EventArgs e)
        {
            // Kiểm tra xem có hàng nào được chọn không
            if (dataCD.SelectedRows.Count > 0)
            {
                // Lấy hàng đầu tiên được chọn
                var selectedRow = dataCD.SelectedRows[0];

                // Lấy CCCD của công dân đã chọn
                string cccd = selectedRow.Cells["CCCD"].Value.ToString();

                // Hiển thị hộp thoại xác nhận
                DialogResult result = MessageBox.Show($"Bạn có chắc chắn muốn xóa công dân với CCCD: {cccd}?", "Xác nhận xóa", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                // Nếu người dùng chọn Yes, thực hiện việc xóa
                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa công dân trong cơ sở dữ liệu Neo4j
                        var deleteQuery = "MATCH (c:CongDan {cccd: $cccd}) DELETE c";
                        var parameters = new { cccd = cccd };

                        using (var session = _neo4jDriver.AsyncSession())
                        {
                            await session.RunAsync(deleteQuery, parameters);
                        }

                        // Hiển thị thông báo xóa thành công
                        MessageBox.Show("Xóa công dân thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Tải lại danh sách công dân sau khi xóa
                        await LoadAllCitizens();
                    }
                    catch (Exception ex)
                    {
                        // Hiển thị thông báo lỗi nếu có vấn đề xảy ra
                        MessageBox.Show($"Có lỗi xảy ra khi xóa công dân: {ex.Message}", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                // Nếu không có hàng nào được chọn, hiển thị thông báo
                MessageBox.Show("Vui lòng chọn một công dân để xóa.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }

        }
    }
}
