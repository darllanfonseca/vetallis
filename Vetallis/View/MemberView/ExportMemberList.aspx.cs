using System;
using System.Collections.Generic;
using System.Web.Security;
using System.Web.UI.WebControls;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.MemberView
{
    public partial class ExportMemberList : System.Web.UI.Page
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

        protected void selectFieldsFromDB(object sender, EventArgs e)
        {
            string query = "SELECT ";

            // Create the list to store.
            List<String> fields = new List<string>();
            // Loop through each item.
            foreach (ListItem item in this.selectResultFields.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    fields.Add(item.Value);
                }
                else
                {
                    // Item is not selected, do something else.
                }
            }
            // Join the string together using the ; delimiter.
            query += String.Join(", ", fields.ToArray());

            query += " FROM MEMBER WHERE STATUS='ACTIVE' ORDER BY NAME";

            ExportExcel export = new ExportExcel();

            this.mainForm.Visible = false;
            this.responseForm.Visible = true;
            this.responseText.Text = export.exportData(query);            

        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}