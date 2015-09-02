<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="SingleRebate.aspx.cs" Inherits="Vetallis.View.RebateView.SingleRebate" %>

<!DOCTYPE HTML PUBLIC "-//W3C//DTD HTML 4.0 Transitional//EN">
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Edit Single Rebate Data</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
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
                    <div class="fieldSection" style="position:absolute; width: 682px; left: 50%; margin-left: -341px;">
                        <div style="position: absolute; top: 5px; left: 5px; overflow: scroll; width: 300px; height: 400px; border: 1px solid #d0d0d0;">
                            <b>Select a Member</b> <br />
                            <asp:GridView ID="searchMembers" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_MEMBER" DataSourceID="memberDataSource">
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
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="memberDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [MEMBER] WHERE STATUS='ACTIVE' ORDER BY NAME ASC"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; top: 5px; left: 310px; width: 200px; overflow: scroll; height:400px; border: 1px solid #d0d0d0;">
                            <b>Select a Partner</b> <br />
                            <asp:GridView ID="searchPartners" runat="server" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ID_PARTNER" DataSourceID="partnerDataSource">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle"/>
                                <RowStyle Wrap="False" />                               
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="NAME" HeaderText="Partner Name" SortExpression="NAME">
                                    </asp:BoundField>
                                    <asp:BoundField DataField="STATUS" HeaderText="Current Status" SortExpression="STATUS" />
                                    <asp:BoundField DataField="ID_PARTNER" HeaderText="ID" SortExpression="ID_PARTNER" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="partnerDataSource" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [PARTNER] WHERE STATUS='ACTIVE' ORDER BY NAME ASC"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; top: 5px; left: 515px; width: 170px; height:400px; text-align: left; padding-left: 10px;">
                            <b>Select a Year</b> <br />
                            <asp:DropDownList runat="server" ID="selectYear" Width="150px">
                                <asp:ListItem Text="Select the Year..."></asp:ListItem>
                                <asp:ListItem Text="2015"></asp:ListItem>
                                <asp:ListItem Text="2014"></asp:ListItem>
                                <asp:ListItem Text="2013"></asp:ListItem>
                                <asp:ListItem Text="2012"></asp:ListItem>
                                <asp:ListItem Text="2011"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />
                            <b>Select a Category</b> <br />
                            <asp:DropDownList runat="server" ID="selectCategory" Width="150px">
                                <asp:ListItem Text="Select the Category..."></asp:ListItem>
                                <asp:ListItem Text="Money"></asp:ListItem>
                                <asp:ListItem Text="Discount"></asp:ListItem>
                                <asp:ListItem Text="Product"></asp:ListItem>
                                <asp:ListItem Text="Other"></asp:ListItem>
                            </asp:DropDownList>
                            <br /><br />
                            <b>Rebate Amount</b><br />
                            <asp:TextBox TextMode="Number" step="any" runat="server" ID="rebateAmount" Width="150px"></asp:TextBox>
                            <br /><br />
                            <asp:CheckBox runat="server" ID="isDeliveredByPartner" Text="Delivered By Partner" />
                            <br /><br /><br /><br />
                            <asp:Button runat="server" Text="Load Chosen Items" OnClick="loadChosenItems" Width="150px"/>
                        </div>

                        <div style="position:absolute; top: 420px; left: 5px; width: 680px; height:125px; text-align: left; padding-left: 10px;">
                            <div style="position:absolute; width:80px; height: 25px;">
                                <b>Member: </b>
                                </div>
                            <div runat="server" style="position:absolute; left: 80px; width: 350px; height:25px; text-align: left;">
                                <asp:TextBox runat="server" ID="selectedMember" Width="300px" Enabled="false"></asp:TextBox>
                                <asp:TextBox runat="server" Visible="false" ID="ID_SELECTED_MEMBER"></asp:TextBox>
                            </div>

                            <div style="position:absolute; left:400px; width:80px; height: 25px;">
                                <b>Year: </b>
                            </div>
                            <div style="position:absolute; left:480px; width:200px; height: 25px;">
                                <asp:TextBox runat="server" ID="selectedYear" Width="190px" Enabled="false"></asp:TextBox>
                            </div>

                            <div style="position:absolute; top:25px; width:80px; height: 25px;">
                                <b>Partner: </b>
                                </div>
                            <div style="position:absolute; top:25px; left: 80px; width: 350px; height:25px; text-align: left;">
                                <asp:TextBox runat="server" ID="selectedPartner" Width="300px" Enabled="false"></asp:TextBox>
                                <asp:TextBox runat="server" Visible="false" ID="ID_SELECTED_PARTNER"></asp:TextBox>
                            </div>

                            <div style="position:absolute; top:25px; left:400px; width:80px; height: 25px;">
                                <b>Category: </b>
                            </div>
                            <div style="position:absolute; top:25px; left:480px; width:200px; height: 25px;">
                                <asp:TextBox runat="server" ID="selectedCategory" Width="190px" Enabled="false"></asp:TextBox>
                            </div>

                            <div style="position:absolute; top:50px; width:80px; height: 25px;">
                                <b>Amount: </b>
                                </div>
                            <div style="position:absolute; top:50px; left: 80px; width: 100px; height:25px; text-align: left;">
                                <asp:TextBox runat="server" ID="selectedAmount" Width="100px" Enabled="false"></asp:TextBox>
                            </div>
                            <div style="position:absolute; top:75px; width:80px; height: 25px;">
                                <b>Delivery: </b>
                                </div>
                            <div style="position:absolute; top:75px; left: 80px; width: 100px; height:25px; text-align: left;">
                                <asp:TextBox runat="server" ID="selectedDeliveredByPartner" Width="100px" Enabled="false"></asp:TextBox>
                            </div>
                            <div style="position:absolute; top:60px; right:20px; width:200px; text-align:right; height: 25px;">
                                <asp:Button runat="server" Text="Cancel" OnClick="returnToMainPage" Width="150px"/>
                                </div>
                            <div style="position:absolute; top:95px; right:20px; width:200px; text-align:right; height: 25px;">
                                <asp:Button runat="server" Text="Confirm" OnClick="insertRebateData" Width="150px"/>
                                </div>

                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Form to write the message from the Database -->
    <form id="response" visible="false" runat="server">
        <div class="All">
            <div class="container">
                <div class="section">
                    <div class="fieldSection">
                        <div style="position: absolute; top: 25%; left: 25%;">
                            <asp:Label runat="server" ID="responseText"></asp:Label>
                            <br />
                            <br />
                            <asp:Button runat="server" Text="OK" ID="returnBtt" OnClick="returnToMainPage" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>


