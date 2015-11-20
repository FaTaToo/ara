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
using System.Linq;
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
       /// <summary>
       /// Get company by company id
       /// </summary>
       /// <param name="companyId"></param>
       /// <returns></returns>
       public Company GetCompanyById(int companyId) {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           return srvDao.GetById(companyId);
       }
       /// <summary>
       /// Get company by user name
       /// </summary>
       /// <param name="userName"></param>
       /// <returns></returns>
       public Company GetCompanyByUserName(string userName)
       {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           if (!string.IsNullOrEmpty(userName))
           {
               criteria.Add(Restrictions.Where<Company>(c => c.UserName == userName));
           }
           var result = srvDao.FindByCriteria(criteria);
           return result != null ? result.FirstOrDefault() : null;
       }
       /// <summary>
       /// Get all companies
       /// </summary>
       /// <returns></returns>
       public IList<Company> GetAllCompanies() {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           return srvDao.FindByCriteria(criteria);
       }
       /// <summary>
       /// Save new company
       /// </summary>
       /// <param name="company"></param>
       public void SaveNewCompany(Company company) {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
               try {
                   srvDao.Save(company);
               } catch (ADOException) {
                   throw new FaultException<CompanyNameAlreadyExistException>(
                       new CompanyNameAlreadyExistException { MessageError = Dictionary.COMPANY_NAME_CONSTRAINT_EXCEPTION_MSG },
                       new FaultReason(Dictionary.UNIQUE_CONSTRAINT_EXCEPTION_REASON));
               } catch (StaleObjectStateException) {
                   throw new FaultException<ConcurrentUpdateException>(
                       new ConcurrentUpdateException { MessageError = Dictionary.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG },
                       new FaultReason(Dictionary.COMPANY_CONCURRENT_UPDATE_EXCEPTION_MSG));
               } catch (Exception ex) {
                   throw new FaultException<Exception>(
                      new Exception(ex.Message),
                      new FaultReason(Dictionary.UNKNOWN_REASON));
               }
               tr.Complete();
           }
       }
       /// <summary>
       /// Delete company by company id
       /// </summary>
       /// <param name="companyId"></param>
       public void DeleteCompany(int companyId) {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           using (NhTransactionScope tr = TransactionsFactory.CreateTransactionScope()) {
               try {
                   var deleteComppany = srvDao.GetById(companyId);
                   srvDao.Delete(deleteComppany);
               } catch (Exception) {
                   throw new FaultException<CompanyAlreadyDeletedException>(
                      new CompanyAlreadyDeletedException { MessageError = Dictionary.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
               }
               tr.Complete();
           }
       }
       /// <summary>
       /// Delete companies by the list of companies id
       /// </summary>
       /// <param name="companies"></param>
       public void DeleteCompanies(List<int> companies) {
           foreach (var company in companies) {
               try {
                   DeleteCompany(company);
               } catch (Exception) {
                   throw new FaultException<CompanyAlreadyDeletedException>(
                      new CompanyAlreadyDeletedException { MessageError = Dictionary.COMPANY_DELETED_EXCEPTION_MSG },
                      new FaultReason(Dictionary.DELETED_EXCEPTION_REASON));
               }
           }
       }
       /// <summary>
       /// Search company by name, email, phone, and user name
       /// </summary>
       /// <param name="name"></param>
       /// <param name="email"></param>
       /// <param name="phone"></param>
       /// <param name="username"></param>
       /// <returns></returns>
       public IList<Company> SearchCompany(string name, string email, string phone, string username) {
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           if (!string.IsNullOrEmpty(name)) {
               criteria.Add(Restrictions.Where<Company>(c=>c.CompanyName ==name));
           }
           if (!string.IsNullOrEmpty(email)) {
               criteria.Add(Restrictions.Where<Company>(c => c.Email == email));
           }
           if (!string.IsNullOrEmpty(phone)) {
               criteria.Add(Restrictions.Where<Company>(c => c.Phone == phone));
           }
           if (!string.IsNullOrEmpty(username))
           {
               criteria.Add(Restrictions.Where<Company>(c => c.UserName == username));
           }
           var result = srvDao.FindByCriteria(criteria);
           return result;
       }
       /// <summary>
       /// Check user name and password of company
       /// </summary>
       /// <param name="username"></param>
       /// <param name="password"></param>
       /// <returns></returns>
       public int AuthenticateUser(string username, string password) {
           if (String.CompareOrdinal(username, Dictionary.ADMIN_USERNAME) == 0 ||
               String.CompareOrdinal(password, Dictionary.ADMIN_PASSWORD) == 0) {
               return 1;
           }
           var srvDao = NinjectKernelFactory.Kernel.Get<ICompanyDataAccess>();
           var criteria = DetachedCriteria.For<Company>();
           if (!string.IsNullOrEmpty(username) && !string.IsNullOrEmpty(password)) {
               criteria.Add(Restrictions.Where<Company>(a => a.UserName== username));
               criteria.Add(Restrictions.Where<Company>(a => a.Password == password));
               var result = srvDao.FindByCriteria(criteria);
               if (result.Count != 0) {
                   return 2;
               }
           }
           return -1;
       }
       /// <summary>
       /// Count the number of companies
       /// </summary>
       /// <returns></returns>
       public int CountCompany()
       {
           return GetAllCompanies().Count;
       }
       #endregion IMethods
    }
}
