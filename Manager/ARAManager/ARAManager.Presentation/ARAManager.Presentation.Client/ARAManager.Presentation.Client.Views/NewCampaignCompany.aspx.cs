﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="NewCampaignCompany.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for NewCampaignCompany page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Company;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class NewCampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private readonly Validation m_validator = new Validation();
        private Company m_company;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            SetErrorMessages();
            EnableValidator(false);
            string user = Page.User.Identity.Name;
            if (user != Dictionary.ADMIN_USERNAME)
            {
                try
                {
                    m_company = ClientServiceFactory.CompanyService.GetCompanyByUserName(user);
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
        //-----------------------------------------------------------------------------------------------------

        // Supported methods
        private void SetErrorMessages()
        {
            CustomValidator_CampaignName.ErrorMessage = Validation.VALIDATOR_CAMPAIGN_NAME;
            CustomValidator_EndTime.ErrorMessage = Validation.VALIDATOR_ENDTIME;
            CustomValidator_Description.ErrorMessage = Validation.VALIDATOR_DESCRIPTION;
            CustomValidator_Gift.ErrorMessage = Validation.VALIDATOR_GIFT;
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
                Company= m_company
            };
            return campaign;
        }
        private string UploadImageBanner()
        {
            /* Modified by PhucLS - 20151114 - Change to accept new database with image urL, not byte[]
             * Notes: Have not fixed case "If the uploaded file is not image type"
            */
            string extension= Path.GetExtension(FileUpload_Banner.FileName);
            string filePath = Dictionary.PATH_UPLOADED_CAMPAIGNS_BANNER + txtCampaignName.Text + "Banner" + extension;
            FileUpload_Banner.SaveAs(filePath);
            return filePath;
            // Ended by PhucLS
        }
        private string UploadImageAvatar()
        {
            /* Modified by PhucLS - 20151114 - Change to accept new database with image urL, not byte[]
             * Notes: Have not fixed case "If the uploaded file is not image type"
            */
            string extension = Path.GetExtension(FileUpload_Banner.FileName);
            string filePath = Dictionary.PATH_UPLOADED_CAMPAIGNS_AVATAR + txtCampaignName.Text + "Avatar" + extension;
            FileUpload_Banner.SaveAs(filePath);
            return filePath;
            // Ended by PhucLS
        }
        //-----------------------------------------------------------------------------------------------------

        // Events
        protected void btnSave_OnClick(object sender, EventArgs e)
        {
            EnableValidator(true);
            Page.Validate();
            var campaign = string.IsNullOrEmpty(txtEndTime.Text) ?
                SaveNewCampaignWithEndTime() : SaveNewCampaignWithoutEndTime();
            try
            {
                ClientServiceFactory.CampaignService.SaveNewCampaign(campaign);
                Response.Redirect("MissionCampaignCompany.aspx?RequestId="+
                    ClientServiceFactory.CampaignService.GetCampaignByName(txtCampaignName.Text).CampaignName);
            }
            catch (FaultException<CampaignNameAlreadyExistException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
            catch (FaultException<CampaignAlreadyDeletedException> ex)
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
        //-----------------------------------------------------------------------------------------------------
        #endregion IMethods
    }
}