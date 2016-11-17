<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login_user.aspx.cs" Inherits="e_library.Login_user" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>

<body>

 
    <center>
        
    <form id="form1" runat="server">
         <div class="div1">
        <table>
            <h1 style="background-color:white">&nbsp&nbsp Login</h1>
            <asp:Label CssClass="l" ID="status" runat="server" />
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
                    <asp:Label CssClass="l"  ID="lbl_login_pwd" runat="server" Text="Password:" />
                </td>
                <td>
                <asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"/>
                </td>
            </tr>
        </table>
      &nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp&nbsp <asp:Button CssClass="b1" ID="button_login" runat="server" style="width:130px;height:30px; background-color:antiquewhite;" Text="Login" OnClick="Login_Click"></asp:Button>
     <br />   <asp:HyperLink ID="link_regi" runat="server" NavigateUrl="~/Register_user.aspx" Text="Create Account" />
   
              </div>  </form>
       
        </center>
       
</body>
</html>
