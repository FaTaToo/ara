// --------------------------------------------------------------------------------------------------------------------
// <header file="CompanyServiceImpl.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the service class for Company.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.ServiceModel;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Exception.Company;
using ARAManager.Common.Exception.Generic;
using ARAManager.Common.Factory;
using ARAManager.Common.Services;
using NHibernate;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services {
   public class CompanyServiceImpl : ICompanyServiceImpl {
       #region IMethods
       public Company GetCompanyById(int companyId)
       {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           return srvDao.GetById(companyId);
       }
       public IList<Company> GetAllCompanies()
       {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           return srvDao.FindByCriteria(criteria);
       }

       public void SaveNewCompany(Company company)
       {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
           {
               try
               {
                   srvDao.Save(company);
               }
               catch (ADOException)
               {
                   throw new FaultException<CompanyNameAlreadyExistException>(
                       new CompanyNameAlreadyExistException { MessageError = Messages.COMPANY_NAME_CONSTRAINT_EXCEPTION_MSG },
                       new FaultReason(Messages.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
               }
               catch (StaleObjectStateException)
               {
                   throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Messages.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG },
                       new FaultReason(Messages.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG));
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

       public void DeleteCompany(int companyId)
       {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope())
           {
               try
               {
                   var deleteComppany = srvDao.GetById(companyId);
                   srvDao.Delete(deleteComppany);
               }
               catch (Exception)
               {
                   throw new FaultException<ConcurrentUpdateException>(
                      new ConcurrentUpdateException { MessageError = Messages.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Messages.DELETED_EXCEPTION_REASON));
               }
               tr.Complete();
           }
       }

       public void DeleteCompanies(List<int> companies)
       {
           foreach (var company in companies)
           {
               try
               {
                   DeleteCompany(company);
               }
               catch (Exception)
               {
                   throw new FaultException<ConcurrentUpdateException>(
                      new ConcurrentUpdateException { MessageError = Messages.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Messages.DELETED_EXCEPTION_REASON));
               }
           }
       }
       #endregion IMethods
    }
}
