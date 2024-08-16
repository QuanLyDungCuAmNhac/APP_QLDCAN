using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;
using BLL;
using DAL;

namespace BLL
{
    public class BLLThongKe
    {
        DALThongKe ThongKeDAL = new DALThongKe();
        public BLLThongKe() { }

        public List<DoanhThuThangDTO> LayDoanhThuTheoThang(int nam)
        {
            return ThongKeDAL.LayDoanhThuTheoThang(nam);
        }
        public List<SanPhamBanRaDTO> GetSanPhamBanRa()
        {
            return ThongKeDAL.GetSanPhamBanRa();
        }
    }
}
