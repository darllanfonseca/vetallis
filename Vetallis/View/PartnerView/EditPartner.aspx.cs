using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.PartnerView
{
    public partial class EditPartner : System.Web.UI.Page
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

            this.partnerName.Enabled = false;
            this.datepicker.Enabled = false;
            this.address.Enabled = false;
            this.city.Enabled = false;
            this.postalCode.Enabled = false;
            this.website.Enabled = false;
            this.phoneNumber.Enabled = false;
            this.emailAddress.Enabled = false;
            this.faxNumber.Enabled = false;
            this.contactPerson.Enabled = false;
            this.updatePartnerBtt.Enabled = false;
        }

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (this.address.Text.Equals("&nbsp;"))
            {
                this.address.Text = "";
            }
            if (this.postalCode.Text.Equals("&nbsp;"))
            {
                this.postalCode.Text = "";
            }
            if (this.website.Text.Equals("&nbsp;"))
            {
                this.website.Text = "";
            }
            if (this.emailAddress.Text.Equals("&nbsp;"))
            {
                this.emailAddress.Text = "";
            }
            if (this.phoneNumber.Text.Equals("&nbsp;"))
            {
                this.phoneNumber.Text = "";
            }
            if (this.faxNumber.Text.Equals("&nbsp;"))
            {
                this.faxNumber.Text = "";
            }
            if (this.contactPerson.Text.Equals("&nbsp;"))
            {
                this.contactPerson.Text = "";
            }
        }

        protected void loadSelectedPartner(object sender, EventArgs e)
        {
            this.partnerName.Text = this.searchPartners.SelectedRow.Cells[1].Text;
            this.address.Text = this.searchPartners.SelectedRow.Cells[2].Text;
            this.city.Text = this.searchPartners.SelectedRow.Cells[3].Text;
            this.datepicker.Text = this.searchPartners.SelectedRow.Cells[5].Text;
            this.postalCode.Text = this.searchPartners.SelectedRow.Cells[7].Text;
            this.website.Text = this.searchPartners.SelectedRow.Cells[8].Text;
            this.emailAddress.Text = this.searchPartners.SelectedRow.Cells[9].Text;
            this.phoneNumber.Text = this.searchPartners.SelectedRow.Cells[10].Text;
            this.faxNumber.Text = this.searchPartners.SelectedRow.Cells[11].Text;
            this.contactPerson.Text = this.searchPartners.SelectedRow.Cells[12].Text;
            this.enableFieldsBtt.Enabled = true;
            this.enableFieldsBtt.Visible = true;
        }

        protected void enableFields(object sender, EventArgs e)
        {
            this.partnerName.Enabled = true;
            this.datepicker.Enabled = true;
            this.address.Enabled = true;
            this.city.Enabled = true;
            this.postalCode.Enabled = true;
            this.website.Enabled = true;
            this.phoneNumber.Enabled = true;
            this.emailAddress.Enabled = true;
            this.faxNumber.Enabled = true;
            this.contactPerson.Enabled = true;
            this.cancel.Enabled = true;
            this.updatePartnerBtt.Enabled = true;
            this.enableFieldsBtt.Visible = false;
            this.enableFieldsBtt.Enabled = false;
        }

        protected void updatePartner(object sender, EventArgs e)
        {
            Partner partner = new Partner();
            string databaseResponse = "";

            if (partnerName.Text.ToString() == "" || address.Text.ToString() == "" ||
                city.Text.ToString() == "" || postalCode.Text.ToString() == "")
            {
                this.editPartnerForm.Visible = false;
                this.response.Visible = true;

            }
            else
            {   //Loads the form content into the partner object
                partner.id = this.searchPartners.SelectedRow.Cells[4].Text;
                partner.dateJoined = this.searchPartners.SelectedRow.Cells[5].Text;
                partner.status = this.searchPartners.SelectedRow.Cells[6].Text;
                partner.name = partnerName.Text.ToString().Trim();
                partner.address = address.Text.ToString().Trim();
                partner.city = city.Text.ToString().Trim();
                partner.postalCode = postalCode.Text.ToString();
                partner.website = website.Text.ToString().Trim();
                partner.emailAddress = emailAddress.Text.ToString().Trim();
                partner.phoneNumber = phoneNumber.Text.ToString();
                partner.faxNumber = faxNumber.Text.ToString();
                partner.contactPerson = contactPerson.Text.ToString().Trim();

                this.clearAllFields();

                PartnerDAO partnerDAO = new PartnerDAO();
                databaseResponse = partnerDAO.updatePartner(partner);

                this.response.InnerText = databaseResponse;
                this.editPartnerForm.Visible = false;
                this.response.Visible = true;
            }

        }

        protected void clearAllFields()
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

        protected void returnEditPartner(object sender, EventArgs e)
        {
            this.editPartnerForm.Visible = true;
            this.response.Visible = false;
            this.enableFieldsBtt.Enabled = true;
            this.enableFieldsBtt.Visible = true;
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