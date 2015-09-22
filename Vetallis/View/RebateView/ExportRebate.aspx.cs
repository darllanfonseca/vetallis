using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.RebateView
{
    public partial class ExportRebate : System.Web.UI.Page
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

        protected void rebateCategory(object sender, EventArgs e)
        {
            switch (this.category.SelectedIndex)
            {
                case 1:
                    this.hideDivs();
                    this.memberDiv.Visible = true;
                    this.yearDiv.Visible = true;                    
                    break;

                case 2:
                    this.hideDivs();
                    this.memberDiv.Visible = true;
                    break;

                case 3:
                    this.hideDivs();
                    this.partnerDiv.Visible = true;
                    this.yearDiv.Visible = true;
                    break;

                case 4:
                    this.hideDivs();
                    this.partnerDiv.Visible = true;
                    break;

                case 5:
                    this.hideDivs();
                    this.groupDiv.Visible = true;
                    this.yearDiv.Visible = true;
                    break;

                case 6:
                    this.hideDivs();
                    this.groupDiv.Visible = true;
                    break;

                case 7:
                    this.hideDivs();
                    this.yearDiv.Visible = true;
                    break;

                case 8:
                    this.hideDivs();
                    break;
            }
        }

        protected void hideDivs()
        {
            this.memberDiv.Visible = false;
            this.groupDiv.Visible = false;            
            this.partnerDiv.Visible = false;
            this.yearDiv.Visible = false;
            this.buttonsDiv.Visible = true;
        }

        protected void getResults(object sender, EventArgs e)
        {
            switch (this.category.SelectedIndex)
            {
                case 1:
                    //-------MEMBER REBATE IN A GIVEN YEAR--------------------
                    string query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', REBATE.QUANTITY 
                    AS 'Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', 
                    REBATE.YEAR FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER=MEMBER.ID_MEMBER
                    WHERE MEMBER.ID_MEMBER=" + this.searchMembers.SelectedRow.Cells[6].Text + " AND YEAR='"
                    + this.selectYear.Text + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 2:
                    //-------MEMBER REBATE IN ALL TIMES--------------------
                    query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', REBATE.QUANTITY 
                    AS 'Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', 
                    REBATE.YEAR FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER=MEMBER.ID_MEMBER
                    WHERE MEMBER.ID_MEMBER=" + this.searchMembers.SelectedRow.Cells[6].Text;

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 3:
                    //-------PARTNER REBATE IN A GIVEN YEAR--------------------
                    query = @"SELECT PARTNER.NAME AS 'Partner Name', MEMBER.ACCOUNT_NUMBER AS 'Account #', MEMBER.NAME AS 'Member Name',
                    REBATE.QUANTITY AS 'Rebate Amount', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner',  REBATE.YEAR AS 'Year', REBATE.CATEGORY AS 'Category' 
                    FROM PARTNER JOIN REBATE ON REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON 
                    REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE PARTNER.ID_PARTNER = '" + this.searchPartners.SelectedRow.Cells[4].Text +
                    "' AND REBATE.YEAR = '" + this.selectYear.SelectedValue + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 4:
                    //-------PARTNER REBATE IN ALL TIMES--------------------
                    query = @"SELECT PARTNER.NAME AS 'Partner Name', MEMBER.ACCOUNT_NUMBER AS 'Account #', MEMBER.NAME AS 'Member Name',
                    REBATE.QUANTITY AS 'Rebate Amount', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner',  REBATE.YEAR AS 'Year', REBATE.CATEGORY AS 'Category' 
                    FROM PARTNER JOIN REBATE ON REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON 
                    REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE PARTNER.ID_PARTNER = " + this.searchPartners.SelectedRow.Cells[4].Text;

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 5:
                    //-------GROUP REBATE IN A GIVEN YEAR--------------------
                    query = @"SELECT GROUPS.GROUP_NAME AS 'Group Name', MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', 
                    PARTNER.NAME AS 'Partner Name', REBATE.QUANTITY AS 'Rebate Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', REBATE.YEAR AS 'Year' 
                    FROM GROUPS JOIN REBATE ON REBATE.ID_MEMBER = GROUPS.ID_MAIN_MEMBER OR REBATE.ID_MEMBER = 
                    GROUPS.ID_SECOND_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_THIRD_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_FOURTH_MEMBER 
                    OR REBATE.ID_MEMBER = GROUPS.ID_FITH_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_SIXTH_MEMBER JOIN PARTNER ON 
                    REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE GROUPS.ID_GROUP = "
                    + this.searchGroups.SelectedRow.Cells[3].Text + " AND YEAR = '" + this.selectYear.SelectedValue + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 6:
                    //-------GROUP REBATE IN ALL TIMES--------------------
                    query = @"SELECT GROUPS.GROUP_NAME AS 'Group Name', MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', 
                    PARTNER.NAME AS 'Partner Name', REBATE.QUANTITY AS 'Rebate Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', REBATE.YEAR AS 'Year' 
                    FROM GROUPS JOIN REBATE ON REBATE.ID_MEMBER = GROUPS.ID_MAIN_MEMBER OR REBATE.ID_MEMBER = 
                    GROUPS.ID_SECOND_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_THIRD_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_FOURTH_MEMBER 
                    OR REBATE.ID_MEMBER = GROUPS.ID_FITH_MEMBER OR REBATE.ID_MEMBER = GROUPS.ID_SIXTH_MEMBER JOIN PARTNER ON 
                    REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE GROUPS.ID_GROUP = "
                    + this.searchGroups.SelectedRow.Cells[3].Text;

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 7:
                    //-------ALL REBATES IN A GIVEN YEAR--------------------
                    query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', PARTNER.NAME AS 'Partner Name', 
                    REBATE.QUANTITY AS 'Rebate Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', REBATE.YEAR AS 'Year' 
                    FROM MEMBER JOIN REBATE ON REBATE.ID_MEMBER=MEMBER.ID_MEMBER JOIN PARTNER ON REBATE.ID_PARTNER=PARTNER.ID_PARTNER
                    WHERE REBATE.YEAR='" + this.selectYear.Text + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 8:
                    //-------ALL REBATES OF ALL TIMES--------------------
                    query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', PARTNER.NAME AS 'Partner Name', 
                    REBATE.QUANTITY AS 'Rebate Amount', REBATE.CATEGORY AS 'Category', REBATE.IS_DELIVERED_BY_PARTNER AS 'Is Delivered By Partner', REBATE.YEAR AS 'Year' 
                    FROM MEMBER JOIN REBATE ON REBATE.ID_MEMBER=MEMBER.ID_MEMBER JOIN PARTNER ON REBATE.ID_PARTNER=PARTNER.ID_PARTNER";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

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