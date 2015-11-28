// --------------------------------------------------------------------------------------------------------------------
/* <header file="DbLoginException.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the Login exception.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using NHibernate;

namespace ARAManager.Business.Dao.NHibernate.Exception {
    /// <summary>
    /// DB Login Failed or SQL Server is not reachable.
    /// </summary>
    [Serializable]
    public class DbLoginException : ADOException {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbLoginException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object
        /// data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        public DbLoginException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbLoginException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DbLoginException(string message, System.Exception innerException) : base(message, innerException) {
        }
    }
}