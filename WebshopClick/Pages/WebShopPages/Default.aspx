<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <ul class="productlist">
        <asp:ListView ID="productList" runat="server"
            ItemType="WebshopClick.Model.BLL.Product"
            SelectMethod="ProductListView_GetData"
            DataKeyNames="ProductID"
            >
             

<%-- Layout of productlist --%>
            <LayoutTemplate>
                <ul class="productlist">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </ul>
            </LayoutTemplate>

            <ItemTemplate>
                <li>
                     <asp:HyperLink ID="ThumbsHyperLink"  runat="server" NavigateUrl='Productdetails'>
                          <img id="ThumbnailImage" class="thumbs" src="/Content/Images/Thumbs/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                     <br> </br> 
                    <div><%#: Item.Name %>
                        <br></br><%#: Item.Price %></div>
                    <asp:Button ID="AddToCart" runat="server" Text="Köp" />
                </li>
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>
                    Det finns inga produkter
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
    </ul>
</asp:Content>
