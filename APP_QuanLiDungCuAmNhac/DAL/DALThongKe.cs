using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALThongKe
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALThongKe()
        {

        }
        public List<DoanhThuThangDTO> LayDoanhThuTheoThang(int nam)
        {
            var doanhThuThang = qldc.HoaDons
                .Where(hd => hd.NgayDat.Value.Year == nam)
                .GroupBy(hd => hd.NgayDat.Value.Month)
                .Select(g => new DoanhThuThangDTO
                {
                    Thang = g.Key,
                    TongTien = g.Sum(hd => hd.TongTien),
                })
                .ToList();

            return doanhThuThang;
        }

        public List<SanPhamBanRaDTO> GetSanPhamBanRa()
        {
            var query = from cthd in qldc.ChiTietHoaDons
                        join sp in qldc.SanPhams on cthd.MaSP equals sp.MaSP
                        group cthd by new { cthd.MaSP, sp.TenSP } into g
                        select new SanPhamBanRaDTO
                        {
                            MaSP = g.Key.MaSP,
                            TenSP = g.Key.TenSP,
                            SoLuong = g.Sum(x => x.SoLuong)
                        };

            return query.ToList();
        }
    }
}
