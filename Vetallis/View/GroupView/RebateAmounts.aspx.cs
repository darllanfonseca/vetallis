using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.GroupView
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

        protected void exportResults(object sender, EventArgs e)
        {
            string query = @"SELECT GROUPS.GROUP_NAME AS 'Group Name', PARTNER.NAME AS Partner, MEMBER.NAME AS Member, 
            REBATE.QUANTITY AS Amount FROM GROUPS JOIN REBATE ON REBATE.ID_MEMBER = GROUPS.ID_MAIN_MEMBER OR REBATE.ID_MEMBER = 
            GROUPS.ID_SECOND_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_THIRD_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_FOURTH_MEMBER 
            OR REBATE.ID_MEMBER = GROUPS.ID_FITH_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_SIXTH_MEMBER JOIN PARTNER ON 
            REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE GROUPS.ID_GROUP = " 
            + this.ID_Group.Text + " AND YEAR = '" + this.rebateYear.SelectedValue + "-01-01'";


            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Amounts.xlsx", Response);
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void loadSelectedGroup(object sender, EventArgs e)
        {
            this.groupName.Text = this.searchGroups.SelectedRow.Cells[2].Text.ToString();
            this.ID_Group.Text = this.searchGroups.SelectedRow.Cells[1].Text.ToString();
        }
    }
}