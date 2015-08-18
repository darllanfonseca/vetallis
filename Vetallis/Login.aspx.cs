using System;
using Vetallis.Business;
using Vetallis.DAO;
using System.Web.Security;
using System.Collections.Generic;

namespace Vetallis
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void userLogin(object sender, EventArgs e)
        {
            LoginDAO loginDAO = new LoginDAO();
            List<Users> users = new List<Users>();
            users = loginDAO.getAllUsers();

            bool success = false;

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (this.userName.Text.Equals(users[i].name) 
                        && this.passWord.Text.Equals(users[i].password))
                    {
                        i = users.Count;
                        success = true;
                    }
                }

                if (success)
                {
                    FormsAuthentication.RedirectFromLoginPage(userName.Text, true);
                }
                else
                {
                    this.errorMsg.InnerText = "User/Password incorrect.";
                }
            }
            else { this.errorMsg.InnerText = "DATABASE ERROR."; }

        }

    }
}