<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebShop.Master" AutoEventWireup="true" CodeBehind="ProceedOrder.aspx.cs" Inherits="WebshopClick.Pages.WebShopPages.ProceedOrder" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div id="search" class="container">
        <asp:TextBox ID="TxtSearch" CssClass="cell" runat="server"></asp:TextBox>
        <asp:Button ID="ImgSearch" CssClass="cell" OnClick="ImgSearch_Click" runat="server" Text="Sök" />
        <div class="navbuttonsMain">
            <asp:LinkButton Visible="false" ID="ButtonAdmin" CssClass="navbuttons" runat="server" OnClick="ButtonAdmin_Click">Admin</asp:LinkButton>
            <asp:LinkButton ID="btnCart" CausesValidation="false" CssClass="navbuttons" OnClick="btnCart_Click" runat="server" Text="">
                <asp:Image ID="Image1" runat="server" CssClass="imgCart" ImageUrl="~/Content/ButtonImages/shopping_cart_ecommerce.png" />
                <asp:Label ID="lblCart" runat="server" Text=""></asp:Label>
            </asp:LinkButton>
            <asp:LinkButton ID="btnLogin" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="btnLogin_Click">Logga in</asp:LinkButton>
            <asp:LinkButton ID="btnProfile" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="btnPage_Click">Mina sidor</asp:LinkButton>
            <asp:LinkButton ID="btnHem" CausesValidation="false" CssClass="navbuttons" runat="server" OnClick="ImgSearch_Click">Hem</asp:LinkButton>

        </div>
    </div>
    <br />
    <div class="wrapperForm">
        <asp:ValidationSummary ID="ValidationSummaryCategory" CssClass="validation" runat="server" />
        <asp:PlaceHolder ID="FlashPlaceHolder" runat="server" Visible="false">
            <div class="success" runat="server">
                <asp:Label ID="Message" Text="Beställning genomfördes!" runat="server"></asp:Label>
                <asp:Button ID="Close" OnClick="Close_Click" runat="server" Text=" X " CausesValidation="False" />
            </div>
        </asp:PlaceHolder>
        <asp:PlaceHolder ID="PlaceHolder1" runat="server" Visible="false">
            <asp:Label ID="MessageFail" Text="Ett heltal mellan 1 och 999999 måste anges!" runat="server">
                <asp:Button ID="Button3" OnClick="Close1_Click" runat="server" Text="X" CausesValidation="False" />
            </asp:Label>
        </asp:PlaceHolder>

        <div>
        </div>
        <asp:FormView CssClass="form" ID="OrderFormView" runat="server"
            ItemType="WebshopClick.Model.BLL.Order"
            DefaultMode="Insert"
            RenderOuterTable="true"
            InsertMethod="OrderFormView_InsertItem">
            <InsertItemTemplate>
                <asp:HiddenField ID="HiddenFieldUser" runat="server" Value='<%# BindItem.UserID %>' />
                <asp:Button ID="Button2" CssClass="command" CausesValidation="false" runat="server" Text="Hämta uppgifter" OnClick="Button2_Click" />
                <div class="editor-label">

                    <label for="Name">Namn</label>
                    <asp:RequiredFieldValidator ID="NameRequiredFieldValidator" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Name" CssClass="input" runat="server" Text='<%# BindItem.Name %>' MaxLength="50" />
                </div>
                <div class="editor-label">
                    <label for="Date">Datum</label>
                    <asp:Label ID="LabelDate" CssClass="inputDate" runat="server" Text='<%# BindItem.Date %>'></asp:Label>
                </div>
                <div class="editor-label">
                    <label for="Address">Gatuadress</label>
                    <asp:RequiredFieldValidator ID="AddressRequiredFieldValidator" runat="server" ErrorMessage="En adress måste anges." ControlToValidate="Address" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Address" CssClass="input" runat="server" Text='<%# BindItem.Address %>' MaxLength="30" />
                </div>
                <div class="editor-label">
                    <label for="Postnumber">Postnummer</label>
                    <asp:RequiredFieldValidator ID="PostNumberRequiredFieldValidator" runat="server" ErrorMessage="Ett postnummer måste anges." ControlToValidate="Postnumber" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="Postnumber" CssClass="postal-code" runat="server" Text='<%# BindItem.Postnumber %>' MaxLength="6" />
                </div>
                <div class="editor-label">
                    <label for="City">Postort</label>
                    <asp:RequiredFieldValidator ID="CityRequiredFieldValidator" runat="server" ErrorMessage="En postort måste anges." ControlToValidate="TextBox1" Display="None"></asp:RequiredFieldValidator>
                    <asp:TextBox ID="TextBox1" CssClass="input" runat="server" Text='<%# BindItem.City %>' MaxLength="20" />
                </div>
                <div class="editor-label">
                    <label for="PaymentDropDownList">Betallningssätt</label>
                    <asp:DropDownList CssClass="input" runat="server" ID="PaymentDropDownList"
                        ItemType="WebshopClick.Model.BLL.Payment"
                        SelectMethod="PaymentDropDownList_GetData"
                        DataTextField="PaymentType"
                        DataValueField="PaymentID"
                        SelectedValue='<%# BindItem.PaymentID %>'
                        AutoPostBack="false">
                    </asp:DropDownList>
                </div>
                <asp:HiddenField ID="HiddenFieldStatus" runat="server" Value='<%# BindItem.StatusID %>' />
                <div class="commandButtons">
                    <asp:Button ID="btnHem2" CausesValidation="false" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till Webshop" />
                    <asp:Button ID="Button1" CausesValidation="false" CssClass="command" runat="server" OnClick="btnCart_Click" Text="Tillbaka till Varukorgen" />
                    <asp:Button ID="Order" CommandName="Insert" CssClass="commandSpecial" runat="server" Text="Beställa" />

                </div>
            </InsertItemTemplate>
        </asp:FormView>

    </div>
</asp:Content>

