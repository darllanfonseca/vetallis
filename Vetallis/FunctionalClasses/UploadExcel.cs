using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace Vetallis.FunctionalClasses
{
    public class UploadExcel
    {
        public void UploadExcelFile(String path)
        {
            using (OleDbConnection conn = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + path + ";Extended Properties=Excel 12.0;"))
            {
                conn.Open();
                OleDbCommand com = new OleDbCommand("Select * from [rebate$]", conn);
                OleDbDataReader dr = com.ExecuteReader();

                string conString = ConfigurationManager.ConnectionStrings["ConnTest"].ToString();
                SqlConnection sqlCon = new SqlConnection(conString);
                sqlCon.Open();
                using (SqlBulkCopy bulkCopy = new SqlBulkCopy(sqlCon))
                {
                    bulkCopy.ColumnMappings.Add("[ID_REBATE]", "ID_REBATE");
                    bulkCopy.ColumnMappings.Add("ID_MEMBER", "ID_MEMBER");
                    bulkCopy.ColumnMappings.Add("ID_PARTNER", "ID_PARTNER");
                    bulkCopy.ColumnMappings.Add("YEAR", "YEAR");
                    bulkCopy.ColumnMappings.Add("AMOUNT", "AMOUNT");
                    bulkCopy.ColumnMappings.Add("TYPE", "TYPE");
                    bulkCopy.ColumnMappings.Add("DELIVERED_BY", "DELIVERED_BY");
                    bulkCopy.DestinationTableName = "REBATE";
                    bulkCopy.WriteToServer(dr);
                }

                dr.Close();
                dr.Dispose();
            }
        }
    }
}