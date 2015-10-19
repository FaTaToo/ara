// --------------------------------------------------------------------------------------------------------------------
// <header file="CompanyEmailAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the CompanyEmailAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Company {
    /// <summary>
    /// The email has already existed.
    /// </summary>
    [DataContract]
    public class CompanyEmailAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
