// --------------------------------------------------------------------------------------------------------------------
/* <header file="StatisticsCompany.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement logic for StatisticsCompany page.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Linq;
using System.Web.UI;
using System.Web.UI.WebControls;
using ARAManager.Presentation.Client.ARAManager.Presentation.Client.Common;
using ARAManager.Presentation.Connectivity;

namespace ARAManager.Presentation.Client.ARAManager.Presentation.Client.Views
{
    public partial class StatisticsCompany : Page
    {

        #region IFields

        private readonly Validation m_validator = new Validation();

        #endregion IFields

        #region IMethods
        protected void Page_Load(object sender, EventArgs e)
        {
            LoadGeneralStatistic();
        }

        private void LoadGeneralStatistic()
        {
            var campaignList =
                ClientServiceFactory.CampaignService.GetAllCampaigns()
                    .Where(c => c.Company.UserName == Page.User.Identity.Name).ToList();
            var campaignNumbers = campaignList.Count();

            string[] x = new string[campaignNumbers];
            decimal[] y = new decimal[campaignNumbers];
            int totalSubcription = 0;
            for (int i = 0; i < campaignNumbers; i++)
            {
                x[i] = campaignList[i].CampaignName;
                y[i] = campaignList[i].Subscriptions.Count;
                totalSubcription += campaignList[i].Subscriptions.Count;
            }

            campaignChart.Series.Add(new AjaxControlToolkit.BarChartSeries { Data = y });
            campaignChart.CategoriesAxis = string.Join(",", x);

            lblSubcriptionNum.Text = string.Format("Total Subcriptions: {0}", totalSubcription);
            lblCampaignNum.Text = string.Format("Total campaigns: {0}", campaignNumbers);
        }

        protected void CustomValidator_CampaignName_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_CampaignName.ErrorMessage = Validation.VALIDATOR_CAMPAIGN_NAME;
            args.IsValid = m_validator.ValidateChar100(txtCampaignName.Text);
        }

        protected void CustomValidator_RequireFileds_OnServerValidate(object source, ServerValidateEventArgs args)
        {
            CustomValidator_RequireFileds.ErrorMessage = Validation.VALIDATOR_REQUIRED_CRITERION_SEARCH;
            args.IsValid = !string.IsNullOrEmpty(txtCampaignName.Text);
        }

        protected void btnSearch_OnClick(object sender, EventArgs e)
        {
            LoadCampaignDetails();
        }

        private void LoadCampaignDetails()
        {
            var campaign = ClientServiceFactory.CampaignService
                    .GetAllCampaigns().FirstOrDefault(c => c.Company.UserName == Page.User.Identity.Name && c.CampaignName == txtCampaignName.Text);
            if (campaign != null)
            {
                lblCampaignName.Text = campaign.CampaignName;
                lblTotalSub.Text = string.Format("{0} subcriptions", campaign.Subscriptions.Count());
                lblCompleteSub.Text = campaign.Subscriptions.Count(c => c.IsComplete).ToString();
                if (campaign.Subscriptions.Count > 0)
                {
                    lblAveRating.Text =
                        campaign.Subscriptions.Average(c => c.Rating).ToString(CultureInfo.InvariantCulture);
                }
            }
        }

        #endregion IMethods
    }
}