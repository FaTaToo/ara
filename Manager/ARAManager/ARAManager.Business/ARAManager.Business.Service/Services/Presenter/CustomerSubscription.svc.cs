// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerSubscription.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement CustomerSubscription service of presenter.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.PresenterJson;
using ARAManager.Common.Services.Presenter;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerSubscription : ICustomerSubscription
    {
        #region IFields

        private readonly JsonRespone m_authenticationJsonRespone;

        #endregion IFields

        #region IConstructors

        private CustomerSubscription()
        {
            m_authenticationJsonRespone = new JsonRespone();
        }

        #endregion IConstructors

        #region IMethods

        public JsonRespone JoinCampaign(Subscription subscription)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(subscription);
                    m_authenticationJsonRespone.Message = "Successfully";
                    tr.Complete();
                    return m_authenticationJsonRespone;
                }
                catch (Exception)
                {
                    m_authenticationJsonRespone.Message = "Failed";
                    return m_authenticationJsonRespone;
                }
            }
        }

        public IList<Subscription> GetListOfSubscriptions(string customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(Restrictions.Where<Subscription>(c => c.Customer.CustomerId == int.Parse(customerId)));
            return srvDao.FindByCriteria(criteria);
        }

        public Subscription GetSubscription(string subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            return srvDao.GetById(int.Parse(subscriptionId));
        }

        #endregion IMethods
    }
}