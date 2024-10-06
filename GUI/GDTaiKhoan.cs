using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GUI
{
    public partial class GDTaiKhoan : Form
    {
        private FormMain _formMain;
        private TaiKhoan _taiKhoan;
        private TaiKhoanBLL _taiKhoanBLL;
        public GDTaiKhoan(TaiKhoan taiKhoan, TaiKhoanBLL taiKhoanBLL, FormMain formMain)
        {
            InitializeComponent();
            _taiKhoan = taiKhoan;
            _taiKhoanBLL = taiKhoanBLL;
            _formMain = formMain;

            textBox1.Text = taiKhoan.MaNV;
            textBox2.Text = taiKhoan.HoTen;
            textBox3.Text = taiKhoan.ChiNhanh;
            textBox4.Text = taiKhoan.SoDT;
            textBox5.Text = taiKhoan.LoaiTK;
        }

        public string MaNV { get; set; }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            DoiMatKhau formDoiMatKhau = new DoiMatKhau(_taiKhoan.MaNV, _taiKhoanBLL);
            formDoiMatKhau.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            _formMain.Show();
        }
    }
}
