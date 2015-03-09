<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductList.aspx.cs" Inherits="DataList_ProductList" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:DataList ID="DataList1" runat="server" HorizontalAlign="Center" RepeatColumns="2">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <img src="../ProductImages/<%#Eval("ImageUrl") %>" alt="<%#Eval("ProductName") %>" style="width:100px;"/>
                        </td>    
                        <td>
                            <span style="font-weight:bold;"><%#Eval("ProductName") %></span><br />
                            价格:<%#Eval("Price","{0:C}")%><br />
                            说明:<%#Eval("Description") %>
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <ItemStyle BackColor="White" />
            <AlternatingItemStyle BackColor="#ffffcc" />
        </asp:DataList>
    </div>
    </form>
</body>
</html>
