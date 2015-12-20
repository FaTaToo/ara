// --------------------------------------------------------------------------------------------------------------------
/* <header file="AuthenticationJsonRespone.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement AuthenticationJsonRespone.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson.Common
{
    [DataContract]
    public class JsonRespone
    {
        #region IProperties

        [DataMember]
        public string Message { get; set; }

        #endregion IProperties
    }
}