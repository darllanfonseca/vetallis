using System;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;
using System.IO;

namespace Vetallis.FunctionalClasses
{
    public class ExportExcel
    {



        public Microsoft.Office.Interop.Excel.Application insertBTN(String query)
        {
            SqlConnection sqlCon = new SqlConnection();
            sqlCon.ConnectionString = "Data Source=DARLLAN\\SQLEXPRESS;Initial Catalog=TEST_JUN_25;Persist Security Info=True;User ID=sa;Password=DrBr23++";
            sqlCon.Open();

            SqlDataAdapter da = new SqlDataAdapter(query, sqlCon);
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
         
            
            ExcelApp.ActiveWorkbook.SaveCopyAs("Results.xlsx");
            ExcelApp.ActiveWorkbook.Saved = true;
            ExcelApp.Quit();

            return ExcelApp;
        }    

    }
}
