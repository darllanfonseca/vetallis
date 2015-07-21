<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditMember.aspx.cs" Inherits="Vetallis.View.EditMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Edit a Member</title>
    <link rel="stylesheet" href="../CSS/RegForms.css" />
</head>
<body>
    <!-- Main Form -->
    <form id="editMemberForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">Fill out all the required fields and update the member</div>
                <div class="section">
                    <div class="fieldSection">
                        <div style="text-align: left; position: absolute; top: 15px; left: 415px; width: 160px; height: 50px;">
                            <b>Is a Group? *</b>
                            <asp:TextBox runat="server" Visible="false" ID="groupId"></asp:TextBox>
                            <asp:DropDownList runat="server" OnSelectedIndexChanged="enableChooseGroup" ID="isAGroup" Width="70px" AutoPostBack="True">
                                <asp:ListItem Text="Select..." />
                                <asp:ListItem Text="Yes" />
                                <asp:ListItem Text="No" />
                            </asp:DropDownList>
                            <asp:Button runat="server" Width="80px" Visible="false" ID="openChooseGroupForm" OnClick="changeForms" Text="Pick Group" AutoPostBack="True" />
                        </div>
                        <div style="text-align: right; position: absolute; top: 15px; right: 15px; width: 150px; height: 50px;">
                            <b>Account Number *</b>
                            <asp:TextBox runat="server" ID="accountNumber" Width="120px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 70px; left: 415px; width: 155px; height: 50px;">
                            <b>Member Name *</b>
                            <asp:TextBox runat="server" ID="memberName" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                            <b>Date Joined *</b>
                            <asp:TextBox runat="server" ID="datepicker" Width="120px">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 125px; left: 415px; width: 155px; height: 50px;">
                            <b>Address *</b>
                            <asp:TextBox runat="server" ID="address" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 180px; left: 415px; width: 150px; height: 50px;">
                            <b>Doctor Name</b>
                            <asp:TextBox runat="server" ID="doctorName" Width="250px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 180px; right: 15px; width: 160px; height: 50px;">
                            <b>City *</b>
                            <asp:TextBox runat="server" ID="city" Width="150px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 235px; left: 415px; width: 80px; height: 50px;">
                            <b>Province *</b>
                            <asp:DropDownList runat="server" Width="70px" AutoPostBack="True" ID="province" OnSelectedIndexChanged="changeRegion">
                                <asp:ListItem
                                    Text="Select..." />
                                <asp:ListItem
                                    Text="AB" />
                                <asp:ListItem
                                    Text="BC" />
                                <asp:ListItem
                                    Text="MB" />
                                <asp:ListItem
                                    Text="NB" />
                                <asp:ListItem
                                    Text="NL" />
                                <asp:ListItem
                                    Text="NT" />
                                <asp:ListItem
                                    Text="NS" />
                                <asp:ListItem
                                    Text="NU" />
                                <asp:ListItem
                                    Text="ON" />
                                <asp:ListItem
                                    Text="PE" />
                                <asp:ListItem
                                    Text="QC" />
                                <asp:ListItem
                                    Text="SK" />
                                <asp:ListItem
                                    Text="YT" />

                            </asp:DropDownList>
                        </div>
                        <div style="text-align: right; position: absolute; top: 235px; left: 615px; width: 150px; height: 50px;">
                            <b>Region</b>
                            <asp:TextBox runat="server" ID="region" Enabled="false" Width="150px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 235px; right: 15px; width: 160px; height: 50px;">
                            <b>Postal Code *</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="postalCode" Width="150px" MaxLength="6">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 290px; left: 415px; width: 200px; height: 50px;">
                            <b>Website</b>
                            <asp:TextBox runat="server" ID="website" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 290px; right: 15px; width: 160px; height: 50px;">
                            <b>Phone Number</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="phoneNumber" Width="150px" MaxLength="11">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 345px; left: 415px; width: 200px; height: 50px;">
                            <b>Email Address</b>
                            <asp:TextBox runat="server" ID="emailAddress" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 345px; right: 15px; width: 160px; height: 50px;">
                            <b>Fax Number</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="faxNumber" Width="150px" MaxLength="11">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 400px; left: 415px; width: 150px; height: 50px;">
                            <b>Contact Person</b>
                            <asp:TextBox runat="server" ID="contactPerson" Width="250px">                           
                            </asp:TextBox>
                        </div>
                        <div style="position: absolute; top: 460px; left: 415px; width: 100px; height: 50px;">
                            <asp:Button Height="25px" Width="100px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="enableFieldsBtt" OnClick="enableFields" Text="Enable Fields" AutoPostBack="True" />
                        </div>
                        <div style="position: absolute; top: 460px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="25px" Width="150px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" OnClick="returnToMainPage" AutoPostBack="True"/>
                        </div>
                        <div style="position: absolute; top: 510px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="150px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="updateMemberBtt" OnClick="updateMember" Text="Update Member" AutoPostBack="True" />
                        </div>


                        <div style="text-align: left; position: absolute; top: 510px; left: 415px; width: 300px; height: 20px;">
                            * indicates that the field is required.
                        </div>
                        <div style="position: absolute; top: 20px; left: 10px; width: 370px; overflow: scroll; bottom: 30px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchMembers" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedMember" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="Teste1">
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ACCOUNT_NUMBER" HeaderText="Account #" SortExpression="ACCOUNT_NUMBER">
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" SortExpression="ADDRESS" />
                                    <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                                    <asp:BoundField DataField="PROVINCE" HeaderText="PROVINCE" SortExpression="PROVINCE" />
                                    <asp:BoundField DataField="ID_MEMBER" HeaderText="ID_MEMBER" ReadOnly="True" SortExpression="ID_MEMBER" />
                                    <asp:BoundField DataField="ID_GROUP" HeaderText="ID_GROUP" SortExpression="ID_GROUP" />
                                    <asp:BoundField DataField="DATE_JOINED" HeaderText="DATE_JOINED" SortExpression="DATE_JOINED" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                                    <asp:BoundField DataField="DOCTOR" HeaderText="DOCTOR" SortExpression="DOCTOR" />
                                    <asp:BoundField DataField="REGION" HeaderText="REGION" SortExpression="REGION" />
                                    <asp:BoundField DataField="POSTAL_CODE" HeaderText="POSTAL_CODE" SortExpression="POSTAL_CODE" />
                                    <asp:BoundField DataField="WEBSITE" HeaderText="WEBSITE" SortExpression="WEBSITE" />
                                    <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="EMAIL_ADDRESS" SortExpression="EMAIL_ADDRESS" />
                                    <asp:BoundField DataField="PHONE_NUMBER" HeaderText="PHONE_NUMBER" SortExpression="PHONE_NUMBER" />
                                    <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                                    <asp:BoundField DataField="CONTACT_PERSON" HeaderText="CONTACT_PERSON" SortExpression="CONTACT_PERSON" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER]"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; left: 10px; width: 370px; top: 530px; color: #707070; font-family: Calibri; font-size: 13px; text-align: left;">You can sort the results by clicking on the name of the columns.</div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Form to choose the Group -->
    <form id="chooseGroup" visible="false" runat="server">
    </form>

    <!-- Form to write the message from the Database -->
    <form id="response" visible="false" runat="server">
        <div class="All">
            <div class="container">
                <div class="section">
                    <div class="fieldSection">
                        <div style="position: absolute; top: 25%; left: 25%;">
                            One or more of the required fields were blank. Please do it again...
                            <br />
                            <br />
                            <asp:Button runat="server" Text="Return" ID="returnBtt" OnClick="returnEditMember" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
