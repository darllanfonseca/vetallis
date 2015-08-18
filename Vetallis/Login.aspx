<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Vetallis.Login" %>

<!DOCTYPE html>

<html xmlns="//www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script> 
    <title>VETALLIS - Login</title>
</head>
<body>
    <form id="loginForm" runat="server">
        
    <div style="position:absolute; font-family: Calibri; color:#606060; width: 200px; height: 200px; top: 50%; left: 50%; margin-top: -100px; margin-left: -100px; border: solid 1px #C0C0C0;">
        <div style="position:absolute; top: 10px; left: 22px; width: 180px; height: 50px;">
            User Name
            <asp:TextBox runat="server" ID="userName" Width="150px"></asp:TextBox>
        </div>
        <div style="position:absolute; top: 80px; left: 22px; width: 160px; height: 50px;">
            Password
            <asp:TextBox runat="server" ID="passWord" Width="150px" TextMode="Password"></asp:TextBox>
        </div>
        <div style="position:absolute; top: 145px; left: 100px; width:80px; height: 50px;">
            <asp:Button runat="server" ID="loginBtt" Text="Log In" Width="75px" Height="25px" OnClick="userLogin"/>
        </div>
        <div id="errorMsg" runat="server" style="position:absolute; color: red; top: 180px; left: 22px; width: 180px;">

        </div>
    </div>
    </form>
</body>
</html>
