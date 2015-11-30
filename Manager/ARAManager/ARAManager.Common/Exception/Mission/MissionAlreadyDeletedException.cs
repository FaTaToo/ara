﻿// --------------------------------------------------------------------------------------------------------------------
/* <header file="MissionAlreadyDeletedException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the MissionAlreadyDeletedException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Mission
{
    /// <summary>
    ///     The mission has been already deleted.
    /// </summary>
    [DataContract]
    public class MissionAlreadyDeletedException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}