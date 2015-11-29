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
using ARAManager.Common.Dto;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerSubscription
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/JoinCampaign",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool JoinCampaign(Subscription subscription);

        [OperationContract]
        [WebInvoke(UriTemplate = "/JoinCampaign",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        bool UpdateSubscription(Subscription subscription);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetListOfSubscriptions/{customer}")]
        IList<Subscription> GetListOfSubscriptions(Customer customer);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetListOfSubscriptions/{subscriptionId}")]
        Subscription GetSubscription(int subscriptionId);
    }
}