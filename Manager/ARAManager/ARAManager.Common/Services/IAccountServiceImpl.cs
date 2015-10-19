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
        void SaveNewAccount(Account account);

        [OperationContract]
        [PreserveReferences]
        void DeleteAccount(int accountId);

        [OperationContract]
        [PreserveReferences]
        void DeleteAccounts(List<int> accounts);
    }
}
