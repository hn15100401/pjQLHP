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
    public partial class LopHoc_sub1 : Form
    {
        public LopHoc_sub1()
        {
            InitializeComponent();
            cbb_MaMon.Font = new Font("Segoe UI", 9);
            cbb_MaMon.ItemHeight = 20;
            cbb_MaMon.Size = new Size(150, 30);
            cbb_KhoiLop.Font = new Font("Segoe UI", 9);
            cbb_KhoiLop.ItemHeight = 20;
            cbb_KhoiLop.Size = new Size(150, 30);
            cbb_PhanLoai.Font = new Font("Segoe UI", 9);
            cbb_PhanLoai.ItemHeight = 20;
            cbb_PhanLoai.Size = new Size(150, 30);
            cbb_TenGV.Font = new Font("Segoe UI", 9);
            cbb_TenGV.ItemHeight = 20;
            cbb_TenGV.Size = new Size(150, 30);
        }

        private void guna2ShadowPanel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
