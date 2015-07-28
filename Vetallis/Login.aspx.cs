using System;

namespace Vetallis
{
    public partial class Login : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {            
        }

        protected void userLogin(object sender, EventArgs e)
        {
            if (this.userName.Text == "Darllan" && this.passWord.Text == "DrBr23++")
            {
                Response.Redirect("~/Default.aspx");
            }
            else
            {               
                this.errorMsg.InnerText = "User/Password incorrect";
                

            }
        //  ScriptManager.RegisterStartupScript(this.Page, this.GetType(), "script", "setTimeout();", true);
        }

    }
}