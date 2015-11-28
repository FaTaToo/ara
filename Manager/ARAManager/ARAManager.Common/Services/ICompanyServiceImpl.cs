// --------------------------------------------------------------------------------------------------------------------
/* <header file="ICompanyServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ICompanyServiceImpl.
 * </summary>
 * <Problems>
 * </Problems>
*/
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

        [OperationContract]
        [PreserveReferences]
        IList<Company> SearchCompany(string name, string email, string phone, string username);

        [OperationContract]
        [PreserveReferences]
        int AuthenticateUser(string username, string password);

        [OperationContract]
        [PreserveReferences]
        Company GetCompanyByUserName(string userName);

        [OperationContract]
        [PreserveReferences]
        int CountCompany();
    }
}
