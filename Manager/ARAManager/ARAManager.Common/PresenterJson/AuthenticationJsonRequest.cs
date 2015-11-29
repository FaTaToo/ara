// --------------------------------------------------------------------------------------------------------------------
/* <header file="AuthenticationJson.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement AuthenticationJson.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson
{
    [DataContract]
    public class AuthenticationJsonRequest
    {
        #region IProperties

        [DataMember]
        public string UserName { get; set; }

        [DataMember]
        public string Password { get; set; }

        #endregion IProperties
    }
}
