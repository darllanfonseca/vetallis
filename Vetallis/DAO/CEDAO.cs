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
    public class CEDAO
    {
        string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
        SqlConnection sqlConn = new SqlConnection();

        public string insertCE(CE ce, string user)
        {

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(
            @"INSERT INTO CE (ID_MEMBER, NUMBER_OF_SEATS, YEAR, EVENT_DATE, MODIFIED_BY, DATE_MODIFIED) VALUES 
            (@ID_MEMBER, @NUMBER_OF_SEATS, @YEAR, @EVENT_DATE, @MODIFIED_BY, @DATE_MODIFIED)"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", ce.memberID);
            cmd.Parameters.AddWithValue("@NUMBER_OF_SEATS", ce.numberOfSeats);
            cmd.Parameters.AddWithValue("@YEAR", ce.year);
            cmd.Parameters.AddWithValue("@EVENT_DATE", ce.eventDate);
            cmd.Parameters.AddWithValue("@MODIFIED_BY", user);
            cmd.Parameters.AddWithValue("@DATE_MODIFIED", System.DateTime.Today.ToShortDateString());

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The CE Data has been added sucessfully.";
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

        public List<CE> getListOfCE(string memberID, string year)
        {
            List<CE> ceList = new List<CE>();

            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(
            @"SELECT * FROM CE WHERE ID_MEMBER=@ID_MEMBER AND YEAR=@YEAR"), sqlConn);

            cmd.Parameters.AddWithValue("@ID_MEMBER", memberID);
            cmd.Parameters.AddWithValue("@YEAR", year);

            try
            {
                sqlConn.Open();

                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);

                    for (int i = 0; i < dt.Rows.Count; i++)
                    {
                        CE ce = new CE();
                        DataRow row = dt.Rows[i];

                        ce.id = row[0].ToString();
                        ce.memberID = row[1].ToString();
                        ce.numberOfSeats = row[2].ToString();
                        ce.year = row[3].ToString();
                        ce.eventDate = row[4].ToString();

                        ceList.Add(ce);
                    }
                    return ceList;
                }

            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }

            return null;
        }

        public string editCE(CE ce, string user)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            SqlCommand cmd = new SqlCommand(string.Format(
            @"UPDATE CE SET NUMBER_OF_SEATS=@NUMBER_OF_SEATS, YEAR=@YEAR, EVENT_DATE=@EVENT_DATE, 
            MODIFIED_BY=@MODIFIED_BY, DATE_MODIFIED=@DATE_MODIFIED WHERE CE.ID_CE=@ID_CE"), sqlConn);

            cmd.Parameters.AddWithValue("@NUMBER_OF_SEATS", ce.numberOfSeats);
            cmd.Parameters.AddWithValue("@YEAR", ce.year);
            cmd.Parameters.AddWithValue("@EVENT_DATE", ce.eventDate);
            cmd.Parameters.AddWithValue("@MODIFIED_BY", user);
            cmd.Parameters.AddWithValue("@DATE_MODIFIED", System.DateTime.Today);
            cmd.Parameters.AddWithValue("@ID_CE", ce.id);

            try
            {
                sqlConn.Open();

                int result = cmd.ExecuteNonQuery();

                if (result > 0)
                {
                    return "Success";
                }
                else
                {
                    return "Error";
                }

            }
            catch (Exception e)
            {
                string error = e.Message.ToString();
            }
            finally
            {
                sqlConn.Close();
            }

            return "Error";
        }
    }
}