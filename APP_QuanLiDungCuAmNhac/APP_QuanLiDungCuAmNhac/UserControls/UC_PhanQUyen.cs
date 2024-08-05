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
using APP_QuanLiDungCuAmNhac.Forms;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_PhanQUyen : UserControl
    {
        BLLPhanQuyen PhanQuyenBLL = new BLLPhanQuyen();
        BLLManHinh ManHinhBLL = new BLLManHinh();
        BLLNND NNDBLL = new BLLNND();
        public UC_PhanQUyen()
        {
            InitializeComponent();
            
        }

      

        private void DGVPQ_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        public void LoadManHinh()
        {
            var LoaiList = ManHinhBLL.LoadMH();
            LoaiList.Insert(0, new DM_ManHinh { MaManHinh = "-1", TenManHinh = "" });
            CBBManHinh.DataSource = LoaiList;
            CBBManHinh.DisplayMember = "TenManHinh";
            CBBManHinh.ValueMember = "MaManHinh";
        }
        public void LoadNND()
        {
            DGVNhom.DataSource = NNDBLL.LoadNND();
            DGVNhom.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            DGVNhom.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVNhom.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVNhom.Columns[0].HeaderText = "Mã nhóm";
            DGVNhom.Columns[1].HeaderText = "Tên nhóm";
            DGVNhom.Columns[2].HeaderText = "Ghi chú";
        }

        private void UC_PhanQUyen_Load(object sender, EventArgs e)
        {
            DGVPQ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.AllCells;
            LoadPQ();
            LoadNND();
            LoadManHinh();
        }

        public void LoadPQ()
        {
       
            DGVPQ.DataSource = PhanQuyenBLL.LoadPhanQuyen();
            DGVPQ.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVPQ.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVPQ.Columns["MaNhomNguoiDung"].HeaderText = "Mã nhóm";
            DGVPQ.Columns["MaManHinh"].HeaderText = "Mã màn hình";
            DGVPQ.Columns["TenManHinh"].HeaderText = "Tên màn hình";

            // Đặt chiều rộng của các cột để phù hợp với nội dung
            DGVPQ.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVPQ.AutoResizeColumns();
        }

        private void DGVPQ_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == DGVPQ.Columns["CoQuyen"].Index)
            {
                string MaNhom = DGVPQ.Rows[e.RowIndex].Cells["MaNhomNguoiDung"].Value.ToString();
                string MaMH = DGVPQ.Rows[e.RowIndex].Cells["MaManHinh"].Value.ToString();
                bool hoatDong = (bool)DGVPQ.Rows[e.RowIndex].Cells["CoQuyen"].Value;

                // Update the database with the new value
                PhanQuyenBLL.UpdatePhanQuyen(MaNhom, MaMH, hoatDong);

                // Find the parent form
                FormMain formMain = (FormMain)this.FindForm();
                if (formMain != null)
                {
                    // Update UI based on the new permission
                    foreach (Control control in formMain.Controls)
                    {
                        formMain.EnableButtonBasedOnTag(control, formMain.LoggedInMaNhomNguoiDung);
                    }
                }
            }
        }    

        private void EnableButtonBasedOnTag(Control control, string tag, bool enabled)
        {
            if (control is Button btn && btn.Tag != null && btn.Tag.ToString() == tag)
            {
                btn.Enabled = enabled;
            }

            // If control has child controls, iterate through them
            foreach (Control childControl in control.Controls)
            {
                EnableButtonBasedOnTag(childControl, tag, enabled); // Recursively check child controls
            }
        }

        private void DGVPQ_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void DGVPQ_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVPQ.IsCurrentCellDirty)
            {
                DGVPQ.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            string MaNhom = DGVNhom.CurrentRow.Cells[0].Value.ToString();
            string MaMH = CBBManHinh.SelectedValue.ToString();
            if (CBBManHinh.SelectedValue.ToString() == "-1")
            {
                MessageBox.Show("Vui lòng chọn màn hình");
                return;
            }
            if(PhanQuyenBLL.KTKC(MaNhom, MaMH))
            {
                MessageBox.Show("Đã tồn tại nhóm quyền này");
                return;
            }    
            QL_PhanQuyen pq = new QL_PhanQuyen();
            pq.MaNhomNguoiDung = MaNhom;
            pq.MaManHinh = MaMH;    
            pq.CoQuyen = false;
            PhanQuyenBLL.InsertPQ(pq);
            LoadPQ();
            MessageBox.Show("Thêm thành công");
        }
    }
}
