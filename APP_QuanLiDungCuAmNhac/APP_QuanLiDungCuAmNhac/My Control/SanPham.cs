using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace APP_QuanLiDungCuAmNhac.My_Control
{
    public partial class SanPham : UserControl
    {

        public SanPham()
        {
            InitializeComponent();
        }
        public string TenSP
        {
            get => label1.Text;
            set => label1.Text = value;
        }

        public string Price
        {
            get => label2.Text;
            set => label2.Text = value;
        }

        //private string _imageUrl;
        //public string ImageUrl
        //{
        //    get => _imageUrl;
        //    set
        //    {
        //        _imageUrl = value;
        //        try
        //        {
        //            if (File.Exists(_imageUrl))
        //            {
        //                pictureBox1.Image = Image.FromFile(_imageUrl);
        //            }
        //            else
        //            {
        //                MessageBox.Show("Image not found: " + _imageUrl);
        //                pictureBox1.Image = null; // Hoặc đặt hình ảnh mặc định nếu cần
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error loading image: " + ex.Message);
        //            pictureBox1.Image = null; // Hoặc đặt hình ảnh mặc định nếu cần
        //        }
        //    }
        //}
        //private string _imageUrl;
        //public string ImageUrl
        //{
        //    get => _imageUrl;
        //    set
        //    {
        //        _imageUrl = value;
        //        try
        //        {
        //            using (WebClient webClient = new WebClient())
        //            {
        //                byte[] imageBytes = webClient.DownloadData(_imageUrl);
        //                using (MemoryStream ms = new MemoryStream(imageBytes))
        //                {
        //                    pictureBox1.Image = Image.FromStream(ms);
        //                }
        //            }
        //        }
        //        catch (Exception ex)
        //        {
        //            MessageBox.Show("Error loading image: " + ex.Message);
        //            pictureBox1.Image = null; // Đặt hình ảnh mặc định nếu cần
        //        }
        //    }
        //}
        private string _imageUrl;
        public string ImageUrl
        {
            get => _imageUrl;
            set
            {
                _imageUrl = value;
                LoadImageAsync(_imageUrl);
            }
        }

        public object MaSP { get; internal set; }

        private async void LoadImageAsync(string imageUrl)
        {
            try
            {
                using (HttpClient client = new HttpClient())
                {
                    byte[] imageBytes = await client.GetByteArrayAsync(imageUrl);
                    using (MemoryStream ms = new MemoryStream(imageBytes))
                    {
                        pictureBox1.Image = Image.FromStream(ms);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading image: " + ex.Message);
                pictureBox1.Image = null; // Đặt hình ảnh mặc định nếu cần
            }
        }
    }
}
