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
    public class MembershipDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public Membership getMemberPaid(string idMember, string year)
        {
            Membership msp = new Membership();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            //SELECT SQL, using the ID passed as an argument
            SqlCommand cmd = new SqlCommand(string.Format(@"SELECT * FROM MEMBERSHIP 
            WHERE ID_MEMBER=@ID_MEMBER AND YEAR=@YEAR"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", idMember);
            cmd.Parameters.AddWithValue("@YEAR", year);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();
                reader.Read();

                msp.id = reader.GetValue(0).ToString();
                msp.idMember = reader.GetValue(1).ToString();
                msp.idGroup = reader.GetValue(2).ToString();
                msp.year = reader.GetValue(3).ToString();
                msp.amount = reader.GetValue(4).ToString();
                msp.isPaid = reader.GetValue(5).ToString();
                msp.dateReceived = reader.GetValue(6).ToString();
                msp.memberIsSatellite = reader.GetValue(7).ToString();

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

            return msp;

        }
    }
}