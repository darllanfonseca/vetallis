using System;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View
{
    public partial class EditMember : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            this.isAGroup.SelectedIndex = 0;
            this.isAGroup.Enabled = false;
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
            this.updateMemberBtt.Enabled = false;
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
            this.editMemberForm.Visible = false;
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
            this.isAGroup.SelectedIndex = 0;
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
            this.openChooseGroupForm.Visible = false;
        }

        protected void enableFields(object sender, EventArgs e)
        {
            this.isAGroup.SelectedIndex = 0;
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
            this.updateMemberBtt.Enabled = true;
            this.enableFieldsBtt.Visible = false;
            this.enableFieldsBtt.Enabled = false;
        }

        protected void enableFields()
        {
            this.isAGroup.SelectedIndex = 0;
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
            this.updateMemberBtt.Enabled = true;
            this.enableFieldsBtt.Visible = false;
            this.enableFieldsBtt.Enabled = false;
        }

        protected void updateMember(object sender, EventArgs e)
        {
            Member member = new Member();
            string isgroup = "";
            string databaseResponse = "";


            if (this.isAGroup.SelectedIndex == 0 || this.isAGroup.SelectedIndex == 2)
            {
                isgroup = "No";
            }
            else { isgroup = this.isAGroup.SelectedItem.ToString(); }

            //validation of the fields
            switch (isgroup)
            {

                case "Yes":
                    {
                        if (accountNumber.Text.ToString() == "" || memberName.Text.ToString() == "" || address.Text.ToString() == "" ||
                            city.Text.ToString() == "" || province.SelectedItem.ToString() == "" || postalCode.Text.ToString() == "")
                        {
                            this.response.InnerHtml = "<div id=\"All2\" runat=\"server\"><div runat=\"server\" id=\"message\" style=\"position: absolute; top: 50%; left: 50%; width: 200px; height: 100px;\">TESTE InnerHtml</div></div>";
                            this.editMemberForm.Visible = false;
                            this.chooseGroup.Visible = false;
                            this.response.Visible = true;

                            break;
                        }
                        
                                   else
                                    {   //Loads the form content into the member object
                                        member.id = this.searchMembers.SelectedRow.Cells[6].Text;
                                        member.accountNumber = accountNumber.Text.ToString().Trim();
                                        member.idGroup = this.searchMembers.SelectedRow.Cells[7].Text;
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

                                        clearAllFields();

                                        //Sends the member object to the updateMember method in MemberDAO..
                                        MemberDAO memberDAO = new MemberDAO();
                                        databaseResponse = memberDAO.updateMember(member);

                                        this.response.InnerText = databaseResponse;
                                        this.editMemberForm.Visible = false;
                                        this.chooseGroup.Visible = false;
                                        this.response.Visible = true;
                                    }
                                } break;


                            case "No":
                                {
                                    if (accountNumber.Text.ToString() == "" || memberName.Text.ToString() == "" || address.Text.ToString() == "" ||
                                        city.Text.ToString() == "" || province.SelectedItem.ToString() == "" || postalCode.Text.ToString() == "")
                                    {
                                        this.editMemberForm.Visible = false;
                                        this.chooseGroup.Visible = false;
                                        this.response.Visible = true;
                                    }
                                    else
                                    {   //Loads the form content into the member object, BUT NOT THE ID_GROUP VALUE..
                                        member.id = this.searchMembers.SelectedRow.Cells[6].Text;
                                        member.idGroup = "0";
                                        member.accountNumber = accountNumber.Text.ToString().Trim();
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

                                        clearAllFields();

                                        MemberDAO memberDAO = new MemberDAO();
                                        databaseResponse = memberDAO.updateMember(member);

                                        this.response.InnerText = databaseResponse;
                                        this.editMemberForm.Visible = false;
                                        this.chooseGroup.Visible = false;
                                        this.response.Visible = true;
                                    }
                                } break; 
                    } //end of switch statement..

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

        
    }        
}
