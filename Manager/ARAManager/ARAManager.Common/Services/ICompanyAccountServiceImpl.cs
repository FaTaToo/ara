// --------------------------------------------------------------------------------------------------------------------
// <header file="ICompanyAccountServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ICompanyAccountServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ServiceModel;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ICompanyAccountServiceImpl {
        [OperationContract]
        void DoWork();
    }
}
