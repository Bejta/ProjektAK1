<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AdminProducts.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.AdminProducts" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="admin_content" runat="server">
        <div>
             <asp:Button ID="ButtonAdd" runat="server" Text="Ny Produkt" OnClick="ButtonAdd_Click" />
        <br />
        </div>
           <div class="editor-field">
                         <%-- <asp:DropDownList ID="CategoryDropDownList" runat="server"
                                        ItemType="WebshopClick.Model.BLL.Category"
                                        SelectMethod="CategoryDropDownList_GetData"
                                        DataTextField="CategoryName"
                                        DataValueField="CategoryID"
                                        SelectedValue='<%# BindItem.CategoryID %>'
                                        Enabled="true" />--%>

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
            DeleteMethod="ProductListView_DeleteItem"
            DataKeyNames="ProductID"
            >
             

<%-- Layout of productlist --%>
            <LayoutTemplate>
                <ul class="productlist">
                    <asp:PlaceHolder ID="itemPlaceHolder" runat="server"></asp:PlaceHolder>
                </ul>
                <asp:DataPager ID="DataPager" runat="server" PageSize="12" >      
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
                <li class="productsadminlist">
                     <asp:HyperLink ID="ThumbsHyperLink"  runat="server" NavigateUrl='<%# GetRouteUrl("ADetails", new { ProductID = Item.ProductID }) %>'>
                          <img id="ThumbnailImage" class="thumbs" src="/Content/Images/Thumbs/<%#: Item.Image %>"/>   
                     </asp:HyperLink> 
                     <br> </br> 
                    <div><%#: Item.Name %>
                        <br></br><%#: Item.Price %></div>
                    <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                              OnClientClick="return confirm('Ta bort produkten permanent?');" />
                    <asp:HyperLink runat="server" Text="Redigera" NavigateUrl='<%# GetRouteUrl("EditProduct", new { ProductID = Item.ProductID }) %>' />

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
