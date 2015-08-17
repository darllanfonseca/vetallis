using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class LoginDAO
    {
        public Users getUsers(string userName)
        {
            Users user = new Users();

            string conn = ConfigurationManager.ConnectionStrings["ConnUser"].ToString();
            SqlConnection sqlConn = new SqlConnection();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"SELECT * FROM USERS WHERE USER_NAME = @USER_NAME"), sqlConn);

            cmd.Parameters.AddWithValue("@USER_NAME", userName);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                user.id = reader.GetValue(0).ToString();
                user.name = reader.GetValue(1).ToString();
                user.password = reader.GetValue(2).ToString();

                return user;

            }

            catch
            {
                return null;
            }

        }
    }
}