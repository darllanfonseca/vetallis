<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RemoveGroup.aspx.cs" Inherits="Vetallis.View.GroupView.RemoveGroup" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Remove Group</title>
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
                            <asp:Label runat="server" ID="idGroupChosen" Visible="false"></asp:Label>
                        </div>
                        <div style="text-align: left; position: absolute; top: 70px; left: 15px; width: 450px; height: 50px;">
                            <b>Main Member</b>
                            <asp:TextBox runat="server" Enabled="false" ID="mainMemberChosen" Width="350px">                           
                            </asp:TextBox>
                            <asp:Label runat="server" ID="ID_MainMemberChosen" Visible="false"></asp:Label>
                        </div>
                        

                        <div runat="server" visible="true" id="selectMember" style="position: absolute; width: 330px; height: 340px; top: 20px; left: 430px; overflow: scroll; border: solid 1px #d0d0d0;">
                            <asp:GridView CssClass="GridViewStyle" ID="searchGroups" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedGroup" AutoGenerateColumns="False" DataKeyNames="ID_GROUP" DataSourceID="searchMainGroup">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME" />
                                    <asp:BoundField DataField="MAIN_MEMBER" HeaderText="Main Member" SortExpression="MAIN_MEMBER" />
                                    <asp:BoundField DataField="ID_GROUP" HeaderText="Group ID" SortExpression="ID_GROUP" />
                                    <asp:BoundField DataField="ID_MAIN_MEMBER" HeaderText="Main Member ID" SortExpression="ID_MAIN_MEMBER" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="searchMainGroup" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT GROUPS.ID_GROUP, GROUPS.GROUP_NAME AS NAME, GROUPS.ID_MAIN_MEMBER, MEMBER.NAME AS MAIN_MEMBER FROM MEMBER JOIN GROUPS ON GROUPS.ID_MAIN_MEMBER = MEMBER.ID_MEMBER"></asp:SqlDataSource>
                        </div>

                        <div style="position: absolute; top: 430px; right: 40px; width: 160px; height: 50px;">
                            <asp:Button Height="25px" Width="160px" Font-Names="Calibri" Font-Size="Medium" runat="server" Text="Cancel" AutoPostBack="True" OnClick="returnToMainPage" />
                        </div>
                        <div style="position: absolute; text-align: left; top: 510px; left: 15px; width: 600px; height: 50px; color: red;">
                            <asp:Label runat="server" ID="errorMsg" Visible="false"></asp:Label>
                        </div>
                        <div style="position: absolute; top: 480px; right: 40px; width: 160px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="160px" Font-Names="Calibri" Font-Size="Large" runat="server" Text="Remove This Group" OnClick="removeGroup" AutoPostBack="True" />
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
                            <asp:Button runat="server" Text="Remove Another Group" OnClick="returnToMainForm" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
