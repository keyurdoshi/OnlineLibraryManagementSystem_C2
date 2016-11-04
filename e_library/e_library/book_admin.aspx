<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book_admin.aspx.cs" Inherits="e_library.book_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Label ID="status" runat="server" />
        <asp:Button ID="b1" runat="server" Text="Available" OnClick="book_available" />
        <asp:Button ID="b2" runat="server" Text="Archived" OnClick="book_archived" />
        <asp:GridView CssClass="gridview" RowStyle-CssClass="row"  HeaderStyle-CssClass="header" ID="bookgridviewadmin" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID" ReadOnly="true"  />
                <asp:BoundField  DataField="book_name" HeaderText="Book name" ReadOnly="true"/>
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name"  />
                <asp:BoundField DataField="section_name" HeaderText="Section" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="length" HeaderText="No of pages" />
                <asp:BoundField DataField="language" HeaderText="Language" />
                <asp:BoundField DataField="pub_year" HeaderText="Publisher Year" />
                 <asp:BoundField DataField="pub_name" HeaderText="Publisher Name" />
                <asp:BoundField DataField="seller_name" HeaderText="Seller Name" />
                <asp:BoundField DataField="mrp" HeaderText="Price" />
                <asp:BoundField DataField="total_qty" HeaderText="Total Quantity" />
                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Label ID="l1" Text="Blocked" runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" ID="block" Text="Block" OnClick="block_click" />
                               </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Text="Unblocked" runat="server"  Visible="false"/>
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
