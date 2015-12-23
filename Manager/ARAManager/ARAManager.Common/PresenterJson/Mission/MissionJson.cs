// --------------------------------------------------------------------------------------------------------------------
/* <header file="MissionJson.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the MissionJson.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson.Mission
{
    [DataContract]
    public class MissionJson
    {
        #region IProperties

        [DataMember]
        public string MissionName { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Avatar { get; set; }

        [DataMember]
        public string NumTarget { get; set; }

        [DataMember]
        public string CampaignId { get; set; }

        #endregion IProperties
    }
}