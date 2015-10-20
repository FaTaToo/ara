﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="ICompanyServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ICompanyServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Company;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ICompanyServiceImpl {
        [OperationContract]
        [PreserveReferences]
        Company GetCompanyById(int companyId);

        [OperationContract]
        [PreserveReferences]
        IList<Company> GetAllCompanies();

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CompanyNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewCompany(Company company);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CompanyAlreadyDeletedException))]
        void DeleteCompany(int companyId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(CompanyAlreadyDeletedException))]
        void DeleteCompanies(List<int> companies);
    }
}
