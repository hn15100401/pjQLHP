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
    public partial class LopHoc_sub1 : Form
    {
        public LopHoc_sub1()
        {
            InitializeComponent();
            cbb_TenMon.Font = new Font("Segoe UI", 9);
            cbb_TenMon.ItemHeight = 20;
            cbb_TenMon.Size = new Size(195, 25);
            cbb_KhoiLop.Font = new Font("Segoe UI", 9);
            cbb_KhoiLop.ItemHeight = 20;
            cbb_KhoiLop.Size = new Size(195, 30);
            cbb_PhanLoai.Font = new Font("Segoe UI", 9);
            cbb_PhanLoai.ItemHeight = 20;
            cbb_PhanLoai.Size = new Size(195, 30);
            cbb_TenGV.Font = new Font("Segoe UI", 9);
            cbb_TenGV.ItemHeight = 20;
            cbb_TenGV.Size = new Size(195, 30);
            cbb_TrangThai.Font = new Font("Segoe UI", 9);
            cbb_TrangThai.ItemHeight= 20;
            cbb_TrangThai.Size = new Size(195, 25);

            cbb_LocTenMon.Font = new Font("Segoe UI", 9);
            cbb_LocTenMon.ItemHeight = 20;
            cbb_LocTenMon.Size = new Size(150, 25);
            cbb_LocTenCap.Font = new Font("Segoe UI", 9);
            cbb_LocTenCap.ItemHeight = 20;
            cbb_LocTenCap.Size = new Size(150, 30);
            cbb_LocTenPL.Font = new Font("Segoe UI", 9);
            cbb_LocTenPL.ItemHeight = 20;
            cbb_LocTenPL.Size = new Size(150, 30);
            cbb_LocTrangThai.Font = new Font("Segoe UI", 9);
            cbb_LocTrangThai.ItemHeight = 20;
            cbb_LocTrangThai.Size = new Size(150, 25);
            cbb_LocTenGV.Font = new Font("Segoe UI", 9);
            cbb_LocTenGV.ItemHeight = 20;
            cbb_LocTenGV.Size = new Size(150, 30);
        }

        private void LopHoc_sub1_Load(object sender, EventArgs e)
        {
            txt_MaLop.Enabled = false;
            cbb_TrangThai.Enabled = false;
            DataTable dt = DataProvider.LoadCSDL("exec Slc_LopHoc");
            DGW.DataSource = dt;
            DataTable dt1 = DataProvider.LoadCSDL("select TenMon from MonHoc");
            foreach(DataRow dr in dt1.Rows)
            {
                cbb_TenMon.Items.Add(dr["TenMon"].ToString());
                cbb_LocTenMon.Items.Add(dr["TenMon"].ToString());
            }
            dt1.Rows.Clear();
            dt1 = DataProvider.LoadCSDL("select TenCap from CapGiangDay");
            foreach (DataRow dr in dt1.Rows)
            {
                cbb_LocTenCap.Items.Add(dr["TenCap"].ToString());
            }
            dt1.Rows.Clear();
            dt1 = DataProvider.LoadCSDL("select TenPL from PhanLoaiLop");
            foreach (DataRow dr in dt1.Rows)
            {
                cbb_LocTenPL.Items.Add(dr["TenPL"].ToString());
            }
            dt1.Rows.Clear();
            dt1 = DataProvider.LoadCSDL("select TenGV from GiangVien");
            foreach (DataRow dr in dt1.Rows)
            {
                cbb_LocTenGV.Items.Add(dr["TenGV"].ToString());
            }
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            int khoi = int.Parse(cbb_KhoiLop.SelectedItem.ToString());
            string macap = "";
            if (khoi >= 1 && khoi <= 5) macap = "TH";
            else if (khoi >= 6 && khoi <= 9) macap = "THCS";
            else macap = "THPT";
            DataTable slMa = DataProvider.LoadCSDL($"select MaMon from MonHoc where TenMon = N'{cbb_TenMon.SelectedItem}'");
            string mamon = slMa.Rows[0]["MaMon"].ToString();
            DataTable slMaPL = DataProvider.LoadCSDL($"select MaPL from PhanLoaiLop where TenPL = N'{cbb_PhanLoai.SelectedItem}'");
            string mapl = slMaPL.Rows[0]["MaPL"].ToString();
            string query = $"select MaGV from GiangVien where MaCap = '{macap}' and MaMon = '{mamon}' and TenGV = N'{cbb_TenGV.SelectedItem}'";
            DataTable dt = DataProvider.LoadCSDL(query);
            string magv = dt.Rows[0]["MaGV"].ToString();
            string query1 = $"exec ThemLop N'{txt_TenLop.Text}', '{macap}', '{mamon}', '{mapl}', '{magv}'";
            DataProvider.LoadCSDL(query1);
            DataTable dt1 = DataProvider.LoadCSDL("exec Slc_LopHoc");
            DGW.DataSource = dt1 ;
            Them them = new Them();
            them.ShowDialog();
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_MaLop.Text = String.Empty;
            txt_MaLop.Enabled = false;
            cbb_TrangThai.SelectedItem = null;
            cbb_TrangThai.Enabled = false;
            txt_TenLop.Text = string.Empty;
            cbb_KhoiLop.SelectedItem = null;
            cbb_TenMon.SelectedItem = null;
            cbb_PhanLoai.SelectedItem = null;
            cbb_TenGV.SelectedItem = null;
            txt_TenLop.Focus();
        }

        private void cbb_KhoiLop_Leave(object sender, EventArgs e)
        {
            int khoi = int.Parse(cbb_KhoiLop.SelectedItem.ToString());
            string query = $"select TenPL from PhanLoaiLop where KhoiLop = {khoi}";
            DataTable dt1 = DataProvider.LoadCSDL(query);
            cbb_PhanLoai.Items.Clear();
            foreach (DataRow dr in dt1.Rows)
            {
                cbb_PhanLoai.Items.Add(dr["TenPL"].ToString());
            }
            DataTable slMa = DataProvider.LoadCSDL($"select MaMon from MonHoc where TenMon = N'{cbb_TenMon.SelectedItem}'");
            string mamon = slMa.Rows[0]["MaMon"].ToString();
            string macap = "";
            if (khoi >= 1 && khoi <= 5) macap = "TH";
            else if (khoi >= 6 && khoi <= 9) macap = "THCS";
            else macap = "THPT";
            string query2 = $"select TenGV from GiangVien where MaCap = '{macap}' and MaMon = '{mamon}'";
            DataTable dt2 = DataProvider.LoadCSDL(query2);
            cbb_TenGV.Items.Clear();
            foreach (DataRow dr in dt2.Rows)
            {
                cbb_TenGV.Items.Add(dr["TenGV"].ToString());
            }
        }

        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (DGW.SelectedRows.Count > 0)
            {
                cbb_TrangThai.Enabled = true;
                DataGridViewRow selectedRow = DGW.Rows[e.RowIndex];
                txt_MaLop.Text = selectedRow.Cells[0].Value.ToString();
                txt_TenLop.Text = selectedRow.Cells[1].Value.ToString();
                DataTable dt1 = DataProvider.LoadCSDL($"select TenMon from MonHoc where MaMon = '{selectedRow.Cells[4].Value.ToString()}'");
                string tenmon = dt1.Rows[0]["TenMon"].ToString();
                foreach (string item in cbb_TenMon.Items)
                {
                    if(item == tenmon) cbb_TenMon.SelectedItem = item;
                }
                string trangthai = selectedRow.Cells[2].Value.ToString();
                foreach (string item in cbb_TrangThai.Items)
                {
                    if (item == trangthai) cbb_TrangThai.SelectedItem = item;
                }
                dt1 = DataProvider.LoadCSDL($"select KhoiLop from PhanLoaiLop where MaPL = '{selectedRow.Cells[5].Value.ToString()}'");
                string khoi = dt1.Rows[0]["KhoiLop"].ToString();
                foreach (string item in cbb_KhoiLop.Items)
                {
                    if (item == khoi) cbb_KhoiLop.SelectedItem = item;
                }
                cbb_KhoiLop_Leave(sender, e);
                dt1.Rows.Clear();
                dt1 = DataProvider.LoadCSDL($"select TenPL from PhanLoaiLop where MaPL = '{selectedRow.Cells[5].Value.ToString()}'");
                string tenpl = dt1.Rows[0]["TenPL"].ToString();
                foreach (string item in cbb_PhanLoai.Items)
                {
                    if (item == tenpl) cbb_PhanLoai.SelectedItem = item;
                }
                dt1.Rows.Clear();
                dt1 = DataProvider.LoadCSDL($"select TenGV from GiangVien where MaGV = '{selectedRow.Cells[6].Value.ToString()}'");
                string tengv = dt1.Rows[0]["TenGV"].ToString();
                foreach (string item in cbb_TenGV.Items)
                {
                    if (item == tengv) cbb_TenGV.SelectedItem = item;
                }
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            int khoi = int.Parse(cbb_KhoiLop.SelectedItem.ToString());
            string macap = "";
            if (khoi >= 1 && khoi <= 5) macap = "TH";
            else if (khoi >= 6 && khoi <= 9) macap = "THCS";
            else macap = "THPT";
            DataTable slMa = DataProvider.LoadCSDL($"select MaMon from MonHoc where TenMon = N'{cbb_TenMon.SelectedItem}'");
            string mamon = slMa.Rows[0]["MaMon"].ToString();
            DataTable slMaPL = DataProvider.LoadCSDL($"select MaPL from PhanLoaiLop where TenPL = N'{cbb_PhanLoai.SelectedItem}'");
            string mapl = slMaPL.Rows[0]["MaPL"].ToString();
            string query = $"select MaGV from GiangVien where MaCap = '{macap}' and MaMon = '{mamon}' and TenGV = N'{cbb_TenGV.SelectedItem}'";
            DataTable dt = DataProvider.LoadCSDL(query);
            string magv = dt.Rows[0]["MaGV"].ToString();
            int trangthai = 0;
            if (cbb_TrangThai.SelectedItem.ToString() == "Đủ số lượng") trangthai = 1; 
            string query1 = $"exec SuaLopHoc '{txt_MaLop.Text}', N'{txt_TenLop.Text}', {trangthai}, '{macap}', '{mamon}', '{mapl}', '{magv}'";
            DataProvider.LoadCSDL(query1);
            DataTable dt1 = DataProvider.LoadCSDL("exec Slc_LopHoc");
            DGW.DataSource = dt1;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            DataProvider.LoadCSDL($"exec XoaLopHoc '{txt_MaLop.Text}'");
            DataTable dt = DataProvider.LoadCSDL("exec Slc_LopHoc");
            DGW.DataSource = dt;
            Xoa xoa = new Xoa();
            xoa.ShowDialog();
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            List<string> dkList = new List<string>();

            // Trạng thái
            if (cbb_LocTrangThai.SelectedItem != null)
            {
                string val = cbb_LocTrangThai.SelectedItem.ToString();
                int trangthai = val == "Còn trống" ? 0 : 1;
                dkList.Add($"TrangThai = {trangthai}");
            }

            // Môn học
            if (cbb_LocTenMon.SelectedItem != null)
            {
                string tenMon = cbb_LocTenMon.SelectedItem.ToString().Replace("'", "''");
                DataTable dtMon = DataProvider.LoadCSDL($"SELECT MaMon FROM MonHoc WHERE TenMon = N'{tenMon}'");
                if (dtMon.Rows.Count > 0)
                {
                    string maMon = dtMon.Rows[0]["MaMon"].ToString();
                    dkList.Add($"MaMon = '{maMon}'");
                }
            }

            // Cấp học
            if (cbb_LocTenCap.SelectedItem != null)
            {
                string tenCap = cbb_LocTenCap.SelectedItem.ToString().Replace("'", "''");
                string queryCap = $"SELECT MaCap FROM CapGiangDay WHERE TenCap = N'{tenCap}'";
                DataTable dtCap = DataProvider.LoadCSDL(queryCap);
                if (dtCap.Rows.Count > 0)
                {
                    string maCap = dtCap.Rows[0]["MaCap"].ToString();
                    dkList.Add($"MaCap = '{maCap}'");
                }
            }

            // Phân loại lớp
            if (cbb_LocTenPL.SelectedItem != null)
            {
                string tenpl = cbb_LocTenPL.SelectedItem.ToString().Replace("'", "''");
                DataTable dtPL = DataProvider.LoadCSDL($"SELECT MaPL FROM PhanLoaiLop WHERE TenPL = N'{tenpl}'");
                if (dtPL.Rows.Count > 0)
                {
                    string mapl = dtPL.Rows[0]["MaPL"].ToString();
                    dkList.Add($"MaPL = '{mapl}'");
                }
            }

            // Giảng viên
            if (cbb_LocTenGV.SelectedItem != null)
            {
                string tengv = cbb_LocTenGV.SelectedItem.ToString().Replace("'", "''");
                DataTable dtGV = DataProvider.LoadCSDL($"SELECT MaGV FROM GiangVien WHERE TenGV = N'{tengv}'");
                if (dtGV.Rows.Count > 0)
                {
                    string magv = dtGV.Rows[0]["MaGV"].ToString();
                    dkList.Add($"MaGV = '{magv}'");
                }
            }

            // Gộp query và đổ vào DataGridView
            string query = "SELECT * FROM LopHoc";
            if (dkList.Count > 0)
            {
                query += " WHERE " + string.Join(" AND ", dkList);
            }

            DataTable kq = DataProvider.LoadCSDL(query);
            DGW.DataSource = kq;

            // Optional: Hiển thị thông báo nếu không tìm thấy
            if (kq.Rows.Count == 0)
            {
                MessageBox.Show("Không tìm thấy lớp học nào phù hợp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
    }
}
