
<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="e_library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:Button ID="signout"  runat="server" CssClass="gb"  style="width:130px;height:30px; background-color:antiquewhite;float:right;" Text="Sign Out" OnClick="signout_Click" />
        <h1 style="color:#321919">Welcome <asp:Label ForeColor="#321919" ID="l" runat="server" /></h1>
        <br />

        
       
        <asp:Label ID="qty" runat="server" /><br />
        <asp:Button ID="home" CssClass="button" runat="server" Text="Home" OnClick="home_click" />
        <asp:Button ID="books" CssClass="button" runat="server"  Text="Search book" OnClick="book_click" />
        <asp:Button ID="contactus" CssClass="button" runat="server" Text="Contact us" OnClick="contactus_click" />
        <asp:Button ID="faq" CssClass="button" runat="server" Text="FAQ" OnClick="faq_click" />
        <asp:Button ID="account" CssClass="button" runat="server" Text="Account" OnClick="account_click" />
       
        <br /><br /><br /><br />

        <asp:DetailsView ID="accountview" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" AutoGenerateRows="false" runat="server" >
            <Fields>
                <asp:BoundField DataField="member_id" HeaderText="Member Id" ReadOnly="true" />
                <asp:BoundField DataField="member_name" HeaderText="Member Name" ReadOnly="true" />
                <asp:BoundField DataField="email" HeaderText="Email" ReadOnly="true" />
                <asp:TemplateField HeaderText="Branch">
                   <ItemTemplate>
                       <asp:Label ID="l" runat="server" Text='<% #Eval("Branch") %>' />
                   </ItemTemplate>
                    <EditItemTemplate>
                        <asp:Label ID="l" runat="server" Text='<% #Eval("Branch") %>' />
                        <asp:TextBox ID="tb" runat="server" Text='<% #Eval("Branch") %>' />
                    </EditItemTemplate>
                    
                </asp:TemplateField>
                <asp:BoundField DataField="phone_no" HeaderText="Phone No" ReadOnly="true" />
            </Fields>
        </asp:DetailsView>

     
        <asp:Button ID="Current" Visible="false" CssClass="button1" runat="server" Text="Current" OnClick="current_Click" />
        <asp:Button ID="warning" Visible="false" CssClass="button1" runat="server" Text="Warning" OnClick="warning_click" />
        <asp:Button ID="history" Visible="false" CssClass="button1" runat="server" Text="History" OnClick="history_click" />
    
        
        <br /><br /><br /><br />
        
        
       <div id="search" runat="server">
       <center>     
           <asp:Label ID="lsearch" runat="server" Text="Search:" /><asp:TextBox ID="tb_search" runat="server" />
         
        <asp:DropDownList ID="dd_search" runat="server" >
        <asp:ListItem Text="Book ID"/>
        <asp:ListItem Text="Book Name" />
        <asp:ListItem Text="Author Name" />   
        <asp:ListItem Text="Section Name" />
       
        <asp:ListItem Text="Language" />
        <asp:ListItem Text="Publisher Year" />
        <asp:ListItem Text="Publisher Name" />
        <asp:ListItem Text="Edition" />
        </asp:DropDownList>
        <asp:Button ID="b" Text="Search"  CssClass="search" runat="server" OnClick="b_Search" />
       </center>
        </div>
       
       <center><asp:Label ID="l_search" runat="server" Text="Invalid  Search" visible="false"/><asp:Label ID="status" runat="server" /></center>
        <br /><br />
        
       
         <asp:GridView CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" ID="historygridview" runat="server" AutoGenerateColumns="false"  >
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

          <asp:GridView   CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" ID="bookgridview" runat="server" AutoGenerateColumns="false"  >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID"  />
                <asp:BoundField  DataField="book_name" HeaderText="Book name"  />
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name"  />
                <asp:BoundField DataField="section_name" HeaderText="Section" />
                <asp:BoundField DataField="description" HeaderText="Description" />
                <asp:BoundField DataField="length" HeaderText="No of pages" />
                <asp:BoundField DataField="language" HeaderText="Language" />
                <asp:BoundField DataField="pub_year" HeaderText="Publisher Year" />
                 <asp:BoundField DataField="pub_name" HeaderText="Publisher Name" />
                <asp:BoundField DataField="Edition" HeaderText="Edition" />
                                       
                 <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l" Text="Issued" runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" ID="issue" Text="Issue" OnClick="issue_click" />
                    </ItemTemplate>
                </asp:TemplateField>

                
            </Columns>
        </asp:GridView>

        <asp:DetailsView ID="bookdetailview" runat="server" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" AutoGenerateRows="false">
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
        
        <asp:GridView  ID="homegridview" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID" />
                <asp:BoundField  DataField="book_name" HeaderText="Book name"  />
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name" />
                <asp:BoundField DataField="date_of_issue" HeaderText="Issue Date"  />
                <asp:BoundField DataField="date_of_return" HeaderText="Return Date"/>
                <asp:TemplateField ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Button CssClass="gb" runat="server" ID="bookdetail" Text="Book detail" OnClick="bookdetail_click" />
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                         <asp:Label ID="l1" Text="Returned" runat="server"  Visible="false"/>
                            <asp:Button CssClass="gb" runat="server" ID="return" Text="return" OnClick="return_click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>     


                <div id="contact_us1" runat="server" >
            Name : Keyur Doshi<br />
            E-mail : kdoshi96@gmail.com <br />
            Phone no. : 8511410091<br />
            <br />
            Name : Akash Desai<br />
            E-mail : akashdesai2010@yahoo.in<br />
            Phone no. : 8980335100<br />
            <br />
            </div>

        <div id="faq1" runat="server">
            Q : How many maximum books can a person issue?<br />
            A : 3 books at a time.<br />
            <br />
            Q : Can I issue same book again?<br />
            A : No.<br />
            <br />
            Q : How many days can I keep a book?<br />
            A : 15 days maximum.<br />
            <br />
            Q : Do you charge any fees for books?<br />
            A : No, all our servicies are free.<br />
            <br />
        </div>
           
    
    </form>
</body>
</html>
