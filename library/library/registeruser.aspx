<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="registeruser.aspx.cs" Inherits="library.registeruser" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
    <h1>Registration Form</h1>
     <table>
       
     <tr><td><asp:Label ID="status" runat="server" /></td></tr>
     <tr> <td>Name:<asp:Textbox ID="name_tb" runat="server" /> <asp:RequiredFieldValidator ID="rf1" runat="server" ErrorMessage="You must enter a name" ControlToValidate="name_tb"/></td></tr>
     <tr><td>Email:<asp:Textbox ID="email_tb" runat="server" />
     <asp:RegularExpressionValidator ID="REV1" ErrorMessage="Invalid Email-Id" ControlToValidate="email_tb" runat="server" ValidationExpression="\S+@\S+\.\S+" />
     <asp:RequiredFieldValidator ID="rf2" runat="server" ErrorMessage="You must enter a email id" ControlToValidate="email_tb"/></td></tr>
     <tr><td>Password:<asp:TextBox TextMode="Password" ID="password_tb" runat="server" /><asp:RequiredFieldValidator ID="rf4" runat="server" ErrorMessage="Password is required" ControlToValidate="password_tb" /></td></tr>
     <tr><td>Confirm Password:<asp:TextBox TextMode="Password" ID="confirmpassword_tb" runat="server" /><asp:RequiredFieldValidator ID="rfv5" runat="server" ErrorMessage="Confirm Password is required" ControlToValidate="confirmpassword_tb"/>
         <asp:CompareValidator id="vldRetype" runat="server" ErrorMessage="Your password does not match." ControlToCompare="password_tb" ControlToValidate="confirmpassword_tb" /></td></tr>
     <tr><td>Contact No:<asp:TextBox ID="contact_no_tb" runat="server" /><asp:RequiredFieldValidator ID="rf3" runat="server" ErrorMessage="You must enter a contact number" ControlToValidate="contact_no_tb"/>
         <asp:RegularExpressionValidator ID="re3" ErrorMessage="Invalid Contact_no" ControlToValidate="Contact_no_tb" ValidationExpression="[0-9]{10}" runat="server" />
         </td></tr>
    <tr><td>Branch:<asp:DropDownList ID="branch_dd" runat="server" /></td></tr>   
     <tr><td>Category:<asp:DropDownList ID="category_dd" runat="server" /></td></tr>
      <tr><td><asp:Button ID="reguser_b" runat="server" Text="Submit" OnClick="reguser_b_click"/></td></tr>
     </table>
       </center>
   
     </form>
</body>
</html>
