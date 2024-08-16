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
    public partial class UC_Loai : UserControl
    {
        BLLLoai LoaiBLL = new BLLLoai();
        public UC_Loai()
        {
            InitializeComponent();
            
            this.Load += UC_Loai_Load;
        }

        private void UC_Loai_Load(object sender, EventArgs e)
        {
           
      
           
            LoadDGVLoai();
            LoadCBBLoai();
            dataGridViewHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            dataGridViewHoaDon.Font = new Font("Arial", 12, FontStyle.Regular);
            dataGridViewHoaDon.Columns[0].HeaderText = "Mã thương hiệu";
            dataGridViewHoaDon.Columns[1].HeaderText = "Tên thương hiệu";

        }

        public void LoadDGVLoai()
        {
            dataGridViewHoaDon.DataSource = LoaiBLL.LoadLoai();
        }

        public void LoadCBBLoai()
        {
            var LoaiList = LoaiBLL.LoadLoai();
            LoaiList.Insert(0, new LoaiSP { MaLoai = -1, TenLoai = "Tat ca" });
            cbbLoai.DataSource = LoaiList;
            cbbLoai.DisplayMember = "TenLoai";
            cbbLoai.ValueMember = "MaLoai";
        }

        private void cbbLoai_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cbbLoai.SelectedIndex != 0)
            {
                int MaLoai = int.Parse(cbbLoai.SelectedValue.ToString());
                dataGridViewHoaDon.DataSource = LoaiBLL.LoadLoaiTheoMa(MaLoai);
            }
            else
            {
                dataGridViewHoaDon.DataSource= LoaiBLL.LoadLoai();
            }
        }

        private void btnTim_Click(object sender, EventArgs e)
        {
            string TenLoai = txtTenLoai.Text;
            if (TenLoai == "")
                LoadDGVLoai();
            else
                dataGridViewHoaDon.DataSource = LoaiBLL.LoadLoaiTheoTen(TenLoai);
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {       
            if (dataGridViewHoaDon.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = dataGridViewHoaDon.SelectedRows[0];
                int maloai  = int.Parse(selectedRow.Cells[0].Value.ToString());
                if (LoaiBLL.IsLoaiOnSP(maloai))
                {
                    MessageBox.Show("Ma loai ton tai tren bang san pham");
                    return;
                }    
                    LoaiBLL.XoaLoai(maloai);
                MessageBox.Show("Xoa thanh cong");
                LoadDGVLoai();
                LoadCBBLoai();
            }
            
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txtMaLoai.Text))
            {
                MessageBox.Show("Không được để trống mã loại");
                return;
            }
            if (string.IsNullOrEmpty(txtTL.Text))
            {
                MessageBox.Show("Không được để trống tên loại");
                return;
            }    
            if(!LoaiBLL.IsTenLoai(txtTL.Text))
            {
                MessageBox.Show("Tên loại đã tồn tại");
                return;
            }    
            else
            {
                LoaiSP loaiSP = new LoaiSP();
                loaiSP.MaLoai = int.Parse(txtMaLoai.Text);
                loaiSP.TenLoai = txtTL.Text;
                LoaiBLL.UpdateLoai(loaiSP);
                MessageBox.Show("Update thành công");
                LoadCBBLoai() ;
                LoadDGVLoai();
            }    
        }

        private void dataGridViewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void dataGridViewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            txtMaLoai.Text = dataGridViewHoaDon.CurrentRow.Cells[0].Value.ToString();
            txtTL.Text = dataGridViewHoaDon.CurrentRow.Cells[1].Value.ToString();
        }

        private void btnThem_Click(object sender, EventArgs e)
        {      
            if (string.IsNullOrEmpty(txtTL.Text))
            {
                MessageBox.Show("Không được để trống tên loại");
                return;
            }
            if (!LoaiBLL.IsTenLoai(txtTL.Text))
            {
                MessageBox.Show("Tên loại đã tồn tại");
                return;
            }
            else
            {
                LoaiSP loai = new LoaiSP();
                loai.TenLoai = txtTL.Text;
                LoaiBLL.InsertLoai(loai);
                MessageBox.Show("Thêm thành công");
                LoadCBBLoai();
                LoadDGVLoai();
            }
        }
    }
}
