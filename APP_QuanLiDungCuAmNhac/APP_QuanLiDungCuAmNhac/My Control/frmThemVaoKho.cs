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

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmThemVaoKho : Form
    {
        BLLSanPham SanPhamBLL = new BLLSanPham();
        BLLKho KhoBLL = new BLLKho();
        public frmThemVaoKho()
        {
            InitializeComponent();
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void frmThemVaoKho_Load(object sender, EventArgs e)
        {
            LoadSP();
            LoadCBBNCC();
            // Đặt thuộc tính ReadOnly cho các cột không cho phép nhập
            DGVSanPhamNhap.Columns["MaSP"].ReadOnly = true;
            DGVSanPhamNhap.Columns["TenSP"].ReadOnly = true;
            DGVSanPhamNhap.Columns["MaLoai"].ReadOnly = true;          
          
        }
        public void LoadSP()
        {
            DGVSanPham.DataSource = SanPhamBLL.LoadSP();
            // Kiểm tra và ẩn các cột 6, 7, 8, 9 nếu chúng tồn tại
            if (DGVSanPham.Columns.Count > 4)
                DGVSanPham.Columns[4].Visible = false;
            if (DGVSanPham.Columns.Count > 5)
                DGVSanPham.Columns[5].Visible = false;
            if (DGVSanPham.Columns.Count > 6)
                DGVSanPham.Columns[6].Visible = false;
            if (DGVSanPham.Columns.Count > 7)
                DGVSanPham.Columns[7].Visible = false;
            if (DGVSanPham.Columns.Count > 8)
                DGVSanPham.Columns[8].Visible = false;
            if (DGVSanPham.Columns.Count > 9)
                DGVSanPham.Columns[9].Visible = false;
            DGVSanPham.Columns["MaSP"].HeaderText = "Mã sản phẩm";
            DGVSanPham.Columns["TenSP"].HeaderText = "Tên sản phẩm";
            DGVSanPham.Columns["MaLoai"].HeaderText = "Mã loại";
            //DGVSanPham.Columns["DonGia"].HeaderText = "Đơn giá";
            //DGVSanPham.Columns["SoLuong"].HeaderText = "Số lượng";

        }
        public void LoadCBBNCC()
        {
            var SPList = KhoBLL.LoadNCC();
            SPList.Insert(0, new NhaCungCap { MaNCC = -1, TenNCC = "" });
            CBBNCC.DataSource = SPList;
            CBBNCC.DisplayMember = "TenNCC";
            CBBNCC.ValueMember = "MaNCC";
        }


        private void DGVSanPham_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (DGVSanPham.IsCurrentCellDirty)
            {
                DGVSanPham.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }

        private void DGVSanPham_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            // Kiểm tra cột và dòng hợp lệ
            if (e.ColumnIndex == 0 && e.RowIndex >= 0) // Nếu là cột checkbox
            {
                // Lấy dòng hiện tại
                DataGridViewRow row = DGVSanPham.Rows[e.RowIndex];
                bool isChecked = Convert.ToBoolean(row.Cells[e.ColumnIndex].Value);

                // Kiểm tra xem dòng có phải là dòng mới không
                if (isChecked && !row.IsNewRow)
                {
                    // Tạo một danh sách các mã sản phẩm đã sao chép để tránh sao chép trùng lặp
                    HashSet<object> existingProductCodes = new HashSet<object>();
                    foreach (DataGridViewRow r in DGVSanPhamNhap.Rows)
                    {
                        if (r.Cells.Count > 0)
                        {
                            existingProductCodes.Add(r.Cells["MaSP"].Value);
                        }
                    }

                    // Nếu mã sản phẩm chưa được sao chép thì thêm vào DGVSanPhamNhap
                    if (!existingProductCodes.Contains(row.Cells["MaSP"].Value))
                    {
                        DGVSanPhamNhap.Rows.Add(
                            row.Cells["MaSP"].Value,
                            row.Cells["TenSP"].Value,
                            row.Cells["MaLoai"].Value                        
                        );
                    }
                }
                else if (!isChecked)
                {
                    // Nếu checkbox bị bỏ tích, xóa dòng tương ứng khỏi DGVSanPhamNhap
                    foreach (DataGridViewRow r in DGVSanPhamNhap.Rows)
                    {
                        if (r.Cells.Count > 0 && row.Cells["MaSP"].Value.Equals(r.Cells["MaSP"].Value))
                        {
                            DGVSanPhamNhap.Rows.Remove(r);
                            break;
                        }
                    }
                }
            }

        }

        private void btnThem_Click(object sender, EventArgs e)
        {
            if(int.Parse(CBBNCC.SelectedValue.ToString()) == -1)
            {
                MessageBox.Show("Vui lòng chọn nhà cung cấp");
                return;
            }    
            // Biến đánh dấu trạng thái kiểm tra
            bool hasEmptyFields = false;

            // Duyệt qua từng dòng trong DGVSanPhamNhap
            foreach (DataGridViewRow row in DGVSanPhamNhap.Rows)
            {
                // Bỏ qua dòng mới
                if (row.IsNewRow)
                    continue;

                // Kiểm tra cột SoLuongNhap và DonGiaNhap
                var soLuongNhap = row.Cells["SoLuongNhap"].Value;
                var donGiaNhap = row.Cells["DonGiaNhap"].Value;

                if (soLuongNhap == null || string.IsNullOrWhiteSpace(soLuongNhap.ToString()) ||
                    donGiaNhap == null || string.IsNullOrWhiteSpace(donGiaNhap.ToString()))
                {
                    hasEmptyFields = true;
                    break;
                }
            }

            // Hiển thị thông báo nếu có cột nào đó bị rỗng
            if (hasEmptyFields)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin vào các cột 'Số lượng nhập' và 'Đơn giá nhập'.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
               
                foreach (DataGridViewRow row in DGVSanPhamNhap.Rows)
                {
                    // Bỏ qua dòng mới
                    if (row.IsNewRow)
                        continue;
                    KhoHang kh = new KhoHang();
                    kh.MaNCC = int.Parse(CBBNCC.SelectedValue.ToString());
                    kh.MaSP = int.Parse(row.Cells["MaSP"].Value.ToString());
                    kh.SoLuongNhap = int.Parse(row.Cells["SoLuongNhap"].Value.ToString());
                    kh.NgayNhap = DateTime.Now.Date;
                    kh.GiaNhap = float.Parse(row.Cells["DonGiaNhap"].Value.ToString());
                    KhoBLL.InsertKho(kh);
                }
                // Thực hiện hành động thêm nếu không có ô nào rỗng
                // Ví dụ: Lưu dữ liệu vào cơ sở dữ liệu hoặc xử lý tiếp theo
                MessageBox.Show("Dữ liệu đã được thêm thành công!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
