// --------------------------------------------------------------------------------------------------------------------
// <header file="DbDeadLockException.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the DeadLock exception.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Runtime.Serialization;
using NHibernate;

namespace ARAManager.Business.Dao.NHibernate.Exception
{
    /// <summary>
    /// The transaction has been chosen as deadlock victim.
    /// </summary>
    [Serializable]
    public class DbDeadLockException : ADOException {
        /// <summary>
        /// Initializes a new instance of the <see cref="DbDeadLockException"/> class.
        /// </summary>
        /// <param name="info">The <see cref="T:System.Runtime.Serialization.SerializationInfo"/> that holds the serialized object
        /// data about the exception being thrown.</param>
        /// <param name="context">The <see cref="T:System.Runtime.Serialization.StreamingContext"/> that contains contextual information about the source or destination.</param>
        public DbDeadLockException(SerializationInfo info, StreamingContext context) : base(info, context) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DbDeadLockException"/> class.
        /// </summary>
        /// <param name="message">The message.</param>
        /// <param name="innerException">The inner exception.</param>
        public DbDeadLockException(string message, System.Exception innerException) : base(message, innerException) {
        }
    }
}