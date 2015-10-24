<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Company.master" AutoEventWireup="true" CodeBehind="EditCampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditCampaignCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                <asp:TextBox ID="txtCampaign"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">Edit "CAMPAIGN" information</asp:TextBox>
                <table class="table" style="border-style: none">
                    <tr>
                        <td style="width: 30%">Name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtCampaignName" runat="server"
                                Width="100%"
                                placeholder="Campaign name" />
                            <asp:CustomValidator ID="CustomValidator_CampaignName" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Start time</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtStartTime" runat="server"
                                Width="100%"
                                placeholder="The time which the campaign starts" />
                            <asp:CustomValidator ID="CustomValidator_StartTime" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">End time</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtEndTime" runat="server"
                                Width="100%"
                                placeholder="The time which the campaign ends" />
                            <asp:CustomValidator ID="CustomValidator_EndTime" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Description</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtDescription" runat="server"
                                Width="100%"
                                placeholder="Description of the campaign" />
                            <asp:CustomValidator ID="CustomValidator_Description" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Baner</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtBanner" runat="server"
                                Width="100%"
                                placeholder="Banner link of the campaign" />
                            <asp:CustomValidator ID="CustomValidator_Banner" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Avatar</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtAvatar" runat="server"
                                Width="100%"
                                placeholder="Avatar link of the campaign" />
                            <asp:CustomValidator ID="CustomValidator_Avatar" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Gift</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtGift" runat="server"
                                Width="100%"
                                placeholder="Gift of the campaign" />
                            <asp:CustomValidator ID="CustomValidator_Gift" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Number of missions</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtMission" runat="server"
                                Width="100%"
                                placeholder="Number of missions of the campaign" />
                            <asp:RangeValidator ID="RangeValidator_Mission" runat="server"
                                ForeColor="Red"
                                Type="Integer"
                                MinimumValue="0"
                                MaximumValue="2147483647"
                                ControlToValidate="txtMission"
                                ErrorMessage="Please enter number of mission in range from 0 to 2,147,483,647." />
                        </td>
                    </tr>
                </table>
                <ul class="nav nav-pills pull-left">
                    <li role="presentation">
                        <asp:Button ID="btnSave" runat="server"
                            CssClass="btn btn-danger"
                            Text="Save" />
                    </li>
                    <li role="presentation" style="margin-left: 20px">
                        <asp:Button ID="btnCancel" runat="server"
                            CssClass="btn btn-warning"
                            Text="Cancel" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
