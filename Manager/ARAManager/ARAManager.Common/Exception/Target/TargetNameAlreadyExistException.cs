﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="TargetNameAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the TargetNameAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Target {
    /// <summary>
    /// The target name has already existed.
    /// </summary>
    [DataContract]
    public class TargetNameAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}