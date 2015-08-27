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

            this.group_ID.Enabled = false;
            this.group_ID.Visible = false;
            this.ID_GROUP_DIV.Visible = false;
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
            this.isAGroup.SelectedIndex = 0;
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
            this.openChooseGroupForm.Visible = false;
        }

        protected void clearAllFields()
        {
            this.isAGroup.SelectedIndex = 0;
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
            this.openChooseGroupForm.Visible = false;
        }

        protected void insertNewMember(object sender, EventArgs e)
        {
            MemberDAO memberDAO = new MemberDAO();

            if (memberDAO.alreadyExists(this.accountNumber.Text))
            {
                this.errorMsg.Text = "This Account Number Already Exists. Please choose another one.";
            }
            else
            {
                member.idGroup = this.group_ID.Text;
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

                this.insertNewMemberForm.Visible = false;
                this.chooseGroup.Visible = false;
                this.response.Visible = true;
                this.responseText.Text = memberDAO.insertNewMember(member);
            }
            
        }

        protected void enableChooseGroup(object sender, EventArgs e)
        {
            if (this.isAGroup.SelectedValue == "No")
            {
                member.idGroup = "0";
            }
            else if (this.isAGroup.SelectedValue == "Yes")
            {
                this.openChooseGroupForm.Visible = true;
            }          
        }

        protected void changeForms(object sender, EventArgs e)
        {
            this.chooseGroup.Visible = true;
            this.insertNewMemberForm.Visible = false;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void loadSelectedGroup(object sender, EventArgs e)
        {
            this.chooseGroup.Visible = false;
            this.insertNewMemberForm.Visible = true;
            this.group_ID.Text = searchGroups.SelectedRow.Cells[3].Text;
            this.openChooseGroupForm.Enabled = false;
            this.openChooseGroupForm.Visible = false;
            this.group_ID.Visible = true;
            this.ID_GROUP_DIV.Visible = true;
            this.isAGroup.Enabled = false;
        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}