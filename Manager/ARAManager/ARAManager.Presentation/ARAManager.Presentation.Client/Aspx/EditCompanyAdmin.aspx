<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="EditCompanyAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditCompanyAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <!--#region EDIT_INFORMATION-->
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                <!--#region TITLE-->
                <asp:TextBox ID="txtCompany"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server" />
                <!--#endregion TITLE-->

                <!--#region INFORMATION-->
                <table class="table" style="border-style: none">
                    <!--#region NAME-->
                    <tr>
                        <td style="width: 30%">Name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtCompanyName" runat="server"
                                Width="100%"
                                placeholder="Name of company" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Name" runat="server"
                                ControlToValidate="txtCompanyName"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_CompanyName" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_CompanyName_OnServerValidate" />

                        </td>
                    </tr>
                    <!--#endregion NAME-->

                    <!--#region ADDRESS-->
                    <tr>
                        <td style="width: 30%">Address</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtAddress" runat="server"
                                Width="100%"
                                placeholder="Address of company" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Address" runat="server"
                                ControlToValidate="txtAddress"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_Address" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Address_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion ADDRESS-->

                    <!--#region EMAIL-->
                    <tr>
                        <td style="width: 30%">Email</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtEmail" runat="server"
                                Width="100%"
                                placeholder="Email address" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Email" runat="server"
                                ControlToValidate="txtEmail"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_Email" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Email_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion EMAIL-->

                    <!--#region PHONE-->
                    <tr>
                        <td style="width: 30%">Phone</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtPhone" runat="server"
                                Width="100%"
                                placeholder="Phone number" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Phone" runat="server"
                                ControlToValidate="txtPhone"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_Phone" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Phone_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion PHONE-->

                    <!--#region USERNAME-->
                    <tr>
                        <td style="width: 30%">User Name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtUsername" runat="server"
                                Width="100%"
                                placeholder="User name" />


                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Username" runat="server"
                                ControlToValidate="txtUsername"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_Username" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Username_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion USERNAME-->

                    <!--#region PASSWORD-->
                    <tr>
                        <td style="width: 30%">Password</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtPassword" runat="server"
                                Width="100%"
                                TextMode="Password"
                                placeholder="Password" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_Password" runat="server"
                                ControlToValidate="txtPassword"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_Password" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_Password_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion PASSWORD-->
                    
                    <!--#region ERROR_MESSAGE-->
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:Label ID="lblMessage" runat="server" 
                                ForeColor="Red"
                                Width="100%"/>
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
                            OnClick="btnSave_OnClick"/>
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
