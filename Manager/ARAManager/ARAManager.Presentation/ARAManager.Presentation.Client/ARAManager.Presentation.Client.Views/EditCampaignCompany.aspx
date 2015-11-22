<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="EditCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.EditCampaignCompany" %>

<%@ Register TagPrefix="ajaxToolkit" Namespace="AjaxControlToolkit" Assembly="AjaxControlToolkit, Version=15.1.3.0, Culture=neutral, PublicKeyToken=28f01b0e84b6d53e" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--
 <header file="EditCampaignCompany.aspx" group="288-462">
    Author: LE Sanh Phuc - 11520288
 </header>
 <summary>
    GUI of EditCampaignCompany.
 </summary>
 <Problems>
    1. Have not check case if users input wrong text instead of using datetime picker.
    2. Do not implement customer require validators for Banner.
 </Problems>
-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <asp:ScriptManager ID="ScriptManager1" runat="server" />
    <!--#region EDIT_INFORMATION-->
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                <!--Modified by PhucLS - 20151120 - src-manager-gui - Fix validator messages positions-->
                <!--Fix validators's color-->
                <!--#region TITLE-->
                <asp:TextBox ID="txtCampaign"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">"CAMPAIGN" information</asp:TextBox>
                <!--#endregion TITLE-->
                <div class="row">
                    <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                        <asp:Label ID="lblMessage" runat="server"
                            ForeColor="Red" />
                    </div>
                </div>
                <!--#region INFORMATION-->
                <table class="table" style="border-style: none">
                    <!--#region NAME-->
                    <tr>
                        <td style="width: 30%">Name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtCampaignName" runat="server"
                                Width="100%"
                                placeholder="Campaign name" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_CampaignName" runat="server"
                                ForeColor="Red"
                                ControlToValidate="txtCampaignName" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_CampaignName" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_CampaignName_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion NAME-->

                    <!--#region START_TIME-->
                    <tr>
                        <td style="width: 30%">Start time</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtStartTime" runat="server"
                                Width="100%"
                                placeholder="The time which the campaign starts" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender_StartTime" runat="server"
                                Enabled="True"
                                Format="MM.dd.yy"
                                TargetControlID="txtStartTime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_StartTime" runat="server"
                                ForeColor="Red"
                                ControlToValidate="txtStartTime" />
                        </td>
                    </tr>
                    <!--#endregion START_TIME-->

                    <!--#region END_TIME-->
                    <tr>
                        <td style="width: 30%">End time</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtEndTime" runat="server"
                                Width="100%"
                                placeholder="The time which the campaign ends" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender_EndTime" runat="server"
                                Enabled="True"
                                Format="MM.dd.yy"
                                TargetControlID="txtEndTime" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_EndTime" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_EndTime_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion END_TIME-->

                    <!--#region DESCRIPTION-->
                    <tr>
                        <td style="width: 30%">Description</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtDescription" runat="server"
                                Width="100%"
                                placeholder="Description of the campaign" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server"
                                ForeColor="Red"
                                ControlToValidate="txtDescription" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_Description" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Description_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion DESCRIPTION-->

                    <!--#region BANNER-->
                    <tr>
                        <td style="width: 30%">Banner</td>
                        <td style="width: 70%">
                            <asp:FileUpload ID="FileUpload_Banner" runat="server" />
                        </td>
                    </tr>
                    <!--#endregion BANNER-->

                    <!--#region AVATAR-->
                    <tr>
                        <td style="width: 30%">Avatar</td>
                        <td style="width: 70%">
                            <asp:FileUpload ID="FileUpload_Avatar" runat="server" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_Avatar" runat="server"
                                Display="Dynamic"
                                ValidateEmptyText="True"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Avatar_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion AVATAR-->

                    <!--#region GIFT-->
                    <tr>
                        <td style="width: 30%">Gift</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtGift" runat="server"
                                Width="100%"
                                placeholder="Gift of the campaign" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Gift" runat="server"
                                ForeColor="Red"
                                ControlToValidate="txtGift" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_Gift" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Gift_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion GIFT-->

                    <!--#region NUM_MISSIONS-->
                    <tr>
                        <td style="width: 30%">Number of missions</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtMission" runat="server"
                                Width="100%"
                                placeholder="Number of missions of the campaign" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_NumMission" runat="server"
                                ForeColor="Red"
                                ControlToValidate="txtMission" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RangeValidator ID="RangeValidator_NumMission" runat="server"
                                ForeColor="Red"
                                Type="Integer"
                                MinimumValue="0"
                                MaximumValue="2147483647"
                                ControlToValidate="txtMission" />
                        </td>
                    </tr>
                    <!--#endregion NUM_MISSIONS-->
                    <!--Ended by PhucLS - 20151120 -->
                </table>
                <!--#endregion INFORMATION-->

                <!--#region BUTTON-->
                <ul class="nav nav-pills pull-left">
                    <li role="presentation">
                        <asp:Button ID="btnSave" runat="server"
                            CssClass="btn btn-danger"
                            Text="Save"
                            OnClick="btnSave_OnClick" />
                    </li>
                    <li role="presentation" style="margin-left: 20px">
                        <asp:Button ID="btnCancel" runat="server"
                            CssClass="btn btn-warning"
                            Text="Cancel"
                            OnClick="btnCancel_OnClick" />
                    </li>
                    <li role="presentation" style="margin-left: 20px">
                        <asp:Button ID="btnCreateMission" runat="server"
                            CssClass="btn btn-danger"
                            Text="Create mission"
                            OnClick="btnCreateMission_OnClick" />
                    </li>
                </ul>
                <!--#endregion BUTTON-->
            </div>
        </div>
    </div>
    <!--#endregion EDIT_INFORMATION-->
</asp:Content>
