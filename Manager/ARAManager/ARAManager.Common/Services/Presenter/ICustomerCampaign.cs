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
        [WebGet(UriTemplate = "/GetListOfCampaigns",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        IList<Campaign> GetListOfCampaigns();

        [OperationContract]
        [WebGet(UriTemplate = "/GetCampaignByName",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        Campaign GetCampaignByName(string campaignName);

        [OperationContract]
        [WebGet(UriTemplate = "/GetArData",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json)]
        RootObject GetArData(string targetUrl);
    }
}