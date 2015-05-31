<%@ Page Title="" Language="C#" MasterPageFile="~/Pages/Shared/WebAdmin.Master" AutoEventWireup="true" CodeBehind="Statistics.aspx.cs" Inherits="WebshopClick.Pages.WebAdminPages.Statistics" %>

<%@ Register Assembly="System.Web.DataVisualization, Version=4.0.0.0, Culture=neutral, PublicKeyToken=31bf3856ad364e35" Namespace="System.Web.UI.DataVisualization.Charting" TagPrefix="asp" %>
<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
</asp:Content>
<asp:Content ID="Content3" ContentPlaceHolderID="admin_content" runat="server">
    <asp:Chart ID="Chart1" runat="server">
        <Series>
            <asp:Series Name="Barchart" ChartArea="ChartArea2" ChartType="Bar"></asp:Series>
        </Series>
        <ChartAreas>
            <asp:ChartArea Name="ChartArea1"></asp:ChartArea>
            <asp:ChartArea Name="ChartArea2">
            </asp:ChartArea>
        </ChartAreas>
    </asp:Chart>
</asp:Content>
