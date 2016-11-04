<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="e_library.HomeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="b1" Text="Books" runat="server" OnClick="book_click" />
        <asp:Button ID="b2" Text="Publishers" runat="server" OnClick="publisher_Click" />
        <asp:Button ID="b3" Text="Sellers" runat="server" OnClick="seller_click" />
        <asp:Button ID="b4" Text="Users" runat="server" OnClick="user_click" />
        <asp:Button ID="b5" Text="Sections" runat="server" OnClick="section_click" />
    
    </div>
    </form>
</body>
</html>
