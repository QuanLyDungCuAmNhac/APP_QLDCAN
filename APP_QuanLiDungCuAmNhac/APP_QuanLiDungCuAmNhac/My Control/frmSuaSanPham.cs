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
using APP_QuanLiDungCuAmNhac.UserControls;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class frmSuaSanPham : Form
    {
        BLLSanPham bll_sp = new BLLSanPham();
        BLLLoai bll_loai = new BLLLoai();
        BLLThuongHieu bll_th = new BLLThuongHieu();
        private Cloudinary cloudinary;
        private int productId;
        private string currentImageFileName;

        public frmSuaSanPham(int productId)
        {
            InitializeComponent();
            this.productId = productId;
            InitializeCloudinary();
            //LoadProductDetails();
        }

        private void InitializeCloudinary()
        {
            var account = new Account(
                "deuokbfws",
                "248837377936324",
                "KVCmXwtnx9zLnRet4SzN_Lee9xY");
            cloudinary = new Cloudinary(account);
        }

        private void LoadProductDetails()
        {
            var product = bll_sp.GetSanPhamById(productId);
            if (product != null)
            {
                // txt_MaSP.Text = product.MaSP.ToString();
                txt_TenSP.Text = product.TenSP;
                txt_DonGia.Text = product.DonGia.ToString();
                txt_SoLuong.Text = product.SoLuong.ToString();
                txt_MoTa.Text = product.MoTa;
                cbo_MaLoai.SelectedValue = product.MaLoai;
                cbo_MaTH.SelectedValue = product.MaTH;
                txt_TrangThai.Text = product.TrangThai.ToString();
                currentImageFileName = product.HinhAnh;
                // Load current image from Cloudinary

                var imageUrl = cloudinary.Api.UrlImgUp.BuildUrl(product.HinhAnh.Trim());
                pictureBox_HinhAnh.ImageLocation = imageUrl;
            }
        }

        public void LoadLoai()
        {
            cbo_MaLoai.DataSource = bll_loai.LoadLoai();
            cbo_MaLoai.DisplayMember = "TenLoai";
            cbo_MaLoai.ValueMember = "MaLoai";
            cbo_MaLoai.SelectedIndex = -1;
        }

        public void LoadThuongHieu()
        {
            cbo_MaTH.DataSource = bll_th.LoadTH();
            cbo_MaTH.DisplayMember = "TenTH";
            cbo_MaTH.ValueMember = "MaTH";
            cbo_MaTH.SelectedIndex = -1;
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
                currentImageFileName = Path.GetFileName(openFileDialog.FileName); // Lưu tên file ảnh
                txt_Url.Text = openFileDialog.FileName;
            }
        }

        private async void btn_Luu_Click(object sender, EventArgs e)
        {
            string tenSP = txt_TenSP.Text;
            decimal donGia = decimal.Parse(txt_DonGia.Text);
            int soLuong = int.Parse(txt_SoLuong.Text);
            string moTa = txt_MoTa.Text;
            int maLoai = int.Parse(cbo_MaLoai.SelectedValue.ToString());
            int maThuongHieu = int.Parse(cbo_MaTH.SelectedValue.ToString());
            int trangThai = int.Parse(txt_TrangThai.Text);

            // Upload image to Cloudinary if a new image is selected
            if (!string.IsNullOrEmpty(txt_Url.Text))
            {
                bool uploadSuccess = await UploadImageToCloudinaryAsync(txt_Url.Text);
                if (uploadSuccess)
                {
                    currentImageFileName = Path.GetFileName(txt_Url.Text);
                }
                else
                {
                    MessageBox.Show("Failed to upload image.");
                    return;
                }
            }

            // Update product details in database
            bll_sp.UpdateSanPham(productId, tenSP, donGia, soLuong, currentImageFileName, moTa, maLoai, maThuongHieu, trangThai);
            MessageBox.Show("Product updated successfully!");

            this.Close(); // Close the form after saving
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

        private void frmSuaSanPham_Load(object sender, EventArgs e)
        {
            LoadLoai();
            LoadThuongHieu();
            LoadProductDetails();
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

        private void frmSuaSanPham_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
