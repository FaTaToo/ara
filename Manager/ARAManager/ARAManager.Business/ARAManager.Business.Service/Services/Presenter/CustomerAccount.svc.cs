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
using ARAManager.Common.Dto;
using ARAManager.Common.Services.Presenter;

namespace ARAManager.Business.Service.Services.Presenter
{
    public class CustomerAccount : ICustomerAccount
    {
        #region IMethods

        public bool Authenticate(Customer account)
        {
            throw new NotImplementedException();
        }

        public void SignUp(Customer customer)
        {
            throw new NotImplementedException();
        }

        #endregion IMethods
    }
}