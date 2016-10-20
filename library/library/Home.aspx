<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome</h1>
    <asp:Button ID="logout_b" runat="server" Text="LOG OUT" OnClick="logout_b_click" />
    </div>
    </form>
</body>
</html>
