using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.PartnerView
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
                userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(".") - 1);
            }

            this.timeAndDate.Text = "User: " + userName + " - " + System.DateTime.Today.Date.ToLongDateString();
        }

        protected void loadSelectedPartner(object sender, EventArgs e)
        {
            this.partnerName.Text = this.searchPartners.SelectedRow.Cells[1].Text;
            this.ID_PARTNER.Text = this.searchPartners.SelectedRow.Cells[2].Text;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void exportResults(object sender, EventArgs e)
        {
            string partnerId = this.ID_PARTNER.Text;

            string query = @"SELECT PARTNER.NAME AS 'Partner Name', MEMBER.NAME AS 'Member Name', MEMBER.ACCOUNT_NUMBER AS 'Account #',
            REBATE.QUANTITY AS 'Rebate Amount',  REBATE.YEAR AS 'Year', REBATE.CATEGORY AS 'Category' 
            FROM PARTNER JOIN REBATE ON REBATE.ID_PARTNER = PARTNER.ID_PARTNER JOIN MEMBER ON 
            REBATE.ID_MEMBER = MEMBER.ID_MEMBER WHERE PARTNER.ID_PARTNER = '" + partnerId + 
            "' AND REBATE.YEAR = '" + this.rebateYear.SelectedValue + "-01-01'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Amounts.xlsx", Response);
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}