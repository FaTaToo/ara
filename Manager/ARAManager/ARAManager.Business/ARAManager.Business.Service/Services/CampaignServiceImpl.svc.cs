// --------------------------------------------------------------------------------------------------------------------
// <header file="CampaignServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Campaign.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
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

namespace ARAManager.Business.Service.Services {
    public class CampaignServiceImpl : ICampaignServiceImpl {
        #region IMethods
        public Campaign GetCampaignById(int campaignId) {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            return srvDao.GetById(campaignId);
        }
        public IList<Campaign> GetAllCampaigns()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var criteria = DetachedCriteria.For<Campaign>();
            return srvDao.FindByCriteria(criteria);
        }

        public void SaveNewCampaign(Campaign campaign)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(campaign);
                }
                catch (ADOException)
                {
                    throw new FaultException<CampaignNameAlreadyExistException>(
                        new CampaignNameAlreadyExistException { MessageError = Dictionary.CAMPAIGN_NAME_CONSTRAINT_EXCEPTION_MSG },
                        new FaultReason(Dictionary.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException { MessageError = Dictionary.CAMPAIGN_CONCURRENT_UPDATE_EXCEPTION_MSG },
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

        public void DeleteCampaign(int campaignId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteCampaign = srvDao.GetById(campaignId);
                    srvDao.Delete(deleteCampaign);
                }
                catch (Exception)
                {
                    throw new FaultException<CampaignAlreadyDeletedException>(
                       new CampaignAlreadyDeletedException { MessageError = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }

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
                       new CampaignAlreadyDeletedException { MessageError = Dictionary.CAMPAIGN_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
            }
        }
        #endregion IMethods
    }
}
