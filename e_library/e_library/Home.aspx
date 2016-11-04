<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="e_library.Home" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="StyleSheet1.css" rel="stylesheet" type="text/css" runat="server" />
</head>
<body>
    <form id="form1" runat="server">
         <asp:Button ID="signout"  runat="server" Style=" float:right;" Text="Sign Out" OnClick="signout_Click" />
        <h1 style="color:white">Welcome <asp:Label ForeColor="White" ID="l" runat="server" /></h1>
        <br />

        
        <asp:Label ID="status" runat="server" /><br />
        <asp:Label ID="qty" runat="server" /><br />
        <asp:Button ID="home" CssClass="button" runat="server" Text="Home" OnClick="home_click" />
        <asp:Button ID="books" CssClass="button" runat="server"  Text="Search book" OnClick="book_click" />
        <asp:Button ID="contactus" CssClass="button" runat="server" Text="Contact us" OnClick="contactus_click" />
        <asp:Button ID="faq" CssClass="button" runat="server" Text="FAQ" OnClick="faq_click" />
        <asp:Button ID="account" CssClass="button" runat="server" Text="Account" OnClick="account_click" />
       
        <br /><br /><br /><br />

        
        <asp:Button ID="Current" Visible="false" CssClass="button1" runat="server" Text="Current" OnClick="current_Click" />
        <asp:Button ID="warning" Visible="false" CssClass="button1" runat="server" Text="Warning" OnClick="warning_click" />
        <asp:Button ID="history" Visible="false" CssClass="button1" runat="server" Text="History" OnClick="history_click" />
        
        
        <br /><br /><br /><br />
        :
        
       <div id="search" runat="server">
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
        <asp:Button ID="b" Text="Search" runat="server" OnClick="b_Search" />
       </center>
        </div>
        <br /><br /><br />
        
       
         <asp:GridView CssClass="gridview" RowStyle-CssClass="row" HeaderStyle-CssClass="header" ID="historygridview" runat="server" AutoGenerateColumns="false"  >
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

          <asp:GridView CssClass="gridview" RowStyle-CssClass="row" HeaderStyle-CssClass="header" ID="bookgridview" runat="server" AutoGenerateColumns="false"  >
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
                            <asp:Button CssClass="gb" runat="server" ID="issue" Text="Issue" OnClick="issue_click" />
                    </ItemTemplate>
                </asp:TemplateField>

                
            </Columns>
        </asp:GridView>

        <asp:DetailsView ID="bookdetailview" runat="server" RowStyle-CssClass="row" CssClass="gridview" HeaderStyle-CssClass="header" AutoGenerateRows="false">
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
        
        <asp:GridView  ID="homegridview" CssClass="gridview" RowStyle-CssClass="row" HeaderStyle-CssClass="header"  runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID" ReadOnly="true" />
                <asp:BoundField  DataField="book_name" HeaderText="Book name" ReadOnly="true"  />
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name" ReadOnly="true" />
                <asp:BoundField DataField="date_of_issue" HeaderText="Issue Date" ReadOnly="true" />
                <asp:BoundField DataField="date_of_return" HeaderText="Return Date" ReadOnly="true"  />
                <asp:TemplateField ItemStyle-Width="130px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Button CssClass="gb" runat="server" ID="bookdetail" Text="Book detail" OnClick="bookdetail_click" />
                    </ItemTemplate>
                </asp:TemplateField> 
                 <asp:TemplateField ItemStyle-Width="120px" ItemStyle-HorizontalAlign="Center" >
                     <ItemTemplate>
                            <asp:Button CssClass="gb" runat="server" ID="return" Text="return" OnClick="return_click" />
                    </ItemTemplate>
                </asp:TemplateField>
            </Columns>
        </asp:GridView>     
           
    
    </form>
</body>
</html>
