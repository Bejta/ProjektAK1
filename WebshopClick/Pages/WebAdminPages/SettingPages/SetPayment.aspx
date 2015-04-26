<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="SetPayment.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.SettingPages.SetPayment" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
            <asp:ListView ID="LineListView" runat="server"
                ItemType="WebshopClick.Model.BLL.Payment"
                SelectMethod="PaymentListView_GetData"
                InsertMethod="PaymentListView_InsertItem"
                UpdateMethod="PaymentListView_UpdateItem"
                DeleteMethod="PaymentListView_DeleteItem"
                DataKeyNames="PaymentID"
                InsertItemPosition="FirstItem">
                <LayoutTemplate>
                    <table class="gridAdmin">
                        <tr>
                            <th>
                                Betalningssätt
                            </th>
                            <th>
                            </th>
                        </tr>
<%-- Platshållare för nya rader --%>
                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
<%-- Mall för nya rader. --%>
                    <tr>
                        <td>
                            <%#: Item.PaymentType %>
                        </td>
                        <td class="command">
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                              OnClientClick="return confirm('Ta bort betalningen permanent?');" />
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
<%-- Detta visas då betalningssätt uppgifter saknas i databasen. --%>
                    <table class="gridAdmin">
                        <tr>
                            <td>
                                betalningssätt uppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="PaymentType" MaxLength="30" runat="server" Text='<%# BindItem.PaymentType %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                </InsertItemTemplate>
                <EditItemTemplate>
                    <tr>
                        <td>
                            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett betalningssätt måste anges." ControlToValidate="TypeEdit"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="TypeEdit" runat="server" Text='<%# BindItem.PaymentType %>' MaxLength="30" />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
</asp:Content>
