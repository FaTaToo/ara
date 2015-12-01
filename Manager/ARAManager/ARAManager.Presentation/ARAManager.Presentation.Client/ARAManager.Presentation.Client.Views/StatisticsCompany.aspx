<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="StatisticsCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.StatisticsCompany" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="asp" %>


<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <asp:TextBox ID="txtCampaignName" runat="server"
                            placeholder="Campaign name" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_CampaignName" runat="server"
                            OnServerValidate="CustomValidator_CampaignName_OnServerValidate" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_RequireFileds" runat="server"
                            ForeColor="Red"
                            OnServerValidate="CustomValidator_RequireFileds_OnServerValidate" />
                    </li>
                    <li role="presentation" style="margin-left: 35px; margin-top: 20px;">
                        <asp:Button ID="btnSearch" runat="server"
                            CssClass="btn btn-success"
                            Text="Search"
                            OnClick="btnSearch_OnClick" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div class="container">
        <div class="generalStatistics">
            <div class="row">
                <asp:Label CssClass="col-md-3" runat="server" ID="lblCampaignNum"></asp:Label>
                <asp:Label CssClass="col-md-3" runat="server" ID="lblSubcriptionNum"></asp:Label>
            </div>
            <div class="row">
                <div class="col-md-6">
                    <asp:BarChart ID="campaignChart" runat="server" ChartHeight="300" ChartWidth="450"
                        ChartTitle="Campaign statistics" ChartType="Column" ChartTitleColor="#0E426C" Visible="True"
                        CategoryAxisLineColor="#D08AD9" ValueAxisLineColor="#D08AD9" BaseLineColor="#A156AB">
                    </asp:BarChart>
                </div>
            </div>
        </div>
    </div>
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-bottom: 20px; margin-left: 20px; margin-top: 20px;">
                <!--#region TITLE-->
                <asp:TextBox ID="txtCampaignDetail"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">
                    Campaign Information
                </asp:TextBox>
                <!--#endregion TITLE-->

                <!--#region INFORMATION-->
                <table class="table" style="border-style: none">
                    <tr>
                        <td style="width: 30%">Campaign Name: </td>
                        <td style="width: 70%">
                            <asp:Label ID="lblCampaignName" runat="server"
                                Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Total Subcription: </td>
                        <td style="width: 70%">
                            <asp:Label ID="lblTotalSub" runat="server"
                                Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Total Complete Subcription: </td>
                        <td style="width: 70%">
                            <asp:Label ID="lblCompleteSub" runat="server"
                                Width="100%" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Average Rating: </td>
                        <td style="width: 70%">
                            <asp:Label ID="lblAveRating" runat="server"
                                Width="100%" />
                        </td>
                    </tr>

                </table>
            </div>
        </div>
    </div>

    <asp:ScriptManager ID="ScriptManager" runat="server">
    </asp:ScriptManager>
</asp:Content>
