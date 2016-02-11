// --------------------------------------------------------------------------------------------------------------------
/* <header file="CompanyAlreadyDeletedException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the CompanyAlreadyDeletedException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Company
{
    /// <summary>
    ///     The company has been already deleted.
    /// </summary>
    [DataContract]
    public class CompanyAlreadyDeletedException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}