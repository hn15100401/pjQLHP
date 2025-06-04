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
    public partial class PhanLoaiLop : Form
    {
        PhanLoaiLop_sub1 sub1;
        PhanLoaiLop_sub2 sub2;
        public PhanLoaiLop()
        {
            InitializeComponent();
        }
        private void OpenFormInPanel(Form formCon)
        {
            panel2.Controls.Clear(); // Clear mấy form cũ trong panel (nếu có)
            formCon.TopLevel = false; // CỰC QUAN TRỌNG: form con không phải top-level
            formCon.FormBorderStyle = FormBorderStyle.None; // Bỏ viền xấu xí
            formCon.Dock = DockStyle.Fill; // Cho nó lấp đầy panel
            panel2.Controls.Add(formCon); // Nhét vô panel
            formCon.Show(); // Show it, baby!
        }
        private void btn_Thaotac_Click(object sender, EventArgs e)
        {
            btn_Thaotac.FillColor = Color.DarkSlateGray;
            btn_DSLop.FillColor = Color.SteelBlue;
            if (sub2 != null) sub2.Close();
            sub1 = new PhanLoaiLop_sub1();
            OpenFormInPanel(sub1);
        }

        private void PhanLoaiLop_Load(object sender, EventArgs e)
        {
            btn_Thaotac.FillColor = Color.DarkSlateGray;
            btn_DSLop.FillColor = Color.SteelBlue;
            if (sub2 != null) sub2.Close();
            sub1 = new PhanLoaiLop_sub1();
            OpenFormInPanel(sub1);
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            btn_DSLop.FillColor = Color.DarkSlateGray;
            btn_Thaotac.FillColor = Color.SteelBlue;
            if (sub1 != null) sub1.Close();
            sub2 = new PhanLoaiLop_sub2();
            OpenFormInPanel(sub2);
        }
    }
}
