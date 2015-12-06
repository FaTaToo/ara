using System;
using System.Web.UI;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views.Master_Pages
{
    // ReSharper disable once InconsistentNaming - Added by PhucLS
    public partial class ManagementAdmin : MasterPage
    {
        #region IMethods

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCompany_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\CompanyAdmin.aspx");
        }

        protected void btnCustomer_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\CustomerAdmin.aspx");
        }

        protected void btnStatistics_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(@"~\ARAManager.Presentation.Client.Views\StatisticsAdmin.aspx");
        }

        #endregion IMethods
    }
}