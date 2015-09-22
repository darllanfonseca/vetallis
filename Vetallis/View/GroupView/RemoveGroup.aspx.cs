using System;
using System.Web.Security;
using Vetallis.DAO;

namespace Vetallis.View.GroupView
{
    public partial class RemoveGroup : System.Web.UI.Page
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
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void returnToMainForm(object sender, EventArgs e)
        {
            this.chooseGroupForm.Visible = true;
            this.response.Visible = false;
            this.groupNameChosen.Text = "";
            this.mainMemberChosen.Text = "";
            clearAllFields();
        }

        protected void loadSelectedGroup(object sender, EventArgs e)
        {
            this.groupNameChosen.Text = this.searchGroups.SelectedRow.Cells[1].Text;
            this.mainMemberChosen.Text = this.searchGroups.SelectedRow.Cells[2].Text;
            this.idGroupChosen.Text = this.searchGroups.SelectedRow.Cells[3].Text;
        }

        protected void clearAllFields()
        {

        }

        protected void removeGroup(object sender, EventArgs e)
        {
            GroupsDAO groupsDAO = new GroupsDAO();

            string result = groupsDAO.removeGroup(this.idGroupChosen.Text);

            this.chooseGroupForm.Visible = false;
            this.response.Visible = true;
            this.responseText.Text = result;
        }

    }
}