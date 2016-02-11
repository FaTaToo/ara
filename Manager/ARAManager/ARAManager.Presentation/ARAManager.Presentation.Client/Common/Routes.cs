// --------------------------------------------------------------------------------------------------------------------
/* <header file="Routes.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Defines navigation path, naming aspx files in web.
 * </summary>
 * <Problems>
 *      Will be sorted by ABC.
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

namespace ARAManager.Presentation.Client.Common
{
    public class Routes
    {
        #region IConstants

        public const string NAVIGATION_TO_COMPANY_PAGE_OF_ADMIN =
            @"~\ARAManager.Presentation.Client.Views\CompanyAdmin.aspx";

        public const string NAVIGATION_TO_COMPANY_PAGE_OF_ADMIN_SHORT =
            @"CompanyAdmin.aspx";

        public const string NAVIGATION_TO_CUSTOMER_PAGE_OF_ADMIN =
            @"~\ARAManager.Presentation.Client.Views\CustomerAdmin.aspx";

        public const string NAVIGATION_TO_CUSTOMER_PAGE_OF_ADMIN_SHORT =
            @"CustomerAdmin.aspx";

        public const string NAVIGATION_TO_STATISTIC_PAGE_OF_ADMIN =
            @"~\ARAManager.Presentation.Client.Views\StatisticsAdmin.aspx";

        public const string NAVIGATION_TO_CAMPAIGN_PAGE_OF_COMPANY =
            @"~\ARAManager.Presentation.Client.Views\CampaignCompany.aspx";

        public const string NAVIGATION_TO_CAMPAIGN_PAGE_OF_COMPANY_SHORT =
            @"CampaignCompany.aspx";

        public const string NAVIGATION_TO_STATISTICS_PAGE_OF_COMPANY =
            @"~\ARAManager.Presentation.Client.Views\StatisticsCompany.aspx";

        /*
         * RequestId=-4438: Stands for "New" signal
         */

        public const string NAVIGATION_TO_NEW_COMPANY_PAGE_OF_ADMIN =
            @"EditCompanyAdmin.aspx?RequestId=-4438";

        public const string NAVIGATION_TO_NEW_CUSTOMER_PAGE_OF_ADMIN =
            @"EditCustomerAdmin.aspx?RequestId=-4438";

        public const string NAVIGATION_TO_HOME_PAGE_OF_ADMIN =
            @"HomeAdmin.aspx";

        public const string NAVIGATION_TO_NEW_MISSION_OF_CAMPAIGN_PAGE_OF_COMPANY =
            @"MissionCampaignCompany.aspx?Method=New&RequestId=";

        public const string NAVIGATION_TO_LOGIN_PAGE =
            "Default.aspx";

        #endregion IConstants
    }
}