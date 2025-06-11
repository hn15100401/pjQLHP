using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.Expando;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
{
    public partial class Form1 : Form
    {
        Form currentChildForm = null;
        private bool HeThongExpanded = false;
        private bool QuanLyExpanded = false;
        private bool ThongKeExpanded = false;
        NhanVien nv;
        HocVien hv;
        CapGiangDay cgd;
        MonHoc mh;
        PhanLoaiLop pll;
        GiangVien gv;
        LopHoc lh;
        BuoiHocMoiLop bh;
        CaKip ck;
        TrangChuFW tc;
        TaoTaiKhoan ttk;
        DoiMK dmk;
        HocPhiTheoThang hptt;
        TiLeVangHoc tlvh;
        public bool LoggedOut { get; private set; } = false;
        public Form1()
        {
            InitializeComponent();
            this.MouseDown += Form1_MouseDown;
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            tc = new TrangChuFW();
            currentChildForm = tc;
            tc.MdiParent = this;
            tc.Show();
            tc.Dock = DockStyle.Fill;
        }
        [DllImport("user32.dll")]
        public static extern int SendMessage(IntPtr hWnd, int Msg, int wParam, int lParam);

        [DllImport("user32.dll")]
        public static extern bool ReleaseCapture();

        public const int WM_NCLBUTTONDOWN = 0xA1;
        public const int HTCAPTION = 0x2;

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                ReleaseCapture();
                SendMessage(this.Handle, WM_NCLBUTTONDOWN, HTCAPTION, 0);
            }
        }
        private void btn_QuanLy_Click(object sender, EventArgs e)
        {
            QuanLyTimer.Start();
        }

        private void QuanLyTimer_Tick(object sender, EventArgs e)
        {
            pn_HeThong.Height = 0;
            pn_ThongKe.Height = 0;
            HeThongExpanded = false;
            ThongKeExpanded = false;
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
        private void btn_HeThong_Click(object sender, EventArgs e)
        {
            HeThongTimer.Start();
        }

        private void HeThongTimer_Tick(object sender, EventArgs e)
        {
            pn_QuanLy.Height = 0;
            pn_ThongKe.Height= 0;
            QuanLyExpanded = false;
            ThongKeExpanded= false;
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
        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            lh = new LopHoc();
            currentChildForm = lh;
            lh.MdiParent = this;
            lh.Show();
            lh.Dock = DockStyle.Fill;
        }
        private void guna2Button6_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            nv = new NhanVien();
            currentChildForm = nv;
            nv.MdiParent = this;
            nv.Show();
            nv.Dock = DockStyle.Fill;
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            hv = new HocVien();
            currentChildForm = hv;
            hv.MdiParent = this;
            hv.Show();
            hv.Dock = DockStyle.Fill;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender,e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            cgd = new CapGiangDay();
            currentChildForm = cgd;
            cgd.MdiParent = this;
            cgd.Show();
            cgd.Dock = DockStyle.Fill;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            mh = new MonHoc();
            currentChildForm = cgd;
            mh.MdiParent = this;
            mh.Show();
            mh.Dock = DockStyle.Fill;
        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            pll = new PhanLoaiLop();
            currentChildForm = pll;
            pll.MdiParent = this;
            pll.Show();
            pll.Dock = DockStyle.Fill;
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            gv = new GiangVien();
            currentChildForm = gv;
            gv.MdiParent = this;
            gv.Show();
            gv.Dock = DockStyle.Fill;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            bh = new BuoiHocMoiLop();
            currentChildForm = bh;
            bh.MdiParent = this;
            bh.Show();
            bh.Dock = DockStyle.Fill;
        }

        private void guna2Button11_Click(object sender, EventArgs e)
        {
            this.btn_QuanLy_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            ck = new CaKip();
            currentChildForm = ck;
            ck.MdiParent = this;
            ck.Show();
            ck.Dock = DockStyle.Fill;
        }

        private void btn_TrangChu_Click(object sender, EventArgs e)
        {
            this.btn_HeThong_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            tc = new TrangChuFW();
            currentChildForm = tc;
            tc.MdiParent = this;
            tc.Show();
            tc.Dock = DockStyle.Fill;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.btn_HeThong_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            ttk = new TaoTaiKhoan();
            currentChildForm = ttk;
            ttk.MdiParent = this;
            ttk.Show();
            ttk.Dock = DockStyle.Fill;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.btn_HeThong_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            dmk = new DoiMK();
            currentChildForm = dmk;
            dmk.MdiParent = this;
            dmk.Show();
            dmk.Dock = DockStyle.Fill;
        }

        private void ThongKeTimer_Tick(object sender, EventArgs e)
        {
            pn_QuanLy.Height = 0;
            pn_HeThong.Height = 0;
            QuanLyExpanded = false;
            HeThongExpanded = false;
            if (ThongKeExpanded)
            {
                panel1.Height -= 5;
                if (panel1.Height <= 70)
                {
                    pn_ThongKe.Height = 0;
                    panel1.Height = 70; // Chốt đúng size
                    ThongKeExpanded = false;
                    ThongKeTimer.Stop();
                }
            }
            else
            {
                panel1.Height += 5;
                if (panel1.Height >= 108)
                {
                    pn_ThongKe.Height = 58;
                    panel1.Height = 108; // Chốt đúng size
                    ThongKeExpanded = true;
                    ThongKeTimer.Stop();
                }
            }
        }

        private void btn_ThongKe_Click(object sender, EventArgs e)
        {
            ThongKeTimer.Start();
        }

        private void guna2Button12_Click(object sender, EventArgs e)
        {
            this.btn_ThongKe_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            hptt = new HocPhiTheoThang();
            currentChildForm = hptt;
            hptt.MdiParent = this;
            hptt.Show();
            hptt.Dock = DockStyle.Fill;
        }

        private void guna2Button13_Click(object sender, EventArgs e)
        {
            this.btn_ThongKe_Click(sender, e);
            if (currentChildForm != null && !currentChildForm.IsDisposed)
            {
                currentChildForm.Close();
            }
            tlvh = new TiLeVangHoc();
            currentChildForm = tlvh;
            tlvh.MdiParent = this;
            tlvh.Show();
            tlvh.Dock = DockStyle.Fill;
        }
    }
}
