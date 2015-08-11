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
    public partial class ActivateRemovedMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            this.group_ID.Enabled = false;
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.accountNumber.Text = this.searchMembers.SelectedRow.Cells[1].Text;
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.group_ID.Text = this.searchMembers.SelectedRow.Cells[7].Text;
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
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void activateMember(object sender, EventArgs e)
        {
            if(this.datepicker.Text.Equals("")){
                this.requiredFieldsTxt.Text = "Please select the date of activation!";
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
    }
}