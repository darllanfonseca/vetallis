using System;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.MemberView
{
    public partial class EditMember : System.Web.UI.Page
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

        protected void Page_LoadComplete(object sender, EventArgs e)
        {
            if (this.doctorName.Text.Equals("&nbsp;"))
            {
                this.doctorName.Text = "";
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
            enableFields();
        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.accountNumber.Text = this.searchMembers.SelectedRow.Cells[1].Text;
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.address.Text = this.searchMembers.SelectedRow.Cells[3].Text;
            this.city.Text = this.searchMembers.SelectedRow.Cells[4].Text;
            this.province.SelectedValue = this.searchMembers.SelectedRow.Cells[5].Text;
            this.datepicker.Text = this.searchMembers.SelectedRow.Cells[8].Text;
            this.doctorName.Text = this.searchMembers.SelectedRow.Cells[10].Text;
            this.region.Text = this.searchMembers.SelectedRow.Cells[11].Text;
            this.postalCode.Text = this.searchMembers.SelectedRow.Cells[12].Text;
            this.website.Text = this.searchMembers.SelectedRow.Cells[13].Text;
            this.emailAddress.Text = this.searchMembers.SelectedRow.Cells[14].Text;
            this.phoneNumber.Text = this.searchMembers.SelectedRow.Cells[15].Text;
            this.faxNumber.Text = this.searchMembers.SelectedRow.Cells[16].Text;
            this.contactPerson.Text = this.searchMembers.SelectedRow.Cells[17].Text;
            this.enableFieldsBtt.Visible = true;
            this.enableFieldsBtt.Enabled = true;
            this.errorDiv.Visible = false;
            this.disableFields();
        }

        protected void disableFields()
        {
            this.accountNumber.Enabled = false;
            this.memberName.Enabled = false;
            this.datepicker.Enabled = false;
            this.address.Enabled = false;
            this.doctorName.Enabled = false;
            this.city.Enabled = false;
            this.province.Enabled = false;
            this.postalCode.Enabled = false;
            this.website.Enabled = false;
            this.phoneNumber.Enabled = false;
            this.emailAddress.Enabled = false;
            this.faxNumber.Enabled = false;
            this.contactPerson.Enabled = false;
            this.cancel.Enabled = true;
            this.enableFieldsBtt.Visible = true;
            this.enableFieldsBtt.Enabled = true;
        }

        protected void enableFields(object sender, EventArgs e)
        {
            this.accountNumber.Enabled = true;
            this.memberName.Enabled = true;
            this.datepicker.Enabled = true;
            this.address.Enabled = true;
            this.doctorName.Enabled = true;
            this.city.Enabled = true;
            this.province.Enabled = true;
            this.postalCode.Enabled = true;
            this.website.Enabled = true;
            this.phoneNumber.Enabled = true;
            this.emailAddress.Enabled = true;
            this.faxNumber.Enabled = true;
            this.contactPerson.Enabled = true;
            this.cancel.Enabled = true;
            this.enableFieldsBtt.Visible = false;
            this.enableFieldsBtt.Enabled = false;
        }

        protected void enableFields()
        {
            this.accountNumber.Enabled = true;
            this.memberName.Enabled = true;
            this.datepicker.Enabled = true;
            this.address.Enabled = true;
            this.doctorName.Enabled = true;
            this.city.Enabled = true;
            this.province.Enabled = true;
            this.postalCode.Enabled = true;
            this.website.Enabled = true;
            this.phoneNumber.Enabled = true;
            this.emailAddress.Enabled = true;
            this.faxNumber.Enabled = true;
            this.contactPerson.Enabled = true;
            this.cancel.Enabled = true;
            this.enableFieldsBtt.Visible = false;
            this.enableFieldsBtt.Enabled = false;
        }

        protected void updateMember(object sender, EventArgs e)
        {
            this.enableFieldsBtt.Visible = false;

            Member member = new Member();
            string databaseResponse = "";
            MemberDAO memberDAO = new MemberDAO();

            if (this.searchMembers.SelectedIndex == -1)
            {
                this.errorMsg.Text = "Select one member to be updated.";
                this.errorDiv.Visible = true;
            }
            else
            {

                if (accountNumber.Text.ToString() == "" || memberName.Text.ToString() == "" || this.datepicker.Text.Equals("") || address.Text.ToString() == "" ||
                    city.Text.ToString() == "" || province.SelectedValue.ToString() == "Select..." || postalCode.Text.ToString() == "")
                {
                    this.errorMsg.Text = "One or more of the required fields are blank!";
                    this.errorDiv.Visible = true;
                }

                else
                {
                    if (memberDAO.alreadyExists(this.accountNumber.Text))
                    {
                        this.errorMsg.Text = "This account number already exists. Please choose another one.";
                    }
                    else
                    {
                        //Loads the form content into the member object
                        member.id = this.searchMembers.SelectedRow.Cells[6].Text;
                        member.idGroup = this.searchMembers.SelectedRow.Cells[7].Text;
                        member.accountNumber = accountNumber.Text.ToString().Trim();
                        member.dateJoined = this.datepicker.Text;
                        member.doctor = doctorName.Text.ToString().Trim();
                        member.name = memberName.Text.ToString().Trim();
                        member.address = address.Text.ToString().Trim();
                        member.city = city.Text.ToString().Trim();
                        member.province = province.SelectedItem.ToString();
                        member.region = region.Text.ToString();
                        member.postalCode = postalCode.Text.ToString();
                        member.website = website.Text.ToString().Trim();
                        member.emailAddress = emailAddress.Text.ToString().Trim();
                        member.phoneNumber = phoneNumber.Text.ToString();
                        member.faxNumber = faxNumber.Text.ToString();
                        member.contactPerson = contactPerson.Text.ToString().Trim();
                        member.dateLastActivated = this.datepicker.Text;

                        //Sends the member object to the updateMember method in MemberDAO..
                        databaseResponse = memberDAO.updateMember(member);

                        clearAllFields();
                        this.responseText.Text = databaseResponse;
                        this.editMemberForm.Visible = false;
                        this.response.Visible = true;
                    }
                }
            }
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

        protected void returnEditMember(object sender, EventArgs e)
        {
            this.editMemberForm.Visible = true;
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
