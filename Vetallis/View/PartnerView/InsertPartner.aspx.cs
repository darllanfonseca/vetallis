using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.PartnerView
{
    public partial class InsertPartner : System.Web.UI.Page
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

        protected void clearAllFields(object sender, EventArgs e)
        {
            this.partnerName.Text = "";
            this.datepicker.Text = "";
            this.address.Text = "";
            this.city.Text = "";
            this.postalCode.Text = "";
            this.website.Text = "";
            this.phoneNumber.Text = "";
            this.emailAddress.Text = "";
            this.faxNumber.Text = "";
            this.contactPerson.Text = "";
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void insertNewPartner(object sender, EventArgs e)
        {
            Partner partner = new Partner();

            partner.name = this.partnerName.Text.Trim();
            partner.dateJoined = this.datepicker.Text;
            partner.address = this.address.Text.Trim();
            partner.city = this.city.Text.Trim();
            partner.postalCode = this.postalCode.Text.ToUpper();
            partner.website = this.website.Text.Trim();
            partner.emailAddress = this.emailAddress.Text.Trim();
            partner.phoneNumber = this.phoneNumber.Text;
            partner.faxNumber = this.faxNumber.Text;
            partner.contactPerson = this.contactPerson.Text.Trim();

            PartnerDAO partnerDAO = new PartnerDAO();
            this.response.InnerText = partnerDAO.insertNewPartner(partner);
            this.insertNewPartnerForm.Visible = false;
            this.response.Visible = true;
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}