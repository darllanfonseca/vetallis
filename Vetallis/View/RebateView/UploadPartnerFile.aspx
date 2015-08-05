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
                <div class="header"></div>
                <div class="section">
                    <div id="fieldSection">
                        <div runat="server" style="position: absolute; text-align: left; padding-left: 10px; padding-top: 20px; width: 200px; height: 200px; top: 50%; left: 50%; margin-left: -100px; margin-top: -100px;">
                            <asp:FileUpload ID="uploadFile" runat="server"/>
                            <br />
                            <br />
                            <asp:Button ID="uploadFileBtt" runat="server" OnClick="uploadExcelFile" Text="Upload File" />
                            <div runat="server" style="position: absolute; bottom:20px; right: 10px;">
                                <asp:Button runat="server" ID="cancelBtt" OnClick="returnMainPage" Text="Cancel" />
                            </div>
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
