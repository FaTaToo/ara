// --------------------------------------------------------------------------------------------------------------------
/* <header file="CustomerAccount.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement CustomerAccount service of presenter.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using System;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.NHibernate.Transaction;
using ARAManager.Common;
using ARAManager.Common.Dto;
using ARAManager.Common.Factory;
using ARAManager.Common.PresenterJson.Account;
using ARAManager.Common.PresenterJson.Common;
using ARAManager.Common.Services.Presenter;
using NHibernate.Criterion;
using Ninject;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerAccount : ICustomerAccount
    {
        #region IFields

        private readonly JsonRespone m_authenticationJsonRespone;

        #endregion IFields

        #region IConstructors

        private CustomerAccount()
        {
            m_authenticationJsonRespone = new JsonRespone();
        }

        #endregion IConstructors

        #region IMethods

        public JsonRespone Authenticate(AuthenticationJsonRequest account)
        {
            var username = account.UserName;
            var password = account.Password;
            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            var criteria = DetachedCriteria.For<Customer>();
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                m_authenticationJsonRespone.Message = "Failed";
            }
            criteria.Add(Restrictions.Where<Customer>(a => a.UserName == username));
            criteria.Add(Restrictions.Where<Customer>(a => a.Password == password));
            var result = srvDao.FindByCriteria(criteria);
            m_authenticationJsonRespone.Message = result.Count != 0 ? "Success" : "Failed";
            return m_authenticationJsonRespone;
        }

        public JsonRespone SignUp(CustomerJson customerJson)
        {
            var customer = new Customer
            {
                FirstName = customerJson.FirstName,
                LastName = customerJson.LastName,
                Sex = customerJson.Sex,
                Address = customerJson.Address,
                BirthDay = DateTime.ParseExact(customerJson.BirthDay, Dictionary.DATE_FORMAT, null),
                Email = customerJson.Email,
                Phone = customerJson.Phone,
                UserName = customerJson.UserName,
                Password = customerJson.Password
            };

            var srvDao = NinjectKernelFactory.Kernel.Get<ICustomerDataAccess>();
            using (var tr = TransactionsFactory.CreateTransactionScope())
            {
                try
                {
                    srvDao.Save(customer);
                    m_authenticationJsonRespone.Message = "Successfully";
                    tr.Complete();
                    return m_authenticationJsonRespone;
                }
                catch (Exception)
                {
                    m_authenticationJsonRespone.Message = "Failed";
                    return m_authenticationJsonRespone;
                }
            }
        }

        #endregion IMethods
    }
}