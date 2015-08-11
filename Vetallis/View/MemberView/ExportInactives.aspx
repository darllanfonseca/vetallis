﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ExportInactives.aspx.cs" Inherits="Vetallis.View.MemberView.ExportInactives" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Export List of Inactive Members</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
</head>
<body>
    <form id="mainForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header"></div>
                <div class="section">
                    <div id="fieldSection">
                        <div style="position: absolute; top: 50%; left: 50%; width: 300px; height: 500px; margin-left: -100px; margin-top: -250px; text-align: left;">
                            Select the fields to be included in the results:
                            <br />
                            <br />
                            <asp:CheckBoxList runat="server" ID="selectResultFields" OnSelectedIndexChanged="selectFieldsFromDB">
                                <asp:ListItem Text="NAME"></asp:ListItem>
                                <asp:ListItem Text="ACCOUNT_NUMBER"></asp:ListItem>
                                <asp:ListItem Text="DATE_JOINED"></asp:ListItem>
                                <asp:ListItem Text="DATE_REMOVED"></asp:ListItem>
                                <asp:ListItem Text="DATE_LAST_ACTIVATED"></asp:ListItem>
                                <asp:ListItem Text="DOCTOR"></asp:ListItem>
                                <asp:ListItem Text="ADDRESS"></asp:ListItem>
                                <asp:ListItem Text="CITY"></asp:ListItem>
                                <asp:ListItem Text="PROVINCE"></asp:ListItem>
                                <asp:ListItem Text="REGION"></asp:ListItem>
                                <asp:ListItem Text="POSTAL_CODE"></asp:ListItem>
                                <asp:ListItem Text="WEBSITE"></asp:ListItem>
                                <asp:ListItem Text="EMAIL_ADDRESS"></asp:ListItem>
                                <asp:ListItem Text="PHONE_NUMBER"></asp:ListItem>
                                <asp:ListItem Text="FAX"></asp:ListItem>
                                <asp:ListItem Text="CONTACT_PERSON"></asp:ListItem>
                            </asp:CheckBoxList>
                            <br />
                            <br />
                            <asp:Button runat="server" ID="Btt" OnClick="selectFieldsFromDB" Text="Export Results" />
                            <br />
                            <br />
                            <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage" />
                        </div>
                    </div>
                    <asp:Label runat="server" ID="response"></asp:Label>
                </div>
            </div>
        </div>
    </form>

    <form id="responseForm" visible="false" runat="server">
        <div class="all">
            <div class="container">
                <div class="section">
                    <div class="fieldSection">
                        <div runat="server" style="position: absolute; top: 25%; left: 25%;">
                            <asp:Label runat="server" ID="responseText"></asp:Label><br /><br />
                            <asp:Button runat="server" Text="Return" OnClick="returnToMainPage"/>
                        </div>
                    </div>
                </div>
            </div>
         </div>   
    </form>
</body>
</html>
