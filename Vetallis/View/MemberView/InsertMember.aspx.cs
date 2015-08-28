using System;
using System.Web.Security;
using Vetallis.DAO;

namespace Vetallis.View.MemberView
{
    public partial class InsertMember : System.Web.UI.Page
    {
        Vetallis.Business.Member member = new Vetallis.Business.Member();

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

        protected void changeRegion(object sender, EventArgs e)
        {
            switch (province.SelectedValue)
            {
                case "Select...":
                    region.Text = "";
                    break;

                case "AB":
                case "BC":
                case "MB":
                case "NT":
                case "NU":
                case "QC":
                case "SK":
                case "YT":
                    region.Text = "WESTERN";
                    break;

                case "NB":
                case "NL":
                case "NS":
                case "PE":
                    region.Text = "ATLANTIC";
                    break;

                case "ON":
                    region.Text = "CENTRAL";
                    break;
            }           
        }

        protected void clearAllFields(object sender, EventArgs e)
        {
            this.accountNumber.Text = "";
            this.memberName.Text = "";
            this.datepicker.Text = "";
            this.address.Text = "";
            this.doctorName.Text = "";
            this.city.Text = "";
            this.province.SelectedIndex = 0;
            this.region.Text = "";
            this.postalCode.Text = "";
            this.website.Text = "";
            this.phoneNumber.Text = "";
            this.emailAddress.Text = "";
            this.faxNumber.Text = "";
            this.contactPerson.Text = "";
        }

        protected void clearAllFields()
        {
            this.accountNumber.Text = "";
            this.memberName.Text = "";
            this.datepicker.Text = "";
            this.address.Text = "";
            this.doctorName.Text = "";
            this.city.Text = "";
            this.province.SelectedIndex = 0;
            this.region.Text = "";
            this.postalCode.Text = "";
            this.website.Text = "";
            this.phoneNumber.Text = "";
            this.emailAddress.Text = "";
            this.faxNumber.Text = "";
            this.contactPerson.Text = "";
        }

        protected void insertNewMember(object sender, EventArgs e)
        {
            MemberDAO memberDAO = new MemberDAO();

            if (memberDAO.alreadyExists(this.accountNumber.Text))
            {
                this.errorMsg.Text = "This account number already exists. Please choose another one.";
            }
            else
            {
                member.accountNumber = this.accountNumber.Text.Trim();
                member.doctor = this.doctorName.Text.Trim();
                member.name = this.memberName.Text.Trim();
                member.dateJoined = this.datepicker.Text;
                member.address = this.address.Text.Trim();
                member.city = this.city.Text.Trim();
                member.province = this.province.SelectedValue;
                member.region = this.region.Text;
                member.postalCode = this.postalCode.Text.ToUpper();
                member.website = this.website.Text.Trim();
                member.emailAddress = this.emailAddress.Text.Trim();
                member.phoneNumber = this.phoneNumber.Text;
                member.faxNumber = this.faxNumber.Text;
                member.contactPerson = this.contactPerson.Text.Trim();
                member.dateModified = System.DateTime.Today.ToShortDateString();
                member.dateCreated = System.DateTime.Today.ToShortDateString();
                member.modifiedBy = this.Page.User.Identity.Name.ToString();
                member.dateLastActivated = System.DateTime.Today.ToShortDateString();

                this.insertNewMemberForm.Visible = false;
                this.response.Visible = true;
                this.responseText.Text = memberDAO.insertNewMember(member);
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