<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Login.ascx.cs" Inherits="CustomEvent_Login" %>
<table border="0" cellpadding="1" cellspaceing="0" style="border-collapse:collapse;">
    <tr><td align="center" colspan="2">登录</td></tr>
    <tr><td align="right">
        <asp:Label ID="UserNameLabel" runat="server" AssociatedControlID="UserName">用户名:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="UserName" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="UserNameRequired" runat="server" ErrorMessage="必须填写用户名" 
                ControlToValidate="UserName" ToolTip="必须填写用户名" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr><td align="right">
        <asp:Label ID="PasswordLabel" runat="server" AssociatedControlID="Password">密码:</asp:Label>
        </td>
        <td>
            <asp:TextBox ID="Password" runat="server"></asp:TextBox>
            <asp:RequiredFieldValidator ID="PasswordRequired" runat="server" ErrorMessage="必须填写密码"
                ToolTip="必须填写密码" ValidationGroup="Login1">*</asp:RequiredFieldValidator>
        </td>
    </tr>
    <tr>
        <td align="center" colspan="2" style="color:red;">
            <asp:Literal ID="FailureText" runat="server" EnableViewState="false"></asp:Literal>
        </td>
    </tr>
    <tr>
        <td align="right" colspan="2">
            <asp:Button ID="LoginButton" runat="server" Text="登录" CommandName="Login"
                ValidationGroup="Login1" OnClick="LoginButton_Click" />
        </td>
    </tr>
</table>