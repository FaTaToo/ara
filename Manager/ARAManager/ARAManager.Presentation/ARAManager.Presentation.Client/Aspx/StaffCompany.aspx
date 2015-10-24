<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Company.master" AutoEventWireup="true" CodeBehind="StaffCompany.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.StaffCompany" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <asp:TextBox ID="txtUserName" runat="server"
                            placeholder="User name" />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_Username" runat="server" ErrorMessage="CustomValidator"/>
                    </li>
                    <li role="presentation">
                        <asp:TextBox ID="txtAccountId" runat="server"
                            placeholder="Account Id number" />
                    </li>
                    <li role="presentation">
                        <asp:RangeValidator ID="RangeValidator_AccountId" runat="server"
                            ForeColor="Red"
                            Type="Integer"
                            MinimumValue="0"
                            MaximumValue="2147483647"
                            ControlToValidate="txtAccountId"
                            ErrorMessage="Please enter account id in range from 0 to 2,147,483,647." />
                    </li>
                    <li role="presentation">
                        <asp:CustomValidator ID="CustomValidator_RequireFileds" runat="server"
                            ForeColor="Red"
                            ErrorMessage="Please enter at lease one criterion to search." />
                    </li>
                    <li role="presentation" style="margin-left: 40px">
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
            <div class="col-md-12" style="margin-top: 20px;">
                <asp:TextBox ID="txtTypeOfAccount"
                    Width="55%"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">ACCOUNT CATEGORIES</asp:TextBox>
            </div>
        </div>
                <div class="row">
            <div class="col-md-12" style="margin-top: 20px;">
                <div class="btn-toolbar" role="toolbar">
                    <div class="btn-group" role="group">
                        <asp:Button ID="btnSelectAll" runat="server" 
                            CssClass="btn btn-block"
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
                            CssClass="btn btn-primary"
                            Text="Clear" />
                    </div>
                </div>
            </div>
        </div>
        <div class="row">
            <div class="col-md-12" style="margin-top: 20px; margin-bottom: 20px">
                <asp:GridView ID="GridViewResult" runat="server"
                    Width="55%"
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
                        <asp:HyperLinkField
                            DataNavigateUrlFields="AccountTypeId"
                            HeaderText="Id"
                            DataNavigateUrlFormatString="abc.aspx?Id={0}"
                            DataTextField="AccountTypeId"
                            ItemStyle-Width="20%" />
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
