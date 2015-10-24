<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Company.master" AutoEventWireup="true" CodeBehind="EditStaffCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditStaffCompany" %>
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
                    runat="server">Edit "COMPANY" information</asp:TextBox>
                <table class="table" style="border-style: none">
                    <tr>
                        <td style="width: 30%">UserName</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtUserName" runat="server"
                                Width="100%"
                                placeholder="Username of staff account in company" />
                            <asp:CustomValidator ID="CustomValidator_Username" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Password</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtPassword" runat="server"
                                Width="100%"
                                TextMode="Password"
                                placeholder="Password of staff account in company" />
                            <asp:CustomValidator ID="CustomValidator_Password" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                     <tr>
                        <td style="width: 30%">Re-Password</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtPasswordConfirmation" runat="server"
                                Width="100%"
                                placeholder="Password of staff account in company" />
                            <asp:CustomValidator ID="CustomValidator_PasswordConfirmation" runat="server" ErrorMessage="CustomValidator" />
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
