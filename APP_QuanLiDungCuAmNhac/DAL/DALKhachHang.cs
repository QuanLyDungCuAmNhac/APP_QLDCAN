using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALKhachHang
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALKhachHang()
        {
        }
        public int insertKH(KhachHang kh)
        {
            var KH = new KhachHang
            {
                TenKH = kh.TenKH,
                Email = kh.Email,
                SDT = kh.SDT,
            };
            qldc.KhachHangs.InsertOnSubmit(KH);
            qldc.SubmitChanges();
            return KH.MaKH;
        }

        public List<KhachHang> LoadKH()
        {
            return qldc.KhachHangs.Select(kh=>kh).ToList<KhachHang>();
        }
    }
}
