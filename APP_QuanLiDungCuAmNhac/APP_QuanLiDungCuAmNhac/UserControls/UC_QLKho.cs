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
    public partial class UC_QLKho : UserControl
    {
        private FormMain _mainForm;
        public UC_QLKho(FormMain mainForm)
        {
            InitializeComponent();
            _mainForm = mainForm;
            btnKho.Click += BtnKho_Click;
            btnQLNCC.Click += BtnQLNCC_Click;
        }

        private void BtnQLNCC_Click(object sender, EventArgs e)
        {
            UC_NCC uc = new UC_NCC();
            _mainForm.AddControlsToPanel(uc);
        }

        private void BtnKho_Click(object sender, EventArgs e)
        {
            UC_KhoHang uc = new UC_KhoHang();
            _mainForm.AddControlsToPanel(uc);
        }

        private void btnKho_Click_1(object sender, EventArgs e)
        {

        }
    }
}
