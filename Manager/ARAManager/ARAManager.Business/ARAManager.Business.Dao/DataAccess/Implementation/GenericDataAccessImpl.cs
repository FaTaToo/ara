// --------------------------------------------------------------------------------------------------------------------
// <header file="GenericDataAccessImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the Generic data access class.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using NHibernate;
using NHibernate.Criterion;
using NHibernate.Transform;

namespace ARAManager.Business.Dao.DataAccess.Implementation {
    /// <summary>
    /// Implement generic data access layer
    /// </summary>
    /// <typeparam name="T">type of domain object</typeparam>
    /// <typeparam name="TPk">The type of the pk.</typeparam>
    public class GenericDataAccessImpl<T, TPk> : IGenericDataAccess<T, TPk> {
        #region IMethods

        /// <summary>
        /// Saves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Save(T item) {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                session.SaveOrUpdate(item);
                tr.Complete();
            }
        }

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Object by id.</returns>
        public T GetById(TPk id) {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                var result = session.Get<T>(id);
                tr.Complete();
                return result;
            }
        }

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        public void Delete(T item) {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                session.Delete(item);
                tr.Complete();
            }
        }

        /// <summary>
        /// Finds the by query.
        /// </summary>
        /// <param name="criteria">The criteria.</param>
        /// <returns>list of all items satisfied conditions.</returns>
        public IList<T> FindByCriteria(DetachedCriteria criteria) {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                var result = criteria.GetExecutableCriteria(session).List<T>();
                result = result ?? new List<T>();
                tr.Complete();
                return result;
            }
        }

        /// <summary>
        /// Finds the by SQL query.
        /// </summary>
        /// <typeparam name="TD">The type of the D.</typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>List of items get by sql query</returns>
        public IList<TD> FindBySqlQuery<TD>(string sqlQuery, Dictionary<string, object> parameters) where TD : class  {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                var query = session.CreateSQLQuery(sqlQuery);
                var result = FindByQuery<TD>(query, parameters);
                tr.Complete();
                return result;
            }
        }

        /// <summary>
        /// Finds the by HQL query.
        /// </summary>
        /// <typeparam name="TD">The type of the D.</typeparam>
        /// <param name="hqlQuery">The HQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>List of items get by sql query</returns>
        public IList<TD> FindByHqlQuery<TD>(string hqlQuery, Dictionary<string, object> parameters) {
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                var session = tr.GetSession();
                var query = session.CreateQuery(hqlQuery);
                var result = FindByQuery<TD>(query, parameters);
                tr.Complete();
                return result;
            }
        }

        /// <summary>
        /// Finds the by query.
        /// </summary>
        /// <typeparam name="TD">The type of the D.</typeparam>
        /// <param name="query">The query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>List of items get by sql query</returns>
        private IList<TD> FindByQuery<TD>(IQuery query, Dictionary<string, object> parameters) {
            foreach (var parameter in parameters) {
                query.SetParameter(parameter.Key, parameter.Value);
            }

            query.SetResultTransformer(Transformers.AliasToBean<TD>());
            var result = query.List<TD>();
            return result;
        }

        #endregion IMethods
    }
}
