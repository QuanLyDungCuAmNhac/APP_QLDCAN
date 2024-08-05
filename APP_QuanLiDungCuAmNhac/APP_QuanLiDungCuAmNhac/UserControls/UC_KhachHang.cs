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

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_KhachHang : UserControl
    {
        BLLKhachHang KhachHangBLL = new BLLKhachHang();
        public UC_KhachHang()
        {
            InitializeComponent();
            this.Load += UC_KhachHang_Load;
        }

        private void UC_KhachHang_Load(object sender, EventArgs e)
        {
            LoadDGVKH();

        }
        public void LoadDGVKH()
        {
            DGVKhachHang.DataSource = KhachHangBLL.LoadKH();
            DGVKhachHang.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVKhachHang.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVKhachHang.Columns[0].HeaderText = "Mã khách hàng";
            DGVKhachHang.Columns[1].HeaderText = "Tên khách hàng";
            DGVKhachHang.Columns[2].HeaderText = "Số điện thoại";
            DGVKhachHang.Columns[3].HeaderText = "Email";
            DGVKhachHang.Columns[4].HeaderText = "Tài khoản";
            DGVKhachHang.Columns[5].HeaderText = "Mật khẩu";
        }
    }
}
