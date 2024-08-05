using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using DAL;
using DTO;

namespace BLL
{
    public class BLLSanPham
    {
        DALSanPham SanPhamDAL = new DALSanPham();
        public BLLSanPham()
        {

        }
        public SanPham GetSanPhamById(int maSP)
        {
            return SanPhamDAL.GetSanPhamById(maSP);
        }

        public void UpdateSanPham(int maSP, string tenSP, decimal donGia, int soLuong, string hinhAnh, string moTa, int maLoai, int maThuongHieu, int trangThai)
        {
            SanPham sanPham = SanPhamDAL.GetSanPhamById(maSP);
            if (sanPham != null)
            {
                sanPham.TenSP = tenSP;
                sanPham.DonGia = donGia;
                sanPham.SoLuong = soLuong;
                sanPham.HinhAnh = hinhAnh;
                sanPham.MoTa = moTa;
                sanPham.MaLoai = maLoai;
                sanPham.MaTH = maThuongHieu;
                sanPham.TrangThai = trangThai;

                SanPhamDAL.UpdateSanPham(sanPham);
            }
        }
        public List<SanPham> LoadSP()
        {
            return SanPhamDAL.LoadSP();
        }
        public List<SanPham> LoadSPTheoLoai(int maLoai)
        {
            return SanPhamDAL.LoadSPTheoLoai(maLoai);
        }
        public List<SanPham> LoadSPTheoTen(string tenSP)
        {
            return SanPhamDAL.LoadSPTheoTen(tenSP);
        }
        public void AddSanPham(string tenSP, decimal donGia, int soLuong, string hinhAnh, string moTa, int maLoai, int maThuongHieu, int trangThai)
        {
            var product = new SanPham
            {

                TenSP = tenSP,
                DonGia = donGia,
                SoLuong = soLuong,
                HinhAnh = hinhAnh,
                MoTa = moTa,
                MaLoai = maLoai,
                MaTH = maThuongHieu,
                TrangThai = trangThai
            };

            SanPhamDAL.AddSanPham(product);
        }
        public void DeleteSanPham(int maSP)
        {
            SanPhamDAL.DeleteSanPham(maSP);
        }

        public List<SanPham> LoadSPTheoTH(int maTH)
        {
            return SanPhamDAL.LoadSPTheoTH(maTH);
        }
    }
}
