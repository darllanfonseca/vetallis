using System;
using System.Collections.Generic;
using System.Data;
using System.Web.Security;
using Vetallis.Business;
using Vetallis.DAO;

namespace Vetallis.View.RebateView
{
    public partial class EditCE : System.Web.UI.Page
    {
        CEDAO ceDAO;
        CE ce;

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

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.memberID.Text = this.searchMembers.SelectedRow.Cells[6].Text;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void loadSelectedCE(object sender, EventArgs e)
        {
            this.editionDiv.Visible = false;
            this.chooseDiv.Visible = false;
            this.selectedCEDiv.Visible = true;

            this.selectedMemberName2.Text = this.searchMembers.SelectedRow.Cells[2].Text;
            this.datepicker.Text = this.CEResults.SelectedRow.Cells[1].Text.Substring(0, 10);
            this.CEID.Text = this.CEResults.SelectedRow.Cells[5].Text;
            this.numberOfSeats.Text = this.CEResults.SelectedRow.Cells[3].Text;
            this.selectYear2.Text = this.CEResults.SelectedRow.Cells[2].Text.Substring(0, 4);
        }

        protected void goToEditionDiv(object sender, EventArgs e)
        {
            if (this.selectYear.Text.Equals("...") || this.memberName.Text.Equals(""))
            {
                this.response1.Text = "Please select one Member and the Rebate Year in order to proceed.";
            }
            else
            {
                this.response1.Text = "";

                ceDAO = new CEDAO();
                List<CE> ceList = ceDAO.getListOfCE(this.memberID.Text, this.selectYear.Text + "-01-01");

                if (ceList != null)
                {
                    System.Data.DataTable tbl = new DataTable();
                    DataColumn col = new DataColumn("Event Date");
                    tbl.Columns.Add(col);
                    col = new DataColumn("Rebate Year");
                    tbl.Columns.Add(col);
                    col = new DataColumn("Number of Seats");
                    tbl.Columns.Add(col);
                    col = new DataColumn("Member ID");
                    tbl.Columns.Add(col);
                    col = new DataColumn("CE ID");
                    tbl.Columns.Add(col);

                    foreach (CE ce in ceList)
                    {
                        DataRow dr = tbl.NewRow();
                        dr["Event Date"] = ce.eventDate.Substring(0, 10);
                        dr["Rebate Year"] = ce.year.Substring(0, 4);
                        dr["Number of Seats"] = ce.numberOfSeats;
                        dr["Member ID"] = ce.memberID;
                        dr["CE ID"] = ce.id;

                        tbl.Rows.Add(dr);
                    }

                    CEResults.DataSource = tbl;
                    CEResults.DataBind();

                    ViewState.Add("TBL", tbl);

                    this.selectedMemberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
                    this.chooseDiv.Visible = false;
                    this.editionDiv.Visible = true;
                }
                else
                {
                    this.response1.Text = "There is no results for the given parameters.";
                }


            }
        }

        protected void returnToeditionDiv(object sender, EventArgs e)
        {
            this.selectedCEDiv.Visible = false;
            this.editionDiv.Visible = true;
        }

        protected void returnTochooseDiv(object sender, EventArgs e)
        {
            this.chooseDiv.Visible = true;
            this.editionDiv.Visible = false;
        }

        protected void insertEditedCE(object sender, EventArgs e)
        {
            if (this.datepicker.Text.Equals("") || this.numberOfSeats.Text.Equals("") || 
                this.selectYear2.Text.Equals("") || this.selectYear2.Text.Equals("..."))
            {
                this.errorMsg.Text = "Please fill all the 3 required fields.";
            }
            else
            {
            ceDAO = new CEDAO();
            ce = new CE();

            ce.id = this.CEResults.SelectedRow.Cells[5].Text;
            ce.memberID = this.CEResults.SelectedRow.Cells[4].Text;
            ce.year = this.selectYear2.Text;
            ce.numberOfSeats = this.numberOfSeats.Text;
            ce.eventDate = this.datepicker.Text;
            string user = this.Page.User.Identity.Name.ToString();

            string result = ceDAO.editCE(ce, user);

            if (result.Equals("Success")){
                this.DB_Response.Text = "The CE data was successfully updated on the Database.";
                this.errorMsg.Text = "";
            }else
            {
                this.errorMsg.Text = "Nothing was commited. Some error has occurred.";
                this.DB_Response.Text = "";
            }
                

            }     


        }

        protected void logout(object sender, EventArgs e)
        {
            FormsAuthentication.SignOut();
            Response.Redirect("~/Login.aspx");
        }
    }
}