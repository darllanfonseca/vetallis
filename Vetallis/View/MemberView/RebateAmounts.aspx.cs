using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Vetallis.View.MemberView
{
    public partial class RebateAmounts : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void loadSelectedMember(object sender, EventArgs e)
        {
            this.memberName.Text = this.searchMembers.SelectedRow.Cells[2].Text;
        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Response.Redirect("~/Default.aspx");
        }

        protected void exportResults(object sender, EventArgs e)
        {
            string memberId = this.searchMembers.SelectedRow.Cells[6].Text;

            string query = @"SELECT MEMBER.NAME AS Member, PARTNER.NAME AS Partner,
                REBATE.QUANTITY as Amount, REBATE.YEAR as Year, rebate.CATEGORY as Category, rebate.IS_DELIVERED_BY_PARTNER as Delivered_By_Partner
                FROM REBATE JOIN MEMBER ON REBATE.ID_MEMBER = " + memberId + " JOIN PARTNER ON ID_PARTNER = ";

            List<String> partnerList = new List<string>();

            foreach (ListItem item in this.partners.Items)
            {
                if (item.Selected)
                {
                    partnerList.Add(item.Value);
                }
                else
                {
                    // Item is not selected, do something else.
                }
            }
            // Join the string together using the ; delimiter.
            query += String.Join(" OR ID_PARTNER = ", partnerList.ToArray());

            query += " AND YEAR = '" + this.rebateYear.SelectedValue.ToString() + "-01-01'";

            string meuDeus = "isso aqui ta osso!";
        }
    }
}