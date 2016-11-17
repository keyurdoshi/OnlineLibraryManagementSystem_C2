        <%@ Page Language="C#" AutoEventWireup="true" CodeBehind="book_admin.aspx.cs" Inherits="e_library.book_admin" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
    <div>
         <asp:Button ID="signout"  runat="server" Style=" float:right;" CssClass="gb" Text="Sign Out" OnClick="signout_Click" />
        <asp:Button ID="Button1"  runat="server" Style=" float:left;" CssClass="gb" Text="Home" OnClick="home_Click" />
        <asp:Label ID="status" runat="server" />
        <br /><br />
        <asp:Button ID="b1"  CssClass="button1" runat="server" Text="Available" OnClick="book_available" />
        <asp:Button ID="b2" CssClass="button1" runat="server" Text="Archived" OnClick="book_archived" />
         <asp:Button ID="badd" Cssclass="button1" Text="Add Book" runat="server" OnClick="badd_click" /> 
        <br /><br /><br />
       <div id="search" visible="false" runat="server">
       <center>     
           <asp:Label ID="lserach" runat="server" Text="Search:" /><asp:TextBox ID="tb_search" runat="server" />
         
        <asp:DropDownList ID="dd_search" runat="server" >
        <asp:ListItem Text="Book ID"/>
        <asp:ListItem Text="Book Name" />
        <asp:ListItem Text="Author Name" />   
        <asp:ListItem Text="Section Name" />
        <asp:ListItem Text="Description" />
        <asp:ListItem Text="Language" />
        <asp:ListItem Text="Publisher Year" />
        <asp:ListItem Text="Publisher Name" />
        <asp:ListItem Text="Edition" />
        </asp:DropDownList>
        <asp:Button ID="b" Text="Search"  CssClass="gb" runat="server" OnClick="b_Search" />
       </center>
        </div>
        <br />
        <div id="count" runat="server" >
        <center><asp:Label ID="l_search" runat="server" Text="Invalid Search" Visible="false"/></center>
        <br />
        <center><asp:Label ID="tcount" runat="server" />&nbsp&nbsp<asp:Label ID="bcount" runat="server" />&nbsp&nbsp<asp:Label ID="ubcount" runat="server" /></center><br />
       </div>
        <asp:GridView  CssClass="mydatagrid" PagerStyle-CssClass="pager" onrowediting="EditBook" OnRowUpdating="UpdateBook"  onrowcancelingedit="CancelEdit"    HeaderStyle-CssClass="header" ID="bookgridviewadmin" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:TemplateField ItemStyle-Width = "30px"  HeaderText = "Book ID">
                     <ItemTemplate>
                                  <asp:Label ID="l_book_id" BackColor="gainsboro" runat="server"  Text='<%# Eval("book_id")%>'></asp:Label>
                     </ItemTemplate>
                </asp:TemplateField>
               <asp:TemplateField ItemStyle-Width = "250px"  HeaderText = "Book Name">
                        <ItemTemplate>
                                 <asp:Label ID="l_book_name" BackColor="gainsboro" runat="server" Text='<%# Eval("book_name")%>'/>
                        </ItemTemplate>
                        <EditItemTemplate>
                                 <asp:TextBox ID="txt_book_name" Width="100px" runat="server" Text='<%# Eval("book_name")%>'/>
                         </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "200px"  HeaderText = "Author Name">
                         <ItemTemplate>
                                 <asp:Label ID="l_author_name" BackColor="gainsboro" runat="server" Text='<%# Eval("author_name")%>' />
                         </ItemTemplate>
                         <EditItemTemplate>
                                 <asp:TextBox ID="txt_author_name" Width="100px" runat="server" Text='<%# Eval("author_name")%>' />
                         </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "Section">
                          <ItemTemplate>
                                  <asp:Label ID="l_section_name" BackColor="gainsboro" runat="server" Text='<%# Eval("section_name")%>'/>
                          </ItemTemplate>
                          <EditItemTemplate>
                                <asp:TextBox ID="txt_section_name" Width="100px" runat="server" Text='<%# Eval("section_name")%>' />
                          </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "Description">
                          <ItemTemplate>
                                 <asp:Label ID="l_description" BackColor="gainsboro" runat="server"  Text='<%# Eval("description")%>'/>
                           </ItemTemplate>
                          <EditItemTemplate>
                                <asp:TextBox ID="txt_description" Width="100px" runat="server" Text='<%# Eval("description")%>'/>
                           </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "50px"  HeaderText = "No of pages">
                           <ItemTemplate>
                                 <asp:Label ID="l_length" BackColor="gainsboro" runat="server" Text='<%# Eval("length")%>'/>
                             </ItemTemplate>
                         <EditItemTemplate>
                                  <asp:TextBox ID="txt_length" Width="30px" runat="server" Text='<%# Eval("length")%>'></asp:TextBox>
                          </EditItemTemplate> 
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "100px"  HeaderText = "Language">
                             <ItemTemplate>
                                  <asp:Label ID="l_language" BackColor="gainsboro" runat="server" Text='<%# Eval("language")%>'></asp:Label>
                             </ItemTemplate>
                             <EditItemTemplate>
                                  <asp:TextBox ID="txt_language" Width="100px" runat="server" Text='<%# Eval("language")%>'></asp:TextBox>
                             </EditItemTemplate> 
               </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width = "50px"  HeaderText = "Publication year">
                               <ItemTemplate>
                                   <asp:Label ID="l_pub_year" BackColor="gainsboro" runat="server" Text='<%# Eval("pub_year")%>'/>
                                </ItemTemplate>
                             <EditItemTemplate>
                                     <asp:TextBox ID="txt_pub_year" Width="40px" runat="server" Text='<%# Eval("pub_year")%>'/>
                              </EditItemTemplate> 
                </asp:TemplateField>
            <asp:TemplateField ItemStyle-Width = "90px"  HeaderText = "Publisher Name">
           <ItemTemplate>
                 <asp:Label ID="l_pub_name" BackColor="gainsboro" runat="server" Text='<%# Eval("pub_name")%>'></asp:Label>
          </ItemTemplate>
             <EditItemTemplate>
                     <asp:TextBox ID="txt_pub_name" runat="server"  Text='<%# Eval("pub_name") %>' />
               </EditItemTemplate> 
    
         </asp:TemplateField>
          <asp:TemplateField ItemStyle-Width = "140px"  HeaderText = "Seller Name">
             <ItemTemplate>
                 <asp:Label ID="l_seller_name" BackColor="gainsboro" runat="server" Text='<%# Eval("seller_name")%>'></asp:Label>
                     </ItemTemplate>
                   <EditItemTemplate>
                       
                       <asp:TextBox ID="txt_seller_name" runat="server" Text='<%# Eval("seller_name")%>' />
                   </EditItemTemplate> 
    
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Price">
                   <ItemTemplate>
                        <asp:Label ID="l_mrp" BackColor="gainsboro" runat="server"  Text='<%# Eval("mrp")%>'></asp:Label>
                   </ItemTemplate>
                   <EditItemTemplate>
                         <asp:TextBox ID="txt_mrp"  Width="40px" runat="server" Text='<%# Eval("mrp")%>'></asp:TextBox>
                  </EditItemTemplate> 
    
             </asp:TemplateField>
             <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Quantity">
                  <ItemTemplate>
                            <asp:Label ID="l_total_qty" BackColor="gainsboro" runat="server" Text='<%# Eval("total_qty")%>'></asp:Label>
                  </ItemTemplate>
                   <EditItemTemplate>
                            <asp:TextBox ID="txt_total_qty"  Width="40px" runat="server" Text='<%# Eval("total_qty")%>'></asp:TextBox>
                   </EditItemTemplate> 
   
              </asp:TemplateField>
              <asp:TemplateField ItemStyle-Width = "40px"  HeaderText = "Edition">
                    <ItemTemplate>
                            <asp:Label ID="l_Edition" BackColor="gainsboro" runat="server" Text='<%# Eval("Edition")%>' />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txt_Edition" Width="40px" runat="server" Text='<%# Eval("Edition")%>'/>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="50px">
                    <ItemTemplate>
                        <asp:Button ID="b" runat="server" CssClass="gb" Text="View Status" OnClick="status_click" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="70px" ItemStyle-HorizontalAlign="Center">
                    <ItemTemplate>
                        <asp:Button ID="edit" runat="server" CssClass="gb" Text="Edit" CommandName="Edit" />
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Button  ID="update" runat="server" CssClass="gb" Text="Update" CommandName="Update" />
                        <asp:Button CssClass="gb" ID="cancel" runat="server" Text="Cancel" CommandName="Cancel" />
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField ItemStyle-Width="60px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Label ID="l1" Text="Blocked" runat="server"  BackColor="gainsboro" Visible="false"/>
                            <asp:Button CssClass="gb" runat="server"   ID="block" Text="Block" OnClick="block_click" />
                               </ItemTemplate>
                </asp:TemplateField>  

                <asp:TemplateField ItemStyle-Width="100px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Text="Unblocked"  BackColor="gainsboro" runat="server"  Visible="false"/>
                         <asp:Button CssClass="gb" runat="server" ID="unblock" Text="Unblock" OnClick="unblock_click" />
                            <asp:Button CssClass="gb" runat="server" ID="fdelete" Text="Remove" OnClick="fdelete_click"/>
                

                           </ItemTemplate>
                </asp:TemplateField>              
                

                
            </Columns>
        </asp:GridView>
        <div id="currentissue" runat="server" visible="false">
            <center><asp:Label ID="c_count" runat="server" Visible="false" /></center>
    <asp:GridView  ID="homegridview" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" runat="server" AutoGenerateColumns="false" >
            <Columns>
                
                <asp:BoundField DataField="email" HeaderText="User's email" />
                <asp:BoundField DataField="date_of_issue" HeaderText="Issue Date"  />
                <asp:BoundField DataField="date_of_return" HeaderText="Return Date"/>
                
            </Columns>
        </asp:GridView>     
           </div>
    

    

    </div>
    </form>
</body>
</html>
