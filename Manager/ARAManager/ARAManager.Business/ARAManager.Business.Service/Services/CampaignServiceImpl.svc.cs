// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *       Implement the service class for Campaign.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services
{
    public class CampaignServiceImpl : ICampaignServiceImpl
    {
        #region IMethods

        /// <summary>
        ///     Get campaign by campaing id
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public Campaign GetCampaignById(int campaignId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            return srvDao.GetById(campaignId);
        }

        /// <summary>
        ///     Get campaign by name
        /// </summary>
        /// <param name="campaignName"></param>
        /// <returns></returns>
        public Campaign GetCampaignByName(string campaignName)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            if (!string.IsNullOrEmpty(campaignName))
            {
                criteria.Add(Restrictions.Where<Campaign>(c => c.CampaignName == campaignName));
            }
            return srvDao.FindByCriteria(criteria).FirstOrDefault();
        }

        /// <summary>
        ///     Get all campaigns
        /// </summary>
        /// <returns></returns>
        public IList<Campaign> GetAllCampaigns()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            return srvDao.FindByCriteria(criteria);
        }

        /// <summary>
        ///     Save new campaign
        /// </summary>
        /// <param name="campaign"></param>
        public void SaveNewCampaign(Campaign campaign)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(campaign);
                }
                catch (ADOException)
                {
                    throw new FaultException<CampaignNameAlreadyExistException>(
                        new CampaignNameAlreadyExistException
                        {
                            MessageError = Dictionary.CAMPAIGN_NAME_CONSTRAINT_EXCEPTION_MSG
                        },
                        new FaultReason(Dictionary.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException
                        {
                            MessageError = Dictionary.CAMPAIGN_CONCURRENT_UPDATE_EXCEPTION_MSG
                        },
                        new FaultReason(Dictionary.CAMPAIGN_CONCURRENT_UPDATE_EXCEPTION_MSG));
                }
                catch (Exception ex)
                {
                    throw new FaultException<Exception>(
                        new Exception(ex.Message),
                        new FaultReason(Dictionary.UNKNOWN_REASON));
                }
                tr.Complete();
            }
        }

        /// <summary>
        ///     Delete campaign by campaign id
        /// </summary>
        /// <param name="campaignId"></param>
        public void DeleteCampaign(int campaignId)
        {
            var srvDaoCampaign = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteCampaign = srvDaoCampaign.GetById(campaignId);
                    srvDaoCampaign.Delete(deleteCampaign);
                }
                catch (Exception)
                {
                    throw new FaultException<CampaignAlreadyDeletedException>(
                        new CampaignAlreadyDeletedException {MessageError = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG},
                        new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }

        /// <summary>
        ///     Delete campaigns by the list of campaigns id
        /// </summary>
        /// <param name="campaigns"></param>
        public void DeleteCampaigns(List<int> campaigns)
        {
            foreach (var campaign in campaigns)
            {
                try
                {
                    DeleteCampaign(campaign);
                }
                catch (Exception)
                {
                    throw new FaultException<CampaignAlreadyDeletedException>(
                        new CampaignAlreadyDeletedException {MessageError = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG},
                        new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
            }
        }

        /// <summary>
        ///     Search campaign by campaign name
        /// </summary>
        /// <param name="campaignname"></param>
        /// <returns></returns>
        public IList<Campaign> SearchCampaign(string campaignname)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();

            if (!string.IsNullOrEmpty(campaignname))
            {
                criteria.Add(Restrictions.Where<Campaign>(c => c.CampaignName == campaignname));
            }

            var result = srvDao.FindByCriteria(criteria);
            return result;
        }

        /// <summary>
        ///     Count the number of campaign
        /// </summary>
        /// <returns></returns>
        public int CountCampaign()
        {
            return GetAllCampaigns().Count;
        }

        #endregion IMethods
    }
}