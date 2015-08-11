using System;
using Vetallis.FunctionalClasses;

namespace Vetallis
{
    public partial class Default : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.timeAndDate.Text = "Welcome Darllan! Today is " + DateTime.Today.ToLongDateString();
        }

        //Exports current list of active members
        protected void exportMemberList(object sender, EventArgs e)
        {
            ExportExcel export = new ExportExcel();
            string result = export.exportData("SELECT NAME FROM MEMBER WHERE STATUS = 'ACTIVE' ORDER BY MEMBER.NAME");

            this.changeForms();
            this.responseText.Text = result;
        }

        //Exports current list of the active Partners
        protected void exportPartnerList(object sender, EventArgs e)
        {
            ExportExcel export = new ExportExcel();
            string result = export.exportData("SELECT * FROM PARTNER WHERE STATUS = 'ACTIVE'");

            this.changeForms();
            this.responseText.Text = result;
        }

        //Exports current Rebate sheet 
        protected void exportRebateSheet(object sender, EventArgs e)
        {
            ExportExcel export = new ExportExcel();           

            string result = export.exportData(@"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER JOIN PARTNER ON 
                REBATE.ID_PARTNER = PARTNER.ID_PARTNER WHERE REBATE.YEAR = '" +
            this.rebateYear.SelectedValue.ToString() + "-01-01' ORDER BY MEMBER.NAME, PARTNER.NAME");

            this.changeForms();
            this.responseText.Text = result;

            this.rebateYear.SelectedIndex = 0;
            this.pickYear.Visible = false;
            this.exportBtt.Visible = true;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void activateYearDropDown(object sender, EventArgs e)
        {
            this.exportBtt.Visible = false;
            this.pickYear.Visible = true;

        }

        protected void changeForms()
        {
            this.DefaultForm.Visible = false;
            this.responseForm.Visible = true;
        }
    }
}