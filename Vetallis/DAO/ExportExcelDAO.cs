using System.Data;
using System.Configuration;
using System.Data.SqlClient;

namespace Vetallis.DAO
{
    public class ExportExcelDAO
    {
        public static DataTable getDataTable (string query){
             string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
             SqlConnection sqlConn = new SqlConnection();

             sqlConn.ConnectionString = conn;
             DataTable dt = new DataTable();
             dt.Clear();

             SqlCommand cmd = new SqlCommand(query, sqlConn);

             sqlConn.Open();

             using (SqlDataAdapter a = new SqlDataAdapter(cmd))
             {
                 a.Fill(dt);
             }

             sqlConn.Close();

             return dt;
        }
    }
}