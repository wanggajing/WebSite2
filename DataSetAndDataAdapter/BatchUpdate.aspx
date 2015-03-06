<%@ Page Language="C#" AutoEventWireup="true" CodeFile="BatchUpdate.aspx.cs" Inherits="DataSetAndDataAdapter_BatchUpdate" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="update" runat="server" Text="保存修改" OnClick="update_Click" />
        <asp:Table ID="grid" runat="server"></asp:Table>
    </div>
    </form>
</body>
</html>
