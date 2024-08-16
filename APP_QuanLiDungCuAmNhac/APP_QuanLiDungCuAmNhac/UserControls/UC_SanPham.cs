using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using CloudinaryDotNet;
using APP_QuanLiDungCuAmNhac.My_Control;
using DTO;
namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_SanPham : UserControl
    {
        private Cloudinary cloudinary;
        BLLSanPham bll_sp = new BLLSanPham();
        BLLLoai bll_loai = new BLLLoai();
        BLLThuongHieu bll_thuongHieu = new BLLThuongHieu();
        private int selectedProductId;
        public UC_SanPham()
        {
            InitializeCloudinary();
            InitializeComponent();

        }

        private void txtTenLoai_TextChanged(object sender, EventArgs e)
        {

        }
       

        private async void UC_SanPham_Load(object sender, EventArgs e)
        {
            dataGridViewSanPham.Font = new Font("Segoe GUI", 12, FontStyle.Regular);
            dataGridViewSanPham.AutoGenerateColumns = false;

            await LoadSanPhamAsync();
           
        }
        public async Task LoadSanPhamAsync()
        {
            var products = bll_sp.LoadSP(); // Kiểm tra để chắc chắn rằng phương thức này trả về dữ liệu hợp lệ
            dataGridViewSanPham.Rows.Clear();

            foreach (var product in products)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewSanPham);

                row.Cells[0].Value = product.MaSP;
                row.Cells[1].Value = product.TenSP;
                row.Cells[2].Value = product.DonGia;
                row.Cells[3].Value = product.SoLuong;
                row.Cells[4].Value = product.MoTa;
                row.Cells[5].Value = product.MaLoai;
                row.Cells[6].Value = product.MaTH;

                var imageCell = (DataGridViewImageCell)row.Cells[7];
                if (product.HinhAnh != null)
                {
                    string imageUrl = cloudinary.Api.UrlImgUp.BuildUrl(product.HinhAnh.Trim());
                    await LoadImageAsync(imageUrl, imageCell);
                }

                row.Height = 100;
                dataGridViewSanPham.Rows.Add(row);
            }
        }
        private void InitializeCloudinary()
        {
            var account = new Account(
                "deuokbfws",
                "248837377936324",
                "KVCmXwtnx9zLnRet4SzN_Lee9xY");

            cloudinary = new Cloudinary(account);
        }

        private async Task LoadImageAsync(string imageUrl, DataGridViewImageCell imageCell)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        Image img = Image.FromStream(ms);
                        Bitmap bitmap = new Bitmap(img, new Size(100, 100)); // Điều chỉnh kích thước hình ảnh lớn hơn, bạn có thể điều chỉnh giá trị này
                        imageCell.Value = bitmap;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
                imageCell.Value = null; // Đặt hình ảnh mặc định nếu cần
            }
        }


        private void btnThem_Click(object sender, EventArgs e)
        {
            frmThemSanPham form = new frmThemSanPham();

            // Hiển thị form như một hộp thoại
            form.ShowDialog();
        }

        private void btnSua_Click(object sender, EventArgs e)
        {
            if (selectedProductId > 0)
            {
                frmSuaSanPham form = new frmSuaSanPham(selectedProductId);
                form.FormClosed += Form_FormClosed;
                form.ShowDialog();
            }
            else
            {
                MessageBox.Show("Please select a product to edit.");
            }
        }

        private async void Form_FormClosed(object sender, FormClosedEventArgs e)
        {
            await LoadSanPhamAsync();
        }

        private void dataGridViewSanPham_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.RowIndex < dataGridViewSanPham.Rows.Count)
            {
                DataGridViewRow row = dataGridViewSanPham.Rows[e.RowIndex];
                selectedProductId = (int)row.Cells[0].Value; // Lấy ID sản phẩm từ cột đầu tiên
            }
        }
        private async void FrmSuaSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {

            await LoadSanPhamAsync();
        }

        private async void btnLoad_Click(object sender, EventArgs e)
        {
            await LoadSanPhamAsync();
        }

        private async void btnXoa_Click(object sender, EventArgs e)
        {
            if (dataGridViewSanPham.SelectedRows.Count > 0)
            {
                // Lấy mã sản phẩm từ hàng được chọn
                int selectedProductId = (int)dataGridViewSanPham.SelectedRows[0].Cells[0].Value;

                // Xác nhận việc xóa
                var result = MessageBox.Show("Bạn có chắc chắn muốn xóa sản phẩm này không?", "Xóa sản phẩm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        // Xóa sản phẩm khỏi cơ sở dữ liệu
                        bll_sp.DeleteSanPham(selectedProductId);

                        // Cập nhật DataGridView
                        await LoadSanPhamAsync();

                        MessageBox.Show("Sản phẩm đã được xóa thành công!");
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xóa sản phẩm: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn sản phẩm để xóa.");
            }
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void cbbThuongHieu_SelectedIndexChanged(object sender, EventArgs e)
        {
           
        }

        private async void btnTim_Click(object sender, EventArgs e)
        {
            string TenSP = txtTenLoai.Text;

            List<DTO.SanPham> products;

            if (!string.IsNullOrEmpty(TenSP))
            {
                products = bll_sp.LoadSPTheoTen(TenSP);
            }
            else
            {
                products = bll_sp.LoadSP();
            }

            dataGridViewSanPham.Rows.Clear();

            foreach (var product in products)
            {
                DataGridViewRow row = new DataGridViewRow();
                row.CreateCells(dataGridViewSanPham);

                row.Cells[0].Value = product.MaSP;
                row.Cells[1].Value = product.TenSP;
                row.Cells[2].Value = product.DonGia;
                row.Cells[3].Value = product.SoLuong;
                row.Cells[4].Value = product.MoTa;
                row.Cells[5].Value = product.MaLoai;
                row.Cells[6].Value = product.MaTH;

                var imageCell = (DataGridViewImageCell)row.Cells[7];
                if (product.HinhAnh != null)
                {
                    string imageUrl = cloudinary.Api.UrlImgUp.BuildUrl(product.HinhAnh.Trim());
                    await LoadImageAsync(imageUrl, imageCell);
                }

                row.Height = 100;
                dataGridViewSanPham.Rows.Add(row);
            }
        }

        private void btnDong_Click(object sender, EventArgs e)
        {
            
        }
    }
}
