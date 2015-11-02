<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="MissionCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.MissionCampaignCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <asp:Panel ID="Panel_Mission" runat="server"
                    ScrollBars="Vertical">
                    <asp:GridView ID="GridView_Mission" runat="server"
                        Width="100%"
                        BorderStyle="None"
                        AutoGenerateColumns="False">
                        <Columns>
                            <asp:BoundField DataField="Avatar" />
                            <asp:HyperLinkField
                                DataNavigateUrlFields="MissionId"
                                DataNavigateUrlFormatString="MissionCampaignCompany.aspx?RequestId={0}"
                                DataTextField="MissionId" />
                        </Columns>
                    </asp:GridView>
                </asp:Panel>
            </div>
        </div>
        <div class="row">
            <div class="col-md-2">
                <asp:Button ID="btnCreateMission" runat="server"
                    CssClass="btn btn-success"
                    Text="Button" />
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <asp:Panel ID="Panel_Result" runat="server" Visible="False">
        <!--#region MISSION_INFORMATION-->
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:TextBox ID="txtMission"
                        Width="100%"
                        BackColor="darkred"
                        Font-Size="large"
                        Font-Bold="True"
                        ForeColor="white"
                        BorderColor="yellow"
                        Enabled="False"
                        Style="text-align: center"
                        runat="server">MISSION information</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                    <table class="table" style="border-style: none">
                        <!--#region NAME-->
                        <tr>
                            <td style="width: 30%">Name</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtMissionName" runat="server"
                                    Width="100%"
                                    placeholder="Name of mission" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_MissionName" runat="server"
                                    ControlToValidate="txtMissionName"
                                    ForeColor="Red" />
                                <asp:CustomValidator ID="CustomValidator_MissionName" runat="server"
                                    ForeColor="Red"
                                    OnServerValidate="CustomValidator_MissionName_OnServerValidate" />
                            </td>
                        </tr>
                        <!--#endregion NAME-->

                        <!--#region DESCRIPTION-->
                        <tr>
                            <td style="width: 30%">Description</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtDescription" runat="server"
                                    Width="100%"
                                    placeholder="Description of mission" />
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
                                    OnServerValidate="CustomValidator_Description_OnServerValidate" />
                            </td>
                        </tr>
                        <!--#endregion DESCRIPTION-->

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
                                    ForeColor="Red"
                                    OnServerValidate="CustomValidator_Avatar_OnServerValidate" />
                            </td>
                        </tr>
                        <!--#endregion AVATAR-->

                        <!--#region NUM_TARGET-->
                        <tr>
                            <td style="width: 30%">Number of target</td>
                            <td style="width: 70%">
                                <asp:TextBox ID="txtNumTarget" runat="server"
                                    Width="100%"
                                    placeholder="Number of target" />
                            </td>
                        </tr>
                        <tr>
                            <td style="width: 30%"></td>
                            <td style="width: 70%">
                                <asp:RequiredFieldValidator ID="RequiredFieldValidator_txtNumTarget" runat="server"
                                    ControlToValidate="txtNumTarget"
                                    ForeColor="Red" />
                                <asp:RangeValidator ID="RangeValidator_NumMission" runat="server"
                                    ForeColor="Red"
                                    Type="Integer"
                                    MinimumValue="0"
                                    MaximumValue="2147483647"
                                    ControlToValidate="txtNumTarget" />
                            </td>
                        </tr>
                        <!--#endregion NUM_TARGET-->

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
                            <asp:Label ID="lblCreateMission" runat="server" />
                        </li>
                        <li role="presentation" style="margin-left: 20px">
                            <asp:Button ID="btnCreateTarget" runat="server"
                                CssClass="btn btn-warning"
                                Text="Upload target NOW"
                                OnClick="btnCreateTarget_OnClick" />
                        </li>
                    </ul>
                    <!--#endregion BUTTON-->
                </div>
            </div>
        </div>
        <!--#endregion MISSION_INFORMATION-->
    </asp:Panel>
</asp:Content>
