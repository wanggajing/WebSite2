<%@ Page Language="C#" AutoEventWireup="true" CodeFile="GridViewUpdate.aspx.cs" Inherits="GridView_GridViewUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:GridView ID="GridView1" runat="server" CellPadding="4" HorizontalAlign="Center" OnRowCancelingEdit="GridView1_RowCancelingEdit" 
            AutoGenerateColumns="False" OnRowEditing="GridView1_RowEditing" OnRowUpdating="GridView1_RowUpdating" DataKeyNames="ProductId">
            <Columns>
                <asp:BoundField DataField="ProductId" HeaderText="商品编号" SortExpression="ProductId" ReadOnly="true" />
                <asp:BoundField DataField="ProductName" HeaderText="商品名称" SortExpression="ProductName" />
                <asp:BoundField DataField="Price" DataFormatString="{0:C}" HeaderText="商品价格" SortExpression="Price" />
                <asp:BoundField DataField="Stock" HeaderText="库存数量" SortExpression="Stock" />
                <asp:BoundField DataField="Description" HeaderText="商品描述" SortExpression="Description" />
                <asp:CommandField HeaderText="编辑" ShowEditButton="True" ShowHeader="True" EditText="编辑" UpdateText="保存"
                     CancelText="取消" />
            </Columns>
        </asp:GridView>
    </div>
    </form>
</body>
</html>
