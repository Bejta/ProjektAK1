<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Default" %>

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
            <asp:LinkButton ID="btnProfile" CssClass="navbuttons" runat="server" OnClick="btnPage_Click">Mina sidor</asp:LinkButton>
            <asp:LinkButton ID="btnHem" CssClass="navbuttons" runat="server" OnClick="btnHem_Click">Hem</asp:LinkButton>

        </div>
    </div>
    <div class="dropdownlistShop">
        <label for="CategoryDropDownList">Kategorier</label>
        <asp:DropDownList CssClass="dropdownShop" runat="server" ID="CategoryDropDownList"
            SelectMethod="CategoryDropDownList_GetData"
            DataTextField="CategoryName"
            DataValueField="CategoryID"
            OnSelectedIndexChanged="SelectionHasChanged"
            AutoPostBack="True"
            AppendDataBoundItems="true">
            <asp:ListItem>-- Välj kategori --</asp:ListItem>
        </asp:DropDownList>
    </div>
    <div id="products">
        
        <asp:ListView ID="productList" runat="server"
            ItemType="WebshopClick.Model.BLL.Product"
            SelectMethod="ProductListView_GetData"
            DataKeyNames="ProductID">

            <LayoutTemplate>
                <ul class="productlist">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </ul>
                <asp:DataPager ID="DataPager" runat="server" PageSize="15">
                    <Fields>
                        <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" Första "
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                        <asp:NumericPagerField />
                        <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" Sista "
                            ShowNextPageButton="False" ShowPreviousPageButton="False" />
                    </Fields>
                </asp:DataPager>
            </LayoutTemplate>

            <ItemTemplate>
                <li>
                    <asp:HyperLink ID="ThumbsHyperLink" runat="server" NavigateUrl='<%# GetRouteUrl("Details", new { ProductID = Item.ProductID }) %>'>
                          <img id="ThumbnailImage" class="thumbs" src="/Content/Images/Thumbs/<%#: Item.Image %>"/>                        
                    </asp:HyperLink>
                    <br></br>
                    <div class="productsTemplate">
                        <asp:Label ID="Label1" runat="server" CssClass="productName" Text="<%#: Item.Name %> "></asp:Label>
                        <div class="price">
                            <%#: Item.Price %>
                            <asp:Button
                                ID="AddToCart"
                                CssClass="commandSpecialbuy"
                                runat="server"
                                OnClick="BuyButton_OnClick"
                                Text="Köp"
                                CommandName="AddToCart"
                                CommandArgument='<%#Eval("ProductID")%>' />
                        </div>
                    </div>

                </li>
            </ItemTemplate>

            <EmptyDataTemplate>
                <div>
                    Det finns inga produkter
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
    </div>
</asp:Content>
