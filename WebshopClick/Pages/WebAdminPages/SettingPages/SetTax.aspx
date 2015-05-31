<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="SetTax.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.SettingPages.SetTax" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
    <asp:ListView ID="TaxListView" runat="server"
        ItemType="WebshopClick.Model.BLL.Tax"
        SelectMethod="TaxListView_GetData"
        InsertMethod="TaxListView_InsertItem"
        UpdateMethod="TaxListView_UpdateItem"
        DeleteMethod="TaxListView_DeleteItem"
        DataKeyNames="TaxID"
        InsertItemPosition="FirstItem">
        <LayoutTemplate>
            <table class="gridAdmin">
                <tr>
                    <th>Moms
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
                    <%#: Item.TaxValue %>
                </td>
                <td>
                    <asp:Button runat="server" CssClass="command" CommandName="Delete" Text="Ta bort" CausesValidation="false"
                        OnClientClick="return confirm('Ta bort betyget permanent?');" />
                    <asp:Button runat="server" CssClass="command" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                </td>
            </tr>
        </ItemTemplate>
        <EmptyDataTemplate>
            <%-- Detta visas då momsuppgifter saknas i databasen. --%>
            <table class="gridAdmin">
                <tr>
                    <td>Momsuppgifter saknas.
                    </td>
                </tr>
            </table>
        </EmptyDataTemplate>
        <InsertItemTemplate>
            <tr>
                <td>
                    <asp:RangeValidator ID="RangeValidator2" runat="server" ErrorMessage="Ett tal mellan 0 och 100 måste anges" Visible="False" ViewStateMode="Enabled" ControlToValidate="Tax" MaximumValue="100" MinimumValue="0"></asp:RangeValidator>
                    <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ett heltal måste anges." ControlToValidate="Tax" Type="Integer" Operator="DataTypeCheck" Visible="False"></asp:CompareValidator>
                    <asp:TextBox ID="Tax" runat="server" Text='<%# BindItem.TaxValue %>' />
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
                    <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Moms måste anges." ControlToValidate="TaxEdit"></asp:RequiredFieldValidator>
                    <asp:RangeValidator ID="RangeValidator1" runat="server" ErrorMessage="Ett tal mellan 0 och 100 måste anges" Visible="False" ViewStateMode="Enabled" ControlToValidate="TaxEdit" MaximumValue="100" MinimumValue="0"></asp:RangeValidator>
                    <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Ett tal måste anges." ControlToValidate="TaxEdit" Type="Double" Operator="DataTypeCheck" Visible="False"></asp:CompareValidator>
                    <asp:TextBox ID="TaxEdit" runat="server" Text='<%# BindItem.TaxValue %>' />
                </td>
                <td>
                    <asp:Button runat="server" CssClass="command" CommandName="Update" Text="Spara" />
                    <asp:Button runat="server" CssClass="command" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                </td>
            </tr>
        </EditItemTemplate>
    </asp:ListView>
</asp:Content>
