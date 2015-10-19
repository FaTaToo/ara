// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountTypeAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the AccountTypeAlreadyDeletedException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.AccountType {
    /// <summary>
    /// The type of account has been alread deleted.
    /// </summary>
    [DataContract]
    public class AccountTypeAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
