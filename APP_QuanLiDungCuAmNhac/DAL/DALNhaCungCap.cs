using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALNhaCungCap
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();

        public DALNhaCungCap()
        {

        }

        public List<NhaCungCap> LoadNCC()
        {
            return qldc.NhaCungCaps.Select(loai => loai).ToList<NhaCungCap>();
        }

        public bool ThemNCC(NhaCungCap ncc)
        {
            try
            {
                qldc.NhaCungCaps.InsertOnSubmit(ncc);
                qldc.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi thêm NCC mới: " + ex.Message);
                return false; // Trả về false nếu thêm không thành công
            }
        }

        public bool IsTenNCC(string TenNCC)
        {
            var kt = qldc.NhaCungCaps.Where(l => l.TenNCC == TenNCC).Count();
            if (kt == 0)
                return true;
            else
                return false;
        }

        public List<NhaCungCap> LoadNCCTheoMa(int mancc)
        {
            return qldc.NhaCungCaps.Where(l => l.MaNCC == mancc).ToList<NhaCungCap>();
        }

        public List<NhaCungCap> LoadNCCTheoTen(string TenNCC)
        {
            string seachItem = TenNCC.ToLower();
            return qldc.NhaCungCaps.Where(l => l.TenNCC.Contains(seachItem)).ToList<NhaCungCap>();
        }

        public void XoaNCC(int MaNCC)
        {
            var NCC = qldc.NhaCungCaps.SingleOrDefault(l => l.MaNCC == MaNCC);
            if (NCC != null)
            {
                qldc.NhaCungCaps.DeleteOnSubmit(NCC);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("NCC không tồn tại.");
            }
        }

        public bool IsNCConKho(int MaNCC)
        {
            var NCC = qldc.KhoHangs.Where(t => t.MaNCC == MaNCC).FirstOrDefault();
            if (NCC != null)
                return true;
            else
                return false;
        }

        public void UpdateNCC(NhaCungCap ncc)
        {
            var NCC = qldc.NhaCungCaps.FirstOrDefault(l => l.MaNCC == ncc.MaNCC);
            if (NCC != null)
            {
                NCC.TenNCC = ncc.TenNCC;
                NCC.SDT = ncc.SDT;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("NCC không tồn tại.");
        }

        public void InsertNCC(NhaCungCap ncc)
        {
            var NCC = new NhaCungCap
            {
                TenNCC = ncc.TenNCC,
                SDT = ncc.SDT
            };
            qldc.NhaCungCaps.InsertOnSubmit(NCC);
            qldc.SubmitChanges();
        }
    }
}
