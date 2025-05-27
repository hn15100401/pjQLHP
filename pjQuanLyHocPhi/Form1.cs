using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
{
    public partial class Form1 : Form
    {
        private bool HeThongExpanded = false;
        private bool QuanLyExpanded = false;
        private bool ThongKeExpanded = false;
        TrangChuFW bt1;
        public bool LoggedOut { get; private set; } = false;
        public Form1()
        {
            InitializeComponent();
        }
        private void btn_QuanLy_Click(object sender, EventArgs e)
        {
            QuanLyTimer.Start();
        }

        private void QuanLyTimer_Tick(object sender, EventArgs e)
        {
            pn_HeThong.Height = 0;
            HeThongExpanded = false ;
            if (QuanLyExpanded)
            {
                panel1.Height -= 5;
                if (panel1.Height <= 70)
                {
                    pn_QuanLy.Height = 0;
                    panel1.Height = 70; // Chốt đúng size
                    QuanLyExpanded = false;
                    QuanLyTimer.Stop();
                }
            }
            else
            {
                panel1.Height += 5;
                if (panel1.Height >= 108)
                {
                    pn_QuanLy.Height = 58;
                    panel1.Height = 108; // Chốt đúng size
                    QuanLyExpanded = true;
                    QuanLyTimer.Stop();
                }
            }
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (bt1 == null)
            {
                bt1 = new TrangChuFW();
                bt1.MdiParent = this;
                bt1.Show();
                bt1.Dock = DockStyle.Fill;
            }
            else bt1.Activate();
        }
        private void btn_HeThong_Click(object sender, EventArgs e)
        {
            HeThongTimer.Start();
        }

        private void HeThongTimer_Tick(object sender, EventArgs e)
        {
            pn_QuanLy.Height = 0;
            QuanLyExpanded = false;
            if (HeThongExpanded)
            {
                panel1.Height -= 5;
                if (panel1.Height <= 70)
                {
                    pn_HeThong.Height = 0;
                    panel1.Height = 70; // Chốt đúng size
                    HeThongExpanded = false;
                    HeThongTimer.Stop();
                }
            }
            else
            {
                panel1.Height += 5;
                if (panel1.Height >= 108)
                {
                    pn_HeThong.Height = 58;
                    panel1.Height = 108; // Chốt đúng size
                    HeThongExpanded = true;
                    HeThongTimer.Stop();
                }
            }
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            FormLogout formLogout = new FormLogout();
            if (formLogout.ShowDialog() == DialogResult.Yes)
            {
                this.LoggedOut = true; // nhớ có biến này để chương trình quay lại login
                this.Close(); // Đóng FormMain → quay lại Login
            }
        }
    }
}
