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
    public partial class UC_QLDN : UserControl
    {
        private FormMain _mainForm;
        public UC_QLDN(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            UC_NhanVien uc = new UC_NhanVien();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLND_Click(object sender, EventArgs e)
        {
            UC_NND uc = new UC_NND();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLND_NND_Click(object sender, EventArgs e)
        {
            UC_ND_NND uc = new UC_ND_NND();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLPQ_Click(object sender, EventArgs e)
        {
            UC_PhanQUyen uc = new UC_PhanQUyen();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnDMMH_Click(object sender, EventArgs e)
        {
            UC_ManHinh uc = new UC_ManHinh();
            _mainForm.AddControlsToPanel(uc);
        }

        private void UC_QLDN_Load(object sender, EventArgs e)
        {

        }

        private void btnQLNV_Click(object sender, EventArgs e)
        {
            UC_NhanVien uc = new UC_NhanVien();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLNND_Click(object sender, EventArgs e)
        {
            UC_NND uc = new UC_NND();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLKH_Click(object sender, EventArgs e)
        {
            UC_KhachHang uc = new UC_KhachHang();
            _mainForm.AddControlsToPanel(uc);
        }
    }
}
