<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="NewCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.NewCampaignCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <!--#region EDIT_INFORMATION-->
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
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
                    runat="server">New "CAMPAIGN" information</asp:TextBox>
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
                                ControlToValidate="txtCampaignName"/>
                            <asp:CustomValidator ID="CustomValidator_CampaignName" runat="server"
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
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_StartTime" runat="server" 
                                ControlToValidate="txtStartTime"/>
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
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_EndTime" runat="server"
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
                                ControlToValidate="txtDescription" />
                            <asp:CustomValidator ID="CustomValidator_Description" runat="server"
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
                                ControlToValidate="txtGift"/>
                            <asp:CustomValidator ID="CustomValidator_Gift" runat="server"
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
                                ControlToValidate="txtMission" />
                            <asp:RangeValidator ID="RangeValidator_NumMission" runat="server"
                                ForeColor="Red"
                                Type="Integer"
                                MinimumValue="0"
                                MaximumValue="2147483647"
                                ControlToValidate="txtMission" />
                        </td>
                    </tr>
                    <!--#endregion NUM_MISSIONS-->
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
                </ul>
                <!--#endregion BUTTON-->
            </div>
        </div>
    </div>
    <!--#endregion EDIT_INFORMATION-->
</asp:Content>
