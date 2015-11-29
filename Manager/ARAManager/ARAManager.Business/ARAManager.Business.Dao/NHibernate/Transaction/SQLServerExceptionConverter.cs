// --------------------------------------------------------------------------------------------------------------------
/* <header file="SqlServerExceptionConverter.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the SqlServerExceptionConverter.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Data.SqlClient;
using ARAManager.Business.Dao.NHibernate.Exception;
using NHibernate;
using NHibernate.Exceptions;

namespace ARAManager.Business.Dao.NHibernate.Transaction {
    /// <summary>
    /// Exception converter to convert sql server DBException to some more specific ones.
    /// </summary>
    /// <remarks>The converter is enabled via nhibernate configuration:
    /// <example>
    /// <![CDATA[
    ///   <property name="sql_exception_converter">Kaba.Mks.Markets.Service.Base.NHibernate.SQLServerExceptionConverter, Kaba.Mks.Markets.Service.Base.NHibernate</property> 
    /// ]]>
    /// </example>
    /// </remarks>
    public class SqlServerExceptionConverter : ISQLExceptionConverter {
        /// <summary>
        /// Converts the db specific exceptions to something more usable.
        /// </summary>
        /// <param name="exInfo">The exception info.</param>
        /// <returns>Exception thrown</returns>
        public System.Exception Convert(AdoExceptionContextInfo exInfo) {
            SqlException sqle = ADOExceptionHelper.ExtractDbException(exInfo.SqlException) as SqlException;
            System.Exception finalException = this.Convert(sqle, exInfo);

            return finalException;
        }

        /// <summary>
        /// Wraps the connection SQL exception.
        /// </summary>
        /// <param name="ex">The ex.</param>
        /// <returns>Wrapped connection exception</returns>
        public System.Exception WrapConnectionSqlException(SqlException ex) {
            return Convert(ex, null);
        }

        /// <summary>
        /// Converts the specified sqle.
        /// </summary>
        /// <param name="sqle">The sqle.</param>
        /// <param name="exInfo">The ex info.</param>
        /// <returns>Exception thrown by NHibernate</returns>
        private System.Exception Convert(SqlException sqle, AdoExceptionContextInfo exInfo) {
            System.Exception finalException;
            if (sqle != null) {
                switch (sqle.Number) {
                    case 17:
                    // SQL Server does not exist or access denied. 
                    case 4060:
                    // Invalid Database 
                    case 18456:
                        // Login Failed 
                        finalException = new DbLoginException(sqle.Message, sqle);
                        break;

                    case 1205:
                        // DeadLock Victim 
                        finalException =
                           new DbDeadLockException(sqle.Message, sqle);
                        break;

                    case 2627:
                    case 2601:
                        // Unique Index/Constriant Violation 
                        finalException =
                           new DbUniqueConstraintException(sqle.Message, sqle);
                        break;
                    case 547:
                        finalException =
                           new DbForeignKeyException(sqle.Message, sqle);
                        break;

                    case 208:
                        finalException =
                            new SQLGrammarException(
                                    exInfo.Message, sqle.InnerException, exInfo.Sql);
                        break;

                    case 3960: // in case of snapshot isolation
                        finalException =
                            new StaleObjectStateException(exInfo.EntityName, exInfo.EntityId);
                        break;

                    default:
                        finalException =
                           SQLStateConverter.HandledNonSpecificException(exInfo.SqlException, exInfo.Message, exInfo.Sql);
                        break;
                }
            } else {
                finalException = SQLStateConverter.HandledNonSpecificException(exInfo.SqlException, exInfo.Message, exInfo.Sql);
            }
            return finalException;
        }
    }
}