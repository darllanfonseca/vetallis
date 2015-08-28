using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.MemberView
{
    public partial class RemoveMember : System.Web.UI.Page
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

            this.accountNumber.Enabled = false;
            this.memberName.Enabled = false;
            this.dateJoined.Enabled = false;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void removeMember(object sender, EventArgs e)
        {
            Member member = new Member();

            member.id = this.searchMembers.SelectedRow.Cells[6].Text;
            member.status = "INACTIVE";
            member.dateRemoved = this.datepicker.Text;

            MemberDAO memberDAO = new MemberDAO();
            this.removeMemberForm.Visible = false;
            this.responseForm.Visible = true;
            this.responseText.Text = memberDAO.removeMember(member);
                                                        
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.accountNumber.Text = this.searchMembers.SelectedRow.Cells[1].Text;
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.dateJoined.Text = this.searchMembers.SelectedRow.Cells[8].Text;
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

    }
}