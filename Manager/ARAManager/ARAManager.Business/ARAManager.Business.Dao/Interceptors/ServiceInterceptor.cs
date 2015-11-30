// --------------------------------------------------------------------------------------------------------------------
/* <header file="ServiceInterceptor.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *       Implement the ServiceInterceptor.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using ARAManager.Business.Dao.NHibernate.Transaction;
using log4net;
using Ninject.Extensions.Interception;

namespace ARAManager.Business.Dao.Interceptors
{
    /// <summary>
    ///     Class summary.
    /// </summary>
    public class ServiceInterceptor : IInterceptor
    {
        #region SFields

        /// <summary>
        ///     Logger object.
        /// </summary>
        private static readonly ILog s_classTracer = LogManager.GetLogger(
            typeof (ServiceInterceptor));

        #endregion SFields

        #region IMethods

        /// <summary>
        ///     Intercepts the specified invocation.
        /// </summary>
        /// <param name="invocation">The invocation to intercept.</param>
        public void Intercept(IInvocation invocation)
        {
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                s_classTracer.Info("Enter method " + invocation.Request.Target + "." + invocation.Request.Method.Name);
                invocation.Proceed();
                s_classTracer.Info("Exit method " + invocation.Request.Target + "." + invocation.Request.Method.Name);

                tr.Complete();
            }
        }

        #endregion IMethods
    }
}