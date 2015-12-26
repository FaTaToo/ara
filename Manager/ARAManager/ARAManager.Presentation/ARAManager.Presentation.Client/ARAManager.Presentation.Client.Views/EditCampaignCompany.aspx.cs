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
using System.Net;
using System.ServiceModel;
using System.Text;
using System.Web.UI;
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
    ///     Code-behind of EditCampaignCompany.aspx - used to create new campaign of a company
    /// </summary>
    public partial class EditCampaignCompany : Page
    {
        #region SFields

        private static byte[] s_rowVersion;

        #endregion SFields

        #region IFields

        private readonly Validation m_validator = new Validation();
        private Company m_company;
        private Campaign m_campaign;
        private string m_campaignTypeName;
        private CampaignType m_campaignType;

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
                            m_campaignTypeName = m_campaign.CampaignTypeId.CampaignTypeName;
                        }
                        else
                        {
                            lblMessage.Text = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG;
                        }
                    }
                    else
                    {
                        m_company = ClientServiceFactory.CompanyService.GetCompanyByUserName(user);
                        m_campaign = new Campaign();
                        m_campaignTypeName = Request.QueryString["Type"];
                        SetCampaignType();
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

        private void SaveNewCampaignWithoutEndTime()
        {
            m_campaign.CampaignName = txtCampaignName.Text;
            m_campaign.StartTime = DateTime.ParseExact(txtStartTime.Text, Dictionary.DATE_FORMAT, null);
            m_campaign.Description = txtDescription.Text;
            m_campaign.Banner = UploadImageBanner();
            m_campaign.Avatar = UploadImageAvatar();
            m_campaign.Gift = txtGift.Text;
            m_campaign.NumMission = int.Parse(txtMission.Text);
            m_campaign.Company = m_company;
            m_campaign.CampaignTypeId = m_campaignType;
            MoveBackRowVersion(m_campaign);
        }

        private void SaveNewCampaignWithEndTime()
        {
            SaveNewCampaignWithoutEndTime();
            m_campaign.EndTime = DateTime.ParseExact(txtEndTime.Text, Dictionary.DATE_FORMAT, null);
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
            var extension = Path.GetExtension(FileUpload_Banner.FileName);
            var fileName = txtCampaignName.Text + "Banner" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_CAMPAIGNS_BANNER + fileName);
            FileUpload_Banner.SaveAs(filePath);
            UploadFileToFtpServer(fileName, Dictionary.PATH_UPLOADED_CAMPAIGNS_BANNER + fileName, false);
            return Dictionary.PATH_UPLOADED_CAMPAIGNS_BANNER + fileName;
        }

        private string UploadImageAvatar()
        {
            var extension = Path.GetExtension(FileUpload_Avatar.FileName);
            var fileName = txtCampaignName.Text + "Avatar" + extension;
            var filePath = Server.MapPath(Dictionary.PATH_UPLOADED_CAMPAIGNS_AVATAR + fileName);
            FileUpload_Avatar.SaveAs(filePath);
            UploadFileToFtpServer(fileName, Dictionary.PATH_UPLOADED_CAMPAIGNS_AVATAR + fileName, true);
            return Dictionary.PATH_UPLOADED_CAMPAIGNS_AVATAR + fileName;
        }

        private void SetCampaignType()
        {
            m_campaignType = ClientServiceFactory.CampaignTypeService.GetCampaignTypeByName(m_campaignTypeName);
            if (m_campaignTypeName == Dictionary.CAMPAIGN_TYPE_CHECK_IN_URL)
            {
                txtMission.Text = "1";
                txtMission.Enabled = false;
            }
        }

        private void UploadFileToFtpServer(string fileName, string filePath, bool isAvatar)
        {
            // Get the object used to communicate with the server.
            var uri = isAvatar
                ? "ftp://phucls11520288@www.ara288.somee.com/www.ara288.somee.com/Ara_Data/Campaigns/Avatar/"
                : "ftp://phucls11520288@www.ara288.somee.com/www.ara288.somee.com/Ara_Data/Campaigns/Banner/";
            var request = (FtpWebRequest) WebRequest.Create(uri + fileName);
            request.Method = WebRequestMethods.Ftp.UploadFile;
            // FTP site logon.
            request.Credentials = new NetworkCredential(Authentication.FPT_USER, Authentication.FPT_PASSWORD);
            // Copy the entire contents of the file to the request stream.
            var sourceStream = new StreamReader(Server.MapPath(filePath));
            var fileContents = Encoding.UTF8.GetBytes(sourceStream.ReadToEnd());
            sourceStream.Close();
            request.ContentLength = fileContents.Length;
            // Upload the file stream to the server.
            var requestStream = request.GetRequestStream();
            requestStream.Write(fileContents, 0, fileContents.Length);
            requestStream.Close();
            // Get the response from the FTP server.
            var response = (FtpWebResponse) request.GetResponse();
            // Close the connection = Happy a FTP server.
            response.Close();
            lblMessage.Text = request.GetResponse().ToString();
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
            if (string.IsNullOrEmpty(txtEndTime.Text))
            {
                SaveNewCampaignWithoutEndTime();
            }
            else
            {
                SaveNewCampaignWithEndTime();
            }
            try
            {
                ClientServiceFactory.CampaignService.SaveNewCampaign(m_campaign);
                Response.Redirect("MissionCampaignCompany.aspx?Method=New&RequestId=" +
                                  ClientServiceFactory.CampaignService.GetCampaignByName(txtCampaignName.Text)
                                      .CampaignId);
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
            Response.Redirect("MissionCampaignCompany.aspx?Method=New&RequestId=" + m_campaign.CampaignId);
        }

        //-----------------------------------------------------------------------------------------------------

        #endregion IMethods
    }
}