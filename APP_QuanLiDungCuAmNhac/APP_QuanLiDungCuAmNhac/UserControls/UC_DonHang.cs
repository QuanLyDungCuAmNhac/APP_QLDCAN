using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BLL;
using APP_QuanLiDungCuAmNhac.My_Control;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class UC_DonHang : UserControl
    {
        BLLHoaDon bllhd = new BLLHoaDon();

        public UC_DonHang()
        {
            InitializeComponent();
        }

        private void datagridviewHoaDon_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Xử lý khi nhấp vào ô của DataGridView
        }

        private void UC_DonHang_Load(object sender, EventArgs e)
        {
            datagridviewHoaDon.ColumnHeadersDefaultCellStyle.Font = new Font("Seogoe UI", 12, FontStyle.Bold);
            datagridviewHoaDon.AutoGenerateColumns = false;

            // Xóa các cột đã tồn tại nếu có
            if (datagridviewHoaDon.Columns.Contains("TinhTrang"))
            {
                datagridviewHoaDon.Columns.Remove("TinhTrang");
            }
            if (datagridviewHoaDon.Columns.Contains("ViewDetailButton"))
            {
                datagridviewHoaDon.Columns.Remove("ViewDetailButton");
            }

            // Cấu hình cột tình trạng
            DataGridViewComboBoxColumn statusColumn = new DataGridViewComboBoxColumn
            {
                Name = "TinhTrang",
                HeaderText = "Tình Trạng",
                DataPropertyName = "TinhTrang",
                DataSource = new List<string>
                {
                    "Chờ xác nhận",
                    "Đã xác nhận",
                    "Đang giao hàng",
                    "Mua thành công"
                },
                AutoSizeMode = DataGridViewAutoSizeColumnMode.None,
                Width = 150,
                DropDownWidth = 150
            };

            // Cấu hình cột nút xem chi tiết
            DataGridViewButtonColumn viewDetailButtonColumn = new DataGridViewButtonColumn
            {
                Name = "ViewDetailButton",
                HeaderText = "",
                Text = "Xem Chi Tiết",
                UseColumnTextForButtonValue = true,
                Width = 120
            };

            // Thêm các cột vào DataGridView
            datagridviewHoaDon.Columns.Add(statusColumn);
            datagridviewHoaDon.Columns.Add(viewDetailButtonColumn);

            // Điều chỉnh kích thước cho DataGridView
            datagridviewHoaDon.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.None;
            datagridviewHoaDon.Columns["TinhTrang"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;
            datagridviewHoaDon.Columns["ViewDetailButton"].AutoSizeMode = DataGridViewAutoSizeColumnMode.None;



            datagridviewHoaDon.DataSource = bllhd.LoadHD();

            txtMaHD.KeyDown += new KeyEventHandler(txt_KeyDown);
            txtMaKH.KeyDown += new KeyEventHandler(txt_KeyDown);
            datagridviewHoaDon.CellValueChanged += datagridviewHoaDon_CellValueChanged;
            //  datagridviewHoaDon.CellClick += datagridviewHoaDon_CellClick;
        }

        private void datagridviewHoaDon_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
           
            var tinhTrangColumn = datagridviewHoaDon.Columns["TinhTrang"];
            if (tinhTrangColumn != null && e.ColumnIndex == tinhTrangColumn.Index && e.RowIndex >= 0)
            {
                int maHD = (int)datagridviewHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value;
                string tinhTrangMoi = datagridviewHoaDon.Rows[e.RowIndex].Cells["TinhTrang"].Value as string ?? "Chưa xác định";

                // Cập nhật tình trạng mới vào database
                bllhd.UpdateTinhTrang(maHD, tinhTrangMoi);
            }
            
        }

        private void txt_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterDataGridView();
            }
        }

        // Hàm lọc dữ liệu DataGridView
        private void FilterDataGridView()
        {
            int? maHD = string.IsNullOrEmpty(txtMaHD.Text.Trim()) ? (int?)null : int.Parse(txtMaHD.Text.Trim());
            int? maKH = string.IsNullOrEmpty(txtMaKH.Text.Trim()) ? (int?)null : int.Parse(txtMaKH.Text.Trim());

            // Gọi phương thức lọc từ DAL
            var filteredData = bllhd.FilterHD(maHD, maKH).Select(hd => new
            {
                hd.MaHD,
                TinhTrang = string.IsNullOrEmpty(hd.TinhTrang) ? "Chưa xác định" : hd.TinhTrang.Trim(),
                MaKH = hd.MaKH,
                DiaChiGiaoHang = hd.DiaChiGiaoHang,
                NgayDat = hd.NgayDat,
                GhiChu = hd.GhiChu,
                TongTien = hd.TongTien,
                HinhThucThanhToan = hd.HinhThucThanhToan,
                MaNV = hd.MaNV

            }).ToList();

            datagridviewHoaDon.DataSource = filteredData;
        }

        private void datagridviewHoaDon_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == datagridviewHoaDon.Columns["ViewDetailButton"].Index && e.RowIndex >= 0)
            {
                // Lấy mã hóa đơn của hàng được chọn
                int maHD = (int)datagridviewHoaDon.Rows[e.RowIndex].Cells["MaHD"].Value;
                var invoiceDetails = bllhd.GetInvoiceDetails(maHD);

                // Tạo form mới để hiển thị chi tiết hóa đơn
                frmXemChiTietHD frm = new frmXemChiTietHD(maHD);
                frm.DataGridViewCTHD.DataSource = invoiceDetails;

                frm.Size = new Size(600, 400);
                frm.ShowDialog();
            }
        }

        private void datagridviewHoaDon_CurrentCellDirtyStateChanged(object sender, EventArgs e)
        {
            if (datagridviewHoaDon.IsCurrentCellDirty)
            {
                datagridviewHoaDon.CommitEdit(DataGridViewDataErrorContexts.Commit);
            }
        }
    }
}
