<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="EditPartner.aspx.cs" Inherits="Vetallis.View.EditPartner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Edit a Partner</title>
    <link rel="stylesheet" href="../CSS/RegForms.css" />
    <link rel="stylesheet" href="../CSS/GridView.css"/>
</head>
<body>
    <!-- Main Form -->
    <form id="editPartnerForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">Fill out all the required fields and update the partner</div>
                <div class="section">
                    <div class="fieldSection">
                        <div style="text-align: left; position: absolute; top: 15px; left: 415px; width: 160px; height: 50px;">
                            
                        </div>
                        <div style="text-align: right; position: absolute; top: 15px; right: 15px; width: 150px; height: 50px;">
                           
                        </div>
                        <div style="text-align: left; position: absolute; top: 70px; left: 415px; width: 155px; height: 50px;">
                            <b>Partner Name *</b>
                            <asp:TextBox runat="server" ID="partnerName" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                            <b>Date Joined *</b>
                            <asp:TextBox runat="server" ID="datepicker" Width="120px">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 125px; left: 415px; width: 155px; height: 50px;">
                            <b>Address</b>
                            <asp:TextBox runat="server" ID="address" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 180px; left: 415px; width: 150px; height: 50px;">

                        </div>
                        <div style="text-align: right; position: absolute; top: 180px; right: 15px; width: 160px; height: 50px;">
                            <b>City</b>
                            <asp:TextBox runat="server" ID="city" Width="150px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 235px; left: 415px; width: 80px; height: 50px;">

                        </div>
                        <div style="text-align: right; position: absolute; top: 235px; left: 615px; width: 150px; height: 50px;">

                        </div>
                        <div style="text-align: right; position: absolute; top: 235px; right: 15px; width: 160px; height: 50px;">
                            <b>Postal Code</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="postalCode" Width="150px" MaxLength="10">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 290px; left: 415px; width: 200px; height: 50px;">
                            <b>Website</b>
                            <asp:TextBox runat="server" ID="website" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 290px; right: 15px; width: 160px; height: 50px;">
                            <b>Phone Number</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="phoneNumber" Width="150px" MaxLength="11">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 345px; left: 415px; width: 200px; height: 50px;">
                            <b>Email Address</b>
                            <asp:TextBox runat="server" ID="emailAddress" Width="350px">                           
                            </asp:TextBox>
                        </div>
                        <div style="text-align: right; position: absolute; top: 345px; right: 15px; width: 160px; height: 50px;">
                            <b>Fax Number</b>
                            <asp:TextBox Style="text-transform: uppercase;" runat="server" ID="faxNumber" Width="150px" MaxLength="11">
                            </asp:TextBox>
                        </div>
                        <div style="text-align: left; position: absolute; top: 400px; left: 415px; width: 150px; height: 50px;">
                            <b>Contact Person</b>
                            <asp:TextBox runat="server" ID="contactPerson" Width="250px">                           
                            </asp:TextBox>
                        </div>
                        <div style="position: absolute; top: 460px; left: 415px; width: 100px; height: 50px;">
                            <asp:Button Height="25px" Width="100px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="enableFieldsBtt" OnClick="enableFields" Text="Enable Fields" AutoPostBack="True" />
                        </div>
                        <div style="position: absolute; top: 460px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="25px" Width="150px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" OnClick="returnToMainPage" AutoPostBack="True"/>
                        </div>
                        <div style="position: absolute; top: 510px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="150px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="updatePartnerBtt" OnClick="updatePartner" Text="Update Partner" AutoPostBack="True" />
                        </div>


                        <div style="text-align: left; position: absolute; top: 510px; left: 415px; width: 300px; height: 20px;">
                            * indicates that the field is required.
                        </div>
                        <div style="position: absolute; top: 20px; left: 10px; width: 370px; overflow: scroll; bottom: 30px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchPartners" runat="server" RowStyle-Height="15px" HeaderStyle-Height="30px" RowStyle-Width="100px" AllowSorting="True" OnSelectedIndexChanged="loadSelectedPartner" AutoGenerateColumns="False" DataKeyNames="ID_PARTNER" DataSourceID="Teste2" Height="534px" Width="1000px">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle" />
                                <RowStyle Wrap="False" /> 
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="NAME" HeaderText="NAME" SortExpression="NAME" />
                                    <asp:BoundField DataField="ADDRESS" HeaderText="ADDRESS" SortExpression="ADDRESS" />
                                    <asp:BoundField DataField="CITY" HeaderText="CITY" SortExpression="CITY" />
                                    <asp:BoundField DataField="ID_PARTNER" HeaderText="ID_PARTNER" ReadOnly="True" SortExpression="ID_PARTNER" />
                                    <asp:BoundField DataField="PARTNER_SINCE" HeaderText="PARTNER_SINCE" SortExpression="PARTNER_SINCE" />
                                    <asp:BoundField DataField="STATUS" HeaderText="STATUS" SortExpression="STATUS" />
                                    <asp:BoundField DataField="POSTAL_CODE" HeaderText="POSTAL_CODE" SortExpression="POSTAL_CODE" />
                                    <asp:BoundField DataField="WEBSITE" HeaderText="WEBSITE" SortExpression="WEBSITE" />
                                    <asp:BoundField DataField="EMAIL_ADDRESS" HeaderText="EMAIL_ADDRESS" SortExpression="EMAIL_ADDRESS" />
                                    <asp:BoundField DataField="PHONE_NUMBER" HeaderText="PHONE_NUMBER" SortExpression="PHONE_NUMBER" />
                                    <asp:BoundField DataField="FAX" HeaderText="FAX" SortExpression="FAX" />
                                    <asp:BoundField DataField="CONTACT_PERSON" HeaderText="CONTACT_PERSON" SortExpression="CONTACT_PERSON" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Teste2" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM [PARTNER]"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; left: 10px; width: 370px; top: 530px; color: #707070; font-family: Calibri; font-size: 13px; text-align: left;">You can sort the results by clicking on the name of the columns.</div>
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
                            One or more of the required fields were blank. Please do it again...
                            <br />
                            <br />
                            <asp:Button runat="server" Text="Return" ID="returnBtt" OnClick="returnEditPartner" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
