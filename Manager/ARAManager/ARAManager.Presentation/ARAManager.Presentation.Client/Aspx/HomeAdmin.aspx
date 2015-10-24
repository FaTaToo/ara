<%@ Page Title="" Language="C#" MasterPageFile="~/Master_Pages/Management_Admin.master" AutoEventWireup="true" CodeBehind="HomeAdmin.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.HomeAdmin" %>

<asp:Content ID="Content1" ContentPlaceHolderID="ContentPlaceHolder_Search" runat="server">
    <div class="container">
        <div class="row">
            <div class="col-md-12">
                <ul class="nav nav-pills nav-stacked pull-left">
                    <li role="presentation">
                        <ul class="nav nav-pills pull-left">
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_1" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_2" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_3" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_4" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_5" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCustomers_6" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                        </ul>
                    </li>
                    <li role="presentation">
                        <p class="pull-left" style="margin-left: 20px; font-weight: bold">TOTAL CUSTOMERS</p>
                    </li>
                    <li role="presentation">
                        <ul class="nav nav-pills pull-left">
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_1" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_2" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_3" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_4" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_5" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCompanies_6" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                        </ul>
                    </li>
                    <li role="presentation">
                        <p class="pull-left" style="margin-left: 20px; font-weight: bold">TOTAL COMPANIES</p>
                    </li>
                    <li role="presentation">
                        <ul class="nav nav-pills pull-left">
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_1" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_2" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_3" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_4" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_5" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                            <li role="presentation">
                                <asp:TextBox ID="txtNumCampaigns_6" Enabled="False" runat="server"
                                    ForeColor="white"
                                    BackColor="black"
                                    Width="30px"
                                    MaxLength="1"></asp:TextBox>
                            </li>
                        </ul>
                    </li>
                    <li role="presentation">
                        <p class="pull-left" style="margin-left: 20px; font-weight: bold">TOTAL CAMPAIGNS</p>
                    </li>
                </ul>
            </div>
        </div>
    </div>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder_Content" runat="server">
    <div class="container" style="margin-top: 20px; margin-left: 30px">
        <div class="row">
            <div class="col-md6" style="margin-left: 20px">
                <asp:TextBox ID="txtListOfCinema"
                    Width="550px"
                    BackColor="darkred"
                    Font-Size="large"
                    Font-Bold="True"
                    ForeColor="white"
                    BorderColor="yellow"
                    Enabled="False"
                    Style="text-align: center"
                    runat="server">LIST OF MOVIE THEATERS</asp:TextBox>
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <input type="search" id="search" value="" class="form-control" style="margin-top: 20px"
                    placeholder="Enter keyword to search.">
            </div>
        </div>
        <div class="row">
            <div class="col-md-6">
                <table class="table" id="table">
                    <thead>
                        <tr>
                            <th>Region</th>
                            <th>Cinema</th>
                            <th>City</th>
                            <th>Name</th>
                            <th>Address</th>
                        </tr>
                    </thead>
                    <tbody>
                        <tr>
                            <td>South</td>
                            <td>Lotte</td>
                            <td>HCM</td>
                            <td>Cantavil</td>
                            <td>Tầng 7, Cantavil Premier, Xa lộ Hà Nội, P.An Phú, Q.2, TP.HCM</td>
                        </tr>
                        <tr>
                            <td>South</td>
                            <td>Lotte</td>
                            <td>HCM</td>
                            <td>Cộng Hòa</td>
                            <td>Tầng 4, Pico Plaza, 20 Cộng Hòa, P.12, Q.Tân Bình, TPHCM</td>
                        </tr>
                        <tr>
                            <td>South</td>
                            <td>Lotte</td>
                            <td>HCM</td>
                            <td>Nam Sài Gòn</td>
                            <td>Địa chỉ: Tầng 3 Lotte Mart NSG, 469 Nguyễn Hữu Thọ, q7, TPHCM</td>
                        </tr>
                        <tr>
                            <td>South</td>
                            <td>Lotte</td>
                            <td>HCM</td>
                            <td>Cantavil</td>
                            <td>Tầng 7, Cantavil Premier, Xa lộ Hà Nội, P.An Phú, Q.2, TP.HCM</td>
                        </tr>
                        <tr>
                            <td>South</td>
                            <td>Lotte</td>
                            <td>HCM</td>
                            <td>Phú Thọ</td>
                            <td>Tầng 4 Lotte Mart Phú Thọ, Ngã tư 3/2 và Lê Đại Hành,Quận 11, TPHCM</td>
                        </tr>
                    </tbody>
                </table>
                <hr>
            </div>
        </div>
    </div>
</asp:Content>
