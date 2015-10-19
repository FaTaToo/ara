// --------------------------------------------------------------------------------------------------------------------
// <header file="WrongTypeOfGroupAccountException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the WrongTypeOfGroupAccountException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.AccountType {
    /// <summary>
    /// The type of account has been created in wrong group.
    /// </summary>
    [DataContract]
    public class WrongTypeOfGroupAccountException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
