<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="EditProduct.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.EditProduct" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="admin_content" runat="server">
    <asp:ValidationSummary runat="server" CssClass="validation-summary-errors" ValidationGroup="ProductUpload" />
            <asp:FormView ID="ProductFormView" runat="server"
                ItemType="WebshopClick.Model.BLL.Product"
                DataKeyNames="ProductID"
                DefaultMode="Edit"
                RenderOuterTable="false"
                SelectMethod="ProductFormView_GetItem"
                UpdateMethod="ProductFormView_UpdateItem">
                <EditItemTemplate>
                    <div class="editor-label">
                        <label for="Name">Namn</label>
                    </div>
                    <div class="editor-field">
                        <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator1" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Name" ValidationGroup="ProductUpload"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Name" runat="server" Text='<%# BindItem.Name %>' MaxLength="40" />
                    </div>
                    <div class="editor-label">
                        <label for="Price">Priset</label>
                    </div>
                    <div class="editor-field">
                        <asp:RegularExpressionValidator Display="None" ID="RegularExpressionValidator2" runat="server" ErrorMessage="Priset är inte i rätt format." ControlToValidate="Price" ValidationGroup="ProductUpload" ValidationExpression='"^\d ValidationExpression="^\d+(.\d{1,2})?$" +(.\d{1,2})?$"'></asp:RegularExpressionValidator>
                        <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator4" runat="server" ErrorMessage="Ett namn måste anges." ControlToValidate="Price" ValidationGroup="ProductUpload"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Price" runat="server" Text='<%# BindItem.Price %>' />
                    </div>
                    <div class="editor-label">
                        <label for="Description">Beskrivning</label>
                    </div>
                    <div class="editor-field">
                        <asp:RequiredFieldValidator Display="None" ID="RequiredFieldValidator2" runat="server" ErrorMessage="En beskrivning måste anges." ControlToValidate="Description" ValidationGroup="ProductUpload"></asp:RequiredFieldValidator>
                        <asp:TextBox ID="Description" TextMode="MultiLine" Rows="5" runat="server" Text='<%# BindItem.Description %>' MaxLength="200" />
                    </div>
                    <div class="editor-label">
                        <label for="Image">Bild</label>
                    </div>
                    <div class="editor-field">
                        <asp:TextBox ID="AddImage" runat="server" Text='<%# BindItem.Image %>' Enabled="False" />
                    </div>
                    <div>
                        <asp:LinkButton runat="server" Text="Spara" CommandName="Update" />
                        <asp:LinkButton ID="BackProducts" OnClick="BackToProducts_Click" Text="Avbryt" runat="server" />
                        
                        <%--<asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("AProducts") %>'></asp:HyperLink>
                        <asp:HyperLink runat="server" Text="Avbryt" NavigateUrl='<%# GetRouteUrl("AProducts") %>' />--%>
                    </div>
                    <div class="editor-field">
                     <asp:DropDownList ID="CategoryDropDownList" runat="server"
                                    ItemType="WebshopClick.Model.BLL.Category"
                                    SelectMethod="CategoryDropDownList_GetData"
                                    DataTextField="CategoryName"
                                    DataValueField="CategoryID"
                                    SelectedValue='<%# BindItem.CategoryID %>'
                                    Enabled="true" />
                    </div>

                </EditItemTemplate>
            </asp:FormView>
    <%-- Uploading of images --%>
            <asp:Panel ID="UploadPanel" runat="server"> 
      
            <asp:ValidationSummary 
                ID="ValidationSummary1" 
                ValidationGroup="ImageUpload"
                runat="server" />  
            <asp:FileUpload ID="FileUpload" runat="server" />
       
             <asp:RequiredFieldValidator 
                ID="RequiredFieldValidator1" 
                runat="server" 
                ErrorMessage="En fil måste väljas" 
                ControlToValidate="FileUpload" 
                Display="None"
                ValidationGroup="ImageUpload">
            </asp:RequiredFieldValidator>
       
            <asp:RegularExpressionValidator 
                ID="RegularExpressionValidator1" 
                runat="server" 
                ErrorMessage="Endast bilder av typerna gif, jpeg eller png är tillåtna." 
                ControlToValidate="FileUpload" 
                ValidationExpression='.*(\.[Jj][Pp][Gg]|\.[Gg][Ii][Ff]|\.[Jj][Pp][Ee][Gg]|\.[Pp][Nn][Gg])' 
                Display="None" 
                ValidationGroup="ImageUpload"></asp:RegularExpressionValidator>
            <asp:Button ID="UploadButton" runat="server" Text="Ladda upp" OnClick="UploadButton_Click" />
        </asp:Panel>
<%-- Uploading of images END --%>
</asp:Content>
