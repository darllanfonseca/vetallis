<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="InsertCE.aspx.cs" Inherits="Vetallis.View.RebateView.InsertCE" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Insert New Ce Event</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css"/>
    </head>
<body>
    <form id="form1" runat="server">
    <div class="all">
        <div class="container">
            <div class="header">Fill out all the required fields to insert a new Ce Event
                <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
            </div>


            <div class="section"></div>
        </div>

    </div>
    </form>
</body>
</html>
