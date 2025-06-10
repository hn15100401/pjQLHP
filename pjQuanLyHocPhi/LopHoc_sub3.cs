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
    public partial class LopHoc_sub3 : Form
    {
        public LopHoc_sub3()
        {
            InitializeComponent();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            string query = $"exec Slc_DSHVtungLop '{txt_MaLop.Text}'";
            DataTable dt = DataProvider.LoadCSDL(query);
            DGW_HT.DataSource = dt;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            txt_MaLop.Text = "Tất cả";
            string query = $"exec Slc_DSHVtheoLop";
            DataTable dt = DataProvider.LoadCSDL(query);
            DGW_HT.DataSource = dt;
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            DGW_HT.DataSource = null;
            txt_MaLop.Text = String.Empty;
        }

        private void LopHoc_sub3_Load(object sender, EventArgs e)
        {
            string query = $"exec Slc_LopHoc";
            DataTable dt = DataProvider.LoadCSDL(query);
            DGW_LH.DataSource = dt;
        }

        private void DGW_LH_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGW_LH.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DGW_LH.Rows[e.RowIndex];
                    txt_MaLop.Text = selectedRow.Cells[0].Value.ToString();  // Cột 0: Mã học viên
                }
            }
            catch (Exception ex) { }
        }
    }
}
