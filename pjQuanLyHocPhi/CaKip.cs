using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class CaKip : Form
    {
        public CaKip()
        {
            InitializeComponent();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            string date = DatePicker.Value.ToString("yyyy-MM-dd");
            string cakip = "";
            string query = "";
            if (cbb_TenCaKip.SelectedItem == null) MessageBox.Show("Vui lòng chọn ca kíp!");
            else
            {
                cakip = cbb_TenCaKip.SelectedItem.ToString();
                if (cakip != "Tất cả") query = $"exec CaKipSlc N'{cakip}', '{date}'";
                else query = $"exec CaKipSlcAll '{date}'";
                DataTable tb = DataProvider.LoadCSDL(query);
                DGW.DataSource = tb;
            }
        }
    }
}
