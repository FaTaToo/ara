// --------------------------------------------------------------------------------------------------------------------
// <header file="ICustomerServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ICustomerServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.ServiceModel;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ICustomerServiceImpl {
        [OperationContract]
        void DoWork();
    }
}
