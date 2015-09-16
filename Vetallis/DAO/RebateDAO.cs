
using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;
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

        public string insertSingleRebateData(Rebate rebate) {
            string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;

            SqlCommand cmd = new SqlCommand(string.Format(
            @"INSERT INTO REBATE (ID_MEMBER, ID_PARTNER, IS_DELiVERED_BY_PARTNER, QUANTITY, CATEGORY, YEAR, DATE_MODIFIED, MODIFIED_BY) 
            VALUES (@ID_MEMBER, @ID_PARTNER, @IS_DELiVERED_BY_PARTNER, @QUANTITY, @CATEGORY, @YEAR, @DATE_MODIFIED, @MODIFIED_BY)"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", rebate.idMember);
            cmd.Parameters.AddWithValue("@ID_PARTNER", rebate.idPartner);
            cmd.Parameters.AddWithValue("@IS_DELiVERED_BY_PARTNER", rebate.isDeliveredByPartner);
            cmd.Parameters.AddWithValue("@QUANTITY", rebate.quantity);
            cmd.Parameters.AddWithValue("@CATEGORY", rebate.type);
            cmd.Parameters.AddWithValue("@YEAR", rebate.year);
            cmd.Parameters.AddWithValue("@DATE_MODIFIED", rebate.dateModified);
            cmd.Parameters.AddWithValue("@MODIFIED_BY", rebate.modifiedBy);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Rebate data was inserted into the database successfully.";
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
        public void editSingleRebateData() { }

        //TO DO
        public void consultRebateData() { }

    }
}