<%@ Page Language="C#" AutoEventWireup="true" CodeFile="SimpleBankPage.aspx.cs" Inherits="OnlineBanking_SimpleBankPage" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <h3>银行转账程序</h3>
        <table>
            <tr>
                <td>客户编号:<asp:TextBox ID="customer" runat="server"></asp:TextBox></td>
                <td>登录密码:<asp:TextBox ID="loginPass" TextMode="Password" runat="server"></asp:TextBox></td>
                <td>支付密码:<asp:TextBox ID="payPass" runat="server" TextMode="Password"></asp:TextBox></td>
            </tr>
            <tr>
                <td>转出账号:<asp:TextBox ID="source" runat="server"></asp:TextBox></td>
                <td>转账金额:<asp:TextBox ID="money" runat="server"></asp:TextBox></td>
                <td></td>
            </tr>
            <tr>
                <td>接收账号:<asp:TextBox ID="destinationName" runat="server"></asp:TextBox></td>
                <td>账号名称:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox></td>
                <td><asp:Button ID="ok" runat="server" Text="转账" Width="100" OnClick="ok_Click"></asp:Button></td>
            </tr>
        </table>
        <asp:Label runat="server" ID="error" ForeColor="Red" Visible="false"></asp:Label>
        <asp:Label runat="server" ID="message" Visible="false"></asp:Label>
    </div>
    </form>
</body>
</html>
