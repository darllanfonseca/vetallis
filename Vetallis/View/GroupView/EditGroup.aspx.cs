using System;
using System.Collections.Generic;
using System.Data;
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
           
            GroupsDAO groupDAO = new GroupsDAO();

            List<Groups> groups = groupDAO.getAllGroups();


            System.Data.DataTable tbl = new DataTable();
            DataColumn col = new DataColumn("Group Name");
            tbl.Columns.Add(col);
            col = new DataColumn("Main Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Second Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Third Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Fourth Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Fith Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Sixth Member");
            tbl.Columns.Add(col);
            col = new DataColumn("Group ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Main Member ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Second Member ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Third Member ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Fourth Member ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Fith Member ID");
            tbl.Columns.Add(col);
            col = new DataColumn("Sixth Member ID");
            tbl.Columns.Add(col);

            foreach (Groups group in groups)
            {
                DataRow dr = tbl.NewRow();
                dr["Group Name"] = group.name;
                dr["Main Member"] = group.mainMemberName;
                dr["Second Member"] = group.secondMemberName;
                dr["Third Member"] = group.thirdMemberName;
                dr["Fourth Member"] = group.fourthMemberName;
                dr["Fith Member"] = group.fithMemberName;
                dr["Sixth Member"] = group.sixthMemberName;
                dr["Group ID"] = group.id;
                dr["Main Member ID"] = group.idMainMember;
                dr["Second Member ID"] = group.idSecond;
                dr["Third Member ID"] = group.idThird;
                dr["Fourth Member ID"] = group.idFourth;
                dr["Fith Member ID"] = group.idFith;
                dr["Sixth Member ID"] = group.idSixth;

                tbl.Rows.Add(dr);
            }

            searchGroups.DataSource = tbl;
            searchGroups.DataBind();

            ViewState.Add("TBL", tbl);
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (this.editGroupForm.Visible == true)
            {
                if (this.thirdMember.Text.Equals("&nbsp;"))
                {
                    this.addThirdMember.Visible = true;
                }
                else if (this.fourthMember.Text.Equals("&nbsp;"))
                {
                    this.addFourthMember.Visible = true;
                }
                else if (this.fithMember.Text.Equals("&nbsp;"))
                {
                    this.addFithMember.Visible = true;
                }
                else if (this.sixthMember.Text.Equals("&nbsp;"))
                {
                    this.addSixthMember.Visible = true;
                }
            }
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
            this.chooseGroupForm.Visible = true;
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

                if (!this.idThirdMember.Text.Equals("") && !this.idThirdMember.Text.Equals("&nbsp;"))
                group.idThird = this.idThirdMember.Text;

                if (!this.idFourthMember.Text.Equals("") && !this.idFourthMember.Text.Equals("&nbsp;"))
                group.idFourth = this.idFourthMember.Text;

                if (!this.idFithMember.Text.Equals("") && !this.idFithMember.Text.Equals("&nbsp;"))
                group.idFith = this.idFithMember.Text;

                if (!this.idSixthMember.Text.Equals("") && !this.idSixthMember.Text.Equals("&nbsp;"))
                group.idSixth = this.idSixthMember.Text;

                string result = groupDAO.updateGroup(group, this.Page.User.Identity.Name.ToString());

                this.editGroupForm.Visible = false;
                this.response.Visible = true;
                this.responseText.Text = result;
            }
        }

        protected void loadSelectedGroup(object sender, EventArgs e)
        {
            this.groupName.Text = this.searchGroups.SelectedRow.Cells[1].Text;
            this.groupNameChosen.Text = this.searchGroups.SelectedRow.Cells[1].Text;
            this.mainMember.Text = this.searchGroups.SelectedRow.Cells[2].Text;
            this.mainMemberChosen.Text = this.searchGroups.SelectedRow.Cells[2].Text;
            this.secondMember.Text = this.searchGroups.SelectedRow.Cells[3].Text;
            this.thirdMember.Text = this.searchGroups.SelectedRow.Cells[4].Text;
            this.fourthMember.Text = this.searchGroups.SelectedRow.Cells[5].Text;
            this.fithMember.Text = this.searchGroups.SelectedRow.Cells[6].Text;
            this.sixthMember.Text = this.searchGroups.SelectedRow.Cells[7].Text;
            this.GroupID.Text = this.searchGroups.SelectedRow.Cells[8].Text;
            this.idMainMember.Text = this.searchGroups.SelectedRow.Cells[9].Text;
            this.idSecondMember.Text = this.searchGroups.SelectedRow.Cells[10].Text;
            this.idThirdMember.Text = this.searchGroups.SelectedRow.Cells[11].Text;
            this.idFourthMember.Text = this.searchGroups.SelectedRow.Cells[12].Text;
            this.idFithMember.Text = this.searchGroups.SelectedRow.Cells[13].Text;
            this.idSixthMember.Text = this.searchGroups.SelectedRow.Cells[14].Text;
        }

        protected void addMember(object sender, EventArgs e)
        {
            if (this.secondMemberDiv.Visible == false && this.mainMember.Text != "")
            {
                this.secondMemberDiv.Visible = true;
            }
            else if (this.thirdMemberDiv.Visible == false && this.secondMember.Text != "")
            {
                this.thirdMemberDiv.Visible = true;
                this.thirdMember.Text = "";
                this.addThirdMember.Visible = false;
            }
            else if (this.fourthMemberDiv.Visible == false && this.thirdMember.Text != "")
            {
                this.fourthMemberDiv.Visible = true;
                this.fourthMember.Text = "";
                this.addFourthMember.Visible = false;
            }
            else if (this.fithMemberDiv.Visible == false && this.fourthMember.Text != "")
            {
                this.fithMemberDiv.Visible = true;
                this.fithMember.Text = "";
                this.addFithMember.Visible = false;
            }
            else if (this.fithMember.Text != "")
            {
                this.sixthMemberDiv.Visible = true;
                this.sixthMember.Text = "";
                this.addSixthMember.Visible = false;
            }
        }

        protected void changeGroupForm(object sender, EventArgs e)
        {
            this.chooseGroupForm.Visible = false;
            this.editGroupForm.Visible = true;

            if (!this.thirdMember.Text.Equals("") && !this.thirdMember.Text.Equals("&nbsp;"))
                this.thirdMemberDiv.Visible = true;

            if (!this.fourthMember.Text.Equals("") && !this.fourthMember.Text.Equals("&nbsp;"))
                this.fourthMemberDiv.Visible = true;

            if (!this.fithMember.Text.Equals("") && !this.fithMember.Text.Equals("&nbsp;"))
                this.fithMemberDiv.Visible = true;

            if (!this.sixthMember.Text.Equals("") && !this.sixthMember.Text.Equals("&nbsp;"))
                this.sixthMemberDiv.Visible = true;
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

        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}