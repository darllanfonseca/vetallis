<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MemberSummary.aspx.cs" Inherits="Vetallis.View.RebateView.MemberSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Member Summary</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
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

                <div runat="server" class="section" style="background: #FFF;">
                    <div runat="server" style="position: absolute; top: 20px; left: 0px; width: 150px; height: 50px;">
                        <asp:Button runat="server" Text="Return" Width="100px" Height="30px" OnClick="returnToMainPage" />
                    </div>
                    <div id="imgContainer">
                    </div>
                </div>
            </div>

        </div>
    </form>
</body>
</html>
