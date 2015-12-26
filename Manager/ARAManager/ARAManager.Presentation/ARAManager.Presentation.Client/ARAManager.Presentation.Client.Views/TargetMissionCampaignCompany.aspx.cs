// --------------------------------------------------------------------------------------------------------------------
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
using System.Collections.Generic;
using System.IO;
using System.Net;
using System.ServiceModel;
using System.Web.Hosting;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Mission;
using ARAManager.Common.Exception.Target;
using ARAManager.Common.PresenterJson.ArResources;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;
using Newtonsoft.Json;
using Subgurim.Controles;
using Attribute = ARAManager.Common.PresenterJson.ArResources.Attribute;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    ///     Code-behind of TargetMissionCampaignCompany.aspx - used to create new target of a mission
    /// </summary>
    public partial class TargetMissionCampaignCompany : Page
    {
        #region IFields

        private double m_latitude;
        private double m_longtitude;
        private readonly Validation m_validator = new Validation();
        private Mission m_mission;

        #endregion IFields

        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
            m_mission = ClientServiceFactory.MissionService.GetMissionById(int.Parse(Request.QueryString["RequestId"]));
            EnableValidator(false);
            InitializeDataForGMap();
            if (Request.QueryString["Type"] == Dictionary.CAMPAIGN_TYPE_CHECK_IN_URL)
            {
                txtDirector.Enabled = false;
                txtActor.Enabled = false;
            }
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
            var marker = new GMarker(new GLatLng(10, 106));
            var window = new GInfoWindow(marker, "<center><b>Target location</b></center>", true);
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
            try
            {
                // Save image target to server - just help debugging, it does not affect system.
                var extension = Path.GetExtension(FileUpload_Target.FileName);
                var fileName = txtTargetName.Text + extension;
                var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_TARGET + fileName);
                FileUpload_Target.SaveAs(filePath);

                // Call VWS
                var callPostNewTarget = new WebClient();
                var result = callPostNewTarget.DownloadString(new Uri(
                    "http://localhost:1234/ara-vws/vws/SampleSelector.php?select=PostNewTarget&targetName=" +
                    txtTargetName.Text +
                    "&imageLocation=" + fileName));

                // Filter target id
                var targetId = string.Empty;
                var resultCodeIndex = result.IndexOf(@"""TargetCreated""", StringComparison.Ordinal);
                if (resultCodeIndex > 0)
                {
                    var resultTargetId = result.IndexOf(@"""target_id""", StringComparison.Ordinal);
                    var startIndex = result.IndexOf("\"", resultTargetId + 12, StringComparison.Ordinal) + 1;
                    var endIndex = result.IndexOf("\"", startIndex, StringComparison.Ordinal) - 1;
                    targetId = result.Substring(startIndex, endIndex - startIndex + 1);
                }

                // Save target id to ListTarget.txt
                if (!File.Exists(Server.MapPath(Dictionary.PATH_LIST_TARGET)))
                {
                    using (var sw = File.CreateText(Server.MapPath(Dictionary.PATH_LIST_TARGET)))
                    {
                        sw.WriteLine(targetId);
                    }
                }
                else
                {
                    using (var sw = new StreamWriter(Server.MapPath(Dictionary.PATH_LIST_TARGET), true))
                    {
                        sw.WriteLine(targetId);
                    }
                }

                /* Get latitude and longtitude from textbox
                 * Issues:
                 *      _ I haven't not validate the case which string is not float format because of time
                 *      => will be fixed using tryparse
                 */
                if (txtLat.Text != string.Empty && txtLong.Text != string.Empty)
                {
                    m_latitude = double.Parse(txtLat.Text);
                    m_longtitude = double.Parse(txtLong.Text);
                }

                // Save target to database
                var target = new Target
                {
                    Url = targetId,
                    TargetName = txtTargetName.Text,
                    Address = txtAddress.Text,
                    Latitude = m_latitude,
                    Longitude = m_longtitude,
                    FacebookUrl = txtFacebookUrl.Text,
                    YoutubeUrl = txtYoutubeUrl.Text,
                    Mission = m_mission
                };
                // Notes: Will be migrated into helper file

                // Create ArResources
                var arResources = new ArResources();

                // Create ARSM-PicturesGallery
                var commonAttributes = new CommonAttributes();
                var platforms = new Platforms();
                var platform = new Platform();
                var processors = new Processors();

                var uploadedPicturesGallery = FileUpload_PicturesGallery.PostedFiles;

                if (FileUpload_PicturesGallery.HasFiles)
                {
                    // Create Attribute in CommonAttributes
                    foreach (var uploadedPicture in uploadedPicturesGallery)
                    {
                        fileName = "Ar" + uploadedPicture.FileName;
                        filePath = Server.MapPath(Dictionary.PATH_UPLOADED_TARGET + fileName);
                        FileUpload_Target.SaveAs(filePath);

                        var attribute = new Attribute
                        {
                            Key = Dictionary.AR_KEY_URL,
                            Value = filePath
                        };
                        commonAttributes.Attribute = new List<Attribute> {attribute};
                    }
                    // Create Platform with Processor in Platforms
                    platform.PlatformId = Dictionary.AR_PLATFORM_ID_ANDROID;
                    processors.Processor = new Processor {ProcessorType = Dictionary.AR_PROCESSOR_TYPE_IMAGE_SWITCHER};
                    platforms.Platform = platform;
                    // Add ArResource to ArResources
                    arResources.ArResource = new List<ArResource>
                    {
                        new ArResource
                        {
                            CommonAttributes = commonAttributes,
                            ArType = Dictionary.ARSM_PICTURES_GALLERY,
                            Platforms = platforms
                        }
                    };
                }

                // Create ARSM-Youtube
                commonAttributes = new CommonAttributes();
                platforms = new Platforms();
                platform = new Platform();
                processors = new Processors();
                // Create Attribute in CommonAttributes
                commonAttributes.Attribute = new List<Attribute>
                {
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_URL,
                        Value = txtYoutubeUrl.Text
                    }
                };

                // Create Platform with Processor in Platforms
                platform.PlatformId = Dictionary.AR_PLATFORM_ID_ANDROID;
                processors.Processor = new Processor {ProcessorType = Dictionary.AR_PROCESSOR_TYPE_YOUTUBE};
                platforms.Platform = platform;

                // Add ArResource to ArResources
                arResources.ArResource.Add(new ArResource
                {
                    CommonAttributes = commonAttributes,
                    ArType = Dictionary.ARSM_YOUTUBE,
                    Platforms = platforms
                });

                // Create ARSM-Facebook
                commonAttributes = new CommonAttributes();
                platforms = new Platforms();
                platform = new Platform();
                processors = new Processors();

                // Create Attribute in CommonAttributes
                commonAttributes.Attribute = new List<Attribute>
                {
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_URL,
                        Value = txtFacebookUrl.Text
                    }
                };

                // Create Platform with Processor in Platforms
                platform.PlatformId = Dictionary.AR_PLATFORM_ID_ANDROID;
                processors.Processor = new Processor {ProcessorType = Dictionary.AR_PROCESSOR_TYPE_FACEBOOK};
                platforms.Platform = platform;

                // Add ArResource to ArResources
                arResources.ArResource.Add(new ArResource
                {
                    CommonAttributes = commonAttributes,
                    ArType = Dictionary.ARSM_FACEBOOK,
                    Platforms = platforms
                });

                // Create ARSM-Text
                commonAttributes = new CommonAttributes();
                platforms = new Platforms();
                platform = new Platform();
                processors = new Processors();

                // Create Attribute in CommonAttributes
                commonAttributes.Attribute = new List<Attribute>
                {
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_NAME,
                        Value = txtArName.Text
                    },
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_DIRECTOR,
                        Value = txtDirector.Text
                    },
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_ACTOR,
                        Value = txtActor.Text
                    },
                    new Attribute
                    {
                        Key = Dictionary.AR_KEY_DESCRIPTION,
                        Value = txtDescription.Text
                    }
                };

                // Create Platform with Processor in Platforms
                platform.PlatformId = Dictionary.AR_PLATFORM_ID_ANDROID;
                processors.Processor = new Processor {ProcessorType = Dictionary.AR_PROCESSOR_TYPE_TEXTVIEW};
                platforms.Platform = platform;

                // Add ArResource to ArResources
                arResources.ArResource.Add(new ArResource
                {
                    CommonAttributes = commonAttributes,
                    ArType = Dictionary.ARSM_TEXT,
                    Platforms = platforms
                });
                var rootObject = new RootObject {ArResources = arResources};

                // Save new target
                ClientServiceFactory.TargetService.SaveNewTarget(target);

                // Save JSON to server
                var arResourcesJson = JsonConvert.SerializeObject(rootObject);
                var jsonPath = Dictionary.PATH_AR_JSON + target.Url + ".json";
                File.Create(HostingEnvironment.MapPath(jsonPath)).Dispose();
                // ReSharper disable once AssignNullToNotNullAttribute - Added by PhucLS
                File.WriteAllText(HostingEnvironment.MapPath(jsonPath), arResourcesJson);

                Response.Redirect(@"~\ARAManager.Presentation.Client.Views\CampaignCompany.aspx");
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

        #endregion IMethods
    }
}