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
                    users[i].status = row[3].ToString();

                    i++;
                }

                return users;
            }

            catch
            {
                return null;
            }

        }

        public void registerLogin(string userName, string ip)
        {
            int loginTimes = 0;

            string conn = ConfigurationManager.ConnectionStrings["ConnUser"].ToString();
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;

            SqlCommand cmd1 = new SqlCommand("SELECT LOGIN_TIMES FROM USERS WHERE USER_NAME=@USER_NAME", sqlConn);
            cmd1.Parameters.AddWithValue("@USER_NAME", userName);

            try
            {
                sqlConn.Open();
                SqlDataReader reader = cmd1.ExecuteReader();
                reader.Read();
                loginTimes = System.Int32.Parse(reader.GetValue(0).ToString());

            }
            finally
            {
                sqlConn.Close();
            }

            SqlCommand cmd2 = new SqlCommand("UPDATE USERS SET DATE_LAST_LOGIN=@TODAY, LOCATION_LAST_LOGIN=@LOCATION, LOGIN_TIMES=@LOGIN_TIMES WHERE USER_NAME=@USER_NAME", sqlConn);

            cmd2.Parameters.AddWithValue("@TODAY", System.DateTime.Today);
            cmd2.Parameters.AddWithValue("@LOCATION", ip);
            cmd2.Parameters.AddWithValue("@LOGIN_TIMES", loginTimes+1);
            cmd2.Parameters.AddWithValue("@USER_NAME", userName);

            try
            {
                sqlConn.Open();
                cmd2.ExecuteNonQuery();
            }
            finally
            {
                sqlConn.Close();
            }

        }
    }
}