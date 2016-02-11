// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the service class for Customer.
 * </summary>
 * <Problems>
 * </Problems>
*/
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

namespace ARAManager.Business.Service.Services
{
    /// <summary>
    ///     Services of Customers.
    /// </summary>
    public class CustomerServiceImpl : ICustomerServiceImpl
    {
        #region IMethods

        /// <summary>
        ///     Get customer by customer id
        /// </summary>
        /// <param name="customerId"></param>
        /// <returns></returns>
        public Customer GetCustomerById(int customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            return srvDao.GetById(customerId);
        }

        /// <summary>
        ///     Get all customers
        /// </summary>
        /// <returns></returns>
        public IList<Customer> GetAllCustomers()
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            var criteria = DetachedCriteria.For<Customer>();
            return srvDao.FindByCriteria(criteria);
        }

        /// <summary>
        ///     Save new customer
        /// </summary>
        /// <param name="customer"></param>
        public void SaveNewCustomer(Customer customer)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(customer);
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException
                        {
                            MessageError = Dictionary.CUSTOMER_CONCURRENT_UPDATE_EXCEPTION_MSG
                        },
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

        /// <summary>
        ///     Delete customer by customer id
        /// </summary>
        /// <param name="customerId"></param>
        public void DeleteCustomer(int customerId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteCustomer = srvDao.GetById(customerId);
                    srvDao.Delete(deleteCustomer);
                }
                catch (Exception)
                {
                    throw new FaultException<CustomerAlreadyDeletedException>(
                        new CustomerAlreadyDeletedException {MessageError = Dictionary.CUSTOMER_DELETED_EXCEPTION_MSG},
                        new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }

        /// <summary>
        ///     Delete the list of customers by list of customers id
        /// </summary>
        /// <param name="customers"></param>
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
                        new CustomerAlreadyDeletedException {MessageError = Dictionary.CUSTOMER_DELETED_EXCEPTION_MSG},
                        new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
                }
            }
        }

        /// <summary>
        ///     Search customers by firstname, lastname, email, phone and username
        /// </summary>
        /// <param name="firstname"></param>
        /// <param name="lastname"></param>
        /// <param name="email"></param>
        /// <param name="phone"></param>
        /// <param name="username"></param>
        /// <returns></returns>
        public IList<Customer> SearchCustomer(string firstname, string lastname, string email, string phone,
            string username)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            var criteria = DetachedCriteria.For<Customer>();

            if (!string.IsNullOrEmpty(firstname))
            {
                criteria.Add(Restrictions.Where<Customer>(c => c.FirstName == firstname));
            }

            if (!string.IsNullOrEmpty(lastname))
            {
                criteria.Add(Restrictions.Where<Customer>(c => c.LastName == lastname));
            }

            if (!string.IsNullOrEmpty(email))
            {
                criteria.Add(Restrictions.Where<Customer>(c => c.Email == email));
            }

            if (!string.IsNullOrEmpty(phone))
            {
                criteria.Add(Restrictions.Where<Customer>(c => c.Phone == phone));
            }

            if (!string.IsNullOrEmpty(username))
            {
                criteria.Add(Restrictions.Where<Customer>(c => c.UserName == username));
            }

            var result = srvDao.FindByCriteria(criteria);
            return result;
        }

        /// <summary>
        ///     Count the number of customers
        /// </summary>
        /// <returns></returns>
        public int CountCustomers()
        {
            return GetAllCustomers().Count;
        }

        #endregion IMethods
    }
}