using Guna.UI2.WinForms;
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
    public partial class TC_XemLS : Form
    {
        public TC_XemLS()
        {
            InitializeComponent();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void TC_XemLS_Load(object sender, EventArgs e)
        {
            LoadDanhSachLopDaTao();
        }

        private void LoadDanhSachLopDaTao()
        {
            string query = "EXEC sp_LayDanhSachLopDaDuocTaoDiemDanh";

            DataTable dt = DataProvider.LoadCSDL(query);
            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "Ten_Lop";
            guna2ComboBox1.ValueMember = "Ma_Lop";
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {
            TimKiemHocVien();
        }

        private void TimKiemHocVien()
        {
            if (guna2ComboBox1.SelectedValue == null) return;

            string maLop = guna2ComboBox1.SelectedValue.ToString();
            string tenHV = guna2TextBox1.Text.Trim();

            string query = $@"
        EXEC sp_TimKiemDiemDanhTheoTen 
            @Ma_Lop = '{maLop}', 
            @Ten_HV = N'{tenHV}'";

            DataTable dt = DataProvider.LoadCSDL(query);
            guna2DataGridView1.DataSource = dt;

            if (guna2DataGridView1.Columns.Contains("Trang_Thai_Diem_Danh"))
            {
                guna2DataGridView1.Columns["Trang_Thai_Diem_Danh"].HeaderText = "Có mặt";
            }
        }
    }
}
