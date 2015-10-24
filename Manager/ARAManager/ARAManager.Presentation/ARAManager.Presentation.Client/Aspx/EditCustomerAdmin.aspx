<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Admin.master" AutoEventWireup="true" CodeBehind="EditCustomerAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditCustomerAdmin" %>

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
                    runat="server">Edit "CUSTOMER" information</asp:TextBox>
                <table class="table" style="border-style: none">
                    <tr>
                        <td style="width: 30%">First name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtFirstName" runat="server"
                                Width="100%"
                                placeholder="First name" />
                            <asp:CustomValidator ID="CustomValidator_FirstName" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Last name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtLastName" runat="server"
                                Width="100%"
                                placeholder="Last name" />
                            <asp:CustomValidator ID="CustomValidator_LastName" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Sex</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtSex" runat="server"
                                Width="100%"
                                placeholder="Gender" />
                            <asp:CustomValidator ID="CustomValidator_Sex" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Birthday</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtBirthday" runat="server"
                                Width="100%"
                                placeholder="Date of birth" />
                            <asp:CustomValidator ID="CustomValidator_Birthday" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Address</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtAddress" runat="server"
                                Width="100%"
                                placeholder="Address of company" />
                            <asp:CustomValidator ID="CustomValidator_Address" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Email</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtEmail" runat="server"
                                Width="100%"
                                placeholder="Email address" />
                            <asp:CustomValidator ID="CustomValidator_Email" runat="server" ErrorMessage="CustomValidator" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%">Phone</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtPhone" runat="server"
                                Width="100%"
                                placeholder="Phone number" />
                            <asp:CustomValidator ID="CustomValidator_Phone" runat="server" ErrorMessage="CustomValidator" />
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
