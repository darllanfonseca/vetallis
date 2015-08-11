using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.MemberView
{
    public partial class RemoveMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
        }

    }
}