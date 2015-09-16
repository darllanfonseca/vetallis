<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCE.aspx.cs" Inherits="Vetallis.View.RebateView.InsertCE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Insert New Ce Data</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css"/>
    <link rel="stylesheet" href="../../CSS/GridView.css"/>
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
    <form id="form1" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Fill out all the required fields to insert a new Ce Event
                <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
            </div>
            <div class="section">
                <div runat="server" class="fieldSection" style="position:absolute; width: 800px; left: 50%; margin-left: -400px;">
                    <div style="position: absolute; top: 20px; left: 10px; overflow:auto; width: 370px; bottom: 30px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchMembers" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedMember" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="Teste1">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle"/>
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
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER] WHERE STATUS='ACTIVE' ORDER BY NAME ASC"></asp:SqlDataSource>
                        </div>
                    <div runat="server" style="text-align:right; position: absolute; top: 20px; right: 15px; width: 150px; height: 50px;">
                        <b>Event Date*</b>
                        <asp:TextBox runat="server" ID="datepicker" Width="120px">
                        </asp:TextBox>
                    </div>

                    <div runat="server" style="text-align:right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                        <b>Number of Seats*</b>
                        <asp:TextBox TextMode="Number" step="any" runat="server" ID="numberOfSeats" Width="120px"></asp:TextBox>
                    </div>
                    
                    <div runat="server" style="text-align:right; position: absolute; top: 120px; right: 15px; width: 150px; height: 50px;">
                        <b>Rebate Year*</b>
                            <br />
                            <asp:DropDownList runat="server" ID="selectYear" Width="120px">
                                <asp:ListItem Text="..."></asp:ListItem>
                                <asp:ListItem Text="2016"></asp:ListItem>
                                <asp:ListItem Text="2015"></asp:ListItem>
                                <asp:ListItem Text="2014"></asp:ListItem>
                                <asp:ListItem Text="2013"></asp:ListItem>
                                <asp:ListItem Text="2012"></asp:ListItem>
                            </asp:DropDownList>
                    </div>

                    <div runat="server" style="text-align:right; position: absolute; top: 170px; right: 15px; width: 300px; height: 50px;">
                        <b>Member Name*</b>
                        <asp:TextBox runat="server" ID="memberName" Enabled="false" Width="300px"></asp:TextBox>
                        <asp:Label runat="server" ID="memberID" Visible="false"></asp:Label>
                    </div>

                    <div runat="server" style="text-align:right; position: absolute; top: 370px; right: 15px; width: 120px; height: 50px; text-align:right;">
                        <asp:Button runat="server" Text="Insert CE Data" Width="120px" OnClick="insertCEData"/>                       
                    </div>
                    <div runat="server" style="text-align:right; position: absolute; top: 370px; right: 190px; width: 120px; height: 50px; text-align:right;">
                        <asp:Button runat="server" Text="Cancel" Width="120px" OnClick="returnToMainPage"/>
                    </div>

                    <div runat="server" visible="false" id="response" style="position:absolute; bottom:30px; right:15px; text-align:right; color:green; width:300px;">
                        <asp:Label runat="server" ID="DBMsg"></asp:Label>
                    </div>
                    <div runat="server" visible="false" id="errorDiv" style="position:absolute; bottom:30px; right:15px; text-align:right; color:red; width:300px;">
                        <asp:Label runat="server" ID="errorMsg"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>
</body>
</html>
