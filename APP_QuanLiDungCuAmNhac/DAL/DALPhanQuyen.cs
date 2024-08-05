using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    
    public class DALPhanQuyen
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALPhanQuyen() { }

        public List<PhanQuyenDTO> LoadPhanQuyen()
        {
            var result = from pq in qldc.QL_PhanQuyens
                         join mh in qldc.DM_ManHinhs on pq.MaManHinh equals mh.MaManHinh
                         select new PhanQuyenDTO
                         {
                             MaNhomNguoiDung = pq.MaNhomNguoiDung,
                             MaManHinh = mh.MaManHinh,
                             TenManHinh = mh.TenManHinh,
                             CoQuyen = pq.CoQuyen
                         };

            return result.ToList();
        }

        public void UpdatePhanQuyen(string MaNhom,string MaManHinh,bool quyen)
        {
            var Loai = qldc.QL_PhanQuyens.FirstOrDefault(l => l.MaNhomNguoiDung == MaNhom && l.MaManHinh == MaManHinh);
            if (Loai != null)
            {
               Loai.CoQuyen = quyen;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("Nhóm quyền không tồn tại.");
        }

        public bool CheckPermission(string maNhomNguoiDung, string maManHinh)
        {
            // Thực hiện truy vấn kiểm tra quyền hạn từ cơ sở dữ liệu     
                var permission = qldc.QL_PhanQuyens
                    .FirstOrDefault(p => p.MaNhomNguoiDung == maNhomNguoiDung && p.MaManHinh == maManHinh);

                return permission != null && permission.CoQuyen;  
        }

        public void InsertPQ(QL_PhanQuyen pq)
        {
            var PQ = new QL_PhanQuyen
            {
                MaNhomNguoiDung = pq.MaNhomNguoiDung,
                MaManHinh = pq.MaManHinh,
                CoQuyen = pq.CoQuyen,
            };
            qldc.QL_PhanQuyens.InsertOnSubmit(PQ);
            qldc.SubmitChanges();
        }
        public bool KTKC(string MaNhom,string MaMH)
        {
            var kt = qldc.QL_PhanQuyens.Where(l => l.MaNhomNguoiDung == MaNhom && l.MaManHinh == MaMH).Count();
            if (kt != 0)
                return true;
            else
                return false;
        }
    }
}
