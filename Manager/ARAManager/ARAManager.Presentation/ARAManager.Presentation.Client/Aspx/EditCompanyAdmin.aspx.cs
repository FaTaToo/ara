// --------------------------------------------------------------------------------------------------------------------
// <header file="EditCompanyAdmin.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for EditCompanyAdmin page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Company;
using ARAManager.Common.Exception.Generic;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class EditCompanyAdmin : System.Web.UI.Page {
        #region IFields

        private int m_companyId;
        private Company m_company;
        private readonly Validation m_validator = new Validation();
        private byte[] m_rowVersion;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {
            SetErrorMessages();
            EnableValidator(false);

            if (!Page.IsPostBack) {
                m_companyId = int.Parse(Request.QueryString["RequestId"]);
                m_company = ClientServiceFactory.CompanyService.GetCompanyById(m_companyId);
                if (m_company != null) {
                    txtCompany.Text = Dictionary.COMPANY_ADMIN_EDIT_HEADER;
                    txtCompanyName.Text = m_company.CompanyName;
                    txtAddress.Text = m_company.Address;
                    txtEmail.Text = m_company.Email;
                    txtPhone.Text = m_company.Phone;
                    txtUsername.Text = m_company.UserName;
                    txtPassword.Text = m_company.Password;
                    m_rowVersion = m_company.RowVersion;
                } else if (m_companyId == -4438) {
                            txtCompany.Text = Dictionary.COMPANY_ADMIN_NEW_HEADER;
                       } else {
                            txtCompany.Text = Dictionary.COMPANY_DELETED_EXCEPTION_MSG;
                       }
                }
        }
        protected void CustomValidator_CompanyName_OnServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = m_validator.ValidateChar100(txtCompanyName.Text);
        }
        protected void CustomValidator_Address_OnServerValidate(object source, ServerValidateEventArgs args) {
          
            args.IsValid = m_validator.ValidateChar500(txtAddress.Text);
        }
        protected void CustomValidator_Email_OnServerValidate(object source, ServerValidateEventArgs args) {
            
            args.IsValid = m_validator.ValidateChar100(txtEmail.Text);
        }
        protected void CustomValidator_Phone_OnServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = m_validator.ValidateChar20(txtPhone.Text);
        }
        protected void CustomValidator_Username_OnServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = m_validator.ValidateChar100(txtUsername.Text);
        }
        protected void CustomValidator_Password_OnServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = m_validator.ValidateChar100(txtPassword.Text);
        }
        protected void btnSave_OnClick(object sender, EventArgs e) {
            EnableValidator(true);
            Page.Validate();
            if (txtCompany.Text == Dictionary.COMPANY_ADMIN_NEW_HEADER) {
               var company = new Company {
                    CompanyName = txtCompanyName.Text,
                    Address = txtAddress.Text,
                    Email = txtAddress.Text,
                    Phone = txtPhone.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text
                };
                try {
                    ClientServiceFactory.CompanyService.SaveNewCompany(company);
                }
                catch (FaultException<CompanyNameAlreadyExistException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                }
                catch (FaultException<Exception> ex) {
                    lblMessage.Text = ex.Detail.Message;
                }
            } else {
                m_company.CompanyName = txtCompanyName.Text;
                m_company.Address = txtAddress.Text;
                m_company.Email = txtEmail.Text;
                m_company.Phone = txtPhone.Text;
                m_company.UserName = txtUsername.Text;
                m_company.Password = txtPassword.Text;
                m_company.RowVersion = m_rowVersion;
                try {
                    ClientServiceFactory.CompanyService.SaveNewCompany(m_company);
                }
                catch (FaultException<ConcurrentUpdateException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                }
            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e) {
            Response.Redirect("CompanyAdmin.aspx");
        }
        private void SetErrorMessages()
        {
            CustomValidator_CompanyName.ErrorMessage = Validation.VALIDATOR_COMPANY_NAME;
            CustomValidator_Address.ErrorMessage = Validation.VALIDATOR_ADDRESS;
            CustomValidator_Email.ErrorMessage = Validation.VALIDATOR_EMAIL;
            CustomValidator_Phone.ErrorMessage = Validation.VALIDATOR_PHONE;
            CustomValidator_Username.ErrorMessage = Validation.VALIDATOR_USERNAME;
            CustomValidator_Password.ErrorMessage = Validation.VALIDATOR_PASSWORD;
            RequiredFieldValidator_Name.ErrorMessage = Validation.REQUIRE_COMPANYADMIN_NAME;
            RequiredFieldValidator_Address.ErrorMessage = Validation.REQUIRE_ADDRESS;
            RequiredFieldValidator_Email.ErrorMessage = Validation.REQUIRE_EMAIL;
            RequiredFieldValidator_Phone.ErrorMessage = Validation.REQUIRE_PHONE;
            RequiredFieldValidator_Username.ErrorMessage = Validation.REQUIRE_USERNAME;
            RequiredFieldValidator_Password.ErrorMessage = Validation.REQUIRE_PASSWORD;
        }
        private void EnableValidator(bool flag) {
            CustomValidator_CompanyName.Enabled = flag;
            CustomValidator_Address.Enabled = flag;
            CustomValidator_Email.Enabled = flag;
            CustomValidator_Phone.Enabled = flag;
            CustomValidator_Phone.Enabled = flag;
            RequiredFieldValidator_Name.Enabled = flag;
            RequiredFieldValidator_Address.Enabled = flag;
            RequiredFieldValidator_Email.Enabled = flag;
            RequiredFieldValidator_Phone.Enabled = flag;
            RequiredFieldValidator_Username.Enabled = flag;
        }
        #endregion IMethods
    }
}