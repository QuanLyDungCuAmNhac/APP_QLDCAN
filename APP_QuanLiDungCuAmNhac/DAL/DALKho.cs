using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALKho
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();

        public DALKho()
        {

        }
        public List<KhoHang> LoadKho()
        {
            return qldc.KhoHangs.Select(kho => kho).ToList<KhoHang>();
        }
        public List<SanPham> LoadSP()
        {
            return qldc.SanPhams.Select(km => km).ToList<SanPham>();
        }

        public List<NhaCungCap> LoadNCC()
        {
            return qldc.NhaCungCaps.Select(km => km).ToList<NhaCungCap>();
        }

        public bool IsMaKho(int MaKho)
        {
            var kt = qldc.KhoHangs.Where(l => l.MaKho == MaKho).Count();
            if (kt == 0)
                return true;
            else
                return false;
        }
        public bool ThemKho(KhoHang KH)
        {
            try
            {
                qldc.KhoHangs.InsertOnSubmit(KH);
                qldc.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi thêm kho mới: " + ex.Message);
                return false; // Trả về false nếu thêm không thành công
            }
        }  

        public List<KhoHang> LoadKhoTheoMa(int kh)
        {
            return qldc.KhoHangs.Where(l => l.MaKho == kh).ToList<KhoHang>();
        }

        public void XoaKho(int MaKho)
        {
            var Kho = qldc.KhoHangs.SingleOrDefault(l => l.MaKho == MaKho);
            if (Kho != null)
            {
                qldc.KhoHangs.DeleteOnSubmit(Kho);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("Kho không tồn tại.");
            }
        }

        public void UpdateKho(KhoHang kh)
        {
            var Kho = qldc.KhoHangs.FirstOrDefault(l => l.MaKho == kh.MaKho);
            if (Kho != null)
            {
                Kho.MaNCC = kh.MaNCC;
                Kho.MaSP = kh.MaSP;
                Kho.SoLuongNhap = kh.SoLuongNhap;
                Kho.NgayNhap = kh.NgayNhap;
                Kho.GiaNhap = kh.GiaNhap;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("Kho không tồn tại.");
        }

        public void InsertKho(KhoHang kh)
        {
            var Kho = new KhoHang
            {
                MaNCC = kh.MaNCC,
                MaSP = kh.MaSP,
                SoLuongNhap = kh.SoLuongNhap,
                NgayNhap = kh.NgayNhap,
                GiaNhap = kh.GiaNhap
            };
            qldc.KhoHangs.InsertOnSubmit(Kho);
            qldc.SubmitChanges();
        }
    }
}
