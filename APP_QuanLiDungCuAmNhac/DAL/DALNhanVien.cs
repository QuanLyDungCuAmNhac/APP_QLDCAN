using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using DTO;

namespace DAL
{
    public class DALNhanVien
    {
        QL_DCANDataContext qldc = new QL_DCANDataContext();
        public DALNhanVien() 
        { 
            
        }

        public List<NhanVien> LoadNV()
        {
            return qldc.NhanViens.Select(nv => nv).ToList<NhanVien>();
        }

        public bool Login(string TenDangNhap, string MatKhau)
        {
            var nv = qldc.NhanViens.SingleOrDefault(n => n.Username == TenDangNhap && n.Password == HashPassword(MatKhau));
            return nv != null;
            //return true;
        }
        private string HashPassword(string password)
        {
            using (var sha256 = SHA256.Create())
            {
                var hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public bool getTrangThai(string UserName)
        {
            bool? trangthai = qldc.NhanViens.Where(t=>t.Username == UserName).Select(t=>t.HoatDong).FirstOrDefault();
            if(trangthai == true)
                return true;
            return false;
        }

        public void UpdateHoatDongNV (int id, bool HoatDong)
        {
            var NV = qldc.NhanViens.FirstOrDefault(l => l.MaNV == id);
            if (NV != null)
            {
                NV.HoatDong = HoatDong;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("NV không tồn tại.");
        }

        public string GetName(string UserName)
        {
            return qldc.NhanViens.Where(nv=>nv.Username == UserName).Select(nv => nv.TenNV).FirstOrDefault();
        }

        public int KTKC(int MaNV)
        {
            return qldc.NhanViens.Where(n => n.MaNV == MaNV).Count();
        }

        public void UpdateNV(NhanVien nv)
        {
            var NV = qldc.NhanViens.FirstOrDefault(l => l.MaNV == nv.MaNV);
            if (NV != null)
            {
                NV.TenNV = nv.TenNV;
                NV.SDT = nv.SDT;
                NV.Email = nv.Email;
                NV.Username = nv.Username;
                NV.Password = nv.Password;
                qldc.SubmitChanges();
            }
            else
                throw new Exception("nhân viên không tồn tại.");
        }

        public void InsertNV(NhanVien nv)
        {
            NhanVien nhanVien = new NhanVien{  
                MaNV = nv.MaNV,
                TenNV = nv.TenNV,
                SDT = nv.SDT,
                Email = nv.Email,
                Username = nv.Username,
                Password = nv.Password,
            };
            qldc.NhanViens.InsertOnSubmit(nhanVien);
            qldc.SubmitChanges();

        }

        public void XoaNV(int MaNV)
        {
            var NV = qldc.NhanViens.SingleOrDefault(l => l.MaNV == MaNV);
            if (NV != null)
            {
                qldc.NhanViens.DeleteOnSubmit(NV);
                qldc.SubmitChanges();
            }
            else
            {
                throw new Exception("nhân viên không tồn tại.");
            }
        }
    }
}
