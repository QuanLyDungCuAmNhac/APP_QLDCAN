using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLNND
    {
        DALNND NNDDAL = new DALNND();
        public BLLNND() { }

        public List<QL_NhomNguoiDung> LoadNND()
        {
            return NNDDAL.LoadNND();
        }

        public string getTenNhom(string MaNhom)
        {
            return NNDDAL.getTenNhom(MaNhom);
        }

        public int KTKC(string MaNhom)
        {
            return NNDDAL.KTKC(MaNhom);
        }
        public void UpdateNND(QL_NhomNguoiDung nnd)
        {
            NNDDAL.UpdateNND(nnd);
        }
        public void InsertNhomND(QL_NhomNguoiDung nnd)
        {
            NNDDAL.InsertNhomND(nnd);
        }
        public void XoaNhom(string MaNhom)
        {
            NNDDAL.XoaNhom(MaNhom);
        }
        public int IsNNDonPhanQuyen(string MaNhom)
        {
            return NNDDAL.IsNNDonPhanQuyen(MaNhom);
        }
    }
}
