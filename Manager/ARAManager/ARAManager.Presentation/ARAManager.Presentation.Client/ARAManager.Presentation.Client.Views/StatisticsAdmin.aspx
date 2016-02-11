<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="StatisticsAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.StatisticsAdmin" %>
<%@ Register Assembly="AjaxControlToolkit" namespace="AjaxControlToolkit" tagPrefix="asp"%>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div>
        <asp:piechart id="SexPieChart" runat="server" backcolor="#993333" bordercolor="#660033"
                      borderstyle="Solid" forecolor="White" height="349px" width="320px" charttitle="Customers by Sex"
                      charttitlecolor="Blue">
        </asp:piechart>
        <asp:piechart id="AgePieChart" runat="server" backcolor="#993333" bordercolor="#660033"
                      borderstyle="Solid" forecolor="White" height="349px" width="320px" charttitle="Customers by Age"
                      charttitlecolor="Blue">
        </asp:piechart>
    </div>
    <asp:scriptmanager id="ScriptManager1" runat="server">
    </asp:scriptmanager>
</asp:Content>