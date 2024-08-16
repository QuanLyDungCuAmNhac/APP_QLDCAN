using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALThuongHieu
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();

        public DALThuongHieu() 
        {
            
        }

        public List<ThuongHieu> LoadTH()
        {
            return qldc.ThuongHieus.Select(th => th).ToList<ThuongHieu>();
        }

        public bool ThemTH(ThuongHieu THmoi)
        {
            try
            {
                qldc.ThuongHieus.InsertOnSubmit(THmoi);
                qldc.SubmitChanges();
                return true; // Trả về true nếu thêm thành công
            }
            catch (Exception ex)
            {
                // Xử lý ngoại lệ nếu có lỗi xảy ra
                Console.WriteLine("Lỗi khi thêm thương hiệu mới: " + ex.Message);
                return false; // Trả về false nếu thêm không thành công
            }
        }

        public bool IsTenTH(string TenTH)
        {
            var kt = qldc.ThuongHieus.Where(l => l.TenTH == TenTH).Count();
            if (kt == 0)
                return true;
            else
                return false;
        }

        public List<ThuongHieu> LoadTHTheoMa(int MaTH)
        {
            return qldc.ThuongHieus.Where(l => l.MaTH == MaTH).ToList<ThuongHieu>();
        }

        public List<ThuongHieu> LoadTHTheoTen(string TenTH)
        {
            string seachItem = TenTH.ToLower();
            return qldc.ThuongHieus.Where(l => l.TenTH.Contains(seachItem)).ToList<ThuongHieu>();
        }

        public void XoaTH(int MaTH)
        {
            var TH = qldc.ThuongHieus.SingleOrDefault(l => l.MaTH == MaTH);
            if (TH != null)
            {
                qldc.ThuongHieus.DeleteOnSubmit(TH);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("Loại không tồn tại.");
            }
        }

        public bool IsTHOnSP(int MaTH)
        {
            var TH = qldc.SanPhams.Where(t => t.MaTH == MaTH).FirstOrDefault();
            if (TH != null)
                return true;
            else
                return false;
        }

        public void UpdateTH(ThuongHieu th)
        {
            var TH = qldc.ThuongHieus.FirstOrDefault(l => l.MaTH == th.MaTH);
            if (TH != null)
            {
                TH.TenTH = th.TenTH;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("Loại không tồn tại.");
        }

        public void InsertTH(ThuongHieu th)
        {
            var TH = new ThuongHieu
            {
                TenTH = th.TenTH
            };
            qldc.ThuongHieus.InsertOnSubmit(TH);
            qldc.SubmitChanges();
        }
    }
}
