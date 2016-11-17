<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Register_User.aspx.cs" Inherits="e_library.Register_User" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    
<link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <center>
        <h1>Register Me!!!</h1>
    <form id="form1" runat="server">
        <asp:Label ID="status" runat="server" />
    <table border="0" title="YOUR MEMBERSHIP!!" >
       
        <tr>
            <td><asp:Label ID="Label2" runat="server" Text="Your Name:"></asp:Label></td>
            <td><asp:TextBox ID="tb_name" runat="server"></asp:TextBox></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label3" runat="server" Text="Password:"></asp:Label></td>
            <td><asp:TextBox ID="tb_pwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:RequiredFieldValidator ID="rfv_pwd" runat="server" ErrorMessage="You must enter a password." Display="Dynamic" ControlToValidate="tb_pwd" /></td>
        </tr>
        <tr>
            <td><asp:Label ID="Label4" runat="server" Text="Reenter Your Password:"></asp:Label></td>
            <td><asp:TextBox ID="tb_repwd" runat="server" TextMode="Password"></asp:TextBox>
                <asp:CompareValidator id="cv_repwd" runat="server" ErrorMessage="Your password does not match." ControlToCompare="tb_pwd" ControlToValidate="tb_repwd" /> 
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label5" runat="server" Text="Email ID:"></asp:Label></td>
            <td><asp:TextBox ID="tb_email" runat="server"></asp:TextBox>
                <asp:RegularExpressionValidator id="rev_email" runat="server" ErrorMessage="This email is not in the correct format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*" ControlToValidate="tb_email" /> 
            </td>
        </tr>
        <tr>
            <td><asp:Label ID="Label6" runat="server" Text="Contact No.:"></asp:Label></td>
            <td><asp:TextBox ID="tb_contact" runat="server"></asp:TextBox>
            <asp:RegularExpressionValidator ID="rev_contact" runat="server" ControlToValidate="tb_contact" ValidationExpression="[0-9]{10}" ErrorMessage="Please enter upto 10 digits." /></td>
        </tr>
        <tr>
            <td>Branch:</td>
            <td><asp:DropDownList id="branch_dd" runat="server" /></td>
        </tr>
        <tr>
            <td>Category:</td>
            <td><asp:DropDownList ID="category_dd" runat="server" /></td>
        </tr>
       
        </table>
        <asp:Button ID="Button1_register" runat="server" style="width:130px;height:30px; background-color:antiquewhite;" Text="Register Me" OnClick="Button1_register_Click" />
        <br />
        <asp:Label ID="lblStatus" runat="server" Text=""></asp:Label>
    </form>
    </center>
</body>
</html>
