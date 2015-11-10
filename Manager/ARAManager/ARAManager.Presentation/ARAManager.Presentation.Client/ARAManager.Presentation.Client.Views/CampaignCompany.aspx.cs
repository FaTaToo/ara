// --------------------------------------------------------------------------------------------------------------------
// <header file="CampaignCompany.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for CampaignCompany page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Linq;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class CampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            EnableValidator(false);
        }
        protected void CustomValidator_CampaignName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_CampaignName.ErrorMessage = Validation.VALIDATOR_CAMPAIGN_NAME;
            args.IsValid = m_validator.ValidateChar100(txtCampaignName.Text);
        }
        protected void CustomValidator_Company_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Company.ErrorMessage = Validation.VALIDATOR_COMPANY_NAME;
            args.IsValid = m_validator.ValidateChar100(txtCompany.Text);
        }
        protected void CustomValidator_RequireFileds_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_RequireFileds.ErrorMessage = Validation.VALIDATOR_REQUIRED_CRITERION_SEARCH;
            if (!string.IsNullOrEmpty(txtCampaignName.Text) ||
                !string.IsNullOrEmpty(txtCompany.Text))
            {
                args.IsValid = true;
            }
            else
            {
                args.IsValid = false;
            }
        }
        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            EnableValidator(true);
            Validate();
            if (Page.IsValid)
            {
                Search();
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
            var deletedCampaigns = (from GridViewRow row in GridViewResult.Rows
                                    let checkBox = row.Cells[0].FindControl("cbSelect") as CheckBox
                                    where checkBox != null && checkBox.Checked
                                    select row.Cells[1].FindControl("lblId")).OfType<Label>().
                                      Select(label => int.Parse(label.Text)).ToList();
            try
            {
                ClientServiceFactory.CampaignService.DeleteCampaigns(deletedCampaigns);
            }
            catch (FaultException ex)
            {
                lblMessage.Text = ex.Message;
            }
            Search();
        }
        protected void btnClear_OnClick(object sender, EventArgs e)
        {
            txtCampaignName.Text = string.Empty;
            txtCompany.Text = string.Empty;
            GridViewResult.DataSource = null;
            GridViewResult.DataBind();
            Panel_Result.Visible = false;
        }
        private void Search()
        {
            Panel_Result.Visible = true;
            var result = ClientServiceFactory.CampaignService.SearchCampaign(txtCampaignName.Text,
                txtCompany.Text);
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
        private void EnableValidator(bool flag)
        {
            CustomValidator_CampaignName.Enabled = flag;
            CustomValidator_Company.Enabled = flag;
            CustomValidator_RequireFileds.Enabled = flag;
        }
        #endregion IMethods
    }
}