// --------------------------------------------------------------------------------------------------------------------
// <header file="IGenericDataAccess.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the IGenericDataAccess.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using NHibernate.Criterion;

namespace ARAManager.Business.Dao.DataAccess.Interfaces
{
    /// <summary>
    /// All generic methods of NHibernate
    /// </summary>
    /// <typeparam name="T">type of object</typeparam>
    /// <typeparam name="TPk">type of primary key</typeparam>
    public interface IGenericDataAccess<T, in TPk>
    {
        /// <summary>
        /// Saves the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Save(T item);

        /// <summary>
        /// Gets the by id.
        /// </summary>
        /// <param name="id">The id.</param>
        /// <returns>Item object by id</returns>
        T GetById(TPk id);

        /// <summary>
        /// Deletes the specified item.
        /// </summary>
        /// <param name="item">The item.</param>
        void Delete(T item);

        /// <summary>
        /// Finds the by criteria.
        /// </summary>
        /// <typeparam name="T">type of object.</typeparam>
        /// <param name="criteria">The criteria.</param>
        /// <returns>List of items satisfied criteria.</returns>
        IList<T> FindByCriteria(DetachedCriteria criteria);

        /// <summary>
        /// Finds the by SQL query.
        /// </summary>
        /// <typeparam name="TD">The type of the D.</typeparam>
        /// <param name="sqlQuery">The SQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>list of items get by sql query</returns>
        IList<TD> FindBySqlQuery<TD>(string sqlQuery, Dictionary<string, object> parameters) where TD : class;

        /// <summary>
        /// Finds the by HQL query.
        /// </summary>
        /// <typeparam name="TD">The type of the D.</typeparam>
        /// <param name="hqlQuery">The HQL query.</param>
        /// <param name="parameters">The parameters.</param>
        /// <returns>list of items get by hql query</returns>
        IList<TD> FindByHqlQuery<TD>(string hqlQuery, Dictionary<string, object> parameters);
    }
}