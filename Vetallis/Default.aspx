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
    <form id="DefaultForm" runat="server">
        <div id="all">
            <div id="container">
                <div id="header">
                    <div runat="server" style="position: relative; left: 0px; top: 0px; height: 80px; width: 365px; border-right: solid 1px black;">
                        <div style="position: absolute; left: 19px; top: 20px;">
                            <button class="btn btn-success dropdown-toggle" type="button" id="menu1" data-toggle="dropdown">
                                Insert 
	<span class="caret"></span>
                            </button>
                            <ul class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertMember.aspx">New Member</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertPartner.aspx">New Partner</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/InsertGroup.aspx">New Group</a></li>
                            </ul>

                            <div style="position: absolute; left: 111px; top: 0px;">
                                <button class="btn btn-success dropdown-toggle" type="button" id="menu2" data-toggle="dropdown">
                                    Edit
	<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu2">
                                    <li role="presentation"><a role="menuitem" id="editMember" tabindex="-1" href="View/EditMember.aspx">Member</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditPartner.aspx">Partner</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="View/EditGroup.aspx">Group</a></li>
                                </ul>
                            </div>
                            <div style="position: absolute; left: 224px; top: 0px;">
                                <button class="btn btn-success dropdown-toggle" type="button" id="menu3" data-toggle="dropdown">
                                    Remove
	<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu3">
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveMember.aspx">Member</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemovePartner.aspx">Partner</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="View/RemoveGroup.aspx">Group</a></li>
                                </ul>
                            </div>
                        </div>
                    </div>
                    <div style="position: absolute; top: 20px; left: 385px;">
                        <button class="btn btn-success dropdown-toggle" type="button" id="menu4" data-toggle="dropdown">
                                    Rebate
	<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu4">
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/UploadPartnerFile.aspx">Upload Partner Rebate File</a></li>
                                </ul>                        
                    </div>
                    <div style="position: absolute; float: right; right: 20px; top: 50%; margin-top: -10px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label>
                    </div>
                </div>
                <div id="nav">
                    <div runat="server" id="navItem1">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportMemberListBtt" AutoPostBack="true" OnClick="exportMemberList" Text="Export Current Member List" />
                    </div>
                    <div id="labelResponse" runat="server" visible="false">
                    </div>
                    <div id="navItem2">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportPartnerListBtt" AutoPostBack="true" OnClick="exportPartnerList" Text="Export Current Partner List" />
                    </div>
                    <div id="exportBtt" runat="server">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportRebateSheetBtt" AutoPostBack="true" OnClick="activateYearDropDown" Text="Export Rebate Sheet" />
                    </div>
                    <div id="pickYear" runat="server" visible="false" class="navItem3">
                        <asp:DropDownList runat="server" Height="35px" Width="200px" ID="rebateYear" AutoPostBack="true" OnSelectedIndexChanged="exportRebateSheet">
                            <asp:ListItem
                                Text="Select the Year..." />
                            <asp:ListItem
                                Text="2015" />
                            <asp:ListItem
                                Text="2014" />
                            <asp:ListItem
                                Text="2013" />
                            <asp:ListItem
                                Text="2012" />
                            <asp:ListItem
                                Text="2011" />
                            <asp:ListItem
                                Text="2010" />
                        </asp:DropDownList>
                    </div>
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
    </form>
</body>
</html>
