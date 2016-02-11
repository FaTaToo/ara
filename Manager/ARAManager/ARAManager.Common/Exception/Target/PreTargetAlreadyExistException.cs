// --------------------------------------------------------------------------------------------------------------------
/* <header file="PreTargetAlreadyExistException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the PreTargetAlreadyExistException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Target
{
    /// <summary>
    ///     The pre target has already existed.
    /// </summary>
    [DataContract]
    public class PreTargetAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}