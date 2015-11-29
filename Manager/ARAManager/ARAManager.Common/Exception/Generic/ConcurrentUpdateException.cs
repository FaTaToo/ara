// --------------------------------------------------------------------------------------------------------------------
/* <header file="ConcurrentUpdateException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ConcurrentUpdateException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic {
    /// <summary>
    /// There is concurrent update error.
    /// </summary>
    [DataContract]
    public class ConcurrentUpdateException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
