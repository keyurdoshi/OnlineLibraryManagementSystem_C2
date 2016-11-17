<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="e_library.HomeAdmin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
      <asp:Button ID="signout"  runat="server" Style=" float:right;" CssClass="gb" Text="Sign Out" OnClick="signout_Click" />
      <center> <h1>Admin Page</h1></center>
   <div>
     <center><asp:Button ID="b1" CssClass="badmin" Text="Books" runat="server" OnClick="book_click" />
        <asp:Button ID="b2" CssClass="badmin" Text="Publishers" runat="server" OnClick="publisher_Click"  />
        <asp:Button ID="b3" CssClass="badmin" Text="Sellers" runat="server" OnClick="seller_click" />
        <asp:Button ID="b4" CssClass="badmin" Text="Users" runat="server" OnClick="user_click" />
       
    </div>
        
    </form>
</body>
</html>
