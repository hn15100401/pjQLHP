using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace pjQuanLyHocPhi
{
    internal class DataProvider
    {
        const string connString = @"Data Source=LAPTOP-7U5VOEJH\SQLEXPRESS;Initial Catalog=QLTHUHOCPHI;Integrated Security=True;";
        private static SqlConnection connection;

        public static void OpenConnection()
        {
            connection = new SqlConnection(connString);
            connection.Open();
        }
        public static void CloseConnection()
        {
            connection.Close();
        }

        public static DataTable LoadCSDL(string query)
        {
            DataTable dt = new DataTable();
            try
            {
                OpenConnection();
                SqlCommand command = new SqlCommand(query, connection);
                SqlDataAdapter da = new SqlDataAdapter(command);
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                CloseConnection();
            }
            return dt;
        }
    }
}
