<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="transaction.aspx.cs" Inherits="e_library.transaction" %>

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
        <asp:Button ID="Button1" OnClick="home_click"  runat="server" Style=" float:left;" CssClass="gb" Text="Home"  />
           <center>    
               <h1>Transactions</h1>
               <asp:Label ID="status" runat="server" />
               <div id="searchdiv" runat="server" >
                   <asp:Calendar ID="clndr" runat="server" OnSelectionChanged="search_click" BackColor="White" BorderColor="Black" DayNameFormat="Shortest" Font-Names="Times New Roman" Font-Size="10pt" ForeColor="Black" Height="220px" NextPrevFormat="FullMonth" TitleFormat="Month" Width="400px" >
                    <DayHeaderStyle BackColor="#CCCCCC" Font-Bold="True" Font-Size="7pt" ForeColor="#333333" Height="10pt" />
                    <DayStyle Width="14%" />
                    <NextPrevStyle Font-Size="8pt" ForeColor="White" />
                    <OtherMonthDayStyle ForeColor="#999999" />
                    <SelectedDayStyle BackColor="#CC3333" ForeColor="White" />
                    <SelectorStyle BackColor="#CCCCCC" Font-Bold="True" Font-Names="Verdana" Font-Size="8pt" ForeColor="#333333" Width="1%" />
                    <TitleStyle BackColor="Black" Font-Bold="True" Font-Size="13pt" ForeColor="White" Height="14pt" />
                    <TodayDayStyle BackColor="#CCCC99" />
                </asp:Calendar>
               <br />

              
        </center>
        
          <asp:GridView  ID="homegridview" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" runat="server" AutoGenerateColumns="false" >
            <Columns>
                <asp:BoundField  DataField="book_id" HeaderText="Book ID" />
                <asp:BoundField DataField="email" HeaderText="Email" />
                <asp:BoundField  DataField="book_name" HeaderText="Book name"  />
                <asp:BoundField DataField="author_name" HeaderText="Auhtor Name" />
                <asp:BoundField DataField="date_of_issue" HeaderText="Issue Date"  />
                <asp:BoundField DataField="date_of_return" HeaderText="Return Date"/>
                
                
            </Columns>
        </asp:GridView>     
        <asp:DetailsView ID="accountview" CssClass="mydatagrid" PagerStyle-CssClass="pager" RowStyle-CssClass="rows" HeaderStyle-CssClass="header" AutoGenerateRows="false" runat="server" >
            <Fields>
                <asp:BoundField DataField="member_id" HeaderText="Member Id" />
                <asp:BoundField DataField="member_name" HeaderText="Member Name" />
                <asp:BoundField DataField="email" HeaderText="Email"/>
                <asp:BoundField DataField="branch" HeaderText="Branch" />
                <asp:BoundField DataField="phone_no" HeaderText="Phone No" />
                <asp:BoundField DataField="category" HeaderText="Category" />
            </Fields>
        </asp:DetailsView>
        
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

    </div>
    </form>
</body>
</html>
