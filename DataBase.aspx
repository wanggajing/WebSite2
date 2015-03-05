<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DataBase.aspx.cs" Inherits="DataBase" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
    
        <asp:Button ID="Button1" runat="server" OnClick="Button1_Click" Text="Connect" />
        <br />
        <asp:Label ID="Label1" runat="server" Text="输出信息"></asp:Label>
        <br />
        UserName:<asp:TextBox ID="TextBox1" runat="server"></asp:TextBox>
        <br />
        Password<asp:TextBox ID="TextBox2" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button2" runat="server" OnClick="Button2_Click" Text="注册" />
    
        <br />
        <br />
        <asp:Label ID="Label2" runat="server" Text="修改密码"></asp:Label>
        <br />
        用户名:<asp:TextBox ID="TextBox3" runat="server"></asp:TextBox>
        <br />
        原密码:<asp:TextBox ID="TextBox4" runat="server"></asp:TextBox>
        <br />
        新密码:<asp:TextBox ID="TextBox5" runat="server"></asp:TextBox>
        <br />
        <asp:Button ID="Button3" runat="server" OnClick="Button3_Click" Text="修改密码" />
    
        <br />
        <br />
        <asp:Button ID="Button4" runat="server" Text="统计用户人数" OnClick="Button4_Click" />
        <br />
        <asp:Label ID="Total" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Male" runat="server" Text="Label"></asp:Label>
        <br />
        <asp:Label ID="Female" runat="server" Text="Label"></asp:Label>
    
        <br />
        <br />
        <asp:Button ID="Button5" runat="server" Text="查询" OnClick="Button5_Click" />
        <br />
        <asp:Table ID="Result" runat="server" BorderStyle="Solid" BorderWidth="1px" GridLines="Both">
        </asp:Table>
    
    </div>
    </form>
</body>
</html>
