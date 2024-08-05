using BLL;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using DTO;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class ThongKeDoanhThu : UserControl
    {
        BLLThongKe ThongKeBLL = new BLLThongKe();
        public ThongKeDoanhThu()
        {
            InitializeComponent();
            cbbNam.SelectedIndexChanged += CbbNam_SelectedIndexChanged;
            this.Load += ThongKeDoanhThu_Load;
        }

        private void ThongKeDoanhThu_Load(object sender, EventArgs e)
        {
            InitializeComboBox();
           

        }

        private void CbbNam_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedYear = (int)cbbNam.SelectedItem;
            List<DoanhThuThangDTO> doanhThuThang = ThongKeBLL.LayDoanhThuTheoThang(selectedYear);
            HienThiBieuDo(doanhThuThang);
        }

        private void HienThiBieuDo(List<DoanhThuThangDTO> doanhThuThang)
        {
            chartDoanhThu.Series.Clear();
            Series series = new Series("Doanh Thu");
            series.ChartType = SeriesChartType.Column;

            foreach (var dt in doanhThuThang)
            {
                series.Points.AddXY(dt.Thang, dt.TongTien);
            }

            chartDoanhThu.Series.Add(series);
        }

        private void InitializeComboBox()
        {
            // Giả sử bạn muốn hiển thị các năm từ 2020 đến 2024
            for (int year = 2024; year >= 2020; year--)
            {
                cbbNam.Items.Add(year);
            }
            cbbNam.SelectedIndex = 0; // Chọn năm đầu tiên mặc định
        }
    }
}
