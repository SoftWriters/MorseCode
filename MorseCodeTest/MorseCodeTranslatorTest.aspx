<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="MorseCodeTranslatorTest.aspx.cs" Inherits="MorseCodeTest.MorseCodeTranslatorTest" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Morse Code Translator</title>
    <link rel="stylesheet" href="styles.css" />
</head>
<body>
    <asp:Label ID="lblFileSelector" runat="server" Text="Please select a file containing Morse Code:"></asp:Label>
    <form id="form1" runat="server">
        <asp:FileUpload ID="fileUploader" runat="server" />
        <asp:Button ID="btnTranslate" runat="server" Text="Translate to English" OnClick="btnTranslate_Click" />
    </form>
    <asp:Panel ID="result" runat="server">
        <asp:Label id="lblResult" runat="server"/>
    </asp:Panel>
</body>
</html>
