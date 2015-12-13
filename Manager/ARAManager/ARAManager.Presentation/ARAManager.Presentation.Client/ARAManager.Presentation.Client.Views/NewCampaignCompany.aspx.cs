// --------------------------------------------------------------------------------------------------------------------
/* <header file="NewCampaignCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for NewCampaignCompany page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.UI;
using ARAManager.Common;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    /// <summary>
    ///     Code-behind of NewCampaignCompany.aspx - used to choose category of campaign
    /// </summary>
    public partial class NewCampaignCompany : Page
    {
        #region IConstants

        private const string EDIT_CAMPAIGN_COMPANY_URL =
            @"~\ARAManager.Presentation.Client.Views\EditCampaignCompany.aspx?Method=New&Type=";

        #endregion IConstants

        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCreate_OnClick(object sender, EventArgs e)
        {
            // Commented by PhucLS - 20151128 - Code logic will be optimized later   
            if (rbCheckIn.Checked)
            {
                /*
                 * 1 campaign
                 * 1 mission
                 * 1 target
                 */
                NavigateToEditCampaignCompanyPage(Dictionary.CAMPAIGN_TYPE_CHECK_IN_URL);
            }
            else if (rbTour.Checked)
            {
                /*
                 * 1 campaign
                 * n mission
                 * 1 mission - 1 target 
                 */
                NavigateToEditCampaignCompanyPage(Dictionary.CAMPAIGN_TYPE_TOUR_URL);
            }
            else if (rbTheater.Checked)
            {
                /*
                 * 1 campaign
                 * 1 mission
                 * 1 target 
                 */
                NavigateToEditCampaignCompanyPage(Dictionary.CAMPAIGN_TYPE_THEATER_URL);
            }
        }

        private void NavigateToEditCampaignCompanyPage(string type)
        {
            Response.Redirect(EDIT_CAMPAIGN_COMPANY_URL + type);
        }

        #endregion IMethods
    }
}