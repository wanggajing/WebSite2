<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ParameterizedQuery.aspx.cs" Inherits="DataSource_ParameterizedQuery" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        根据名字搜索:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="搜索" />
        <asp:GridView ID="GridView1" runat="server" AutoGenerateColumns="False" DataKeyNames="ProductId" DataSourceID="SqlDataSource1">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="ProductId" InsertVisible="False" ReadOnly="True" SortExpression="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="ProductName" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" HeaderText="Price" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="Stock" SortExpression="Stock" />
                <asp:BoundField DataField="Description" HeaderText="Description" SortExpression="Description" />
                <asp:BoundField DataField="ImageUrl" HeaderText="ImageUrl" SortExpression="ImageUrl" />
                
                <asp:HyperLinkField DataNavigateUrlFields="ProductId" DataNavigateUrlFormatString="ProductDetail.aspx?id={0}" HeaderText="Detail" Text="查看" />
                
            </Columns>
        </asp:GridView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductId], [ProductName], [Price], [Stock], [Description], [ImageUrl] FROM [Products] WHERE ([ProductName] LIKE '%' + @ProductName + '%')">
            <SelectParameters>
                <asp:ControlParameter ControlID="TextBox1" Name="ProductName" PropertyName="Text" Type="String" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
