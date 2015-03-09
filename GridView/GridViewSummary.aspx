<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewSummary.aspx.cs" Inherits="GridView_GridViewSummary" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="导出Excel" OnClick="Button1_Click" />
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" HorizontalAlign="Center" 
            AutoGenerateColumns="False" GridLines="None" ShowFooter="true" OnRowDataBound="GridView1_RowDataBound">
            <AlternatingRowStyle BackColor="White" />
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="商品编号" SortExpression="ProductId" />
                <asp:BoundField DataField="ProductName" HeaderText="商品名称" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="商品价格" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="库存数量" SortExpression="Stock" />
                <asp:BoundField DataField="Description" HeaderText="商品描述" SortExpression="Description" />
            </Columns>
            <HeaderStyle BackColor="#0099FF" />
            <FooterStyle BackColor="#EFF3FB" />
        </asp:GridView>
    </div>
    </form>
</body>
</html>
