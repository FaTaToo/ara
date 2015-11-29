<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.Default" %>
<!DOCTYPE html>
<!--
 <header file="Default.aspx" group="288-462">
    Author: LE Sanh Phuc - 11520288
 </header>
 <summary>
    GUI of Default.
 </summary>
 <Problems>
 </Problems>
-->
<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>ARA - AR advertisement on mobile - Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class=".container-fluid" style="background: linear-gradient(to right, darkred,red, black, darkred); width: 100%">
        <!--Header - Logo and Name of the system-->
        <div class="row" style="padding-top: 81px">
            <div class="col-md-4 col-xs-4 col-sm-4"></div>
            <div class="col-md-1 col-xs-1 col-sm-4">
                <!--Logo-->
                <img class="img-responsive center-block" src="../ARAManager.Presentation.Client.Resources/Images/logo.png" />
            </div>
            <div class="col-md-1 col-xs-1 col-sm-1">
                <!--ARA name-->
                <p style="color: black; font-size: 36px; font-family: fantasy;"><strong>A</strong>r<strong style="color: gold">Advertisement</strong></p>
            </div>
            <div class="col-md-1 col-xs-1 col-sm-1"></div>
            <div class="col-md-1 col-xs-1 col-sm-1"></div>
            <div class="col-md-4 col-xs-4 col-sm-4"></div>
        </div>
        <!------------------------------------------------------------------------------------------------------>
         <!--Login form-->
        <div class="row" style="padding-top: 36px; padding-bottom: 81px">
            <div class="col-md-4 col-xs-4 col-sm-4"></div>
            <div class="col-md-4 col-xs-4 col-sm-4" style="background: silver">
                <form role="form" runat="server">
                    <!--User name -->
                    <div class="form-group">
                        <label style="padding-top: 15px; font-size: 20px">Username</label>
                        <asp:TextBox ID="UserEmail" CssClass="form-control" runat="server" />
                        <asp:CustomValidator ID="CustomValidator_UserEmail" runat="server"
                                             OnServerValidate="CustomValidator_UserEmail_OnServerValidate"/>
                    </div>
                    <!------------------------------------------------------------------------------------------>
                    <!--Password-->
                    <div class="form-group">
                        <label style="padding-top: 15px; font-size: 20px">Password</label>
                        <asp:TextBox ID="UserPass" CssClass="form-control" TextMode="Password" runat="server"/>
                         <asp:CustomValidator ID="CustomValidator_UserPass" runat="server"
                                             OnServerValidate="CustomValidator_UserPass_OnServerValidate"/>
                    </div>
                    <!------------------------------------------------------------------------------------------>
                    <!--Remeber pass-->
                    <div class="form-group">
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="cbRememberPassword" CssClass="checkbox" runat="server" />
                                Remember me?
                            </label>
                            <asp:HyperLink ID="hpForgetPass" runat="server" Text="Lost your password?" />
                        </div>
                    </div>
                    <!------------------------------------------------------------------------------------------>
                    <!--Authentication failed-->
                    <div class="form-group" style="padding-top: 5px">
                        <asp:Label ID="lblMessageIncredential" ForeColor="red" runat="server" />
                    </div>
                    <!------------------------------------------------------------------------------------------>
                    <!--Login button-->
                    <div class="form-group" style="padding-top: 5px">
                        <asp:Button ID="btnLogin" CssClass="btn btn-primary center-block"
                            OnClick="btnLogin_OnClick"
                            Text="Log On" runat="server" />
                    </div>
                    <!------------------------------------------------------------------------------------------>
                </form>
            </div>
            <div class="col-md-4 col-xs-4 col-sm-4"></div>
        </div>
        <!------------------------------------------------------------------------------------------------------>
    </div>
</body>
</html>