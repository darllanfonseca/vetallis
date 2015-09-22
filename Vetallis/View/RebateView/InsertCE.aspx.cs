using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.RebateView
{
    public partial class InsertCE : System.Web.UI.Page
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

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.memberID.Text = this.searchMembers.SelectedRow.Cells[6].Text;
        }

        protected void insertCEData(object sender, EventArgs e)
        {
            //--------CONSISTENCY-----------------

            if (this.memberID.Text.Equals("") || this.datepicker.Text.Equals("") || this.numberOfSeats.Text.Equals("") || this.selectYear.SelectedIndex == 0)
            {
                this.errorDiv.Visible = true;
                this.response.Visible = false;
                this.errorMsg.Text = "Please fill all required fields.";
            }

            //------------------------------------

            else
            {
                string user = Page.User.Identity.Name;
                CEDAO ceDAO = new CEDAO();
                CE ce = new CE();

                ce.memberID = this.memberID.Text;
                ce.numberOfSeats = this.numberOfSeats.Text;
                ce.year = this.selectYear.Text + "-01-01";
                ce.eventDate = this.datepicker.Text;

                this.response.Visible = true;
                this.errorDiv.Visible = false;
                this.DBMsg.Text = ceDAO.insertCE(ce, user);
            }
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