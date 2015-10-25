// --------------------------------------------------------------------------------------------------------------------
// <header file="Default.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for Default page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.Security;
using System.Web.UI;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class Default : Page {
        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnLogin_OnClick(object sender, EventArgs e) {
            int login = -1;
            login = ClientServiceFactory.AccountService.AuthenticateUser(
                UserEmail.Text, UserPass.Text);
            if (login != -1) {
                FormsAuthentication.RedirectFromLoginPage(UserEmail.Text, cbRememberPassword.Checked);
                Response.Redirect(login == 1 ? "HomeAdmin.aspx" : "CampaignCompany.aspx");
            } else {
                lblMessageIncredential.Text = "Invalid credentials. Please try again.";
            }
        }

        #endregion IMethods
    }
}