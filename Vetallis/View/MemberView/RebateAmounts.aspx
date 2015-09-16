<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RebateAmounts.aspx.cs" Inherits="Vetallis.View.MemberView.RebateAmounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Member Rebate Amounts</title>
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
    <form id="editMemberForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">Fill out all the required fields and update the member
                    <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div class="fieldSection" style="width:800px; position:absolute; left: 50%; margin-left: -400px;">

                        <div style="text-align: left; position: absolute; top: 70px; left: 400px; width: 150px; height: 50px;">
                            <b>Member Name</b>
                            <asp:TextBox runat="server" ID="memberName" Width="350px">                           
                            </asp:TextBox>
                        </div>

                       <!-- <div id="ID_GROUP_DIV" runat="server" style="text-align: left; position: absolute; top: 70px; right: 15px; width: 200px; height: 200px;">
                            <b>Choose the Partners</b>
                            <div runat="server" style="text-align: left; overflow: scroll; position: absolute; top: 19px; right: 0px; width: 200px; height: 200px; border: 1px solid #9c9c9c">
                                <asp:CheckBoxList TextAlign="Right" runat="server" SelectionMode="Multiple" ID="partners" DataSourceID="SqlDataSource1" DataTextField="Name" DataValueField="ID_PARTNER"></asp:CheckBoxList>
                                <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT ID_PARTNER, NAME FROM [PARTNER] ORDER BY NAME ASC"></asp:SqlDataSource>
                            </div>
                        </div>  -->

                        <div style="text-align: left; position: absolute; top: 150px; left: 400px; width: 150px; height: 50px;">
                            <b>Choose the Year</b>
                            <asp:DropDownList runat="server" Height="22px" Width="200px" ID="rebateYear">
                            <asp:ListItem
                                Text="Select the Year..." />
                            <asp:ListItem
                                Text="2015" />
                            <asp:ListItem
                                Text="2014" />
                            <asp:ListItem
                                Text="2013" />
                            <asp:ListItem
                                Text="2012" />
                            <asp:ListItem
                                Text="2011" />
                            <asp:ListItem
                                Text="2010" />
                        </asp:DropDownList>
                        </div>

                        <div style="position: absolute; top: 400px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="25px" Width="150px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" OnClick="returnToMainPage" AutoPostBack="True" />
                        </div>
                        <div style="position: absolute; top: 450px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="150px" Font-Names="Calibri" Font-Size="Large" runat="server" OnClick="exportResults" ID="exportResultsBtt" Text="Export Results" AutoPostBack="True" />
                        </div>

                        <div style="position: absolute; top: 20px; left: 10px; overflow: auto; width: 370px; bottom: 30px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchMembers" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedMember" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="Teste1">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ACCOUNT_NUMBER" HeaderText="Account #" SortExpression="ACCOUNT_NUMBER"></asp:BoundField>
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
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER] ORDER BY NAME ASC"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; left: 10px; width: 370px; top: 530px; color: #707070; font-family: Calibri; font-size: 13px; text-align: left;">You can sort the results by clicking on the name of the columns.</div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
