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
    public partial class LopHoc : Form
    {
        LopHoc_sub1 sub1;
        LopHoc_sub3 sub3;
        public LopHoc()
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
        private void LopHoc_Load(object sender, EventArgs e)
        {
            sub1 = new LopHoc_sub1();
            OpenFormInPanel(sub1);
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            if (sub1 != null) sub1.Close();
            sub3 = new LopHoc_sub3();
            OpenFormInPanel(sub3);
        }

        private void btn_Thaotac_Click(object sender, EventArgs e)
        {
            if (sub3 != null) sub3.Close();
            sub1 = new LopHoc_sub1();
            OpenFormInPanel(sub1);
        }
    }
}
