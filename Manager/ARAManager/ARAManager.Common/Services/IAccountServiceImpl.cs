// --------------------------------------------------------------------------------------------------------------------
// <header file="IAccountServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the IAccountServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface IAccountServiceImpl
    {
        [OperationContract]
        [PreserveReferences]
        Account GetAccountById(int accountId);

        [OperationContract]
        [PreserveReferences]
        IList<Account> GetAllAccounts();

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(UserNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewAccount(Account account);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void DeleteAccount(int accountId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void DeleteAccounts(List<int> accounts);
    }
}
