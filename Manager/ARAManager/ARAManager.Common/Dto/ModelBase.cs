// --------------------------------------------------------------------------------------------------------------------
/* <header file="ModelBase.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *       Implement the ModelBase.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Runtime.Serialization;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Common.Dto
{
    [DataContract]
    public class ModelBase
    {
        #region IProperties

        /// <summary>
        ///     Gets the row version.
        /// </summary>
        /// <value>The row version.</value>
        [Version(Name = "RowVersion", Column = "RowVersion", Generated = VersionGeneration.Always, Type = "BinaryBlob")]
        [DataMember]
        public virtual byte[] RowVersion { get; set; }

        #endregion IProperties
    }
}