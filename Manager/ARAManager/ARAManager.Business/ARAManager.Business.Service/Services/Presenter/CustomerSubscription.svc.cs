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

        public JsonRespone JoinCampaign(SubscriptionJson subscriptionJson)
        {
            var subscription = ConvertSubscriptionJsonToSubScription(subscriptionJson);
            var srvDaoSubcription = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDaoSubcription.Save(subscription);
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

        public IList<SubscriptionJson> GetListOfSubscriptions(string customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var criteria = DetachedCriteria.For<Subscription>();
            criteria.Add(Restrictions.Where<Subscription>(c => c.Customer.CustomerId == int.Parse(customerId)));
            var subscriptions = srvDao.FindByCriteria(criteria);
            return subscriptions.Select(ConvertSubscriptionToSubcriptionJson).ToList();
        }

        public SubscriptionJson GetSubscription(string subscriptionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ISubscriptionDataAccess>();
            var subscription = srvDao.GetById(int.Parse(subscriptionId));
            return subscription != null ? ConvertSubscriptionToSubcriptionJson(subscription) : null;
        }

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

        public IList<MissionJson> GetMissionsOfCampaign(string campaignId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            var criteria = DetachedCriteria.For<Mission>();
            criteria.Add(Restrictions.Where<Mission>(m => m.Campaign.CampaignId == int.Parse(campaignId)));
            var missions = srvDao.FindByCriteria(criteria);
            return missions.Select(ConvertMissionToMissionJson).ToList();
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
            var srvDaoMission = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            return new Subscription
            {
                Campaign = srvDaoCampaign.GetById(int.Parse(subscriptionJson.CampaignId)),
                Customer = srvDaoCustomer.GetById(int.Parse(subscriptionJson.CustomerId)),
                Comment = subscriptionJson.Comment,
                CurrentMission = srvDaoMission.GetById(int.Parse(subscriptionJson.CurrentMission)),
                IsComplete = ReturnIsCompleteSubscriptionValue(subscriptionJson.IsComplete),
                NumOfCompletedMission = int.Parse(subscriptionJson.NumOfCompletedMission),
                Rating = int.Parse(subscriptionJson.Rating)
            };
        }

        private SubscriptionJson ConvertSubscriptionToSubcriptionJson(Subscription subscription)
        {
            return new SubscriptionJson
            {
                CampaignId = subscription.Campaign.CampaignId.ToString(),
                CurrentMission = subscription.CurrentMission.MissionId.ToString(),
                CustomerId = subscription.Customer.CustomerId.ToString(),
                IsComplete = ReturnIsCompleteSubscriptionString(subscription.IsComplete),
                NumOfCompletedMission = subscription.NumOfCompletedMission.ToString(),
                Comment = subscription.Comment,
                Rating = subscription.ToString()
            };
        }

        private MissionJson ConvertMissionToMissionJson(Mission mission)
        {
            return new MissionJson
            {
                MissionName = mission.Name,
                Description = mission.Description,
                Avatar = mission.Avatar,
                NumTarget = mission.NumTarget.ToString(),
                CampaignId = mission.Campaign.CampaignId.ToString()
            };
        }

        #endregion IMethods
    }
}