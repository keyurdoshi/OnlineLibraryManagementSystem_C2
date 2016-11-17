<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="member_admin.aspx.cs" Inherits="e_library.member_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
     <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
               <asp:Button ID="Button2"  runat="server" Style=" float:left;" CssClass="gb" Text="Home" PostBackUrl="~/HomeAdmin.aspx" />
        <asp:Button ID="Button1"  runat="server" Style=" float:right;" CssClass="gb" Text="Sign Out" OnClick="signout_Click" />
    <div>
        <br /> <br />
        <asp:Label ID="status" runat="server" />
        <asp:Button ID="b1" runat="server" CssClass="button2" Text="Current" OnClick="member_available" />
        <asp:Button ID="b2" runat="server" CssClass="button2" Text="Blocked" OnClick="member_archived" />
          <br /><br /><br />
       <div id="search" visible="false" runat="server">
       <center>     
           <asp:Label ID="lserach" runat="server" Text="Search:" /><asp:TextBox ID="tb_search" runat="server" />
         
        <asp:DropDownList ID="dd_search" runat="server" >
        <asp:ListItem Text="Member ID"/>
        <asp:ListItem Text="Member Name" />
        <asp:ListItem Text="Email" />   
        <asp:ListItem Text="Category" />
        <asp:ListItem Text="Branch" />
        <asp:ListItem Text="Contact No" />
       
        </asp:DropDownList>
        <asp:Button ID="b" Text="Search" CssClass="gb" runat="server" OnClick="b_Search" />
       </center>
        </div>
        <br />
        <div id="count" runat="server" >
        <center><asp:Label ID="l_search" runat="server" Text="Invalid Search" Visible="false"/></center>
        <br />
        <center><asp:Label ID="tcount" runat="server" />&nbsp&nbsp<asp:Label ID="bcount" runat="server" />&nbsp&nbsp<asp:Label ID="ubcount" runat="server" /></center><br />
       </div>
        <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager"  HeaderStyle-CssClass="header" ID="membergridviewadmin" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField DataField="member_id" HeaderText="Member Id" />
                <asp:BoundField DataField="member_name" HeaderText="Member Name" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField DataField="password" HeaderText="Password" />
                <asp:BoundField DataField="category" HeaderText="Category" />
                <asp:BoundField DataField="branch" HeaderText="Branch" />
                <asp:BoundField DataField="phone_no" HeaderText="Contact No" />
                <asp:TemplateField ItemStyle-Width="120px">
                    <ItemTemplate>
                        <asp:Button ID="b" runat="server" OnClick="user_click" Text="View Details"  CssClass="gb"/>
                    </ItemTemplate>
                </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Label ID="l1" Text="Blocked" BackColor="gainsboro"  runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" ID="block" Text="Block" OnClick="block_click" />
                               </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Text="Unblocked" BackColor="gainsboro"  runat="server"  Visible="false"/>
                         <asp:Button CssClass="gb" runat="server" ID="unblock" Text="Unblock" OnClick="unblock_click" />
                            <asp:Button CssClass="gb" runat="server" ID="fdelete" Text="Remove" OnClick="fdelete_click"/>
                     </ItemTemplate>
                </asp:TemplateField>              
            </Columns>
        </asp:GridView>
         <asp:GridView  CssClass="mydatagrid" PagerStyle-CssClass="pager"  HeaderStyle-CssClass="header" ID="usergridviewadmin" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID"  />
                <asp:BoundField  DataField="book_name" HeaderText="Book name"   />
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name" />
               <asp:BoundField  DataField="date_of_issue" HeaderText="Date of issue" />
                <asp:BoundField DataField="actual_date_of_return" HeaderText="Date of return" />
                <asp:TemplateField ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Button CssClass="gb" runat="server" ID="bookdetail1" Text="Book detail" OnClick="bookdetail_click" />
                    </ItemTemplate>
                </asp:TemplateField>          
                </Columns>
          </asp:GridView>
         <asp:DetailsView ID="bookdetailview" runat="server"  CssClass="mydatagrid" PagerStyle-CssClass="pager"  HeaderStyle-CssClass="header" AutoGenerateRows="false">
            <Fields>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID"  />
                <asp:BoundField  DataField="book_name" HeaderText="Book name"/>
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name"/>
                <asp:BoundField DataField="language" HeaderText="Language"/>
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="length" HeaderText="No of pages"/>
                <asp:BoundField DataField="Edition" HeaderText="Edition"/>
                <asp:BoundField DataField="pub_year" HeaderText="Publisher Year" />
                <asp:BoundField DataField="pub_name" HeaderText="Publisher Name" />
            </Fields> 
        </asp:DetailsView>
    
    </div>
    </form>
</body>
</html>
