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
    public partial class CapGiangDay : Form
    {
        public CapGiangDay()
        {
            InitializeComponent();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            string maCap = "";
            string query = "";
            if (cbb_CapGD.SelectedItem != null)
            {
                maCap = cbb_CapGD.SelectedItem.ToString();
                if (maCap == "Tất cả") query = $"exec DSTCLop_CGD";
                else query = $"exec DSLop_CGD N'{maCap}'";
                DataTable tb = DataProvider.LoadCSDL(query);
                DGW.DataSource = tb;
            }
            else MessageBox.Show("Vui lòng chọn Cấp giảng dạy!");
        }

        private void btn_DSGiangvien_Click(object sender, EventArgs e)
        {
            string maCap = "";
            string query = "";
            if (cbb_CapGD.SelectedItem != null)
            {
                maCap = cbb_CapGD.SelectedItem.ToString();
                if (maCap == "Tất cả") query = $"exec DSTCGV_CGD";
                else query = $"exec DSGV_CGD N'{maCap}'";
                DataTable tb = DataProvider.LoadCSDL(query);
                DGW.DataSource = tb;
            }
            else MessageBox.Show("Vui lòng chọn Cấp giảng dạy!");
        }

        private void CapGiangDay_Load(object sender, EventArgs e)
        {
            string query = "select TenCap from CapGiangDay";
            DataTable dt = DataProvider.LoadCSDL(query);
            foreach (DataRow dr in dt.Rows) 
            {
                cbb_CapGD.Items.Add(dr["TenCap"].ToString());
            }
            cbb_CapGD.Items.Add("Tất cả");
        }
    }
}
