<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Productdetails.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="search" class="container">
                <asp:TextBox ID="TxtSearch" CssClass="cell"  runat="server"></asp:TextBox>
                <asp:Button ID="ImgSearch" CssClass="cell" OnClick="ImgSearch_Click"  runat="server" Text="Sök" />
        <div class="navbuttonsMain">  
                   
                <asp:LinkButton ID="btnCart" CssClass="navbuttons" runat="server" OnClick="btnCart_Click" Text="">
                    <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                    <asp:Label ID="lblCart"  runat="server" Text=""></asp:Label> 
                </asp:LinkButton>    
                <asp:LinkButton ID="btnLogin" CssClass="navbuttons" runat="server" >Logga in</asp:LinkButton>
                <asp:LinkButton ID="btnProfile" CssClass="navbuttons" runat="server">Mina sidor</asp:LinkButton>
               <asp:LinkButton ID="btnHem" CssClass="navbuttons" runat="server" OnClick="btnHem_Click" >Hem</asp:LinkButton>
                      
       </div>
    </div>
    <div id="product1">
    <asp:ListView ID="productList" runat="server"
            ItemType="WebshopClick.Model.BLL.Product"
            SelectMethod="ProductListView_GetData"
            DataKeyNames="ProductID"
            >
             

<%-- Layout of productlist --%>
            <LayoutTemplate>
                <div class="productlistOne">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </div>
            </LayoutTemplate>

            <ItemTemplate>
                <%--<li class="OneProduct">
                     <asp:HyperLink ID="ThumbsHyperLink" class="imageDetails"  runat="server" NavigateUrl='~/Pages/WebShopPages/Default.aspx'>
                          <img id="ThumbnailImage" class="imageDetails" src="/Content/Images/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                     <br> </br> 
                    <div class="productsOneTemplate">
                    <asp:DropDownList ID="CategoryDropDownList" runat="server"
                                    ItemType="WebshopClick.Model.BLL.Category"
                                    SelectMethod="CategoryDropDownList_GetData"
                                    DataTextField="CategoryName"
                                    DataValueField="CategoryID"
                                    SelectedValue='<%# BindItem.CategoryID %>'
                                    Enabled="false" />
                    </div>
                    <div class="productName">
                        <asp:Label ID="Label1" runat="server" CssClass="productName" Text="<%#: Item.Name %> "></asp:Label>
                        <br /><asp:Label ID="Label2" runat="server" CssClass="productName" Text="<%#: Item.Description %> "></asp:Label>
                        <div class="price">
                        <%#: Item.Price %>
                        <asp:Button ID="AddToCart"  
                            CssClass="commandSpecialbuy" 
                            OnClick="BuyButton_OnClick" 
                            runat="server" 
                            Text="Köp" />
                    </div>
                    
                </li>--%>
                    <div class="imageDetail">
                    <asp:HyperLink class="imageDetails"  runat="server" NavigateUrl='~/Pages/WebShopPages/Default.aspx'>
                          <img class="imageDetails"  src="/Content/Images/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                    
                    </div>
                    <div id="productEverything">
                        <div class="productName1">
                        <%-- <asp:DropDownList ID="CategoryDropDownList" runat="server"
                                    ItemType="WebshopClick.Model.BLL.Category"
                                    SelectMethod="CategoryDropDownList_GetData"
                                    DataTextField="CategoryName"
                                    DataValueField="CategoryID"
                                    SelectedValue='<%# BindItem.CategoryID %>'
                                    Enabled="false" />--%>
                        <asp:Label CssClass="productName" ID="Label1" runat="server"  Text="<%#: Item.Name %> "></asp:Label>
                        </div>
                        <div>
                        <br /><asp:Label ID="Label2" runat="server" Text="<%#: Item.Description %> "></asp:Label>
                        </div>
                        <div class="priceOne">
                        <%#: Item.Price %>
                        <asp:Button ID="AddToCart"  
                            CssClass="commandSpecialbuy" 
                            OnClick="BuyButton_OnClick" 
                            runat="server" 
                            Text="Köp" />
                    </div>
                </div>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div>
                    Det finns inga produkter
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
        </div>
</asp:Content>
