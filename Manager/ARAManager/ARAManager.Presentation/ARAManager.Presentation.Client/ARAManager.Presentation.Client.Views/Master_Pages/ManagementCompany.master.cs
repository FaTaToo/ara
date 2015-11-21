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
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\EditCampaignCompany.aspx?Method=New");
        }
        #endregion IMethods
    }
}