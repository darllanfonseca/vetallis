<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPartnerFile.aspx.cs" Inherits="Vetallis.View.RebateView.UploadPartnerFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <title>VETALLIS - Upload Partner File</title>
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
                    <div id="fieldSection">
                        <div runat="server" style="position: absolute; text-align: left; padding-left: 10px; border: solid white 1px; padding-top: 20px; width: 200px; height: 120px; top: 60%; left: 50%; margin-left: -100px; margin-top: -60px;">
                            <div runat="server" style="position:absolute; top:20px; left:20px; height:100px;">
                                <asp:FileUpload ID="uploadFile" runat="server"/>
                            </div>
                            <div runat="server" style="position:absolute; top: 80px; left: 20px; height: 50px;">
                                <asp:Button ID="uploadFileBtt" runat="server" OnClick="uploadExcelFile" Text="Upload File" />
                                <asp:Button runat="server" ID="cancelBtt" OnClick="returnMainPage" Text="Cancel" />
                            </div>
                            
                                
                        </div>  
                       <!-- <div runat="server" style="position:absolute; height:120px; width:200px; left: 50%; top: 25%; margin-top: -60px; margin-left: -100px; border: white solid 1px;">
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
                        </div>  -->
                        <div runat="server" id="errorDiv" visible="true" style="position:absolute; height:50px; color:red; text-align:left; font-size:13px; width: 300px; bottom:30px; left: 50%; margin-left: -150px; border: white solid 1px;">
                            <asp:Label runat="server" ID="errorMsg"/>
                        </div>
                    </div>
                </div>
            </div>
        </div>

        
    </form>

    <form id="responseForm" visible="false" runat="server">

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
