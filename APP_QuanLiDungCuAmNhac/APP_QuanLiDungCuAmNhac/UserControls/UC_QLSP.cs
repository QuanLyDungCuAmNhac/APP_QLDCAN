using APP_QuanLiDungCuAmNhac.Forms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_QLSP : UserControl
    {
        private FormMain _mainForm;

        // Cập nhật constructor để nhận tham chiếu đến FormMain
        public UC_QLSP(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
            UC_SanPham uc = new UC_SanPham();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLLSP_Click(object sender, EventArgs e)
        {
            UC_Loai uc = new UC_Loai();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLTH_Click(object sender, EventArgs e)
        {
            UC_ThuongHieu uc = new UC_ThuongHieu();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnKhuyenMai_Click(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            UC_DonHang uc = new UC_DonHang();
            _mainForm.AddControlsToPanel(uc);
        }
    }
}
