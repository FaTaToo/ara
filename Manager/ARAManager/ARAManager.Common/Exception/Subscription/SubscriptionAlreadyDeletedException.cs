// --------------------------------------------------------------------------------------------------------------------
// <header file="SubscriptionAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the SubscriptionAlreadyDeletedException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Subscription {
    /// <summary>
    /// The subscription has been already deleted.
    /// </summary>
    [DataContract]
    public class SubscriptionAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
