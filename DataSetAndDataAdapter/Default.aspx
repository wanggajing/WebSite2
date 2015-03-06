<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="DataSetAndDataAdapter_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:Button ID="Button1" runat="server" Text="填充数据" OnClick="Button1_Click" />
        <asp:Table ID="Table1" runat="server" BorderWidth="1px" BorderStyle="Solid" GridLines="Both"></asp:Table>
    </div>
    </form>
</body>
</html>
