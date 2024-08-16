using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{

    public class DALSanPham
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALSanPham()
        {

        }
        public SanPham GetSanPhamById(int maSP)
        {
            return qldc.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);
        }
        public void UpdateSanPham(SanPham updatedSanPham)
        {
            var existingSanPham = qldc.SanPhams.SingleOrDefault(sp => sp.MaSP == updatedSanPham.MaSP);
            if (existingSanPham != null)
            {
                // Update fields
                existingSanPham.TenSP = updatedSanPham.TenSP;
                existingSanPham.DonGia = updatedSanPham.DonGia;
                existingSanPham.SoLuong = updatedSanPham.SoLuong;
                existingSanPham.HinhAnh = updatedSanPham.HinhAnh;
                existingSanPham.MoTa = updatedSanPham.MoTa;
                existingSanPham.MaLoai = updatedSanPham.MaLoai;
                existingSanPham.MaTH = updatedSanPham.MaTH;
                existingSanPham.TrangThai = updatedSanPham.TrangThai;

                // Submit changes to the database
                qldc.SubmitChanges();
            }
        }
        public List<SanPham> LoadSP()
        {
            return qldc.SanPhams.Select(nv => nv).ToList<SanPham>();
        }
        public List<SanPham> LoadSPTheoLoai(int maLoai)
        {
            return qldc.SanPhams.Where(sp => sp.MaLoai == maLoai).ToList<SanPham>();
        }
        public List<SanPham> LoadSPTheoTen(string tenSP)
        {
            return qldc.SanPhams.Where(sp => sp.TenSP.Contains(tenSP)).ToList<SanPham>();
        }
        public List<SanPham> LoadSPTheoTH(int maTH)
        {
            return qldc.SanPhams.Where(sp => sp.MaTH == maTH).ToList<SanPham>();
        }
        public void AddSanPham(SanPham sanPham)
        {
            qldc.SanPhams.InsertOnSubmit(sanPham);
            qldc.SubmitChanges();
        }
        public void DeleteSanPham(int maSP)
        {
            var sanPham = qldc.SanPhams.SingleOrDefault(sp => sp.MaSP == maSP);
            if (sanPham != null)
            {
                qldc.SanPhams.DeleteOnSubmit(sanPham);
                qldc.SubmitChanges();
            }
        }
    }
}
