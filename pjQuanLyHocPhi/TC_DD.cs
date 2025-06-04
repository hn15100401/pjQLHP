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
    public partial class TC_DD : Form
    {
        private TrangChuFW tc;
        DataTable dt = new DataTable();

        public TC_DD()
        {
            InitializeComponent();
        }

        public TC_DD(TrangChuFW trangChu)
        {
            InitializeComponent();
            this.Load += new System.EventHandler(this.TC_DD_Load);
            this.tc = trangChu;
        }

        private void z_Paint(object sender, PaintEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick_1(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void TC_DD_Load(object sender, EventArgs e)
        {
            string query = "EXEC sp_LayDanhSachLop"; 
            DataTable dt = DataProvider.LoadCSDL(query);

            guna2ComboBox1.DataSource = dt;
            guna2ComboBox1.DisplayMember = "Ten_Lop";
            guna2ComboBox1.ValueMember = "Ma_Lop";
            LoadDanhSachLopDaTao();
        }

        private void guna2ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void EnableControls(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = true;
            }
        }
        private void UnEnableControls(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Enabled = false;
            }
        }
        private void ResetText(List<Control> controls)
        {
            foreach (Control control in controls)
            {
                control.Text = "";
            }
        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void TaoBang_btn_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox1.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn lớp để tạo bảng điểm danh.");
                return;
            }

            string maLop = guna2ComboBox1.SelectedValue.ToString();
            string ngay = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");

            string query = $"EXEC sp_TaoDiemDanhTuDong @Ma_Lop = '{maLop}', @Ngay = '{ngay}'";

            DataTable result = DataProvider.LoadCSDL(query);

            MessageBox.Show("Tạo bảng điểm danh thành công!");
            LoadDanhSachLopDaTao();
        }

        private void LoadDanhSachLopDaTao()
        {
            string query = "EXEC sp_LayDanhSachLopDaDuocTaoDiemDanh";

            DataTable dt = DataProvider.LoadCSDL(query);
            guna2ComboBox2.DataSource = dt;
            guna2ComboBox2.DisplayMember = "Ten_Lop";
            guna2ComboBox2.ValueMember = "Ma_Lop";
        }

        private void guna2ComboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox2.SelectedValue == null) return;

            string maLop = guna2ComboBox2.SelectedValue.ToString();
            string query = $"EXEC sp_LayDanhSachBuoiTheoLop @Ma_Lop = '{maLop}'";

            DataTable dt = DataProvider.LoadCSDL(query);
            guna2ComboBox3.DataSource = dt;
            guna2ComboBox3.DisplayMember = "Ma_Buoi";
            guna2ComboBox3.ValueMember = "Ma_Buoi";
        }

        private void guna2ComboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedValue == null || guna2ComboBox2.SelectedValue == null) return;
            
            string maBuoi = guna2ComboBox3.SelectedValue.ToString();
            string maLop = guna2ComboBox2.SelectedValue.ToString();

            string query = $"EXEC sp_LayDanhSachHocVienDiemDanh @Ma_Buoi = '{maBuoi}', @Ma_Lop = '{maLop}'";

            DataTable dt = DataProvider.LoadCSDL(query);
            guna2DataGridView1.DataSource = dt;

            if (guna2DataGridView1.Columns.Contains("Trang_Thai_Diem_Danh"))
            {
                guna2DataGridView1.Columns["Trang_Thai_Diem_Danh"].HeaderText = "Có mặt";
                guna2DataGridView1.Columns["Trang_Thai_Diem_Danh"].ReadOnly = false;

            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if (guna2ComboBox3.SelectedValue == null)
            {
                MessageBox.Show("Vui lòng chọn mã buổi để lưu điểm danh.");
                return;
            }

            string maBuoi = guna2ComboBox3.SelectedValue.ToString();

            foreach (DataGridViewRow row in guna2DataGridView1.Rows)
            {
                if (row.IsNewRow) continue;

                string maHV = row.Cells["Ma_HV"].Value.ToString();
                bool trangThai = Convert.ToBoolean(row.Cells["Trang_Thai_Diem_Danh"].Value.ToString());

                string query = $@"
                    EXEC sp_CapNhatDiemDanh 
                        @Ma_HV = '{maHV}', 
                        @Ma_Buoi = '{maBuoi}', 
                        @TrangThai = {(trangThai ? 1 : 0)}";

                DataProvider.LoadCSDL(query);
            }
            MessageBox.Show("Cập nhật trạng thái điểm danh thành công!");
        }
    }
}
