// --------------------------------------------------------------------------------------------------------------------
// <header file="IAccountTypeServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the IAccountTypeServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.AccountType;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface IAccountTypeServiceImpl {
        [OperationContract]
        [PreserveReferences]
        AccountType GetAccountTypeById(int accountTypeId);

        [OperationContract]
        [PreserveReferences]
        IList<AccountType> GetAllAccountTypes();

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(AccountTypeNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewAccountType(AccountType accountType);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void DeleteAccountType(int accountTypeId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void DeleteAccountTypes(List<int> accountTypes);
    }
}
