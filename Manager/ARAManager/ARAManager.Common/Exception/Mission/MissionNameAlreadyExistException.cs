// --------------------------------------------------------------------------------------------------------------------
// <header file="MissionNameAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the MissionNameAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Mission {
    /// <summary>
    /// The mission name has already deleted.
    /// </summary>
    [DataContract]
    public class MissionNameAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}
