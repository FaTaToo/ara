<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="ARAManager.Presentation.Client.Aspx.Default" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml" lang="en">
<head runat="server">
    <title>ARA - AR advertisement on mobile - Dashboard</title>
    <meta name="viewport" content="width=device-width, initial-scale=1, maximum-scale=1, user-scalable=no" />
    <link href="../Content/bootstrap.min.css" rel="stylesheet" />
</head>
<body>
    <div class=".container-fluid" style="background: linear-gradient(to right, red, black); width: 100%">
        <div class="row" style="padding-top: 81px">
            <div class="col-md-4"></div>
            <div class="col-md-1">
                <img class="img-responsive center-block" src="../Resources/Images/logo.png" />
            </div>
            <div class="col-md-1">
                <p style="color: black; font-size: 36px; font-family: fantasy;"><strong>A</strong>r<strong style="color: yellow">Advertisement</strong></p>
            </div>
            <div class="col-md-1"></div>
            <div class="col-md-1"></div>
            <div class="col-md-4"></div>
        </div>
        <div class="row" style="padding-top: 36px; padding-bottom: 81px">
            <div class="col-md-4"></div>
            <div class="col-md-4" style="background: silver">
                <form role="form" runat="server">
                    <div class="form-group">
                        <label style="padding-top: 15px; font-size: 20px">Username</label>
                        <asp:TextBox ID="UserEmail" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserEmail"
                            ControlToValidate="UserEmail"
                            ForeColor="Red"
                            ErrorMessage="User name can not be empty."
                            runat="server" />
                    </div>
                    <div class="form-group">
                        <label style="padding-top: 15px; font-size: 20px">Password</label>
                        <asp:TextBox ID="UserPass" CssClass="form-control" runat="server" />
                        <asp:RequiredFieldValidator ID="RequiredFieldValidator_UserPass"
                            ControlToValidate="UserPass"
                            ForeColor="Red"
                            ErrorMessage="Password can not be empty."
                            runat="server" />
                    </div>
                    <div class="form-group">
                        <div class="checkbox">
                            <label>
                                <asp:CheckBox ID="Persist" CssClass="checkbox" runat="server" />
                                Remember me?
                            </label>
                            <asp:HyperLink ID="hpForgetPass" runat="server" Text="Lost your password?" />
                        </div>
                    </div>
                    <div class="form-group" style="padding-top: 5px">
                        <asp:Label ID="lblMessageIncredential" ForeColor="red" runat="server" />
                    </div>
                    <div class="form-group" style="padding-top: 5px">
                        <asp:Button ID="btnLogin" CssClass="btn btn-primary center-block"
                            OnClick="btnLogin_OnClick"
                            Text="Log On" runat="server" />
                    </div>
                </form>
            </div>
            <div class="col-md-4"></div>
        </div>
    </div>
</body>
</html>
