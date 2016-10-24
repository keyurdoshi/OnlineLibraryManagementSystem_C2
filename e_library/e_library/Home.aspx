<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="e_library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h1>Welcome <asp:Label ID="l" runat="server" /></h1>
        <br />
        <asp:Button ID="b" runat="server" Text="Sign Out" OnClick="b_Click" />
    </div>
    </form>
</body>
</html>
