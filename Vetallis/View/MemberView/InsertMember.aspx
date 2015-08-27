<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertMember.aspx.cs" Inherits="Vetallis.View.MemberView.InsertMember" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Insert New Member</title>
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
    <!-- Main Form -->
    <form id="insertNewMemberForm" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Fill out all the required fields to insert a new member</div>
            <div class="section">
                <div id="fieldSection">
                  <!-- <div visible="false" style="text-align:left; position: absolute; top: 15px; left: 15px; width: 160px; height: 50px;">
                        <b>Is a Group? *</b>
                        <asp:TextBox runat="server" Visible="false" ID="groupId"></asp:TextBox>
                        <asp:DropDownList OnSelectedIndexChanged="enableChooseGroup" runat="server" ID="isAGroup" Width="70px" AutoPostBack="True">
                            <asp:ListItem Text="Select..." />
                            <asp:ListItem Text="Yes" />
                            <asp:ListItem Text="No" />
                        </asp:DropDownList>
                        <asp:Button runat="server" Width="80px" Visible="false" ID="openChooseGroupForm" OnClick="changeForms" Text="Pick Group" AutoPostBack="True"/>
                    </div> -->
                    <div style="text-align:right; position: absolute; top: 15px; right: 15px; width: 150px; height: 50px;">
                        <b>Account Number *</b>
                        <asp:TextBox runat="server" id="accountNumber" Width="120px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 70px; left: 15px; width: 155px; height: 50px;">
                        <b>Member Name *</b>
                        <asp:TextBox runat="server" id="memberName" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                        <b>Date Joined *</b>
                        <asp:TextBox runat="server" ID="datepicker" Width="120px">
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 125px; left: 15px; width: 155px; height: 50px;">
                        <b>Address *</b>
                        <asp:TextBox runat="server" id="address" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div id="ID_GROUP_DIV" runat="server" style="text-align:right; position: absolute; top: 125px; right: 15px; width: 155px; height: 50px;">
                        <b>Group ID</b>
                        <asp:TextBox runat="server" id="group_ID" Width="150px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 180px; left: 15px; width: 150px; height: 50px;">
                        <b>Doctor Name</b>
                        <asp:TextBox runat="server" id="doctorName" Width="250px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 180px; right: 15px; width: 160px; height: 50px;">
                        <b>City *</b>
                        <asp:TextBox runat="server" id="city" Width="150px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 235px; left: 15px; width: 80px; height: 50px;">
                        <b>Province *</b>
                        <asp:DropDownList runat="server" Width="70px" AutoPostBack="True" ID="province" OnSelectedIndexChanged="changeRegion">
                            <asp:ListItem
                                Text="Select..."
                            />
                            <asp:ListItem
                                Text="AB"
                            />
                            <asp:ListItem
                                Text="BC"
                            />
                            <asp:ListItem
                                Text="MB"
                            />
                            <asp:ListItem
                                Text="NB"
                            />
                            <asp:ListItem
                                Text="NL"
                            />
                            <asp:ListItem
                                Text="NT"
                            />
                            <asp:ListItem
                                Text="NS"
                            />
                            <asp:ListItem
                                Text="NU"
                            />
                            <asp:ListItem
                                Text="ON"
                            />
                            <asp:ListItem
                                Text="PE"
                            />
                            <asp:ListItem
                                Text="QC"
                            />
                            <asp:ListItem
                                Text="SK"
                            />
                            <asp:ListItem
                                Text="YT"
                            />

                        </asp:DropDownList>
                    </div>
                    <div style="text-align:right; position: absolute; top: 235px; left: 215px; width: 150px; height: 50px;">
                        <b>Region</b>
                        <asp:TextBox runat="server" id="region" Enabled="false" Width="150px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 235px; right: 15px; width: 160px; height: 50px;">
                        <b>Postal Code *</b>
                        <asp:TextBox style="text-transform:uppercase;" runat="server" id="postalCode" Width="150px" MaxLength="6">
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 290px; left: 15px; width:200px; height: 50px;">
                        <b>Website</b>
                        <asp:TextBox runat="server" id="website" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 290px; right: 15px; width: 160px; height: 50px;">
                        <b>Phone Number</b>
                        <asp:TextBox style="text-transform:uppercase;" runat="server" id="phoneNumber" Width="150px" MaxLength="11">
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 345px; left: 15px; width:200px; height: 50px;">
                        <b>Email Address</b>
                        <asp:TextBox runat="server" id="emailAddress" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 345px; right: 15px; width: 160px; height: 50px;">
                        <b>Fax Number</b>
                        <asp:TextBox style="text-transform:uppercase;" runat="server" id="faxNumber" Width="150px" MaxLength="11">
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 400px; left: 15px; width: 150px; height: 50px;">
                        <b>Contact Person</b>
                        <asp:TextBox runat="server" id="contactPerson" Width="250px">                           
                        </asp:TextBox>
                    </div>
                    <div style="position: absolute; top: 460px; left: 15px; width: 100px; height: 50px;">
                        <asp:Button Height="25px" Width="100px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="clearFields" OnClick="clearAllFields" Text="Clear Fields" AutoPostBack="True"/>
                    </div>
                    <div style="position: absolute; top: 460px; right: 15px; width: 120px; height: 50px;">
                       <asp:Button Height="25px" Width="120px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" AutoPostBack="True" OnClick="returnToMainPage"/>
                    </div>
                    <div style="position: absolute; top: 510px; right: 15px; width: 120px; height: 50px;">
                        <asp:Button Height="30px" BackColor="#e3efc7" Width="120px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="addMember" Text="Add Member" OnClick="insertNewMember" AutoPostBack="True"/>
                    </div>


                    <div runat="server" style="text-align: left; color: red; position: absolute; top: 510px; left: 15px; width: 300px; height: 20px;">
                        <asp:Label runat="server" ID="errorMsg"></asp:Label>
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <!-- Form to choose the Group -->
    <form id="chooseGroup" visible="false" runat="server">
            <div class="all">
        <div class="container">
            <div class="header">Choose the correct group to match with the new Member</div>
            <div class="section">
                <div class="fieldSection">
                    <div style="position: absolute; top: 20px; left: 50%; margin-left: -150px; width: 300px; overflow: scroll; bottom: 300px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchGroups" runat="server" RowStyle-Height="15px" HeaderStyle-Height="30px" RowStyle-Width="100px" AllowSorting="True" OnSelectedIndexChanged="loadSelectedGroup" AutoGenerateColumns="False" DataKeyNames="ID_GROUP" DataSourceID="Teste3">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" /> 
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="GROUP_NAME" HeaderText="Name" SortExpression="GROUP_NAME">
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ID_MAIN_MEMBER" HeaderText="Main Member" SortExpression="ID_MAIN_MEMBER" />
                                    <asp:BoundField DataField="ID_GROUP" HeaderText="Group ID" SortExpression="ID_GROUP" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Teste3" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [GROUPS]"></asp:SqlDataSource>
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
                    <div class="fieldSection">
                        <div runat="server" style="position: absolute; top: 25%; left: 25%;">
                            <asp:Label runat="server" ID="responseText"></asp:Label><br /><br />
                            <asp:Button runat="server" Text="Return" OnClick="returnToMainPage"/>
                        </div>
                    </div>
                </div>
            </div>
         </div>   
    </form>
</body>
</html>
