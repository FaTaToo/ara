﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="PhoneNumberAlreadyExistException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the PhoneNumberAlreadyExistException.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Generic
{
    /// <summary>
    /// The phone number has already existed.
    /// </summary>
    public class PhoneNumberAlreadyExistException {
        [DataMember]
        public string MessageError { get; set; }
    }
}