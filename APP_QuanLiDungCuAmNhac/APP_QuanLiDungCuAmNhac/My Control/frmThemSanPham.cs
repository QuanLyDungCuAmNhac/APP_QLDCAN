using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DTO;
using BLL;
using System.IO;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmThemSanPham : Form
    {
        BLLSanPham bll_sp = new BLLSanPham();
        BLLLoai bll_loai = new BLLLoai();
        BLLThuongHieu bll_th = new BLLThuongHieu();
        private Cloudinary cloudinary;
        private string selectedImageFileName;
        public frmThemSanPham()
        {
            InitializeComponent();
            InitializeCloudinary();
        }
        private void InitializeCloudinary()
        {
            var account = new Account(
                "deuokbfws",
                "248837377936324",
                "KVCmXwtnx9zLnRet4SzN_Lee9xY");
            cloudinary = new Cloudinary(account);
        }
        public void LoadLoai()
        {
            cbo_MaLoai.DataSource = bll_loai.LoadLoai();
            cbo_MaLoai.DisplayMember = "TenLoai";
            cbo_MaLoai.ValueMember = "MaLoai";

        }
        public void LoadThuongHieu()
        {
            cbo_MaTH.DataSource = bll_th.LoadTH();
            cbo_MaTH.DisplayMember = "TenTH";
            cbo_MaTH.ValueMember = "MaTH";

        }
        private void btn_ChonHinh_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog
            {
                Filter = "Image Files|*.jpg;*.jpeg;*.png;*.bmp",
                Title = "Select an Image"
            };
            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                pictureBox_HinhAnh.Image = Image.FromFile(openFileDialog.FileName);
                selectedImageFileName = Path.GetFileName(openFileDialog.FileName); // Lưu tên file ảnh
                txt_Url.Text = openFileDialog.FileName;
            }
        }

        private async void btn_Luu_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(txt_DonGia.Text) || string.IsNullOrEmpty(txt_SoLuong.Text) || string.IsNullOrEmpty(txt_MoTa.Text)
                || string.IsNullOrEmpty(cbo_MaLoai.SelectedValue.ToString()) || string.IsNullOrEmpty(txt_TrangThai.Text)
                || string.IsNullOrEmpty(cbo_MaTH.SelectedValue.ToString()))
            {
                MessageBox.Show("Vui lòng điền đầy đủ công tin");
                return;
            }

            //  string maSP = txt_MaSP.Text;
            string tenSP = txt_TenSP.Text;
            decimal donGia = decimal.Parse(txt_DonGia.Text);
            int soLuong = int.Parse(txt_SoLuong.Text);
            string moTa = txt_MoTa.Text;
            int maLoai = int.Parse(cbo_MaLoai.SelectedValue.ToString());
            int maThuongHieu = int.Parse(cbo_MaTH.SelectedValue.ToString());
            int trangThai = int.Parse(txt_TrangThai.Text);

            // Upload image to Cloudinary
            bool uploadSuccess = await UploadImageToCloudinaryAsync(txt_Url.Text);
            
            if (uploadSuccess)
            {
                // Lưu tên hình ảnh vào database
                bll_sp.AddSanPham(tenSP, donGia, soLuong, selectedImageFileName, moTa, maLoai, maThuongHieu, trangThai);
                MessageBox.Show("Product added successfully!");
                this.Close(); // Close the form after saving
            }
            else
            {
                MessageBox.Show("Failed to upload image.");
            }

            //   LoadProducts(); // Reload data grid view
        }
        private async Task<bool> UploadImageToCloudinaryAsync(string imageFilePath)
        {
            try
            {
                var uploadParams = new ImageUploadParams
                {
                    File = new FileDescription(imageFilePath),
                    PublicId = Path.GetFileNameWithoutExtension(imageFilePath),
                    Transformation = new Transformation().Width(500).Height(500).Crop("limit")
                };
                var uploadResult = await cloudinary.UploadAsync(uploadParams);

                return uploadResult.StatusCode == System.Net.HttpStatusCode.OK;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error uploading image: " + ex.Message);
                return false;
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void frmThemSanPham_Load(object sender, EventArgs e)
        {
            LoadLoai();
            LoadThuongHieu();
        }

        private void txt_SoLuong_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }

        private void txt_DonGia_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
    }
}

