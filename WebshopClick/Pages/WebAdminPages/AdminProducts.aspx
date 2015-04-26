<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.AdminProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <asp:ValidationSummary ID="ValidationSummary1" runat="server" />
    <h2>Lägg till ny produkt</h2>

    <asp:FormView ID="ProductFormView" runat="server"
                ItemType="WebShop.Model.BLL.Product"
                DefaultMode="Insert"
                RenderOuterTable="false"
                InsertMethod="ProductFormView_InsertItem">
                <InsertItemTemplate>
                    <div class="editor-label">
                        <label for="Name">Namn</label>
                    </div>
                    <div class="editor-field">
                        <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" Display="None"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="40" />
                    </div>
                    <div>
                        <asp:LinkButton runat="server" Text="Spara" CommandName="Insert" />
                        
                    </div>
                </InsertItemTemplate>
         </asp:FormView>
</asp:Content>
