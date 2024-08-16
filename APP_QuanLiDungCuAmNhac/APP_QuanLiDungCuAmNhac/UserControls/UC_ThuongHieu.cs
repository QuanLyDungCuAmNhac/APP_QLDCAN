using BLL;
using DTO;
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
    public partial class UC_ThuongHieu : UserControl
    {
        BLLThuongHieu ThuongHieuBLL = new BLLThuongHieu();
        public UC_ThuongHieu()
        {
            InitializeComponent();
            this.Load += UC_ThuongHieu_Load;
        }

        private void UC_ThuongHieu_Load(object sender, EventArgs e)
        {
            dgvThuongHieu.Font = new Font("Century", 15);
            dgvThuongHieu.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 17, FontStyle.Bold);
            LoadDGVTH();
            LoadCBBTH();    
        }

        public void LoadDGVTH()
        {
            dgvThuongHieu.DataSource = ThuongHieuBLL.LoadTH();
            dgvThuongHieu.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            dgvThuongHieu.Font = new Font("Arial", 12, FontStyle.Regular);
            dgvThuongHieu.Columns[0].HeaderText = "Mã thương hiệu";
            dgvThuongHieu.Columns[1].HeaderText = "Tên thương hiệu";
        }

        public void LoadCBBTH()
        {
            var LoaiList = ThuongHieuBLL.LoadTH();
            LoaiList.Insert(0, new ThuongHieu { MaTH = -1, TenTH = "Tat ca" });
            cbbTH.DataSource = LoaiList;
            cbbTH.DisplayMember = "TenTH";
            cbbTH.ValueMember = "MaTH";

        }

        private void cbbTH_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbTH.SelectedIndex != 0)
            {
                int MaTH = int.Parse(cbbTH.SelectedValue.ToString());
                dgvThuongHieu.DataSource = ThuongHieuBLL.LoadTHTheoMa(MaTH);
            }
            else
            {
                dgvThuongHieu.DataSource = ThuongHieuBLL.LoadTH();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TenTH = txtThuongHieu.Text;
            if (TenTH == "")
                LoadDGVTH();
            else
                dgvThuongHieu.DataSource = ThuongHieuBLL.LoadTHTheoTen(TenTH);
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (dgvThuongHieu.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dgvThuongHieu.SelectedRows[0];
                int math = int.Parse(selectedRow.Cells[0].Value.ToString());
                if (ThuongHieuBLL.IsTHOnSP(math))
                {
                    MessageBox.Show("Mã thương hiệu tồn tại trên sản phẩm");
                    return;
                }
                ThuongHieuBLL.XoaTH(math);
                MessageBox.Show("Xóa thành công");
                LoadDGVTH();
                LoadCBBTH();
            }
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaTH.Text))
            {
                MessageBox.Show("Không được để trống mã thương hiệu");
                return;
            }
            if (string.IsNullOrEmpty(txtTenTH.Text))
            {
                MessageBox.Show("Không được để trống tên thương hiệu");
                return;
            }
            if (!ThuongHieuBLL.IsTenTH(txtTenTH.Text))
            {
                MessageBox.Show("Tên thương hiệu đã tồn tại");
                return;
            }
            else
            {
                ThuongHieu th = new ThuongHieu();
                th.MaTH = int.Parse(txtMaTH.Text);
                th.TenTH = txtTenTH.Text;
                ThuongHieuBLL.UpdateTH(th);
                MessageBox.Show("Update thành công");
                LoadCBBTH();
                LoadDGVTH() ;
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtTenTH.Text))
            {
                MessageBox.Show("Không được để trống tên thương hiệu");
                return;
            }
            if (!ThuongHieuBLL.IsTenTH(txtTenTH.Text))
            {
                MessageBox.Show("Tên thương hiệu đã tồn tại");
                return;
            }
            else
            {
                ThuongHieu th = new ThuongHieu();
                th.TenTH = txtTenTH.Text;
                ThuongHieuBLL.InsertTH(th);
                MessageBox.Show("Thêm thành công");
                LoadDGVTH();
                LoadCBBTH();
            }
        }

        private void dgvThuongHieu_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaTH.Text = dgvThuongHieu.CurrentRow.Cells[0].Value.ToString();
            txtTenTH.Text = dgvThuongHieu.CurrentRow.Cells[1].Value.ToString();
        }

        private void txtThuongHieu_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMaTH_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtTenTH_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
