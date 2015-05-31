<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="MyPages.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.MyPages" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="search" class="container">
        <asp:TextBox ID="TxtSearch" CssClass="cell" runat="server"></asp:TextBox>
        <asp:Button ID="ImgSearch" CssClass="cell" OnClick="ImgSearch_Click" runat="server" Text="Sök" />
        <div class="navbuttonsMain">
            <asp:LinkButton Visible="false" ID="ButtonAdmin" CssClass="navbuttons" runat="server" OnClick="ButtonAdmin_Click">Admin</asp:LinkButton>
            <asp:LinkButton ID="btnCart" CssClass="navbuttons" runat="server" OnClick="btnCart_Click" Text="">
                <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
            </asp:LinkButton>
            <asp:LinkButton ID="btnLogin" CssClass="navbuttons" runat="server" OnClick="btnLogin_Click">Logga in</asp:LinkButton>
            <asp:LinkButton ID="btnProfile" CssClass="navbuttons" runat="server">Mina sidor</asp:LinkButton>
            <asp:LinkButton ID="btnHem" CssClass="navbuttons" runat="server" OnClick="btnHem_Click">Hem</asp:LinkButton>

        </div>
    </div>
    <div class="mypages">
        <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
        <asp:ListView ID="OrderListView" runat="server"
            EnableViewState="false"
            ItemType="WebshopClick.Model.BLL.Order"
            SelectMethod="OrderListView_GetData"
            DataKeyNames="OrderID">
            <LayoutTemplate>
                <table class="gridAdmin">
                    <thead>
                        <tr>
                            <th colspan="2">Kund
                            </th>
                            <th>Beställning
                            </th>
                            <th>Datum
                            </th>
                            <th>Adress
                            </th>
                            <th>Postnummer
                            </th>
                            <th>Postort
                            </th>
                            <th>Betalningstyp
                            </th>
                            <th>Status
                            </th>
                            <th></th>
                        </tr>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    <asp:DataPager ID="DataPager" runat="server" PageSize="12">
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" Första "
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" Sista "
                                ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        </Fields>
                    </asp:DataPager>
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <%-- New rows --%>
                <tr>
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# BindItem.OrderID %>' />
                    </td>
                    <td>
                        <%#: Item.Name %>
                    </td>
                    <td>
                        <%#: Item.OrderID %>
                    </td>
                    <td>
                        <%#: Item.Date %>
                    </td>
                    <td>
                        <%#: Item.Address %>
                    </td>
                    <td>
                        <%#: Item.Postnumber %>
                    </td>
                    <td>
                        <%#: Item.City %>
                    </td>
                    <td>
                        <asp:DropDownList ID="PaymentDropDownList" runat="server"
                            ItemType="WebshopClick.Model.BLL.Payment"
                            SelectMethod="PaymentDropDownList_GetData"
                            DataTextField="PaymentType"
                            DataValueField="PaymentID"
                            SelectedValue='<%# Item.PaymentID %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            ItemType="WebshopClick.Model.BLL.Status"
                            SelectMethod="StatusDropDownList_GetData"
                            DataTextField="StatusType"
                            DataValueField="StatusID"
                            SelectedValue='<%# Item.StatusID %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:Button CssClass="command" UseSubmitBehavior="False" runat="server" ID="BtnOrderDetails" Text="Detaljer" CausesValidation="false" OnClick="BtnOrderDetails_Click" />
                    </td>
                </tr>
            </ItemTemplate>
            <SelectedItemTemplate>
                <tr runat="server" style="background-color: springgreen">
                    <td>
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# BindItem.OrderID %>' />
                    </td>
                    <td>
                        <%#: Item.Name %>
                    </td>
                    <td>
                        <%#: Item.OrderID %>
                    </td>
                    <td>
                        <%#: Item.Date %>
                    </td>
                    <td>
                        <%#: Item.Address %>
                    </td>
                    <td>
                        <%#: Item.Postnumber %>
                    </td>
                    <td>
                        <%#: Item.City %>
                    </td>
                    <td>
                        <asp:DropDownList ID="PaymentDropDownList" runat="server"
                            ItemType="WebshopClick.Model.BLL.Payment"
                            SelectMethod="PaymentDropDownList_GetData"
                            DataTextField="PaymentType"
                            DataValueField="PaymentID"
                            SelectedValue='<%# Item.PaymentID %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                            ItemType="WebshopClick.Model.BLL.Status"
                            SelectMethod="StatusDropDownList_GetData"
                            DataTextField="StatusType"
                            DataValueField="StatusID"
                            SelectedValue='<%# Item.StatusID %>'
                            Enabled="false" />
                    </td>
                    <td>
                        <asp:Button CssClass="command" UseSubmitBehavior="False" runat="server" ID="BtnOrderDetails" Text="Detaljer" CausesValidation="false" OnClick="BtnOrderDetails_Click" />
                    </td>
                </tr>
            </SelectedItemTemplate>
            <EmptyDataTemplate>
                <%-- This is template when no orders are found in the database --%>
                <table class="gridAdmin">
                    <tr>
                        <td>Beställninguppgifter saknas.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>
        </asp:ListView>
        <asp:ListView ID="OrderrowListView" runat="server">
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
                        <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "OrderID") %>' />
                    </td>
                    <td>
                        <img id="table_image" class="tablethumbs" src="/Content/Images/Thumbs/<%# DataBinder.Eval(Container.DataItem, "Image") %>" />
                    </td>

                    <td>

                        <%# DataBinder.Eval(Container.DataItem, "Name") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Price") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "Quantity") %>
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
                        <td>Välj en beställning, då visas uppgifter.
                        </td>
                    </tr>
                </table>
            </EmptyDataTemplate>

        </asp:ListView>
    </div>
</asp:Content>
