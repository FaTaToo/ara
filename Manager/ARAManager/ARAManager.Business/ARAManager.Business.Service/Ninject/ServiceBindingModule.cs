// --------------------------------------------------------------------------------------------------------------------
/* <header file="ServiceBindingModule.cs" group="288-462">
 * Author: LE Sanh Phuc - 11520288
 * </header>
 * <summary>
 *      Implement the ServiceBindingModule.
 * </summary>
 * <Problems>
 * </Problems>
*/
// --------------------------------------------------------------------------------------------------------------------

using ARAManager.Business.Dao.DataAccess.Implementation;
using ARAManager.Business.Dao.DataAccess.Interfaces;
using ARAManager.Business.Dao.Interceptors;
using ARAManager.Business.Service.Services;
using ARAManager.Common.Services;
using Ninject.Extensions.Interception.Infrastructure.Language;
using Ninject.Modules;

namespace ARAManager.Business.Service.Ninject {
    /// <summary> 
    /// Class summary. 
    /// </summary>
    public class ServiceBindingModule : NinjectModule {
        #region IMethods

        /// <summary>
        /// Loads the module into the kernel.
        /// </summary>
        public override void Load() {
            // Campaign
            Bind<ICampaignDataAccess>().To<CampaignDataAccessImpl>();
            Bind<ICampaignServiceImpl>().To<CampaignServiceImpl>().Intercept().With<ServiceInterceptor>();

            // CampaignType
            Bind<ICampaignTypeDataAccess>().To<CampaignTypeDataAccessImpl>();
            Bind<ICampaignTypeServiceImpl>().To<CampaignTypeServiceImpl>().Intercept().With<ServiceInterceptor>();

            // Company
            Bind<ICompanyDataAccess>().To<CompanyDataAccessImpl>();
            Bind<ICompanyServiceImpl>().To<CompanyServiceImpl>().Intercept().With<ServiceInterceptor>();
            
            // Customer
            Bind<ICustomerDataAccess>().To<CustomerDataAccessImpl>();
            Bind<ICustomerServiceImpl>().To<CustomerServiceImpl>().Intercept().With<ServiceInterceptor>();
                
            // Mission
            Bind<IMissionDataAccess>().To<MissionDataAccessImpl>();
            Bind<IMissionServiceImpl>().To<MissionServiceImpl>().Intercept().With<ServiceInterceptor>();

            // Subscription
            Bind<ISubscriptionDataAccess>().To<SubscriptionDataAccessImpl>();
            Bind<ISubscriptionServiceImpl>().To<SubscriptionServiceImpl>().Intercept().With<ServiceInterceptor>();

            // Target
            Bind<ITargetDataAccess>().To<TargetDataAccessImpl>();
            Bind<ITargetServiceImpl>().To<TargetServiceImpl>().Intercept().With<ServiceInterceptor>();
        }

        #endregion IMethods
    }
}
