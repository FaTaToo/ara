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
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\CampaignCompany.aspx");
        }

        #endregion IMethods
    }
}