﻿// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICustomerServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *       Implement the ICustomerServiceImpl.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Customer;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services
{
    [ServiceContract]
    public interface ICustomerServiceImpl
    {
        [OperationContract]
        [PreserveReferences]
        Customer GetCustomerById(int customerId);

        [OperationContract]
        [PreserveReferences]
        IList<Customer> GetAllCustomers();

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof (ConcurrentUpdateException))]
        void SaveNewCustomer(Customer customer);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof (CustomerAlreadyDeletedException))]
        void DeleteCustomer(int customerId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof (CustomerAlreadyDeletedException))]
        void DeleteCustomers(List<int> customers);

        [OperationContract]
        [PreserveReferences]
        IList<Customer> SearchCustomer(string firstname, string lastname, string email, string phone, string username);

        [OperationContract]
        [PreserveReferences]
        int CountCustomers();
    }
}