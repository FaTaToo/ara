// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICustomerAccount.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ICustomerAccount.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.ServiceModel;
using System.ServiceModel.Web;
using ARAManager.Common.PresenterJson.Account;
using ARAManager.Common.PresenterJson.Common;

namespace ARAManager.Common.Services.Presenter
{
    [ServiceContract]
    public interface ICustomerAccount
    {
        [OperationContract]
        [WebInvoke(UriTemplate = "/Authenticate",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        JsonRespone Authenticate(AuthenticationJsonRequest account);

        [OperationContract] 
        [WebInvoke(UriTemplate = "/SignUp",
            RequestFormat = WebMessageFormat.Json,
            ResponseFormat = WebMessageFormat.Json, Method = "POST")]
        JsonRespone SignUp(CustomerJson customerJson);
    }
}