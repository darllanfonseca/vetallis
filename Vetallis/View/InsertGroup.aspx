<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertGroup.aspx.cs" Inherits="Vetallis.View.InsertGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Insert New Group</title>
    <link rel="stylesheet" href="../CSS/RegForms.css"/>
    <link rel="stylesheet" href="../CSS/GridView.css"/>
    <link rel="stylesheet" href="//code.jquery.com/ui/1.11.4/themes/smoothness/jquery-ui.css"/>
    <script src="//code.jquery.com/jquery-1.10.2.js"></script>
    <script src="//code.jquery.com/ui/1.11.4/jquery-ui.js"></script>
    <script>
        $(function() {
        $( "#datepicker" ).datepicker();
        });
    </script>
    
</head>
<body>
    <!-- Main Form -->
    <form id="insertGroupForm" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Fill out all the required fields to insert a new group of members</div>
            <div class="section">
                <div id="fieldSection">
                    <div style="text-align:left; position: absolute; top: 15px; left: 15px; width: 160px; height: 50px;">
                       
                    </div>
                    <div style="text-align:right; position: absolute; top: 15px; right: 15px; width: 150px; height: 50px;">
                    </div>
                    <div style="text-align:left; position: absolute; top: 70px; left: 15px; width: 155px; height: 50px;">
                        <b>Main Member</b>
                        <asp:TextBox runat="server" id="mainMember" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                    </div>
                    <div style="text-align:left; position: absolute; top: 125px; left: 15px; width: 155px; height: 50px;">
                        <b>Group Name</b>
                        <asp:TextBox Enabled="false" runat="server" id="groupName" Width="350px">                           
                        </asp:TextBox>
                        <asp:Label runat="server" ID="ID_Member" Visible="false"></asp:Label>
                    </div>
                    <div runat="server" visible="true" id="selectMember" style="position:absolute; width: 568px; height: 250px; top: 180px; left: 15px; overflow: scroll; border: solid 1px #d0d0d0;">
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
                            <asp:SqlDataSource ID="searchMainMember" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER]"></asp:SqlDataSource>
                    </div>




                    <div style="position: absolute; top: 460px; left: 15px; width: 100px; height: 50px;">
                        <asp:Button Height="25px" Width="100px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="clearFields" OnClick="clearAllFields" Text="Clear Fields" AutoPostBack="True"/>
                    </div>
                    <div style="position: absolute; top: 460px; right: 15px; width: 120px; height: 50px;">
                       <asp:Button Height="25px" Width="120px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" AutoPostBack="True" OnClick="returnToMainPage"/>
                    </div>
                    <div style="position: absolute; top: 510px; right: 15px; width: 120px; height: 50px;">
                        <asp:Button Height="30px" BackColor="#e3efc7" Width="120px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="addGroup" Text="Add Group" OnClick="insertNewGroup" AutoPostBack="True"/>
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
    </form>
</body>
</html>
