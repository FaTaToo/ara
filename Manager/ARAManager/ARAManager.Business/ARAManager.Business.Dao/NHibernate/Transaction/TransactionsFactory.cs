// --------------------------------------------------------------------------------------------------------------------
// <header file="TransactionsFactory.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the TransactionsFactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Globalization;
using System.Transactions;

namespace ARAManager.Business.Dao.NHibernate.Transaction {
    /// <summary>
    /// Factory class for transaction scopes.
    /// Used to provide simple methods to get transactionscope options right.
    /// </summary>
    public static class TransactionsFactory {
        /// <summary>
        /// The default transaction timeout.
        /// </summary>
        public static readonly TimeSpan DefaultTimeOut = TimeSpan.FromSeconds(60);

        /// <summary>
        /// Create a transaction scope with default options
        /// </summary>
        /// <returns>Transaction scope</returns>
        public static NhTransactionScope CreateTransactionScope() {
            return CreateTransactionScope(false);
        }

        /// <summary>
        /// Create a transaction scope with default options. If forceNewScope is true, creates a new scope/new session/transaction.
        /// </summary>
        /// <param name="forceNewScope">Flag to know the new scope must be created</param>
        /// <returns>Transaction scope</returns>
        public static NhTransactionScope CreateTransactionScope(bool forceNewScope) {
            return CreateTransactionScope(forceNewScope, GetTransactionTimeout(forceNewScope));
        }

        /// <summary>
        /// Create a transaction scope with the given options.
        /// </summary>
        /// <param name="forceNewScope">if set to <c>true</c> [force new scope].</param>
        /// <param name="timeout">The timeout.</param>
        /// <returns>transaction scope</returns>
        public static NhTransactionScope CreateTransactionScope(bool forceNewScope, TimeSpan timeout) {
            ValidateTransactionTimeout(timeout);
            TransactionScopeOption scopeoptions = forceNewScope ? TransactionScopeOption.RequiresNew : TransactionScopeOption.Required;
            TransactionOptions transOptions = GetTransactionOptions(timeout);
            return new NhTransactionScope(scopeoptions, transOptions);
        }

        /// <summary>
        /// Gets the transaction timeout.
        /// </summary>
        /// <param name="forceNewScope">if set to <c>true</c> [force new scope].</param>
        /// <returns>Time span</returns>
        private static TimeSpan GetTransactionTimeout(bool forceNewScope) {
            TimeSpan result = DefaultTimeOut;
            if (System.Transactions.Transaction.Current != null && !forceNewScope) {
                result = TimeSpan.Zero;
            }

            return result;
        }

        /// <summary>
        /// Validates the transaction timeout.
        /// </summary>
        /// <param name="timeOut">The time out.</param>
        private static void ValidateTransactionTimeout(TimeSpan timeOut) {
            if (timeOut > TransactionManager.MaximumTimeout) {
                throw new ArgumentException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        "Requested timeout {0} is bigger than TransactionManager.MaximumTimeout {1}. The transaction would therefore abort earlier.",
                        timeOut,
                        TransactionManager.MaximumTimeout));
            }
        }

        /// <summary>
        /// Gets the transaction options.
        /// </summary>
        /// <param name="timeout">The timeout.</param>
        /// <returns>Transaction option</returns>
        private static TransactionOptions GetTransactionOptions(TimeSpan timeout) {
            var options = new TransactionOptions
            {
                Timeout = timeout,
                IsolationLevel = IsolationLevel.ReadCommitted
            };
            return options;
        }
    }
}