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

using System.ServiceModel;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerSubscription
    {
        [OperationContract]
        void DoWork();
    }
}
