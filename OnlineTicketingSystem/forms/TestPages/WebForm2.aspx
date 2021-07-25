<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm2.aspx.cs" Inherits="OnlineTicketingSystem.forms.TestPages.WebForm2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Generate" runat="server" Text="Button" OnClick="Generate_OnClick" />
        <asp:Image ID="Image1" runat="server" />
    </div>
    </form>
</body>
</html>
