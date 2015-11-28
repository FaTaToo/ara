// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignAlreadyDeletedException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the CampaignAlreadyDeletedException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Campaign {
    /// <summary>
    /// The campaign has been already deleted.
    /// </summary>
    [DataContract]
    public class CampaignAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
