using Guna.UI2.WinForms;
using System;
using System.Collections;
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
    public partial class HocVien_sub1 : Form
    {
        Them them;
        Them_Sai them_sai;
        Sua sua;
        Sua_Sai sua_sai;
        Xoa xoa;
        Xoa_Sai xoa_sai;
        public HocVien_sub1()
        {
            InitializeComponent();
            txt_MaHV.Enabled = false;
            cbb_KhoiLop.Font = new Font("Segoe UI", 9);
            cbb_KhoiLop.ItemHeight = 20;
            cbb_KhoiLop.Size = new Size(150, 32);
        }
        private void Form_load(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
            DGW_HV.DataSource = dt;
            foreach (var cb in new[] { cbb_Truong1, cbb_Truong2, cbb_Truong3, cbb_Truong4, cbb_Truong5 })
                cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
        }
        private void ComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            var comboBoxes = new[] { cbb_Truong1, cbb_Truong2, cbb_Truong3, cbb_Truong4, cbb_Truong5 };

            // Lấy hết các giá trị đang được chọn
            var selectedValues = comboBoxes
                .Where(cb => cb.SelectedItem != null)
                .Select(cb => cb.SelectedItem.ToString())
                .ToList();

            foreach (var cb in comboBoxes)
            {
                var current = cb.SelectedItem?.ToString();
                cb.SelectedIndexChanged -= ComboBox_SelectedIndexChanged;

                for (int i = 0; i < cb.Items.Count; i++)
                {
                    string item = cb.Items[i].ToString();
                    bool shouldShow = !selectedValues.Contains(item) || item == current;
                    cb.Items[i] = shouldShow ? item : ""; // Trick: đặt item "" để ẩn
                }

                cb.SelectedIndexChanged += ComboBox_SelectedIndexChanged;
            }
        }
        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
                if (DGW_HV.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DGW_HV.Rows[e.RowIndex];
                    txt_MaHV.Text = selectedRow.Cells[0].Value.ToString();  // Cột 0: Mã học viên
                    txt_HoTen.Text = selectedRow.Cells[1].Value.ToString(); // Cột 1: Tên học viên
                    txt_SDT.Text = selectedRow.Cells[2].Value.ToString();   // Cột 2: SĐT
                    txt_DiaChi.Text = selectedRow.Cells[3].Value.ToString(); // Cột 3: Quận/huyện
                    foreach(string item in cbb_KhoiLop.Items) {
                        if (item == selectedRow.Cells[4].Value.ToString())
                        {
                            cbb_KhoiLop.SelectedItem = item;
                            break;
                        }
                    }
                }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_MaHV.Text = String.Empty;
            txt_HoTen.Text= String.Empty;
            txt_SDT.Text = String.Empty;
            txt_DiaChi.Text= String.Empty;
            cbb_KhoiLop.SelectedItem = null;
            txt_HoTen.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            string execQuery = "";
            if (txt_HoTen.Text != "")
            {
                execQuery = $"exec ThemHV N'{txt_HoTen.Text}', '{txt_SDT.Text}', N'{txt_DiaChi.Text}', {cbb_KhoiLop.SelectedItem}";
                DataProvider.LoadCSDL(execQuery);
                DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
                DGW_HV.DataSource = dt;
                foreach (DataGridViewRow row in DGW_HV.Rows)
                {
                    if (row.Cells[1].Value?.ToString() == txt_HoTen.Text)
                    {
                        row.Selected = true;
                        DGW_HV.FirstDisplayedScrollingRowIndex = row.Index; // Scroll tới dòng đó
                        break;
                    }
                }
                them = new Them();
                them.ShowDialog();
            }
            else
            {
                them_sai = new Them_Sai();
                them_sai.ShowDialog();
            }
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            string execQuery = $"exec SuaHV '{txt_MaHV.Text}', N'{txt_HoTen.Text}', '{txt_SDT.Text}', N'{txt_DiaChi.Text}', {cbb_KhoiLop.SelectedItem}";
            DataProvider.LoadCSDL(execQuery);
            DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
            DGW_HV.DataSource = dt;
            foreach (DataGridViewRow row in DGW_HV.Rows)
            {
                if (row.Cells[0].Value?.ToString() == txt_MaHV.Text)
                {
                    row.Selected = true;
                    DGW_HV.FirstDisplayedScrollingRowIndex = row.Index; // Scroll tới dòng đó
                    break;
                }
            }
            btn_Clear_Click(sender, e);
            sua = new Sua();
            sua.ShowDialog();
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
            DGW_HV.DataSource = dt;
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            string execQuery = "";
            if (txt_MaHV.Text == null)
            {
                xoa_sai = new Xoa_Sai();
                xoa_sai.ShowDialog();
            }
            else
            {
                execQuery = $"exec XoaHV '{txt_MaHV.Text}'";
                DataProvider.LoadCSDL(execQuery);
                DataTable dt = DataProvider.LoadCSDL("exec Slc_HocVien");
                DGW_HV.DataSource = dt;
                btn_Clear_Click(sender, e);
                xoa = new Xoa();
                xoa.ShowDialog();
            }
        }
        private void btn_Search_Click(object sender, EventArgs e)
        {
            // B1: Khai báo Dictionary ánh xạ tên hiển thị => tên cột DB
            Dictionary<string, string> hocVien = new Dictionary<string, string>
            {
                { "Mã học viên", "MaHV" },
                { "Họ và tên", "TenHV" },
                { "Số điện thoại", "SDT" },
                { "Địa chỉ", "DiaChi" },
                {"Khối lớp", "KhoiLop" }
            };

            // B2: Kiểm tra tất cả TextBox có trống không
            if (string.IsNullOrWhiteSpace(txt_Truong1.Text) &&
                string.IsNullOrWhiteSpace(txt_Truong2.Text) &&
                string.IsNullOrWhiteSpace(txt_Truong3.Text) &&
                string.IsNullOrWhiteSpace(txt_Truong4.Text) &&
                string.IsNullOrWhiteSpace(txt_Truong5.Text))
            {
                MessageBox.Show("Vui lòng nhập ít nhất một thông tin để tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // B3: Danh sách chứa các điều kiện WHERE
            List<string> dieuKienList = new List<string>();

            // B4: Hàm xử lý điều kiện lọc
            void XuLyDieuKien(Guna.UI2.WinForms.Guna2ComboBox combo, Guna.UI2.WinForms.Guna2TextBox text)
            {
                if (combo.SelectedItem != null && !string.IsNullOrWhiteSpace(text.Text))
                {
                    string truong = combo.SelectedItem.ToString();
                    if (hocVien.ContainsKey(truong))
                    {
                        if (truong != "Khối lớp")
                        {
                            string cot = hocVien[truong];
                            string giaTri = text.Text.Trim();
                            dieuKienList.Add($"{cot} COLLATE Vietnamese_CI_AI LIKE N'%{giaTri}%'");
                        }
                        else
                        {
                            string cot = hocVien[truong];
                            if (int.TryParse(text.Text.Trim(), out int giaTri))
                            {
                                dieuKienList.Add($"{cot} = {giaTri}");
                            }
                            else
                            {
                                MessageBox.Show($"Giá trị '{text.Text}' của '{truong}' không hợp lệ!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }

                            dieuKienList.Add($"{cot} = {giaTri}");
                        }
                    }
                }
            }

            // B5: Gọi xử lý với từng cặp ComboBox + TextBox
            XuLyDieuKien(cbb_Truong1, txt_Truong1);
            XuLyDieuKien(cbb_Truong2, txt_Truong2);
            XuLyDieuKien(cbb_Truong3, txt_Truong3);
            XuLyDieuKien(cbb_Truong4, txt_Truong4);
            XuLyDieuKien(cbb_Truong5, txt_Truong5);

            // B6: Gộp các điều kiện
            string dieuKienWhere = string.Join(" AND ", dieuKienList);
            string query = "SELECT * FROM HocVien";
            if (dieuKienList.Count > 0)
            {
                query += " WHERE " + dieuKienWhere;
            }
            DataTable dt = DataProvider.LoadCSDL(query);
            DGW_HV.DataSource = dt;
        }

        private void btn_Loc_Click(object sender, EventArgs e)
        {
            int Khoi = int.Parse(cbb_LocKhoiLop.Text);
            string query = $"SELECT * FROM HocVien Where KhoiLop = {Khoi}";
            DataTable dt = DataProvider.LoadCSDL(query);
            DGW_HV.DataSource = dt;
        }
    }
}
