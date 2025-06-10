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
    public partial class BuoiHocMoiLop : Form
    {
        public BuoiHocMoiLop()
        {
            InitializeComponent();
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            if (txt_MaBuoi.Text != "")
            {
                string ngay = guna2DateTimePicker1.Value.ToString("yyyy-MM-dd");
                DataTable slMaLop = DataProvider.LoadCSDL($"select MaLop from LopHoc where TenLop = N'{txt_TenLop.Text}'");
                string malop = slMaLop.Rows[0]["MaLop"].ToString();
                DataTable slMaNV = DataProvider.LoadCSDL($"select MaNV from NhanVien where TenNV = N'{cbb_TenNV.SelectedItem}'");
                string manv = slMaNV.Rows[0]["MaNV"].ToString();
                DataTable slMaCaKip = DataProvider.LoadCSDL($"select MaCaKip from CaKip where TenCaKip = N'{cbb_TenCaKip.SelectedItem}'");
                string mack = slMaCaKip.Rows[0]["MaCaKip"].ToString();
                DataProvider.LoadCSDL($"exec SuaBH '{txt_MaBuoi.Text}', '{ngay}', '{malop}', '{manv}', '{mack}'");
                DataTable dt = DataProvider.LoadCSDL("exec SLc_BuoiHocMoiLop");
                DGW.DataSource = dt;
                foreach (DataGridViewRow row in DGW.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == txt_MaBuoi.Text)
                    {
                        row.Selected = true;
                        DGW.FirstDisplayedScrollingRowIndex = row.Index; // Scroll tới dòng đó
                        break;
                    }
                }
                Sua sua = new Sua();
                sua.ShowDialog();
            }
            else
            {
                Sua_Sai sua_Sai = new Sua_Sai();
                sua_Sai.ShowDialog();
            }
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            if (txt_MaBuoi.Text != "")
            {
                DataProvider.LoadCSDL($"exec XoaBH '{txt_MaBuoi.Text}'");
                DataTable dt = DataProvider.LoadCSDL("exec SLc_BuoiHocMoiLop");
                DGW.DataSource = dt;
                Xoa xoa = new Xoa();
                xoa.ShowDialog();
            }
            else
            {
                Xoa_Sai xoa_Sai = new Xoa_Sai();
                xoa_Sai.ShowDialog();
            }
        }

        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            DataGridViewRow selectedRow = DGW.Rows[e.RowIndex];
            txt_MaBuoi.Text = selectedRow.Cells[0].Value.ToString();
            txt_TenLop.Text = selectedRow.Cells[3].Value.ToString();
            DataTable dt1 = DataProvider.LoadCSDL($"select TenNV from NhanVien where MaNV = '{selectedRow.Cells[4].Value.ToString()}'");
            string tennv = dt1.Rows[0]["TenNV"].ToString();
            foreach (string item in cbb_TenNV.Items)
            {
                if (item == tennv) cbb_TenNV.SelectedItem = item;
            }
            dt1.Rows.Clear();
            dt1 = DataProvider.LoadCSDL($"select TenCaKip from CaKip where MaCaKip = '{selectedRow.Cells[5].Value.ToString()}'");
            string tenck = dt1.Rows[0]["TenCaKip"].ToString();
            foreach (string item in cbb_TenCaKip.Items)
            {
                if (item == tenck) cbb_TenCaKip.SelectedItem = item;
            }
            guna2DateTimePicker1.Value = DateTime.Parse(selectedRow.Cells[1].Value.ToString());
        }

        private void BuoiHocMoiLop_Load(object sender, EventArgs e)
        {
            string query = $"exec Slc_BuoiHocMoiLop";
            DataTable dt1 = DataProvider.LoadCSDL(query);
            DGW.DataSource = dt1;
            DataTable dt = DataProvider.LoadCSDL("select TenNV from NhanVien");
            foreach (DataRow dr in dt.Rows)
            {
                cbb_TenNV.Items.Add(dr["TenNV"].ToString());
                cbb_LocTenNV.Items.Add(dr["TenNV"].ToString());
            }
            dt.Rows.Clear();
            dt = DataProvider.LoadCSDL("select TenCaKip from CaKip");
            foreach (DataRow dr in dt.Rows)
            {
                cbb_TenCaKip.Items.Add(dr["TenCaKip"].ToString());
                cbb_LocCaKip.Items.Add(dr["TenCaKip"].ToString());
            }
            dt.Rows.Clear();
            dt = DataProvider.LoadCSDL("select TenLop from LopHoc");
            foreach (DataRow dr in dt.Rows)
            {
                cbb_LocTenLop.Items.Add(dr["TenLop"].ToString());
            }
            txt_MaBuoi.Enabled = false;
            txt_TenLop.Enabled = false;
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            
            string query = $"select MaBuoi [Mã Buổi], NgayThangNam [Ngày/Tháng/Năm], bh.MaLop [Mã Lớp], TenLop [Tên Lớp], MaNV [Mã NV], MaCaKip [Mã Ca Kíp] from BuoiHocMoiLop bh join LopHoc lh on bh.MaLop = lh.MaLop where MaBuoi COLLATE Vietnamese_CI_AI LIKE N'%{txt_TimMaBuoi.Text}%'";
            DataTable kq = DataProvider.LoadCSDL(query);
            DGW.DataSource = kq;
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            List<string> dkList = new List<string>();

            // Mã Lớp
            if (cbb_LocTenLop.SelectedItem != null)
            {
                string tenLop = cbb_LocTenLop.SelectedItem.ToString();
                DataTable dtNV = DataProvider.LoadCSDL($"SELECT MaLop FROM LopHoc WHERE TenLop = N'{tenLop}'");
                if (dtNV.Rows.Count > 0)
                {
                    string maLop = dtNV.Rows[0]["MaLop"].ToString();
                    dkList.Add($"lh.MaLop = '{maLop}'");
                }
            }

            // Ngày Tháng Năm
            if (guna2DateTimePicker2.Checked)
            {
                string selectedDate = guna2DateTimePicker2.Value.ToString("yyyy-MM-dd");
                dkList.Add($"NgayThangNam = '{selectedDate}'");
            }

            // Tên Nhân viên
            if (cbb_LocTenNV.SelectedItem != null)
            {
                string tenNV = cbb_LocTenNV.SelectedItem.ToString();
                DataTable dtNV = DataProvider.LoadCSDL($"SELECT MaNV FROM NhanVien WHERE TenNV = N'{tenNV}'");
                if (dtNV.Rows.Count > 0)
                {
                    string maNV = dtNV.Rows[0]["MaNV"].ToString();
                    dkList.Add($"MaNV = '{maNV}'");
                }
            }

            // Tên Ca kíp
            if (cbb_LocCaKip.SelectedItem != null)
            {
                string tenCa = cbb_LocCaKip.SelectedItem.ToString();
                DataTable dtCa = DataProvider.LoadCSDL($"SELECT MaCaKip FROM CaKip WHERE TenCaKip = N'{tenCa}'");
                if (dtCa.Rows.Count > 0)
                {
                    string maCa = dtCa.Rows[0]["MaCaKip"].ToString();
                    dkList.Add($"MaCaKip = '{maCa}'");
                }
            }

            // Gộp query
            string query = "select MaBuoi [Mã Buổi], NgayThangNam [Ngày/Tháng/Năm], bh.MaLop [Mã Lớp], TenLop [Tên Lớp], MaNV [Mã NV], MaCaKip [Mã Ca Kíp] from BuoiHocMoiLop bh join LopHoc lh on bh.MaLop = lh.MaLop";
            if (dkList.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", dkList);
            }

            DataTable kq = DataProvider.LoadCSDL(query);
            DGW.DataSource = kq;

            if (kq.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy dữ liệu phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            BuoiHocMoiLop_Load(sender, e);
            cbb_LocCaKip.SelectedItem = null;
            cbb_LocTenLop.SelectedItem = null;
            cbb_LocTenNV.SelectedItem = null;
            txt_MaBuoi.Text = string.Empty;
            txt_TimMaBuoi.Text = string.Empty;
            txt_TenLop.Text = string.Empty;
            cbb_TenCaKip.Text = string.Empty;
            cbb_TenNV.Text = string.Empty;
        }
    }
}
