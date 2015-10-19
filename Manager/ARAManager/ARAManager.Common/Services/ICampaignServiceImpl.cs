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

using System.ServiceModel;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ICampaignServiceImpl {
        [OperationContract]
        void DoWork();
    }
}
