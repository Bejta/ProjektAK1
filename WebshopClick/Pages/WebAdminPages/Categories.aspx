<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.Categories" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
            <asp:ListView ID="LineListView" runat="server"
                ItemType="WebshopClick.Model.BLL.Category"
                SelectMethod="CategoryListView_GetData"
                InsertMethod="CategoryListView_InsertItem"
                UpdateMethod="CategoryListView_UpdateItem"
                DeleteMethod="CategoryListView_DeleteItem"
                DataKeyNames="CategoryID"
                InsertItemPosition="FirstItem">
                <LayoutTemplate>
                    <table class="gridAdmin">
                        <tr>
                            <th>
                                Namn
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
                            <%#: Item.CategoryName %>
                        </td>
                        <td class="command">
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                              OnClientClick="return confirm('Ta bort kategori permanent?');" />
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
<%-- Detta visas då linjeuppgifter saknas i databasen. --%>
                    <table class="gridAdmin">
                        <tr>
                            <td>
                                Kategoriuppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Name" MaxLength="30" runat="server" Text='<%# BindItem.CategoryName %>' />
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
                            <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="NameEdit"></asp:RequiredFieldValidator>
                            <asp:TextBox ID="NameEdit" runat="server" Text='<%# BindItem.CategoryName %>' MaxLength="30" />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
</asp:Content>
