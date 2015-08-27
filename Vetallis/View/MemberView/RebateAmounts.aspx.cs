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

            string query = @"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = " + memberId + " JOIN PARTNER ON PARTNER.ID_PARTNER = ";

            List<String> partnerList = new List<string>();

            foreach (ListItem item in this.partners.Items)
            {
                if (item.Selected)
                {
                    partnerList.Add(item.Value);
                }
                else
                {
                    // Item is not selected, do something else.
                }
            }
            // Join the string together using the ; delimiter.
            query += String.Join(" OR PARTNER.ID_PARTNER = ", partnerList.ToArray());

            query += " AND YEAR = '" + this.rebateYear.SelectedValue.ToString() + "-01-01'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Amounts.xlsx", Response);
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}