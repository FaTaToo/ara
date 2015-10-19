// --------------------------------------------------------------------------------------------------------------------
// <header file="InvalidDataException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the InvalidDataException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic {
    /// <summary>
    /// Invalid input data
    /// </summary>
    [DataContract]
    public class InvalidDataException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
