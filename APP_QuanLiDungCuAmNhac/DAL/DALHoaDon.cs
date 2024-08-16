using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
namespace DAL
{
    public class DALHoaDon
    {
        QL_DCANDataContext qldcan = new QL_DCANDataContext();
        public List<HoaDon> LoadHD()
        {
            return qldcan.HoaDons.Select(nv => nv).ToList<HoaDon>();
        }
        public void UpdateTinhTrang(int maHD, string tinhTrangMoi)
        {
            // Tìm hóa đơn dựa trên MaHD
            var hoaDon = qldcan.HoaDons.SingleOrDefault(hd => hd.MaHD == maHD);

            if (hoaDon != null)
            {
                // Cập nhật giá trị của thuộc tính TinhTrang
                hoaDon.TinhTrang = tinhTrangMoi;

                // Lưu thay đổi vào cơ sở dữ liệu
                qldcan.SubmitChanges();
            }
            else
            {
                throw new Exception("Hóa đơn không tồn tại.");
            }
        }
        public List<HoaDon> FilterHD(int? maHD, int? maKH, string tinhTrang)
        {
            var allHoaDons = LoadHD(); // Lấy tất cả hóa đơn

            var filteredHoaDons = allHoaDons.Where(hd =>
                (!maHD.HasValue || hd.MaHD == maHD.Value) &&
                (!maKH.HasValue || hd.MaKH == maKH.Value) &&
                (string.IsNullOrEmpty(tinhTrang) || hd.TinhTrang == tinhTrang)
            ).ToList();

            return filteredHoaDons;
        }

        public int SaveHoaDon(HoaDon hoaDon)
        {

            qldcan.HoaDons.InsertOnSubmit(hoaDon);
            qldcan.SubmitChanges();
            return hoaDon.MaHD; // Trả về MaHD của hóa đơn vừa được lưu
           
        }

        public bool SaveChiTietHoaDon(ChiTietHoaDon chiTietHoaDon)
        {
            try
            {
                qldcan.ChiTietHoaDons.InsertOnSubmit(chiTietHoaDon);
                qldcan.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                // Log or handle the exception
                return false;
            }
        }

        public List<DoanhThuTheoNgay> GetDoanhThuTheoThang(int month, int year)
        {
            var query = qldcan.HoaDons
            .Where(hd => hd.NgayDat.HasValue && hd.NgayDat.Value.Month == month && hd.NgayDat.Value.Year == year)
            .GroupBy(hd => hd.NgayDat.Value.Day)
            .Select(g => new DoanhThuTheoNgay
            {
                Ngay = g.Key,
                DoanhThu = g.Sum(hd => hd.TongTien ?? 0)
            })
            .ToList();

            return query;
        }

        public class DoanhThuTheoNgay
        {
            public int Ngay { get; set; }
            public decimal DoanhThu { get; set; }
        }
        public void DeleteHD(int maHD)
        {
            var hoaDon = qldcan.HoaDons.SingleOrDefault(hd => hd.MaHD == maHD);
            if (hoaDon != null)
            {
                qldcan.HoaDons.DeleteOnSubmit(hoaDon);
                qldcan.SubmitChanges();
            }
        }
        public List<ChiTietHoaDon> GetInvoiceDetails(int maHD)
        {
             var details = from d in qldcan.ChiTietHoaDons
                              where d.MaHD == maHD
                              select d;

                return details.ToList();
            
        }
    }
}
