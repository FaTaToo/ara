// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerCampaign.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement CustomerCampaign service of presenter.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.Linq;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.PresenterJson.Campaign;
using ARAManager.Common.Services.Presenter;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerCampaign : ICustomerCampaign
    {
        #region IMethods

        /// <summary>
        ///     Get list of ALL available campaigns of ALL companies
        /// </summary>
        /// <returns></returns>
        public IList<CampaignJson> GetListOfCampaigns()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            var campaigns = srvDao.FindByCriteria(criteria);
            return campaigns.Select(ReturnCampaignJson).ToList();
        }

        /// <summary>
        ///     Get campaign by campaign name
        /// </summary>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        public CampaignJson GetCampaignByName(string campaignName)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            if (!string.IsNullOrEmpty(campaignName))
            {
                criteria.Add(Restrictions.Where<Campaign>(c => c.CampaignName == campaignName));
            }
            var campaign = srvDao.FindByCriteria(criteria).FirstOrDefault();
            return campaign != null ? ReturnCampaignJson(campaign) : new CampaignJson();
        }

        private CampaignJson ReturnCampaignJson(Campaign campaign)
        {
            return campaign.EndTime != null
                ? new CampaignJson
                {
                    CampaignName = campaign.CampaignName,
                    StartTime = campaign.StartTime.ToString(Dictionary.DATE_FORMAT),
                    EndTime = campaign.EndTime.Value.ToString(Dictionary.DATE_FORMAT),
                    Avatar = campaign.Avatar,
                    Banner = campaign.Banner,
                    Description = campaign.Description,
                    Gift = campaign.Gift,
                    CampaignTypeId = campaign.CampaignTypeId.CampaignTypeId.ToString(),
                    CompanyId = campaign.Company.CompanyId.ToString(),
                    NumMission = campaign.NumMission.ToString()
                }
                : new CampaignJson();
        }

        #endregion IMethods
    }
}