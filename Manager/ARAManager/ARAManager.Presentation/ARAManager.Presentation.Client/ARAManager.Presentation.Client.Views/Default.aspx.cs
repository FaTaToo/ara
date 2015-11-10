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
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class Default : Page
    {
        #region IFields

        private readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {

        }
        protected void btnLogin_OnClick(object sender, EventArgs e)
        {
            CustomValidator_UserEmail.Validate();
            CustomValidator_UserPass.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            var login = ClientServiceFactory.CompanyService.AuthenticateUser(UserEmail.Text, UserPass.Text);

            if (login != -1)
            {
                FormsAuthentication.RedirectFromLoginPage(UserEmail.Text, cbRememberPassword.Checked);
                Response.Redirect(login == 1 ? "HomeAdmin.aspx" : "CampaignCompany.aspx");
            }
            else
            {
                lblMessageIncredential.Text = Dictionary.INVALID_LOGIN;
                UserEmail.Text = string.Empty;
                UserPass.Text = string.Empty;
            }
        }
        protected void CustomValidator_UserEmail_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_UserEmail.ErrorMessage = Validation.VALIDATOR_USEREMAIL_FORMAT;
            args.IsValid = m_validator.ValidateChar100(UserEmail.Text);
        }
        protected void CustomValidator_UserPass_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_UserPass.ErrorMessage = Validation.VALIDATOR_USERPASS_FORMAT;
            args.IsValid = m_validator.ValidateChar100(UserPass.Text);
        }

        #endregion IMethods
    }
}