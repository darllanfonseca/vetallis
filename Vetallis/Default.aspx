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
                       <b>Insert</b> 
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
                        <b>Edit</b>
	<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu2">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditMember.aspx">Member</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditPartner.aspx">Partner</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditCE.aspx">CE Event</a></li>
                    </ul>
                </div>
                <div id="link3" class="dropdown">
                    <button class="btn btn-success dropdown-toggle" type="button" id="menu3" data-toggle="dropdown">
                       <b>Remove</b> 
	<span class="caret"></span>
                    </button>
                    <ul class="dropdown-menu" role="menu" aria-labelledby="menu3">
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveMember.aspx">Member</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemovePartner.aspx">Partner</a></li>
                        <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveCE.aspx">CE Event</a></li>
                    </ul>
                </div>
                <div style="float:right; padding: 15px;"><asp:Label ID="timeAndDate" runat="server"></asp:Label></div>
            </div>

            <div id="nav">
                
            </div>

            <div id="section">
                <h2>Vet Alliance Rebate 2015</h2>
                <p>
                    Text to include
                </p>
                <p>
                    ...
                </p>
            </div>

            <div id="footer" style="font-family: Calibri; font-size: 15px;">
                © 2015 Vet Alliance Inc.
            </div>
        </div>
    </div>
</body>
</html>
