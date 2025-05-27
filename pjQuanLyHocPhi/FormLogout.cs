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
    public partial class FormLogout : Form
    {
        public FormLogout()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterParent;
        }

        private void btn_DangXuat_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Yes;
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
            this.Close();
        }
    }
}
