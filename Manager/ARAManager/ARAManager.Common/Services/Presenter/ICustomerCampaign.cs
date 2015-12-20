﻿// --------------------------------------------------------------------------------------------------------------------
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
using ARAManager.Common.PresenterJson.ArResources;
using ARAManager.Common.PresenterJson.Campaign;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerCampaign
    {
        [OperationContract]
        [WebGet(UriTemplate = "/GetListOfCampaigns",
            ResponseFormat = WebMessageFormat.Json)]
        IList<CampaignJson> GetListOfCampaigns();

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetCampaignByName/{campaignName}",
            ResponseFormat = WebMessageFormat.Json)]
        CampaignJson GetCampaignByName(string campaignName);

        [OperationContract]
        [WebInvoke(UriTemplate = "/GetArData/{targetUrl}",
            ResponseFormat = WebMessageFormat.Json)]
        RootObject GetArData(string targetUrl);
    }
}