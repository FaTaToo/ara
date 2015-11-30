// --------------------------------------------------------------------------------------------------------------------
/* <header file="EmailAlreadyExistException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the EmailAlreadyExistException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic
{
    /// <summary>
    ///     The email has already existed.
    /// </summary>
    [DataContract]
    public class EmailAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}