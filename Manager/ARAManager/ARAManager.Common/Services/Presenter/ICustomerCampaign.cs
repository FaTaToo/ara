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

using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerCampaign
    {
        [OperationContract]
        void DoWork();
    }
}
