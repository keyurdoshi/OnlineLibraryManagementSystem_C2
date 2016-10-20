<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Addsysdate.aspx.cs" Inherits="library.Addsysdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <asp:Label ID="status" runat="server" />
    <form id="form1" runat="server">
    Name:<asp:TextBox ID="tb" runat="server" />
        <asp:Button ID="b" runat="server" OnClick="b_click"/>
        
     </form>
</body>
</html>
