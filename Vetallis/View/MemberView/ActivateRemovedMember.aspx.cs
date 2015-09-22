using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.MemberView
{
    public partial class ActivateRemovedMember : System.Web.UI.Page
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

            this.accountNumber.Enabled = false;
            this.memberName.Enabled = false;
            this.dateRemoved.Enabled = false;
            this.address.Enabled = false;
            this.doctorName.Enabled = false;
            this.city.Enabled = false;
            this.province.Enabled = false;
            this.postalCode.Enabled = false;
            this.website.Enabled = false;
            this.phoneNumber.Enabled = false;
            this.emailAddress.Enabled = false;
            this.faxNumber.Enabled = false;
            this.contactPerson.Enabled = false;
            this.activateMemberBtt.Enabled = true;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (this.doctorName.Text.Equals("&nbsp;"))
            {
                this.doctorName.Text = "";
            }
            if (this.postalCode.Text.Equals("&nbsp;"))
            {
                this.postalCode.Text = "";
            }
            if (this.website.Text.Equals("&nbsp;"))
            {
                this.website.Text = "";
            }
            if (this.emailAddress.Text.Equals("&nbsp;"))
            {
                this.emailAddress.Text = "";
            }
            if (this.phoneNumber.Text.Equals("&nbsp;"))
            {
                this.phoneNumber.Text = "";
            }
            if (this.faxNumber.Text.Equals("&nbsp;"))
            {
                this.faxNumber.Text = "";
            }
            if (this.contactPerson.Text.Equals("&nbsp;"))
            {
                this.contactPerson.Text = "";
            }
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.accountNumber.Text = this.searchMembers.SelectedRow.Cells[1].Text;
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.address.Text = this.searchMembers.SelectedRow.Cells[3].Text;
            this.city.Text = this.searchMembers.SelectedRow.Cells[4].Text;
            this.province.SelectedValue = this.searchMembers.SelectedRow.Cells[5].Text;
            this.dateRemoved.Text = this.searchMembers.SelectedRow.Cells[18].Text;
            this.doctorName.Text = this.searchMembers.SelectedRow.Cells[10].Text;
            this.region.Text = this.searchMembers.SelectedRow.Cells[11].Text;
            this.postalCode.Text = this.searchMembers.SelectedRow.Cells[12].Text;
            this.website.Text = this.searchMembers.SelectedRow.Cells[13].Text;
            this.emailAddress.Text = this.searchMembers.SelectedRow.Cells[14].Text;
            this.phoneNumber.Text = this.searchMembers.SelectedRow.Cells[15].Text;
            this.faxNumber.Text = this.searchMembers.SelectedRow.Cells[16].Text;
            this.contactPerson.Text = this.searchMembers.SelectedRow.Cells[17].Text;
            this.activateMemberBtt.Enabled = true;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void activateMember(object sender, EventArgs e)
        {
            if(this.datepicker.Text.Equals("")){
                this.errorDiv.Visible = true;
                this.errorMsg.Text = "Please select the date of activation!";
            }
            else
            {
                Member member = new Member();
                MemberDAO memberDAO = new MemberDAO();

                member.id = this.searchMembers.SelectedRow.Cells[6].Text;
                member.dateLastActivated = this.datepicker.Text;
                member.status = "ACTIVE";

                this.mainForm.Visible = false;
                this.response.Visible = true;
                this.responseText.Text =  memberDAO.activateMember(member);
                
            }
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}