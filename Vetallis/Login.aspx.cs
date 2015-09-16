using System;
using Vetallis.Business;
using Vetallis.DAO;
using System.Web.Security;
using System.Collections.Generic;
using System.Web;

namespace Vetallis
{
    public partial class Login : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void userLogin(object sender, EventArgs e)
        {
            string ipAddress = System.Net.Dns.GetHostEntry(System.Net.Dns.GetHostName()).AddressList.GetValue(2).ToString();           

            bool status = true;

            LoginDAO loginDAO = new LoginDAO();
            List<Users> users = new List<Users>();
            users = loginDAO.getAllUsers();

            bool success = false;

            if (users != null)
            {
                for (int i = 0; i < users.Count; i++)
                {
                    if (this.userName.Text.Equals(users[i].name)
                       && this.passWord.Text.Equals(users[i].password)
                        && users[i].status.Equals("ACTIVE"))
                    {
                        i = users.Count;
                        success = true;
                    }
                    else if (users[i].status.Equals("INACTIVE"))
                    {
                        status = false;
                    }
                }

                if (success)
                {
                    loginDAO.registerLogin(this.userName.Text, ipAddress);
                    FormsAuthentication.RedirectFromLoginPage(userName.Text, true);
                }
                else if (!status)
                {
                    this.errorMsg.InnerText = "This User is Inactive.";
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