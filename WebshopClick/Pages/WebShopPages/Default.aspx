<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Default" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="search">
                <asp:TextBox ID="TxtSearch" runat="server"></asp:TextBox>
                <asp:ImageButton ID="ImgSearch" OnClick="ImgSearch_Click" ImageUrl="~/Content/ButtonImages/search_icon.png" runat="server" />
    </div>
    <div class="editor-field">
               <asp:DropDownList runat="server" ID="CategoryDropDownList"
               SelectMethod="CategoryDropDownList_GetData"
               DataTextField="CategoryName"
               DataValueField="CategoryID"
               OnSelectedIndexChanged="SelectionHasChanged"
               AutoPostBack="True"
               AppendDataBoundItems="true">
                    <asp:ListItem>-- Välj kategori --</asp:ListItem>
               </asp:DropDownList>
        </div>
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
                 <asp:DataPager ID="DataPager" runat="server" PageSize="15" >      
                        <Fields>
                            <asp:NextPreviousPagerField ShowFirstPageButton="True" FirstPageText=" Första "
                                ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                            <asp:NumericPagerField />
                            <asp:NextPreviousPagerField ShowLastPageButton="True" LastPageText=" Sista "
                                ShowNextPageButton="False" ShowPreviousPageButton="False"  />
                        </Fields>
               </asp:DataPager>
            </LayoutTemplate>

            <ItemTemplate>
                <li>
                     <asp:HyperLink ID="ThumbsHyperLink"  runat="server" NavigateUrl='<%# GetRouteUrl("Details", new { ProductID = Item.ProductID }) %>'>
                          <img id="ThumbnailImage" class="thumbs" src="/Content/Images/Thumbs/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                     <br> </br> 
                    <div><%#: Item.Name %>
                        <br></br><%#: Item.Price %>
                    </div>
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
