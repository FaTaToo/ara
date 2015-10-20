// --------------------------------------------------------------------------------------------------------------------
// <header file="IMissionServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the IMissionServiceImpl.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Exception.Mission;
using ARAManager.Common.Services.Behaviors;

namespace ARAManager.Common.Services {
    [ServiceContract]
    public interface IMissionServiceImpl {
        [OperationContract]
        [PreserveReferences]
        Mission GetMissionTypeById(int missionId);

        [OperationContract]
        [PreserveReferences]
        IList<Mission> GetAllMissionsOfTheCampaign(Campaign campaign);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(MissionNameAlreadyExistException))]
        [FaultContract(typeof(ConcurrentUpdateException))]
        void SaveNewMission(Mission mission);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(MissionAlreadyDeletedException))]
        void DeleteMission(int missionId);

        [OperationContract]
        [PreserveReferences]
        [FaultContract(typeof(MissionAlreadyDeletedException))]
        void DeleteMissions(List<int> missions);
    }
}
