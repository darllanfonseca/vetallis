using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.DAO;
using Vetallis.Business;
using System.Configuration;
using System.Data.SqlClient;
using System.Data;

namespace Vetallis.View.MembershipView
{
    public partial class Pay : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!this.Page.User.Identity.IsAuthenticated)
            {
                FormsAuthentication.RedirectToLoginPage();
            }
            string userName = "User";
            string name = this.Page.User.Identity.Name.ToString();

            if (name != null && name != "")
            {
                userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(".") - 1);
            }

            this.timeAndDate.Text = "Welcome back " + userName + "! Today is " + DateTime.Today.ToLongDateString();

           
        }

        protected void openDivs(object sender, EventArgs e)
        {
            switch (this.cat.SelectedIndex)
            {
                case 1:
                    this.memberDiv.Visible = true;
                    this.groupDiv.Visible = false;
                    this.yearDiv.Visible = true;
                    this.buttonsDiv.Visible = true;
                    break;
                case 2:
                    this.memberDiv.Visible = false;
                    this.groupDiv.Visible = true;
                    this.yearDiv.Visible = true;
                    this.buttonsDiv.Visible = true;
                    break;
                case 3:
                    this.memberDiv.Visible = false;
                    this.groupDiv.Visible = false;
                    this.yearDiv.Visible = true;
                    this.buttonsDiv.Visible = true;
                    break;
                case 4:
                    this.memberDiv.Visible = false;
                    this.groupDiv.Visible = false;
                    this.yearDiv.Visible = false;
                    this.buttonsDiv.Visible = true;
                    break;
            }
        }

        protected void getResults(object sender, EventArgs e)
        {
            MembershipDAO mspDAO;
            Vetallis.Business.Membership membership;

            switch (this.cat.SelectedIndex)
            {
                case 1:

                    //pesquisar no BD
                    mspDAO = new MembershipDAO();
                    membership = mspDAO.getMemberPaid(this.searchMembers.SelectedRow.Cells[6].Text, this.selectYear.Text);

                    string conn = ConfigurationManager.ConnectionStrings["Conn"].ToString();
                    SqlConnection sqlConn = new SqlConnection();

                    sqlConn.ConnectionString = conn;
                    DataTable dt = new DataTable();
                    dt.Clear();

                    SqlCommand cmd = new SqlCommand(string.Format(
                    @"SELECT MEMBER.NAME, MEMBER.ACCOUNT_NUMBER FROM MEMBER WHERE MEMBER.ID_MEMBER=@ID_MEMBER"), sqlConn);

                    cmd.Parameters.AddWithValue("@ID_MEMBER", membership.idMember);

                    string memberName = "";
                    try
                    {
                        sqlConn.Open();

                        SqlDataReader reader = cmd.ExecuteReader();
                        reader.Read();

                        memberName = reader.GetValue(0).ToString();
                        memberName += " (" + reader.GetValue(1).ToString() + ")";

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

                    this.memberDiv.Visible = false;
                    this.specificMemberDiv.Visible = true;
                    this.specifMemberName.Text = memberName;
                    this.membershipYear.Text = membership.year.Substring(0, 4);

                    if(membership.isPaid.Equals("True"))
                        this.paidResponse.Text = "Yes";
                    else
                        this.paidResponse.Text = "No";


                    //jogar na Tela o resultado




                    break;
            }
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}