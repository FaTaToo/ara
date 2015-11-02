// --------------------------------------------------------------------------------------------------------------------
// <header file="MissionCampaignCompany.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for MissionCampaignCompany page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Mission;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.Aspx {
    public partial class MissionCampaignCompany : System.Web.UI.Page {
        #region IFields

        private int m_campaignId;
        private readonly Validation m_validator = new Validation();
        private Campaign m_camnpaign;

        #endregion IFields

        #region SFields

        private static int s_numberOfMission;

        #endregion SFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {
            if (!IsPostBack) {
                m_campaignId = int.Parse(Request.QueryString["RequestId"]);
                m_camnpaign = ClientServiceFactory.CampaignService.GetCampaignById(m_campaignId);
                s_numberOfMission = m_camnpaign.NumMission;
            }
            EnableValidator(false);
            lblCreateMission.Text = "You have " + s_numberOfMission + " left.";
            GridView_Mission.DataSource = s_numberOfMission;
            GridView_Mission.DataBind();
        }

        protected void CustomValidator_MissionName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_MissionName.ErrorMessage = Validation.VALIDATOR_MISSION_NAME;
            args.IsValid = m_validator.ValidateChar100(txtMissionName.Text);
        }

        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args) {
            CustomValidator_MissionName.ErrorMessage = Validation.VALIDATOR_DESCRIPTION;
            args.IsValid = m_validator.ValidateChar500(txtDescription.Text);
        }

        protected void CustomValidator_Avatar_OnServerValidate(object source, ServerValidateEventArgs args)  {

            args.IsValid = FileUpload_Avatar.HasFile;
        }

        #endregion IMethods

        protected void btnSave_OnClick(object sender, EventArgs e) {
            EnableValidator(true);
            Page.Validate();
        }

        protected void btnCancel_OnClick(object sender, EventArgs e) {
            Response.Redirect("CampaignCompany.aspx");
        }

        protected void btnCreateTarget_OnClick(object sender, EventArgs e) {
            EnableValidator(true);
            Page.Validate();
            if (Page.IsValid) {
                var avatar = FileUpload_Avatar.FileBytes;

                var mission = new Mission() {
                    Name = txtMissionName.Text,
                    Description = txtDescription.Text,
                    NumTarget = int.Parse(txtNumTarget.Text),
                    Avatar = avatar,
                    Campaign = m_camnpaign
                };
                try {
                    ClientServiceFactory.MissionService.SaveNewMission(mission);
                    s_numberOfMission--;
                    if (s_numberOfMission > 0) {
                        Response.Redirect("MissionCampaignCompany.aspx");
                    }
                } catch (FaultException<MissionNameAlreadyExistException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                } catch (FaultException<CampaignAlreadyDeletedException> ex) {
                    lblMessage.Text = ex.Detail.MessageError;
                }
            }
        }

        private void EnableValidator(bool flag) {
            CustomValidator_MissionName.Enabled = flag;
            CustomValidator_Description.Enabled = flag;
            CustomValidator_MissionName.Enabled = flag;
            CustomValidator_Description.Enabled = flag;
            CustomValidator_Avatar.Enabled = flag;
            RequiredFieldValidator_MissionName.Enabled = flag;
            RequiredFieldValidator_Description.Enabled = flag;
            RequiredFieldValidator_txtNumTarget.Enabled = flag;
        }
    }
}