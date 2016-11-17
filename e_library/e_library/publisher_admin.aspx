<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="publisher_admin.aspx.cs" Inherits="e_library.publisher_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
               <asp:Button ID="Button1"  runat="server" Style=" float:left;" CssClass="gb" Text="Home" PostBackUrl="~/HomeAdmin.aspx" />
         <asp:Button ID="signout"  runat="server" Style=" float:right;" CssClass="gb" Text="Sign Out" OnClick="signout_Click" />
        <asp:Label ID="status" runat="server" />
        <br /><br />
        <asp:Button ID="b1" CssClass="button1" runat="server" Text="Available" OnClick="publisher_available" />
        <asp:Button ID="b2" CssClass="button1" runat="server" Text="Blocked" OnClick="publisher_archived" />
        <asp:Button ID="b3" CssClass="button1" runat="server" Text="Add Publisher" OnClick="padd_click " />
         <br /><br /><br />
        <div id="search" visible="false" runat="server">
        <center>     
        <asp:Label ID="lserach" runat="server" Text="Search:" /><asp:TextBox ID="tb_search" runat="server" />
         
        <asp:DropDownList ID="dd_search" runat="server" >
            <asp:ListItem Text="Publisher Id" />
            <asp:ListItem Text="Publisher Name" />
            <asp:ListItem Text="City" />
            <asp:ListItem Text="Address" />
            <asp:ListItem Text="Email" />
            <asp:ListItem Text="Phone No" />
        </asp:DropDownList>
        <asp:Button ID="b" Text="Search"  CssClass="gb" runat="server" OnClick="b_Search" />
        </center>
        </div>
        <br />
      
        <br />
        <div id="count" runat="server" >
        <center><asp:Label ID="l_search" runat="server" Visible="false" /></center>
        <center><asp:Label ID="tcount" runat="server" />&nbsp&nbsp<asp:Label ID="bcount" runat="server" />&nbsp&nbsp<asp:Label ID="ubcount" runat="server" /></center><br />
       </div>
        <asp:GridView ID="publishergridviewadmin"  CssClass="mydatagrid" PagerStyle-CssClass="pager"  HeaderStyle-CssClass="header" 
            runat="server"  AutoGenerateColumns="false" onrowcancelingedit="gridView_RowCancelingEdit" onrowediting="gridView_RowEditing"
        onrowupdating="gridView_RowUpdating">
        <Columns>
                    <asp:TemplateField HeaderText="ID">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_id" BackColor="gainsboro"  runat="server" Text='<%#Eval("pub_id") %>'></asp:Label>  
                    </ItemTemplate>
                </asp:TemplateField>
              
                <asp:TemplateField HeaderText="Name">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_name" BackColor="gainsboro"  runat="server" Text='<%#Eval("pub_name") %>'></asp:Label>  
                    </ItemTemplate>  
                    
                </asp:TemplateField>  
                <asp:TemplateField HeaderText="City">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_city" BackColor="gainsboro"  runat="server" Text='<%#Eval("city") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_city"  runat="server" Text='<%#Eval("city") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_email" BackColor="gainsboro"  runat="server" Text='<%#Eval("email") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_email" runat="server" Text='<%#Eval("email") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Address">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_address" BackColor="gainsboro"  runat="server" Text='<%#Eval("address") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_address" runat="server" Text='<%#Eval("address") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Phone no">  
                    <ItemTemplate>  
                        <asp:Label ID="lbl_phn" BackColor="gainsboro"  runat="server" Text='<%#Eval("phone_no") %>'></asp:Label>  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:TextBox ID="txt_phn" runat="server" Text='<%#Eval("phone_no") %>'></asp:TextBox>  
                    </EditItemTemplate>  
                </asp:TemplateField>
				 <asp:TemplateField ItemStyle-Width="120px">  
                    <ItemTemplate>  
                        <asp:Button ID="btn_Edit" CssClass="gb"  Width="100px" runat="server" Text="Edit" CommandName="Edit" />  
                    </ItemTemplate>  
                    <EditItemTemplate>  
                        <asp:Button ID="btn_Update" CssClass="gb" runat="server" Width="100px" Text="Update" CommandName="Update"/>  
                        <asp:Button ID="btn_Cancel" CssClass="gb"  runat="server" Text="Cancel" Width="100px" CommandName="Cancel"/>  
                    </EditItemTemplate>  
                </asp:TemplateField> 
                 <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Label ID="l1" Text="Blocked"  BackColor="gainsboro"  runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" Width="100px" ID="block" Text="Block" OnClick="block_click" />
                               </ItemTemplate>
                </asp:TemplateField>  
                <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Width="100px" BackColor="gainsboro"   Text="Unblocked" runat="server"  Visible="false"/>
                         <asp:Button CssClass="gb" Width="100px" runat="server" ID="unblock" Text="Unblock" OnClick="unblock_click" />
                            <asp:Button CssClass="gb" Width="100px" runat="server" ID="fdelete" Text="Remove" OnClick="fdelete_click"/>
                     </ItemTemplate>
                </asp:TemplateField>              
            </Columns>

    </asp:GridView>
    
 
     

    </div>
    </form>
</body>
</html>
