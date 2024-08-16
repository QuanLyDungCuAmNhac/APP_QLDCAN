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
    public partial class UC_NCC : UserControl
    {
        BLLNhaCungCap NCCBLL = new BLLNhaCungCap();
        public UC_NCC()
        {
            InitializeComponent();
            this.Load += UC_NCC_Load;
        }

        private void UC_NCC_Load(object sender, EventArgs e)
        {
            DGVNCC.Font = new Font("Century", 15);
            DGVNCC.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 17, FontStyle.Bold);
            LoadDGVNCC();
            LoadCBBNCC();
        }
        public void LoadDGVNCC()
        {
            DGVNCC.DataSource = NCCBLL.LoadNCC();
            DGVNCC.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVNCC.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVNCC.Columns[0].HeaderText = "Mã nhà cung cấp";
            DGVNCC.Columns[1].HeaderText = "Tên nhà cung cấp";
            DGVNCC.Columns[2].HeaderText = "Số điện thoại";        
        }

        public void LoadCBBNCC()
        {
            var LoaiList = NCCBLL.LoadNCC();
            LoaiList.Insert(0, new NhaCungCap { MaNCC = -1, TenNCC = "Tat ca" });
            cbbNCC.DataSource = LoaiList;
            cbbNCC.DisplayMember = "TenNCC";
            cbbNCC.ValueMember = "MaNCC";
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TenNCC = txtTim.Text;
            if (TenNCC == "")
                LoadDGVNCC();
            else
                DGVNCC.DataSource = NCCBLL.LoadNCCTheoTen(TenNCC);
        }

        private void cbbNCC_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbNCC.SelectedIndex != 0)
            {
                int MaNCC = int.Parse(cbbNCC.SelectedValue.ToString());
                DGVNCC.DataSource = NCCBLL.LoadNCCTheoMa(MaNCC);
            }
            else
            {
                DGVNCC.DataSource = NCCBLL.LoadNCC();
            }
        }

        private void DGVNCC_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaNCC.Text = DGVNCC.CurrentRow.Cells[0].Value.ToString();
            txtTenNCC.Text = DGVNCC.CurrentRow.Cells[1].Value.ToString();
            txtSDT.Text = DGVNCC.CurrentRow.Cells[2].Value.ToString();
        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            if (DGVNCC.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGVNCC.SelectedRows[0];
                int mancc = int.Parse(selectedRow.Cells[0].Value.ToString());
                if (NCCBLL.IsNccOnKho(mancc))
                {
                    MessageBox.Show("Ma NCC ton tai tren bang kho");
                    return;
                }
                NCCBLL.XoaNCC(mancc);
                MessageBox.Show("Xoa thanh cong");
                LoadDGVNCC();
                LoadCBBNCC();
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {         
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Không được để trống tên NCC");
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Không được để trống SDT");
                return;
            }
            NhaCungCap ncc = new NhaCungCap();         
            ncc.TenNCC = txtTenNCC.Text;
            ncc.SDT = txtSDT.Text;
            NCCBLL.InsertNCC(ncc);
            MessageBox.Show("Thêm thành công");
            LoadDGVNCC();
            LoadCBBNCC();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaNCC.Text))
            {
                MessageBox.Show("Không được để trống mã NCC");
                return;
            }
            if (string.IsNullOrEmpty(txtTenNCC.Text))
            {
                MessageBox.Show("Không được để trống tên NCC");
                return;
            }
            if (string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Không được để trống SDT");
                return;
            }

                NhaCungCap ncc = new NhaCungCap();
                ncc.MaNCC = int.Parse(txtMaNCC.Text);
                ncc.TenNCC = txtTenNCC.Text;
                ncc.SDT = txtSDT.Text;
                NCCBLL.UpdateNCC(ncc);
                MessageBox.Show("Update thành công");
                LoadDGVNCC();
                LoadCBBNCC();
            
        }
    }
}
