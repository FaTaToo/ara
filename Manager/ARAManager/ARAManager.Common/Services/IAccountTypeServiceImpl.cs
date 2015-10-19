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

using System.ServiceModel;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface IAccountTypeServiceImpl {
        [OperationContract]
        void DoWork();
    }
}
