﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="TargetMissionCampaignCompany.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement logic for TargetMissionCampaignCompany page.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using System.Web.UI.WebControls;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Mission;
using ARAManager.Common.Exception.Target;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;
using Subgurim.Controles;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class TargetMissionCampaignCompany : System.Web.UI.Page
    {
        #region IFields

        private double m_latitude;
        private double m_longtitude;
        private int m_missionId;
        private readonly Validation m_validator = new Validation();
        private Mission m_mission;

        #endregion IFields

        #region SFields

        private static int s_numberOfTarget;

        #endregion SFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                m_missionId = int.Parse(Request.QueryString["RequestId"]);
                m_mission = ClientServiceFactory.MissionService.GetMissionTypeById(m_missionId);
                s_numberOfTarget = m_mission.NumTarget;
            }
            EnableValidator(false);
            lblCreateMission.Text = "You have " + s_numberOfTarget + " left.";
            GridView_Target.DataSource = m_mission.Targets;
            GridView_Target.DataBind();
            InitializeDataForGMap();
        }
        protected void CustomValidator_TargetName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_TargetName.ErrorMessage = Validation.VALIDATOR_TARGET_NAME;
            args.IsValid = m_validator.ValidateChar100(txtTargetName.Text);
        }
        protected void CustomValidator_Description_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Description.ErrorMessage = Validation.VALIDATOR_DESCRIPTION;
            args.IsValid = m_validator.ValidateChar500(txtDescription.Text);
        }
        protected void CustomValidator_Video_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Facebook.ErrorMessage = Validation.VALIDATOR_VIDEO;
            args.IsValid = m_validator.ValidateChar500(txtVideoUrl.Text);
        }
        protected void CustomValidator_Facebook_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Facebook.ErrorMessage = Validation.VALIDATOR_FACEBOOK;
            args.IsValid = m_validator.ValidateChar500(txtFacebookUrl.Text);
        }
        protected void CustomValidator_Youtube_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_Youtube.ErrorMessage = Validation.VALIDATOR_YOUTUBE;
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
            CustomValidator_TargetName.Enabled = flag;
            CustomValidator_Description.Enabled = flag;
            CustomValidator_Video.Enabled = flag;
            CustomValidator_Facebook.Enabled = flag;
            CustomValidator_Youtube.Enabled = flag;
            RequiredFieldValidator_TargetName.Enabled = flag;
            RequiredFieldValidator_Description.Enabled = flag;
        }
        protected void btnCancel_OnClick(object sender, EventArgs e)
        {
            Response.Redirect("CampaignCompany.aspx");
        }
        protected void btnCreateTarget_OnClick(object sender, EventArgs e)
        {
            EnableValidator(true);
            Page.Validate();
            if (Page.IsValid)
            {
                var target = new Target()
                {
                    TargetName = txtTargetName.Text,
                    Latitude = m_latitude,
                    Longitude = m_longtitude,
                    Description = txtDescription.Text,
                    VideoUrl = txtVideoUrl.Text,
                    FacebookUrl = txtFacebookUrl.Text,
                    YoutubeUrl = txtYoutubeUrl.Text,
                    Mission = m_mission
                };
                try
                {

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
        }

        #endregion IMethods
    }
}