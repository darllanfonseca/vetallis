using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.GroupView
{
    public partial class EditGroup : System.Web.UI.Page
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

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void clearAllFields(object sender, EventArgs e)
        {
            this.mainMember.Text = "";
            this.groupName.Text = "";
            this.secondMember.Text = "";
            this.thirdMember.Text = "";
            this.fourthMember.Text = "";
            this.fithMember.Text = "";
            this.sixthMember.Text = "";
            this.sixthMemberDiv.Visible = false;
            this.fithMemberDiv.Visible = false;
            this.fourthMemberDiv.Visible = false;
            this.thirdMemberDiv.Visible = false;
            this.secondMemberDiv.Visible = false;
        }

        protected void clearAllFields()
        {
            this.mainMember.Text = "";
            this.groupName.Text = "";
            this.secondMember.Text = "";
            this.thirdMember.Text = "";
            this.fourthMember.Text = "";
            this.fithMember.Text = "";
            this.sixthMember.Text = "";
            this.sixthMemberDiv.Visible = false;
            this.fithMemberDiv.Visible = false;
            this.fourthMemberDiv.Visible = false;
            this.thirdMemberDiv.Visible = false;
            this.secondMemberDiv.Visible = false;
        }

        protected void returnToMainForm(object sender, EventArgs e)
        {
            this.editGroupForm.Visible = true;
            this.response.Visible = false;
            clearAllFields();
        }

        protected void updateGroup(object sender, EventArgs e)
        {
            if (this.mainMember.Text.Equals("") || this.secondMember.Text.Equals(""))
            {
                this.errorMsg.Visible = true;
                this.errorMsg.Text = "At least 2 members have to be selected in order to update a group.";
            }
            else if (this.groupName.Text.Equals(""))
            {
                this.errorMsg.Visible = true;
                this.errorMsg.Text = "Please insert a name for the Group.";
            }
            else
            {
                Groups group = new Groups();
                GroupsDAO groupDAO = new GroupsDAO();

                group.id = this.GroupID.Text;
                group.idMainMember = this.idMainMember.Text;
                group.name = this.groupName.Text;
                group.idSecond = this.idSecondMember.Text;
                group.idThird = this.idThirdMember.Text;
                group.idFourth = this.idFourthMember.Text;
                group.idFith = this.idFithMember.Text;
                group.idSixth = this.idSixthMember.Text;

                string result = groupDAO.updateGroup(group, this.Page.User.Identity.Name.ToString());

                this.editGroupForm.Visible = false;
                this.response.Visible = true;
                this.responseText.Text = result;
            }
        }

        protected void loadSelectedGroup(object sender, EventArgs e)
        {
            this.groupNameChosen.Text = this.searchGroups.SelectedRow.Cells[1].Text;
            this.mainMemberChosen.Text = this.searchGroups.SelectedRow.Cells[2].Text;
        }

        protected void addMember(object sender, EventArgs e)
        {
            if (this.secondMemberDiv.Visible == false && this.mainMember.Text != "")
            {
                this.secondMemberDiv.Visible = true;
                this.addSecondMember.Visible = false;
            }
            else if (this.thirdMemberDiv.Visible == false && this.secondMember.Text != "")
            {
                this.thirdMemberDiv.Visible = true;
                this.addThirdMember.Visible = false;
            }
            else if (this.fourthMemberDiv.Visible == false && this.thirdMember.Text != "")
            {
                this.fourthMemberDiv.Visible = true;
                this.addFourthMember.Visible = false;
            }
            else if (this.fithMemberDiv.Visible == false && this.fourthMember.Text != "")
            {
                this.fithMemberDiv.Visible = true;
                this.addFithMember.Visible = false;
            }
            else if (this.fithMember.Text != "")
            {
                this.sixthMemberDiv.Visible = true;
                this.addSixthMember.Visible = false;
            }
        }

        protected void changeGroupForm(object sender, EventArgs e)
        {
            this.chooseGroupForm.Visible = false;
            this.editGroupForm.Visible = true;

            this.groupName.Text = this.searchGroups.SelectedRow.Cells[1].Text;
            this.GroupID.Text = this.searchGroups.SelectedRow.Cells[3].Text;
            this.mainMember.Text = this.searchGroups.SelectedRow.Cells[2].Text;
            this.idMainMember.Text = this.searchGroups.SelectedRow.Cells[4].Text;
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            if (this.sixthMemberDiv.Visible == true)
            {
                if (this.idMainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idSecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idFourthMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idFithMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.sixthMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.idSixthMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }
            }
            else if (this.fithMemberDiv.Visible == true)
            {
                if (this.idMainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idSecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idFourthMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.fithMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.idFithMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                    this.addSixthMember.Visible = true;
                }

            }
            else if (this.fourthMemberDiv.Visible == true)
            {
                if (this.idMainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idSecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.fourthMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.idFourthMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                    this.addFithMember.Visible = true;
                }

            }
            else if (this.thirdMemberDiv.Visible == true)
            {
                if (this.idMainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.idSecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.thirdMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.idThirdMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                    this.addFourthMember.Visible = true;
                }

            }
            else if (this.secondMemberDiv.Visible == true)
            {
                if (this.idMainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.secondMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.idSecondMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                    this.addThirdMember.Visible = true;
                }
            }
            else
            {
                this.mainMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                this.idMainMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                this.addSecondMember.Visible = true;
            }

        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}