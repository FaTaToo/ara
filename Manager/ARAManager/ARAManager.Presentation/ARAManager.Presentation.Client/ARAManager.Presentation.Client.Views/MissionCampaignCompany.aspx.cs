// --------------------------------------------------------------------------------------------------------------------
/* <header file="MissionCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for MissionCampaignCompany page.
 * </summary>
 * <Problems>
 *      1. 
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.ServiceModel;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Mission;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    ///     Code-behind of MissionCampaignCompany.aspx - used to create new mission of a campaign
    /// </summary>
    public partial class MissionCampaignCompany : Page
    {
        #region SFields

        private static byte[] s_rowVersion;

        #endregion SFields

        #region SFields

        private static int s_numberOfMission;

        #endregion SFields

        #region IFields

        private readonly Validation m_validator = new Validation();
        private Campaign m_campaign;
        private Mission m_mission;

        #endregion IFields

        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
            m_campaign =
                ClientServiceFactory.CampaignService.GetCampaignById(int.Parse(Request.QueryString["RequestId"]));
            if (!Page.IsPostBack)
            {
                s_numberOfMission = m_campaign.Missions.Count;
            }
            EnableValidator(false);
            lblCreateMission.Text = "You have " + s_numberOfMission + " missions";
            GridView_Mission.DataSource = m_campaign.Missions;
            GridView_Mission.DataBind();

            if ((Request.QueryString["Method"]) != "Edit")
            {
                m_mission = new Mission();
                return;
            }
            txtMissionName.Enabled = false;
            m_mission = ClientServiceFactory.MissionService.GetMissionById(int.Parse(Request.QueryString["MissionId"]));
            txtMissionName.Text = m_mission.Name;
            txtDescription.Text = m_mission.Description;
            txtNumTarget.Text = m_mission.NumTarget.ToString();
            s_rowVersion = m_mission.RowVersion;
        }

        // Validators
        protected void CustomValidator_MissionName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtMissionName.Text);
        }

        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtDescription.Text);
        }

        protected void CustomValidator_Avatar_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = FileUpload_Avatar.HasFile;
        }

        //-----------------------------------------------------------------------------------------------------

        // Supported methods
        private void EnableValidator(bool flag)
        {
            RequiredFieldValidator_MissionName.Enabled = flag;
            RequiredFieldValidator_Description.Enabled = flag;
            RequiredFieldValidator_NumTarget.Enabled = flag;
            CustomValidator_MissionName.Enabled = flag;
            CustomValidator_Description.Enabled = flag;
            CustomValidator_Avatar.Enabled = flag;
            RangeValidator_NumMission.Enabled = flag;
        }

        private void SetErrorMessages()
        {
            RequiredFieldValidator_MissionName.ErrorMessage = Validation.REQUIRE_MISSIONCAMPAIGNCOMPANY_NAME;
            RequiredFieldValidator_Description.ErrorMessage = Validation.REQUIRE_MISSIONCAMPAIGNCOMPANY_DESCRIPTION;
            RequiredFieldValidator_NumTarget.ErrorMessage = Validation.REQUIRE_MISSIONCAMPAIGNCOMPANY_NUM_TARGET;
            CustomValidator_MissionName.ErrorMessage = Validation.VALIDATOR_MISSION_NAME;
            CustomValidator_Description.ErrorMessage = Validation.VALIDATOR_DESCRIPTION;
            CustomValidator_Avatar.ErrorMessage = Validation.VALIDATOR_AVATAR;
            RangeValidator_NumMission.ErrorMessage = Validation.VALIDATOR_NUM_MISSION;
        }

        protected string GetAvatar(object eval)
        {
            return Dictionary.PATH_UPLOADED_MISSIONS_AVATAR + eval;
        }

        //-----------------------------------------------------------------------------------------------------

        // Events
        protected void btnCreateMission_OnClick(object sender, EventArgs e)
        {
            SetErrorMessages();
            EnableValidator(true);
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            if (s_numberOfMission == m_campaign.NumMission)
            {
                lblMessage.Text = Dictionary.EXCEED_NUMBER_OF_MISSION;
                return;
            }
            var extension = Path.GetExtension(FileUpload_Avatar.FileName);
            var fileName = txtMissionName.Text + "Avatar" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_MISSIONS_AVATAR + fileName);
            FileUpload_Avatar.SaveAs(filePath);
            m_mission.Name = txtMissionName.Text;
            m_mission.Description = txtDescription.Text;
            m_mission.NumTarget = int.Parse(txtNumTarget.Text);
            m_mission.Avatar = Dictionary.PATH_UPLOADED_MISSIONS_AVATAR + fileName;
            m_mission.Campaign = m_campaign;
            m_mission.RowVersion = s_rowVersion;
            try
            {
                ClientServiceFactory.MissionService.SaveNewMission(m_mission);
                Response.Redirect("MissionCampaignCompany.aspx?Method=New&RequestId=" + m_campaign.CampaignId);
            }
            catch (FaultException<MissionNameAlreadyExistException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
            catch (FaultException<CampaignAlreadyDeletedException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
        }

        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CampaignCompany.aspx");
        }

        protected string GetNavigateUrl(object eval)
        {
            return "TargetMissionCampaignCompany.aspx?RequestId=" + eval;
        }

        protected string GetEditMissionUrl(object eval)
        {
            return "MissionCampaignCompany.aspx?Method=Edit&RequestId=" + m_campaign.CampaignId + "&MissionId=" + eval;
        }

        //-----------------------------------------------------------------------------------------------------

        #endregion IMethods
    }
}