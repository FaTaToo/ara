﻿<%@ Page Title="" Language="C#" MasterPageFile="~/ARAManager.Presentation.Client.Views/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.CustomerAdmin" %>
<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <!--
    <header file="CustomerAdmin.aspx" group="288-462">
        Author: LE Sanh Phuc - 11520288
    </header>
    <summary>
        GUI of CustomerAdmin.
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
                        <asp:TextBox ID="txtFirstName" runat="server"
                                     placeholder="First name"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_FirstName" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_FirstName_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtLastName" runat="server"
                                     placeholder="Last name"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_LastName" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_LastName_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtEmail" runat="server"
                                     placeholder="Email address"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_Email" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_Email_OnServerValidate"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtPhone" runat="server"
                                     placeholder="Phone number"/>
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_Phone" runat="server"
                                             ForeColor="Red"
                                             OnServerValidate="CustomValidator_Phone_OnServerValidate"/>
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
                        <asp:Button ID="btnNewCustomer" runat="server"
                                    CssClass="btn btn-success"
                                    Text="Create new customer"
                                    OnClick="btnNewCustomer_OnClick"/>
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
                    <asp:TextBox ID="txtCustomer"
                                 Width="100%"
                                 BackColor="darkred"
                                 Font-Size="large"
                                 Font-Bold="True"
                                 ForeColor="white"
                                 BorderColor="yellow"
                                 Enabled="False"
                                 Style="text-align: center"
                                 runat="server">
                        CUSTOMER
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
                                    <asp:Label ID="lblID" runat="server" Text='<%# Eval("CustomerId") %>'/>
                                </ItemTemplate>
                            </asp:TemplateField>
                            <asp:HyperLinkField
                                DataNavigateUrlFields="CustomerId"
                                HeaderText="Id"
                                DataNavigateUrlFormatString="EditCustomerAdmin.aspx?RequestId={0}"
                                DataTextField="CustomerId"
                                ItemStyle-Width="5%"/>
                            <asp:BoundField DataField="FirstName" HeaderText="First Name" ItemStyle-Width="10%"/>
                            <asp:BoundField DataField="LastName" HeaderText="Last Name" ItemStyle-Width="10%"/>
                            <asp:BoundField DataField="Sex" HeaderText="Sex" ItemStyle-Width="10%"/>
                            <asp:BoundField DataField="BirthDay" HeaderText="BirthDay" DataFormatString="{0:MM.dd.yy}" ItemStyle-Width="10%"/>
                            <asp:BoundField DataField="Email" HeaderText="Email" ItemStyle-Width="20%"/>
                            <asp:BoundField DataField="Phone" HeaderText="Phone" ItemStyle-Width="10%"/>
                            <asp:BoundField DataField="UserName" HeaderText="Username" ItemStyle-Width="20%"/>
                        </Columns>
                    </asp:GridView>
                </div>
            </div>
        </div>
    </asp:Panel>
    <!--#endregion SEARCH_RESULT-->
</asp:Content>