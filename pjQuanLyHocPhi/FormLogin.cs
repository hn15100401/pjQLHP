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
    public partial class FormLogin : Form
    {
        public FormLogin()
        {
            InitializeComponent();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_Password.Text = string.Empty;
            txt_Username.Text = string.Empty;
            txt_Username.Focus();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btn_Login_Click(object sender, EventArgs e)
        {
            if(txt_Username.Text == "admin" && txt_Password.Text == "123456")
            {
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            else
            {
                txt_Password.Text = string.Empty ;
                txt_Username.Text = string.Empty ;
                txt_Username.Focus();
            }
        }
    }
}
