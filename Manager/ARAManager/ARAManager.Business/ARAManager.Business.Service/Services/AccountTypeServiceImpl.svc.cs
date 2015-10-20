// --------------------------------------------------------------------------------------------------------------------
// <header file="AccountTypeServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Account type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.AccountType;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
    public class AccountTypeServiceImpl : IAccountTypeServiceImpl {
        #region IMethods
        public AccountType GetAccountTypeById(int accountTypeId) {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountTypeDataAccess>();
            return srvDao.GetById(accountTypeId);
        }

        public IList<AccountType> GetAllAccountTypes() {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountTypeDataAccess>();
            var criteria = DetachedCriteria.For<AccountType>();
            return srvDao.FindByCriteria(criteria);
        }

        public void SaveNewAccountType(AccountType accountType) {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountTypeDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                try {
                    srvDao.Save(accountType);
                } catch (ADOException) {
                    throw new FaultException<AccountTypeNameAlreadyExistException>(
                        new AccountTypeNameAlreadyExistException { MessageError = Messages.ACCOUNTTYPE_NAME_CONSTRAINT_EXCEPTION_MSG},
                        new FaultReason(Messages.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                } catch (StaleObjectStateException) {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException { MessageError = Messages.ACCOUNTTYPE_CONCURRENT_UPDATE_EXCEPTION_MSG},
                        new FaultReason(Messages.CONCURRENT_UPDATE_EXCEPTION_REASON));
                } catch (Exception ex) {
                    throw new FaultException<Exception>(
                       new Exception(ex.Message),
                       new FaultReason(Messages.UNKNOWN_REASON));
                }
                tr.Complete();
            }
        }

        public void DeleteAccountType(int accountTypeId) {
            var srvDao = NinjectKernelFactory.Kernel.Get<IAccountTypeDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
                try {
                    var deleteAccountType = srvDao.GetById(accountTypeId);
                    srvDao.Delete(deleteAccountType);
                }
                catch (Exception) {
                    throw new FaultException<AccountTypeAlreadyDeletedException>(
                       new AccountTypeAlreadyDeletedException { MessageError = Messages.ACCOUNTTYPE_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }
        public void DeleteAccountTypes(List<int> accountTypes)
        {
            foreach (var accounType in accountTypes) {
                try {
                    DeleteAccountType(accounType);
                }
                catch (Exception) {
                    throw new FaultException<AccountTypeAlreadyDeletedException>(
                       new AccountTypeAlreadyDeletedException { MessageError = Messages.ACCOUNTTYPE_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.DELETED_EXCEPTION_REASON));
                }
            }
        }
        #endregion IMethods
    }
}
