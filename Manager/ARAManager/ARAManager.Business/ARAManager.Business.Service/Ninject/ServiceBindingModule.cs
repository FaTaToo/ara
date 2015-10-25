// --------------------------------------------------------------------------------------------------------------------
// <header file="ServiceBindingModule.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ServiceBindingModule.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using ARAManager.Business.Dao.DataAccess.Implementation;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.Interceptors;
using ARAManager.Business.Service.Services;
using ARAManager.Common.Services;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace ARAManager.Business.Service.Ninject
{
    /// <summary> 
    /// Class summary. 
    /// </summary>
    public class ServiceBindingModule : NinjectModule
    {
        #region IMethods

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IAccountDataAccess>().To<AccountDataAccessImpl>();
            Bind<IAccountServiceImpl>().To<AccountServiceImpl>().Intercept().With<ServiceInterceptor>();
        }

        #endregion IMethods
    }
}
