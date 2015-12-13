// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICustomerCampaign.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ICustomerCampaign.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using System.ServiceModel.Web;
using ARAManager.Common.Dto;
using ARAManager.Common.PresenterJson.ArResources;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerCampaign
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/GetListOfCampaigns",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        IList<Campaign> GetListOfCampaigns();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetCampaignByName",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        Campaign GetCampaignByName(string campaignName);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetArData",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        RootObject GetArData(string targetUrl);
    }
}