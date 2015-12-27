using System;
using System.Web.UI;
using ARAManager.Presentation.Client.Common;

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
            Response.Redirect(Routes.NAVIGATION_TO_COMPANY_PAGE_OF_ADMIN);
        }

        protected void btnCustomer_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Routes.NAVIGATION_TO_CUSTOMER_PAGE_OF_ADMIN);
        }

        protected void btnStatistics_OnClick(object sender, EventArgs e)
        {
            Response.Redirect(Routes.NAVIGATION_TO_STATISTIC_PAGE_OF_ADMIN);
        }

        #endregion IMethods
    }
}