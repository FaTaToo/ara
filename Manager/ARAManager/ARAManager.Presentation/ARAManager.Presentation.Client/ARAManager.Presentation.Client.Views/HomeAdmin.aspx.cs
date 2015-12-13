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
using System.Web.UI;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class HomeAdmin : Page
    {
        #region IFields

        private int m_numberofCustomers;
        private int m_numberofCompanies;
        private int m_numberofCampaigns;

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            m_numberofCustomers = ClientServiceFactory.CustomerService.CountCustomers();
            m_numberofCompanies = ClientServiceFactory.CompanyService.CountCompany();
            m_numberofCampaigns = ClientServiceFactory.CampaignService.CountCampaign();
            switch ( m_numberofCustomers.ToString().Length)
            {
                case 1:
                    SetTexttxtNumCustomers_6();
                    break;
                case 2:
                    SetTexttxtNumCustomers_5();
                    break;
                case 3:
                    SetTexttxtNumCustomers_4();
                    break;
                case 4:
                    SetTexttxtNumCustomers_3();
                    break;
                case 5:
                    SetTexttxtNumCustomers_2();
                    break;
                case 6:
                    SetTexttxtNumCustomers_1();
                    break;
            }
            switch (m_numberofCompanies.ToString().Length)
            {
                case 1:
                    SetTexttxtNumCompanies_6();
                    break;
                case 2:
                    SetTexttxtNumCompanies_5();
                    break;
                case 3:
                    SetTexttxtNumCompanies_4();
                    break;
                case 4:
                    SetTexttxtNumCompanies_3();
                    break;
                case 5:
                    SetTexttxtNumCompanies_2();
                    break;
                case 6:
                    SetTexttxtNumCompanies_1();
                    break;
            }
            switch (m_numberofCampaigns.ToString().Length)
            {
                case 1:
                    SetTexttxtNumCampaigns_6();
                    break;
                case 2:
                    SetTexttxtNumCampaigns_5();
                    break;
                case 3:
                    SetTexttxtNumCampaigns_4();
                    break;
                case 4:
                    SetTexttxtNumCampaigns_3();
                    break;
                case 5:
                    SetTexttxtNumCampaigns_2();
                    break;
                case 6:
                    SetTexttxtNumCampaigns_1();
                    break;
            }
        }
        private void SetTexttxtNumCustomers_1()
        {
            txtNumCustomers_1.Text = m_numberofCustomers.ToString()[0].ToString();
            SetTexttxtNumCustomers_2();
        }
        private void SetTexttxtNumCustomers_2()
        {
            txtNumCustomers_2.Text = m_numberofCustomers.ToString()[1].ToString();
            SetTexttxtNumCustomers_3();
        }
        private void SetTexttxtNumCustomers_3()
        {
            txtNumCustomers_3.Text = m_numberofCustomers.ToString()[2].ToString();
            SetTexttxtNumCustomers_4();
        }
        private void SetTexttxtNumCustomers_4()
        {
            txtNumCustomers_4.Text = m_numberofCustomers.ToString()[3].ToString();
            SetTexttxtNumCustomers_5();
        }
        private void SetTexttxtNumCustomers_5()
        {
            txtNumCustomers_5.Text = m_numberofCustomers.ToString()[4].ToString();
            SetTexttxtNumCustomers_6();
        }
        private void SetTexttxtNumCustomers_6()
        {
            txtNumCustomers_6.Text = m_numberofCustomers.ToString()[5].ToString();
        }
        private void SetTexttxtNumCompanies_1()
        {
            txtNumCompanies_1.Text = m_numberofCompanies.ToString()[0].ToString();
            SetTexttxtNumCompanies_2();
        }
        private void SetTexttxtNumCompanies_2()
        {
            txtNumCompanies_2.Text = m_numberofCompanies.ToString()[1].ToString();
            SetTexttxtNumCompanies_3();
        }
        private void SetTexttxtNumCompanies_3()
        {
            txtNumCompanies_3.Text = m_numberofCompanies.ToString()[2].ToString();
            SetTexttxtNumCompanies_4();
        }
        private void SetTexttxtNumCompanies_4()
        {
            txtNumCompanies_4.Text = m_numberofCompanies.ToString()[3].ToString();
            SetTexttxtNumCompanies_5();
        }
        private void SetTexttxtNumCompanies_5()
        {
            txtNumCompanies_5.Text = m_numberofCompanies.ToString()[4].ToString();
            SetTexttxtNumCompanies_6();
        }
        private void SetTexttxtNumCompanies_6()
        {
            txtNumCompanies_6.Text = m_numberofCompanies.ToString()[5].ToString();
        }
        private void SetTexttxtNumCampaigns_1()
        {
            txtNumCampaigns_1.Text = m_numberofCampaigns.ToString()[0].ToString();
            SetTexttxtNumCampaigns_2();
        }
        private void SetTexttxtNumCampaigns_2()
        {
            txtNumCampaigns_2.Text = m_numberofCampaigns.ToString()[1].ToString();
            SetTexttxtNumCampaigns_3();
        }
        private void SetTexttxtNumCampaigns_3()
        {
            txtNumCampaigns_3.Text = m_numberofCampaigns.ToString()[2].ToString();
            SetTexttxtNumCampaigns_4();
        }
        private void SetTexttxtNumCampaigns_4()
        {
            txtNumCampaigns_4.Text = m_numberofCampaigns.ToString()[3].ToString();
            SetTexttxtNumCampaigns_5();
        }
        private void SetTexttxtNumCampaigns_5()
        {
            txtNumCampaigns_5.Text = m_numberofCampaigns.ToString()[4].ToString();
            SetTexttxtNumCampaigns_6();
        }
        private void SetTexttxtNumCampaigns_6()
        {
            txtNumCampaigns_6.Text = m_numberofCampaigns.ToString()[5].ToString();
        }
        #endregion IMethods
    }
}