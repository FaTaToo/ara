// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Account.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
    /// <summary>
    /// Services of Account
    /// </summary>
    public class AccountServiceImpl : IAccountServiceImpl {
        #region IMethods
        /// <summary>
        /// Get account by account id.
        /// </summary>
        /// <param name="accountId"></param>
        /// <returns></returns>
        public Account GetAccountById(int accountId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountDataAccess>();
            return srvDao.GetById(accountId);
        }
        /// <summary>
        /// Get all root accounts of companies and customers.
        /// </summary>
        /// <returns></returns>
        public IList<Account> GetAllAccounts() {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountDataAccess>();
            var criteria = DetachedCriteria.For<Account>();
            return srvDao.FindByCriteria(criteria);
        }
        /// <summary>
        /// Save new account
        /// </summary>
        /// <param name="account"></param>
        public void SaveNewAccount(Account account) {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                try {
                    srvDao.Save(account);
                }
                catch (ADOException) {
                    throw new FaultException<UserNameAlreadyExistException>(
                        new UserNameAlreadyExistException { MessageError = Messages.USERNAME_CONSTRAINT_EXCEPTION_MSG},
                        new FaultReason(Messages.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                }
                catch (StaleObjectStateException) {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException { MessageError = Messages.ACCOUNT_CONCURRENT_UPDATE_EXCEPTION_MSG},
                        new FaultReason(Messages.CONCURRENT_UPDATE_EXCEPTION_REASON));
                } catch (Exception ex) {
                    throw new FaultException<Exception>(
                       new Exception(ex.Message),
                       new FaultReason(Messages.UNKNOWN_REASON)); 
                }
                tr.Complete();
            }
        }
        /// <summary>
        /// Delete account by account id.
        /// </summary>
        /// <param name="accountId"></param>
        public void DeleteAccount(int accountId) {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                try
                {
                    var deleteAccount = srvDao.GetById(accountId);
                    srvDao.Delete(deleteAccount);
                }
                catch (Exception){
                    throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Messages.ACCOUNT_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }
        /// <summary>
        /// Delete all account(s) in list of account(s)
        /// </summary>
        /// <param name="accounts"></param>
        public void DeleteAccounts(List<int> accounts) {
            foreach (var account in accounts) {
                try {
                    DeleteAccount(account);
                } catch (Exception) {
                    throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Messages.ACCOUNT_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.DELETED_EXCEPTION_REASON));
                }
            }
        }

        public int CheckLogin(string username, string password)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountDataAccess>();
            var criteria = DetachedCriteria.For<Account>();
            return 0;
        }
        #endregion IMethods
    }
}
