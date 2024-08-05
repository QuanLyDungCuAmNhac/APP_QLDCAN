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
    public partial class UC_NND : UserControl
    {
        BLLNND NNDBLL = new BLLNND();
        public UC_NND()
        {
            InitializeComponent();
        }

        private void UC_NND_Load(object sender, EventArgs e)
        {
            LoadNND();
        }
        public void LoadNND()
        {
            DGVNND.DataSource = NNDBLL.LoadNND();
            DGVNND.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVNND.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVNND.Columns["MaNhom"].HeaderText = "Mã nhóm";
            DGVNND.Columns["TenNhom"].HeaderText = "Tên nhóm";
            DGVNND.Columns["GhiChu"].HeaderText = "Ghi chú";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhóm");
                return;
            }
            if (string.IsNullOrEmpty(txtTenNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm");
                return;
            }
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú");
                return;
            }
            QL_NhomNguoiDung nnd = new QL_NhomNguoiDung();
            nnd.MaNhom = txtMaNhom.Text;
            nnd.TenNhom = txtTenNhom.Text;
            nnd.GhiChu = txtGhiChu.Text;
            if (NNDBLL.KTKC(txtMaNhom.Text) != 0) {
                MessageBox.Show("Nhom nguoi dung đã tồn tại");
                return;
            }
            NNDBLL.InsertNhomND(nnd);
            LoadNND();
            MessageBox.Show("Thêm thành công");
        
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtMaNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhóm");
                return;
            }    
            if(NNDBLL.IsNNDonPhanQuyen(txtMaNhom.Text) != 0)
            {
                MessageBox.Show("Nhóm người dùng đã tồn tại trên bảng phân quyền");
                return;
            }
            string MaNND = txtMaNhom.Text;
            if (NNDBLL.KTKC(txtMaNhom.Text) == 0)
            {
                MessageBox.Show("Nhom nguoi dung không tồn tại");
                return;
            }
            NNDBLL.XoaNhom(MaNND);
            LoadNND();
            MessageBox.Show("Xóa thành công");
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập mã nhóm");
                return;
            }
            if (string.IsNullOrEmpty(txtTenNhom.Text))
            {
                MessageBox.Show("Vui lòng nhập tên nhóm");
                return;
            }
            if (string.IsNullOrEmpty(txtGhiChu.Text))
            {
                MessageBox.Show("Vui lòng nhập ghi chú");
                return;
            }
            QL_NhomNguoiDung nnd = new QL_NhomNguoiDung();
            nnd.MaNhom = txtMaNhom.Text;
            nnd.TenNhom = txtTenNhom.Text;
            nnd.GhiChu = txtGhiChu.Text;
            NNDBLL.UpdateNND(nnd);
            LoadNND();
            MessageBox.Show("Update thành công");
        }

        private void guna2Panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void DGVNND_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNhom.Text = DGVNND.CurrentRow.Cells[0].Value.ToString();
            txtTenNhom.Text = DGVNND.CurrentRow.Cells[1].Value.ToString();
            txtGhiChu.Text = DGVNND.CurrentRow.Cells[2].Value.ToString();
        }
    }
}
