// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICampaignTypeServiceImp.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ICampaignTypeServiceImp.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services
{
    [ServiceContract]
    public interface ICampaignTypeServiceImpl
    {
        [OperationContract]
        [PreserveReferences]
        CampaignType GetCampaignTypeById(int campaignTypeId);

        [OperationContract]
        [PreserveReferences]
        CampaignType GetCampaignTypeByName(string campaignTypeName);
    }
}