using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALDN_NDD
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALDN_NDD() { }

        public List<NhanVien> LoadNDHoatDong()
        {
            return qldc.NhanViens.Where(t=>t.HoatDong==true).ToList<NhanVien>();
        }

        public List<QL_NguoiDungNhomNguoiDung> LoadND_NDD()
        {
            return qldc.QL_NguoiDungNhomNguoiDungs.ToList<QL_NguoiDungNhomNguoiDung>();
        }

        public List<QL_NhomNguoiDung> LoadNND()
        {
            return qldc.QL_NhomNguoiDungs.ToList<QL_NhomNguoiDung>();
        }

        public bool KTKC(int MaNV,string MaNhom)
        {
            var kt = qldc.QL_NguoiDungNhomNguoiDungs.Where(l => l.MaNV == MaNV && l.MaNhomNguoiDung == MaNhom).Count();
            if (kt != 0)
                return true;
            else
                return false;
        }

        public void InserNDvaoNhom(int ManNV,string MaNhom)
        {
            var Loai = new QL_NguoiDungNhomNguoiDung
            {
                MaNV = ManNV,
                MaNhomNguoiDung = MaNhom
            };
            qldc.QL_NguoiDungNhomNguoiDungs.InsertOnSubmit(Loai);
            qldc.SubmitChanges();
        }

        public void XoaNDKhoiNhom(int MaNV,string MaNhom)
        {
            var Loai = qldc.QL_NguoiDungNhomNguoiDungs.SingleOrDefault(l => l.MaNV == MaNV && l.MaNhomNguoiDung == MaNhom);
            if (Loai != null)
            {
                qldc.QL_NguoiDungNhomNguoiDungs.DeleteOnSubmit(Loai);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("người không tồn tại trong nhóm");
            }
        }

        public string GetMaNND(string userName)
        {
            int maNV = qldc.NhanViens.Where(t => t.Username == userName).Select(t => t.MaNV).FirstOrDefault();

            return qldc.QL_NguoiDungNhomNguoiDungs.Where(t => t.MaNV == maNV).Select(t => t.MaNhomNguoiDung).FirstOrDefault();
        }
    }
}
