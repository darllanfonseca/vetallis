using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View
{
    public partial class RemoveMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.accountNumber.Enabled = false;
            this.memberName.Enabled = false;
            this.datepicker.Enabled = false;
            this.address.Enabled = false;
            this.status.Enabled = false;
            this.doctorName.Enabled = false;
            this.city.Enabled = false;
            this.province.Enabled = false;
            this.postalCode.Enabled = false;
            this.website.Enabled = false;
            this.phoneNumber.Enabled = false;
            this.emailAddress.Enabled = false;
            this.faxNumber.Enabled = false;
            this.contactPerson.Enabled = false;
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

            MemberDAO memberDAO = new MemberDAO();
            this.removeMemberForm.InnerText = memberDAO.removeMember(member); ;  
                                                         
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.accountNumber.Text = this.searchMembers.SelectedRow.Cells[1].Text;
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.address.Text = this.searchMembers.SelectedRow.Cells[3].Text;
            this.city.Text = this.searchMembers.SelectedRow.Cells[4].Text;
            this.province.SelectedValue = this.searchMembers.SelectedRow.Cells[5].Text;
            this.datepicker.Text = this.searchMembers.SelectedRow.Cells[8].Text;
            this.status.Text = this.searchMembers.SelectedRow.Cells[9].Text;
            this.doctorName.Text = this.searchMembers.SelectedRow.Cells[10].Text;
            this.region.Text = this.searchMembers.SelectedRow.Cells[11].Text;
            this.postalCode.Text = this.searchMembers.SelectedRow.Cells[12].Text;
            this.website.Text = this.searchMembers.SelectedRow.Cells[13].Text;
            this.emailAddress.Text = this.searchMembers.SelectedRow.Cells[14].Text;
            this.phoneNumber.Text = this.searchMembers.SelectedRow.Cells[15].Text;
            this.faxNumber.Text = this.searchMembers.SelectedRow.Cells[16].Text;
            this.contactPerson.Text = this.searchMembers.SelectedRow.Cells[17].Text;
        }
    }
}