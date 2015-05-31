<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="SetStatus.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.SettingPages.SetStatus" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
    <asp:ListView ID="StatusListView" runat="server"
        ItemType="WebshopClick.Model.BLL.Status"
        SelectMethod="StatusListView_GetData"
        InsertMethod="StatusListView_InsertItem"
        UpdateMethod="StatusListView_UpdateItem"
        DeleteMethod="StatusListView_DeleteItem"
        DataKeyNames="StatusID"
        InsertItemPosition="FirstItem">
        <LayoutTemplate>
            <table class="gridAdmin">
                <tr>
                    <th>Status
                    </th>
                    <th></th>
                </tr>
                <%-- Platshållare för nya rader --%>
                <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
            </table>
        </LayoutTemplate>
        <ItemTemplate>
            <%-- Mall för nya rader. --%>
            <tr>
                <td>
                    <%#: Item.StatusType %>
                </td>
                <td>
                    <asp:Button runat="server" CssClass="command" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                        OnClientClick="return confirm('Ta bort betyget permanent?');" />
                    <asp:Button runat="server" CssClass="command" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då status uppgifter saknas i databasen. --%>
            <table class="gridAdmin">
                <tr>
                    <td>status uppgifter saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:TextBox ID="StatusType" MaxLength="20" runat="server" Text='<%# BindItem.StatusType %>' />
                </td>
                <td>
                    <asp:Button CssClass="commandSpecial" runat="server" CommandName="Insert" Text="Lägg till" />
                    <asp:Button CssClass="command" runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                </td>
            </tr>
        </InsertItemTemplate>
        <EditItemTemplate>
            <tr>
                <td>
                    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Status måste anges." ControlToValidate="TypeEdit"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="TypeEdit" runat="server" Text='<%# BindItem.StatusType %>' MaxLength="20" />
                </td>
                <td>
                    <asp:Button runat="server" CssClass="command" CommandName="Update" Text="Spara" />
                    <asp:Button runat="server" CssClass="command" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
