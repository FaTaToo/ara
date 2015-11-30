// --------------------------------------------------------------------------------------------------------------------
/* <header file="PreMissionAlreadyExistException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the PreMissionAlreadyExistException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Mission
{
    /// <summary>
    ///     The pre mission has already existed.
    /// </summary>
    [DataContract]
    public class PreMissionAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}