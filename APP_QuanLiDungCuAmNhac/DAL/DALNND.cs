using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALNND
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALNND() { }
        public List<QL_NhomNguoiDung> LoadNND()
        {
            return qldc.QL_NhomNguoiDungs.Select(nv => nv).ToList<QL_NhomNguoiDung>();
        }
        public string getTenNhom(string MaNhom)
        {
            return qldc.QL_NhomNguoiDungs.Where(nv => nv.MaNhom == MaNhom).Select(nv => nv.TenNhom).FirstOrDefault();
        }

        public int KTKC(string MaNhom)
        {
            return qldc.QL_NhomNguoiDungs.Where(n=>n.MaNhom==MaNhom).Count();
        }
        public int IsNNDonPhanQuyen(string MaNhom)
        {
            return qldc.QL_PhanQuyens.Where(n => n.MaNhomNguoiDung == MaNhom).Count();
        }

        public void UpdateNND(QL_NhomNguoiDung nnd)
        {
            var Ndd = qldc.QL_NhomNguoiDungs.FirstOrDefault(l => l.MaNhom == nnd.MaNhom);
            if (Ndd != null)
            {
                Ndd.TenNhom = nnd.TenNhom;
                Ndd.GhiChu = nnd.GhiChu;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("NND không tồn tại.");
        }

        public void InsertNhomND(QL_NhomNguoiDung nnd)
        {
            var NDD = new QL_NhomNguoiDung
            {
                MaNhom = nnd.MaNhom,
                TenNhom = nnd.TenNhom,
                GhiChu = nnd.GhiChu
            };
            qldc.QL_NhomNguoiDungs.InsertOnSubmit(NDD);
            qldc.SubmitChanges();
        }

        public void XoaNhom(string MaNhom)
        {
            var Nhom = qldc.QL_NhomNguoiDungs.SingleOrDefault(l => l.MaNhom == MaNhom);
            if (Nhom != null)
            {
                qldc.QL_NhomNguoiDungs.DeleteOnSubmit(Nhom);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("Nhom không tồn tại.");
            }
        }
    }
}
