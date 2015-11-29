<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="NewCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.NewCampaignCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--
 <header file="NewCampaignCompany.aspx" group="288-462">
    Author: LE Sanh Phuc - 11520288
 </header>
 <summary>
    GUI of NewCampaignCompany.
 </summary>
 <Problems>
 </Problems>
-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <div class="container">
        <div class="row" style="margin-top: 20px">
            <div class="col-md-2">
                <img src="../ARAManager.Presentation.Client.Resources/Images/CampaignTypes/checkIn.jpg" alt="Image is lost." />
            </div>
            <div class="col-md-2" style="margin-left: 20px">
                <img src="../ARAManager.Presentation.Client.Resources/Images/CampaignTypes/tour.jpg" alt="Image is lost." />
            </div>
            <div class="col-md-2" style="margin-left: 20px">
                <img src="../ARAManager.Presentation.Client.Resources/Images/CampaignTypes/theater.jpg" alt="Image is lost." />
            </div>
        </div>
        <div class="row">
            <div class="col-md-2" style="margin-left: 100px">
                <asp:RadioButton ID="rbCheckIn" runat="server" GroupName="CampaignTypes"/>
            </div>
            <div class="col-md-2" style="margin-left: 15px">
                <asp:RadioButton ID="rbTour" runat="server" GroupName="CampaignTypes"/>
            </div>
            <div class="col-md-2" style="margin-left: 15px">
                <asp:RadioButton ID="rbTheater" runat="server" GroupName="CampaignTypes"
                    Checked="True"/>
            </div>
        </div>
        <div class="row" style="margin-bottom: 20px">
            <div class="col-md-6" style="margin-left: 220px">
                <asp:Button ID="btnCreate" runat="server" 
                    class="btn btn-danger"
                    Text="Create NEW CAMPAIGN"
                    OnClick="btnCreate_OnClick" />
            </div>
        </div>
    </div>
</asp:Content>
