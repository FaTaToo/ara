// --------------------------------------------------------------------------------------------------------------------
// <header file="CustomerAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CustomerAlreadyDeletedException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Customer {
    /// <summary>
    /// The customer has been already deleted.
    /// </summary>
    [DataContract]
    public class CustomerAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
