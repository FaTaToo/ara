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
        #region Constants

        #endregion Constants

        #region SFields

        #endregion SFields

        #region IFields

        #endregion IFields

        #region SConstructor

        #endregion SConstructor

        #region IConstructors

        #endregion IConstructors

        #region IDestructor

        #endregion IDestructor

        #region SMethods

        #endregion SMethods

        #region IMethods

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load()
        {
            Bind<IAccountServiceImpl>().To<AccountServiceImpl>().Intercept().With<ServiceInterceptor>();
        }

        #endregion IMethods

        #region SProperties

        #endregion SProperties

        #region IProperties

        #endregion IProperties
    }
}
