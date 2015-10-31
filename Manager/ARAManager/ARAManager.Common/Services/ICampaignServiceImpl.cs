// --------------------------------------------------------------------------------------------------------------------
// <header file="ICampaignServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ICampaignServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Campaign;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ICampaignServiceImpl {
        [OperationContract]
        [PreserveReferences]
        Campaign GetCampaignById(int campaignId);

        [OperationContract]
        [PreserveReferences]
        IList<Campaign> GetAllCampaigns();

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CampaignNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewCampaign(Campaign campaign);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CampaignNameAlreadyExistException))]
        void DeleteCampaign(int campaignId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CampaignNameAlreadyExistException))]
        void DeleteCampaigns(List<int> campaigns);

        [OperationContract]
        [PreserveReferences]
        IList<Campaign> SearchCampaign(string campaignname, string companyname);
    }
}
