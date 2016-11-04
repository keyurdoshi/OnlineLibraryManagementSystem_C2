<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Seller_admin.aspx.cs" Inherits="e_library.Seller_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="status" runat="server" />
      <asp:Button ID="b1" runat="server" Text="Available" OnClick="seller_available" />
        <asp:Button ID="b2" runat="server" Text="Blocked" OnClick="seller_archived" />
        <asp:GridView CssClass="gridview" RowStyle-CssClass="row"  HeaderStyle-CssClass="header" ID="sellergridviewadmin" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField DataField="seller_id" HeaderText="Seller ID" />
                <asp:BoundField DataField="seller_name" HeaderText="Seller Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="address" HeaderText="Address" />
                <asp:BoundField DataField="city" HeaderText="City" />
                <asp:BoundField DataField="phone_no" HeaderText="Contact NO" />
                 <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Label ID="l1" Text="Blocked" runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" ID="block" Text="Block" OnClick="block_click" />
                               </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Text="undo" runat="server"  Visible="false"/>
                         <asp:Button CssClass="gb" runat="server" ID="unblock" Text="Unblock" OnClick="unblock_click" />
                            <asp:Button CssClass="gb" runat="server" ID="fdelete" Text="Remove" OnClick="fdelete_click"/>
                     </ItemTemplate>
                </asp:TemplateField>              
            </Columns>
        </asp:GridView>

    </div>
    </form>
</body>
</html>
