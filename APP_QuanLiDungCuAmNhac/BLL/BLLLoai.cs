using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLLoai
    {
        DALLoaiSP LoaiDAL = new DALLoaiSP();

        public BLLLoai()
        {
            
        }

        public List<LoaiSP> LoadLoai()
        {
            return LoaiDAL.LoadLoai();
        }

        public bool IsTenLoai(string TenLoai)
        {
            return LoaiDAL.IsTenLoai(TenLoai);
        }

        public List<LoaiSP> LoadLoaiTheoMa(int MaLoai)
        {
            return LoaiDAL.LoadLoaiTheoMa(MaLoai);
        }

        public List<LoaiSP> LoadLoaiTheoTen(string TenLoai)
        {
            return LoaiDAL.LoadLoaiTheoTen(TenLoai);
        }

        public void XoaLoai(int MaLoai)
        {
            LoaiDAL.XoaLoai(MaLoai);
        }

        public bool IsLoaiOnSP(int MaLoai)
        {
            return LoaiDAL.IsLoaiOnSP(MaLoai);
        }

        public void UpdateLoai(LoaiSP loai)
        {
            LoaiDAL.UpdateLoai(loai);
        }

        public void InsertLoai(LoaiSP loai)
        {
            LoaiDAL.InsertLoai(loai);
        }
    }
}
