<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="WebForm1.aspx.cs" Inherits="e_library.WebForm1" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    <asp:GridView ID="publishergridviewadmin" runat="server"  AutoGenerateColumns="false" DataSourceID="sqldatasource1" DataKeyNames="pub_name" >
        <Columns>
            <asp:BoundField DataField="pub_id" HeaderText="Publisher ID" ReadOnly="true"  SortExpression="pub_id" />
            <asp:BoundField DataField="pub_name" HeaderText="Publisher Name" ReadOnly="true" />
            <asp:BoundField DataField="city" HeaderText="City" ReadOnly="true" />
            <asp:BoundField DataField="address" HeaderText="Address" />
            <asp:BoundField DataField="email" HeaderText="Email" />
            <asp:BoundField DataField="phone_no" HeaderText="Contact No" />
            <asp:CommandField ShowEditButton="true" /> 
        </Columns>
    </asp:GridView>
    <asp:SqlDataSource ID="sqldatasource1" runat="server" ConnectionString="Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\Dell\Source\Repos\OnlineLibraryManagementSystem_C2\e_library\e_library\App_Data\library_db.mdf;Integrated Security=True"
        SelectCommand="select pub_id,pub_name,city,address,email,phone_no from [dbo].[publisher] where delete_status=0"
        UpdateCommand="Update [dbo].[publisher] SET address=@address,email=@email,phone_no=@phone_no where  pub_name=@pub_name" >
        
        <UpdateParameters>
           
            <asp:Parameter Name="address" Type="String" />
            <asp:Parameter Name="email" Type="String" />
            <asp:Parameter Name="phone_no" Type="String" />
         </UpdateParameters>
   </asp:SqlDataSource> 
        <asp:Label ID="l" runat="server" />
    </div>
    </form>
</body>
</html>
