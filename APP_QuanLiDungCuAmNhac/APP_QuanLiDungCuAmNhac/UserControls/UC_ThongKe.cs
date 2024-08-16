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
    public partial class UC_ThongKe : UserControl
    {
        private FormMain _mainForm;
        public UC_ThongKe(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
        }

        private void btnQLTH_Click(object sender, EventArgs e)
        {
            ThongKeDoanhThu uc = new ThongKeDoanhThu();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnQLLSP_Click(object sender, EventArgs e)
        {
            ThongKeSanPhamBanRa uc = new ThongKeSanPhamBanRa();
            _mainForm.AddControlsToPanel(uc);
        }
    }
}
