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

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.Master_Pages {
    /// <summary>
    /// Master page of company's pages.
    /// </summary>
    public partial class ManagementCompany : System.Web.UI.MasterPage
    {
        #region IMethods
        protected void Page_Load(object sender, EventArgs e) {

        }

        protected void btnCampaign_OnClick(object sender, EventArgs e)
        {
            /* Modified by PhucLS - 20151128 - Release20151128
             * Notes: _ Navigate to NewCampaignCompany.aspx instead of EditCampaignCompany.aspx
             *          (divide into 3 campaign types)
             */
            // Response.Redirect(@"~\ARAManager.Presentation.Client.Views\EditCampaignCompany.aspx?Method=New");
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\NewCampaignCompany.aspx");
            // Ended by PhucLS
        }
        #endregion IMethods
    }
}