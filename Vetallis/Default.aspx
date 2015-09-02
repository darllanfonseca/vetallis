<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Vetallis.Default" %>

<!DOCTYPE html>
<html>
<head>
    <title>VETALLIS</title>
    <link rel="stylesheet" href="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
    <link rel="stylesheet" href="../CSS/MainScreen.css">
    <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
    <script src="//maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
</head>
<body>
    <form id="DefaultForm" runat="server">
        <div runat="server" id="all">
            <div runat="server" id="container">
                <div id="header">
                    <div runat="server" style="position: relative; left: 0px; top: 0px; height: 80px; width: 365px; border-right: solid 1px black;">
                        <div runat="server" style="position: absolute; left: 19px; top: 20px;">
                            <button class="btn btn-success dropdown-toggle" type="button" id="menu1" data-toggle="dropdown">
                                Member
	<span class="caret"></span>
                            </button>
                            <ul runat="server" class="dropdown-menu" role="menu" aria-labelledby="menu1">
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/MemberView/InsertMember.aspx">Create New</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/MemberView/EditMember.aspx">Edit</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/MemberView/RemoveMember.aspx">Remove</a></li>
                                <li role="presentation">
                                    <hr />
                                </li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/MemberView/ActivateRemovedMember.aspx">Activate Removed Member</a></li>
                                <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/MemberView/RebateAmounts.aspx">View Rebate Amounts</a></li>
                                <li role="presentation">
                                    <hr />
                                </li>
                                <li role="presentation"><asp:Button CssClass="menuBtt" runat="server" OnClick="exportMemberList" Text="Export Current Member List" /></li>
                                <li role="presentation"><asp:Button CssClass="menuBtt" runat="server" OnClick="selectFieldsFromDB" Text="Export List of Inactives" /></li>
                            </ul>

                            <div style="position: absolute; left: 111px; top: 0px;">
                                <button class="btn btn-success dropdown-toggle" type="button" id="menu2" data-toggle="dropdown">
                                    Group
	<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu2">
                                    <li role="presentation"><a role="menuitem" id="editMember" tabindex="-1" href="/View/GroupView/InsertGroup.aspx">Create New</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/GroupView/EditGroup.aspx">Edit</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/GroupView/RemoveGroup.aspx">Remove</a></li>
                                    <li role="presentation">
                                        <hr />
                                    </li>
                                    <li role="presentation"><asp:Button CssClass="menuBtt" runat="server" OnClick="exportGroups" Text="Export List of Groups" /></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/GroupView/RebateAmounts.aspx">View Rebate Amounts</a></li>
                                </ul>
                            </div>
                            <div style="position: absolute; left: 224px; top: 0px;">
                                <button class="btn btn-success dropdown-toggle" type="button" id="menu3" data-toggle="dropdown">
                                    Partner
	<span class="caret"></span>
                                </button>
                                <ul class="dropdown-menu" role="menu" aria-labelledby="menu3">
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/PartnerView/InsertPartner.aspx">Create New</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/PartnerView/EditPartner.aspx">Edit</a></li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/PartnerView/RemovePartner.aspx">Remove</a></li>
                                    <li role="presentation">
                                        <hr />
                                    </li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/PartnerView/ActivateRemovedPartner.aspx">Activate Removed Partner</a></li>
                                    <li role="presentation"><asp:Button CssClass="menuBtt" runat="server" OnClick="exportPartnerList" Text="Export Current Partner List" /></li>
                                    <li role="presentation"><asp:Button CssClass="menuBtt" runat="server" OnClick="exportInactivePartners" Text="Export List of Inactive Partners" /></li>
                                    <li role="presentation">
                                        <hr />
                                    </li>
                                    <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/PartnerView/RebateAmounts.aspx">View Rebate Amounts</a></li>
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
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/RebateView/UploadPartnerFile.aspx">Upload Partner Rebate File</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/RebateView/ReplacePartnerFile.aspx">Replace Partner File</a></li>
                            <li role="presentation">
                                <hr />
                            </li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/RebateView/SingleRebate.aspx">Edit Single Rebate Data</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Export Rebate Data</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">Export Member Summary</a></li>
                            <li role="presentation">
                                <hr />
                            </li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/RebateView/InsertCE.aspx">Add CE Data</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="/View/RebateView/EditCE.aspx">Edit CE Data</a></li>
                            <li role="presentation"><a role="menuitem" tabindex="-1" href="#">View CE Amounts</a></li>
                        </ul>
                    </div>
                    <div style="position: absolute; float: right; right: 20px; top: 50%; margin-top: -10px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                        <div style="position: absolute; top: 20px; text-align: right; right: 0px;">
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                        </div>
                    </div>
                </div>
                <div id="nav">
                    <div id="navItem0">
                        Quick Links
                    </div>
                    <div runat="server" id="navItem1">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportMemberListBtt" AutoPostBack="true" OnClick="exportMemberList" Text="Export Current Member List" />
                    </div>
                    <div id="labelResponse" runat="server" visible="false">
                    </div>
                    <div id="navItem2">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportPartnerListBtt" AutoPostBack="true" OnClick="exportPartnerList" Text="Export Current Partner List" />
                    </div>
                    <div id="exportBtt" runat="server">
                        <asp:Button runat="server" Height="35px" Width="200px" ID="exportRebateSheetBtt" AutoPostBack="true" OnClick="exportRebateSheet" Text="Export Rebate Sheet" />
                    </div>
                </div>
                <div id="section">
                    <div id="imgContainer">
                    </div>

                </div>
                <div runat="server" id="footer" style="font-family: Calibri; font-size: 13px;">
                </div>
            </div>
        </div>
    </form>
</body>
</html>
