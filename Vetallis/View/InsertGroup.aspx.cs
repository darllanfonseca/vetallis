using System;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View
{
    public partial class InsertGroup : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void clearAllFields(object sender, EventArgs e)
        {
            this.mainMember.Text = "";
            this.groupName.Text = "";
        }

        protected void clearAllFields()
        {
            this.mainMember.Text = "";
            this.groupName.Text = "";
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void insertNewGroup(object sender, EventArgs e)
        {
            //Add DAO code
            Groups group = new Groups();
            GroupsDAO groupDAO = new GroupsDAO();
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {

        }
    }
}