<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/ManagementAdmin.master" AutoEventWireup="true" CodeBehind="EditCustomerAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.EditCustomerAdmin" %>

<%@ Register Assembly="AjaxControlToolkit" Namespace="AjaxControlToolkit" TagPrefix="ajaxToolkit" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <!--#region EDIT_INFORMATION-->
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px; margin-left: 20px">
                <!--#region TITLE-->
                <asp:TextBox ID="txtCustomer"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">Edit "CUSTOMER" information</asp:TextBox>
                <!--#endregion TITLE-->

                <!--#region INFORMATION-->
                <table class="table" style="border-style: none">
                    <!--#region FIRST_NAME-->
                    <tr>
                        <td style="width: 30%">First name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtFirstName" runat="server"
                                Width="100%"
                                placeholder="First name" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_FirstName" runat="server"
                                ControlToValidate="txtFirstName"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_FirstName" runat="server"
                                ForeColor="Red"
                                OnServerValidate="CustomValidator_FirstName_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion FIRST_NAME-->

                    <!--#region LAST_NAME-->
                    <tr>
                        <td style="width: 30%">Last name</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtLastName" runat="server"
                                Width="100%"
                                placeholder="Last name" />
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:RequiredFieldValidator ID="RequiredFieldValidator_LastName" runat="server"
                                ControlToValidate="txtLastName"
                                ForeColor="Red" />
                            <asp:CustomValidator ID="CustomValidator_LastName" runat="server"
                                ForeColor="Red"
                                OnServerValidate=CustomValidator_LastName_OnServerValidate />
                        </td>
                    </tr>
                    <!--#endregion LAST_NAME-->

                    <!--#region SEX-->
                    <tr>
                        <td style="width: 30%">Sex</td>
                        <td style="width: 70%">
                            <asp:DropDownList ID="DropDownList_Sex" runat="server">
                                <asp:ListItem Enabled="True" Selected="True" Text="Male" Value="Male"/>
                                <asp:ListItem Enabled="True" Selected="True" Text="Female" Value="Female"/>
                            </asp:DropDownList>
                        </td>
                    </tr>
                    <!--#endregion SEX-->

                    <!--#region BIRTHDAY-->
                    <tr>
                        <td style="width: 30%">Birthday</td>
                        <td style="width: 70%">
                            <asp:TextBox ID="txtBirthday" runat="server"
                                Width="100%"
                                Enabled="False"
                                placeholder="Date of birth" />
                            <ajaxToolkit:CalendarExtender ID="CalendarExtender_Birthday" runat="server" 
                                TargetControlID="txtBirthday"/>
                        </td>
                    </tr>
                    <tr>
                        <td style="width: 30%"></td>
                        <td style="width: 70%">
                            <asp:CustomValidator ID="CustomValidator_Birthday" runat="server"
                                OnServerValidate="CustomValidator_Birthday_OnServerValidate" />
                        </td>
                    </tr>
                    <!--#endregion BIRTHDAY-->

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
                            <asp:CustomValidator ID="CustomValidator_Address" runat="server" 
                                OnServerValidate="CustomValidator_Address_OnServerValidate"/>
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
                            <asp:CustomValidator ID="CustomValidator_Phone" runat="server"
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
                            OnClick="btnSave_OnClick"/>
                    </li>
                    <li role="presentation" style="margin-left: 20px">
                        <asp:Button ID="btnCancel" runat="server"
                            CssClass="btn btn-warning"
                            Text="Cancel"
                            OnClick="btnCancel_OnClick"/>
                    </li>
                </ul>
                <!--#endregion BUTTON-->
            </div>
        </div>
    </div>
    <!--#endregion EDIT_INFORMATION-->
</asp:Content>
