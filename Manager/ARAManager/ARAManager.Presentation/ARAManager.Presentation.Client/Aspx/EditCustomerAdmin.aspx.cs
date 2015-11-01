// --------------------------------------------------------------------------------------------------------------------
// <header file="EditCustomerAdmin.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for EditCustomerAdmin page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class EditCustomerAdmin : System.Web.UI.Page {
        #region IFields

        private int m_customerId;
        private Customer m_customer;
        private readonly Validation m_validator = new Validation();
        private byte[] m_rowVersion;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {
            SetErrorMessages();
            EnableValidator(false);
            if (!Page.IsPostBack) {
                m_customerId = int.Parse(Request.QueryString["RequestId"]);
                m_customer = ClientServiceFactory.CustomerService.GetCustomerById(m_customerId);
                if (m_customer != null) {
                    txtCustomer.Text = Dictionary.CUSTOMER_ADMIN_EDIT_HEADER;
                    txtFirstName.Text = m_customer.FirstName;
                    txtLastName.Text = m_customer.LastName;
                    DropDownList_Sex.SelectedValue = m_customer.Sex;
                    txtBirthday.Text = m_customer.BirthDay.ToString(Dictionary.DATE_FORMAT);
                    txtAddress.Text = m_customer.Address;
                    txtEmail.Text = m_customer.Email;
                    txtPhone.Text = m_customer.Phone;
                    txtUsername.Text = m_customer.UserName;
                    txtPassword.Text = m_customer.Password;
                    m_rowVersion = m_customer.RowVersion;
                } else if (m_customerId == -4438) {
                    txtCustomer.Text = Dictionary.COMPANY_ADMIN_NEW_HEADER;
                }
                else {
                    txtCustomer.Text = Dictionary.CUSTOMER_DELETED_EXCEPTION_MSG;
                }
            }
        }
        protected void CustomValidator_LastName_OnServerValidate(object source, ServerValidateEventArgs args) {
            args.IsValid = m_validator.ValidateChar100(txtLastName.Text);
        }
        protected void CustomValidator_Birthday_OnServerValidate(object source, ServerValidateEventArgs args) {
            if (!string.IsNullOrEmpty(txtBirthday.Text)) {
                DateTime birthday;
                bool checkBirthday = DateTime.TryParseExact(txtBirthday.Text, 
                    Dictionary.DATE_FORMAT, 
                    Dictionary.EnUs,
                    DateTimeStyles.None,
                    out birthday);

                if (checkBirthday) {
                    args.IsValid = true;
                }
                else {
                    args.IsValid = false;
                    CustomValidator_Birthday.ErrorMessage = Dictionary.DATE_FORMAT;
                }
            }
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
            if (txtCustomer.Text == Dictionary.COMPANY_ADMIN_NEW_HEADER) {
                var customer = new Customer {
                    FirstName = txtFirstName.Text,
                    LastName = txtLastName.Text,
                    Sex = DropDownList_Sex.SelectedValue,
                    BirthDay = DateTime.ParseExact(txtBirthday.Text,Dictionary.DATE_FORMAT, null),
                    Address = txtAddress.Text,
                    Email = txtAddress.Text,
                    Phone = txtPhone.Text,
                    UserName = txtUsername.Text,
                    Password = txtPassword.Text
                };
                try {
                    ClientServiceFactory.CustomerService.SaveNewCustomer(customer);
                } catch (FaultException<UserNameAlreadyExistException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                } catch (FaultException<Exception> ex) {
                    lblMessage.Text = ex.Detail.Message;
                }
            } else {
                m_customer.FirstName = txtFirstName.Text;
                m_customer.LastName = txtLastName.Text;
                m_customer.Sex = DropDownList_Sex.SelectedValue;
                m_customer.BirthDay = DateTime.ParseExact(txtBirthday.Text, Dictionary.DATE_FORMAT, null);
                m_customer.Address = txtAddress.Text;
                m_customer.Email = txtEmail.Text;
                m_customer.Phone = txtPhone.Text;
                m_customer.UserName = txtUsername.Text;
                m_customer.Password = txtPassword.Text;
                m_customer.RowVersion = m_rowVersion;
                try {
                    ClientServiceFactory.CustomerService.SaveNewCustomer(m_customer);
                } catch (FaultException<ConcurrentUpdateException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                }
            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e) {
            Response.Redirect("CustomerAdmin.aspx");
        }
        private void SetErrorMessages() {
            CustomValidator_FirstName.ErrorMessage = Validation.VALIDATOR_CUSTOMER_NAME;
            CustomValidator_LastName.ErrorMessage = Validation.VALIDATOR_CUSTOMER_NAME;
            CustomValidator_Birthday.ErrorMessage = Validation.VALIDATOR_DATE_FORMAT;
            CustomValidator_Address.ErrorMessage = Validation.VALIDATOR_ADDRESS;
            CustomValidator_Email.ErrorMessage = Validation.VALIDATOR_EMAIL;
            CustomValidator_Phone.ErrorMessage = Validation.VALIDATOR_PHONE;
            CustomValidator_Username.ErrorMessage = Validation.VALIDATOR_USERNAME;
            CustomValidator_Password.ErrorMessage = Validation.VALIDATOR_PASSWORD;
            RequiredFieldValidator_FirstName.ErrorMessage = Validation.REQUIRE_CUSTOMER_NAME;
            RequiredFieldValidator_LastName.ErrorMessage = Validation.REQUIRE_CUSTOMER_NAME;
            RequiredFieldValidator_Email.ErrorMessage = Validation.REQUIRE_EMAIL;
            RequiredFieldValidator_Username.ErrorMessage = Validation.REQUIRE_USERNAME;
            RequiredFieldValidator_Password.ErrorMessage = Validation.REQUIRE_PASSWORD;
        }
        protected void CustomValidator_FirstName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtFirstName.Text);
        }
        private void EnableValidator(bool flag) {
            CustomValidator_FirstName.Enabled = flag;
            CustomValidator_LastName.Enabled = flag;
            CustomValidator_Birthday.Enabled = flag;
            CustomValidator_Address.Enabled = flag;
            CustomValidator_Email.Enabled = flag;
            CustomValidator_Phone.Enabled = flag;
            CustomValidator_Username.Enabled = flag;
            CustomValidator_Password.Enabled = flag;
            RequiredFieldValidator_FirstName.Enabled = flag;
            RequiredFieldValidator_LastName.Enabled = flag;
            RequiredFieldValidator_Email.Enabled = flag;
            RequiredFieldValidator_Username.Enabled = flag;
            RequiredFieldValidator_Password.Enabled = flag;
        }
        #endregion IMethods
    }
}