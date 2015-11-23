// --------------------------------------------------------------------------------------------------------------------
// <header file="ISubscriptionServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ISubscriptionServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ISubscriptionServiceImpl {
        [OperationContract]
        [PreserveReferences]
        Subscription GetSubcriptionById(int subscriptionId);

        [OperationContract]
        [PreserveReferences]
        IList<Subscription> GetSubcriptionListByCampaignId(int campaignId);

        [OperationContract]
        [PreserveReferences]
        IList<Subscription> GetSubcriptionListByCustomerId(int customerId);

        [OperationContract]
        [PreserveReferences]
        void SaveNewSubscription(Subscription subscription);

        [OperationContract]
        [PreserveReferences]
        void DeleteSubscription(int subscriptionId);

        [OperationContract]
        [PreserveReferences]
        void DeleteSubscriptions(List<int> subscriptions);
    }
}
