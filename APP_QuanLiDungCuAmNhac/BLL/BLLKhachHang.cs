using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using DAL;

namespace BLL
{
    public class BLLKhachHang
    {
        DALKhachHang KhachHangDAL = new DALKhachHang(); 
        public BLLKhachHang()
        { 
        
        }

        public int InsetKH(KhachHang kh)
        {
            return KhachHangDAL.insertKH(kh);
        }
        public List<KhachHang> LoadKH()
        {
            return KhachHangDAL.LoadKH();
        }
    }
}
