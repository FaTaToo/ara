<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="TargetMissionCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.TargetMissionCampaignCompany" %>

<%@ Register Assembly="GMaps" Namespace="Subgurim.Controles" TagPrefix="cc1" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--
    <header file="TargetMissionCampaignCompany.aspx" group="288-462">
        Author: LE Sanh Phuc - 11520288
    </header>
    <summary>
        GUI of TargetMissionCampaignCompany.
    </summary>
    <Problems>
        1. Does not check whether uploaded target has any file.
        2. Does not validate movie information (remember to check maximum 4 files in pictures gallery)
    </Problems>
    -->
    <asp:ScriptManager ID="ScriptManager1" runat="server"/>
    <div class="container">
        <div class="row">
            <div class="col-md-6">
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <asp:Label ID="lblInformation" runat="server" Text="Information"
                                   Width="60%"
                                   BackColor="darkred"
                                   Font-Bold="True"
                                   ForeColor="white"
                                   BorderColor="yellow"
                                   Enabled="False"
                                   Style="text-align: center"/>
                    </li>
                    <li role="presentation" style="margin-left: 20px; margin-top: 20px;">
                        <asp:TextBox ID="txtArName" runat="server"
                                     placeholder="Name"/>
                    </li>
                    <li role="presentation" style="margin-left: 20px; margin-top: 20px;">
                        <asp:TextBox ID="txtDirector" runat="server"
                                     placeholder="Director of movie"/>
                    </li>
                    <li role="presentation" style="margin-left: 20px; margin-top: 20px;">
                        <asp:TextBox ID="txtActor" runat="server"
                                     placeholder="Actor of movie"/>
                    </li>
                    <li role="presentation" style="margin-left: 20px; margin-top: 20px;">
                        <asp:TextBox ID="txtDescription" runat="server"
                                     placeholder="Description"/>
                    </li>
                    <li role="presentation" style="margin-top: 20px;">
                        <asp:Label ID="lblPicturesGallery" runat="server" Text="Picture gallery"
                                   Width="60%"
                                   BackColor="darkred"
                                   Font-Bold="True"
                                   ForeColor="white"
                                   BorderColor="yellow"
                                   Enabled="False"
                                   Style="text-align: center"/>
                    </li>
                    <li role="presentation" style="margin-top: 20px;">
                        <asp:FileUpload runat="server" ID="FileUpload_PicturesGallery" AllowMultiple="true"/>
                    </li>
                </ul>

            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <asp:Panel ID="Panel_Result" runat="server">
        <!--#region TARGET_INFORMATION-->
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="margin-left: 20px; margin-top: 20px;">
                    <asp:TextBox ID="txtTarget"
                                 Width="100%"
                                 BackColor="darkred"
                                 Font-Size="large"
                                 Font-Bold="True"
                                 ForeColor="white"
                                 BorderColor="yellow"
                                 Enabled="False"
                                 Style="text-align: center"
                                 runat="server">
                        TARGET information
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-bottom: 20px; margin-left: 20px; margin-top: 20px;">
                    <table class="table" style="border-style: none">
                        <!--#region NAME-->
                        <tr>
                            <td style="width: 30%">Name</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtTargetName" runat="server"
                                             Width="100%"
                                             placeholder="Name of target"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_TargetName" runat="server"
                                                            ControlToValidate="txtTargetName"
                                                            ForeColor="Red"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:CustomValidator ID="CustomValidator_TargetName" runat="server"
                                                     ForeColor="Red"
                                                     OnServerValidate="CustomValidator_TargetName_OnServerValidate"/>
                            </td>
                        </tr>
                        <!--#endregion NAME-->

                        <!--#region TARGET-->
                        <tr>
                            <td style="width: 30%">Target</td>
                            <td style="width: 70%">
                                <asp:FileUpload ID="FileUpload_Target" runat="server"/>
                            </td>
                        </tr>
                        <!--#endregion TARGET-->

                        <!--#region GOOGLE_MAP-->
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <cc1:GMap ID="GMAP_Target" runat="server"
                                          enableServerEvents="True"
                                          OnClick="GMAP_Target_OnClick"
                                          OnMarkerClick="GMAP_Target_OnMarkerClick"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%">Latitude</td>
                            <td style="width: 25%">
                                <asp:TextBox ID="txtLat" runat="server"
                                             Width="25%"
                                             placeholder="Latitude"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 25%">Longtitude</td>
                            <td style="width: 25%">
                                <asp:TextBox ID="txtLong" runat="server"
                                             Width="25%"
                                             placeholder="Longtitude"/>
                            </td>
                        </tr>
                        <!--#endregion GOOGLE_MAP-->

                        <!--#region ADDRESS-->
                        <tr>
                            <td style="width: 30%">Address</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtAddress" runat="server"
                                             Width="100%"
                                             placeholder="Location"/>
                            </td>
                        </tr>
                        <!--#endregion ADDRESS-->

                        <!--#region FACEBOOK_URL-->
                        <tr>
                            <td style="width: 30%">Facebook</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtFacebookUrl" runat="server"
                                             Width="100%"
                                             placeholder="Facebook URL"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Facebook" runat="server"
                                                            ControlToValidate="txtFacebookUrl"
                                                            ForeColor="Red"/>
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
                                             placeholder="Youtube URL"/>
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_Youtube" runat="server"
                                                            ControlToValidate="txtYoutubeUrl"
                                                            ForeColor="Red"/>
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
                                           Width="100%"/>
                            </td>
                        </tr>
                        <!--#endregion ERROR_MESSAGE-->
                    </table>
                    <!--#endregion INFORMATION-->

                    <!--#region BUTTON-->
                    <ul class="nav nav-pills pull-left">
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Button ID="btnCreateTarget" runat="server"
                                        CssClass="btn btn-danger"
                                        Text="Upload target NOW"
                                        OnClick="btnCreateTarget_OnClick"/>
                        </li>
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Button ID="btnCancel" runat="server"
                                        CssClass="btn btn-warning"
                                        Text="Cancel"
                                        OnClick="btnCancel_OnClick"/>
                        </li>
                    </ul>
                    <!--#endregion BUTTON-->
                </div>
            </div>
        </div>
        <!--#endregion TARGET_INFORMATION-->
    </asp:Panel>
</asp:Content>