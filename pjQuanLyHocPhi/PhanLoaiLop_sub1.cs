using Guna.UI2.WinForms;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
{
    public partial class PhanLoaiLop_sub1 : Form
    {
        public PhanLoaiLop_sub1()
        {
            InitializeComponent();
            cbb_LocHocPhi.Font = new Font("Segoe UI", 9);
            cbb_LocHocPhi.ItemHeight = 20;
            cbb_LocHocPhi.Size = new Size(150, 32);
            cbb_LocKhoiLop.Font = new Font("Segoe UI", 9);
            cbb_LocKhoiLop.ItemHeight = 20;
            cbb_LocKhoiLop.Size = new Size(150, 32);
            cbb_KhoiLop.Font = new Font("Segoe UI", 9);
            cbb_KhoiLop.ItemHeight = 20;
            cbb_KhoiLop.Size = new Size(150, 39);
        }
    }
}
