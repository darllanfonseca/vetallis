﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.PartnerView
{
    public partial class EditPartner : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
                partner.idPartner = this.searchPartners.SelectedRow.Cells[4].Text;
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

    }
}