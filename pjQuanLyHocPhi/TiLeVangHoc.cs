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
    public partial class TiLeVangHoc : Form
    {
        public TiLeVangHoc()
        {
            InitializeComponent();
            cbb_Thang.Font = new Font("Segoe UI", 9);
            cbb_Thang.ItemHeight = 20;
            cbb_Thang.Size = new Size(195, 25);
            cbb_Nam.Font = new Font("Segoe UI", 9);
            cbb_Nam.ItemHeight = 20;
            cbb_Nam.Size = new Size(195, 30);
        }

        private void TiLeVangHoc_Load(object sender, EventArgs e)
        {
            DataTable dtM = DataProvider.LoadCSDL("select distinct Month(NgayThangNam) from BuoiHocMoiLop");
            foreach (DataRow dr in dtM.Rows)
            {
                cbb_Thang.Items.Add(dr[0].ToString());
            }
            DataTable dtY = DataProvider.LoadCSDL("select distinct Year(NgayThangNam) from BuoiHocMoiLop");
            foreach (DataRow dr in dtY.Rows)
            {
                cbb_Nam.Items.Add(dr[0].ToString());
            }
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            if (cbb_Nam.SelectedItem != null && cbb_Thang.SelectedItem != null)
            {
                string query = $"exec TyLeVang {cbb_Thang.SelectedItem}, {cbb_Nam.SelectedItem}";
                DataTable dt = DataProvider.LoadCSDL(query);
                DGW.DataSource = dt;
                int tongVang = 0;
                double tongDiemDanh = 0;
                foreach (DataRow dr in dt.Rows)
                {
                    tongDiemDanh += double.Parse(dr[2].ToString());
                    tongVang += int.Parse(dr[3].ToString());

                }
                txt_TyLe.Text = (tongVang * 100 / tongDiemDanh).ToString("0.00");
            }
            else
            {
                if (cbb_Thang.SelectedItem == null && cbb_Nam.SelectedItem != null) MessageBox.Show($"Vui lòng chọn Tháng cần thống kê!");
                if (cbb_Thang.SelectedItem != null && cbb_Nam.SelectedItem == null) MessageBox.Show($"Vui lòng chọn Năm cần thống kê!");
                if (cbb_Thang.SelectedItem == null && cbb_Nam.SelectedItem == null) MessageBox.Show($"Vui lòng chọn Tháng và Năm cần thông kê!");
            }
        }
    }
}
