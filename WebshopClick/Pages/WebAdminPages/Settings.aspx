<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="Settings.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.Settings" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
    <asp:Button ID="category" CssClass="settingButtons" runat="server" Text="Kategori" OnClick="category_Click" />
    <asp:Button ID="grade" CssClass="settingButtons" runat="server" Text="Betyg" OnClick="grade_Click" />
    <asp:Button ID="tax" CssClass="settingButtons" runat="server" Text="Moms" OnClick="tax_Click" />
    <asp:Button ID="payment" CssClass="settingButtons" runat="server" Text="Betalning" OnClick="payment_Click" />
    <asp:Button ID="status" CssClass="settingButtons" runat="server" Text="Status" OnClick="status_Click" />
</asp:Content>
