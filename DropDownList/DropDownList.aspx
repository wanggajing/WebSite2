<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList.aspx.cs" Inherits="DropDownList_DropDownList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="list" runat="server" DataValueField="OccupationId" DataTextField="OccupationName" onchange="showSelection()"></asp:DropDownList><br />
    </div>
    </form>
</body>
</html>
