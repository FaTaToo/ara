﻿// --------------------------------------------------------------------------------------------------------------------
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
using System.Linq;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class CompanyAdmin : System.Web.UI.Page {
        #region IFields

        readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods

        #region Validators
        protected void CustomValidator_CompanyName_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_CompanyName.ErrorMessage = Validation.VALIDATOR_COMPANYADMIN_NAME;
            args.IsValid = m_validator.ValidateChar100(txtCompanyName.Text);
        }

        protected void CustomValidator_EmailAddress_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_EmailAddress.ErrorMessage = Validation.VALIDATOR_EMAIL;
            args.IsValid = m_validator.ValidateChar100(txtEmail.Text);
        }

        protected void CustomValidator_PhoneNumber_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_EmailAddress.ErrorMessage = Validation.VALIDATOR_PHONE;
            args.IsValid = m_validator.ValidateChar20(txtPhone.Text);
        }

        protected void CustomValidator_UserName_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_EmailAddress.ErrorMessage = Validation.VALIDATOR_USERNAME;
            args.IsValid = m_validator.ValidateChar100(txtUserName.Text);
        }

        protected void CustomValidator_RequireFileds_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_RequireFileds.ErrorMessage = Validation.VALIDATOR_REQUIRED_CRITERION_SEARCH;
            if (!string.IsNullOrEmpty(txtCompanyName.Text) ||
                !string.IsNullOrEmpty(txtEmail.Text) ||
                !string.IsNullOrEmpty(txtPhone.Text) ||
                !string.IsNullOrEmpty(txtUserName.Text)) {
                args.IsValid = true;
            }
            else {
                args.IsValid = false;
            }
        }
        #endregion Validators

        #region Events
        protected void btnSearch_OnClick(object sender, EventArgs e) {
            if (Page.IsValid) {
                Search();
            }
        }

        protected void btnSelectAll_OnClick(object sender, EventArgs e) {
            SelectDeselectGridView(true);
        }

        protected void btnDeselectAll_OnClick(object sender, EventArgs e) {
            SelectDeselectGridView(false);
        }

        protected void btnDelete_OnClick(object sender, EventArgs e) {
            var deletedCompanies = (from GridViewRow row in GridViewResult.Rows
                                    let checkBox = row.Cells[0].FindControl("cbSelect") as CheckBox
                                    where checkBox != null && checkBox.Checked
                                    select row.Cells[1].FindControl("lblId")).OfType<Label>().
                                        Select(label => int.Parse(label.Text)).ToList();
            try {
                ClientServiceFactory.CompanyService.DeleteCompanies(deletedCompanies);
            }
            catch (FaultException ex) {
                lblMessage.Text = ex.Message;
            }
            Search();
        }

        protected void btnClear_OnClick(object sender, EventArgs e) {
            txtCompanyName.Text = string.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUserName.Text = string.Empty;
            GridViewResult.DataSource = null;
            GridViewResult.DataBind();
            Panel_Result.Visible = false;
        }

        #endregion Events
        private void Search() {
            Panel_Result.Visible = true;
            var result = ClientServiceFactory.CompanyService.SearchCompany(txtCompanyName.Text,
                txtEmail.Text,
                txtPhone.Text,
                txtUserName.Text);
            GridViewResult.DataSource = result;
            GridViewResult.DataBind();
        }
        private void SelectDeselectGridView(bool flag)
        {
            foreach (GridViewRow row in GridViewResult.Rows)
            {
                var cb = row.Cells[0].FindControl("cbSelect") as CheckBox;
                if (cb != null)
                {
                    cb.Checked = flag;
                }
            }
        }

        #endregion IMethods
    }
}