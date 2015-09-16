using System;
using System.Web.Security;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.RebateView
{
    public partial class ViewCETotals : System.Web.UI.Page
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

            this.timeAndDate.Text = "User: " + userName + " - " + System.DateTime.Today.Date.ToLongDateString();
        }

        protected void openDivs(object sender, EventArgs e)
        {
            switch (this.category.SelectedIndex)
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
            switch (this.category.SelectedIndex)
            {
                case 1:
                    string query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', CE.YEAR AS 'Rebate Year', CE.NUMBER_OF_SEATS 
                    AS 'Number of Seats', CE.EVENT_DATE AS 'Event Date' FROM CE JOIN MEMBER ON CE.ID_MEMBER=MEMBER.ID_MEMBER 
                    WHERE CE.ID_MEMBER=" + this.searchMembers.SelectedRow.Cells[6].Text+ " AND YEAR='" 
                    + this.selectYear.Text + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 2:
                    query = @"SELECT GROUPS.GROUP_NAME AS 'Group Name', MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', 
                    CE.NUMBER_OF_SEATS AS 'Number of Seats', CE.EVENT_DATE AS 'Event Date', CE.YEAR AS 'Rebate Year' FROM 
                    GROUPS JOIN CE ON CE.ID_MEMBER = GROUPS.ID_MAIN_MEMBER OR CE.ID_MEMBER = 
                    GROUPS.ID_SECOND_MEMBER OR CE.ID_MEMBER = GROUPS.ID_THIRD_MEMBER OR CE.ID_MEMBER = GROUPS.ID_FOURTH_MEMBER 
                    OR CE.ID_MEMBER = GROUPS.ID_FITH_MEMBER OR CE.ID_MEMBER = GROUPS.ID_SIXTH_MEMBER JOIN MEMBER ON 
                    CE.ID_MEMBER = MEMBER.ID_MEMBER WHERE GROUPS.ID_GROUP = "
                    + this.searchGroups.SelectedRow.Cells[3].Text + " AND YEAR = '" + this.selectYear.Text + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 3:
                    query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', CE.NUMBER_OF_SEATS 
                    AS 'Number of Seats', CE.EVENT_DATE AS 'Event Date', CE.YEAR AS 'Rebate Year' FROM CE JOIN MEMBER
                    ON CE.ID_MEMBER=MEMBER.ID_MEMBER WHERE YEAR='" + this.selectYear.Text + "-01-01'";

                    CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Results.xlsx", Response);

                    break;

                case 4:
                    query = @"SELECT MEMBER.ACCOUNT_NUMBER AS 'Acc. #', MEMBER.NAME AS 'Member Name', CE.NUMBER_OF_SEATS 
                    AS 'Number of Seats', CE.EVENT_DATE AS 'Event Date', CE.YEAR AS 'Rebate Year' FROM CE JOIN MEMBER
                    ON CE.ID_MEMBER=MEMBER.ID_MEMBER";

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