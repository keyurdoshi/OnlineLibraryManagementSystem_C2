<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Search.aspx.cs" Inherits="library.Search" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
        <h1>Search Book</h1>
        <table>
            <tr>
                <td>
                    <asp:Label ID="status" runat="server" />
                    <asp:DropDownList ID="dd_search" runat="server" />
                    
                </td>
                <td>
                    Search:<asp:TextBox ID="tb_search" runat="server" />
                    <asp:RequiredFieldValidator ID="rfv" runat="server" ErrorMessage="Please type search keyword" ControlToValidate="tb_search" />
                </td>
            </tr>
        </table>
        <asp:Button ID="search_b" runat="server" OnClick="search_b_click" Text="Search" />
        <asp:GridView ID="gv_search" runat="server" />
    </form>
        
    </center>
</body>
</html>
