﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="TargetAlreadyDeletedException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the TargetAlreadyDeletedException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Target {
    /// <summary>
    /// The target has been already deleted.
    /// </summary>
    [DataContract]
    public class TargetAlreadyDeletedException {
        [DataMember]
        public string MessageError { get; set; }
    }
}