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
using APP_QuanLiDungCuAmNhac.My_Control;
using System.IO;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Globalization;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_BanHang : UserControl
    {
        BLLSanPham bllsp = new BLLSanPham();
        BLLLoai bllloai = new BLLLoai();
        public UC_BanHang()
        {
            InitializeComponent();
            InitializeDataGridView();
            btn_TienMat.Enabled = textBox2.Enabled = textBox4.Enabled = textBox3.Enabled = false;
        }

        private void sanPhamBindingNavigatorSaveItem_Click(object sender, EventArgs e)
        {
            this.Validate();


        }
        private void InitializeDataGridView()
        {
            dataGridViewHoaDon.Columns.Clear();
            DataGridViewButtonColumn buttonColumn = new DataGridViewButtonColumn
            {
                Name = "Xoa",
                Text = "Xóa",
                UseColumnTextForButtonValue = true,
                Width = 12,
                FlatStyle = FlatStyle.Flat,
                HeaderText = "",
                FillWeight = 30

            };
            dataGridViewHoaDon.Font = new Font("Segoe GUI", 12, FontStyle.Regular);

            dataGridViewHoaDon.Columns.Add(buttonColumn);

            dataGridViewHoaDon.Columns.Add("TenSP", "Tên Sản Phẩm");
            dataGridViewHoaDon.Columns.Add("DonGia", "Đơn Giá");
            dataGridViewHoaDon.Columns.Add("SoLuong", "Số Lượng");
            dataGridViewHoaDon.Columns.Add("TongTien", "Tổng Tiền");


            dataGridViewHoaDon.Columns["TenSP"].ReadOnly = true;
            dataGridViewHoaDon.Columns["DonGia"].ReadOnly = true;
            dataGridViewHoaDon.Columns["TongTien"].ReadOnly = true;
            dataGridViewHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewHoaDon.AllowUserToAddRows = false;
            dataGridViewHoaDon.AllowUserToDeleteRows = false;
            dataGridViewHoaDon.CellContentClick += dataGridViewHoaDon_CellContentClick_1;
        }


        private void UC_BanHang_Load(object sender, EventArgs e)
        {
            LoadSanPham();
            LoadLoai();
            btn_TienMat.Enabled = dataGridViewHoaDon.Rows.Count > 0;
            comboBox1.SelectedIndexChanged += ComboBox1_SelectedIndexChanged;
            textBox2.ReadOnly = true;
            textBox4.ReadOnly = true;

        }

        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedCategoryId = (int)comboBox1.SelectedValue;
            LoadSanPham(selectedCategoryId);
        }

        public void LoadLoai()
        {
            var loaiList = bllloai.LoadLoai();
            DataTable dt = new DataTable();
            dt.Columns.Add("MaLoai", typeof(int));
            dt.Columns.Add("TenLoai", typeof(string));

            DataRow dr = dt.NewRow();
            dr["MaLoai"] = 0; // ID cho "Tất cả"
            dr["TenLoai"] = "Tất cả";
            dt.Rows.InsertAt(dr, 0);

            foreach (var loai in loaiList)
            {
                dr = dt.NewRow();
                dr["MaLoai"] = loai.MaLoai;
                dr["TenLoai"] = loai.TenLoai;
                dt.Rows.Add(dr);
            }

            comboBox1.DisplayMember = "TenLoai";
            comboBox1.ValueMember = "MaLoai";
            comboBox1.DataSource = dt;
            //comboBox1.DisplayMember = "TenLoai";
            //comboBox1.ValueMember = "MaLoai";
            //comboBox1.DataSource = bllloai.LoadLoai();

        }
        public void LoadSanPham(int categoryId = 0)
        {
            flowLayoutPanel1.Controls.Clear();
            var products = bllsp.LoadSP();
            if (categoryId != 0)
            {
                products = bllsp.LoadSPTheoLoai(categoryId);
            }
            else
            {
                products = bllsp.LoadSP();
            }
            var cloudinary = new Cloudinary(new Account(
            "deuokbfws",
            "248837377936324",
            "KVCmXwtnx9zLnRet4SzN_Lee9xY"));

            foreach (var product in products)
            {
                if (product.HinhAnh != null)
                {
                    var imageUrl = cloudinary.Api.UrlImgUp.BuildUrl(product.HinhAnh.Trim());
                    // Sử dụng `imageUrl` trong logic của bạn


                    var sanPhamControl = new My_Control.SanPham
                    {
                        TenSP = product.TenSP,
                        Price = product.DonGia.ToString(),
                        ImageUrl = imageUrl,
                    };
                    sanPhamControl.Click += (s, e) => OnProductClick(product);
                    flowLayoutPanel1.Controls.Add(sanPhamControl);
                }
            }
        }
        public void LoadSanPhamTheoTen(string TenSP)
        {
            flowLayoutPanel1.Controls.Clear();
            var products = bllsp.LoadSP();
            if (TenSP != null)
            {
                products = bllsp.LoadSPTheoTen(TenSP);
            }
            else
            {
                products = bllsp.LoadSP();
            }
            var cloudinary = new Cloudinary(new Account(
            "deuokbfws",
            "248837377936324",
            "KVCmXwtnx9zLnRet4SzN_Lee9xY"));

            foreach (var product in products)
            {
                if (product.HinhAnh != null)
                {
                    var imageUrl = cloudinary.Api.UrlImgUp.BuildUrl(product.HinhAnh.Trim());
                    // Sử dụng `imageUrl` trong logic của bạn


                    var sanPhamControl = new My_Control.SanPham
                    {
                        TenSP = product.TenSP,
                        Price = product.DonGia.ToString(),
                        ImageUrl = imageUrl,
                    };
                    sanPhamControl.Click += (s, e) => OnProductClick(product);
                    flowLayoutPanel1.Controls.Add(sanPhamControl);
                }
            }
        }
        private void UpdateTongTien()
        {
            decimal totalAmount = 0;
            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (row.Cells["TongTien"].Value != null)
                {
                    totalAmount += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }
            }
            CultureInfo vietnamCulture = new CultureInfo("vi-VN");
            textBox2.Text = totalAmount.ToString("N0", vietnamCulture) + " đ";
        }
        private void OnProductClick(DTO.SanPham product)
        {
            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (row.IsNewRow) continue;
                if (row.Cells["TenSP"].Value != null &&
                    row.Cells["TenSP"].Value.ToString() == product.TenSP)
                {
                    int currentQuantity = Convert.ToInt32(row.Cells["SoLuong"].Value);
                    currentQuantity += 1;
                    row.Cells["SoLuong"].Value = currentQuantity;
                    row.Cells["TongTien"].Value = currentQuantity * Convert.ToDouble(row.Cells["DonGia"].Value);
                    return;
                }
            }

            dataGridViewHoaDon.Rows.Add(null, product.TenSP, product.DonGia, 1, product.DonGia);
            UpdateTongTien();
            btn_TienMat.Enabled =  textBox2.Enabled = textBox4.Enabled = textBox3.Enabled = dataGridViewHoaDon.Rows.Count > 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            decimal totalAmount = 0;
            frmXacNhanThanhToan frm = new frmXacNhanThanhToan();
            frm.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            frm.StartPosition = FormStartPosition.CenterParent;
            frm.Dock = DockStyle.Fill;
            frm.OnSaveSuccess += Frm_OnSaveSuccess;
            foreach (DataGridViewRow row in dataGridViewHoaDon.Rows)
            {
                if (!row.IsNewRow)
                {
                    frm.HoaDonDataGridView.Rows.Add(row.Cells["TenSP"].Value,
                                                       row.Cells["DonGia"].Value,
                                                       row.Cells["SoLuong"].Value,
                                                       row.Cells["TongTien"].Value);
                    totalAmount += Convert.ToDecimal(row.Cells["TongTien"].Value);
                }

            }
            CultureInfo vietnamCulture = new CultureInfo("vi-VN");
            frm.TongTienTextBox.Text = totalAmount.ToString("N0", vietnamCulture) + " đ";
            frm.ShowDialog();
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }



        private void dataGridViewHoaDon_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewHoaDon.Columns["Xoa"].Index)
            {
                if (dataGridViewHoaDon.Rows.Count > e.RowIndex)
                {
                    dataGridViewHoaDon.Rows.RemoveAt(e.RowIndex);
                    UpdateTongTien();
                    btn_TienMat.Enabled = textBox2.Enabled = textBox4.Enabled = textBox3.Enabled = dataGridViewHoaDon.Rows.Count > 0;
                }
            }
        }

        private void dataGridViewHoaDon_CellPainting(object sender, DataGridViewCellPaintingEventArgs e)
        {
            if (e.RowIndex == -1)
            {

                using (SolidBrush brush = new SolidBrush(Color.SteelBlue))
                {
                    e.Graphics.FillRectangle(brush, e.CellBounds);
                }


                using (SolidBrush textBrush = new SolidBrush(Color.White))
                {
                    e.Graphics.DrawString(e.Value?.ToString() ?? "", e.CellStyle.Font, textBrush, e.CellBounds,
                        new StringFormat { Alignment = StringAlignment.Center, LineAlignment = StringAlignment.Center });
                }
                e.Handled = true;
            }
        }

        private void groupBox4_Enter(object sender, EventArgs e)
        {

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            int selectedCategoryId = (int)comboBox1.SelectedValue;
            LoadSanPham(selectedCategoryId);
        }

        private void textBox3_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void textBox4_TextChanged(object sender, EventArgs e)
        {

        }
        private bool isFormatting = false;
        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            if (isFormatting) return;

            isFormatting = true;

            try
            {
                string text = textBox3.Text.Replace(".", "");

                if (decimal.TryParse(text, out decimal tienKhachDua))
                {
                    textBox3.Text = tienKhachDua.ToString("N0", new CultureInfo("vi-VN"));
                    textBox3.SelectionStart = textBox3.Text.Length; // Đặt con trỏ chuột ở cuối TextBox
                    decimal totalAmount = decimal.Parse(textBox2.Text.Replace(" đ", "").Replace(".", ""), NumberStyles.Currency, new CultureInfo("vi-VN"));
                    decimal tienThua = tienKhachDua - totalAmount;
                    textBox4.Text = tienThua.ToString("N0", new CultureInfo("vi-VN")) + " đ";
                }
            }
            catch
            {
                textBox4.Text = "0 đ";
            }
            finally
            {
                isFormatting = false;
            }
        }
        private void Frm_OnSaveSuccess()
        {
            dataGridViewHoaDon.Rows.Clear();
            UpdateTongTien();
        }

        private void dataGridViewHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0 && e.ColumnIndex == dataGridViewHoaDon.Columns["SoLuong"].Index)
            {
                DataGridViewCell cell = dataGridViewHoaDon.Rows[e.RowIndex].Cells["SoLuong"];
                int newQuantity = Convert.ToInt32(cell.Value);
                double unitPrice = Convert.ToDouble(dataGridViewHoaDon.Rows[e.RowIndex].Cells["DonGia"].Value);
                dataGridViewHoaDon.Rows[e.RowIndex].Cells["TongTien"].Value = newQuantity * unitPrice;
                UpdateTongTien();

            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadSanPhamTheoTen(textBox1.Text);
        }
    }

}