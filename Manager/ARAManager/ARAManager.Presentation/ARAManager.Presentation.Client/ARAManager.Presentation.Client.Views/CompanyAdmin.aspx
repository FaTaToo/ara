<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="CompanyAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.CompanyAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--
    <header file="CompanyAdmin.aspx" group="288-462">
        Author: LE Sanh Phuc - 11520288
    </header>
    <summary>
        GUI of CompanyAdmin.
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
                        <asp:TextBox ID="txtCompanyName" runat="server"
                                     placeholder="Name of company"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_CompanyName" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_CompanyName_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtEmail" runat="server"
                                     placeholder="Email address"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_EmailAddress" runat="server"
                                             ForeColor="Red"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtPhone" runat="server"
                                     placeholder="Phone number"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_PhoneNumber" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_PhoneNumber_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtUserName" runat="server"
                                     placeholder="UserName"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_UserName" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_UserName_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_RequireFileds" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_RequireFileds_OnServerValidate"/>
                    </li>
                    <li role="presentation" style="margin-top: 20px">
                        <asp:Button ID="btnSearch" runat="server"
                                    CssClass="btn btn-success"
                                    Text="Search"
                                    OnClick="btnSearch_OnClick"/>
                    </li>
                    <li role="presentation" style="margin-top: 20px">
                        <asp:Button ID="btnNewCompany" runat="server"
                                    CssClass="btn btn-success"
                                    Text="Create new company"
                                    OnClick="btnNewCompany_OnClick"/>
                    </li>
                </ul>
            </div>
        </div>
    </div>
    <!--#endregion SEARCH_FORMS-->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <!--#region SEARCH_RESULT-->
    <asp:Panel ID="Panel_Result" runat="server" Visible="False">
        <div class="container">
            <div class="row">
                <div class="col-md-6" style="margin-left: 20px; margin-top: 20px;">
                    <asp:TextBox ID="txtCompany"
                                 Width="100%"
                                 BackColor="darkred"
                                 Font-Size="large"
                                 Font-Bold="True"
                                 ForeColor="white"
                                 BorderColor="yellow"
                                 Enabled="False"
                                 Style="text-align: center"
                                 runat="server">
                        COMPANY
                    </asp:TextBox>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-left: 20px; margin-top: 20px;">
                    <asp:Label ID="lblMessage" runat="server"
                               ForeColor="Red"/>
                </div>
            </div>
            <div class="row">
                <div class="col-md-6" style="margin-left: 20px; margin-top: 20px;">
                    <div class="btn-toolbar" role="toolbar">
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnSelectAll" runat="server"
                                        CssClass="btn btn-warning"
                                        Text="Select all"
                                        OnClick="btnSelectAll_OnClick"/>
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnDeselectAll" runat="server"
                                        CssClass="btn btn-warning"
                                        Text="Deselect all"
                                        OnClick="btnDeselectAll_OnClick"/>
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnDelete" runat="server"
                                        CssClass="btn btn-danger"
                                        Text="Delete"
                                        OnClick="btnDelete_OnClick"/>
                        </div>
                        <div class="btn-group" role="group">
                            <asp:Button ID="btnClear" runat="server"
                                        CssClass="btn btn-warning"
                                        Text="Clear"
                                        OnClick="btnClear_OnClick"/>
                        </div>
                    </div>
                </div>
            </div>
            <!--Headers center does not affect-->
            <div class="row">
                <div class="col-md-6" style="margin-bottom: 20px; margin-left: 20px; margin-top: 20px;">
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
                                    <asp:CheckBox ID="cbSelect" runat="server"/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("CompanyId") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField
                                DataNavigateUrlFields="CompanyId"
                                HeaderText="Id"
                                DataNavigateUrlFormatString="EditCompanyAdmin.aspx?RequestId={0}"
                                DataTextField="CompanyId"
                                ItemStyle-Width="5%"/>
                            <asp:BoundField DataField="CompanyName" HeaderText="Name" ItemStyle-Width="15%"/>
                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="30%"/>
                            <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="15%"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="15%"/>
                            <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-Width="15%"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--#endregion SEARCH_RESULT-->
</asp:Content>