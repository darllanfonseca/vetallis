﻿using System;
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

        public string insertGroup(Groups group, string userName)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            string query = "INSERT INTO GROUPS (ID_MAIN_MEMBER, GROUP_NAME";

            if (!group.idSecond.Equals(""))
            {
                query += ", ID_SECOND_MEMBER";
            }
            if (!group.idThird.Equals(""))
            {
                query += ", ID_THIRD_MEMBER";
            }
            if (!group.idFourth.Equals(""))
            {
                query += ", ID_FOURTH_MEMBER";
            }
            if (!group.idFith.Equals(""))
            {
                query += ", ID_FITH_MEMBER";
            }
            if (!group.idSixth.Equals(""))
            {
                query += ", ID_SIXTH_MEMBER";
            }

            query += ", DATE_MODIFIED, MODIFIED_BY, DATE_CREATED)";
            query += " VALUES (@ID_MAIN_MEMBER, @GROUP_NAME";

            if (!group.idSecond.Equals(""))
            {
                query += ", @ID_SECOND_MEMBER";
            }
            if (!group.idThird.Equals(""))
            {
                query += ", @ID_THIRD_MEMBER";
            }
            if (!group.idFourth.Equals(""))
            {
                query += ", @ID_FOURTH_MEMBER";
            }
            if (!group.idFith.Equals(""))
            {
                query += ", @ID_FITH_MEMBER";
            }
            if (!group.idSixth.Equals(""))
            {
                query += ", @ID_SIXTH_MEMBER";
            }

            query += ", @DATE_MODIFIED, @MODIFIED_BY, @DATE_CREATED)";

            SqlCommand cmd = new SqlCommand(query, sqlConn);

            cmd.Parameters.AddWithValue("@ID_MAIN_MEMBER", group.idMainMember);
            cmd.Parameters.AddWithValue("@GROUP_NAME", group.name);

            if (!group.idSecond.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_SECOND_MEMBER", group.idSecond);
            }
            if (!group.idThird.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_THIRD_MEMBER", group.idThird);
            }
            if (!group.idFourth.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_FOURTH_MEMBER", group.idThird);
            }
            if (!group.idFith.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_FITH_MEMBER", group.idThird);
            }
            if (!group.idSixth.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_SIXTH_MEMBER", group.idThird);
            }

            cmd.Parameters.AddWithValue("@DATE_MODIFIED", System.DateTime.Now);
            cmd.Parameters.AddWithValue("@MODIFIED_BY", userName);
            cmd.Parameters.AddWithValue("@DATE_CREATED", System.DateTime.Now);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Group has been created sucessfully.";
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

        public string updateGroup(Groups group, string userName)
        {
            sqlConn.ConnectionString = conn;
            DataTable dt = new DataTable();
            dt.Clear();

            string query = "UPDATE GROUPS SET ID_MAIN_MEMBER=@ID_MAIN_MEMBER, GROUP_NAME=@GROUP_NAME, ID_SECOND_MEMBER=@ID_SECOND_MEMBER";

            if (!group.idThird.Equals(""))
            {
                query += ", ID_THIRD_MEMBER=@ID_THIRD_MEMBER";
            }
            if (!group.idFourth.Equals(""))
            {
                query += ", ID_FOURTH_MEMBER=@ID_FOURTH_MEMBER";
            }
            if (!group.idFith.Equals(""))
            {
                query += ", ID_FITH_MEMBER=@ID_FITH_MEMBER";
            }
            if (!group.idSixth.Equals(""))
            {
                query += ", ID_SIXTH_MEMBER=@ID_SIXTH_MEMBER";
            }

            query += ", DATE_MODIFIED=@DATE_MODIFIED, MODIFIED_BY=@MODIFIED_BY WHERE ID_GROUP=@ID_GROUP";

            SqlCommand cmd = new SqlCommand(query, sqlConn);

            cmd.Parameters.AddWithValue("ID_GROUP", group.id);
            cmd.Parameters.AddWithValue("@ID_MAIN_MEMBER", group.idMainMember);
            cmd.Parameters.AddWithValue("@GROUP_NAME", group.name);
            cmd.Parameters.AddWithValue("@ID_SECOND_MEMBER", group.idSecond);

            if (!group.idThird.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_THIRD_MEMBER", group.idThird);
            }
            if (!group.idFourth.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_FOURTH_MEMBER", group.idThird);
            }
            if (!group.idFith.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_FITH_MEMBER", group.idThird);
            }
            if (!group.idSixth.Equals(""))
            {
                cmd.Parameters.AddWithValue("@ID_SIXTH_MEMBER", group.idThird);
            }

            cmd.Parameters.AddWithValue("@DATE_MODIFIED", System.DateTime.Today);
            cmd.Parameters.AddWithValue("@MODIFIED_BY", userName);


            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Group has been updated sucessfully.";
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

        public string removeGroup(string idGroup)
        {
            sqlConn.ConnectionString = conn;

            string query = "DELETE FROM GROUPS WHERE ID_GROUP = @ID_GROUP";

            SqlCommand cmd = new SqlCommand(query, sqlConn);
            cmd.Parameters.AddWithValue("ID_GROUP", idGroup);

            try
            {
                sqlConn.Open();
                cmd.ExecuteNonQuery();
                return "The Group has been deleted sucessfully.";
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