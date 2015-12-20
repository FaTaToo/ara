// --------------------------------------------------------------------------------------------------------------------
/* <header file="SubscriptionJson.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the SubscriptionJson.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson.Subscription
{
    [DataContract]
    public class SubscriptionJson
    {
        #region IProperties

        [DataMember]
        public string CustomerId { get; set; }

        [DataMember]
        public string CampaignId { get; set; }

        [DataMember]
        public string CurrentMission { get; set; }

        [DataMember]
        public string NumOfCompletedMission { get; set; }

        [DataMember]
        public string IsComplete { get; set; }

        [DataMember]
        public string Comment { get; set; }

        [DataMember]
        public string Rating { get; set; }

        #endregion IProperties
    }
}
