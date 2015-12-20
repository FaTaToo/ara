// --------------------------------------------------------------------------------------------------------------------
/* <header file="CampaignJson.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the CampaignJson.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.PresenterJson.Campaign
{
    [DataContract]
    public class CampaignJson
    {
        #region IProperties

        [DataMember]
        public string CampaignName { get; set; }

        [DataMember]
        public string StartTime { get; set; }

        [DataMember]
        public string EndTime { get; set; }

        [DataMember]
        public string Description { get; set; }

        [DataMember]
        public string Avatar { get; set; }

        [DataMember]
        public string Banner { get; set; }

        [DataMember]
        public string Gift { get; set; }

        [DataMember]
        public string NumMission { get; set; }

        [DataMember]
        public string CompanyId { get; set; }

        [DataMember]
        public string CampaignTypeId { get; set; }

        #endregion IProperties
    }
}
