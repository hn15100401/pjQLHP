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
    public partial class HocVien_sub1 : Form
    {
        public HocVien_sub1()
        {
            InitializeComponent();
        }
        static SqlConnection conn;

        static void Connect()
        {
            string source = "server=LAPTOP-SSM21CL0;" + "uid=nlhn;pwd=hongnhung15102004;" + "database=QLTT";
            conn = new SqlConnection(source);
            conn.Open();
        }
        private void LoadData()
        {
            SqlCommand com = new SqlCommand("exec Slc_HocVien", conn);
            SqlDataAdapter d = new SqlDataAdapter(com);
            DataTable dt = new DataTable();
            d.Fill(dt);
            DGW_HV.DataSource = dt;
        }
        private void Form_load(object sender, EventArgs e)
        {
            Connect();
            LoadData();
        }
        private void DGW_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                if (DGW_HV.SelectedRows.Count > 0)
                {
                    DataGridViewRow selectedRow = DGW_HV.Rows[e.RowIndex];
                    txt_MaHV.Text = selectedRow.Cells[0].Value.ToString();  // Cột 0: Mã học viên
                    txt_HoTen.Text = selectedRow.Cells[1].Value.ToString(); // Cột 1: Tên học viên
                    txt_SDT.Text = selectedRow.Cells[2].Value.ToString();   // Cột 2: SĐT
                    txt_DiaChi.Text = selectedRow.Cells[3].Value.ToString(); // Cột 3: Quận/huyện
                    txt_MaHV.Enabled = false;
                }
            }
            catch (Exception ex){ }
        }

        private void btn_Clear_Click(object sender, EventArgs e)
        {
            txt_MaHV.Enabled = true;
            txt_MaHV.Text = String.Empty;
            txt_HoTen.Text= String.Empty;
            txt_SDT.Text = String.Empty;
            txt_DiaChi.Text= String.Empty;
            txt_MaHV.Focus();
        }

        private void btn_Them_Click(object sender, EventArgs e)
        {
            Connect();
            string execQuery = "";
            if (txt_MaHV.Text != "")
            {
                execQuery = $"exec ThemHV '{txt_MaHV.Text}', N'{txt_HoTen.Text}', '{txt_SDT.Text}', N'{txt_DiaChi.Text}'";
                SqlCommand inserQuery = new SqlCommand(execQuery, conn);
                inserQuery.ExecuteNonQuery();
                LoadData();
                foreach (DataGridViewRow row in DGW_HV.Rows)
                {
                    if (row.Cells[0].Value?.ToString() == txt_MaHV.Text)
                    {
                        row.Selected = true;
                        DGW_HV.FirstDisplayedScrollingRowIndex = row.Index; // Scroll tới dòng đó
                        break;
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng điền Mã Học viên!");
            }
            
        }

        private void btn_Sua_Click(object sender, EventArgs e)
        {
            Connect();
            string execQuery = "";
            execQuery = $"exec SuaHV '{txt_MaHV.Text}', N'{txt_HoTen.Text}', '{txt_SDT.Text}', N'{txt_DiaChi.Text}'";
            SqlCommand inserQuery = new SqlCommand(execQuery, conn);
            inserQuery.ExecuteNonQuery();
            LoadData();
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
        }

        private void btn_Reload_Click(object sender, EventArgs e)
        {
            Connect();
            LoadData();
        }

        private void btn_Xoa_Click(object sender, EventArgs e)
        {
            Connect();
            string execQuery = "";
            execQuery = $"exec XoaHV '{txt_MaHV.Text}'";
            SqlCommand inserQuery = new SqlCommand(execQuery, conn);
            inserQuery.ExecuteNonQuery();
            LoadData();
            btn_Clear_Click(sender, e);
        }
    }
}
