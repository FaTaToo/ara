// --------------------------------------------------------------------------------------------------------------------
/* <header file="UserNameAlreadyExistException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the UserNameAlreadyExistException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic
{
    /// <summary>
    ///     The user name has already existed.
    /// </summary>
    [DataContract]
    public class UserNameAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}