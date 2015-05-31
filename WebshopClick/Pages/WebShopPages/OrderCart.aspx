<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="OrderCart.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Order" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">


    <div id="search" class="container">
        <asp:TextBox ID="TxtSearch" CssClass="cell" runat="server"></asp:TextBox>
        <asp:Button ID="ImgSearch" CssClass="cell" OnClick="ImgSearch_Click" runat="server" Text="Sök" />
        <div class="navbuttonsMain">
            <asp:LinkButton Visible="false" ID="ButtonAdmin" CssClass="navbuttons" runat="server" OnClick="ButtonAdmin_Click">Admin</asp:LinkButton>
            <asp:LinkButton ID="btnCart" CssClass="navbuttons" runat="server" Text="">
                <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
            </asp:LinkButton>
            <asp:LinkButton ID="btnLogin" CssClass="navbuttons" runat="server" OnClick="btnLogin_Click">Logga in</asp:LinkButton>
            <asp:LinkButton ID="btnProfile" CssClass="navbuttons" runat="server" OnClick="btnPage_Click">Mina sidor</asp:LinkButton>
            <asp:LinkButton ID="btnHem" CssClass="navbuttons" runat="server" OnClick="btnHem_Click">Hem</asp:LinkButton>

        </div>
    </div>
    <br />
    <br />
    <div class="wrapper">
        <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
        <asp:PlaceHolder ID="FlashPlaceHolder" runat="server" Visible="false">
            <div class="success" runat="server">
                <asp:Label ID="Message" Text="Antalet uppdaterades!" runat="server" />
                <asp:Button ID="Close" OnClick="Close_Click" runat="server" Text=" X " CausesValidation="False" />
            </div>
            <!--<asp:Label CssClass="success" ID="Message1" Text="Operation avslutades med succé!" runat="server">
                     <asp:Button ID="Close1" OnClick="Close_Click" runat="server" Text="X" CausesValidation="False" />
                </asp:Label>  -->
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <div class="error" runat="server">
                <asp:Label ID="MessageFail1" Text="Ett heltal mellan 1 och 999999 måste anges!" runat="server">
                    <asp:Button ID="Button3" OnClick="Close1_Click" runat="server" Text=" X " CausesValidation="False" />
                </asp:Label>
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder2" runat="server" Visible="false">
            <div class="info" runat="server">
                <asp:Label ID="Label1" Text="Det finns inga produkter i din varukorg!" runat="server">
                    <asp:Button ID="Button4" OnClick="Close2_Click" runat="server" Text=" X " CausesValidation="False" />
                </asp:Label>
            </div>
        </asp:PlaceHolder>
        <asp:ListView ID="listView"
            runat="server">
            <LayoutTemplate>
                <table class="gridAdmin">
                    <caption>Varukorgen</caption>
                    <thead>
                        <tr>
                            <th colspan="2">Produkt
                            </th>
                            <th>Pris
                            </th>
                            <th>Antal
                            </th>
                            <th>Total
                            </th>
                            <th></th>

                            <tfoot>
                                <tr>

                                    <td colspan="4">Subtotal:</td>
                                    <td>
                                        <asp:Label ID="TotalCart" runat="server" /></td>
                                    <td></td>
                                </tr>

                            </tfoot>
                        </tr>
                    </thead>
                    <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                </table>
            </LayoutTemplate>
            <ItemTemplate>
                <tr>
                    <asp:HiddenField ID="HiddenFieldButton" runat="server" Value='<%# DataBinder.Eval(Container.DataItem, "product.ProductID") %>' />
                    <td>
                        <img id="table_image" class="tablethumbs" src="/Content/Images/Thumbs/<%# DataBinder.Eval(Container.DataItem, "product.Image") %>" />
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "product.Name") %>
                    </td>
                    <td>
                        <%# DataBinder.Eval(Container.DataItem, "product.Price") %>
                    </td>
                    <td>
                        <asp:CompareValidator ID="CompareValidator1" runat="server" ErrorMessage="Ett heltal måste anges." ControlToValidate="QuantityEdit" Type="Integer" Operator="DataTypeCheck" Visible="False"></asp:CompareValidator>
                        <asp:RangeValidator ID="RangeValidator1" ControlToValidate="QuantityEdit" runat="server" ErrorMessage="Ett heltal större än 0 måste anges." MaximumValue="999999" MinimumValue="0" Visible="False"></asp:RangeValidator>
                        <asp:TextBox ID="QuantityEdit" runat="server" Text='<%# DataBinder.Eval(Container.DataItem, "Quantity") %>' MaxLength="6" />
                    </td>
                    <td>
                        <%# Convert.ToDecimal(Eval("Quantity")) * Convert.ToDecimal(Eval("product.Price")) %>
                    </td>
                    <td>
                        <asp:Button CssClass="command" ID="DeleteItemLink" runat="server" OnClick="LinkButtonDelete_Click" CommandName="Delete" Text="Ta bort" CausesValidation="false" OnClientClick="return confirm('Ta bort produkt från varukorg permanent?');" />
                        <asp:Button CssClass="command" ID="EditItemLink" runat="server" OnClick="LinkButtonEdit_Click" Text="Uppdatera antal" CausesValidation="false" />
                    </td>

                </tr>
            </ItemTemplate>
        </asp:ListView>
        <div>
            <asp:Button ID="btnHem2" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till Webshop" />
            <asp:Button ID="Button2" CssClass="command" runat="server" Text="Radera alla produkter" OnClick="Button2_Click" OnClientClick="return confirm('Ta bort alla produkter från varukorgen?');" />
            <asp:Button ID="Button1" CssClass="commandSpecial" runat="server" Text="Fortsätta till kassan" OnClick="Button1_Click" />
        </div>

    </div>
</asp:Content>
