<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="issue_book_staff.aspx.cs" Inherits="e_library.issue_book" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <center>
        <asp:Label ID="status" runat="server" /><br />
        <asp:Label ID="status1" runat="server" />
    <table>
        <tr>
            <td>Member email ID:</td>
            <td><asp:TextBox ID="tb_member_email_id" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv1" Text="Email Id required" ControlToValidate="tb_member_email_id" runat="server" /></td>
        </tr>
        <tr>
            <td>Book Id:</td>
            <td><asp:TextBox ID="tb_book_id" runat="server" /></td>
            <td><asp:RequiredFieldValidator ID="rfv2" runat="server" Text="Book_id is required" ControlToValidate="tb_book_id" /></td>
        </tr>

    </table>
        <asp:Button ID="b" Text="Submit" runat="server" OnClick="b_click"/>
    </center>
    </form>
</body>
</html>
