<%@ Page Language="C#" AutoEventWireup="true" CodeFile="DropDownList.aspx.cs" Inherits="DropDownList_DropDownList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <script>
        function showSelection() {
            var selection = document.getElementById('list');
            if (selection.selectedIndex >= 0) {
                var option = selection.options[selection.selectedIndex];
                var msg = "你选的职业是： " + option.text + "职业代码是： " + option.value;
                alert(msg);
            }
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DropDownList ID="list" runat="server" DataValueField="OccupationId" 
            DataTextField="OccupationName" onchange="showSelection()"></asp:DropDownList><br />
    </div>
    </form>
</body>
</html>
