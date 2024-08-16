using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using DTO;

namespace DAL
{
    public class DALLoaiSP
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        
        public DALLoaiSP() 
        {
            
        }

        public List<LoaiSP> LoadLoai()
        {
            return qldc.LoaiSPs.Select(loai=>loai).ToList<LoaiSP>();
        }

        public bool ThemLoai(LoaiSP LoaiSpMoi)
        {
            try
            {
                qldc.LoaiSPs.InsertOnSubmit(LoaiSpMoi);
                qldc.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi thêm loại sản phẩm mới: " + ex.Message);
                return false; // Trả về false nếu thêm không thành công
            }
        }

        public bool IsTenLoai(string TenLoai)
        {
            var kt = qldc.LoaiSPs.Where(l => l.TenLoai == TenLoai).Count();
            if (kt == 0)
                return true;
            else 
                return false;
        }

        public List<LoaiSP> LoadLoaiTheoMa(int MaLoai)
        {
            return qldc.LoaiSPs.Where(l => l.MaLoai == MaLoai).ToList<LoaiSP>();
        }

        public List<LoaiSP> LoadLoaiTheoTen(string TenLoai)
        {
            string seachItem = TenLoai.ToLower();
            return qldc.LoaiSPs.Where(l => l.TenLoai.Contains(seachItem)).ToList<LoaiSP>();
        }

        public void XoaLoai(int MaLoai)
        {
            var Loai = qldc.LoaiSPs.SingleOrDefault(l => l.MaLoai == MaLoai);
            if (Loai != null)
            {
                qldc.LoaiSPs.DeleteOnSubmit(Loai);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("Loại không tồn tại.");
            }
        }

        public bool IsLoaiOnSP(int MaLoai)
        {
            var Loai = qldc.SanPhams.Where(t=>t.MaLoai==MaLoai).FirstOrDefault();
            if (Loai != null)
                return true;
            else
                return false;
        }

        public void UpdateLoai(LoaiSP loai)
        {
            var Loai = qldc.LoaiSPs.FirstOrDefault(l => l.MaLoai == loai.MaLoai);
            if(Loai != null)
            {
                Loai.TenLoai = loai.TenLoai;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("Loại không tồn tại.");
        }

        public void InsertLoai(LoaiSP loai)
        {
            var Loai = new LoaiSP
            {
                TenLoai = loai.TenLoai
            };
            qldc.LoaiSPs.InsertOnSubmit(Loai);
            qldc.SubmitChanges();
        }
    }
}
