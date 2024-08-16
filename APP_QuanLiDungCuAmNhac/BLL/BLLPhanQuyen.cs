using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLPhanQuyen
    {
        DALPhanQuyen PhanQuyenDAL = new DALPhanQuyen();
        public BLLPhanQuyen()
        {

        }

        public List<PhanQuyenDTO> LoadPhanQuyen()
        {
            return PhanQuyenDAL.LoadPhanQuyen();
        }

        public void UpdatePhanQuyen(string MaNhom,string MMM,bool quyen)
        {
            PhanQuyenDAL.UpdatePhanQuyen(MaNhom, MMM, quyen);
        }
        public bool CheckPermission(string maNhomNguoiDung, string maManHinh)
        {
            return PhanQuyenDAL.CheckPermission(maNhomNguoiDung,maManHinh);
        }

        public void InsertPQ(QL_PhanQuyen pq)
        {
            PhanQuyenDAL.InsertPQ(pq);
        }
        public bool KTKC(string MaNhom, string MaMH)
        {
            return PhanQuyenDAL.KTKC(MaNhom, MaMH);
        }
    }
}
