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
       #region IFields

       private const string ADMIN_USERNAME = "admin";
       private const string ADMIN_PASSWORD = "admin";

       #endregion IFields

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
                       new CompanyNameAlreadyExistException { MessageError = Dictionary.COMPANY_NAME_CONSTRAINT_EXCEPTION_MSG },
                       new FaultReason(Dictionary.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
               }
               catch (StaleObjectStateException)
               {
                   throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Dictionary.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG },
                       new FaultReason(Dictionary.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG));
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
                   throw new FaultException<CompanyAlreadyDeletedException>(
                      new CompanyAlreadyDeletedException { MessageError = Dictionary.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
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
                   throw new FaultException<CompanyAlreadyDeletedException>(
                      new CompanyAlreadyDeletedException { MessageError = Dictionary.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
               }
           }
       }

       public IList<Company> SearchCompany(string name, string email, string phone, string username) {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           
           if (!string.IsNullOrEmpty(name)) {
               criteria.Add(Restrictions.Where<Company>(c=>c.CompanyName==name));
           }

           if (!string.IsNullOrEmpty(email))
           {
               criteria.Add(Restrictions.Where<Company>(c => c.Email == email));
           }

           if (!string.IsNullOrEmpty(phone))
           {
               criteria.Add(Restrictions.Where<Company>(c => c.Phone == phone));
           }

           var result = srvDao.FindByCriteria(criteria);
           return result;
       }

       public int AuthenticateUser(string username, string password)
       {
           if (String.CompareOrdinal(username, ADMIN_USERNAME) == 0 ||
               String.CompareOrdinal(password, ADMIN_PASSWORD) == 0) {
               return 1;
           }

           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();

           if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)) {
               criteria.Add(Restrictions.Where<Company>(a => a.UserName== username));
               criteria.Add(Restrictions.Where<Company>(a => a.Password == password));
               var result = srvDao.FindByCriteria(criteria);
               if (result.Count != 0)
               {
                   return 2;
               }
           }
           
           return -1;
       }
       #endregion IMethods
    }
}
