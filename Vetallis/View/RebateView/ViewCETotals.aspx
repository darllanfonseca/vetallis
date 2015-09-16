<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ViewCETotals.aspx.cs" Inherits="Vetallis.View.RebateView.ViewCETotals" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - View CE Totals</title>
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
    <form id="mainForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">
                    <div runat="server" style="position: absolute; font-family: Calibri; font-size: 14px; text-align: right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                        <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div class="fieldSection" style="width:390px; margin-left:-195px;">
                        <div runat="server" style="position:absolute; top:20px; width:350px; height:50px;">
                            <b>Select the category</b>
                            <asp:DropDownList runat="server" ID="category" OnSelectedIndexChanged="openDivs" Width="180px" AutoPostBack="true">
                                <asp:ListItem Text="..."></asp:ListItem>
                                <asp:ListItem Text="For Individual Member"></asp:ListItem>
                                <asp:ListItem Text="For a Group"></asp:ListItem>
                                <asp:ListItem Text="For All Members"></asp:ListItem>
                                <asp:ListItem Text="For All Times"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <!---MEMBER DIV-->
                        <div runat="server" id="memberDiv" visible="false" style="position:absolute; top:70px; left:20px; width:350px; height:350px; overflow:scroll; border:solid 1px #d0d0d0;">
                            <asp:GridView ID="searchMembers" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="Teste1">
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


                        <!---GROUP DIV-->
                        <div runat="server" id="groupDiv" visible="false" style="position:absolute; top:70px; left:20px; width:350px; height:350px; overflow:scroll; border:solid 1px #d0d0d0;">
                            <asp:GridView ID="searchGroups" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_GROUP" DataSourceID="AllGroups">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle"/>
                                <RowStyle Wrap="False" />                               
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="GROUP_NAME" HeaderText="Group Name" SortExpression="GROUP_NAME" />
                                    <asp:BoundField DataField="STATUS" HeaderText="Status" SortExpression="STATUS" />
                                    <asp:BoundField DataField="ID_GROUP" HeaderText="Group ID" SortExpression="ID_GROUP" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="AllGroups" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [GROUPS] WHERE STATUS='ACTIVE' ORDER BY GROUP_NAME ASC"></asp:SqlDataSource>
                        </div>


                        <!---YEAR DIV-->
                        <div runat="server" id="yearDiv" visible="false" style="position:absolute; top:430px; left:20px; width:350px; height:50px; text-align:left;">
                            <b>Select the Year*</b>
                            <asp:DropDownList runat="server" ID="selectYear" Width="120px">
                                <asp:ListItem Text="..."></asp:ListItem>
                                <asp:ListItem Text="2016"></asp:ListItem>
                                <asp:ListItem Text="2015"></asp:ListItem>
                                <asp:ListItem Text="2014"></asp:ListItem>
                                <asp:ListItem Text="2013"></asp:ListItem>
                                <asp:ListItem Text="2012"></asp:ListItem>
                            </asp:DropDownList>
                        </div>


                        <!---BUTTONS DIV-->
                        <div runat="server" id="buttonsDiv" visible="false" style="position:absolute; top:490px; left:20px; width:350px; height:50px;">
                            <div runat="server" style="position:absolute; left:0px; width: 150px; text-align:left;">
                                <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage" Width="120px" Height="30px"/>
                            </div>
                            <div runat="server" style="position:absolute; right:0px; width: 150px; text-align:right;">
                                <asp:Button runat="server" Text="Get Results" OnClick="getResults" Width="120px" Height="30px"/>
                            </div>
                            
                        </div>
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
