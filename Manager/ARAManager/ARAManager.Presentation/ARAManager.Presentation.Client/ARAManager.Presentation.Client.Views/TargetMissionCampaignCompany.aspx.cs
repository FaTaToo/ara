﻿// --------------------------------------------------------------------------------------------------------------------
/* <header file="TargetMissionCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for TargetMissionCampaignCompany page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Mission;
using ARAManager.Common.Exception.Target;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;
using Subgurim.Controles;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    /// Code-behind of TargetMissionCampaignCompany.aspx - used to create new target of a mission
    /// </summary>
    public partial class TargetMissionCampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private double m_latitude;
        private double m_longtitude;
        private readonly Validation m_validator = new Validation();
        private Mission m_mission;

        #endregion IFields

        #region SFields

        private static int s_numberOfTarget;

        #endregion SFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            m_mission = ClientServiceFactory.MissionService.GetMissionById(int.Parse(Request.QueryString["RequestId"]));
            if (!IsPostBack)
            {
                s_numberOfTarget = m_mission.NumTarget;
            }
            EnableValidator(false);
            lblCreateTarget.Text = "You have " + s_numberOfTarget + " target(s)";
            InitializeDataForGMap();
        }
        protected void CustomValidator_TargetName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar100(txtTargetName.Text);
        }
        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtDescription.Text);
        }
        protected void CustomValidator_Facebook_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtFacebookUrl.Text);
        }
        protected void CustomValidator_Youtube_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            args.IsValid = m_validator.ValidateChar500(txtYoutubeUrl.Text);
        }
        protected string GMAP_Target_OnClick(object s, GAjaxServerEventArgs e)
        {
            var marker = new GMarker(e.point);
            var window = new GInfoWindow(marker,
                                                 string.Format(
                                                     @"<b>GLatLngBounds</b><br />SW = {0}<br/>NE = {1}",
                                                     e.bounds.getSouthWest(),
                                                     e.bounds.getNorthEast()),
                                        true);
            return window.ToString(e.map);
        }
        protected string GMAP_Target_OnMarkerClick(object s, GAjaxServerEventArgs e)
        {
            m_latitude = e.point.lat;
            m_longtitude = e.point.lng;
            return string.Format("alert('MarkerClick: {0} - {2} - {1}')", e.point, DateTime.Now, e.map);
        }
        private void InitializeDataForGMap()
        {
            GMAP_Target.Add(new GControl(GControl.preBuilt.GOverviewMapControl));
            GMAP_Target.Add(new GControl(GControl.preBuilt.LargeMapControl));
            GMarker marker = new GMarker(new GLatLng(5, 5));
            GInfoWindow window = new GInfoWindow(marker, "<center><b>Target location</b></center>", true);
            GMAP_Target.Add(window);

        }
        private void EnableValidator(bool flag)
        {
            RequiredFieldValidator_TargetName.Enabled = flag;
            RequiredFieldValidator_Facebook.Enabled = flag;
            RequiredFieldValidator_Youtube.Enabled = flag;
            CustomValidator_TargetName.Enabled = flag;
            CustomValidator_Facebook.Enabled = flag;
            CustomValidator_Youtube.Enabled = flag;
            RequiredFieldValidator_TargetName.Enabled = flag;
        }

        private void SetErrorMessages()
        {
            RequiredFieldValidator_TargetName.ErrorMessage = Validation.REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_NAME;
            RequiredFieldValidator_Facebook.ErrorMessage = Validation.REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_FACEBOOK;
            RequiredFieldValidator_Youtube.ErrorMessage = Validation.REQUIRE_TARGETMISSIONCAMPAIGNCOMPANY_YOUTUBE;
            CustomValidator_TargetName.ErrorMessage = Validation.VALIDATOR_TARGET_NAME;
            CustomValidator_Facebook.ErrorMessage = Validation.VALIDATOR_VIDEO;
            CustomValidator_Facebook.ErrorMessage = Validation.VALIDATOR_FACEBOOK;
            CustomValidator_Youtube.ErrorMessage = Validation.VALIDATOR_YOUTUBE;
        }
        protected void btnCreateTarget_OnClick(object sender, EventArgs e)
        {
            SetErrorMessages();
            EnableValidator(true);
            Page.Validate();
            if (!Page.IsValid)
            {
                return;
            }
            // Modifed by PhucLS - 20151121 - Save target id to txt file
            // Save image target to server
            var extension = Path.GetExtension(FileUpload_Target.FileName);
            var fileName = txtTargetName.Text + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_TARGET + fileName);
            FileUpload_Target.SaveAs(filePath);

            // Call VWS
            var callPostNewTarget = new WebClient();
            var result = callPostNewTarget.DownloadString(new Uri(
                "http://localhost:1234/ara-vws/vws/SampleSelector.php?select=PostNewTarget&targetName="+txtTargetName.Text+
                "&imageLocation=" + fileName));

            // Filter target id
            var targetId=string.Empty;
            var resultCodeIndex = result.IndexOf(@"""TargetCreated""", StringComparison.Ordinal);
            if (resultCodeIndex > 0)
            {
                var resultTargetId = result.IndexOf(@"""target_id""", StringComparison.Ordinal);
                var startIndex = result.IndexOf("\"", resultTargetId+12, StringComparison.Ordinal) + 1;
                var endIndex = result.IndexOf("\"", startIndex, StringComparison.Ordinal)- 1;
                targetId = result.Substring(startIndex, endIndex - startIndex + 1);
            }
            if (!File.Exists(Dictionary.PATH_LIST_TARGET))
            {
                using (StreamWriter sw = File.CreateText(Dictionary.PATH_LIST_TARGET))
                {
                    sw.WriteLine(targetId);
                }
            }
            else
            {
                using (StreamWriter sw = new StreamWriter(Dictionary.PATH_LIST_TARGET))
                {
                    sw.WriteLine(targetId);
                }
            }
            // Ended by PhucLS - 20151121

            // Save target to database
            var target = new Target()
            {
                TargetName = txtTargetName.Text,
                Url = targetId,
                Latitude = m_latitude,
                Longitude = m_longtitude,
                FacebookUrl = txtFacebookUrl.Text,
                YoutubeUrl = txtYoutubeUrl.Text,
                Mission = m_mission
            };
            try
            {
                ClientServiceFactory.TargetService.SaveNewTarget(target);
                txtTargetName.Text = string.Empty;
                txtFacebookUrl.Text = string.Empty;
                txtYoutubeUrl.Text = string.Empty;
                lblCreateTarget.Text = "You have " + ++s_numberOfTarget + " target(s)";
            }
            catch (FaultException<TargetNameAlreadyExistException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
            catch (FaultException<MissionAlreadyDeletedException> ex)
            {
                lblMessage.Text = ex.Detail.MessageError;
            }
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CampaignCompany.aspx");
        }
        // Added by PhucLS - 20151121 - Will be changed later
        protected void btnBack_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CampaignCompany.aspx");
        }
        // Ended by PhucLS - 20151121
        #endregion IMethods

      
    }
}