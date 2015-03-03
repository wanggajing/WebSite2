<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="_Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="main.css" rel="stylesheet" />
</head>
<body>
    <form id="form1" runat="server">
    <div class="assistant">
        <h3>英汉双向翻译</h3>
        输入单词:<asp:TextBox ID="word" runat="server"></asp:TextBox>
        <asp:Button ID="Button1" runat="server" Text="翻译" OnClick="Button1_Click" />
        <asp:Label ID="translation" runat="server"></asp:Label>
    </div>
    </form>
</body>
</html>
