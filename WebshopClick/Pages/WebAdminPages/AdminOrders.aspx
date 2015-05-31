<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.AdminOrders" EnableViewState="false" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="admin_content" runat="server">

    <div>
        <asp:DropDownList runat="server" ID="StatusDropDownList"
            SelectMethod="StatusDropDownList_GetData"
            DataTextField="StatusType"
            DataValueField="StatusID"
            OnSelectedIndexChanged="SelectionHasChanged"
            AutoPostBack="True"
            AppendDataBoundItems="true">
            <asp:ListItem>-- Välj status --</asp:ListItem>
        </asp:DropDownList>
    </div>
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
    <asp:ListView ID="OrderListView" runat="server"
        ItemType="WebshopClick.Model.BLL.Order"
        SelectMethod="OrderListView_GetData"
        UpdateMethod="OrderListView_UpdateItem"
        DeleteMethod="OrderListView_DeleteItem"
        DataKeyNames="OrderID">
        <LayoutTemplate>
            <table class="gridAdmin">
                <thead>
                    <tr>
                        <th colspan="2">Kund
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
                    <asp:Button CssClass="command" UseSubmitBehavior="False" ID="Button1" runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                        OnClientClick="return confirm('Ta bort beställning permanent?');" />
                    <asp:Button CssClass="command" UseSubmitBehavior="False" CommandName="Edit" ID="Button2" runat="server" Text="Uppdatera status" />
                    <asp:Button CssClass="command" UseSubmitBehavior="False" runat="server" ID="BtnOrderDetails" Text="Detaljer" CausesValidation="false" OnClick="BtnOrderDetails_Click" />
                </td>
            </tr>
        </ItemTemplate>

        <EmptyDataTemplate>
            <%-- This is template when no orders are found in the database --%>
            <table class="gridAdmin">
                <tr>
                    <td>Beställninguppgifter saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>

        <EditItemTemplate>
            <tr>
                <asp:HiddenField ID="HiddenField1" runat="server" Value='<%# BindItem.OrderID %>' />

                <td>
                    <asp:HiddenField ID="HiddenFieldButton" runat="server" Value='<%# BindItem.UserID %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox5" runat="server" Enabled="false" Text='<%# BindItem.Name %>' />
                </td>
                <td>

                    <asp:TextBox ID="TextBox1" runat="server" Enabled="false" Text='<%# BindItem.Date %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox2" runat="server" Enabled="false" Text='<%# BindItem.Address %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox3" runat="server" Enabled="false" Text='<%# BindItem.Postnumber %>' />
                </td>
                <td>
                    <asp:TextBox ID="TextBox4" runat="server" Enabled="false" Text='<%# BindItem.City %>' />
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
                    <!-- BindItem.StatusID  IMPORTANT! not Item.StatusID -->
                    <asp:DropDownList ID="LineDropDownList" runat="server"
                        ItemType="WebshopClick.Model.BLL.Status"
                        SelectMethod="StatusDropDownList_GetData"
                        DataTextField="StatusType"
                        DataValueField="StatusID"
                        SelectedValue='<%# BindItem.StatusID %>'
                        Enabled="true" />
                </td>
                <td>
                    <asp:Button CssClass="command" UseSubmitBehavior="False" runat="server" CommandName="Update" Text="Spara" CausesValidation="false" />
                    <asp:Button CssClass="command" UseSubmitBehavior="False" runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
