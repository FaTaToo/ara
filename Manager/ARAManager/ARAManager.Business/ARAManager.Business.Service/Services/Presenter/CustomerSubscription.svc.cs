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
using System.IO;
using System.Linq;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.PresenterJson.ArResources;
using ARAManager.Common.PresenterJson.Common;
using ARAManager.Common.PresenterJson.Mission;
using ARAManager.Common.PresenterJson.Subscription;
using ARAManager.Common.Services.Presenter;
using Newtonsoft.Json;
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

        /// <summary>
        ///     Help customer for joining campaign
        /// </summary>
        /// <param name="subscriptionJson"></param>
        /// <returns></returns>
        public JsonRespone JoinCampaign(SubscriptionJson subscriptionJson)
        {
            var subscription = ConvertSubscriptionJsonToSubScription(subscriptionJson);
            var srvDaoSubcription = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDaoSubcription.Save(subscription);
                    m_authenticationJsonRespone.Message = Dictionary.MSG_SUCCESS;
                    tr.Complete();
                    return m_authenticationJsonRespone;
                }
                catch (Exception)
                {
                    m_authenticationJsonRespone.Message = Dictionary.MSG_FAILED;
                    return m_authenticationJsonRespone;
                }
            }
        }

        /// <summary>
        ///     Leave campaign - delete subscription by subsriptionId
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public JsonRespone LeaveCampaign(string subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteSubscription = srvDao.GetById(int.Parse(subscriptionId));
                    srvDao.Delete(deleteSubscription);
                    tr.Complete();
                    m_authenticationJsonRespone.Message = Dictionary.MSG_SUCCESS;
                    return m_authenticationJsonRespone;
                }
                catch (Exception)
                {
                    m_authenticationJsonRespone.Message = Dictionary.MSG_FAILED;
                    return m_authenticationJsonRespone;
                }
            }
        }

        /// <summary>
        ///     Get list of subscriptions by customerId
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public IList<SubscriptionJson> GetListOfSubscriptions(string customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(Restrictions.Where<Subscription>(c => c.Customer.CustomerId == int.Parse(customerId)));
            var subscriptions = srvDao.FindByCriteria(criteria);
            return subscriptions.Select(ConvertSubscriptionToSubcriptionJson).ToList();
        }

        /// <summary>
        ///     Get subscription by subcriptionId
        /// </summary>
        /// <param name="subscriptionId"></param>
        /// <returns></returns>
        public SubscriptionJson GetSubscription(string subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var subscription = srvDao.GetById(int.Parse(subscriptionId));
            return subscription != null ? ConvertSubscriptionToSubcriptionJson(subscription) : null;
        }

        /// <summary>
        ///     Get Ar Data by targetId
        /// </summary>
        /// <param name="targetId"></param>
        /// <returns></returns>
        public RootObject GetArData(string targetId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ITargetDataAccess>();
            var target = srvDao.GetById(int.Parse(targetId));
            using (var streamReader = new StreamReader(Dictionary.PATH_AR_JSON + target.Url + ".json"))
            {
                var jsonFile = streamReader.ReadToEnd();
                return JsonConvert.DeserializeObject<RootObject>(jsonFile);
            }
        }

        /// <summary>
        ///     Get list of missions of campaign by campaignId
        /// </summary>
        /// <param name="campaignId"></param>
        /// <returns></returns>
        public IList<MissionJson> GetMissionsOfCampaign(string campaignId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            var criteria = DetachedCriteria.For<Mission>();
            criteria.Add(Restrictions.Where<Mission>(m => m.Campaign.CampaignId == int.Parse(campaignId)));
            var missions = srvDao.FindByCriteria(criteria);
            return missions.Select(ConvertMissionToMissionJson).ToList();
        }

        /// <summary>
        ///     Update completed mission to subcription table
        /// </summary>
        /// <param name="subscriptionUpdateMissionJson"></param>
        /// <returns></returns>
        public JsonRespone UpdateCompletedMission(SubscriptionUpdateMissionJson subscriptionUpdateMissionJson)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(
                Restrictions.Where<Subscription>(
                    c => c.Campaign.CampaignId == int.Parse(subscriptionUpdateMissionJson.CampaignId)));
            criteria.Add(
                Restrictions.Where<Subscription>(
                    c => c.Customer.CustomerId == int.Parse(subscriptionUpdateMissionJson.CustomerId)));
            var subscription = srvDao.FindByCriteria(criteria).First();
            subscription.NumOfCompletedMission++;
            subscription.CompletedMission += subscriptionUpdateMissionJson.MissionId + ";";
            var count = 0;
            var rowVersion = new byte[Dictionary.MAX_LENGTH_ROW_VERSION_ARRAY];
            foreach (var byteValue in subscriptionUpdateMissionJson.RowVersion)
            {
                rowVersion[count++] = byte.Parse(byteValue.ToString());
            }
            subscription.RowVersion = rowVersion;
            try
            {
                srvDao.Save(subscription);
                m_authenticationJsonRespone.Message = Dictionary.MSG_SUCCESS;
                return m_authenticationJsonRespone;
            }
            catch (Exception)
            {
                m_authenticationJsonRespone.Message = Dictionary.MSG_FAILED;
                return m_authenticationJsonRespone;
            }
        }

        private bool ReturnIsCompleteSubscriptionValue(string isComplete)
        {
            return isComplete == Dictionary.TRUE;
        }

        private string ReturnIsCompleteSubscriptionString(bool isComplete)
        {
            return isComplete ? Dictionary.TRUE : Dictionary.FALSE;
        }

        private Subscription ConvertSubscriptionJsonToSubScription(SubscriptionJson subscriptionJson)
        {
            var srvDaoCampaign = NinjectKernelFactory.Kernel.Get<ICampaignDataAccess>();
            var srvDaoCustomer = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            return new Subscription
            {
                Customer = srvDaoCustomer.GetById(int.Parse(subscriptionJson.CustomerId)),
                Campaign = srvDaoCampaign.GetById(int.Parse(subscriptionJson.CampaignId)),
                IsComplete = ReturnIsCompleteSubscriptionValue(subscriptionJson.IsComplete),
                CompletedMission = subscriptionJson.CompletedMission,
                NumOfCompletedMission = int.Parse(subscriptionJson.NumOfCompletedMission),
                Comment = subscriptionJson.Comment,
                Rating = int.Parse(subscriptionJson.Rating)
            };
        }

        private SubscriptionJson ConvertSubscriptionToSubcriptionJson(Subscription subscription)
        {
            return new SubscriptionJson
            {
                CustomerId = subscription.Customer.CustomerId.ToString(),
                CampaignId = subscription.Campaign.CampaignId.ToString(),
                IsComplete = ReturnIsCompleteSubscriptionString(subscription.IsComplete),
                CompletedMission = subscription.CompletedMission,
                NumOfCompletedMission = subscription.NumOfCompletedMission.ToString(),
                Comment = subscription.Comment,
                Rating = subscription.Rating.ToString()
            };
        }

        private MissionJson ConvertMissionToMissionJson(Mission mission)
        {
            return new MissionJson
            {
                MissionName = mission.Name,
                Description = mission.Description,
                Avatar = mission.Avatar,
                CampaignId = mission.Campaign.CampaignId.ToString()
            };
        }

        #endregion IMethods
    }
}