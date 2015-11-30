// --------------------------------------------------------------------------------------------------------------------
/* <header file="CompanyNameAlreadyExistException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the CompanyNameAlreadyExistException.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;

namespace ARAManager.Common.Exception.Company
{
    /// <summary>
    ///     The company name has already existed.
    /// </summary>
    [DataContract]
    public class CompanyNameAlreadyExistException
    {
        [DataMember]
        public string MessageError { get; set; }
    }
}