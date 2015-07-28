<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="UploadPartnerFile.aspx.cs" Inherits="Vetallis.View.UploadPartnerFile" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <script src="//code.jquery.com/jquery-1.11.3.min.js"></script>
    <title>VETALLIS - Upload Partner File</title>
</head>
<body>
    <form id="uploadForm" runat="server" enctype="MULTIPART/FORM-DATA">
        <asp:FileUpload ID="uploadFile" runat="server" /><br />
        <br />
        <asp:Button ID="uploadFileBtt" runat="server" OnClick="uploadExcelFile"
            Text="Upload File" /><br />
        <br />
    </form>

    <form id="responseForm" visible="false" runat="server">

        <div style="position: absolute; font-family: Calibri; color: #606060; width: 200px; height: 200px; top: 50%; left: 50%; margin-top: -100px; margin-left: -100px; border: solid 1px #C0C0C0;">
            <div style="position: absolute; top: 30px; left: 15px;">
                <asp:Label ID="response" runat="server"></asp:Label>
            </div>
        </div>
    </form>

</body>
</html>
