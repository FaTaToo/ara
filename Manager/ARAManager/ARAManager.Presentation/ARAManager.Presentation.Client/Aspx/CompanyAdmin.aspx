<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="CompanyAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.CompanyAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--#region SEARCH_FORMS-->
    <div class="container">
        <div class="row">
            <!--Modified by PhucLS - 20151027 - Change md-2 to md-6 for fixing lack of space for validators-->
            <div class="col-md-6">
                <!--Ended by PhucLS - 20151027 - Change md-2 to md-6 for fixing lack of space for validators-->
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <asp:TextBox ID="txtCompanyName" runat="server"
                            placeholder="Name of company" />
                        <asp:CustomValidator ID="CustomValidator_CompanyName" runat="server"
                            ForeColor="Red"
                            OnServerValidate="CustomValidator_CompanyName_OnServerValidate" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtEmail" runat="server"
                            placeholder="Email address" />
                        <asp:CustomValidator ID="CustomValidator_EmailAddress" runat="server"
                            ForeColor="Red" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtPhone" runat="server"
                            placeholder="Phone number" />
                        <asp:CustomValidator ID="CustomValidator_PhoneNumber" runat="server"
                            ForeColor="Red"
                            OnServerValidate="CustomValidator_PhoneNumber_OnServerValidate" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtUserName" runat="server"
                            placeholder="UserName" />
                        <asp:CustomValidator ID="CustomValidator_UserName" runat="server"
                            ForeColor="Red"
                            OnServerValidate="CustomValidator_UserName_OnServerValidate" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_RequireFileds" runat="server"
                            ForeColor="Red"
                            OnServerValidate="CustomValidator_RequireFileds_OnServerValidate" />
                    </li>
                    <li role="presentation" style="margin-top:20px">
                        <asp:Button ID="btnSearch" runat="server"
                            CssClass="btn btn-success"
                            Width="100%"
                            Text="Search"
                            OnClick="btnSearch_OnClick" />
                    </li>
                    <li role="presentation" style="margin-top:20px">
                        <asp:Button ID="btnNewCompany" runat="server"
                            CssClass="btn btn-success"
                            Width="100%"
                            Text="Create new company"
                            OnClick="btnNewCompany_OnClick" />
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
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:TextBox ID="txtCompany"
                        Width="100%"
                        BackColor="darkred"
                        Font-Size="large"
                        Font-Bold="True"
                        ForeColor="white"
                        BorderColor="yellow"
                        Enabled="False"
                        Style="text-align: center"
                        runat="server">COMPANY</asp:TextBox>
                </div>
            </div>
             <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-left: 20px">
                    <asp:Label ID="lblMessage" runat="server"
                        ForeColor="Red"/>
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
            <div class="row">
                <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                    <asp:GridView ID="GridViewResult" runat="server"
                        Width="100%"
                        AllowPaging="True"
                        AllowSorting="True"
                        AutoGenerateColumns="False"
                        RowStyle-HorizontalAlign="Center">
                        <Columns>
                            <asp:TemplateField ItemStyle-Width="5%">
                                <ItemTemplate>
                                    <asp:CheckBox ID="cbSelect" runat="server" />
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:TemplateField Visible="False">
                                <ItemTemplate>
                                    <asp:Label ID="lblId" runat="server" Text='<%# Eval("CompanyId") %>'></asp:Label>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField
                                DataNavigateUrlFields="CompanyId"
                                HeaderText="Id"
                                DataNavigateUrlFormatString="EditCompanyAdmin.aspx?RequestId={0}"
                                DataTextField="CompanyId"
                                ItemStyle-Width="5%" />
                            <asp:BoundField DataField="CompanyName" HeaderText="Name" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="Address" HeaderText="Address" ItemStyle-Width="30%" />
                            <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="15%" />
                            <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-Width="15%" />
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--#endregion SEARCH_RESULT-->
</asp:Content>
