// --------------------------------------------------------------------------------------------------------------------
/* <header file="SubscriptionServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the service class for Subscription.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Exception.Subscription;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
    public class SubscriptionServiceImpl : ISubscriptionServiceImpl
    {
        #region IMethods

        public Subscription GetSubcriptionById(int subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            return srvDao.GetById(subscriptionId);
        }
        public IList<Subscription> GetSubcriptionListByCampaignId(int campaignId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(Restrictions.Where<Subscription>(c => c.Campaign.CampaignId == campaignId));
            return srvDao.FindByCriteria(criteria);
        }
        public IList<Subscription> GetSubcriptionListByCustomerId(int customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(Restrictions.Where<Subscription>(c => c.Customer.CustomerId == customerId));
            return srvDao.FindByCriteria(criteria);
        }
        public void SaveNewSubscription(Subscription subscription)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(subscription);
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

        public void DeleteSubscription(int subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteSubscription = srvDao.GetById(subscriptionId);
                    srvDao.Delete(deleteSubscription);
                }
                catch (Exception)
                {
                    throw new FaultException<SubscriptionAlreadyDeletedException>(
                       new SubscriptionAlreadyDeletedException { MessageError = Dictionary.SUBSCRIPTION_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }

        public void DeleteSubscriptions(List<int> subscriptions)
        {
            foreach (var subscription in subscriptions)
            {
                try
                {
                    DeleteSubscription(subscription);
                }
                catch (Exception)
                {
                    throw new FaultException<SubscriptionAlreadyDeletedException>(
                       new SubscriptionAlreadyDeletedException { MessageError = Dictionary.SUBSCRIPTION_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
            }
        }

    #endregion IMethods
    }
}
