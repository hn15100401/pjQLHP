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
    public partial class HocVien_sub2 : Form
    {
        public HocVien_sub2()
        {
            InitializeComponent();
        }

        private void HocVien_sub2_Load(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.LoadCSDL("exec Slc_HocVien");
            DGW_1.DataSource = tb;
        }
        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGW_1.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DGW_1.Rows[e.RowIndex];
                    txt_MaHV.Text = selectedRow.Cells[0].Value.ToString();  // Cột 0: Mã học viên
                }
            }
            catch (Exception ex) { }
        }
        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.LoadCSDL($"exec DSLoptungHV '{txt_MaHV.Text}'");
            DGW_2.DataSource = tb;
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            DataTable tb = DataProvider.LoadCSDL("exec DSLoptatcaHV");
            DGW_2.DataSource = tb;
            txt_MaHV.Text = "Tất cả";
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            HocVien_sub2_Load(sender, e);
            txt_MaHV.Text = String.Empty;
            DGW_2.DataSource = null;
        }
    }
}
