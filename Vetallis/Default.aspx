<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vetallis.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>VETALLIS</title>
    <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="../CSS/MainScreen.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
    <div id="all">
        <div id="container">
            <div id="header">
                <div id="link1" class="dropdown">
                    <button class="btn btn-success dropdown-toggle" type="button" id="menu1" data-toggle="dropdown">
                        Insert 
	<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertMember.aspx">New Member</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertPartner.aspx">New Partner</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertCE.aspx">New CE Event</a></li>
                    </ul>
                </div>
                <div id="link2" class="dropdown">
                    <button class="btn btn-success dropdown-toggle" type="button" id="menu2" data-toggle="dropdown">
                        Edit
	<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu2">
                        <li role="presentation"><a role="menuitem" id="editMember" tabindex="-1" href="View/EditMember.aspx">Member</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditPartner.aspx">Partner</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditCE.aspx">CE Event</a></li>
                    </ul>
                </div>
                <div id="link3" class="dropdown">
                    <button class="btn btn-success dropdown-toggle" type="button" id="menu3" data-toggle="dropdown">
                        Remove
	<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu3">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveMember.aspx">Member</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemovePartner.aspx">Partner</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveCE.aspx">CE Event</a></li>
                    </ul>
                </div>
                <div style="float: right; padding: 15px;">
                    <asp:Label ID="timeAndDate" runat="server"></asp:Label></div>
            </div>
            <div id="nav">
                <div id="navItem1">
                    <button class="btn btn-default" type="button" id="item1">Export Current Member List</button></div> 
                <div id="navItem2">
                    <button class="btn btn-default" type="button" id="item2">Export Current Partner List</button></div>
                <div id="navItem3">
                    <button class="btn btn-default" type="button" id="item3">Export Rebate Sheet of Current Year</button></div>
            </div>
            <div id="section">
                <div id="imgContainer">
                </div>
            </div>
            <div id="footer" style="font-family: Calibri; font-size: 13px;">
                © 2015 Vet Alliance Inc. - Vet Alliance Information System.
            </div>
        </div>
    </div>
</body>
</html>
