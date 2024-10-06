using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using Neo4j.Driver;

namespace GUI
{
    public partial class DoiMatKhau : Form
    {
        private TaiKhoanBLL _taiKhoanBLL;
        private string _maNV;
        public DoiMatKhau(string maNV, TaiKhoanBLL taiKhoanBLL)
        {
            InitializeComponent();
            _maNV = maNV;
            _taiKhoanBLL = taiKhoanBLL;
        }

        private async void buttonDoiMatKhau_Click(object sender, EventArgs e)
        {
            string matKhauCu = textBoxMatKhauCu.Text;
            string matKhauMoi = textBoxMatKhauMoi.Text;
            string xacNhanMatKhau = textBoxXacNhanMatKhau.Text;

            if (matKhauMoi != xacNhanMatKhau)
            {
                MessageBox.Show("Mật khẩu mới và xác nhận mật khẩu không khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            bool result = await _taiKhoanBLL.ChangePassword(_maNV, matKhauCu, matKhauMoi);
            if (result)
            {
                MessageBox.Show("Đổi mật khẩu thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close(); // Đóng form DoiMatKhau
            }
            else
            {
                MessageBox.Show("Mật khẩu cũ không đúng!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
