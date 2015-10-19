// --------------------------------------------------------------------------------------------------------------------
// <header file="CampaignNameAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CampaignNameAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Campaign {
    /// <summary>
    /// The campaign name has already existed.
    /// </summary>
    [DataContract]
    public class CampaignNameAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
