<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Admin.master" AutoEventWireup="true" CodeBehind="EditCategoryAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditCategoryAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                <asp:TextBox ID="txtTypeOfAccount"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">Edit "TYPE" of ACCOUNT</asp:TextBox>
                <table class="table" style="border-style: none">
                    <tr>
                        <td style="width: 30%">Name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtAccountTypeName" runat="server"
                                Width="100%"
                                placeholder="Type of account" />
                            <asp:CustomValidator ID="CustomValidator_AccountTypeName" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Group account</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtGroup" runat="server"
                                Width="100%"
                                placeholder="Type of group account" />
                            <asp:RangeValidator ID="RangeValidator_GroupAccount" runat="server"
                                ForeColor="Red"
                                Type="Integer"
                                MinimumValue="0"
                                MaximumValue="2147483647"
                                ControlToValidate="txtGroup"
                                ErrorMessage="Please enter type of group account in range from 0 to 2,147,483,647." />
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
