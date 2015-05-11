<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Productdetails.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Productdetails" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">

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
                <li class="productsadminlist">
                     <asp:HyperLink ID="ImageHyperLink"  runat="server" NavigateUrl='~/Pages/WebShopPages/Default.aspx'>
                          <img id="BigImage" class="imagesDetails" src="/Content/Images/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                     <br> </br> 
                    <div class="editor-field">
                    <asp:DropDownList ID="CategoryDropDownList" runat="server"
                                    ItemType="WebshopClick.Model.BLL.Category"
                                    SelectMethod="CategoryDropDownList_GetData"
                                    DataTextField="CategoryName"
                                    DataValueField="CategoryID"
                                    SelectedValue='<%# BindItem.CategoryID %>'
                                    Enabled="false" />
                    </div>
                    <div><%#: Item.Name %>
                        <br></br><%#: Item.Description %>
                        <br></br><%#: Item.Price %>
                        <asp:Button ID="AddToCart" runat="server" Text="Köp" />
                    </div>
                    
                </li>
            </ItemTemplate>
            <EmptyDataTemplate>
                <div>
                    Det finns inga produkter
                </div>
            </EmptyDataTemplate>
        </asp:ListView>
</asp:Content>
