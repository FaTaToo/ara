// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the AccountAlreadyDeletedException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Account {
    /// <summary>
    /// The account has been already deleted.
    /// </summary>
    [DataContract]
    public class AccountAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
