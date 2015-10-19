// --------------------------------------------------------------------------------------------------------------------
// <header file="EmailAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the EmailAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic
{
    /// <summary>
    /// The email has already existed.
    /// </summary>
    [DataContract]
    public class EmailAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}
