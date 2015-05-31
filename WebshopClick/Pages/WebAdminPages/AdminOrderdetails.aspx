<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AdminOrderdetails.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.AdminOrderdetails" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="admin_content" runat="server">
    <asp:FormView CssClass="form" ID="OrderFormView" runat="server"
        ItemType="WebshopClick.Model.BLL.Order"
        SelectMethod="OrderFormView_GetData"
        DataKeyNames="OrderID"
        RenderOuterTable="true">
        <ItemTemplate>
            <asp:HiddenField ID="HiddenFieldUser" runat="server" Value='<%# BindItem.UserID %>' />
            <div class="editor-label-admin">
                <label for="Name">Namn</label>
                <asp:Label ID="Name" CssClass="inputDate" runat="server" Text='<%# BindItem.Name %>'></asp:Label>
            </div>
            <div class="editor-label-admin">
                <label for="Date">Datum</label>
                <asp:Label ID="LabelDate" CssClass="inputDate" runat="server" Text='<%# BindItem.Date %>'></asp:Label>
            </div>
            <div class="editor-label-admin">
                <label for="Address">Gatuadress</label>
                <asp:Label ID="Address" CssClass="inputDate" runat="server" Text='<%# BindItem.Address %>'></asp:Label>
            </div>
            <div class="editor-label-admin">
                <label for="Postnumber">Postnummer</label>
                <asp:Label ID="Postnumber" CssClass="inputDate" runat="server" Text='<%# BindItem.Postnumber %>'></asp:Label>
            </div>
            <div class="editor-label-admin">
                <label for="City">Postort</label>
                <asp:Label ID="TextBox1" CssClass="inputDate" runat="server" Text='<%# BindItem.City %>'></asp:Label>
            </div>
            <div class="editor-label-admin">
                <label for="PaymentDropDownList">Betallningssätt</label>
                <asp:DropDownList CssClass="inputDate" runat="server" ID="PaymentDropDownList"
                    ItemType="WebshopClick.Model.BLL.Payment"
                    SelectMethod="PaymentDropDownList_GetData"
                    DataTextField="PaymentType"
                    DataValueField="PaymentID"
                    SelectedValue='<%# BindItem.PaymentID %>'
                    AutoPostBack="false"
                    Enabled="false">
                </asp:DropDownList>
            </div>
            <div class="editor-label-admin">
                <label for="StatusDropDownList">Status</label>
                <asp:DropDownList CssClass="inputDate" runat="server" ID="StatusDropDownList"
                    ItemType="WebshopClick.Model.BLL.Status"
                    SelectMethod="StatusDropDownList_GetData"
                    DataTextField="StatusType"
                    DataValueField="StatusID"
                    SelectedValue='<%# BindItem.StatusID %>'
                    AutoPostBack="false"
                    Enabled="false">
                </asp:DropDownList>
            </div>
        </ItemTemplate>
    </asp:FormView>

    <asp:ListView ID="OrderrowListView" runat="server"
        ItemType="WebshopClick.Model.BLL.ViewOrderDetails"
        SelectMethod="OrderrowListView_GetData">
        <LayoutTemplate>
            <table class="gridAdmin">
                <thead>
                    <tr>
                        <th></th>
                        <th></th>
                        <th>Name
                        </th>
                        <th>Price
                        </th>
                        <th>Quantity
                        </th>
                        <th>Total
                        </th>
                        <th></th>
                    </tr>
                </thead>
                <tfoot>
                    <tr>

                        <td colspan="5">Subtotal:</td>
                        <td>
                            <asp:Label ID="TotalCart" runat="server" /></td>
                        <td></td>
                    </tr>
                </tfoot>

                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <%-- New rows --%>
            <tr>
                <td>
                    <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# BindItem.OrderID %>' />
                </td>
                <td>
                    <img id="table_image" class="tablethumbs" src="/Content/Images/Thumbs/<%#: Item.Image %>" />
                </td>

                <td>
                    <%#: Item.Name %>
                </td>
                <td>
                    <%#: Item.Price %>
                </td>
                <td>
                    <%#: Item.Quantity %>
                </td>
                <td>
                    <asp:Label ID="total" runat="server" Text='<%# Convert.ToDecimal(Eval("Quantity")) * Convert.ToDecimal(Eval("Price")) %>'></asp:Label>
                </td>
                <td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- This is template when no orderdetails are found in the database --%>
            <table class="gridAdmin">
                <tr>
                    <td>Beställninguppgifter saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>

    </asp:ListView>
    <asp:Button ID="btnHem2" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till beställningar" />
</asp:Content>
