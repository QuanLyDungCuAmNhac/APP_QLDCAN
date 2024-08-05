using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_QuanLiDungCuAmNhac.UserControls;
using DTO;
using BLL;

namespace APP_QuanLiDungCuAmNhac.Forms
{
    public partial class FormMain : Form
    {
        string getUser = "";
        BLLPhanQuyen PhanQuyenBLL = new BLLPhanQuyen();
        BLLNND NNDBLL = new BLLNND();
        BLLND_NDD DN_NNDBLL = new BLLND_NDD();
        BLLNhanVien NhanVienBLL = new BLLNhanVien();
        public string LoggedInMaNhomNguoiDung { get; set; }
        int PanelWidth;
        bool isCollapsed;
        public FormMain(string MaNhom,string UserName)
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            label5.Text = NhanVienBLL.GetName(UserName);
            label7.Text = NNDBLL.getTenNhom(MaNhom);
            getUser = MaNhom;
             UC_BanHang uch = new UC_BanHang();
            AddControlsToPanel(uch);
            this.Load += FormMain_Load;
           
        }

       

        private void FormMain_Load(object sender, EventArgs e)
        {
            // Debugging: List all controls' tags
            LoggedInMaNhomNguoiDung = LoginAndGetMaNhomNguoiDung();

            // Sau khi đăng nhập thành công, cập nhật giao diện dựa trên quyền hạn
            UpdateUIBasedOnPermissions();


        }
        private string LoginAndGetMaNhomNguoiDung()
        {
            // Thực hiện đăng nhập và trả về mã nhóm người dùng
            //return label7.Text.ToString(); // Ví dụ
            return getUser;
        }

        private void UpdateUIBasedOnPermissions()
        {
            foreach (Control control in this.Controls)
            {
                EnableButtonBasedOnTag(control, LoggedInMaNhomNguoiDung);
            }
        }

        public void EnableButtonBasedOnTag(Control control, string maNhom)
        {
            if (control is Button btn && btn.Tag != null)
            {
                string maManHinh = btn.Tag.ToString();
                bool coQuyen = PhanQuyenBLL.CheckPermission(maNhom, maManHinh);
                btn.Enabled = coQuyen;
            }

            foreach (Control childControl in control.Controls)
            {
                EnableButtonBasedOnTag(childControl, maNhom);
            }
        }

        public void AddControlsToPanel(Control c)
        {
            c.Dock = DockStyle.Fill;
            panelControls.Controls.Clear();
            panelControls.Controls.Add(c);
        }

        

        private void button9_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void timerTime_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            labelTime.Text = dt.ToString("HH:MM:ss");
        }

        private void button8_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

       

        private void button9_Click_1(object sender, EventArgs e)
        {
            this.Close();
        }

        private void showSubMenu(Panel subMenu)
        {
            if (subMenu.Visible == false)
            {
                subMenu.Visible = true;
            }
            else
                subMenu.Visible=false;
        }
        private void btnBanHang_Click(object sender, EventArgs e)
        {
           
            UC_BanHang uch = new UC_BanHang();
            AddControlsToPanel(uch);
        }

        

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (isCollapsed)
            {
                panelLeft.Width = panelLeft.Width + 10;
                if (panelLeft.Width >= PanelWidth)
                {
                    timer1.Stop();
                    isCollapsed = false;
                    this.Refresh();
                }
            }
            else
            {
                panelLeft.Width = panelLeft.Width - 10;
                if (panelLeft.Width <= 59)
                {
                    timer1.Stop();
                    isCollapsed = true;
                    this.Refresh();
                }
            }
        }

        private void btnSanPham_Click(object sender, EventArgs e)
        {
           
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
           
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
            
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            
            UC_Home uch = new UC_Home();
            AddControlsToPanel(uch);
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            UC_QLSP uC_QLSP = new UC_QLSP(this);
            AddControlsToPanel(uC_QLSP);
        }

        private void btnDQDN_Click(object sender, EventArgs e)
        {
            UC_QLDN uch = new UC_QLDN(this);
            AddControlsToPanel(uch);
        }

        private void btn_QLKho_Click(object sender, EventArgs e)
        {
            UC_QLKho uch = new UC_QLKho(this);
            AddControlsToPanel(uch);
        }

        private void btnThongKe_Click_1(object sender, EventArgs e)
        {
            UC_ThongKe uch = new UC_ThongKe(this);
            AddControlsToPanel(uch);
        }
    }
}
