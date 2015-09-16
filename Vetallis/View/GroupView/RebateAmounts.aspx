<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RebateAmounts.aspx.cs" Inherits="Vetallis.View.GroupView.RebateAmounts" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Group Rebate Amounts</title>
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
    <form id="mainForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">
                    <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div class="fieldSection" style="width: 800px; position:absolute; left: 50%; margin-left: -400px;">

                        <div runat="server" style="text-align: left; position: absolute; top: 70px; left: 400px; width: 150px; height: 50px;">
                            <b>Group Name</b>
                            <asp:TextBox runat="server" ID="groupName" Width="350px">                           
                            </asp:TextBox>
                            <asp:Label ID="ID_Group" runat="server" Visible="false"></asp:Label><br />
                        </div>

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
                            <asp:GridView ID="searchGroups" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedGroup" AutoGenerateColumns="False" DataKeyNames="ID_GROUP" DataSourceID="Teste1">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="ID_GROUP" SortExpression="ID_GROUP"></asp:BoundField>
                                    <asp:BoundField DataField="GROUP_NAME" HeaderText="Group Name" SortExpression="GROUP_NAME" />
                                    <asp:BoundField DataField="NAME" HeaderText="Main Member" SortExpression="NAME" />                                   
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT GROUPS.ID_GROUP, GROUPS.GROUP_NAME, MEMBER.NAME AS NAME FROM GROUPS JOIN MEMBER ON GROUPS.ID_MAIN_MEMBER = MEMBER.ID_MEMBER ORDER BY GROUPS.GROUP_NAME ASC"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; left: 10px; width: 370px; top: 530px; color: #707070; font-family: Calibri; font-size: 13px; text-align: left;">You can sort the results by clicking on the name of the columns.</div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
