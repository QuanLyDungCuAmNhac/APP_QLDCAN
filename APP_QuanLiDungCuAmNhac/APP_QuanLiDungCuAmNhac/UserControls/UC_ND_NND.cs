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
    public partial class UC_ND_NND : UserControl
    {
        BLLND_NDD ND_NNDBLL = new BLLND_NDD();
        public UC_ND_NND()
        {
            InitializeComponent();
        }

        private void UC_ND_NND_Load(object sender, EventArgs e)
        {
            LoadND();
            LoadND_NDD();
            LoadNDD();
        }

        public void LoadND_NDD()
        {
            DGVND_NND.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVND_NND.DataSource = ND_NNDBLL.LoadND_NDD();
            if (DGVND_NND.Columns.Count > 0)
            {
                DGVND_NND.Columns[2].Visible = false;     
            }
            DGVND_NND.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVND_NND.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVND_NND.Columns[0].HeaderText = "Mã người dùng";
            DGVND_NND.Columns[1].HeaderText = "Mã nhóm";
        }

        public void LoadNDD()
        {
            var LoaiList = ND_NNDBLL.LoadNND();
            LoaiList.Insert(0, new QL_NhomNguoiDung { MaNhom = "-1", TenNhom = "" });
            CBBNND.DataSource = LoaiList;
            CBBNND.DisplayMember = "TenNhom";
            CBBNND.ValueMember = "MaNhom";

        }

        public void LoadND()
        {
            DGVND.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DGVND.DataSource = ND_NNDBLL.LoadNDHoatDong();
            // Đảm bảo rằng cột tồn tại trước khi ẩn
            if (DGVND.Columns.Count > 0)
            {
                if (DGVND.Columns.Count > 1) DGVND.Columns[1].Visible = false;
                if (DGVND.Columns.Count > 2) DGVND.Columns[2].Visible = false;
                if (DGVND.Columns.Count > 3) DGVND.Columns[3].Visible = false;
                if (DGVND.Columns.Count > 6) DGVND.Columns[6].Visible = false;      
            }

            DGVND.ColumnHeadersDefaultCellStyle.Font = new Font("Century", 14, FontStyle.Bold);
            DGVND.Font = new Font("Arial", 12, FontStyle.Regular);
            DGVND.Columns[0].HeaderText = "Mã ND";
            DGVND.Columns["Username"].HeaderText = "Tài khoản";
            DGVND.Columns["Password"].HeaderText = "Mật khẩu";
        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            try
            {            
                // Lấy giá trị MaNV từ ô đầu tiên của hàng hiện tại
                int MaNV = int.Parse(DGVND.CurrentRow.Cells["MaNV"].Value.ToString());

                // Lấy giá trị MaNhom từ ComboBox
                string MaNhom = CBBNND.SelectedValue.ToString();
                if(MaNhom == "-1")
                {
                    MessageBox.Show("Vui lòng chọn nhóm");
                    return;
                }    

                // Kiểm tra xem nhân viên đã tồn tại trong nhóm chưa
                if (ND_NNDBLL.KTKC(MaNV, MaNhom))
                {
                    MessageBox.Show("Nhân viên đã tồn tại trong nhóm.");
                }
                else
                {
                    // Thực hiện thêm nhân viên vào nhóm nếu chưa tồn tại
                    ND_NNDBLL.InserNDvaoNhom(MaNV, MaNhom);               
                    MessageBox.Show("Nhân viên đã được thêm vào nhóm.");
                    LoadND_NDD();
                }
            }
            catch (Exception ex)
            {
                // Hiển thị thông báo lỗi nếu có lỗi xảy ra
                MessageBox.Show("Đã xảy ra lỗi: " + ex.Message);
            }
        }

        private void CBBNND_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btnXoa_Click(object sender, EventArgs e)
        {
            int MaNV = int.Parse(DGVND_NND.CurrentRow.Cells[0].Value.ToString());
            string MaNhom = DGVND_NND.CurrentRow.Cells[1].Value.ToString();
            if (!ND_NNDBLL.KTKC(MaNV, MaNhom))
            {
                MessageBox.Show("Nhân viên không tồn tại trong nhóm.");
                return;
            }
            else
            {
                ND_NNDBLL.XoaNDKhoiNhom(MaNV, MaNhom);
                MessageBox.Show("Xoa thanh cong");
                LoadND_NDD();
            }
        }
    }
}
