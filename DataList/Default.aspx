<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DataList_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server">
            <HeaderTemplate>
                商品编号</td>&nbsp
                <td>商品名称</td>&nbsp;<td>商品价格</td>&nbsp;<td>商品库存</td>
                &nbsp;<td>商品描述
            </HeaderTemplate>
            <ItemTemplate>
                <asp:Label ID="Label0" runat="server" Text='<%# Eval("ProductId") %>'></asp:Label></td>
                <td><asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label></td>
                <td><asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>'></asp:Label></td>
                <td><asp:Label ID="Label3" runat="server" Text='<%# Eval("Stock") %>'></asp:Label></td>
                <td><asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
