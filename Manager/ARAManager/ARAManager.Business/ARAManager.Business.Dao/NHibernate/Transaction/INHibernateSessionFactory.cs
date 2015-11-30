// --------------------------------------------------------------------------------------------------------------------
/* <header file="INHibernateSessionFactory.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the INHibernateSessionFactory.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using NHibernate;
using NHibernate.Cfg;

namespace ARAManager.Business.Dao.NHibernate.Transaction
{
    /// <summary>
    ///     Components implementing this interface are responsible for
    ///     creating the nhibernate sessions.
    /// </summary>
    /// <remarks>
    ///     <list type="bullet">
    ///         <item>
    ///             <term>
    ///                 Multiple definitions of this interface are not allowed.
    ///             </term>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 This interface is for infrastructure purpose only.
    ///             </term>
    ///         </item>
    ///         <item>
    ///             <term>
    ///                 Assumptions:
    ///                 <list type="bullet">
    ///                     <item>
    ///                         <term>
    ///                             The session factory is expensive to create, therefore an implementation should
    ///                             cache the session factory.
    ///                         </term>
    ///                     </item>
    ///                     <item>
    ///                         <term>
    ///                             To implementation should check, that the nhibernate config can be found and is valid during
    ///                             startup.
    ///                             This can be done by creating the factory during startup.
    ///                         </term>
    ///                     </item>
    ///                 </list>
    ///             </term>
    ///         </item>
    ///     </list>
    /// </remarks>
    public interface INHibernateSessionFactory
    {
        #region IMethods

        /// <summary>
        ///     Returns the NHibernate session for the specified connection alias.
        /// </summary>
        /// <param name="connectionAlias"> alias of connection </param>
        /// <returns>created session</returns>
        ISession CreateSession(string connectionAlias);

        /// <summary>
        ///     Disposes the session.
        /// </summary>
        /// <param name="session">The session.</param>
        void DisposeSession(ISession session);

        /// <summary>
        ///     Returns the NHibernate configuration for the specified connection alias.
        /// </summary>
        /// <param name="connectionAlias">The connection alias.</param>
        /// <returns>NHibernate configuration</returns>
        Configuration GetConfiguration(string connectionAlias);

        #endregion IMethods
    }
}