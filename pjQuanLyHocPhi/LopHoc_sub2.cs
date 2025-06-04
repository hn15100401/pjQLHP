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
    public partial class LopHoc_sub2 : Form
    {
        public LopHoc_sub2()
        {
            InitializeComponent();
            cbb_MaMon.Font = new Font("Segoe UI", 9);
            cbb_MaMon.ItemHeight = 20;
            cbb_MaMon.Size = new Size(150, 32);
            cbb_MaCap.Font = new Font("Segoe UI", 9);
            cbb_MaCap.ItemHeight = 20;
            cbb_MaCap.Size = new Size(150, 32);
            cbb_MaPhanLoai.Font = new Font("Segoe UI", 9);
            cbb_MaPhanLoai.ItemHeight = 20;
            cbb_MaPhanLoai.Size = new Size(150, 32);
            cbb_MaGV.Font = new Font("Segoe UI", 9);
            cbb_MaGV.ItemHeight = 20;
            cbb_MaGV.Size = new Size(150, 32);
        }
    }
}
