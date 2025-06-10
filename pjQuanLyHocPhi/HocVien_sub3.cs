using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
{
    public partial class HocVien_sub3 : Form
    {
        public HocVien_sub3()
        {
            InitializeComponent();
        }

        private void HocVien_sub3_Load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
            DGW_HV.DataSource = dt;
        }

        private void DGW_HV_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW_HV.SelectedRows.Count > 0)
            {
                DataGridViewRow selectedRow = DGW_HV.Rows[e.RowIndex];
                txt_MaHV.Text = selectedRow.Cells[0].Value.ToString();
                string query = $"select TenLop " +
                    $"from HocVien hv join PhanLoaiLop pll on hv.KhoiLop = pll.KhoiLop join LopHoc lh on pll.MaPL = lh.MaPL where MaHV = '{txt_MaHV.Text}' and TrangThai = 0";
                DataTable sub_dt = DataProvider.LoadCSDL(query);
                cbb_TenLop.Items.Clear();
                foreach (DataRow row in sub_dt.Rows)
                {
                    cbb_TenLop.Items.Add(row["TenLop"].ToString());
                }
            }
        }
        private void AutoLoadTenLop()
        {
            string maHV = txt_MaHV.Text.Trim();

            if (string.IsNullOrWhiteSpace(maHV))
            {
                cbb_TenLop.Items.Clear();
                return;
            }

            string query = $"SELECT TenLop FROM HocVien hv " +
                           $"JOIN PhanLoaiLop pll ON hv.KhoiLop = pll.KhoiLop " +
                           $"JOIN LopHoc lh ON pll.MaPL = lh.MaPL " +
                           $"WHERE MaHV COLLATE Vietnamese_CI_AI LIKE '%{maHV}%' and TrangThai = 0";

            DataTable sub_dt = DataProvider.LoadCSDL(query);

            cbb_TenLop.Items.Clear();

            foreach (DataRow row in sub_dt.Rows)
            {
                cbb_TenLop.Items.Add(row["TenLop"].ToString());
            }
        }

        private void txt_MaHV_KeyDown(object sender, KeyEventArgs e)
        {
            AutoLoadTenLop();
        }

        private void txt_MaHV_Leave(object sender, EventArgs e)
        {
            AutoLoadTenLop();
        }

        private void btn_DSLop_Click(object sender, EventArgs e)
        {
            try
            {
                string query = $"exec DangKiLop '{txt_MaHV.Text}', N'{cbb_TenLop.SelectedItem}'";
                DataProvider.LoadCSDL(query);
                Them them = new Them();
                them.ShowDialog();
            }
            catch (SqlException sqlEx) 
            {
                MessageBox.Show("Bạn đã đăng kí lớp này rồi. Vui lòng chọn lớp khác!");
                return;
            }
        }
    }
}
