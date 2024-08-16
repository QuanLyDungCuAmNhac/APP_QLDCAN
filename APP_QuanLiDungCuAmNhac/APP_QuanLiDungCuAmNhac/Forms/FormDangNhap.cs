using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;

namespace APP_QuanLiDungCuAmNhac.Forms
{
    public partial class FormDangNhap : Form
    {
        BLLND_NDD DN_NNDBLL = new BLLND_NDD();
        BLLNhanVien NhanVienBLL = new BLLNhanVien();
        public FormDangNhap()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(this.textBox1.Text))
            {
                MessageBox.Show("Vui lòng nhập tài khoản");
                return;
            }
            if (string.IsNullOrEmpty(this.textBox2.Text))
            {
                MessageBox.Show("Vui lòng nhập mật khẩu");
                return;
            }
                
                
            if (NhanVienBLL.getTrangThai(textBox1.Text) == true && NhanVienBLL.Login(textBox1.Text,textBox2.Text) == true)
            {
               
                using (FormMain fd = new FormMain(DN_NNDBLL.GetMaNND(textBox1.Text),textBox1.Text))
                {
                    fd.ShowDialog();
                }
            }
            else
            {
                if (NhanVienBLL.getTrangThai(textBox1.Text) == false && NhanVienBLL.Login(textBox1.Text, textBox2.Text) == true)
                {
                    MessageBox.Show("Tài khoản đã bị khóa");
                    return;
                }
                MessageBox.Show("Ten dang nhap hoac mat khau khong dung");
                return;
            } 
                
                
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
