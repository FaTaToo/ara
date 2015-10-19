// --------------------------------------------------------------------------------------------------------------------
// <header file="SubscriptionAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the SubscriptionAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Subscription {
    /// <summary>
    /// The subscription has already existed.
    /// </summary>
    [DataContract]
    public class SubscriptionAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
