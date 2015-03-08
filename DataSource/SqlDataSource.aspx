<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SqlDataSource.aspx.cs" Inherits="DataSource_SqlDataSource" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" AllowPaging="True" AllowSorting="True" AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:CommandField ShowDeleteButton="True" ShowEditButton="True" ShowSelectButton="True" />
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="ImageUrl" HeaderText="ImageUrl" SortExpression="ImageUrl" />
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" DeleteCommand="DELETE FROM [Products] WHERE [ProductId] = @ProductId" InsertCommand="INSERT INTO [Products] ([ProductName], [Price], [Stock], [Description], [ImageUrl]) VALUES (@ProductName, @Price, @Stock, @Description, @ImageUrl)" SelectCommand="SELECT [ProductId], [ProductName], [Price], [Stock], [Description], [ImageUrl] FROM [Products]" UpdateCommand="UPDATE [Products] SET [ProductName] = @ProductName, [Price] = @Price, [Stock] = @Stock, [Description] = @Description, [ImageUrl] = @ImageUrl WHERE [ProductId] = @ProductId">
            <DeleteParameters>
                <asp:Parameter Name="ProductId" Type="Int32" />
            </DeleteParameters>
            <InsertParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Stock" Type="Double" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ImageUrl" Type="String" />
            </InsertParameters>
            <UpdateParameters>
                <asp:Parameter Name="ProductName" Type="String" />
                <asp:Parameter Name="Price" Type="Double" />
                <asp:Parameter Name="Stock" Type="Double" />
                <asp:Parameter Name="Description" Type="String" />
                <asp:Parameter Name="ImageUrl" Type="String" />
                <asp:Parameter Name="ProductId" Type="Int32" />
            </UpdateParameters>
        </asp:SqlDataSource>
    
    </div>
    </form>
</body>
</html>
