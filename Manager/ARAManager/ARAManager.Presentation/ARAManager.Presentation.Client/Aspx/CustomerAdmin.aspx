<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Admin.master" AutoEventWireup="true" CodeBehind="CustomerAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.CustomerAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-2">
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <asp:TextBox ID="txtFirstName" runat="server"
                            placeholder="First name" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_FirstName" runat="server" ErrorMessage="CustomValidator" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtLastName" runat="server"
                            placeholder="Last name" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_LastName" runat="server" ErrorMessage="CustomValidator" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtEmail" runat="server"
                            placeholder="Email address" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_Email" runat="server" ErrorMessage="CustomValidator" />
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtPhone" runat="server"
                            placeholder="Phone number" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_Phone" runat="server" ErrorMessage="CustomValidator"></asp:CustomValidator>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtUserName" runat="server"
                            placeholder="UserName" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_UserName" runat="server" ErrorMessage="CustomValidator" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_RequireFileds" runat="server"
                            ForeColor="Red"
                            ErrorMessage="Please enter at lease one criterion to search." />
                    </li>
                    <li role="presentation" style="margin-left: 30px">
                        <asp:Button ID="btnSearch" runat="server"
                            CssClass="btn btn-success"
                            Text="Search" />
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px;margin-left: 20px">
                <asp:TextBox ID="txtCustomer"
                    Width="100%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">CUSTOMER</asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-left: 20px;">
                <div class="btn-toolbar" role="toolbar">
                    <div class="btn-group" role="group">
                        <asp:Button ID="btnSelectAll" runat="server"
                            CssClass="btn btn-warning"
                            Text="Select all" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="btnDeselectAll" runat="server"
                            CssClass="btn btn-warning"
                            Text="Deselect all" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="btnDelete" runat="server"
                            CssClass="btn btn-danger"
                            Text="Delete" />
                    </div>
                    <div class="btn-group" role="group">
                        <asp:Button ID="btnClear" runat="server"
                            CssClass="btn btn-warning"
                            Text="Clear" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6" style="margin-top: 20px; margin-bottom: 20px;margin-left: 20px">
                <asp:GridView ID="GridViewResult" runat="server"
                    Width="100%"
                    AllowPaging="True"
                    AllowSorting="True"
                    AutoGenerateColumns="False"
                    RowStyle-HorizontalAlign="Center">
                    <Columns>
                        <asp:TemplateField>
                            <ItemTemplate>
                                <asp:CheckBox ID="cbSelect" runat="server" />
                            </ItemTemplate>
                        </asp:TemplateField>
                        <asp:BoundField DataField="Name" HeaderText="Name"
                            ItemStyle-Width="70%" />
                        <%--  <asp:TemplateField HeaderText="Type">
                        <ItemTemplate>
                            <asp:Label runat="server" Text='<%# ConvertStatus(Eval("GroupType")) %>'/>
                        </ItemTemplate>
                        </asp:TemplateField>--%>
                    </Columns>
                </asp:GridView>
            </div>
        </div>
    </div>
</asp:Content>
