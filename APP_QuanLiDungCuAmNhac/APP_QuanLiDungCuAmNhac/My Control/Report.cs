using DTO;
using Microsoft.Reporting.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class Report : Form
    {
        private List<HoaDonDTO> _hoaDonData;
        private string _TenKH;
        private string _DiaChi;
        private string _SDT;
        public Report(List<HoaDonDTO> hoaDonData,string TenKh,string DiaChi,string SDT)
        {
            InitializeComponent();
            _hoaDonData = hoaDonData;
            _TenKH = TenKh;
            _DiaChi = DiaChi;
            _SDT = SDT;
        }

        private void Report_Load(object sender, EventArgs e)
        {
            // Thiết lập đường dẫn đến file RDLC
            string reportPath = "D:\\HK 7\\PhatTrienPhanMemThongMinh\\APP_QLDCAN\\APP_QuanLiDungCuAmNhac\\APP_QuanLiDungCuAmNhac\\My Control\\MyReport.rdlc";
            if (!System.IO.File.Exists(reportPath))
            {
                MessageBox.Show("File báo cáo không tồn tại: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reportViewer1.LocalReport.ReportPath = reportPath;
            this.reportViewer1.RefreshReport();
        }

        private void reportViewer1_Load(object sender, EventArgs e)
        {
            // Thiết lập lại đường dẫn đến file RDLC
            string reportPath = "D:\\HK 7\\PhatTrienPhanMemThongMinh\\APP_QLDCAN\\APP_QuanLiDungCuAmNhac\\APP_QuanLiDungCuAmNhac\\My Control\\MyReport.rdlc";
            if (!File.Exists(reportPath))
            {
                MessageBox.Show("File báo cáo không tồn tại: " + reportPath, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            reportViewer1.LocalReport.ReportPath = reportPath;

            // Tạo các tham số (nếu cần)
            ReportParameter[] para = new ReportParameter[4];
            para[0] = new ReportParameter("TenKH", _TenKH);
            para[1] = new ReportParameter("SDT", _SDT);
            para[2] = new ReportParameter("DiaChi", _DiaChi);
            para[3] = new ReportParameter("Ngay", "Ngày " + DateTime.Now.Day.ToString() + " tháng " + DateTime.Now.Month.ToString() + " năm " + DateTime.Now.Year.ToString());

            reportViewer1.LocalReport.SetParameters(para);

            // Kiểm tra dữ liệu
            if (_hoaDonData == null || _hoaDonData.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để hiển thị trong báo cáo.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Xóa các nguồn dữ liệu hiện có
            reportViewer1.LocalReport.DataSources.Clear();

            // Thêm nguồn dữ liệu mới với tên khớp với DataSet trong RDLC
            ReportDataSource reportDataSource = new ReportDataSource("HoaDon", _hoaDonData);
            reportViewer1.LocalReport.DataSources.Add(reportDataSource);

            // Làm mới báo cáo
            reportViewer1.RefreshReport();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
