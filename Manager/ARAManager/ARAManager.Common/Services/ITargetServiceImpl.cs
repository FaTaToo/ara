// --------------------------------------------------------------------------------------------------------------------
/* <header file="ITargetServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ITargetServiceImpl.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System.ServiceModel;
using ARAManager.Common.ArResources;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Exception.Target;
using ARAManager.Common.Services.Behaviors;
using RootObject = ARAManager.Common.PresenterJson.ArResources.RootObject;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface ITargetServiceImpl {

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(TargetNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewTarget(Target target, RootObject jsonArResources);
    }
}
