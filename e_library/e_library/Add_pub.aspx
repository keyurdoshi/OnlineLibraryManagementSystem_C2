<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Add_pub.aspx.cs" Inherits="e_library.Add_publisher" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
   
    <form id="form1" runat="server">
    <center>

    <h1>Publisher Registration form</h1>
    <asp:Label ID="status" runat="server" />
    <table>
       
        <tr>
            <td>Publisher Name:</td>
            <td><asp:TextBox ID="tb_name" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_name" Display="Dynamic" Text="Enter name" runat="server" ControlToValidate="tb_name" /></td>
        </tr>
        <tr>
            <td>Address:</td>
            <td><asp:TextBox ID="tb_addr" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_addl1" Text="enter Address" runat="server" ControlToValidate="tb_addr" /></td>
        </tr>
      
        <tr>
            <td>City:</td>
            <td><asp:TextBox ID="tb_city" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv_city" runat="server" Text="enter city" ControlToValidate="tb_city" /></td>
        </tr>
        <tr>
            <td>Contact No:</td>
            <td><asp:Textbox ID="tb_contactno" runat="server" /></td>
            <td><asp:RegularExpressionValidator ID="rev_contact" runat="server" ControlToValidate="tb_contactno" ValidationExpression="[0-9]{10}" ErrorMessage="Please enter upto 10 digits." /></td>
        </tr>
        <tr>
            <td>Email:</td>
            <td><asp:TextBox ID="tb_email" runat="server" /></td>
            <td> <asp:RegularExpressionValidator id="rev_email" runat="server" ErrorMessage="This email is not in the correct format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tb_email" /> </td>
            
             </tr>
        </table>
         </center>     
        
        <asp:Button ID="B_regpub" runat="server" Text="Submit" OnClick="B_click" />
         </form>
</body>
</html>
