﻿// --------------------------------------------------------------------------------------------------------------------
// <header file="MissionServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Mission.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.AccountType;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Exception.Mission;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
    public class MissionServiceImpl : IMissionServiceImpl {
        #region IMethods
        public Mission GetMissionTypeById(int missionId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            return srvDao.GetById(missionId);
        }

        public IList<Mission> GetAllMissionsOfTheCampaign(Campaign campaign)
        {
            // Fix query later
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            var criteria = DetachedCriteria.For<Mission>();
            return srvDao.FindByCriteria(criteria);
        }

        public void SaveNewMission(Mission mission)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(mission);
                }
                catch (ADOException)
                {
                    throw new FaultException<MissionNameAlreadyExistException>(
                        new MissionNameAlreadyExistException { MessageError = Messages.ACCOUNTTYPE_NAME_CONSTRAINT_EXCEPTION_MSG },
                        new FaultReason(Messages.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException { MessageError = Messages.MISSION_CONCURRENT_UPDATE_EXCEPTION_MSG },
                        new FaultReason(Messages.CONCURRENT_UPDATE_EXCEPTION_REASON));
                }
                catch (Exception ex)
                {
                    throw new FaultException<Exception>(
                       new Exception(ex.Message),
                       new FaultReason(Messages.UNKNOWN_REASON));
                }
                tr.Complete();
            }
        }

        public void DeleteAccountType(int accountTypeId)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<IMissionDataAccess>();
            using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    var deleteAccountType = srvDao.GetById(accountTypeId);
                    srvDao.Delete(deleteAccountType);
                }
                catch (Exception)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Messages.MISSION_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.DELETED_EXCEPTION_REASON));
                }
                tr.Complete();
            }
        }
        public void DeleteAccountTypes(List<int> accountTypes)
        {
            foreach (var accounType in accountTypes)
            {
                try
                {
                    DeleteAccountType(accounType);
                }
                catch (Exception)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Messages.MISSION_DELETED_EXCEPTION_MSG },
                       new FaultReason(Messages.MISSION_DELETED_EXCEPTION_MSG));
                }
            }
        }
        #endregion IMethods
    }
}
