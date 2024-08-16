using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmXemChiTietHD : Form
    {
        private int maHD;
        public DataGridView DataGridViewCTHD
        {
            get { return datagridviewCTHD; }
        }
        public frmXemChiTietHD(int maHD)
        {
            InitializeComponent();
            datagridviewCTHD.AutoGenerateColumns = false;
            this.maHD = maHD;
            label3.Text = $"Mã Hóa Đơn: {maHD}";
            // Tạo cột mã chi tiết
            DataGridViewTextBoxColumn maChiTietColumn = new DataGridViewTextBoxColumn();
            maChiTietColumn.Name = "MaHD";
            maChiTietColumn.HeaderText = "Mã Chi Tiết";
            maChiTietColumn.DataPropertyName = "MaHD"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(maChiTietColumn);

            DataGridViewTextBoxColumn maSPColumn = new DataGridViewTextBoxColumn();
            maSPColumn.Name = "MaSP";
            maSPColumn.HeaderText = "Mã SP";
            maSPColumn.DataPropertyName = "MaSP"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(maSPColumn);

            // Tạo cột số lượng
            DataGridViewTextBoxColumn soLuongColumn = new DataGridViewTextBoxColumn();
            soLuongColumn.Name = "SoLuong";
            soLuongColumn.HeaderText = "Số Lượng";
            soLuongColumn.DataPropertyName = "SoLuong"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(soLuongColumn);

            DataGridViewTextBoxColumn donGiaColumn = new DataGridViewTextBoxColumn();
            donGiaColumn.Name = "DonGia";
            donGiaColumn.HeaderText = "Đơn Giá";
            donGiaColumn.DataPropertyName = "DonGia"; // Thuộc tính trong đối tượng chi tiết hóa đơn
            datagridviewCTHD.Columns.Add(donGiaColumn);

            // Tạo cột thành tiền
            DataGridViewTextBoxColumn thanhTienColumn = new DataGridViewTextBoxColumn();
            thanhTienColumn.Name = "ThanhTien";
            thanhTienColumn.HeaderText = "Thành Tiền";
            thanhTienColumn.DataPropertyName = "ThanhTien";
            datagridviewCTHD.Columns.Add(thanhTienColumn);

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void datagridviewCTHD_DataBindingComplete(object sender, DataGridViewBindingCompleteEventArgs e)
        {
            foreach (DataGridViewRow row in datagridviewCTHD.Rows)
            {
                if (row.IsNewRow) continue; // Bỏ qua hàng mới

                // Lấy giá trị của số lượng và đơn giá
                int soLuong = Convert.ToInt32(row.Cells["SoLuong"].Value ?? 0);
                decimal donGia = Convert.ToDecimal(row.Cells["DonGia"].Value ?? 0);

                // Tính thành tiền
                decimal thanhTien = soLuong * donGia;

                // Gán giá trị cho cột thành tiền
                row.Cells["ThanhTien"].Value = thanhTien;
            }
        }
    }
}
