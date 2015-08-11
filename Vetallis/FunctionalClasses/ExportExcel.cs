using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Vetallis.FunctionalClasses
{
    public class ExportExcel
    {

        public string exportData(String query)
        {
            string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
            SqlConnection sqlConn = new SqlConnection();
            sqlConn.ConnectionString = conn;
            sqlConn.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, sqlConn);
            System.Data.DataTable dtMainSQLData = new System.Data.DataTable();
            da.Fill(dtMainSQLData);
            DataColumnCollection dcCollection = dtMainSQLData.Columns;

            // Export Data into EXCEL Sheet
            Microsoft.Office.Interop.Excel.Application ExcelApp = new
            Microsoft.Office.Interop.Excel.Application();
            ExcelApp.Application.Workbooks.Add(Type.Missing);


            // ExcelApp.Cells.CopyFromRecordset(objRS);

            for (int i = 1; i < dtMainSQLData.Rows.Count + 2; i++)
            {

                for (int j = 1; j < dtMainSQLData.Columns.Count + 1; j++)
                {
                    if (i == 1)
                    {
                        ExcelApp.Cells[i, j] = dcCollection[j - 1].ToString();
                    }
                    else
                        ExcelApp.Cells[i, j] = dtMainSQLData.Rows[i - 2][j - 1].ToString();
                }
            }


            string path = Directory.GetParent(Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData)).FullName;
            if (Environment.OSVersion.Version.Major >= 6)
            {
                path = Directory.GetParent(path).ToString();
            }

            //This path belongs to the computer where the application is running.
            //I have to find a way to get the path from the client side... 

            try
            {
                ExcelApp.ActiveWorkbook.SaveAs(path + "\\Desktop\\Results.xlsx");
                ExcelApp.ActiveWorkbook.Saved = true;

                ExcelApp.Quit();

                return "The file has been generated successfully and it is ready on your Desktop.";
            }
            catch (Exception e)
            {
                return "Some error has occured. Message from Server: " + e.Message;
            }

            

        }

    }
}
