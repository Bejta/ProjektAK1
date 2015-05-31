<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="search" class="container">
        <asp:TextBox ID="TxtSearch" CssClass="cell" runat="server"></asp:TextBox>
        <asp:Button ID="ImgSearch" CausesValidation="false" CssClass="cell" OnClick="ImgSearch_Click" runat="server" Text="Sök" />
        <div class="navbuttonsMain">
            <asp:LinkButton Visible="false" ID="ButtonAdmin" CssClass="navbuttons" runat="server" OnClick="ButtonAdmin_Click">Admin</asp:LinkButton>
            <asp:LinkButton ID="btnCart" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="btnCart_Click" Text="">
                <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
            </asp:LinkButton>
            <asp:LinkButton ID="btnLogin" CausesValidation="false" CssClass="navbuttons" runat="server">Logga in</asp:LinkButton>
            <asp:LinkButton ID="btnProfile" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="btnPage_Click">Mina sidor</asp:LinkButton>
            <asp:LinkButton ID="btnHem" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="ImgSearch_Click">Hem</asp:LinkButton>

        </div>
    </div>
    <br />
    <div class="wrapperForm">
        <div runat="server" id="loginform" class="form">
            <div class="editor-label">
                <label for="Name">Användarnamn</label>
                <asp:TextBox ID="UsernameLogin" CssClass="input" runat="server" Text='' MaxLength="20" />
            </div>
            <div class="editor-label">
                <label for="Date">Lösenord</label>
                <asp:TextBox ID="PasswordLogin" CssClass="input" runat="server" Text='' MaxLength="25" TextMode="Password" />
                <div>
                    <asp:Button CausesValidation="false" ID="LoginButton" OnClick="LoginButton_Click" CssClass="commandSpecial" runat="server" Text="Logga in" />
                </div>
            </div>

        </div>
        <asp:ValidationSummary ID="ValidationSummaryCategory" CssClass="validation" runat="server" />
        <asp:PlaceHolder ID="FlashPlaceHolder" runat="server" Visible="false">
            <div class="success" runat="server">
                <asp:Label ID="Message" Text="Din profil är registrerad! Nu kan du logga in." runat="server"></asp:Label>
                <asp:Button ID="Close" OnClick="Close3_Click" runat="server" Text=" X " CausesValidation="False" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolderCheckFail" runat="server" Visible="false">
            <div class="warning" runat="server">
                <asp:Label ID="Label1" Text="Användarnamn är upptagen!" runat="server"></asp:Label>
                <asp:Button ID="Button5" OnClick="Close2_Click" runat="server" Text=" X " CausesValidation="False" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolderCheckOK" runat="server" Visible="false">
            <div class="info" runat="server">
                <asp:Label ID="Label2" Text="Användarnamn går att registrera!" runat="server"></asp:Label>
                <asp:Button ID="Button6" OnClick="Close_Click" runat="server" Text=" X " CausesValidation="False" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <div class="error" runat="server">
                <asp:Label ID="MessageFail1" Text="Okänd användarnamn eller lösenord!" runat="server">
                    <asp:Button ID="Button3" OnClick="Close1_Click" runat="server" Text=" X " CausesValidation="False" />
                </asp:Label>
            </div>
        </asp:PlaceHolder>

        <div>
            <asp:Button ID="ButtonNewProfile" CssClass="command" runat="server" OnClick="ButtonNewProfile_Click" Text="Skapa ny konto" />
        </div>
        <div>
            <asp:Button ID="ButtonLogout" Visible="false" CssClass="command" runat="server" OnClick="ButtonLogout_Click" Text="Logga ut" />
        </div>
        <asp:FormView Visible="false" CssClass="form" ID="UserFormView" runat="server"
            ItemType="WebshopClick.Model.BLL.User"
            DefaultMode="Insert"
            RenderOuterTable="true"
            InsertMethod="UserFormView_InsertItem">
            <InsertItemTemplate>


                <div class="editor-label">
                    <label for="Name">Användarnamn</label>
                    <asp:TextBox ID="Login" CssClass="input" runat="server" Text='<%# BindItem.LoginID %>' MaxLength="20" />

                </div>
                <div>
                    <asp:Button ID="ButtonCheck" CausesValidation="false" CssClass="command" runat="server" OnClick="ButtonCheck_Click" Text="Kontrollera om användarnamn är upptagen" />
                </div>
                <div class="editor-label">
                    <label for="Date">Lösenord</label>
                    <asp:RequiredFieldValidator ID="PasswordRequiredFieldValidator" runat="server" ErrorMessage="Ett lösenord måste anges." ControlToValidate="Password" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Password" CssClass="input" runat="server" Text='<%# BindItem.Password %>' MaxLength="100" TextMode="Password" />
                </div>
                <div class="editor-label">
                    <label for="Date">Bekräfta lösenord</label>
                    <asp:RequiredFieldValidator ID="ConfirmPasswordRequiredFieldValidator" runat="server" ErrorMessage="Ett identiskt lösenord måste anges." ControlToValidate="ConfirmPassword" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="ConfirmPassword" CssClass="input" runat="server" Text='' MaxLength="100" TextMode="Password" />
                    <div>
                        <asp:CompareValidator ID="CompareValidatorPassword" runat="server" ErrorMessage="Ange samma lösenordet" ControlToValidate="ConfirmPassword" ControlToCompare="Password" CssClass="validation"></asp:CompareValidator>
                    </div>
                </div>
                <div class="editor-label">
                    <label for="Address">Namn</label>
                    <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Name" CssClass="input" runat="server" Text='<%# BindItem.Name %>' MaxLength="50" />
                </div>
                <div class="editor-label">
                    <label for="Address">Gatuadress</label>
                    <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator1" runat="server" ErrorMessage="En adress måste anges." ControlToValidate="Address" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Address" CssClass="input" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
                </div>
                <div class="editor-label">
                    <label for="Postnumber">Postnummer</label>
                    <asp:RequiredFieldValidator ID="PostnumberRequiredFieldValidator" runat="server" ErrorMessage="Ett postnumer måste anges." ControlToValidate="Postnumber" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Postnumber" CssClass="postal-code" runat="server" Text='<%# BindItem.Postnumber %>' MaxLength="6" />
                </div>
                <div class="editor-label">
                    <label for="City">Postort</label>
                    <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" ErrorMessage="En postort måste anges." ControlToValidate="TextBox1" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBox1" CssClass="input" runat="server" Text='<%# BindItem.City %>' MaxLength="20" />
                </div>
                <div class="editor-label">
                    <label for="City">E-mail</label>
                    <asp:RequiredFieldValidator ID="EmailRequiredFieldValidator" runat="server" ErrorMessage="En email adress måste anges." ControlToValidate="TextBox2" Display="None"></asp:RequiredFieldValidator>
                    <asp:RegularExpressionValidator ID="RegularExpressionValidator1" runat="server" ErrorMessage="Email adress verkar inte vara korrekt." ControlToValidate="TextBox2" ValidationExpression="^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$" Display="None"></asp:RegularExpressionValidator>
                    <asp:TextBox ID="TextBox2" CssClass="input" runat="server" Text='<%# BindItem.Email %>' MaxLength="40" />
                </div>
                <div class="editor-label">
                    <label for="City">Telefon</label>
                    <asp:RequiredFieldValidator ID="PhoneRequiredFieldValidator" runat="server" ErrorMessage="Ett telefonnummer måste anges." ControlToValidate="phone" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="phone" CssClass="input" runat="server" Text='<%# BindItem.Telephone %>' MaxLength="15" />
                </div>
                <div class="editor-label">
                    <label for="City">Mobil</label>
                    <asp:RequiredFieldValidator ID="MobileRequiredFieldValidator" runat="server" ErrorMessage="Ett mobilnummer måste anges." ControlToValidate="mobile" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="mobile" CssClass="input" runat="server" Text='<%# BindItem.Mobile %>' MaxLength="15" />
                </div>
                <div class="commandButtons">
                    <asp:Button ID="btnHem2" CausesValidation="false" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till Webshop" />
                    <asp:Button ID="Button1" CausesValidation="false" CssClass="command" runat="server" OnClick="btnCart_Click" Text="Tillbaka till Varukorgen" />
                    <asp:Button ID="User" CommandName="Insert" CssClass="commandSpecial" runat="server" Text="Registrera profil" />
                </div>
            </InsertItemTemplate>
        </asp:FormView>

    </div>
</asp:Content>
