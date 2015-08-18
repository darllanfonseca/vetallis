using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class GroupsDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        Groups group;

        public Groups getGroupById(string idGroup)
        {
            group = new Groups();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            //SELECT SQL, using the ID passed as an argument
            SqlCommand cmd = new SqlCommand(string.Format(
            @"SELECT * FROM GROUPS WHERE ID_GROUP=@ID_GROUP"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_GROUP", idGroup);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                //Sets the member's parameters using the reader..
                group.id = reader.GetValue(0).ToString();
                group.idMainMember = reader.GetValue(1).ToString();
                group.name = reader.GetValue(2).ToString();

                reader.Close();

            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }

            return group;
        }

        public string insertGroup(Groups group)
        {            
            return "Success";
        }
    }
}