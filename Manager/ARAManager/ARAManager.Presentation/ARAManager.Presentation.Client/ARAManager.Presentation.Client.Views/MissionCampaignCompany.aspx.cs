// --------------------------------------------------------------------------------------------------------------------
/* <header file="MissionCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for MissionCampaignCompany page.
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
using ARAManager.Common.Exception.Mission;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    /// Code-behind of MissionCampaignCompany.aspx - used to create new mission of a campaign
    /// </summary>
    public partial class MissionCampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private readonly Validation m_validator = new Validation();
        private Campaign m_camnpaign;

        #endregion IFields

        #region SFields

        private static int s_numberOfMission;

        #endregion SFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            m_camnpaign = ClientServiceFactory.CampaignService.GetCampaignById(int.Parse(Request.QueryString["RequestId"]));
            if (!Page.IsPostBack)
            {
                s_numberOfMission = m_camnpaign.Missions.Count;
            }
            EnableValidator(false);
            lblCreateMission.Text = "You have " + s_numberOfMission;
            GridView_Mission.DataSource = m_camnpaign.Missions;
            GridView_Mission.DataBind();
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
            CustomValidator_MissionName.Enabled = flag;
            CustomValidator_Description.Enabled = flag;
            CustomValidator_Avatar.Enabled = flag;
            RangeValidator_NumMission.Enabled = flag;
        }
        private void SetErrorMessages()
        {
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
            var extension = Path.GetExtension(FileUpload_Avatar.FileName);
            var fileName = txtMissionName.Text + "Avatar" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_MISSIONS_AVATAR + fileName);
            FileUpload_Avatar.SaveAs(filePath);
            var mission = new Mission()
            {
                Name = txtMissionName.Text,
                Description = txtDescription.Text,
                NumTarget = int.Parse(txtNumTarget.Text),
                Avatar = fileName,
                Campaign = m_camnpaign
            };
            try
            {
                ClientServiceFactory.MissionService.SaveNewMission(mission);
                txtMissionName.Text = string.Empty;
                txtDescription.Text = string.Empty;
                txtNumTarget.Text = string.Empty;
                lblCreateMission.Text = "You have " + ++s_numberOfMission;
                
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
        //-----------------------------------------------------------------------------------------------------
        #endregion IMethods
    }
}