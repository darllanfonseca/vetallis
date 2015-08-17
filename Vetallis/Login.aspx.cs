using System;
using Vetallis.Business;
using Vetallis.DAO;
using System.Data;
using System.Configuration;
using System.Data.SqlClient;
using System.Web.Security;

namespace Vetallis
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void userLogin(object sender, EventArgs e)
        {

            LoginDAO login = new LoginDAO();
            Users user = new Users();
            user = login.getUsers(this.userName.Text);

            if (user.password.Equals(this.passWord.Text))
            {
                FormsAuthentication.RedirectFromLoginPage(userName.Text, true);
            }
            else
            {
                this.errorMsg.InnerText = "User/Password incorrect.";
            }


        }

    }
}