<%@ Page Language="C#" AutoEventWireup="true" CodeFile="Default.aspx.cs" Inherits="CustomAttribute_Default" %>

<%@ Register Src="~/CustomAttribute/ProgressBar.ascx" TagPrefix="uc1" TagName="ProgressBar" %>


<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <uc1:ProgressBar runat="server" ID="ProgressBar1" />
        <br />
        <asp:Button ID="Button1" runat="server" Text="增加" OnClick="Button1_Click" />
        <asp:Button ID="Button2" runat="server" Text="减少" OnClick="Button2_Click" />
        <br />
        前景色:
        <asp:DropDownList ID="foreColorList" runat="server">
            <asp:ListItem Value="Green">绿色</asp:ListItem>
            <asp:ListItem Value="Red">红色</asp:ListItem>
            <asp:ListItem Value="Blue">蓝色</asp:ListItem>
        </asp:DropDownList>
        背景色:
        <asp:DropDownList ID="backColorList" runat="server">
            <asp:ListItem Value="Black">黑色</asp:ListItem>
            <asp:ListItem Value="White">白色</asp:ListItem>
            <asp:ListItem Value="Silver">灰色</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button3" runat="server" Text="修改颜色" OnClick="Button3_Click" />
    </div>
    </form>
</body>
</html>
