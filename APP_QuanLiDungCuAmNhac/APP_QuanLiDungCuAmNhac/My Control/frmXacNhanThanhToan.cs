using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using DTO;
namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmXacNhanThanhToan : Form
    {  
        BLLNhanVien bllnv = new BLLNhanVien();
        BLLHoaDon bllHoaDon = new BLLHoaDon();
        BLLSanPham bllsp = new BLLSanPham();
        BLLKhachHang KhachHangBLL = new BLLKhachHang();
        public event Action OnSaveSuccess;
        public frmXacNhanThanhToan()
        {
            InitializeComponent();
            InitializeDataGridView();
        }
        public DataGridView HoaDonDataGridView
        {
            get { return dataGridView1; }
        }
        public TextBox TongTienTextBox
        {
            get { return textBox1; }
        }
        private void frmXacNhanThanhToan_Load(object sender, EventArgs e)
        {
            comboBox1.DataSource = bllnv.LoadNV();
            comboBox1.DisplayMember = "TenNV";
            comboBox1.ValueMember = "MaNV";
            dateTimePicker1.Value = DateTime.Now;
            textBox3.Text = "Tiền Mặt";
        }
        private void InitializeDataGridView()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("TenSP", "Tên Sản Phẩm");
            dataGridView1.Columns.Add("DonGia", "Đơn Giá");
            dataGridView1.Columns.Add("SoLuong", "Số Lượng");
            dataGridView1.Columns.Add("TongTien", "Tổng Tiền");

            dataGridView1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.AllowUserToDeleteRows = false;
        }

        private void btn_ThanhToan_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrEmpty(txtTenKH.Text))
            {
                MessageBox.Show("Vui lòng nhập tên khách hàng");
                return;
            }
            if(string.IsNullOrEmpty(txtDiaChi.Text))
            {
                MessageBox.Show("Vui lòng nhập email");
                return;
            }
            if(string.IsNullOrEmpty(txtSDT.Text))
            {
                MessageBox.Show("Vui lòng nhập số điện thoại");
                return;
            }
                
            try
            {
                KhachHang kh = new KhachHang();
                kh.TenKH = txtTenKH.Text;
                kh.Email = txtDiaChi.Text;
                kh.SDT = txtSDT.Text;
                int MaKH = KhachHangBLL.InsetKH(kh);
                // Lưu hóa đơn
                HoaDon hoaDon = new HoaDon
                {
                    MaNV = (int)comboBox1.SelectedValue,
                    NgayDat = dateTimePicker1.Value,
                    HinhThucThanhToan = textBox3.Text,
                    TongTien = decimal.Parse(TongTienTextBox.Text.Replace(" đ", "").Replace(".", ""), NumberStyles.Currency, new CultureInfo("vi-VN")),
                    TinhTrang = "Mua thành công",
                    MaKH = MaKH
                };

                int maHD = bllHoaDon.SaveHoaDon(hoaDon);         
                // Lưu chi tiết hóa đơn
                foreach (DataGridViewRow row in HoaDonDataGridView.Rows)
                {
                    if (!row.IsNewRow)
                    {
                        ChiTietHoaDon chiTietHoaDon = new ChiTietHoaDon
                        {
                            MaHD = maHD,
                            MaSP = GetMaSP(row.Cells["TenSP"].Value.ToString()), // Bạn cần có phương thức để lấy MaSP từ tên sản phẩm
                            SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                            DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value),
                        };

                        if (!bllHoaDon.SaveChiTietHoaDon(chiTietHoaDon))
                        {
                            throw new Exception("Lưu chi tiết hóa đơn không thành công.");
                        }
                    }
                }

                // Hiển thị thông báo hỏi người dùng có muốn in hóa đơn không
                DialogResult result = MessageBox.Show("Bạn có muốn in hóa đơn không?", "In hóa đơn", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // Tạo danh sách HoaDonDTO từ DataGridView
                    List<HoaDonDTO> hoaDonData = new List<HoaDonDTO>();
                    foreach (DataGridViewRow row in HoaDonDataGridView.Rows)
                    {
                        if (!row.IsNewRow)
                        {
                            HoaDonDTO dto = new HoaDonDTO
                            {
                                TenSP = row.Cells["TenSP"].Value.ToString(),
                                SoLuong = Convert.ToInt32(row.Cells["SoLuong"].Value),
                                DonGia = Convert.ToDecimal(row.Cells["DonGia"].Value),
                                // Tính tổng tiền
                                TongTien = Convert.ToInt32(row.Cells["SoLuong"].Value) * Convert.ToDecimal(row.Cells["DonGia"].Value),
                            };
                            hoaDonData.Add(dto);
                        }
                    }
                    // Truyền dữ liệu vào form Report
                    Report report = new Report(hoaDonData, txtTenKH.Text, txtDiaChi.Text, txtSDT.Text);
                    report.ShowDialog();
                    MessageBox.Show("Thanh toán thành công!");
                }
                else
                {
                    // Thông báo thanh toán thành công
                    MessageBox.Show("Thanh toán thành công!");
                }
               

                OnSaveSuccess?.Invoke();
                this.Close(); // Đóng form sau khi thanh toán thành công
            }
            catch (Exception ex)
            {
                MessageBox.Show("Có lỗi xảy ra: " + ex.Message);
            }
        }
        private int GetMaSP(string tenSP)
        {
            // Implement this method to return the product ID based on the product name
            // Example implementation:
            var products = bllsp.LoadSP();
            var product = products.FirstOrDefault(p => p.TenSP == tenSP);
            return product?.MaSP ?? 0;
        }

        private void btnXuatHoaDon_Click(object sender, EventArgs e)
        {
           
        }
    }
}
