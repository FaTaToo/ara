// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICustomerSubscription.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ICustomerSubscription.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ARAManager.Common.PresenterJson.Common;
using ARAManager.Common.PresenterJson.Subscription;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerSubscription
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/JoinCampaign",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        JsonRespone JoinCampaign(SubscriptionJson subscriptionJson);

        [OperationContract]
        [WebGet(UriTemplate = "/GetListOfSubscriptions/{customerId}",
            ResponseFormat = WebMessageFormat.Json)]
        IList<SubscriptionJson> GetListOfSubscriptions(string customerId);

        [OperationContract]
        [WebGet(UriTemplate = "/GetSubscription/{subscriptionId}",
            ResponseFormat = WebMessageFormat.Json)]
        SubscriptionJson GetSubscription(string subscriptionId);
    }
}