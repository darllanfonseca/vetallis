using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Security;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.RebateView
{
    public partial class SingleRebate : System.Web.UI.Page
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

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void loadChosenItems(object sender, EventArgs e)
        {            
            this.selectedYear.Text = this.selectYear.SelectedValue;
            this.selectedCategory.Text = this.selectCategory.SelectedValue;
            this.selectedAmount.Text = this.rebateAmount.Text;

            if (this.isDeliveredByPartner.Checked)
            {
                this.selectedDeliveredByPartner.Text = "Partner";
            }
            else
            {
                this.selectedDeliveredByPartner.Text = "Vet Alliance";
            }
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        { 
            this.selectedMember.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.ID_SELECTED_MEMBER.Text = this.searchMembers.SelectedRow.Cells[6].Text;
        }

        protected void loadSelectedPartner(object sender, EventArgs e)
        {
            this.selectedPartner.Text = this.searchPartners.SelectedRow.Cells[1].Text;
            this.ID_SELECTED_PARTNER.Text = this.searchPartners.SelectedRow.Cells[3].Text;
        }

        protected void insertRebateData(object sender, EventArgs e)
        {
            RebateDAO rebateDAO = new RebateDAO();
            Rebate rebate = new Rebate();

            rebate.idMember = this.ID_SELECTED_MEMBER.Text;
            rebate.idPartner = this.ID_SELECTED_PARTNER.Text;
            rebate.year = this.selectedYear.Text + "-01-01";
            rebate.type = this.selectedCategory.Text;
            rebate.quantity = this.selectedAmount.Text;
            if(this.selectedDeliveredByPartner.Text.Equals("Partner")){
                rebate.isDeliveredByPartner = true;
            }
            else
            {
                rebate.isDeliveredByPartner = false;
            }
            rebate.dateModified = System.DateTime.Today.ToShortDateString();
            rebate.modifiedBy = Page.User.Identity.Name;

            string result = rebateDAO.insertSingleRebateData(rebate);

            this.mainForm.Visible = false;
            this.response.Visible = true;
            this.responseText.Text = result;
        }

    }
}