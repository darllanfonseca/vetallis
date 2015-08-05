<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertPartner.aspx.cs" Inherits="Vetallis.View.PartnerView.InsertPartner" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Insert New Partner</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css"/>
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
    <form id="insertNewPartnerForm" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Fill out all the required fields to insert a new partner</div>
            <div class="section">
                <div id="fieldSection">
                    <div style="text-align:left; position: absolute; top: 15px; left: 15px; width: 160px; height: 50px;">
                       
                    </div>
                    <div style="text-align:right; position: absolute; top: 15px; right: 15px; width: 150px; height: 50px;">
                    </div>
                    <div style="text-align:left; position: absolute; top: 70px; left: 15px; width: 155px; height: 50px;">
                        <b>Partner Name *</b>
                        <asp:TextBox runat="server" id="partnerName" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:right; position: absolute; top: 70px; right: 15px; width: 150px; height: 50px;">
                        <b>Date Joined *</b>
                        <asp:TextBox runat="server" ID="datepicker" Width="120px">
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 125px; left: 15px; width: 155px; height: 50px;">
                        <b>Address</b>
                        <asp:TextBox runat="server" id="address" Width="350px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 180px; left: 15px; width: 150px; height: 50px;">
                    </div>
                    <div style="text-align:right; position: absolute; top: 180px; right: 15px; width: 160px; height: 50px;">
                        <b>City</b>
                        <asp:TextBox runat="server" id="city" Width="150px">                           
                        </asp:TextBox>
                    </div>
                    <div style="text-align:left; position: absolute; top: 235px; left: 15px; width: 80px; height: 50px;">                
                    </div>
                    <div style="text-align:right; position: absolute; top: 235px; left: 215px; width: 150px; height: 50px;">
                    </div>
                    <div style="text-align:right; position: absolute; top: 235px; right: 15px; width: 160px; height: 50px;">
                        <b>Postal Code</b>
                        <asp:TextBox style="text-transform:uppercase;" runat="server" id="postalCode" Width="150px" MaxLength="10">
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
                        <asp:Button Height="30px" BackColor="#e3efc7" Width="120px" Font-Names="Calibri" Font-Size="Large" runat="server" ID="addPartner" Text="Add Partner" OnClick="insertNewPartner" AutoPostBack="True"/>
                    </div>


                    <div style="text-align: left; position: absolute; top: 510px; left: 15px; width: 300px; height: 20px;">
                        * indicates that the field is required.
                    </div>
                </div>
            </div>
        </div>
    </div>
    </form>

    <!-- Form to write the message from the Database -->
    <form id="response" visible="false" runat="server">   
    </form>
</body>
</html>
