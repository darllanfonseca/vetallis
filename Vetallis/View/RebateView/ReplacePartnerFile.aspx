<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplacePartnerFile.aspx.cs" Inherits="Vetallis.View.RebateView.ReplacePartnerFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Replace Partner Data File</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
    <link rel="stylesheet" href="../../CSS/GridView.css" />
</head>
<body>
    <form id="form1" runat="server">
        <div class="all">
            <div class="container">
                <div class="header"></div>
                <div class="section">
                    <div class="fieldSection">
                        <asp:DropDownList runat="server" ID="partnerList" DataSourceID="Teste1" DataTextField="Name">
                        </asp:DropDownList>
                        <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT NAME FROM [PARTNER] ORDER BY NAME ASC"></asp:SqlDataSource>
                    </div>
                </div>
            </div>
        </div>
    </form>
</body>
</html>
