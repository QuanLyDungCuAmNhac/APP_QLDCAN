using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;

namespace BLL
{
    public class BLLNhaCungCap
    {
        DALNhaCungCap NhaCungCapDAL = new DALNhaCungCap();

        public BLLNhaCungCap()
        {

        }

        public List<NhaCungCap> LoadNCC()
        {
            return NhaCungCapDAL.LoadNCC();
        }

        public bool IsTenNCC(string TenNCC)
        {
            return NhaCungCapDAL.IsTenNCC(TenNCC);
        }

        public bool IsNccOnKho(int MaNCC)
        {
            return NhaCungCapDAL.IsNCConKho(MaNCC);
        }

        public List<NhaCungCap> LoadNCCTheoMa(int MaNCC)
        {
            return NhaCungCapDAL.LoadNCCTheoMa(MaNCC);
        }

        public List<NhaCungCap> LoadNCCTheoTen(string TenNCC)
        {
            return NhaCungCapDAL.LoadNCCTheoTen(TenNCC);
        }

        public void XoaNCC(int MaNCC)
        {
            NhaCungCapDAL.XoaNCC(MaNCC);
        }

        public void UpdateNCC(NhaCungCap ncc)
        {
            NhaCungCapDAL.UpdateNCC(ncc);
        }

        public void InsertNCC(NhaCungCap ncc)
        {
            NhaCungCapDAL.InsertNCC(ncc);
        }
    }
}
