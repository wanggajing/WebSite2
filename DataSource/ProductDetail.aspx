<%@ Page Language="C#" AutoEventWireup="true" CodeFile="ProductDetail.aspx.cs" Inherits="DataSource_ProductDetail" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FormView ID="FormView1" runat="server" DataSourceID="SqlDataSource1">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <img src="../ProductImages/<%#Eval("ImageUrl") %>" alt="<%#Eval("ProductName") %>"
                                 style="width:200px;" />
                        </td>
                        <td>
                            <span style="font-weight:bold;"><%#Eval("ProductName") %></span><br />
                            价格:<%#Eval("Price","{0:C}") %><br />说明:<%#Eval("Description") %><br />库存:<%#Eval("Stock") %></td>
                    </tr>
                </table>
            </ItemTemplate>
        </asp:FormView>
        <asp:SqlDataSource ID="SqlDataSource1" runat="server" ConnectionString="<%$ ConnectionStrings:ConnectionString %>" SelectCommand="SELECT [ProductId], [ProductName], [Price], [Stock], [Description], [ImageUrl] FROM [Products] WHERE ([ProductId] = @ProductId)">
            <SelectParameters>
                <asp:QueryStringParameter Name="ProductId" QueryStringField="id" Type="Int32" />
            </SelectParameters>
        </asp:SqlDataSource>
    </div>
    </form>
</body>
</html>
