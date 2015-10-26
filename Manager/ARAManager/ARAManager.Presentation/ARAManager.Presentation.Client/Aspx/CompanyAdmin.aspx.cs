// --------------------------------------------------------------------------------------------------------------------
// <header file="CompanyAdmin.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for CompanyAdmin page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx
{
    public partial class CompanyAdmin : System.Web.UI.Page
    {
        #region IFields

        readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CustomValidator_CompanyName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtCompanyName.Text);
        }

        protected void CustomValidator_EmailAddress_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtEmail.Text);
        }

        protected void CustomValidator_PhoneNumber_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar20(txtPhone.Text);
        }

        protected void CustomValidator_UserName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtUserName.Text);
        }

        protected void CustomValidator_RequireFileds_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (!string.IsNullOrEmpty(txtCompanyName.Text) ||
                !string.IsNullOrEmpty(txtEmail.Text) ||
                !string.IsNullOrEmpty(txtPhone.Text) ||
                !string.IsNullOrEmpty(txtUserName.Text)) {
                args.IsValid = true;
            } else {
                args.IsValid = false;    
            }
            
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                Panel_Result.Visible = true;
                var result = ClientServiceFactory.CompanyService.SearchCompany(txtCompanyName.Text,
                    txtEmail.Text,
                    txtPhone.Text,
                    txtUserName.Text);
                GridViewResult.DataSource = result;
                GridViewResult.DataBind();
            }
        }

        #endregion IMethods
    }
}