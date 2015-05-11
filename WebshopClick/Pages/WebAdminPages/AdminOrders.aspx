<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="AdminOrders.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.AdminOrders" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
    <asp:Content ID="Content3" ContentPlaceHolderID="admin_content" runat="server">
    
         <div>
               <asp:DropDownList runat="server" ID="StatusDropDownList"
               SelectMethod="StatusDropDownList_GetData"
               DataTextField="StatusType"
               DataValueField="StatusID"
               OnSelectedIndexChanged="SelectionHasChanged"
               AutoPostBack="True"
               AppendDataBoundItems="true">
                    <asp:ListItem>-- Välj status type --</asp:ListItem>
               </asp:DropDownList>
        </div>
         <asp:ValidationSummary ID="ValidationSummaryCategory" runat="server" />
            <asp:ListView ID="OrderListView" runat="server"
                ItemType="WebshopClick.Model.BLL.Order"
                SelectMethod="OrderListView_GetData"
                <%--InsertMethod="OrderListView_InsertItem"--%>
                UpdateMethod="OrderListView_UpdateItem"
                DeleteMethod="OrderListView_DeleteItem"
                DataKeyNames="OrderID"
                InsertItemPosition="FirstItem">
                <LayoutTemplate>
                    <table class="gridAdmin">
                        <tr>
                            <th>
                                Kund
                            </th>
                            <th>
                                Datum
                            </th>
                            <th>
                                Adress
                            </th>
                             <th>
                                Postnummer
                            </th>
                            <th>
                                Ort
                            </th>
                            <th>
                                Betalningstyp
                            </th>
                            <th>
                                Status
                            </th>
                            <th>
                            </th>
                        </tr>

                        <asp:PlaceHolder ID="itemPlaceholder" runat="server" />
                    </table>
                </LayoutTemplate>
                <ItemTemplate>
<%-- New rows --%>
                    <tr>
                        <td>
                            <asp:DropDownList ID="DropDownList2" runat="server"
                             ItemType="WebshopClick.Model.BLL.Users"
                             SelectMethod="UsersDropDownList_GetData"
                             DataTextField="Name"
                             DataValueField="UserID"
                             SelectedValue='<%# Item.UserID %>'
                             Enabled="false" />
                        </td>
                        
                        <td>
                            <%#: Item.Date %>
                        </td>
                        <td>
                            <%#: Item.Address %>
                        </td>
                        <td>
                            <%#: Item.Postnumber %>
                        </td>
                        <td>
                            <%#: Item.City %>
                        </td>
                        <td>
                        <asp:DropDownList ID="PaymentDropDownList" runat="server"
                             ItemType="WebshopClick.Model.BLL.Payment"
                             SelectMethod="PaymentDropDownList_GetData"
                             DataTextField="PaymentType"
                             DataValueField="PaymentID"
                             SelectedValue='<%# Item.PaymentID %>'
                             Enabled="false" />
                        </td>
                        <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                             ItemType="WebshopClick.Model.BLL.Status"
                             SelectMethod="StatusDropDownList_GetData"
                             DataTextField="StatusType"
                             DataValueField="StatusID"
                             SelectedValue='<%# Item.StatusID %>'
                             Enabled="false" />
                        </td>
                        <td class="command">
                            <asp:LinkButton runat="server" CommandName="Delete" Text="Ta bort" CausesValidation="false" 
                              OnClientClick="return confirm('Ta bort beställning permanent?');" />
                            <asp:LinkButton runat="server" CommandName="Edit" Text="Redigera" CausesValidation="false" />
                            <asp:LinkButton runat="server"  ID="BtnOrderDetails" Text="Detaljer" CausesValidation="false" OnClick="BtnOrderDetails_Click" />
                        </td>
                    </tr>
                </ItemTemplate>
                <EmptyDataTemplate>
<%-- This is template when no orders are found in the database --%>
                    <table class="gridAdmin">
                        <tr>
                            <td>
                                Beställninguppgifter saknas.
                            </td>
                        </tr>
                    </table>
                </EmptyDataTemplate>
                <%--<InsertItemTemplate>
                    <tr>
                        <td>
                            <asp:TextBox ID="Name" MaxLength="30" runat="server" Text='<%# BindItem.CategoryName %>' />
                        </td>
                        <td>
                            <asp:LinkButton runat="server" CommandName="Insert" Text="Lägg till" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Rensa" CausesValidation="false" />
                        </td>
                    </tr>
                </InsertItemTemplate>--%>
                <EditItemTemplate>
                    <tr>
                        <td>
                            
                            <asp:DropDownList ID="DropDownList2" runat="server"
                             ItemType="WebshopClick.Model.BLL.Users"
                             SelectMethod="UsersDropDownList_GetData"
                             DataTextField="Name"
                             DataValueField="UserID"
                             SelectedValue='<%# Item.UserID %>'
                             Enabled="false" />
                        </td>
                        <td>
                            
                           <asp:TextBox ID="TextBox1" runat="server" Enabled="false" Text='<%# BindItem.Date %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox2" runat="server" Enabled="false" Text='<%# BindItem.Address %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox3" runat="server" Enabled="false" Text='<%# BindItem.Postnumber %>' />
                        </td>
                        <td>
                            <asp:TextBox ID="TextBox4" runat="server" Enabled="false" Text='<%# BindItem.City %>' />
                        </td>
                        <td>
                        <asp:DropDownList ID="PaymentDropDownList" runat="server"
                             ItemType="WebshopClick.Model.BLL.Payment"
                             SelectMethod="PaymentDropDownList_GetData"
                             DataTextField="PaymentType"
                             DataValueField="PaymentID"
                             SelectedValue='<%# Item.PaymentID %>'
                             Enabled="false" />
                        </td>
                        <td>
                        <asp:DropDownList ID="DropDownList1" runat="server"
                             ItemType="WebshopClick.Model.BLL.Status"
                             SelectMethod="StatusDropDownList_GetData"
                             DataTextField="StatusType"
                             DataValueField="StatusID"
                             SelectedValue='<%# Item.StatusID %>'
                             Enabled="true" />
                        </td>
                        <td>
                            
                            <asp:LinkButton runat="server" CommandName="Update" Text="Spara" CausesValidation="false" />
                            <asp:LinkButton runat="server" CommandName="Cancel" Text="Avbryt" CausesValidation="false" />
                        </td>
                    </tr>
                </EditItemTemplate>
            </asp:ListView>

</asp:Content>
