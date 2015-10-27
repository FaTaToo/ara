// --------------------------------------------------------------------------------------------------------------------
// <header file="CustomerServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Customer.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Customer;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
    public class CustomerServiceImpl : ICustomerServiceImpl {
        #region IMethods
        public Customer GetCustomerById(int customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            return srvDao.GetById(customerId);
        }

        public IList<Customer> GetAllCustomers()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            var criteria = DetachedCriteria.For<Customer>();
            return srvDao.FindByCriteria(criteria);
        }

        public void SaveNewCustomer(Customer customer)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(customer);
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException { MessageError = Dictionary.CUSTOMER_CONCURRENT_UPDATE_EXCEPTION_MSG },
                        new FaultReason(Dictionary.CONCURRENT_UPDATE_EXCEPTION_REASON));
                }
                catch (Exception ex)
                {
                    throw new FaultException<Exception>(
                       new Exception(ex.Message),
                       new FaultReason(Dictionary.UNKNOWN_REASON));
                }
                tr.Complete();
            }
        }

        public void DeleteCustomer(int customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteCustomer = srvDao.GetById(customerId);
                    srvDao.Delete(deleteCustomer);
                }
                catch (Exception)
                {
                    throw new FaultException<CustomerAlreadyDeletedException>(
                       new CustomerAlreadyDeletedException { MessageError = Dictionary.CUSTOMER_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }
        public void DeleteCustomers(List<int> customers)
        {
            foreach (var customer in customers)
            {
                try
                {
                    DeleteCustomer(customer);
                }
                catch (Exception)
                {
                    throw new FaultException<CustomerAlreadyDeletedException>(
                       new CustomerAlreadyDeletedException { MessageError = Dictionary.CUSTOMER_DELETED_EXCEPTION_MSG },
                       new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
            }
        }
        #endregion IMethods
    }
}
