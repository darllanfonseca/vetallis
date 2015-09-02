using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.PartnerView
{
    public partial class RemovePartner : System.Web.UI.Page
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

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void removePartner(object sender, EventArgs e)
        {
            Partner partner = new Partner();

            partner.id = this.ID_PARTNER.Text;

            PartnerDAO partnerDAO = new PartnerDAO();
            this.removePartnerForm.Visible = false;
            this.responseForm.Visible = true;
            this.responseText.Text = partnerDAO.removePartner(partner);

        }

        protected void loadSelectedPartner(object sender, EventArgs e)
        {
            this.partnerName.Text = this.searchPartners.SelectedRow.Cells[1].Text;
            this.ID_PARTNER.Text = this.searchPartners.SelectedRow.Cells[2].Text;
        }
    }
}