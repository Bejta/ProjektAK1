<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="SetGrades.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.SettingPages.SetGrades" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
            <asp:ListView ID="GradeListView" runat="server"
                ItemType="WebshopClick.Model.BLL.Grade"
                SelectMethod="GradeListView_GetData"
                InsertMethod="GradeListView_InsertItem"
                UpdateMethod="GradeListView_UpdateItem"
                DeleteMethod="GradeListView_DeleteItem"
                DataKeyNames="GradeID"
                InsertItemPosition="FirstItem">
                <LayoutTemplate>
                    <table class="gridAdmin">
                        <tr>
                            <th>
                                Betyg
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
                            <%#: Item.GradeValue %>
                        </td>
                        <td class="command">
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                              OnClientClick="return confirm('Ta bort betyget permanent?');" />
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
<%-- Detta visas då betyguppgifter saknas i databasen. --%>
                    <table class="gridAdmin">
                        <tr>
                            <td>
                                Betyguppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <InsertItemTemplate>
                    <tr>
                        <td>
                            
                            <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ett heltal måste anges." ControlToValidate="Grade" Type="Integer" Operator="DataTypeCheck" Visible="False"></asp:CompareValidator>
                            <asp:TextBox ID="Grade" runat="server" Text='<%# BindItem.GradeValue %>' />
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
                             <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ErrorMessage="Ett betyg måste anges." ControlToValidate="GradeEdit"></asp:RequiredFieldValidator>
                            <asp:CompareValidator ID="CompareValidator2" runat="server" ErrorMessage="Ett heltal måste anges." ControlToValidate="GradeEdit" Type="Integer" Operator="DataTypeCheck" Visible="False"></asp:CompareValidator>
                            <asp:TextBox ID="GradeEdit" runat="server" Text='<%# BindItem.GradeValue %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>
</asp:Content>
