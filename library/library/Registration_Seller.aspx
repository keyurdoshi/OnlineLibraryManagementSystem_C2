<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Registration_Seller.aspx.cs" Inherits="library.Registration_Seller" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
    <center>
    <h1>Seller</h1>
    <asp:Label ID="status" runat="server" 
    <table>
        <tr>
            <td>Publisher Name:</td>
            <td><asp:TextBox ID="tb_name" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_name" Display="Dynamic" Text="Enter name" runat="server" ControlToValidate="tb_name" /></td>
        </tr>
        <tr>
            <td>Address Line 1:</td>
            <td><asp:TextBox ID="tb_addl1" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_addl1" Text="enter Address" runat="server" ControlToValidate="tb_addl1" /></td>
        </tr>
        <tr>
            <td>Address Line 2:</td>
            <td><asp:TextBox ID="tb_addl2" runat="server" /></td>
           
        </tr>
        <tr>
            <td>City:</td>
            <td><asp:TextBox ID="tb_city" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_city" runat="server" Text="enter city" ControlToValidate="tb_city" /></td>
        </tr>
        <tr>
            <td>Contact No:</td>
            <td><asp:Textbox ID="tb_contactno" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_contactno" runat="server" Text="Enter Contact no" ControlToValidate="tb_contactno" /></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="tb_email" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_email" runat="server" Text="enter email" ControlToValidate="tb_email" /></td>
        </tr>
        </center>     
         </table>
        <asp:Button ID="B_regpub" runat="server" Text="Submit" OnClick="B_click" />
         </form>
    
</body>
</html>
