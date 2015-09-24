﻿<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditGroup.aspx.cs" Inherits="Vetallis.View.GroupView.EditGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Edit Group</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
    <link rel="stylesheet" href="../../CSS/GridView.css" />
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css" />
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function () {
            $("#datepicker").datepicker();
        });
    </script>

</head>
<body>
    <!-- Main Form -->
    <form id="chooseGroupForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">Choose a Group and add or remove members
                    <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div id="fieldSection" style="position: absolute; left: 50%; margin-left: -400px; width: 800px;">
                        <div style="text-align: left; position: absolute; top: 20px; left: 15px; width: 155px; height: 50px;">
                            <b>Group Name</b>
                            <asp:TextBox runat="server" Enabled="false" ID="groupNameChosen" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 70px; left: 15px; width: 450px; height: 50px;">
                            <b>Main Member</b>
                            <asp:TextBox runat="server" Enabled="false" ID="mainMemberChosen" Width="350px">                           
                            </asp:TextBox>
                            <asp:Label runat="server" ID="ID_MainMemberChosen" Visible="false"></asp:Label>
                            <asp:Button runat="server" Visible="false" Width="90px" ID="addSecondMemberBtt" OnClick="addMember" Text="Add Second" />
                        </div>
                        

                        <div runat="server" visible="true" id="selectMember" style="position: absolute; width: 330px; height: 340px; top: 20px; left: 430px; overflow: scroll; border: solid 1px #d0d0d0;">
                            <asp:GridView CssClass="GridViewStyle" ID="searchGroups" runat="server" AllowSorting="False" OnSelectedIndexChanged="loadSelectedGroup" AutoGenerateColumns="True" AutoGenerateSelectButton="true">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" />
                            </asp:GridView>
                        </div>




                        <div style="position: absolute; top: 460px; left: 15px; width: 100px; height: 50px;">
                            <asp:Button Height="25px" Width="100px" Visible="false" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="clearFields" OnClick="clearAllFields" Text="Clear Fields" AutoPostBack="True" />
                        </div>
                        <div style="position: absolute; top: 430px; right: 40px; width: 140px; height: 50px;">
                            <asp:Button Height="25px" Width="140px" Font-Names="Calibri" Font-Size="Medium" runat="server" Text="Cancel" AutoPostBack="True" OnClick="returnToMainPage" />
                        </div>
                        <div style="position: absolute; text-align: left; top: 510px; left: 15px; width: 600px; height: 50px; color: red;">
                            <asp:Label runat="server" ID="errorMsg" Visible="false"></asp:Label>
                        </div>
                        <div style="position: absolute; top: 480px; right: 40px; width: 140px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="140px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="editGroup" Text="Edit This Group" OnClick="changeGroupForm" AutoPostBack="True" />
                        </div>


                        <div style="text-align: left; position: absolute; top: 510px; left: 15px; width: 300px; height: 20px;">
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

