﻿using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Vetallis.Business;
using Vetallis.DAO;
using Vetallis.FunctionalClasses;

namespace Vetallis.View.MemberView
{
    public partial class ExportInactives : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void selectFieldsFromDB(object sender, EventArgs e)
        {
            string query = "SELECT ";

            // Create the list to store.
            List<String> fields = new List<string>();
            // Loop through each item.
            foreach (ListItem item in this.selectResultFields.Items)
            {
                if (item.Selected)
                {
                    // If the item is selected, add the value to the list.
                    fields.Add(item.Value);
                }
                else
                {
                    // Item is not selected, do something else.
                }
            }
            // Join the string together using the ; delimiter.
            query += String.Join(", ", fields.ToArray());

            query += " FROM MEMBER WHERE STATUS='INACTIVE' ORDER BY NAME";

            CreateExcelFile.CreateExcelDocument(ExportExcelDAO.getDataTable(query), "InactiveMembers.xlsx", Response);

        }

        protected void returnToMainPage(object sender, EventArgs e)
        {
            Server.Transfer("~/Default.aspx");
        }
    }
}