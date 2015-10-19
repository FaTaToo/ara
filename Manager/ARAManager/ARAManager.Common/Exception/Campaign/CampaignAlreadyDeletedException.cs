// --------------------------------------------------------------------------------------------------------------------
// <header file="CampaignAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CampaignAlreadyDeletedException.
// </summary>
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
