<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementCompany.master" AutoEventWireup="true" CodeBehind="CampaignCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.CampaignCompany" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
<!--
 <header file="CampaignCompany.aspx" group="288-462">
    Author: LE Sanh Phuc - 11520288
 </header>
 <summary>
    GUI of CampaignCompany.
 </summary>
 <Problems>
 </Problems>
-->
    <!--#region SEARCH_FORMS-->
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
                    <li role="presentation" style="margin-top: 20px; margin-left: 35px">
                        <asp:Button ID="btnSearch" runat="server"
                            CssClass="btn btn-success"
                            Text="Search"
                            OnClick="btnSearch_OnClick" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!--#endregion SEARCH_FORMS-->
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" Visible="False" runat="server">
    <!--#region SEARCH_RESULT-->
    <asp:Panel ID="Panel_Result" runat="server" Visible="False">
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:TextBox ID="txtCampaign"
                        Width="100%"
                        BackColor="darkred"
                        Font-Size="large"
                        Font-Bold="True"
                        ForeColor="white"
                        BorderColor="yellow"
                        Enabled="False"
                        Style="text-align: center"
                        runat="server">CAMPAIGNS</asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:Label ID="lblMessage" runat="server"
                        ForeColor="Red" />
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <div class="btn-toolbar" role="toolbar">
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnSelectAll" runat="server"
                                CssClass="btn btn-warning"
                                Text="Select all"
                                OnClick="btnSelectAll_OnClick" />
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnDeselectAll" runat="server"
                                CssClass="btn btn-warning"
                                Text="Deselect all"
                                OnClick="btnDeselectAll_OnClick" />
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnDelete" runat="server"
                                CssClass="btn btn-danger"
                                Text="Delete"
                                OnClick="btnDelete_OnClick" />
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnClear" runat="server"
                                CssClass="btn btn-warning"
                                Text="Clear"
                                OnClick="btnClear_OnClick" />
                        </div>
                    </div>
                </div>
            </div>
            <!--Headers center does not affect-->
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                    
                    <asp:GridView ID="GridViewResult" runat="server"
                        Width="100%"
                        AllowPaging="True"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        RowStyle-HorizontalAlign="Center">
                        <headerstyle HorizontalAlign="Center"/>
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("CampaignId") %>' />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField
                                DataNavigateUrlFields="CampaignId"
                                HeaderText="Id"
                                DataNavigateUrlFormatString="EditCampaignCompany.aspx?Method=Edit&RequestId={0}"
                                DataTextField="CampaignId"
                                ItemStyle-Width="10%" />
                            <asp:BoundField DataField="CampaignName" HeaderText="Name" ItemStyle-Width="20%" />
                            <asp:BoundField DataField="StartTime" HeaderText="StartTime" ItemStyle-Width="20%" DataFormatString="{0:MM.dd.yy}" />
                            <asp:BoundField DataField="EndTime" HeaderText="EndTime" ItemStyle-Width="20%" DataFormatString="{0:MM.dd.yy}" />
                            <asp:BoundField DataField="Description" HeaderText="Description" ItemStyle-Width="20%" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--#endregion SEARCH_RESULT-->
</asp:Content>
