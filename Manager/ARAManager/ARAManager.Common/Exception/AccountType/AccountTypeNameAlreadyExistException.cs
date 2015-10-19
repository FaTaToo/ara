// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountTypeNameAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the AccountTypeNameAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.AccountType {
    /// <summary>
    /// The type of account has already existed.
    /// </summary>
    [DataContract]
    public class AccountTypeNameAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
