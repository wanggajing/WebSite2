<%@ Control Language="C#" AutoEventWireup="true" CodeFile="Weather.ascx.cs" Inherits="CustomControl_Weather" %>
<table>
    <tr>
        <td>
            <asp:Label ID="cityName" runat="server" Text="城市名称"></asp:Label><br />
            天气
        </td>
        <td>
            <asp:Image ID="weatherImage" runat="server"  Height="32px" AlternateText="天气"/>
        </td>
        <td>
            <asp:Label ID="weatherDesc" runat="server" Text="天气情况"></asp:Label>
        </td>
    </tr>
</table>
