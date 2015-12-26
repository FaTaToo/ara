// --------------------------------------------------------------------------------------------------------------------
/* <header file="TargetServiceImpl.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the service class for Target
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Exception.Target;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using Ninject;

namespace ARAManager.Business.Service.Services
{
    public class TargetServiceImpl : ITargetServiceImpl
    {
        #region IMethods

        public void SaveNewTarget(Target target)
        {
            var srvDao = NinjectKernelFactory.Kernel.Get<ITargetDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(target);
                }
                catch (ADOException)
                {
                    throw new FaultException<TargetNameAlreadyExistException>(
                        new TargetNameAlreadyExistException
                        {
                            MessageError = Dictionary.TARGET_NAME_CONSTRAINT_EXCEPTION_MSG
                        },
                        new FaultReason(Dictionary.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
                }
                catch (StaleObjectStateException)
                {
                    throw new FaultException<ConcurrentUpdateException>(
                        new ConcurrentUpdateException {MessageError = Dictionary.TARGET_CONCURRENT_UPDATE_EXCEPTION_MSG},
                        new FaultReason(Dictionary.TARGET_NAME_CONSTRAINT_EXCEPTION_MSG));
                }
                catch (Exception ex)
                {
                    throw new FaultException<Exception>(
                        new Exception(ex.Message),
                        new FaultReason(Dictionary.UNKNOWN_REASON));
                }
                tr.Complete();
            }
        }

        #endregion IMethods
    }
}