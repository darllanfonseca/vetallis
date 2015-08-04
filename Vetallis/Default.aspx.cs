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
            export.exportData("SELECT * FROM MEMBER WHERE STATUS = 'ACTIVE' ORDER BY MEMBER.NAME");

            successDownload();
        }

        //Exports current list of the active Partners
        protected void exportPartnerList(object sender, EventArgs e)
        {
            ExportExcel export = new ExportExcel();
            export.exportData("SELECT * FROM PARTNER WHERE STATUS = 'ACTIVE'");
            successDownload();
        }

        //Exports current Rebate sheet 
        protected void exportRebateSheet(object sender, EventArgs e)
        {
            ExportExcel export = new ExportExcel();

            string response = export.exportData(@"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER JOIN PARTNER ON 
                REBATE.ID_PARTNER = PARTNER.ID_PARTNER WHERE REBATE.YEAR = '" +
            this.rebateYear.SelectedValue.ToString() + "-01-01' ORDER BY MEMBER.NAME, PARTNER.NAME");

            if (response.Equals("Success"))
            {
                successDownload();
            }

            this.rebateYear.SelectedIndex = 0;

            this.pickYear.Visible = false;
            this.exportBtt.Visible = true;
        }

        //Generates an alert message telling the user the file is on the desktop
        protected void successDownload()
        {
            string message = "The Excel File is ready on your Desktop.";
            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            sb.Append("<script type = 'text/javascript'>");
            sb.Append("window.onload=function(){");
            sb.Append("alert('");
            sb.Append(message);
            sb.Append("')};");
            sb.Append("</script>");
            ClientScript.RegisterClientScriptBlock(this.GetType(), "alert", sb.ToString());
        }

        protected void activateYearDropDown(object sender, EventArgs e)
        {
            this.exportBtt.Visible = false;
            this.pickYear.Visible = true;

        }
    }
}