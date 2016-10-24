<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_user.aspx.cs" Inherits="e_library.Login_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <table>
            <asp:Label ID="status" runat="server" />
            <tr>
                <td>
                    <asp:Label ID="lbl_login_user" runat="server" Text="Email ID:" />
                </td>
                <td>
                <asp:TextBox ID="tb_email" runat="server" />
                </td>
                <td></td>
            </tr>
            <tr>
                <td>
                    <asp:Label ID="lbl_login_pwd" runat="server" Text="Password:" />
                </td>
                <td>
                <asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"/>
                </td>
            </tr>
        </table>
            <asp:Button ID="button_login" runat="server" Text="Login" OnClick="Login_Click"></asp:Button>
        <asp:HyperLink ID="link_regi" runat="server" NavigateUrl="~/Register_user.aspx" Text="Create Account" />
    </form>
        </center>
</body>
</html>