<form id="editGroupForm" visible="false" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Add Members</div>
            <div class="section">
                <div class="fieldSection" style="position:absolute; left:50%; margin-left:-500px; width:1000px;">
                    <div style="text-align:left; position: absolute; top: 20px; left: 15px; width: 155px; height: 50px;">
                        <b>Group Name</b>
                        <asp:TextBox runat="server" id="groupName" Width="350px">                           
                        </asp:TextBox> 
                        <asp:Label runat="server" ID="GroupID" Visible="false"></asp:Label>                      
                    </div>
                    <div style="text-align:left; position: absolute; top: 70px; left: 15px; width: 450px; height: 50px;">
                        <b>Main Member</b>
                        <asp:TextBox runat="server" Enabled="false" id="mainMember" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idMainMember" Visible="false"></asp:Label>
                    </div>
                    <div runat="server" id="secondMemberDiv" style="text-align:left; position: absolute; top: 120px; left: 15px; width: 450px; height: 50px;">
                        <b>Second Member</b>
                        <asp:TextBox runat="server" id="secondMember" Enabled="false" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idSecondMember" Visible="false"></asp:Label>
                        <asp:Button runat="server" Width="90px" Visible="false" ID="addThirdMember" OnClick="addMember" Text="Add Third"/>
                    </div>
                    <div runat="server" id="thirdMemberDiv" visible="false" style="text-align:left; position: absolute; top: 170px; left: 15px; width: 450px; height: 50px;">
                        <b>Third Member</b>
                        <asp:TextBox runat="server" id="thirdMember" Enabled="false" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idThirdMember" Visible="false"></asp:Label>
                        <asp:Button runat="server" Width="90px" Visible="false" ID="addFourthMember" OnClick="addMember" Text="Add Fourth"/>
                    </div>
                    <div runat="server" id="fourthMemberDiv" visible="false" style="text-align:left; position: absolute; top: 220px; left: 15px; width: 450px; height: 50px;">
                        <b>Fourth Member</b>
                        <asp:TextBox runat="server" id="fourthMember" Enabled="false" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idFourthMember" Visible="false"></asp:Label>
                        <asp:Button runat="server" Width="90px" Visible="false" ID="addFithMember" OnClick="addMember" Text="Add Fith"/>
                    </div>
                    <div runat="server" id="fithMemberDiv" visible="false" style="text-align:left; position: absolute; top: 270px; left: 15px; width: 450px; height: 50px;">
                        <b>Fith  -  Member    </b>
                        <asp:TextBox runat="server" id="fithMember" Enabled="false" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idFithMember" Visible="false"></asp:Label>
                        <asp:Button runat="server" Width="90px" Visible="false" ID="addSixthMember" OnClick="addMember" Text="Add Sixth"/>
                    </div>
                    <div runat="server" id="sixthMemberDiv" visible="false" style="text-align:left; position: absolute; top: 320px; left: 15px; width: 450px; height: 50px;">
                        <b>Sixth Member</b>
                        <asp:TextBox runat="server" id="sixthMember" Enabled="false" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="idSixthMember" Visible="false"></asp:Label>
                    </div>
                    
                    <div runat="server" visible="true" id="Div6" style="position:absolute; width: 480px; height: 370px; top: 20px; left: 500px; overflow: scroll; border: solid 1px #d0d0d0;">
                        <asp:GridView CssClass="GridViewStyle" ID="searchMembers" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedMember" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="searchMainMember">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ACCOUNT_NUMBER" HeaderText="Account #" SortExpression="ACCOUNT_NUMBER">
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
                            <asp:SqlDataSource ID="searchMainMember" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER] WHERE STATUS='ACTIVE'"></asp:SqlDataSource>
                    </div>




                    <div style="position: absolute; top: 460px; left: 15px; width: 100px; height: 50px;">
                        <asp:Button Height="25px" Width="100px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="Button10" OnClick="clearAllFields" Text="Clear Fields" AutoPostBack="True"/>
                    </div>
                    <div style="position: absolute; top: 460px; right: 15px; width: 120px; height: 50px;">
                       <asp:Button Height="25px" Width="120px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="Button11" Text="Cancel" AutoPostBack="True" OnClick="returnToMainPage"/>
                    </div>
                    <div style="position: absolute; text-align: left; top: 510px; left: 15px; width: 600px; height: 50px; color: red;">
                        <asp:Label runat="server" ID="Label7" Visible="false"></asp:Label>
                    </div>
                    <div style="position: absolute; top: 510px; right: 15px; width: 120px; height: 50px;">
                        <asp:Button Height="30px" BackColor="#e3efc7" Width="120px" Font-Names="Calibri" Font-Size="Large" runat="server" Text="Update Group" OnClick="updateGroup" AutoPostBack="True"/>
                    </div>


                    <div style="text-align: left; position: absolute; top: 510px; left: 15px; width: 300px; height: 20px;">
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>


    <!-- Form to write the message from the Database -->
    <form id="response" visible="false" runat="server">
        <div class="all">
            <div class="container">
                <div class="section">
                    <div class="fieldSection" style="width: 500px; text-align: center; position: absolute; left: 50%; margin-left: -250px;">
                        <div runat="server" style="position: absolute; text-align: center; width: 500px; height: 200px; top: 50%; margin-top: -100px;">
                            <asp:Label runat="server" ID="responseText"></asp:Label><br />
                            <br />
                            <asp:Button runat="server" Text="Return To Main Page" OnClick="returnToMainPage" />
                            <asp:Button runat="server" Text="Edit Another Group" OnClick="returnToMainForm" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
