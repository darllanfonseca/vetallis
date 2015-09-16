using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.GroupView
{
    public partial class InsertGroup : System.Web.UI.Page
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
            this.FourthMemberDiv.Visible = false;
            this.thirdMemberDiv.Visible = false;
            this.secondMemberDiv.Visible = false;
            this.addSecondMemberBtt.Visible = true;
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
            this.FourthMemberDiv.Visible = false;
            this.thirdMemberDiv.Visible = false;
            this.secondMemberDiv.Visible = false;
            this.addSecondMemberBtt.Visible = true;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void insertNewGroup(object sender, EventArgs e)
        {
            if (this.mainMember.Text.Equals("") || this.secondMember.Text.Equals(""))
            {
                this.errorMsg.Visible = true;
                this.errorMsg.Text = "At least 2 members have to be selected in order to create a group.";
            }
            else if (this.groupName.Text.Equals(""))
            {
                this.errorMsg.Visible = true;
                this.errorMsg.Text = "Please insert a name for the Group.";
            }else
            {
                Groups group = new Groups();
                GroupsDAO groupDAO = new GroupsDAO();

                group.idMainMember = this.ID_MainMember.Text;
                group.name = this.groupName.Text;
                group.idSecond = this.ID_SecondMember.Text;
                group.idThird = this.ID_ThirdMember.Text;
                group.idFourth = this.ID_FourthMember.Text;
                group.idFith = this.ID_FithMember.Text;
                group.idSixth = this.ID_SixthMember.Text;

                string result = groupDAO.insertGroup(group, this.Page.User.Identity.Name.ToString());

                this.insertGroupForm.Visible = false;
                this.response.Visible = true;
                this.responseText.Text = result;
            }
            
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            if (this.sixthMemberDiv.Visible == true)
            {
                if (this.ID_MainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_SecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_ThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_FourthMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_FithMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.sixthMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.ID_SixthMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }                
            }
            else if (this.fithMemberDiv.Visible == true)
            {
                if (this.ID_MainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_SecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_ThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_FourthMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.fithMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.ID_FithMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }
                
            }
            else if (this.FourthMemberDiv.Visible == true)
            {
                if (this.ID_MainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_SecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_ThirdMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.fourthMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.ID_FourthMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }
                
            }
            else if (this.thirdMemberDiv.Visible == true)
            {
                if (this.ID_MainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text
                    && this.ID_SecondMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.thirdMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.ID_ThirdMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }
                
            }
            else if (this.secondMemberDiv.Visible == true)
            {
                if (this.ID_MainMember.Text != this.searchMembers.SelectedRow.Cells[6].Text)
                {
                    this.secondMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.ID_SecondMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
                }                
            }
            else
            {
                this.mainMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                this.ID_MainMember.Text = this.searchMembers.SelectedRow.Cells[6].Text;
            }
           
        }

        protected void addMember(object sender, EventArgs e)
        {
            if (this.secondMemberDiv.Visible == false && this.mainMember.Text != "")
            {
                this.secondMemberDiv.Visible = true;
                this.addSecondMemberBtt.Visible = false;
                this.Button1.Visible = true;
            }
            else if (this.thirdMemberDiv.Visible == false && this.secondMember.Text != "")
            {
                this.thirdMemberDiv.Visible = true;
                this.Button1.Visible = false;
                this.Button2.Visible = true;
            }
            else if (this.FourthMemberDiv.Visible == false && this.thirdMember.Text != "")
            {
                this.FourthMemberDiv.Visible = true;
                this.Button2.Visible = false;
                this.Button3.Visible = true;
            }
            else if (this.fithMemberDiv.Visible == false && this.fourthMember.Text != "")
            {
                this.fithMemberDiv.Visible = true;
                this.Button3.Visible = false;
                this.Button4.Visible = true;
            }
            else if(this.fithMember.Text != "")
            {
                this.sixthMemberDiv.Visible = true;
                this.Button4.Visible = false;
            }
        }

        protected void returnToMainForm(object sender, EventArgs e)
        {
            this.insertGroupForm.Visible = true;
            this.response.Visible = false;
            this.searchMembers.SelectedIndex = -1;
            clearAllFields();
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}