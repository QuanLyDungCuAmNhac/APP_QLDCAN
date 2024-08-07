using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;
using static DAL.DALHoaDon;
namespace BLL
{
    public class BLLHoaDon
    {
        private DALHoaDon dalHoaDon = new DALHoaDon();
        public List<HoaDon> LoadHD()
        {
            return dalHoaDon.LoadHD();
        }
        public List<HoaDon> FilterHD(int? maHD, int? maKH, string tinhTrang)
        {
            return dalHoaDon.FilterHD(maHD, maKH,tinhTrang);
        }
        public void UpdateTinhTrang(int maHD, string tinhTrangMoi)
        {
            // Tìm hóa đơn dựa trên MaHD
            dalHoaDon.UpdateTinhTrang(maHD, tinhTrangMoi);
        }
        public void DeleteHD(int maHD)
        {
            dalHoaDon.DeleteHD(maHD);
        }
        public int SaveHoaDon(HoaDon hoaDon)
        {
            return dalHoaDon.SaveHoaDon(hoaDon);
        }

        public bool SaveChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            return dalHoaDon.SaveChiTietHoaDon(chiTietHoaDon);
        }
        public List<DoanhThuTheoNgay> GetDoanhThuTheoThang(int month, int year)
        {
            return dalHoaDon.GetDoanhThuTheoThang(month, year);
        }
        public List<ChiTietHoaDon> GetInvoiceDetails(int maHD)
        {
            return dalHoaDon.GetInvoiceDetails(maHD);
        }
    }
}
