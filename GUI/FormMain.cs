using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;
using LiveChartsCore;
using LiveChartsCore.SkiaSharpView.WinForms;
using LiveChartsCore.SkiaSharpView;
using LiveChartsCore.Kernel.Sketches;
using BLL;

namespace GUI
{
    public partial class FormMain : Form
    {
        private IDriver _neo4jDriver;
        public string MaNV { get; set; }  // Thuộc tính để lưu Mã NV
        private PieChart _genderChart;
        private PieChart _ageChart;  // Thay đổi ở đây

        public FormMain(string maNV)
        {
            InitializeComponent();
            MaNV = maNV;
            _neo4jDriver = Neo4jConnectionManager.GetDriver();

            // Tạo biểu đồ
            _genderChart = new PieChart();
            _ageChart = new PieChart();

            // Thiết lập thuộc tính cho các biểu đồ
            _genderChart.Dock = DockStyle.Fill; // Để chiếm hết không gian trong ô
            _ageChart.Dock = DockStyle.Fill; // Để chiếm hết không gian trong ô

            // Tạo TableLayoutPanel
            TableLayoutPanel tableLayoutPanel = new TableLayoutPanel();
            tableLayoutPanel.Dock = DockStyle.Fill; // Để chiếm hết không gian trong panel1
            tableLayoutPanel.ColumnCount = 2; // Số cột
            tableLayoutPanel.RowCount = 1; // Số hàng
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 66F)); // Cột 1 chiếm 66%
            tableLayoutPanel.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 34F)); // Cột 2 chiếm 34%

            // Thêm biểu đồ vào TableLayoutPanel
            tableLayoutPanel.Controls.Add(_ageChart, 0, 0); // Biểu đồ độ tuổi nằm ở ô (0,0)
            tableLayoutPanel.Controls.Add(_genderChart, 1, 0); // Biểu đồ giới tính nằm ở ô (1,0)

            // Thêm TableLayoutPanel vào panel1
            panel1.Controls.Add(tableLayoutPanel);
        }

        private async void FormMain_Load(object sender, EventArgs e)
        {
            lb_MaNV.Text = $"Nhân viên: {MaNV}";
            await LoadSoDan();
            await LoadGenderChart();
            await LoadAgeChart();

        }

        private async Task LoadSoDan()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (c:CongDan) RETURN count(c) as SoDan");
            var record = await result.SingleAsync();
            int soDan = record["SoDan"].As<int>();
            lb_sodan.Text = $"Số dân: {soDan}";
        }
        public async void LoadData()
        {
            try
            {
                await LoadSoDan();
                await LoadGenderChart();
                await LoadAgeChart();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Lỗi khi tải lại dữ liệu: " + ex.Message);
            }
        }


        private async Task LoadGenderChart()
        {
            // Lấy số lượng công dân theo giới tính
            var result = await _neo4jDriver.AsyncSession().RunAsync(
                "MATCH (c:CongDan) " +
                "WITH c.gioitinh AS GioiTinh, count(c) AS SoLuong " +
                "RETURN GioiTinh, SoLuong"
            );

            var genderSeries = new List<PieSeries<double>>();

            foreach (var record in await result.ToListAsync())
            {
                string gender = record["GioiTinh"].As<string>();
                int count = record["SoLuong"].As<int>();

                // Tạo một PieSeries cho từng giới tính
                var pieSeries = new PieSeries<double>
                {
                    Values = new List<double> { count },
                    Name = gender
                };

                genderSeries.Add(pieSeries);
            }

            // Đảm bảo rằng bạn đang sử dụng đúng loại biểu đồ
            // Giả sử _genderChart là biểu đồ tròn
            _genderChart.Series = genderSeries;  // Không cần chuyển đổi loại
        }

        private async Task LoadAgeChart()
        {
            var ageGroups = new Dictionary<string, int>
            {
                { "Dưới 18", 0 },
                { "18-60", 0 },
                { "Trên 60", 0 }
            };

            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (c:CongDan) RETURN c.ngaysinh AS NgaySinh");
            foreach (var record in await result.ToListAsync())
            {
                var birthDate = record["NgaySinh"].As<DateTime>();
                int age = DateTime.Now.Year - birthDate.Year;

                if (age < 18)
                    ageGroups["Dưới 18"]++;
                else if (age <= 60)
                    ageGroups["18-60"]++;
                else
                    ageGroups["Trên 60"]++;
            }

            // Sử dụng PieSeries cho biểu đồ độ tuổi
            var ageSeries = new List<PieSeries<double>>();

            foreach (var group in ageGroups)
            {
                var pieSeries = new PieSeries<double>
                {
                    Values = new List<double> { group.Value },
                    Name = group.Key
                };

                ageSeries.Add(pieSeries);
            }

            // Cập nhật biểu đồ độ tuổi với series mới
            _ageChart.Series = ageSeries;  // Sử dụng đúng loại biểu đồ
        }

        private void label1_Click(object sender, EventArgs e)
        {
        }

        private void btnOpenTraCuu_Click(object sender, EventArgs e)
        {

            // Tạo một thể hiện mới của Form TraCuu và truyền MaNV
            TraCuu formTraCuu = new TraCuu
            {
                MaNV = this.MaNV // Chuyển Mã NV từ FormMain sang TraCuu
            };

            // Mở form bằng Show() để mở như một cửa sổ không chặn
            formTraCuu.Show();

            // Đóng form chính (FormMain)
            this.Hide();

        }


        private void button2_Click(object sender, EventArgs e)
        {
            // Tạo một thể hiện mới của form ThongTin và truyền MaNV
            ThongTin formThongTin = new ThongTin
            {
                MaNV = this.MaNV // Chuyển Mã NV từ FormMain sang ThongTin
            };

            // Mở form ThongTin bằng Show()
            formThongTin.Show();

            // Ẩn FormMain
            this.Hide();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DangKy formDangKy = new DangKy
            {
                MaNV = this.MaNV // Chuyển Mã NV từ FormMain sang DangKy
            };

            // Mở form ThongTin bằng Show()
            formDangKy.Show();

            // Ẩn FormMain
            this.Hide();
        }

        private async void button5_Click(object sender, EventArgs e)
        {
            TaiKhoanBLL taiKhoanBLL = new TaiKhoanBLL(_neo4jDriver); // Đảm bảo _neo4jDriver đã được khởi tạo

            // Lấy thông tin tài khoản
            TaiKhoan taiKhoan = await taiKhoanBLL.GetTaiKhoanInfo(this.MaNV);

            if (taiKhoan != null)
            {
                GDTaiKhoan formGD = new GDTaiKhoan(taiKhoan, taiKhoanBLL, this); // Truyền tham chiếu đến FormMain
                formGD.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Không thể tìm thấy thông tin tài khoản!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }
    }
}
