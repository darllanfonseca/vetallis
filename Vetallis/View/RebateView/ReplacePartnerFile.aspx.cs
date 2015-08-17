using System;
using System.Data;
using System.IO;
using System.Data.OleDb;
using System.Configuration;
using System.Data.SqlClient;
using Vetallis.DAO;
using System.Web.Security;

namespace Vetallis.View.RebateView
{
    public partial class ReplacePartnerFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
        }

        protected void uploadExcelFile(object sender, EventArgs e)
        {
            string conString = "";
            string extension = "";

            try
            {
                //Upload and save the file
                string excelPath = Server.MapPath("~/Files/") + Path.GetFileName(this.uploadFile.PostedFile.FileName);
                uploadFile.SaveAs(excelPath);

                conString = string.Empty;
                extension = Path.GetExtension(uploadFile.PostedFile.FileName);

                switch (extension)
                {
                    case ".xls": //Excel 97-03
                        conString = ConfigurationManager.ConnectionStrings["Excel03ConString"].ConnectionString;
                        break;
                    case ".xlsx": //Excel 07 or higher
                        conString = ConfigurationManager.ConnectionStrings["Excel07+ConString"].ConnectionString;
                        break;

                }

                conString = string.Format(conString, excelPath);

            }
            catch (Exception exception)
            {
                this.responseForm.Visible = true;
                this.uploadForm.Visible = false;
                this.response.Text = "Some error has occured. Please verify the file. Message from Server: " + exception.Message;
            }

            RebateDAO rebateDAO = new RebateDAO();
            string result = rebateDAO.deletePartnerData(this.selectYear.SelectedItem.ToString() + "-01-01", this.partnerList.SelectedValue.ToString());

            if (result.Equals("error"))
            {
                this.responseForm.Visible = true;
                this.uploadForm.Visible = false;
                this.response.Text = "Some error has occured. Please verify the file/the Year.";
            }
            else
            {

                try
                {
                    using (OleDbConnection excel_con = new OleDbConnection(conString))
                    {
                        excel_con.Open();
                        string sheet1 = excel_con.GetOleDbSchemaTable(OleDbSchemaGuid.Tables, null).Rows[0]["TABLE_NAME"].ToString();
                        DataTable dtExcelData = new DataTable();

                        dtExcelData.Columns.AddRange(new DataColumn[6] {
                    new DataColumn("ID_MEMBER", typeof(int)),
                    new DataColumn("ID_PARTNER", typeof(int)),
                    new DataColumn("IS_DELIVERED_BY_PARTNER", typeof(int)),
                    new DataColumn("QUANTITY", typeof(float)),
                    new DataColumn("CATEGORY", typeof(string)),
                    new DataColumn("YEAR",typeof(string)) });

                        using (OleDbDataAdapter oda = new OleDbDataAdapter("SELECT * FROM [" + sheet1 + "]", excel_con))
                        {
                            oda.Fill(dtExcelData);
                        }
                        excel_con.Close();

                        string consString = ConfigurationManager.ConnectionStrings["Conn"].ConnectionString;

                        using (SqlConnection con = new SqlConnection(consString))
                        {
                            using (SqlBulkCopy sqlBulkCopy = new SqlBulkCopy(con))
                            {
                                //Set the database table name
                                sqlBulkCopy.DestinationTableName = "dbo.REBATE";

                                //[OPTIONAL]: Map the Excel columns with that of the database table
                                sqlBulkCopy.ColumnMappings.Add("ID_MEMBER", "ID_MEMBER");
                                sqlBulkCopy.ColumnMappings.Add("ID_PARTNER", "ID_PARTNER");
                                sqlBulkCopy.ColumnMappings.Add("IS_DELIVERED_BY_PARTNER", "IS_DELIVERED_BY_PARTNER");
                                sqlBulkCopy.ColumnMappings.Add("QUANTITY", "QUANTITY");
                                sqlBulkCopy.ColumnMappings.Add("CATEGORY", "CATEGORY");
                                sqlBulkCopy.ColumnMappings.Add("YEAR", "YEAR");

                                con.Open();
                                sqlBulkCopy.WriteToServer(dtExcelData);
                                con.Close();
                            }
                        }
                    }

                    this.responseForm.Visible = true;
                    this.uploadForm.Visible = false;
                    this.response.Text = "File uploaded successfully into the database";

                }
                catch (Exception excep)
                {
                    this.responseForm.Visible = true;
                    this.uploadForm.Visible = false;
                    this.response.Text = "Some error has occured. Please verify the file. Message from Server: " + excep.Message;
                }

            }
        }

        protected void returnMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }
    }
}