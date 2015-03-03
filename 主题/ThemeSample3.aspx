<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ThemeSample3.aspx.cs" Inherits="主题_ThemeSample3" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function changeTheme() {
            //获取当前选取的主题
            var theme = document.getElementById('<%=DropDownList1.ClientID%>').value;
            //重新加载当前页面，并通过QueryString传递选中的主题
            window.location = "ThemeSample3.aspx?theme=" + theme;
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="DropDownList1" runat="server">
            <asp:ListItem Value="GrassGreen">草绿色</asp:ListItem>
            <asp:ListItem Value="SkyBlue">天蓝色</asp:ListItem>
        </asp:DropDownList>
        <asp:Button ID="Button1" runat="server" Text="更改主题" />
        <input type="button" runat="server" onclick="changeTheme();" value="更改主题（客户端按钮）"/>
    </div>
    </form>
</body>
</html>
