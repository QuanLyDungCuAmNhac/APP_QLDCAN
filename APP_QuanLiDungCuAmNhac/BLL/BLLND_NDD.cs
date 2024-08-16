using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLND_NDD
    {
        DALDN_NDD ND_NDDBAL = new DALDN_NDD();
        public BLLND_NDD() { }

        public List<NhanVien> LoadNDHoatDong()
        {
            return ND_NDDBAL.LoadNDHoatDong();
        }

        public List<QL_NguoiDungNhomNguoiDung> LoadND_NDD()
        {
            return ND_NDDBAL.LoadND_NDD();
        }

        public List<QL_NhomNguoiDung> LoadNND()
        {
            return ND_NDDBAL.LoadNND();
        }

        public bool KTKC(int MaNV,string MaNhom)
        {
            return ND_NDDBAL.KTKC(MaNV,MaNhom);
        }

        public void InserNDvaoNhom(int MaNV, string MaNhom)
        {
            ND_NDDBAL.InserNDvaoNhom(MaNV, MaNhom);
        }

        public void XoaNDKhoiNhom(int MaNV, string MaNhom)
        {
            ND_NDDBAL.XoaNDKhoiNhom(MaNV, MaNhom);  
        }

        public string GetMaNND(string userName)
        {
            return ND_NDDBAL.GetMaNND(userName);
        }


    }
}
