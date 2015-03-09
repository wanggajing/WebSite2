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
            <ItemTemplate>
                <asp:Label ID="Label1" runat="server" Text='<%# Eval("ProductName") %>'></asp:Label>
                &nbsp;<asp:Label ID="Label2" runat="server" Text='<%# Eval("Price") %>'></asp:Label>
                &nbsp;<asp:Label ID="Label3" runat="server" Text='<%# Eval("Stock") %>'></asp:Label>
                &nbsp;<asp:Label ID="Label4" runat="server" Text='<%# Eval("Description") %>'></asp:Label>
            </ItemTemplate>
        </asp:DataList>
    </div>
    </form>
</body>
</html>
