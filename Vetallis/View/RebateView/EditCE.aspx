<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditCE.aspx.cs" Inherits="Vetallis.View.RebateView.EditCE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Edit CE</title>
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
    <form id="form1" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">
                    Edition...
                <div runat="server" style="position: absolute; font-family: Calibri; font-size: 14px; text-align: right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                    <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                    <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                </div>
                </div>
                <div runat="server" id="chooseDiv" class="section">
                    <div runat="server" class="fieldSection" style="width: 700px; left: 50%; margin-left: -350px;">
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
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER] WHERE STATUS='ACTIVE' ORDER BY NAME ASC"></asp:SqlDataSource>
                        </div>
                        <div runat="server" style="position: absolute; top: 300px; right: 20px; width: 150px; text-align: right">
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
                        <div runat="server" style="position: absolute; bottom: 150px; right: 20px; width: 280px; text-align: right">
                            <asp:TextBox runat="server" ID="memberName" Enabled="false" Width="270px"></asp:TextBox>
                            <asp:Label runat="server" ID="memberID" Visible="false"></asp:Label>
                        </div>
                        <div runat="server" style="position: absolute; bottom: 90px; right: 20px; width: 150px; text-align: right">
                            <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage" Width="120px" Height="25px" />
                        </div>
                        <div runat="server" style="position: absolute; bottom: 32px; right: 20px; width: 150px; text-align: right">
                            <asp:Button runat="server" Text="Edit CE Amounts" OnClick="goToEditionDiv" Width="120px" Height="30px" />
                        </div>
                        <div runat="server" style="position: absolute; bottom: 10px; left: 10px; width: 680px; text-align: left; color:red;">
                           <asp:Label runat="server" ID="response1"></asp:Label>
                        </div>
                    </div>
                    
                </div>



                <!--DIV FOR EDITION -->
                <div runat="server" visible="false" class="section" id="editionDiv">
                    <div runat="server" class="fieldSection" style="width: 700px; left: 50%; margin-left: -350px;">
                        <b>Member</b><br />
                        <asp:TextBox runat="server" ID="selectedMemberName" Enabled="false" Width="280px"></asp:TextBox><br /><br />
                        <div style="position:absolute; top:70px; left:20px; height:300px; width:660px; overflow:scroll;">
                            <asp:GridView runat="server" ID="CEResults" AutoGenerateSelectButton="true" OnSelectedIndexChanged="loadSelectedCE">
                            <FooterStyle CssClass="GridViewFooterStyle" />
                            <RowStyle CssClass="GridViewRowStyle" />
                            <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                            <PagerStyle CssClass="GridViewPagerStyle" />
                            <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                            <HeaderStyle CssClass="GridViewHeaderStyle" />
                            <RowStyle Wrap="False" />
                        </asp:GridView>
                        </div>                       

                        <div runat="server" style="position:absolute; bottom:80px; left:20px; width:150px; text-align:left;">
                            <asp:Button runat="server" Text="Return" OnClick="returnTochooseDiv"/>
                        </div>
                        <div runat="server" style="position:absolute; bottom:40px; left:20px; width:150px; text-align:left;">
                            <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage"/>
                        </div>

                        <div runat="server" style="position: absolute; bottom: 10px; left: 20px; width: 680px; text-align: left; color:red;">
                           <asp:Label runat="server" ID="response2"></asp:Label>
                        </div>

                    </div>
                    
                </div>
                <!-- END OF DIV --->


                <!--DIV FOR EDITION 2 -->

                <div runat="server" visible="false" class="section" id="selectedCEDiv">
                    <div runat="server" class="fieldSection" style="width: 300px; height:400px; left: 50%; margin-left: -150px; text-align:center;">
                        <div runat="server" style="position:absolute; top:20px; left:20px; width:150px; text-align:left;">
                            <b>Member</b>
                            <asp:TextBox runat="server" id="selectedMemberName2" Enabled="false" Width="260px" />
                        </div>

                        <div runat="server" style="position:absolute; top:70px; left:20px; width:150px; text-align:left;">
                            <b>Event Date*</b>
                            <asp:TextBox runat="server" id="datepicker" Width="150px" />
                            <asp:Label runat="server" ID="CEID" Visible="false"></asp:Label>
                        </div>
                        <div runat="server" style="position:absolute; top:120px; left:20px; width:150px; text-align:left;">
                            <b>Number of Seats*</b>
                            <asp:TextBox runat="server" ID="numberOfSeats" TextMode="Number" step="any" Width="150px" />
                        </div>
                        <div runat="server" style="position:absolute; top:170px; left:20px; width:150px; text-align:left;">
                            <b>Rebate Year*</b>
                            <asp:DropDownList runat="server" ID="selectYear2" Width="150px">
                                <asp:ListItem Text="..."></asp:ListItem>
                                <asp:ListItem Text="2016"></asp:ListItem>
                                <asp:ListItem Text="2015"></asp:ListItem>
                                <asp:ListItem Text="2014"></asp:ListItem>
                                <asp:ListItem Text="2013"></asp:ListItem>
                                <asp:ListItem Text="2012"></asp:ListItem>
                            </asp:DropDownList>
                        </div>

                        <div runat="server" style="position:absolute; top:220px; left:20px; width:150px; text-align:left;">
                            <asp:Button runat="server" Text="Return" OnClick="returnToeditionDiv"/>
                        </div>
                        <div runat="server" style="position:absolute; top:260px; left:20px; width:150px; text-align:left;">
                            <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage"/>
                        </div>
                        <div runat="server" style="position:absolute; top:300px; left:20px; width:150px; text-align:left;">
                            <asp:Button runat="server" Text="Confirm Change" OnClick="insertEditedCE"/>
                        </div>
                        <div runat="server" style="position:absolute; top:350px; left:20px; width:200px; text-align:left; color:green;">
                            <asp:Label runat="server" ID="DB_Response"></asp:Label>
                        </div>
                        <div runat="server" style="position:absolute; top:350px; left:20px; width:200px; text-align:left; color:red;">
                            <asp:Label runat="server" ID="errorMsg"></asp:Label>
                        </div>
                    </div>
                </div>

                <!-- END OF DIV --->


            </div>

        </div>
    </form>
</body>
</html>
