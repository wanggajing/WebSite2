<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default2.aspx.cs" Inherits="GridView_Default2" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:TextBox ID="size" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="修改" OnClick="Button1_Click" />
        <br />
        <asp:TextBox ID="pageNumber" runat="server"></asp:TextBox>
        <asp:Button ID="Button2" runat="server" Text="查看" OnClick="Button2_Click" />
        <br />
        <br />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" HorizontalAlign="Center" 
            AutoGenerateColumns="False" AllowPaging="true" PageSize="5" 
            OnPageIndexChanging="GridView1_PageIndexChanging">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="商品编号" SortExpression="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="商品名称" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="商品价格" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="库存数量" SortExpression="Stock" />
                <asp:BoundField DataField="Description" HeaderText="商品描述" SortExpression="Description" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
