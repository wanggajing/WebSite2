<%@ Page Language="C#" AutoEventWireup="true" CodeFile="FormViewSample.aspx.cs" Inherits="FormView_FormViewSample" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
</head>
<body>
    <form id="form1" runat="server">
    <div>
        <asp:FormView ID="FormView1" runat="server" DataKeyNames="ProductId" OnPageIndexChanging="FormView1_PageIndexChanging"
             OnModeChanging="FormView1_ModeChanging" OnItemDeleting="FormView1_ItemDeleting" 
            OnItemUpdating="FormView1_ItemUpdating" AllowPaging="true">
            <ItemTemplate>
                <table>
                    <tr>
                        <td>
                            <img src="../ProductImages/<%#Eval("ImageUrl") %>" alt="<%#Eval("ProductName") %>" 
                                style="width:200px" /> 
                        </td>
                        <td>
                            <span style="font-weight:bold"><%#Eval("ProductName") %></span><br />
                            价格:<%#Eval("Price","{0:C}") %><br />说明:<%#Eval("Description") %><br />库存:<%#Eval("Stock") %></td>
                        <td>
                            <asp:LinkButton ID="editButton" runat="server" Text="编辑" CommandName="edit" />
                        </td>
                        <td>
                            <asp:LinkButton ID="deleteButton" runat="server" Text="删除" CommandName="delete"
                                OnClientClick="return confirm('确实要删除吗?');" />
                        </td>
                    </tr>
                </table>
            </ItemTemplate>
            <EditItemTemplate>
                <table>
                    <tr>
                        <td>
                            商品图片<br />
                            <img src="../ProductImages/<%#Eval("ImageUrl") %>" alt="<%#Eval("ProductName") %>" 
                                style="width:200px" />
                             <br />
                            上传新的商品图片:<br />
                            <asp:FileUpload ID="imageFile" runat="server" /><br />
                        </td>
                        <td>
                            名称:<asp:TextBox ID="productName" runat="server" Text='<%#Eval("ProductName") %>'>
                               </asp:TextBox><br />
                            价格:<asp:TextBox ID="productPrice" runat="server" Text='<%#Eval("Price") %>'></asp:TextBox><br />
                            说明:<asp:TextBox ID="description" runat="server" Text='<%#Eval("Description") %>'></asp:TextBox><br />
                            库存:<asp:TextBox ID="stock" runat="server" Text='<%#Eval("stock") %>'></asp:TextBox>
                        </td>
                        <td>
                            <asp:LinkButton ID="cancelButton" runat="server" Text="取消" CommandName="cancel" />
                            <asp:LinkButton ID="updateButton" runat="server" Text="保存" CommandName="update" />
                        </td>
                        <td>
                            <asp:LinkButton ID="deleteButton" runat="server" Text="删除" CommandName="delete" />
                        </td>
                    </tr>
                </table>
            </EditItemTemplate>
        </asp:FormView>
    </div>
    </form>
</body>
</html>
