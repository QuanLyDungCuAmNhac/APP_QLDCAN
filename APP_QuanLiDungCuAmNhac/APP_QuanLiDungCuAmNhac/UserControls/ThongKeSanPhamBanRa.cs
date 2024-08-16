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
using System.Windows.Forms.DataVisualization.Charting;

namespace APP_QuanLiDungCuAmNhac.UserControls
{
    public partial class ThongKeSanPhamBanRa : UserControl
    {
        BLLThongKe ThongKeBLL = new BLLThongKe();

        public ThongKeSanPhamBanRa()
        {
            InitializeComponent();
            LoadChart();
        }
        private void LoadChart()
        {
            List<SanPhamBanRaDTO> data = ThongKeBLL.GetSanPhamBanRa();

            chart.Series.Clear();
            Series series = new Series
            {
                Name = "Sản phẩm",
                IsValueShownAsLabel = true,
                ChartType = SeriesChartType.Pie
            };

            chart.Series.Add(series);

            foreach (var item in data)
            {
                series.Points.AddXY(item.TenSP, item.SoLuong);
            }

            chart.Invalidate();
        }

        private void chart_Click(object sender, EventArgs e)
        {

        }
    }
}
