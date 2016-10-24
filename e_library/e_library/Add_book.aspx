<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_book.aspx.cs" Inherits="e_library.Add_book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <center>
    <form id="form1" runat="server">
    <asp:Label ID="status" runat="server" />
     <table>
        <tr>
            <td>Book name:</td>
            <td><asp:TextBox ID="tb_book_name" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv1" Text="Book name is empty" runat="server" ControlToValidate="tb_book_name" /></td>
        </tr>
        <tr>
            <td>Author name:</td>
            <td><asp:TextBox ID="tb_author_name" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv2" runat="server" Text="Author name is empty" ControlToValidate="tb_author_name" /></td>
        </tr>
        <tr>
            <td>Section Name:</td>
            <td><asp:DropDownList ID="dd_section" runat="server" >
                <asp:ListItem Value="1" Text="z" />
                </asp:DropDownList></td>
        </tr>
         <tr>
             <td>Language:</td>
             <td><asp:TextBox ID="tb_language" runat="server" /></td>
         </tr>
        <tr>
            <td>Edition:</td>
            <td><asp:TextBox ID="tb_edition" runat="server" /></td>
        </tr>
        <tr>
            <td>Description:</td>
            <td><asp:TextBox ID="tb_description" runat="server" /></td>
        </tr>
        <tr>
            <td>Quantity:</td>
            <td><asp:TextBox ID="tb_quantity" runat="server" /></td>
        </tr>
        <tr>
            <td>MRP:</td>
            <td><asp:TextBox ID="tb_mrp" runat="server" /></td>
        </tr>
        <tr>
            <td>Publish year:</td>
            <td><asp:TextBox ID="tb_pub_year" runat="server" /></td>
        </tr>
        <tr>
            <td>No of pages:</td>
            <td><asp:TextBox ID="tb_noofpages" runat="server" /></td>
        </tr>
        <tr>
            <td>Publisher Name:</td>
            <td><asp:DropDownList ID="dd_publisher_name" runat="server">
                <asp:ListItem Value="1" Text="y" />
                </asp:DropDownList></td>
        </tr>
        <tr>
            <td>Seller Name:</td>
            <td><asp:DropDownList ID="dd_seller_name" runat="server">
                <asp:ListItem Value="1"  Text="x" />
                </asp:DropDownList></td>
        </tr>
       </table>
         <asp:Button ID="b" runat="server" OnClick="b_click" Text="submit" />
    
    </form>
    </center>
</body>
</html>
