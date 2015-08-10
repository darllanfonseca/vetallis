
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace Vetallis.DAO
{
    public class RebateDAO
    {

        public string deletePartnerData(string year, string partnerId)
        {
            string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection sqlConn = new SqlConnection();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(
            @"DELETE FROM REBATE WHERE YEAR=@YEAR AND ID_PARTNER=@ID_PARTNER"), sqlConn);

            cmd.Parameters.AddWithValue("@YEAR", year);
            cmd.Parameters.AddWithValue("@ID_PARTNER", partnerId);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Partner Data specified has been removed sucessfully from the database.";
            }
            catch (Exception e)
            {
                return "error";
            }
            finally
            {
                sqlConn.Close();
            }
        }

        //TO DO
        public void insertSingleRebateData() { }

        //TO DO
        public void editSingleRebateData() { }

        //TO DO
        public void consultRebateData() { }

    }
}