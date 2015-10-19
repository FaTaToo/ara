// --------------------------------------------------------------------------------------------------------------------
// <header file="CompanyPhoneAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CompanyPhoneAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Company {
    /// <summary>
    /// The phone number has already existed.
    /// </summary>
    [DataContract]
    public class CompanyPhoneAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
