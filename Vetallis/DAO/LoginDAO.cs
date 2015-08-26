using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class LoginDAO
    {
        public List<Users> getAllUsers()
        {
            List<Users> users = new List<Users>();

            string conn = ConfigurationManager.ConnectionStrings["ConnUser"].ToString();
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();
            SqlCommand cmd = new SqlCommand("SELECT * FROM USERS", sqlConn);
            
            try
            {
                sqlConn.Open();
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);

                DataRow[] currentRows = dt.Select(null, null, DataViewRowState.CurrentRows);

                int i = 0;
                foreach (DataRow row in currentRows)
                {
                    Users user = new Users();
                    users.Add(user);

                    users[i].id = row[0].ToString();
                    users[i].name = row[1].ToString();
                    users[i].password = row[2].ToString();

                    i++;
                }

                return users;
            }

            catch
            {
                return null;
            }

        }
    }
}