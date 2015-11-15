// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerAdmin.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for CustomerAdmin page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class CustomerAdmin : System.Web.UI.Page
    {
        #region IFields

        private readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            EnableValidator(false);
        }
        protected void CustomValidator_FirstName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_FirstName.ErrorMessage = Validation.VALIDATOR_CUSTOMER_NAME;
            args.IsValid = m_validator.ValidateChar100(txtFirstName.Text);
        }
        protected void CustomValidator_LastName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_LastName.ErrorMessage = Validation.VALIDATOR_CUSTOMER_NAME;
            args.IsValid = m_validator.ValidateChar100(txtLastName.Text);
        }
        protected void CustomValidator_Email_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Email.ErrorMessage = Validation.VALIDATOR_EMAIL;
            args.IsValid = m_validator.ValidateChar100(txtEmail.Text);
        }
        protected void CustomValidator_Phone_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_LastName.ErrorMessage = Validation.VALIDATOR_PHONE;
            args.IsValid = m_validator.ValidateChar100(txtPhone.Text);
        }
        protected void CustomValidator_UserName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_LastName.ErrorMessage = Validation.VALIDATOR_USERNAME;
            args.IsValid = m_validator.ValidateChar100(txtUserName.Text);
        }
        protected void CustomValidator_RequireFileds_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_RequireFileds.ErrorMessage = Validation.VALIDATOR_REQUIRED_CRITERION_SEARCH;
            if (!string.IsNullOrEmpty(txtFirstName.Text) ||
                !string.IsNullOrEmpty(txtLastName.Text) ||
                !string.IsNullOrEmpty(txtEmail.Text) ||
                !string.IsNullOrEmpty(txtPhone.Text) ||
                !string.IsNullOrEmpty(txtUserName.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void btnSelectAll_OnClick(object sender, EventArgs e)
        {
            SelectDeselectGridView(true);
        }
        protected void btnDeselectAll_OnClick(object sender, EventArgs e)
        {
            SelectDeselectGridView(false);
        }
        protected void btnDelete_OnClick(object sender, EventArgs e)
        {
            var deletedCustomers = (from GridViewRow row in GridViewResult.Rows
                                    let checkBox = row.Cells[0].FindControl("cbSelect") as CheckBox
                                    where checkBox != null && checkBox.Checked
                                    select row.Cells[1].FindControl("lblId")).OfType<Label>().
                                        Select(label => int.Parse(label.Text)).ToList();
            try
            {
                ClientServiceFactory.CustomerService.DeleteCustomers(deletedCustomers);
            }
            catch (FaultException ex)
            {
                lblMessage.Text = ex.Message;
            }
            Search();
        }
        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            txtFirstName.Text = string.Empty;
            txtLastName.Text = String.Empty;
            txtEmail.Text = string.Empty;
            txtPhone.Text = string.Empty;
            txtUserName.Text = string.Empty;
            GridViewResult.DataSource = null;
            GridViewResult.DataBind();
            Panel_Result.Visible = false;
        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            EnableValidator(true);
            Page.Validate();
            Panel_Result.Visible = false;
            if (Page.IsValid)
            {
                Search();
            }
        }
        protected void btnNewCustomer_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("EditCustomerAdmin.aspx?RequestId=-4438");
        }
        private void Search()
        {
            Panel_Result.Visible = false;
            var result = ClientServiceFactory.CustomerService.SearchCustomer(txtFirstName.Text,
                txtLastName.Text,
                txtEmail.Text,
                txtPhone.Text,
                txtUserName.Text);
            if (result != null)
            {
                Panel_Result.Visible = true;
                GridViewResult.DataSource = result;
                GridViewResult.DataBind();
            }
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
        private void EnableValidator(bool flag)
        {
            CustomValidator_FirstName.Enabled = flag;
            CustomValidator_LastName.Enabled = flag;
            CustomValidator_Email.Enabled = flag;
            CustomValidator_Phone.Enabled = flag;
            CustomValidator_UserName.Enabled = flag;
            CustomValidator_RequireFileds.Enabled = flag;
        }

        #endregion IMethods
    }
}