using System;
using System.Data;
using System.Threading.Tasks;
using System.Windows.Forms;
using DAL;
using Neo4j.Driver;
using OfficeOpenXml;


namespace GUI
{
    public partial class ThongTin : Form
    {
        private IDriver _neo4jDriver;
        public string MaNV { get; set; }
        public ThongTin()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();
            this.Load += TraCuu_Load;

        }

        private void TraCuu_Load(object? sender, EventArgs e)
        {
            LoadAllCitizens();
        }

        private async Task LoadAllCitizens() // Đảm bảo phương thức là async và trả về Task
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

            datagridviewDSCD.DataSource = dataTable; // Cập nhật tên DataGridView ở đây
        }

        private async Task LoadKhaiSinhData()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (k:KhaiSinh) RETURN k");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("MaSoTo");
            dataTable.Columns.Add("Họ và tên");
            dataTable.Columns.Add("Giới tính");
            dataTable.Columns.Add("Ngày tháng năm sinh");
            dataTable.Columns.Add("Dân tộc");
            dataTable.Columns.Add("Quốc tịch");
            dataTable.Columns.Add("Nơi sinh");
            dataTable.Columns.Add("Họ tên cha");
            dataTable.Columns.Add("Dân tộc cha");
            dataTable.Columns.Add("Quốc tịch cha");
            dataTable.Columns.Add("Họ tên mẹ");
            dataTable.Columns.Add("Dân tộc mẹ");
            dataTable.Columns.Add("Quốc tịch mẹ");
            dataTable.Columns.Add("Người đăng ký");

            while (await result.FetchAsync())
            {
                var khaiSinh = result.Current["k"].As<INode>();
                dataTable.Rows.Add(
                    khaiSinh.Properties["MaSoTo"].As<int>(),
                    khaiSinh.Properties["HovaTen"].As<string>(),
                    khaiSinh.Properties["GioiTinh"].As<string>(),
                    khaiSinh.Properties["NgayThangNamSinh"].As<DateTime>().ToString("dd/MM/yyyy"),
                    khaiSinh.Properties["DanToc"].As<string>(),
                    khaiSinh.Properties["QuocTich"].As<string>(),
                    khaiSinh.Properties["NoiSinh"].As<string>(),
                    khaiSinh.Properties["HoTenCha"].As<string>(),
                    khaiSinh.Properties["DanTocCha"].As<string>(),
                    khaiSinh.Properties["QuocTichCha"].As<string>(),
                    khaiSinh.Properties["HoTenMe"].As<string>(),
                    khaiSinh.Properties["DanTocMe"].As<string>(),
                    khaiSinh.Properties["QuocTichMe"].As<string>(),
                    khaiSinh.Properties["NguoiDangKy"].As<string>()
                );
            }

            datagridviewDSCD.DataSource = dataTable;
        }
        private async void btnLoadKhaiSinh_Click(object sender, EventArgs e)
        {
            await LoadKhaiSinhData();
        }

        private async Task LoadHoKhauData()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (h:SoHoKhau) RETURN h");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("MsHoKhau");
            dataTable.Columns.Add("MaSoTo");
            dataTable.Columns.Add("CCCD");
            dataTable.Columns.Add("Độ ưu tiên");
            dataTable.Columns.Add("Ngày");
            dataTable.Columns.Add("Tháng");
            dataTable.Columns.Add("Năm");
            dataTable.Columns.Add("CCCD Người đăng ký");
            dataTable.Columns.Add("Số đăng ký");

            while (await result.FetchAsync())
            {
                var soHoKhau = result.Current["h"].As<INode>();
                dataTable.Rows.Add(
                    soHoKhau.Properties["MsHoKhau"].As<string>(),
                    soHoKhau.Properties["MaSoTo"].As<int>(),
                    soHoKhau.Properties["cccd"].As<string>(),
                    soHoKhau.Properties["DoUuTien"].As<int>(),
                    soHoKhau.Properties["Ngay"].As<int>(),
                    soHoKhau.Properties["Thang"].As<int>(),
                    soHoKhau.Properties["Nam"].As<int>(),
                    soHoKhau.Properties["CCCDNguoiDangKy"].As<string>(),
                    soHoKhau.Properties["SoDangKy"].As<string>()
                );
            }

            datagridviewDSCD.DataSource = dataTable; // Cập nhật nguồn dữ liệu cho DataGridView
        }
        private async void btnLoadHoKhau_Click(object sender, EventArgs e)
        {
            await LoadHoKhauData();


        }

        private async Task LoadHonNhanData()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (h:HonNhan) RETURN h");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CCCD Người Chồng");
            dataTable.Columns.Add("CCCD Người Vợ");
            dataTable.Columns.Add("Ngày Đăng Ký");
            dataTable.Columns.Add("Nơi Đăng Ký");

            while (await result.FetchAsync())
            {
                var honNhan = result.Current["h"].As<INode>();
                dataTable.Rows.Add(
                    honNhan.Properties["cccdNguoiChong"].As<string>(),
                    honNhan.Properties["cccdNguoiVo"].As<string>(),
                    honNhan.Properties["NgayDangKy"].As<DateTime>().ToString("dd/MM/yyyy"),
                    honNhan.Properties["NoiDangKy"].As<string>()
                );
            }

            datagridviewDSCD.DataSource = dataTable; // Cập nhật nguồn dữ liệu cho DataGridView
        }
        private async void btnLoadHonNhan_Click(object sender, EventArgs e)
        {
            await LoadHonNhanData();
        }

        private async void btnLoadTamTru_Click(object sender, EventArgs e)
        {
            await LoadTamTruData();
        }

        private async Task LoadTamTruData()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (t:TamTru) RETURN t");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("MaSoTo");
            dataTable.Columns.Add("HoTen");
            dataTable.Columns.Add("NgaySinh");
            dataTable.Columns.Add("ThuongTru");
            dataTable.Columns.Add("TamTru");
            dataTable.Columns.Add("CMND");
            dataTable.Columns.Add("Lydo");
            dataTable.Columns.Add("TenCanBo");
            dataTable.Columns.Add("NoiDangKy");
            dataTable.Columns.Add("NgayDangKy");
            dataTable.Columns.Add("NgayKetThuc");

            while (await result.FetchAsync())
            {
                var tamTru = result.Current["t"].As<INode>();
                dataTable.Rows.Add(
                    tamTru.Properties["MaSoTo"].As<string>(),
                    tamTru.Properties["HoTen"].As<string>(),
                    tamTru.Properties["NgaySinh"].As<string>(),
                    tamTru.Properties["ThuongTru"].As<string>(),
                    tamTru.Properties["TamTru"].As<string>(),
                    tamTru.Properties["CMND"].As<string>(),
                    tamTru.Properties["Lydo"].As<string>(),
                    tamTru.Properties["TenCanBo"].As<string>(),
                    tamTru.Properties["NoiDangKy"].As<string>(),
                    tamTru.Properties["NgayDangKy"].As<string>(),
                    tamTru.Properties["NgayKetThuc"].As<string>()
                );
            }

            datagridviewDSCD.DataSource = dataTable; // Cập nhật nguồn dữ liệu cho DataGridView
        }

        private async Task LoadBaoTuData()
        {
            var result = await _neo4jDriver.AsyncSession().RunAsync("MATCH (t:CongDanTu) RETURN t");
            DataTable dataTable = new DataTable();

            dataTable.Columns.Add("CCCD");
            dataTable.Columns.Add("Ngày Mất");
            dataTable.Columns.Add("Nguyên Nhân");
            dataTable.Columns.Add("Ngày Đăng Ký");
            dataTable.Columns.Add("Tháng Đăng Ký");
            dataTable.Columns.Add("Năm Đăng Ký");
            dataTable.Columns.Add("CCCD Cán Bộ");

            while (await result.FetchAsync())
            {
                var tamTru = result.Current["t"].As<INode>();
                dataTable.Rows.Add(
                    tamTru.Properties["cccd"].As<string>(),
                    tamTru.Properties["ngaymat"].As<DateTime>().ToString("dd/MM/yyyy"),
                    tamTru.Properties["nguyennhan"].As<string>(),
                    tamTru.Properties["ngaydk"].As<int>(),
                    tamTru.Properties["thangdk"].As<int>(),
                    tamTru.Properties["namdk"].As<int>(),
                    tamTru.Properties["cccdCanbo"].As<string>()
                );
            }

            datagridviewDSCD.DataSource = dataTable; // Cập nhật nguồn dữ liệu cho DataGridView
        }

        private async void btnLoadBaoTu_Click(object sender, EventArgs e)
        {
            await LoadBaoTuData();
        }
        private async Task LoadCongDanData()
        {
            try
            {
                using (var session = _neo4jDriver.AsyncSession())
                {
                    // Truy vấn tất cả các nút CongDan
                    var result = await session.RunAsync("MATCH (c:CongDan) RETURN c");
                    DataTable dataTable = new DataTable();

                    // Định nghĩa các cột cho DataTable
                    dataTable.Columns.Add("CCCD");
                    dataTable.Columns.Add("Họ và tên");
                    dataTable.Columns.Add("Ngày sinh");
                    dataTable.Columns.Add("Giới tính");
                    dataTable.Columns.Add("Quê quán");
                    dataTable.Columns.Add("Thường trú");
                    dataTable.Columns.Add("Tạm trú");
                    dataTable.Columns.Add("Dân tộc");
                    dataTable.Columns.Add("Hôn nhân");
                    dataTable.Columns.Add("CCCD Cha");
                    dataTable.Columns.Add("CCCD Mẹ");

                    // Duyệt qua mỗi kết quả và thêm vào DataTable
                    while (await result.FetchAsync())
                    {
                        var congDan = result.Current["c"].As<INode>();

                        // Lấy các thuộc tính
                        var cccd = congDan.Properties.ContainsKey("cccd") ? congDan.Properties["cccd"].As<string>() : "Không xác định";
                        var hoTen = congDan.Properties.ContainsKey("hoten") ? congDan.Properties["hoten"].As<string>() : "Không xác định";
                        var ngaySinh = congDan.Properties.ContainsKey("ngaysinh") ? congDan.Properties["ngaysinh"].As<string>() : "Không xác định";
                        var gioiTinh = congDan.Properties.ContainsKey("gioitinh") ? congDan.Properties["gioitinh"].As<string>() : "Không xác định";
                        var queQuan = congDan.Properties.ContainsKey("quequan") ? congDan.Properties["quequan"].As<string>() : "Không xác định";
                        var thuongTru = congDan.Properties.ContainsKey("thuongtru") ? congDan.Properties["thuongtru"].As<string>() : "Không xác định";
                        var tamTru = congDan.Properties.ContainsKey("tamtru") ? congDan.Properties["tamtru"].As<string>() : "Không xác định";
                        var danToc = congDan.Properties.ContainsKey("dantoc") ? congDan.Properties["dantoc"].As<string>() : "Không xác định";
                        var honNhan = congDan.Properties.ContainsKey("honnhan") ? congDan.Properties["honnhan"].As<string>() : "Không xác định";
                        var cccdCha = congDan.Properties.ContainsKey("cccdCha") ? congDan.Properties["cccdCha"].As<string>() : "Không xác định";
                        var cccdMe = congDan.Properties.ContainsKey("cccdMe") ? congDan.Properties["cccdMe"].As<string>() : "Không xác định";

                        // Thêm dữ liệu vào DataTable
                        dataTable.Rows.Add(cccd, hoTen, ngaySinh, gioiTinh, queQuan, thuongTru, tamTru, danToc, honNhan, cccdCha, cccdMe);
                    }

                    // Cập nhật nguồn dữ liệu cho DataGridView
                    datagridviewDSCD.DataSource = dataTable;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while loading citizen data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }



        private async void btnLoadCongDan_Click(object sender, EventArgs e)
        {
            await LoadCongDanData();

        }

        private void button1_Click(object sender, EventArgs e)
        {

            FormMain formMain = new FormMain(MaNV); // Đảm bảo MaNV được truyền vào

            // Hiện form chính
            formMain.Show();

            // Đóng form TraCuu
            this.Close();
        }

        private void btnXuatExcel_Click(object sender, EventArgs e)
        {
                ExcelPackage.LicenseContext = LicenseContext.NonCommercial; // Nếu bạn sử dụng cho mục đích không thương mại

            using (SaveFileDialog saveFileDialog = new SaveFileDialog())
            {
                saveFileDialog.FileName = "ExportedData.xlsx"; // Tên file mặc định
                saveFileDialog.Filter = "Excel Files|*.xlsx"; // Bộ lọc cho file Excel
                saveFileDialog.Title = "Lưu file Excel";

                // Hiển thị dialog và kiểm tra xem người dùng đã nhấn "OK" chưa
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Tạo một Excel package mới
                    using (var package = new ExcelPackage())
                    {
                        // Tạo một worksheet mới
                        var worksheet = package.Workbook.Worksheets.Add("Dữ liệu");

                        // Xuất tiêu đề từ DataGridView
                        for (int col = 0; col < datagridviewDSCD.Columns.Count; col++)
                        {
                            worksheet.Cells[1, col + 1].Value = datagridviewDSCD.Columns[col].HeaderText;
                        }

                        // Xuất dữ liệu từ DataGridView
                        for (int row = 0; row < datagridviewDSCD.Rows.Count; row++)
                        {
                            for (int col = 0; col < datagridviewDSCD.Columns.Count; col++)
                            {
                                worksheet.Cells[row + 2, col + 1].Value = datagridviewDSCD.Rows[row].Cells[col].Value?.ToString();
                            }
                        }

                        // Lưu package vào đường dẫn đã chỉ định
                        System.IO.FileInfo fi = new System.IO.FileInfo(saveFileDialog.FileName);
                        package.SaveAs(fi);

                        MessageBox.Show("Dữ liệu đã được xuất thành công!", "Xuất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }
    }
  }
