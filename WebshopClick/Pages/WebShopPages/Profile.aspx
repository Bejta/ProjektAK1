<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Profile" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
     <div id="search" class="container">
                <asp:TextBox ID="TxtSearch" CssClass="cell"  runat="server"></asp:TextBox>
                <asp:Button ID="ImgSearch" CssClass="cell" OnClick="ImgSearch_Click"  runat="server" Text="Sök" />
        <div class="navbuttonsMain">         
                <asp:LinkButton ID="btnCart" CssClass="navbuttons" runat="server" Text="">
                    <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                    <asp:Label ID="lblCart"  runat="server" Text=""></asp:Label> 
                </asp:LinkButton>      
                <asp:LinkButton ID="btnLogin" CssClass="navbuttons" runat="server" >Logga in</asp:LinkButton>
                <asp:LinkButton ID="btnProfile" CssClass="navbuttons" runat="server">Mina sidor</asp:LinkButton>
                <asp:LinkButton ID="btnHem" CssClass="navbuttons" runat="server" OnClick="ImgSearch_Click" >Hem</asp:LinkButton>
                      
       </div>
    </div>
     <br />
    <div class="wrapperForm">
        <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
        <asp:PlaceHolder ID="FlashPlaceHolder"  runat="server" Visible="false">
            <div class="success" runat="server">
                <asp:Label ID="Message" Text="Du är registrerad!" runat="server"></asp:Label>
                     <asp:Button ID="Close" OnClick="Close_Click" runat="server" Text=" X " CausesValidation="False" />     
                </div>      
    </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1"  runat="server" Visible="false">
                <asp:Label ID="MessageFail" Text="Ett heltal mellan 1 och 999999 måste anges!" runat="server">
                     <asp:Button ID="Button3" OnClick="Close1_Click" runat="server" Text="X" CausesValidation="False" />
                </asp:Label>      
    </asp:PlaceHolder>
    
        <div>
        </div>
        <asp:FormView CssClass="form" ID="UserFormView" runat="server"
                ItemType="WebshopClick.Model.BLL.User"
                DefaultMode="Insert"
                RenderOuterTable="true"
                InsertMethod="UserFormView_InsertItem">
                <InsertItemTemplate>
                    
                    <asp:Button ID="Button2" CssClass="command" runat="server" Text="Hämta uppgifter" OnClick="Button2_Click" />
                    <div class="editor-label">   
                        <label for="Name">Användarnamn</label>
                        <asp:TextBox ID="Login" CssClass="input" runat="server" Text='<%# BindItem.LoginID %>' MaxLength="20" />
                    </div>
                    <div class="editor-label">
                        <label for="Date">Lösenord</label>
                       <asp:TextBox ID="Password" CssClass="input" runat="server" Text='<%# BindItem.Password %>' MaxLength="100" TextMode="Password" />
                    </div>
                    <div class="editor-label">
                        <label for="Address">Namn</label>
                        <asp:TextBox ID="Name" CssClass="input" runat="server" Text='<%# BindItem.Name %>' MaxLength="50" />
                    </div>
                    <div class="editor-label">
                        <label for="Address">Gatuadress</label>
                        <asp:TextBox ID="Address" CssClass="input" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
                    </div>
                     <div class="editor-label">
                        <label for="Postnumber">Postnummer</label>
                        <asp:TextBox ID="Postnumber" CssClass="postal-code" runat="server" Text='<%# BindItem.Postnumber %>' MaxLength="6" />
                    </div>
                    <div class="editor-label">
                        <label for="City">Postort</label>
                        <asp:TextBox ID="TextBox1" CssClass="input" runat="server" Text='<%# BindItem.City %>' MaxLength="20" />
                    </div>
                    <div class="editor-label">
                        <label for="City">E-mail</label>
                        <asp:TextBox ID="TextBox2" CssClass="input" runat="server" Text='<%# BindItem.Email %>' MaxLength="40" />
                    </div>
                    <div class="editor-label">
                        <label for="City">Telefon</label>
                        <asp:TextBox ID="phone" CssClass="input" runat="server" Text='<%# BindItem.Telephone %>' MaxLength="15" />
                    </div>
                    <div class="editor-label">
                        <label for="City">Mobil</label>
                        <asp:TextBox ID="mobile" CssClass="input" runat="server" Text='<%# BindItem.Mobile %>' MaxLength="15" />
                    </div>
                    <div class="commandButtons">
                        <asp:Button ID="btnHem2" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till Webshop" />
                        <asp:Button ID="Button1" CssClass="command" runat="server" OnClick="btnCart_Click" Text="Tillbaka till Varukorgen" />
                        <asp:Button ID="User" CommandName="Insert" CssClass="commandSpecial" runat="server" Text="Registrera profil" />
                    </div>
                </InsertItemTemplate>
         </asp:FormView>
        
   </div>
</asp:Content>
