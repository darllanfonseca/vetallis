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
                if (name.IndexOf(".") >= 0)
                {
                    userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.IndexOf(".") - 1);
                }
                else
                {
                    userName = name.Substring(0, 1).ToUpper() + name.Substring(1, name.Length - 1);
                }
                
            }
            
            this.timeAndDate.Text = "Welcome back " + userName + "! Today is " + DateTime.Today.ToLongDateString();
            this.footer.InnerText = "© " + DateTime.Today.Year.ToString() + " Vet Alliance Inc. - Vet Alliance Information System.";

        }

        //Exports current list of active members
        protected void exportMemberList(object sender, EventArgs e)
        {
            string query = @"SELECT ACCOUNT_NUMBER, NAME, DATE_JOINED, DOCTOR, ADDRESS, 
            CITY, PROVINCE, REGION, POSTAL_CODE, WEBSITE, EMAIL_ADDRESS, PHONE_NUMBER, FAX, CONTACT_PERSON FROM MEMBER WHERE STATUS = 'ACTIVE' ORDER BY MEMBER.NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Members.xlsx", Response);

        }

        //Exports current list of the active Partners
        protected void exportPartnerList(object sender, EventArgs e)
        {
            string query = "SELECT NAME, ADDRESS, CITY, PARTNER_SINCE, PROVINCE, POSTAL_CODE, WEBSITE, PHONE_NUMBER, FAX FROM PARTNER WHERE STATUS = 'ACTIVE'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Active Partners.xlsx", Response);
        }

        //Exports current list of the inactive Partners
        protected void exportInactivePartners(object sender, EventArgs e)
        {
            string query = "SELECT NAME, ADDRESS, CITY, PARTNER_SINCE, PROVINCE, POSTAL_CODE, WEBSITE, PHONE_NUMBER, FAX FROM PARTNER WHERE STATUS = 'INACTIVE'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Inactive Partners.xlsx", Response);
        }       

        //Exports current Rebate sheet 
        protected void exportRebateSheet(object sender, EventArgs e)
        {      
            string query = @"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = MEMBER.ID_MEMBER JOIN PARTNER ON 
                REBATE.ID_PARTNER = PARTNER.ID_PARTNER WHERE REBATE.YEAR = '2014-01-01' ORDER BY MEMBER.NAME, PARTNER.NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Rebate Sheet.xlsx", Response);            
        }

        //Exports template file
        protected void downloadTemplateFile(object sender, EventArgs e)
        {
            string query = @"SELECT ID_MEMBER, ID_PARTNER, IS_DELIVERED_BY_PARTNER, QUANTITY, CATEGORY, YEAR, DATE_MODIFIED, MODIFIED_BY
                            FROM REBATE WHERE ID_REBATE = -1;";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Template.xlsx", Response);
        }

        protected void downloadMemberIds(object sender, EventArgs e)
        {
            string query = @"SELECT ID_MEMBER, ACCOUNT_NUMBER, NAME, DOCTOR, ADDRESS, CITY, PROVINCE
                            FROM MEMBER WHERE STATUS = 'ACTIVE'";
            
            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Member IDs.xlsx", Response);
        }

        protected void downloadPartnerIds(object sender, EventArgs e)
        {
            string query = @"SELECT ID_PARTNER, NAME FROM PARTNER WHERE STATUS = 'ACTIVE'";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "Partner IDs.xlsx", Response);
        }

        //exports list of inactive members
        protected void exportInactiveMembers(object sender, EventArgs e)
        {
            string query = @"SELECT ACCOUNT_NUMBER, NAME, DATE_JOINED, DATE_REMOVED, DATE_LAST_ACTIVATED, 
            STATUS, DOCTOR, ADDRESS, CITY, PROVINCE, REGION, POSTAL_CODE, WEBSITE, EMAIL_ADDRESS, 
            PHONE_NUMBER, FAX, CONTACT_PERSON, DATE_MODIFIED, MODIFIED_BY, DATE_CREATED 
            FROM MEMBER WHERE STATUS='INACTIVE' ORDER BY NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "InactiveMembers.xlsx", Response);

        }


        //Page Redirection -- MEMBER --

        //redirects to other page
        protected void goToInsertMember(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MemberView/InsertMember.aspx");
        }

        //redirects to other page
        protected void goToEditMember(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MemberView/EditMember.aspx");
        }

        //redirects to other page
        protected void goToRemoveMember(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MemberView/RemoveMember.aspx");
        }

        //redirects to other page
        protected void goToActivateMember(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MemberView/ActivateRemovedMember.aspx");
        }

        //redirects to other page
        protected void goToViewMemberRebate(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MemberView/RebateAmounts.aspx");
        }

        //Page Redirection -- GROUPS --

        //exports list of current groups
        protected void exportGroups(object sender, EventArgs e)
        {
            string query = @"SELECT GROUPS.GROUP_NAME AS 'Group Name', MEMBER.ACCOUNT_NUMBER AS 'Account Number', MEMBER.NAME AS 'Member Name' 
            FROM GROUPS JOIN MEMBER ON GROUPS.ID_MAIN_MEMBER = MEMBER.ID_MEMBER OR 
            GROUPS.ID_SECOND_MEMBER = MEMBER.ID_MEMBER OR GROUPS.ID_THIRD_MEMBER = 
            MEMBER.ID_MEMBER OR GROUPS.ID_FOURTH_MEMBER = MEMBER.ID_MEMBER OR 
            GROUPS.ID_FITH_MEMBER = MEMBER.ID_MEMBER OR GROUPS.ID_SIXTH_MEMBER = 
            MEMBER.ID_MEMBER ORDER BY MEMBER.ACCOUNT_NUMBER";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "List of Current Groups.xlsx", Response);
        }

        //redirects to other page
        protected void goToCreateGroup(object sender, EventArgs e)
        {
            Response.Redirect("~/View/GroupView/InsertGroup.aspx");
        }

        //redirects to other page
        protected void goToEditGroup(object sender, EventArgs e)
        {
            Response.Redirect("~/View/GroupView/EditGroup.aspx");
        }

        //redirects to other page
        protected void goToRemoveGroup(object sender, EventArgs e)
        {
            Response.Redirect("~/View/GroupView/RemoveGroup.aspx");
        }

        //redirects to other page
        protected void goToGroupRebate(object sender, EventArgs e)
        {
            Response.Redirect("~/View/GroupView/RebateAmounts.aspx");
        }


        //Page Redirection -- PARTNER --

        //redirects to other page
        protected void goToCreateNewPartner(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PartnerView/InsertPartner.aspx");
        }

        //redirects to other page
        protected void goToEditPartner(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PartnerView/EditPartner.aspx");
        }

        //redirects to other page
        protected void goToRemovePartner(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PartnerView/RemovePartner.aspx");
        }

        //redirects to other page
        protected void goToActivatePartner(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PartnerView/ActivateRemovedPartner.aspx");
        }

        //redirects to other page
        protected void goToPartnerRebate(object sender, EventArgs e)
        {
            Response.Redirect("~/View/PartnerView/RebateAmounts.aspx");
        }


        //Page Redirection -- REBATE --
        protected void goToUploadPartnerFile(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/UploadPartnerFile.aspx");
        }

        protected void goToReplacePartnerFile(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/ReplacePartnerFile.aspx");
        }

        protected void goToEditSingleRebate(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/SingleRebate.aspx");
        }

        protected void goToExportRebate(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/ExportRebate.aspx");
        }

        protected void goToMemberSummary(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/MemberSummary.aspx");
        }

        protected void goToAddCE(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/InsertCE.aspx");
        }

        protected void goToEditCE(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/EditCE.aspx");
        }

        protected void goToViewCETotals(object sender, EventArgs e)
        {
            Response.Redirect("~/View/RebateView/ViewCETotals.aspx");
        }


        //MEMBERSHIP PAGES  

        protected void goToPay(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MembershipView/Pay.aspx");
        }

        protected void goToNotPay(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MembershipView/NotPay.aspx");
        }

        protected void goToTotals(object sender, EventArgs e)
        {
            Response.Redirect("~/View/MembershipView/Totals.aspx");
        }

       //------------------------------------------- 


        //Logs the user out
        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}