<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ReplacePartnerFile.aspx.cs" Inherits="Vetallis.View.RebateView.ReplacePartnerFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>VETALLIS - Replace Partner Data File</title>
    <link rel="stylesheet" href="../../CSS/RegForms.css" />
    <link rel="stylesheet" href="../../CSS/GridView.css" />
</head>
<body>
    <form id="uploadForm" runat="server" enctype="MULTIPART/FORM-DATA">
        <div class="all">
            <div class="container">
                <div class="header">
                    <div runat="server" style="position: absolute; font-family:Calibri; font-size: 14px; text-align:right; float: right; width: 300px; right: 10px; top: 5px; height: 50px;">
                        <asp:Label ID="timeAndDate" runat="server"></asp:Label><br />
                            <asp:LinkButton runat="server" Text="Log Out" OnClick="logout"></asp:LinkButton>
                    </div>
                </div>
                <div class="section">
                    <div class="fieldSection">
                        <div style="position: absolute; left: 50%; margin-left: -250px; width: 500px; top: 25px; text-align: center;">
                            <label>Select the Partner</label>
                            <br />
                            <asp:DropDownList runat="server" ID="partnerList" DataSourceID="Teste1" DataTextField="Name" DataValueField="ID_PARTNER">
                            </asp:DropDownList>
                            <asp:SqlDataSource ID="Teste1" runat="server" ConnectionString="<%$ ConnectionStrings:Conn %>" SelectCommand="SELECT ID_PARTNER, NAME FROM [PARTNER] ORDER BY NAME ASC"></asp:SqlDataSource>
                            <br />
                            <br />
                            <label>Select the Year</label>
                            <br />
                            <asp:DropDownList runat="server" ID="selectYear">
                                <asp:ListItem Text="Select the Year..."></asp:ListItem>
                                <asp:ListItem Text="2015"></asp:ListItem>
                                <asp:ListItem Text="2014"></asp:ListItem>
                                <asp:ListItem Text="2013"></asp:ListItem>
                                <asp:ListItem Text="2012"></asp:ListItem>
                                <asp:ListItem Text="2011"></asp:ListItem>
                            </asp:DropDownList>
                        </div>
                        <div runat="server" style="position: absolute; left: 50%; margin-left: -120px; width: 240px; top: 180px; text-align: left;">
                            <label>Now, select the new file to upload</label>
                            <br />
                            <br />
                            <asp:FileUpload ID="uploadFile" runat="server" />
                            <br />
                            <br />
                            <div runat="server" style="position: absolute; left: 0px; top: 100px;">
                                <asp:Button ID="uploadFileBtt" runat="server" OnClick="uploadExcelFile" Text="Upload File" />
                            </div>
                            <div runat="server" style="position: absolute; right: 0px; top: 100px;">    
                                <asp:Button runat="server" ID="cancelBtt" OnClick="returnMainPage" Text="Cancel" />
                            </div>
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </form>

    <form runat="server" id="responseForm" visible="false">
        <div style="position: absolute; font-family: Calibri; color: #606060; width: 200px; height: 200px; top: 50%; left: 50%; margin-top: -100px; margin-left: -100px; border: solid 1px #C0C0C0;">
            <div style="position: absolute; top: 30px; left: 15px;">
                <asp:Label ID="response" runat="server"></asp:Label>
                <br />
                <br />                               
            </div>
            <div style="position: absolute; bottom: 20%; left: 50%; margin-left: -25px;"><asp:Button runat="server" ID="OK" Width="50px" OnClick="returnMainPage" Text="Ok" /></div> 
        </div>
    </form>
</body>
</html>
