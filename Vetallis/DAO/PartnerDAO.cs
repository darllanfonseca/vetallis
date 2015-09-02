using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class PartnerDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public string insertNewPartner(Partner partner)
        {

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"INSERT INTO PARTNER 
            (NAME, ADDRESS, CITY, PARTNER_SINCE, POSTAL_CODE, WEBSITE, EMAIL_ADDRESS, PHONE_NUMBER, FAX, CONTACT_PERSON, STATUS) 
            VALUES (@NAME, @ADDRESS, @CITY, @PARTNER_SINCE, @POSTAL_CODE, @WEBSITE, @EMAIL_ADDRESS, @PHONE_NUMBER, @FAX, @CONTACT_PERSON, @STATUS)"), sqlConn);

            cmd.Parameters.AddWithValue("@NAME", partner.name);
            cmd.Parameters.AddWithValue("@ADDRESS", partner.address);
            cmd.Parameters.AddWithValue("@CITY", partner.city);
            cmd.Parameters.AddWithValue("@PARTNER_SINCE", partner.dateJoined);
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
                return "An error has occured when we tried to access the database. " + e.Message;
            }
            finally
            {
                sqlConn.Close();
            }

            return "The Partner has been added to the Database sucessfully.";

        }

        public string updatePartner(Partner partner)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"UPDATE PARTNER 
            SET NAME=@NAME, ADDRESS=@ADDRESS, CITY=@CITY, POSTAL_CODE=@POSTAL_CODE, WEBSITE=@WEBSITE, EMAIL_ADDRESS=@EMAIL_ADDRESS, 
            PHONE_NUMBER=@PHONE_NUMBER, FAX=@FAX, CONTACT_PERSON=@CONTACT_PERSON 
            WHERE ID_PARTNER=@ID_PARTNER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_PARTNER", partner.id);
            cmd.Parameters.AddWithValue("@NAME", partner.name);
            cmd.Parameters.AddWithValue("@ADDRESS", partner.address); cmd.Parameters.AddWithValue("@CITY", partner.city);
            cmd.Parameters.AddWithValue("@POSTAL_CODE", partner.postalCode); cmd.Parameters.AddWithValue("@WEBSITE", partner.website);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", partner.emailAddress); cmd.Parameters.AddWithValue("@PHONE_NUMBER", partner.phoneNumber);
            cmd.Parameters.AddWithValue("@FAX", partner.faxNumber); cmd.Parameters.AddWithValue("@CONTACT_PERSON", partner.contactPerson);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Partner has been updated sucessfully.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public string removePartner(Partner partner)
        {
            sqlConn.ConnectionString = conn;

            string inactive = "INACTIVE";

            SqlCommand cmd = new SqlCommand(string.Format(
            @"UPDATE PARTNER SET STATUS=@STATUS WHERE ID_PARTNER=@ID_PARTNER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_PARTNER", partner.id);
            cmd.Parameters.AddWithValue("@STATUS", inactive);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Partner has been removed sucessfully from the list of Active members.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }
        }

        public Partner getPartnerData(string idPartner) //Creates a partner object, using a SELECT. The argument received is a member ID..
        {
            Partner partner = new Partner();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            //SELECT SQL, using the ID passed as an argument
            SqlCommand cmd = new SqlCommand(string.Format(@"SELECT * FROM PARTNER WHERE ID_PARTNER=@ID_PARTNER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_PARTNER", idPartner);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                //Sets the partner's parameters using the reader..
                partner.id = reader.GetValue(0).ToString();
                partner.name = reader.GetValue(1).ToString();                                
                partner.address = reader.GetValue(2).ToString();
                partner.city = reader.GetValue(3).ToString();
                partner.dateJoined = reader.GetValue(4).ToString();
                partner.province = reader.GetValue(5).ToString();
                partner.postalCode = reader.GetValue(6).ToString();
                partner.website = reader.GetValue(7).ToString();
                partner.emailAddress = reader.GetValue(8).ToString();
                partner.phoneNumber = reader.GetValue(9).ToString();
                partner.faxNumber = reader.GetValue(10).ToString();
                partner.contactPerson = reader.GetValue(11).ToString();
                partner.status = reader.GetValue(12).ToString();

                reader.Close();

            }
            catch (Exception)
            {
                //MessageBox.Show("Some error has occured. Sorry =(");
            }
            finally
            {
                sqlConn.Close();
            }

            return partner;
        }

        public string activatePartner(Partner partner)
        {
            sqlConn.ConnectionString = conn;

            string inactive = "ACTIVE";

            SqlCommand cmd = new SqlCommand(string.Format(
            @"UPDATE PARTNER SET STATUS=@STATUS WHERE ID_PARTNER=@ID_PARTNER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_PARTNER", partner.id);
            cmd.Parameters.AddWithValue("@STATUS", inactive);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Partner has been added sucessfully to the list of Active members.";
            }
            catch (Exception e)
            {
                return e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }
        }
    }
}