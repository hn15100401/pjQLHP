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
    public partial class TrangChuFW : Form
    {
        DataTable dt = new DataTable();
        
        public TrangChuFW()
        {
            InitializeComponent();
        }

        private void ShowFormInPanel(Form form)
        {
            guna2Panel3.Controls.Clear(); // Xóa giao diện cũ
            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            guna2Panel3.Controls.Add(form);
            form.Show();
        }

        private void TrangChuFW_Load(object sender, EventArgs e)
        {
            ShowFormInPanel(new TC_DD(this));
        }



        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void EnableControls(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = true;
            }
        }
        private void UnEnableControls(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }

        private void DSLopTao_gunabtn_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new TC_DD());
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new TC_XemLS());
        }

        private void guna2Panel4_Paint(object sender, PaintEventArgs e)
        {

        }

        private void ThuHocPhi_Click(object sender, EventArgs e)
        {
            ShowFormInPanel(new TC_XemLS());
        }
    }
}
