<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ActivateRemovedPartner.aspx.cs" Inherits="Vetallis.View.PartnerView.ActivateRemovedPartner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Activate Removed Partner</title>
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
    <form id="activatePartnerForm" runat="server">
        <div class="all">
            <div class="container">
                <div class="header">
                    <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div class="fieldSection" style="position:absolute; width: 800px; left: 50%; margin-left: -400px;">
                        <div style="text-align: left; position: absolute; top: 70px; left: 415px; width: 155px; height: 50px;">
                            <b>Partner Name</b>
                            <asp:TextBox runat="server" Enabled="false" ID="partnerName" Width="350px">                           
                            </asp:TextBox>
                            <asp:Label runat="server" ID="ID_PARTNER" Visible="false"></asp:Label>
                        </div>                   
                        <div style="position: absolute; top: 460px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="25px" Width="150px" Font-Names="Calibri" Font-Size="Medium" runat="server" ID="cancel" Text="Cancel" OnClick="returnToMainPage" AutoPostBack="True"/>
                        </div>
                        <div runat="server" style="position: absolute; top: 510px; right: 15px; width: 150px; height: 50px;">
                            <asp:Button Height="30px" BackColor="#e3efc7" Width="150px" Font-Names="Calibri" Font-Size="Large" runat="server" OnClick="activatePartner" Text="Activate Partner" AutoPostBack="True" />
                        </div>


                        <div style="text-align: left; position: absolute; top: 510px; left: 415px; width: 300px; height: 20px;">
                        </div>
                        <div style="position: absolute; top: 20px; left: 10px; width: 250px; overflow: scroll; bottom: 30px; border: solid 1px #d0d0d0;">
                            <asp:GridView ID="searchPartners" runat="server" AllowSorting="True" OnSelectedIndexChanged="loadSelectedPartner" AutoGenerateColumns="False" DataKeyNames="ID_PARTNER" DataSourceID="Teste1">
                                <FooterStyle CssClass="GridViewFooterStyle" />
                                <RowStyle CssClass="GridViewRowStyle" />    
                                <SelectedRowStyle CssClass="GridViewSelectedRowStyle" />
                                <PagerStyle CssClass="GridViewPagerStyle" />
                                <AlternatingRowStyle CssClass="GridViewAlternatingRowStyle" />
                                <HeaderStyle CssClass="GridViewHeaderStyle"/>
                                <RowStyle Wrap="False" />
                                <Columns>
                                    <asp:CommandField ShowSelectButton="True" />
                                    <asp:BoundField DataField="NAME" HeaderText="Name" SortExpression="NAME">
                                        <HeaderStyle Width="100px"></HeaderStyle>
                                    </asp:BoundField>
                                    <asp:BoundField DataField="ID_PARTNER" HeaderText="ID" SortExpression="ID_PARTNER" />
                                </Columns>
                            </asp:GridView>
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT * FROM PARTNER WHERE STATUS='INACTIVE'"></asp:SqlDataSource>
                        </div>
                        <div style="position: absolute; left: 10px; width: 370px; top: 530px; color: #707070; font-family: Calibri; font-size: 13px; text-align: left;">You can sort the results by clicking on the name of the columns.</div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <!-- Form to write the message from the Database -->
    <form id="responseForm" visible="false" runat="server">
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
