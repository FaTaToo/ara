// --------------------------------------------------------------------------------------------------------------------
/* <header file="ManagementCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for ManagementCompany MASTER page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Web.UI;
using ARAManager.Presentation.Client.Common;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.Master_Pages
{
    /// <summary>
    ///     Master page of company's pages.
    /// </summary>
    public partial class ManagementCompany : MasterPage
    {
        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCampaign_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Routes.NAVIGATION_TO_CAMPAIGN_PAGE_OF_COMPANY);
        }

        protected void btnStatistics_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Routes.NAVIGATION_TO_STATISTICS_PAGE_OF_COMPANY);
        }

        #endregion IMethods
    }
}