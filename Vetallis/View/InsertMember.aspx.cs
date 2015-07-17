using System;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View
{
    public partial class InsertMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
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
            Member member = new Member();

            member.accountNumber = this.accountNumber.Text.Trim();
            //  member.idGroup = 
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

            MemberDAO memberDAO = new MemberDAO();
            this.response.InnerText = memberDAO.insertNewMember(member);
            this.insertNewMemberForm.Visible = false;
            this.chooseGroup.Visible = false;
            this.response.Visible = true;
        }

        protected void enableChooseGroup(object sender, EventArgs e)
        {
            if (this.isAGroup.SelectedValue == "Yes")
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
    }
}