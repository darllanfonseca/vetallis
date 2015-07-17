using System;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using Vetallis.Business;

namespace Vetallis.DAO
{
    public class MemberDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public string insertNewMember(Member member)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"INSERT INTO MEMBER 
            (ID_GROUP, ACCOUNT_NUMBER, NAME, DATE_JOINED, STATUS, DOCTOR, ADDRESS, CITY, PROVINCE, REGION, 
            POSTAL_CODE, WEBSITE, EMAIL_ADDRESS, PHONE_NUMBER, FAX, CONTACT_PERSON) VALUES 
            (@ID_GROUP, @ACCOUNT_NUMBER, @NAME, @DATE_JOINED, @STATUS, @DOCTOR, @ADDRESS, @CITY, @PROVINCE, @REGION, 
            @POSTAL_CODE, @WEBSITE, @EMAIL_ADDRESS, @PHONE_NUMBER, @FAX, @CONTACT_PERSON)"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_GROUP", member.idGroup); 
            cmd.Parameters.AddWithValue("@ACCOUNT_NUMBER", member.accountNumber);
            cmd.Parameters.AddWithValue("@NAME", member.name); cmd.Parameters.AddWithValue("@DATE_JOINED", member.dateJoined);
            cmd.Parameters.AddWithValue("@STATUS", "ACTIVE"); cmd.Parameters.AddWithValue("@DOCTOR", member.doctor);
            cmd.Parameters.AddWithValue("@ADDRESS", member.address); cmd.Parameters.AddWithValue("@CITY", member.city);
            cmd.Parameters.AddWithValue("@PROVINCE", member.province); cmd.Parameters.AddWithValue("@REGION", member.region);
            cmd.Parameters.AddWithValue("@POSTAL_CODE", member.postalCode); cmd.Parameters.AddWithValue("@WEBSITE", member.website);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", member.emailAddress); cmd.Parameters.AddWithValue("@PHONE_NUMBER", member.phoneNumber);
            cmd.Parameters.AddWithValue("@FAX", member.faxNumber); cmd.Parameters.AddWithValue("@CONTACT_PERSON", member.contactPerson);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Member has been added to the Database sucessfully.";
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

        public string updateMember(Member member)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(@"UPDATE MEMBER 
            SET ID_GROUP=@ID_GROUP, ACCOUNT_NUMBER=@ACCOUNT_NUMBER, NAME=@NAME, DOCTOR=@DOCTOR, 
            ADDRESS=@ADDRESS, CITY=@CITY, PROVINCE=@PROVINCE, REGION=@REGION, 
            POSTAL_CODE=@POSTAL_CODE, WEBSITE=@WEBSITE, EMAIL_ADDRESS=@EMAIL_ADDRESS, 
            PHONE_NUMBER=@PHONE_NUMBER, FAX=@FAX, CONTACT_PERSON=@CONTACT_PERSON 
            WHERE ID_MEMBER=@ID_MEMBER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", member.id);
            cmd.Parameters.AddWithValue("@ID_GROUP", member.idGroup);
            cmd.Parameters.AddWithValue("@ACCOUNT_NUMBER", member.accountNumber);
            cmd.Parameters.AddWithValue("@NAME", member.name);
            cmd.Parameters.AddWithValue("@DOCTOR", member.doctor);
            cmd.Parameters.AddWithValue("@ADDRESS", member.address); cmd.Parameters.AddWithValue("@CITY", member.city);
            cmd.Parameters.AddWithValue("@PROVINCE", member.province); cmd.Parameters.AddWithValue("@REGION", member.region);
            cmd.Parameters.AddWithValue("@POSTAL_CODE", member.postalCode); cmd.Parameters.AddWithValue("@WEBSITE", member.website);
            cmd.Parameters.AddWithValue("@EMAIL_ADDRESS", member.emailAddress); cmd.Parameters.AddWithValue("@PHONE_NUMBER", member.phoneNumber);
            cmd.Parameters.AddWithValue("@FAX", member.faxNumber); cmd.Parameters.AddWithValue("@CONTACT_PERSON", member.contactPerson);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Member has been updated sucessfully.";
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

        public string removeMember(Member member)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            string inactive = "INACTIVE";

            SqlCommand cmd = new SqlCommand(string.Format(
            @"UPDATE MEMBER SET STATUS=@STATUS WHERE ID_MEMBER=@ID_MEMBER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", member.id);
            cmd.Parameters.AddWithValue("@STATUS", member.status);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Member has been removed sucessfully from the list of Active members.";
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

        public Member getMemberData(string idMember) //Creates a member, using a SELECT. The argument received is a member ID..
        {
            Member member = new Member();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            //SELECT SQL, using the ID passed as an argument
            SqlCommand cmd = new SqlCommand(string.Format(@"SELECT * FROM MEMBER WHERE ID_MEMBER=@ID_MEMBER"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", idMember);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                //Sets the member's parameters using the reader..
                member.id = reader.GetValue(0).ToString();
                member.idGroup = reader.GetValue(1).ToString();
                member.accountNumber = reader.GetValue(2).ToString();
                member.name = reader.GetValue(3).ToString();
                member.dateJoined = reader.GetValue(4).ToString();
                member.status = reader.GetValue(5).ToString();
                member.doctor = reader.GetValue(6).ToString();
                member.address = reader.GetValue(7).ToString();
                member.city = reader.GetValue(8).ToString();
                member.province = reader.GetValue(9).ToString();
                member.region = reader.GetValue(10).ToString();
                member.postalCode = reader.GetValue(11).ToString();
                member.website = reader.GetValue(12).ToString();
                member.emailAddress = reader.GetValue(13).ToString();
                member.phoneNumber = reader.GetValue(14).ToString();
                member.faxNumber = reader.GetValue(15).ToString();
                member.contactPerson = reader.GetValue(16).ToString();

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

            return member;
        }
    }
}