using System;
using System.Windows.Forms;
using BLL;
using DAL;
using Neo4j.Driver; // Ensure this is included for IDriver

namespace GUI
{
    public partial class DangNhap : Form
    {
        private TaiKhoanBLL _taiKhoanBLL; // Declare the variable
        private IDriver _neo4jDriver; // Declare the Neo4j driver variable

        public DangNhap()
        {
            InitializeComponent();
            _neo4jDriver = Neo4jConnectionManager.GetDriver();  // Lấy driver từ lớp quản lý kết nối
            _taiKhoanBLL = new TaiKhoanBLL(_neo4jDriver);
            btnDangNhap.Click += new EventHandler(btnDangNhap_Click);
        }

        private async void btnDangNhap_Click(object? sender, EventArgs e)
        {

            // Disable the button to prevent multiple clicks
            btnDangNhap.Enabled = false;

            string maNV = txtMaNV.Text.Trim();
            string matKhau = txtMatKhau.Text.Trim();

            // Kiểm tra xem người dùng có nhập thông tin không
            if (string.IsNullOrEmpty(maNV) || string.IsNullOrEmpty(matKhau))
            {
                MessageBox.Show("Vui lòng nhập mã nhân viên và mật khẩu!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                btnDangNhap.Enabled = true; // Re-enable the button
                return; // Dừng lại nếu không có thông tin
            }

            // Tiến hành kiểm tra thông tin đăng nhập
            bool isValidUser = await _taiKhoanBLL.Login(maNV, matKhau);

            if (isValidUser)
            {
                MessageBox.Show("Đăng nhập thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Mở form chính, ensure only one instance
                if (Application.OpenForms["FormMain"] == null)
                {
                    this.Hide();
                    FormMain mainForm = new FormMain(maNV); // Truyền mã NV vào constructor
                    mainForm.Show();
                }
            }
            else
            {
                MessageBox.Show("Tài khoản hoặc mật khẩu không đúng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Re-enable the button after processing
            btnDangNhap.Enabled = true;
        }

        private void txtMaNV_TextChanged(object sender, EventArgs e)
        {

        }

        private void DangNhap_Load(object sender, EventArgs e)
        {

            pictureBox1.BackColor = Color.Transparent;
            pictureBox2.BackColor = Color.Transparent;

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
           

        }
    }
}

