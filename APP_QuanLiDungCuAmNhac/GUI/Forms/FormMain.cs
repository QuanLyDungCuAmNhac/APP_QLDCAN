using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using APP_QuanLiDungCuAmNhac.UserControls;

namespace APP_QuanLiDungCuAmNhac.Forms
{
    public partial class FormMain : Form
    {
        int PanelWidth;
        bool isCollapsed;
        public FormMain()
        {
            InitializeComponent();
            timerTime.Start();
            PanelWidth = panelLeft.Width;
            isCollapsed = false;
            customizeDegign();
           
           
        }
        private void AddControlsToPanel(Control c)
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

        private void customizeDegign()
        {
            panelQLSP.Visible = false;
        }

        private void hideSubMenu()
        {
            if(panelQLSP.Visible == true)
            {
                panelQLSP.Visible = false;
            }
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
           
          
        }

        private void btnLoai_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnThuongHieu_Click(object sender, EventArgs e)
        {
           
           
        }

        private void btnKhachHang_Click(object sender, EventArgs e)
        {
            
        }

        private void btnKhoHang_Click(object sender, EventArgs e)
        {
         
        }

        private void btnThongKe_Click(object sender, EventArgs e)
        {
           
        }

        private void btnNhanVien_Click(object sender, EventArgs e)
        {
            
           
        }

        private void btnHeThong_Click(object sender, EventArgs e)
        {
            
       
        }

        private void btnQLSP_Click(object sender, EventArgs e)
        {
            showSubMenu(panelQLSP);
        }
    }
}
