// --------------------------------------------------------------------------------------------------------------------
/* <header file="SubscriptionUpdateMissionJson.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the SubscriptionUpdateMissionJson.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson.Subscription
{
    [DataContract]
    public class SubscriptionUpdateMissionJson
    {
        #region IProperties

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public string CampaignId { get; set; }

        [DataMember]
        public string MissionId { get; set; }

        [DataMember]
        public string RowVersion { get; set; }

        #endregion IProperties
    }
}
