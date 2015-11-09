<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="TargetMissionCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.TargetMissionCampaignCompany" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Panel ID="Panel_Target" runat="server"
                    ScrollBars="Vertical">
                    <asp:GridView ID="GridView_Target" runat="server"
                        Width="100%"
                        BorderStyle="None"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="TargetName" />
                            <asp:HyperLinkField
                                DataNavigateUrlFields="TargetId"
                                DataNavigateUrlFormatString="TargetMissionCampaignCompany.aspx?RequestId={0}"
                                DataTextField="TargetId" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <asp:Panel ID="Panel_Result" runat="server" Visible="False">
        <!--#region TARGET_INFORMATION-->
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:TextBox ID="txtTarget"
                        Width="100%"
                        BackColor="darkred"
                        Font-Size="large"
                        Font-Bold="True"
                        ForeColor="white"
                        BorderColor="yellow"
                        Enabled="False"
                        Style="text-align: center"
                        runat="server">TARGET information</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                    <table class="table" style="border-style: none">
                        <!--#region NAME-->
                        <tr>
                            <td style="width: 30%">Name</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtTargetName" runat="server"
                                    Width="100%"
                                    placeholder="Name of target" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_TargetName" runat="server"
                                    ControlToValidate="txtTargetName"
                                    ForeColor="Red" />
                                <asp:CustomValidator ID="CustomValidator_TargetName" runat="server"
                                    ForeColor="Red" 
                                    OnServerValidate="CustomValidator_TargetName_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion NAME-->

                        <!--#region DESCRIPTION-->
                        <tr>
                            <td style="width: 30%">Description</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtDescription" runat="server"
                                    Width="100%"
                                    placeholder="Description of target" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Description" runat="server"
                                    ControlToValidate="txtDescription"
                                    ForeColor="Red" />
                                <asp:CustomValidator ID="CustomValidator_Description" runat="server"
                                    ForeColor="Red"
                                    OnServerValidate="CustomValidator_Description_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion DESCRIPTION-->

                        <!--#region GOOGLE_MAP-->
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <cc1:GMap ID="GMAP_Target" runat="server" 
                                    enableServerEvents="True"
                                    OnClick="GMAP_Target_OnClick"
                                    OnMarkerClick="GMAP_Target_OnMarkerClick"
                                    />
                            </td>
                        </tr>
                        <!--#endregion GOOGLE_MAP-->

                        <!--#region VIDEO_URL-->
                        <tr>
                            <td style="width: 30%">Video</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtVideoUrl" runat="server"
                                    Width="100%"
                                    placeholder="Video URL" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:CustomValidator ID="CustomValidator_Video" runat="server"
                                    ForeColor="Red" 
                                    OnServerValidate="CustomValidator_Video_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion VIDEO_URL-->

                        <!--#region FACEBOOK_URL-->
                        <tr>
                            <td style="width: 30%">Facebook</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtFacebookUrl" runat="server"
                                    Width="100%"
                                    placeholder="Facebook URL" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:CustomValidator ID="CustomValidator_Facebook" runat="server"
                                    ForeColor="Red" 
                                    OnServerValidate="CustomValidator_Facebook_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion FACEBOOK_URL-->

                        <!--#region YOUTUBE_URL-->
                        <tr>
                            <td style="width: 30%">Youtube</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtYoutubeUrl" runat="server"
                                    Width="100%"
                                    placeholder="Youtube URL" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:CustomValidator ID="CustomValidator_Youtube" runat="server"
                                    ForeColor="Red" 
                                    OnServerValidate="CustomValidator_Youtube_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion YOUTUBE_URL-->

                        <!--#region ERROR_MESSAGE-->
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:Label ID="lblMessage" runat="server"
                                    ForeColor="Red"
                                    Width="100%" />
                            </td>
                        </tr>
                        <!--#endregion ERROR_MESSAGE-->
                    </table>
                    <!--#endregion INFORMATION-->

                    <!--#region BUTTON-->
                    <ul class="nav nav-pills pull-left">
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Label ID="lblCreateMission" runat="server" />
                        </li>
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Button ID="btnCreateTarget" runat="server"
                                CssClass="btn btn-warning"
                                Text="Upload target NOW"
                                OnClick="btnCreateTarget_OnClick" />
                        </li>
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Button ID="btnCancel" runat="server"
                                CssClass="btn btn-warning"
                                Text="Cancel"
                                OnClick="btnCancel_OnClick" />
                        </li>
                    </ul>
                    <!--#endregion BUTTON-->
                </div>
            </div>
        </div>
        <!--#endregion TARGET_INFORMATION-->
    </asp:Panel>
</asp:Content>
