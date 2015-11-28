// --------------------------------------------------------------------------------------------------------------------
/* <header file="NhTransactionScope.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the NhTransactionScope.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Security.Permissions;
using System.Transactions;
using NHibernate;

namespace ARAManager.Business.Dao.NHibernate.Transaction {
    /// <summary>
    /// Wrapper for System.Transactions.TransactionScope that works with NHibernate 
    /// and that remains lightweighted working on a single database (i.e. doesn't propagate to a distributed
    /// transaction using MS DTC service).
    /// </summary>
    /// <remarks>
    /// In order to stay lightweighted, this class links to it's parent scope and
    /// therefore is able to share the session cache with its root scope.
    /// The root scope will then be responsible for closing the connections in its
    /// <c>Dispose()</c> method.
    /// The class cannot prevent a forced distributed connection when the option
    /// <c>RequiresNew</c> is used in the constructor.
    /// </remarks>
    public class NhTransactionScope : IDisposable {
        #region Constants

        /// <summary>
        /// Connection alias key
        /// </summary>
        private const string CONNECTION_ALIAS = "_DefaultConnectionForNH";

        /// <summary>
        /// key of session factory component
        /// </summary>
        private const string NH_SESSION_FACTORY_COMPONENT = "NHibernateSessionFactory";

        #endregion Constants
        #region SFields

        /// <summary>
        /// Field similar to <see cref="System.Transactions.Transaction.Current" /> in oder
        /// to get access to the transaction's root scope where the connection
        /// cache is located.
        /// </summary>
        [ThreadStatic]
        private static NhTransactionScope s_currentScope;

        #endregion SFields
        #region IFields

        /// <summary>
        /// Dictionary of session cache
        /// </summary>
        private Dictionary<string, ISession> m_sessionCache;

        /// <summary>
        ///  Wrapped transaction scope
        /// </summary>
        private TransactionScope m_transactionScope;

        /// <summary>
        ///  Cached 'System.Transactions.Transaction' of this scope.
        /// </summary>
        private System.Transactions.Transaction m_cachedCurrentTransaction;

        /// <summary>
        ///  Saved 'NHTransactionScope.Current', represents a kind of stack frame.
        /// </summary>
        private NhTransactionScope m_savedScope;

        #endregion IFields
        #region IConstructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. Initializes a new instance of the
        /// <see cref="NHibernate.Library.Transaction.NHTransactionScope"/> class.
        /// </summary>
        /// <remarks>
        /// Uses <see cref="System.Transactions.TransactionScopeOption.Required"/>
        /// default for NHTransactionScope inheritance.
        /// </remarks>
        public NhTransactionScope() : this((TransactionScopeOption) TransactionScopeOption.Required) {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. Initializes a new instance of the
        /// <see cref="NHibernate.Library.Transaction.NHTransactionScope"/> class
        /// with the specified requirements.
        /// </summary>
        /// <param name="scopeOption">
        /// An instance of the <see cref="System.Transactions.TransactionScopeOption"/>
        /// enumeration that describes the transaction requirements associated
        /// with this transaction scope.
        /// </param>
        public NhTransactionScope(TransactionScopeOption scopeOption) {
            // No :this(...) -> underlying TransactionScope constructors implementations are different
            m_transactionScope = new TransactionScope(scopeOption);
            InitializeScopeLinking(scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. 
        /// Initializes a new instance of the
        /// <see cref="NHibernate.Library.Transaction.NHTransactionScope"/> class
        /// with the specified timeout value and requirements.
        /// </summary>
        /// <param name="scopeOption">
        /// An instance of the <see cref="System.Transactions.TransactionScopeOption"/>
        /// enumeration that describes the transaction requirements associated
        /// with this transaction scope.
        /// </param>
        /// <param name="scopeTimeout">
        /// The <see cref="System.TimeSpan"/> after which the transaction scope
        /// times out and aborts the transaction.
        /// </param>
        public NhTransactionScope(TransactionScopeOption scopeOption, TimeSpan scopeTimeout) {
            // No :this(...) -> underlying TransactionScope constructors implementations are different
            m_transactionScope = new TransactionScope(scopeOption, scopeTimeout);
            InitializeScopeLinking(scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. 
        /// Initializes a new instance of the
        /// <see>
        ///   <cref>Kaba.Mks.Markets.Service.Base.NHibernate.NHTransactionScope</cref>
        /// </see> class
        /// with the specified requirements.
        /// </summary>
        /// <param name="scopeOption">
        /// An instance of the <see cref="System.Transactions.TransactionScopeOption"/>
        /// enumeration that describes the transaction requirements associated
        /// with this transaction scope.
        /// </param>
        /// <param name="transactionOptions">
        /// A <see cref="System.Transactions.TransactionOptions"/> structure
        /// that describes the transaction options to use if a new transaction
        /// is created. If an existing transaction is used, the timeout value in
        /// this parameter applies to the transaction scope. If that time expires
        /// before the scope is disposed, the transaction is aborted.
        /// </param>
        public NhTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions) {
            // No :this(...) -> underlying TransactionScope constructors implementations are different
            m_transactionScope = new TransactionScope(scopeOption, transactionOptions);
            InitializeScopeLinking(scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. 
        /// Initializes a new instance of the
        /// <see>
        ///   <cref>NHibernate.Library.Transaction.NHTransactionScope</cref>
        /// </see> class
        /// with the specified scope and COM+ interoperability requirements, and
        /// transaction options.
        /// </summary>
        /// <param name="scopeOption">
        /// An instance of the <see cref="System.Transactions.TransactionScopeOption"/>
        /// enumeration that describes the transaction requirements associated with
        /// this transaction scope.
        /// </param>
        /// <param name="transactionOptions">
        /// A <see cref="System.Transactions.TransactionOptions"/> structure that
        /// describes the transaction options to use if a new transaction is created.
        /// If an existing transaction is used, the timeout value in this parameter
        /// applies to the transaction scope. If that time expires before the scope
        /// is disposed, the transaction is aborted.
        /// </param>
        /// <param name="interopOption">
        /// An instance of the <see cref="System.Transactions.EnterpriseServicesInteropOption"/>
        /// enumeration that describes how the associated transaction interacts with
        /// COM+ transactions.
        /// </param>
        /// [SuppressMessage("Microsoft.Usage",
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public NhTransactionScope(TransactionScopeOption scopeOption, TransactionOptions transactionOptions, EnterpriseServicesInteropOption interopOption) {
            m_transactionScope = new TransactionScope(scopeOption, transactionOptions, interopOption);
            InitializeScopeLinking(scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NhTransactionScope" /> class
        /// and sets the specified transaction as the ambient transaction, so
        /// that transactional work done inside the scope uses this transaction.
        /// </summary>
        /// <param name="transactionToUse">
        /// The transaction to be set as the ambient transaction, so that
        /// transactional work done inside the scope uses this transaction.
        /// </param>
        public NhTransactionScope(System.Transactions.Transaction transactionToUse) : this(transactionToUse, TimeSpan.Zero) {
        }

        /// <summary>
        /// Initializes a new instance of the
        /// <see cref="NhTransactionScope" /> class
        /// with the specified timeout value, and sets the specified transaction
        /// as the ambient transaction, so that transactional work done inside the
        /// scope uses this transaction.
        /// </summary>
        /// <param name="transactionToUse">
        /// The transaction to be set as the ambient transaction, so that
        /// transactional work done inside the scope uses this transaction.
        /// </param>
        /// <param name="scopeTimeout">
        /// The <see cref="System.TimeSpan" /> after which the transaction scope
        /// times out and aborts the transaction
        /// </param>
        public NhTransactionScope(System.Transactions.Transaction transactionToUse, TimeSpan scopeTimeout) {
            // No :this(...) -> underlying TransactionScope constructors implementations are different
            // Infer equivalent transaction scope from context (to allow consistent interleaving of TransactionScopes)
            TransactionScopeOption scopeOption = GetTransactionScopeOption(transactionToUse);
            
            // redirect request (System.Transactions.Transaction.Current may change!)
            m_transactionScope = new TransactionScope(transactionToUse, scopeTimeout);
            InitializeScopeLinking(scopeOption);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="NhTransactionScope"/> class. 
        /// Initializes a new instance of the
        /// <see cref="NHibernate.Library.Transaction.NHTransactionScope"/> class
        /// with the specified timeout value and COM+ interoperability requirements,
        /// and sets the specified transaction as the ambient transaction, so
        /// that transactional work done inside the scope uses this transaction.
        /// </summary>
        /// <param name="transactionToUse">
        /// The transaction to be set as the ambient transaction, so that transactional
        /// work done inside the scope uses this transaction.
        /// </param>
        /// <param name="scopeTimeout">
        /// The <see cref="System.TimeSpan"/> after which the transaction scope
        /// times out and aborts the transaction.
        /// </param>
        /// <param name="interopOption">
        /// An instance of the <see cref="System.Transactions.EnterpriseServicesInteropOption"/>
        /// enumeration that describes how the associated transaction interacts with
        /// COM+ transactions.
        /// </param>
        [PermissionSet(SecurityAction.LinkDemand, Name = "FullTrust")]
        public NhTransactionScope(System.Transactions.Transaction transactionToUse, TimeSpan scopeTimeout, EnterpriseServicesInteropOption interopOption) {
            // Infer equivalent transaction scope from context (to allow consistent interleaving of TransactionScopes)
            TransactionScopeOption scopeOption = GetTransactionScopeOption(transactionToUse);

            // Redirect request (System.Transactions.Transaction.Current may change!)
            m_transactionScope = new TransactionScope(transactionToUse, scopeTimeout, interopOption);
            InitializeScopeLinking(scopeOption);
        }

        #endregion IConstructors
        #region SProperties

        /// <summary>
        /// Gets the current.
        /// </summary>
        public static NhTransactionScope Current {
            get {
                return s_currentScope;
            }
        }

        #endregion SProperties
        #region IProperties

        /// <summary>
        /// Gets the transaction scope.
        /// </summary>
        public TransactionScope TransactionScope {
            get {
                return this.m_transactionScope;
            }
        }

        /// <summary>
        /// Gets the transaction.
        /// </summary>
        public System.Transactions.Transaction Transaction {
            get {
                return this.m_cachedCurrentTransaction;
            }
        }

        /// <summary>
        /// Gets the session cache.
        /// </summary>
        /// <remarks>
        /// This access to the internal reference is needed because sub-scopes
        /// must be able to add connections to their root scope cache.
        /// </remarks>
        protected Dictionary<string, ISession> SessionCache {
            get {
                return this.m_sessionCache;
            }
        }

        #endregion IProperties
        #region IMethods

        /// <summary>
        /// Indicates that all operations within the scope are completed successfully.
        /// </summary>
        /// <exception cref="System.InvalidOperationException">
        /// This method has already been called once.
        /// </exception>
        public void Complete()
        {
            PreCompleteTransaction();
            FlushSessions();
            m_transactionScope.Complete();
            PostCompleteTransaction();
        }

        #region Dispose

        /// <summary>
        /// Ends the transaction scope. Removes the frame from the scope calling stack...
        /// (a) and close the sessions / database connections if this scope was the root scope.
        /// (b) Also cleares the cache if the creation of a new transaction was suppressed
        /// or the scope (incl. child scopes) has an exclusive transaction.
        /// In other words: Do not clear the cache if the old current scope will stay alive.
        /// </summary>
        public void Dispose() {
            NhTransactionScope oldCurrent = NhTransactionScope.Current;
            PopAndDropScope();
            try {
                if (NhTransactionScope.Current == null) {
                    // (a) root scope
                    ClearSessionCache();
                }
                else if (oldCurrent != NhTransactionScope.Current) {
                    // (b) RequiresNew or Suppress
                    ClearSessionCache();
                }
            }
            finally {
                m_transactionScope.Dispose();
                m_transactionScope = null;
            }
        }

        #endregion Dispose

        /// <summary>
        /// Returns a NHibernate session operating on a connection for the 
        /// given connectionAlias.
        /// </summary>
        /// <returns>Session object</returns>
        /// [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Design", "CA1024:UsePropertiesWhereAppropriate")]
        public ISession GetSession() {
            return GetOrCreateSession(CONNECTION_ALIAS);
        }

        /// <summary>
        /// Plugin method to execute code after initializing new session cache.
        /// </summary>
        protected virtual void PostInitializeNewSessionCache() {
        }

        /// <summary>
        /// Plugin method to execute code after inheriting session cache.
        /// </summary>
        protected virtual void PostInheritSessionCache() {
        }

        /// <summary>
        /// Disposes a session and closes underlying connection.
        /// </summary>
        /// <param name="session">The session.</param>
        protected virtual void DisposeSession(ISession session) {
            INHibernateSessionFactory factory = this.GetSessionFactory();
            factory.DisposeSession(session);
        }

        /// <summary>
        /// Plugin method to execute code before clearing session cache.
        /// </summary>
        protected virtual void PreClearSessionCache() {
        }

        /// <summary>
        /// Plugin method to execute code after clearing session cache.
        /// </summary>
        protected virtual void PostClearSessionCache() {
        }

        #region Complete

        /// <summary>
        /// Flushed the NHibernate sessions, if FlushMode is not equal to never.
        /// </summary>
        protected virtual void FlushSessions() {
            foreach (ISession session in m_sessionCache.Values) {
                if (session.FlushMode != FlushMode.Never) {
                    session.Flush(); // flush the session before transaction commit, like nhibernate does.
                }
            }
        }

        /// <summary>
        /// Plugin method to execute code before transactionscope complete.
        /// </summary>
        protected virtual void PreCompleteTransaction() {
        }

        /// <summary>
        /// Plugin method to execute code  after transactionscope complete.
        /// </summary>
        protected virtual void PostCompleteTransaction()
        {
        }

        /// <summary>
        /// Create a new session using the INHibernateSessionFactory.
        /// </summary>
        /// <param name="connectionAlias">alias of connnection string</param>
        /// <returns>Session object</returns>
        protected virtual ISession CreateNewSession(string connectionAlias) {
            INHibernateSessionFactory factory = GetSessionFactory();
            ISession session = factory.CreateSession(connectionAlias);
            return session;
        }

        #endregion Complete

        #region InitializeScope

        /// <summary>
        /// Initializes a new session cache (if not inherited from ambient
        /// transaction) and updates the linking to the root scope.
        /// </summary>
        /// <param name="scopeOption">The scope option.</param>
        private void InitializeScopeLinking(TransactionScopeOption scopeOption) {
            if (IsRootLightweightTransactionScope()) {
                InitializeRootScope(scopeOption);
            }
            else {
                InitializeChildScope(scopeOption);
            }

            CacheCurrentTransaction();
        }

        /// <summary>
        /// Checks if this scope is a root lightweight transaction scope.
        /// </summary>
        /// <returns>Transaction scope isroot light weight</returns>
        private bool IsRootLightweightTransactionScope() {
            return Current == null;
        }

        /// <summary>
        /// Caches the currently used transaction.
        /// </summary>
        private void CacheCurrentTransaction() {
            m_cachedCurrentTransaction = System.Transactions.Transaction.Current;
        }

        /// <summary>
        /// Initializes the current scope as a new child scope (= non root).
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption to use.</param>
        private void InitializeChildScope(TransactionScopeOption scopeOption) {
            switch (scopeOption) {
                case TransactionScopeOption.Required:
                    // Inherit session cache & keep current root scope
                    InheritSessionCache();
                    Debug.WriteLine("Should conflict");
                    PushScope(Current);
                    break;
                case TransactionScopeOption.RequiresNew:
                    // Create new session cache & become new root scope
                    InitializeNewSessionCache();
                    PushScope(this);
                    break;
                case TransactionScopeOption.Suppress:
                    // Create new session cache & break scope chain
                    InitializeNewSessionCache();
                    PushScope(null);
                    break;
            }
        }

        /// <summary>
        /// Returns what kind of TransactionScopeOption this NHTransactionScope
        /// shall use.
        /// </summary>
        /// <param name="transaction">transation object</param>
        /// <returns>Transation scope</returns>
        private TransactionScopeOption GetTransactionScopeOption(System.Transactions.Transaction transaction) {
            if (transaction == System.Transactions.Transaction.Current) {
                // Reuse same transaction
                return TransactionScopeOption.Required;
            } else {
                return TransactionScopeOption.RequiresNew;
            }
        }

        /// <summary>
        /// Initializes the current scope as a new root scope.
        /// </summary>
        /// <param name="scopeOption">TransactionScopeOption to use.</param>
        private void InitializeRootScope(TransactionScopeOption scopeOption)  {
            // create new connection cache in every case.
            InitializeNewSessionCache();

            // Check for client option request.
            if (scopeOption == TransactionScopeOption.Required || scopeOption == TransactionScopeOption.RequiresNew) {
                // Become root of the scope chain/transaction.
                PushScope(this);
            }
            else {
                // Request == TransactionScopeOption.Suppress
                // --> break scope chain a don't take part in any transaction
                PushScope(null);
            }
        }

        #endregion InitializeScope
        #region PushPop

        /// <summary>
        /// Add <c>scope</c> on top of the scope calling stack. Will be removed during
        /// <c>Dispose()</c>.
        /// </summary>
        /// <param name="scope">
        /// Scope to be pushed on the calling stack.
        /// </param>
        /// <remarks>
        /// Stack structure may contain redundant frames, but this keeps a consistent
        /// stack access in the code.
        /// Call  stack: | scopeA | scopeB | scopeB1 | scopeC  | scodeD | scopeE
        /// Saved value: | null   | scopeA | scopeB  | scopeB  | null   | scopeD
        /// Current val: | scopeA | scopeB | scopeB  | null    | scopeD | scopeE
        /// </remarks>
        private void PushScope(NhTransactionScope scope) {
            m_savedScope = s_currentScope;
            s_currentScope = scope;
        }

        /// <summary>
        /// Pops the top most stack frame from the scope calling stack and drops
        /// its content because it's no longer needed.
        /// </summary>
        /// <remarks>
        /// This won't necessarily exchange the <c>LightweightedTransactionScope.Current</c>.
        /// </remarks>
        private void PopAndDropScope() {
            s_currentScope = m_savedScope;
        }

        #endregion PushPop
        #region InitializeNewSessionCache
        /// <summary>
        /// Sets up a new session cache with default size.
        /// </summary>
        private void InitializeNewSessionCache() {
            m_sessionCache = new Dictionary<string, ISession>();
            PostInitializeNewSessionCache();
        }

        #endregion InitializeNewSessionCache
        #region InheritSessionCache

        /// <summary>
        /// Inherits the session cache from the ambient transaction (root scope).
        /// </summary>
        private void InheritSessionCache() {
            m_sessionCache = Current.SessionCache;
            PostInheritSessionCache();
        }

        #endregion InheritSessionCache
        #region ClearSessionCache

        /// <summary>
        /// Clears the session cache by closing all contained sessions.
        /// </summary>
        private void ClearSessionCache() {
            PreClearSessionCache();
            foreach (KeyValuePair<string, ISession> pair in this.m_sessionCache) {
                // delegate to session factory
                DisposeSession(pair.Value);
            }

            PostClearSessionCache();
            m_sessionCache.Clear();
            m_sessionCache = null;
        }

        #endregion ClearConnectionCache

        /// <summary>
        /// Gets the or create session.
        /// </summary>
        /// <param name="connectionAlias">The connection alias.</param>
        /// <returns>Session object</returns>
        private ISession GetOrCreateSession(string connectionAlias) {
            ISession session = null;
            if (!m_sessionCache.TryGetValue(connectionAlias, out session)) {
                session = CreateNewSession(connectionAlias);
                m_sessionCache.Add(connectionAlias, session);
            }

            return session;
        }

        /// <summary>
        /// Gets the session factory.
        /// </summary>
        /// <returns>session factory</returns>
        private INHibernateSessionFactory GetSessionFactory() {
            return new NHibernateSessionFactory();
        }

        #endregion IMethods
    }
}
