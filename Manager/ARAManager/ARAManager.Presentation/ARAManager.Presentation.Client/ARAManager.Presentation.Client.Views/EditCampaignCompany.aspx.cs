// --------------------------------------------------------------------------------------------------------------------
/* <header file="EditCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for EditCampaignCompany page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Company;
using ARAManager.Common.Exception.Generic;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    /// Code-behind of EditCampaignCompany.aspx - used to create new campaign of a company
    /// </summary>
    public partial class EditCampaignCompany : System.Web.UI.Page
    {
        #region SFields

        private static byte[] s_rowVersion; 

        #endregion SFields

        #region IFields

        private readonly Validation m_validator = new Validation();
        private Company m_company;
        private Campaign m_campaign;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            SetErrorMessages();
            EnableValidator(false);
            var user = Page.User.Identity.Name;
            if (user != Dictionary.ADMIN_USERNAME)
            {
                try
                {
                    if (Request.QueryString["Method"] == "Edit")
                    {
                        m_company = ClientServiceFactory.CompanyService.GetCompanyByUserName(user);
                        m_campaign = ClientServiceFactory.CampaignService.GetCampaignById
                                                        (int.Parse(Request.QueryString["RequestId"]));
                        if (m_company != null)
                        {
                            txtCampaignName.Text = m_campaign.CampaignName;
                            txtDescription.Text = m_campaign.Description;
                            txtStartTime.Text = m_campaign.StartTime.Date.ToString(Dictionary.DATE_FORMAT);
                            if (m_campaign.EndTime != null)
                            {
                                var endDate = (DateTime) m_campaign.EndTime;
                                txtEndTime.Text = endDate.Date.ToString(Dictionary.DATE_FORMAT);
                            }
                            txtGift.Text = m_campaign.Gift;
                            txtMission.Text = m_campaign.NumMission.ToString();
                            s_rowVersion = m_campaign.RowVersion;
                        }
                        else
                        {
                            lblMessage.Text = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG;
                        }
                    }
                    else
                    {
                        m_company = ClientServiceFactory.CompanyService.GetCompanyByUserName(user);
                    }
                   
                }
                catch (FaultException<CompanyAlreadyDeletedException> ex)
                {
                    lblMessage.Text = ex.Message;
                }
            }
            else
            {
                Response.Redirect("HomeAdmin.aspx");
            }
        }

        // Validators
        protected void CustomValidator_CampaignName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtCampaignName.Text);
        }
        protected void CustomValidator_EndTime_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            if (string.IsNullOrEmpty(txtEndTime.Text)) return;
            args.IsValid = DateTime.ParseExact(txtEndTime.Text, Dictionary.DATE_FORMAT, null).
                CompareTo(DateTime.ParseExact(txtStartTime.Text, Dictionary.DATE_FORMAT, null)) > 0;
        }
        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtDescription.Text);
        }
        protected void CustomValidator_Gift_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtGift.Text);
        }
        protected void CustomValidator_Avatar_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = FileUpload_Avatar.HasFile;
        }
        //-----------------------------------------------------------------------------------------------------

        // Supported methods
        private void SetErrorMessages()
        {
            CustomValidator_CampaignName.ErrorMessage = Validation.VALIDATOR_CAMPAIGN_NAME;
            CustomValidator_EndTime.ErrorMessage = Validation.VALIDATOR_ENDTIME;
            CustomValidator_Description.ErrorMessage = Validation.VALIDATOR_DESCRIPTION;
            CustomValidator_Gift.ErrorMessage = Validation.VALIDATOR_GIFT;
            CustomValidator_Avatar.ErrorMessage = Validation.VALIDATOR_AVATAR;
            RangeValidator_NumMission.ErrorMessage = Validation.VALIDATOR_NUM_MISSION;
            RequiredFieldValidator_CampaignName.ErrorMessage = Validation.REQUIRE_CAMPAIGNCOMPANY_NAME;
            RequiredFieldValidator_StartTime.ErrorMessage = Validation.REQUIRE_CAMPAIGNCOMPANY_STARTTIME;
            RequiredFieldValidator_Description.ErrorMessage = Validation.REQUIRE_CAMPAIGNCOMPANY_DESCRIPTION;
            RequiredFieldValidator_Gift.ErrorMessage = Validation.REQUIRE_CAMPAIGNCOMPANY_GIFT;
            RequiredFieldValidator_NumMission.ErrorMessage = Validation.REQUIRE_CAMPAIGNCOMPANY_NUM_MISSION;
        }
        private void EnableValidator(bool flag)
        {
            CustomValidator_CampaignName.Enabled = flag;
            CustomValidator_EndTime.Enabled = flag;
            CustomValidator_Gift.Enabled = flag;
            RangeValidator_NumMission.Enabled = flag;
            RequiredFieldValidator_CampaignName.Enabled = flag;
            RequiredFieldValidator_StartTime.Enabled = flag;
            RequiredFieldValidator_Description.Enabled = flag;
            RequiredFieldValidator_Gift.Enabled = flag;
            RequiredFieldValidator_Description.Enabled = flag;
            RequiredFieldValidator_NumMission.Enabled = flag;
        }
        private void RedirectToCampaignCompany()
        {
            Response.Redirect("CampaignCompany.aspx");
        }
        private Campaign SaveNewCampaignWithEndTime()
        {
            var campaign = new Campaign
            {
                CampaignName = txtCampaignName.Text,
                StartTime = DateTime.ParseExact(txtStartTime.Text, Dictionary.DATE_FORMAT, null),
                Description = txtDescription.Text,
                Banner = UploadImageBanner(),
                Avatar = UploadImageAvatar(),
                Gift = txtGift.Text,
                NumMission = int.Parse(txtMission.Text),
                Company = m_company
            };
            MoveBackRowVersion(campaign);
            return campaign;
        }
        private Campaign SaveNewCampaignWithoutEndTime()
        {
            var campaign = new Campaign
            {
                CampaignName = txtCampaignName.Text,
                StartTime = DateTime.ParseExact(txtStartTime.Text, Dictionary.DATE_FORMAT, null),
                EndTime = DateTime.ParseExact(txtEndTime.Text, Dictionary.DATE_FORMAT, null),
                Description = txtDescription.Text,
                Banner = UploadImageBanner(),
                Avatar = UploadImageAvatar(),
                Gift = txtGift.Text,
                NumMission = int.Parse(txtMission.Text),
                Company = m_company
            };
            MoveBackRowVersion(campaign);
            return campaign;
        }
        private static void MoveBackRowVersion(Campaign campaign)
        {
            if (s_rowVersion != null)
            {
                campaign.RowVersion = s_rowVersion;
            }
        }
        private string UploadImageBanner()
        {
            /* Modified by PhucLS - 20151115 - Change to accept new database with image urL, not byte[]
             * Notes: _ Have not fixed case "If the uploaded file is not image type"
             *        _ Check image resolution later
             *        _ Validator if there is no file
            */
            var extension = Path.GetExtension(FileUpload_Banner.FileName);
            var fileName = txtCampaignName.Text + "Banner" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_CAMPAIGNS_BANNER + fileName);
            FileUpload_Banner.SaveAs(filePath);
            return fileName;
            // Ended by PhucLS
        }
        private string UploadImageAvatar()
        {
            var extension = Path.GetExtension(FileUpload_Avatar.FileName);
            var fileName = txtCampaignName.Text + "Avatar" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_CAMPAIGNS_AVATAR + fileName);
            FileUpload_Avatar.SaveAs(filePath);
            return fileName;
        }
        //-----------------------------------------------------------------------------------------------------

        // Events
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            EnableValidator(true);
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            var campaign = string.IsNullOrEmpty(txtEndTime.Text)
                ? SaveNewCampaignWithEndTime()
                : SaveNewCampaignWithoutEndTime();
            try
            {
                ClientServiceFactory.CampaignService.SaveNewCampaign(campaign);
                Response.Redirect("MissionCampaignCompany.aspx?RequestId=" +
                                  ClientServiceFactory.CampaignService.GetCampaignByName(txtCampaignName.Text).CampaignId);
            }
            catch (FaultException<CampaignNameAlreadyExistException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
            catch (FaultException<ConcurrentUpdateException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
            catch (FaultException<Exception> ex)
            {
                lblMessage.Text = ex.Detail.Message;
            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            RedirectToCampaignCompany();
        }
        protected void btnCreateMission_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("MissionCampaignCompany.aspx?Method=New&RequestId=" + m_company.CompanyId);
        }
        //-----------------------------------------------------------------------------------------------------
        #endregion IMethods
    }
}