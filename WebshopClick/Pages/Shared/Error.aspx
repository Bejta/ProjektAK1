<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Error.aspx.cs" Inherits="WebshopClick.Pages.Shared.Error" ViewStateMode="Disabled" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>WebShop Click</title>
    <link href="~/Content/CSS/Shop.css" rel="stylesheet" type="text/css" />
    <link href='http://fonts.googleapis.com/css?family=Jura:400,300,500,600' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Megrim' rel='stylesheet' type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Shadows+Into+Light' rel='stylesheet' type='text/css' />
</head>
<body>
    <form id="form1" runat="server">
        <div id="shop_wrapper">

            <div id="shop_header">
                <div id="example">
                    <ul class="titel">
                        <li>W</li>
                        <li>E</li>
                        <li>B</li>
                        <li>S</li>
                        <li>H</li>
                        <li>O</li>
                        <li>P</li>
                        <li>C</li>
                        <li>L</li>
                        <li>I</li>
                        <li>C</li>
                        <li>K</li>
                    </ul>
                </div>

                <div>
                    <div class="pageerror">Server error</div>
                    <div class="pageerror">Sorry...It´s not you, it´s me.</div>
                    <asp:Button ID="btnHem2" CssClass="command" runat="server" OnClick="btnHem_Click" Text="Tillbaka till Webshop" />
                </div>
            </div>

        </div>

    </form>
</body>
</html>
