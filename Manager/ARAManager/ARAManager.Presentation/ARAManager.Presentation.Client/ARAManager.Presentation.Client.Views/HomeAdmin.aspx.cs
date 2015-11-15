// --------------------------------------------------------------------------------------------------------------------
/* <header file="HomeAdmin.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for HomeAdmin page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class HomeAdmin : System.Web.UI.Page
    {
        #region IConstants

        private const string NUMBER_OF_CUSTOMER = "txtNumCustomers_";

        #endregion IConstants

        #region IFields

        private int m_numberofCustomers;
        private int m_numberofCompanies;
        private int m_numberofCampaigns;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            // Commented by PhucLS: Will be fixed with new services
            m_numberofCustomers = ClientServiceFactory.CustomerService.GetAllCustomers().Count;
            m_numberofCompanies = ClientServiceFactory.CompanyService.GetAllCompanies().Count;
            m_numberofCampaigns = ClientServiceFactory.CampaignService.GetAllCampaigns().Count;
            // Ended by PhucLS
        }

        #endregion IMethods
    }
}