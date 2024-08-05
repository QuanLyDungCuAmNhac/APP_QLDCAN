using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLKho
    {
        DALKho KhoDAL = new DALKho();

        public BLLKho()
        {

        }

        public List<KhoHang> LoadKho()
        {
            return KhoDAL.LoadKho();
        }

        public List<KhoHang> LoadKhoTheoMa(int MaKho)
        {
            return KhoDAL.LoadKhoTheoMa(MaKho);
        }    

        public List<SanPham> LoadSP()
        {
            return KhoDAL.LoadSP();
        }

        public List<NhaCungCap> LoadNCC()
        {
            return KhoDAL.LoadNCC();
        }
        public void XoaKho(int MaKho)
        {
            KhoDAL.XoaKho(MaKho);
        }
        public bool IsMaKho(int MaKho)
        {
            return KhoDAL.IsMaKho(MaKho);
        }

        public void UpdateKho(KhoHang kh)
        {
            KhoDAL.UpdateKho(kh);
        }

        public void InsertKho(KhoHang kh)
        {
            KhoDAL.InsertKho(kh);
        }
    }
}
