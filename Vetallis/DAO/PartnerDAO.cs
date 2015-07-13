using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class PartnerDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["ConnTest"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public void insertNewPartner(Partner partner)
        {

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"INSERT INTO PARTNER 
            (NAME, ADDRESS, CITY, PROVINCE, POSTAL_CODE, WEBSITE, EMAIL_ADDRESS, PHONE_NUMBER, FAX, CONTACT_PERSON, STATUS) 
            VALUES (@NAME, @ADDRESS, @CITY, @PROVINCE, @POSTAL_CODE, @WEBSITE, @EMAIL_ADDRESS, @PHONE_NUMBER, @FAX, @CONTACT_PERSON, @STATUS)"), sqlConn);

            cmd.Parameters.AddWithValue("@NAME", partner.name);
            cmd.Parameters.AddWithValue("@ADDRESS", partner.address);
            cmd.Parameters.AddWithValue("@CITY", partner.city);
            cmd.Parameters.AddWithValue("@PROVINCE", partner.province);
            cmd.Parameters.AddWithValue("@POSTAL_CODE", partner.postalCode);
            cmd.Parameters.AddWithValue("@WEBSITE", partner.website);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", partner.emailAddress);
            cmd.Parameters.AddWithValue("@PHONE_NUMBER", partner.phoneNumber);
            cmd.Parameters.AddWithValue("@FAX", partner.faxNumber);
            cmd.Parameters.AddWithValue("@CONTACT_PERSON", partner.contactPerson);
            cmd.Parameters.AddWithValue("@STATUS", "ACTIVE");

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
            }
            catch (Exception e)
            {
                //MessageBox.Show("An error has occured when we tried to access the database. " + e.Message);
            }
            finally
            {
                sqlConn.Close();
            }

            //MessageBox.Show("The Partner has been added to the Database sucessfully.");

        }
    }
}