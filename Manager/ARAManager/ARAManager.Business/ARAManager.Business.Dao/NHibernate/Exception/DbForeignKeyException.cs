// --------------------------------------------------------------------------------------------------------------------
// <header file="DbForeignKeyException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ForeignKey exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using NHibernate;

namespace ARAManager.Business.Dao.NHibernate.Exception
{
    /// <summary>
    /// A foreign key constraint was violated.
    /// </summary>
    [Serializable]
    public class DbForeignKeyException : ADOException {
        #region IConstructors

        /// <summary>
        /// Initializes a new instance of the <see cref="DbForeignKeyException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object
        /// data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        public DbForeignKeyException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbForeignKeyException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DbForeignKeyException(string message, System.Exception innerException) : base(message, innerException) {
        }

        #endregion IConstructors
    }
}