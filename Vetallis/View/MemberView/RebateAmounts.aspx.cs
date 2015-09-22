using System;
using System.Collections.Generic;
using System.Web;
using System.Web.Security;
using System.Web.UI.WebControls;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.MemberView
{
    public partial class RebateAmounts : System.Web.UI.Page
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
                if (name.IndexOf(".") >= 0)
                {
                    userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(".") - 1);
                }
                else
                {
                    userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
                }

            }

            this.timeAndDate.Text = "User: " + userName + " - " + System.DateTime.Today.Date.ToLongDateString();
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            //Server.Transfer("Default.aspx", true);
            Response.Redirect("~/Default.aspx");

            //HttpContext.Current.RewritePath("~/Default.aspx");
        }

        protected void exportResults(object sender, EventArgs e)
        {
            string memberId = this.searchMembers.SelectedRow.Cells[6].Text;
            string year = "'" + this.rebateYear.SelectedValue.ToString() + "-01-01'";

            string query = @"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
            REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
            FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER JOIN PARTNER ON REBATE.ID_PARTNER = PARTNER.ID_PARTNER WHERE ";

            query += "YEAR = " + year + " AND MEMBER.ID_MEMBER = " + memberId;

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Amounts.xlsx", Response);

        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}