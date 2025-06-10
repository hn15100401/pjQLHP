using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.UI.WebControls;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace pjQuanLyHocPhi
{
    public partial class MonHoc : Form
    {
        public MonHoc()
        {
            InitializeComponent();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            string tenMon = "";
            string query = "";
            if (cbb_MonHoc.SelectedItem != null)
            {
                tenMon = cbb_MonHoc.SelectedItem.ToString();
                if (tenMon == "Tất cả") query = $"exec DSTCLop_MH";
                else query = $"exec DSLop_MH N'{tenMon}'";
                DataTable tb = DataProvider.LoadCSDL(query);
                DGW.DataSource = tb;
            }
            else MessageBox.Show("Vui lòng chọn Môn học!");
        }
        private void btn_DSGiangvien_Click(object sender, EventArgs e)
        {
            string tenMon = "";
            string query = "";
            if (cbb_MonHoc.SelectedItem != null)
            {
                tenMon = cbb_MonHoc.SelectedItem.ToString();
                if (tenMon == "Tất cả") query = $"exec DSTCGV_MH";
                else query = $"exec DSGV_MH N'{tenMon}'";
                DataTable tb = DataProvider.LoadCSDL(query);
                DGW.DataSource = tb;
            }
            else MessageBox.Show("Vui lòng chọn Môn học!");
        }

        private void MonHoc_Load(object sender, EventArgs e)
        {
            string query = "select TenMon from MonHoc";
            DataTable dt = DataProvider.LoadCSDL(query);
            foreach (DataRow dr in dt.Rows)
            {
                cbb_MonHoc.Items.Add(dr["TenMon"].ToString());
            }
            cbb_MonHoc.Items.Add("Tất cả");
        }
    }
}
