<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="login.aspx.cs" Inherits="library.login" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <h1>Login</h1>
        <asp:Label ID="status" runat="server" />
     <form id="form1" runat="server">
    <table>
         <tr>
            <td>Email ID:<asp:TextBox ID="email_tb" runat="server" />
                <asp:RequiredFieldValidator ID="rfv1" runat="server" ControlToValidate="email_tb" ErrorMessage="Enter email ID" />

            </td>
        </tr>
        <tr>
            <td>
                Password:<asp:TextBox ID="password_tb" runat="server" />
                <asp:RequiredFieldValidator ID="rfv2" runat="server" ErrorMessage="Enter password" ControlToValidate="password_tb" />
            </td>
        </tr>
        <tr><td><asp:Button ID="login_b" runat="server" OnClick="login_b_click" Text="Log in" /></td></tr>
    </table>
    </form>
        <asp:HyperLink ID="link" runat="server" Text="register user" NavigateUrl="~/registeruser.aspx" />
     </center>
</body>
</html>
