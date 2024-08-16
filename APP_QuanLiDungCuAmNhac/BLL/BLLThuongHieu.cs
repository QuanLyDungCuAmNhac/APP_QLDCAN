using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLThuongHieu
    {
        DALThuongHieu ThuongHieuDAL = new DALThuongHieu();

        public BLLThuongHieu()
        {

        }

        public List<ThuongHieu> LoadTH()
        {
            return ThuongHieuDAL.LoadTH();
        }

        public bool IsTenTH(string TenTH)
        {
            return ThuongHieuDAL.IsTenTH(TenTH);
        }

        public List<ThuongHieu> LoadTHTheoMa(int MaTH)
        {
            return ThuongHieuDAL.LoadTHTheoMa(MaTH);
        }

        public List<ThuongHieu> LoadTHTheoTen(string TenTH)
        {
            return ThuongHieuDAL.LoadTHTheoTen(TenTH);
        }

        public void XoaTH(int MaTH)
        {
            ThuongHieuDAL.XoaTH(MaTH);
        }

        public bool IsTHOnSP(int MaTH)
        {
            return ThuongHieuDAL.IsTHOnSP(MaTH);
        }

        public void UpdateTH(ThuongHieu th)
        {
            ThuongHieuDAL.UpdateTH(th);
        }

        public void InsertTH(ThuongHieu th)
        {
            ThuongHieuDAL.InsertTH(th);
        }
    }
}
