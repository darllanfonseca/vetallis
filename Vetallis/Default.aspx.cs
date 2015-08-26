using System;
using System.Web.Security;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis
{
    public partial class Default : System.Web.UI.Page
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
            this.footer.InnerText = "© " + DateTime.Today.Year.ToString() + " Vet Alliance Inc. - Vet Alliance Information System.";
        }

        //Exports current list of active members
        protected void exportMemberList(object sender, EventArgs e)
        {
            string query = @"SELECT ACCOUNT_NUMBER, NAME, DATE_JOINED, DOCTOR, ADDRESS, 
            CITY, PROVINCE, REGION, POSTAL_CODE FROM MEMBER WHERE STATUS = 'ACTIVE' ORDER BY MEMBER.NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Members.xlsx", Response);

        }

        //Exports current list of the active Partners
        protected void exportPartnerList(object sender, EventArgs e)
        {
            string query = "SELECT NAME, ADDRESS, CITY, PARTNER_SINCE, PROVINCE, POSTAL_CODE, WEBSITE FROM PARTNER WHERE STATUS = 'ACTIVE'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Partners.xlsx", Response);
        }

        //Exports current Rebate sheet 
        protected void exportRebateSheet(object sender, EventArgs e)
        {      
            string query = @"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER JOIN PARTNER ON 
                REBATE.ID_PARTNER = PARTNER.ID_PARTNER WHERE REBATE.YEAR = '2015-01-01' ORDER BY MEMBER.NAME, PARTNER.NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Sheet.xlsx", Response);            
        }

        protected void selectFieldsFromDB(object sender, EventArgs e)
        {
            string query = "SELECT *";

            query += " FROM MEMBER WHERE STATUS='INACTIVE' ORDER BY NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "InactiveMembers.xlsx", Response);

        }

        protected void exportGroups(object sender, EventArgs e)
        {
            string query = "SELECT * FROM GROUPS";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "List of Current Groups.xlsx", Response);
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}