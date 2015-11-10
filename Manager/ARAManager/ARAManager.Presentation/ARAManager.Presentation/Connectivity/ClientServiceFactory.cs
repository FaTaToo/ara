// --------------------------------------------------------------------------------------------------------------------
// <header file="ClientServiceFactory.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the ClientServiceFactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Reflection;
using System.ServiceModel;
using System.ServiceModel.Configuration;
using ARAManager.Common.Services;

namespace ARAManager.Presentation.Connectivity
{
    /// <summary> 
    /// Class summary. 
    /// </summary>
    public class ClientServiceFactory
    {
        #region Constants

        private const string CAMPAIGN_SERVICE_NAME = "CampaignService";
        private const string COMPANY_SERVICE_NAME = "CompanyService";
        private const string CUSTOMER_SERVICE_NAME = "CustomerService";
        private const string MISSION_SERVICE_NAME = "MissionService";
        private const string SUBSCRIPTION_SERVICE_NAME = "SubscriptionService";
        private const string TARGET_SERVICE_NAME = "TargetService";
        #endregion Constants

        #region IFields
        /// <summary>
        /// A list of cached service proxies.
        /// </summary>
        private readonly IDictionary<string, object> m_serviceFactories;

        /// <summary>
        /// A factory to create client service proxy.
        /// </summary>
        private static readonly ClientServiceFactory s_instance = new ClientServiceFactory();

        #endregion IFields

        #region IConstructors

        /// <summary>
        /// Prevents a default instance of the <see cref="ClientServiceFactory"/> class from being created. 
        /// The ClientServiceFactory is a Singleton and should only be created internaly.
        /// </summary>
        private ClientServiceFactory()
        {
            m_serviceFactories = new Dictionary<string, object>();
            Configuration configuration = ConfigurationManager.OpenMappedExeConfiguration(new ExeConfigurationFileMap()
            {
                ExeConfigFilename = @"D:\Projects\ARA\1.0\src\Manager\ARAManager\ARAManager.Presentation\ARAManager.Presentation\bin\Debug\ARAManager.Presentation.Client.exe.config",
            }, ConfigurationUserLevel.None);

            var serviceGroup = ServiceModelSectionGroup.GetSectionGroup(configuration);
            if (serviceGroup != null)
            {
                ClientSection clients = serviceGroup.Client;
                foreach (ChannelEndpointElement endpoint in clients.Endpoints)
                {
                    switch (endpoint.Name)
                    {
                        case CAMPAIGN_SERVICE_NAME:
                            var binding = new BasicHttpBinding();
                            var endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<ICampaignServiceImpl>(binding, endpointAddress);
                            break;
                        case COMPANY_SERVICE_NAME:
                            binding = new BasicHttpBinding();
                            endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<ICompanyServiceImpl>(binding, endpointAddress);
                            break;
                        case CUSTOMER_SERVICE_NAME:
                            binding = new BasicHttpBinding();
                            endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<ICustomerServiceImpl>(binding, endpointAddress);
                            break;
                        case MISSION_SERVICE_NAME:
                            binding = new BasicHttpBinding();
                            endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<IMissionServiceImpl>(binding, endpointAddress);
                            break;
                        case SUBSCRIPTION_SERVICE_NAME:
                            binding = new BasicHttpBinding();
                            endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<ISubscriptionServiceImpl>(binding, endpointAddress);
                            break;
                        case TARGET_SERVICE_NAME:
                            binding = new BasicHttpBinding();
                            endpointAddress = new EndpointAddress(endpoint.Address);
                            m_serviceFactories[endpoint.Name] = new ChannelFactory<ITargetServiceImpl>(binding, endpointAddress);
                            break;
                    }
                }
            }
        }

        #endregion IConstructors

        #region IProperties

        public static ICampaignServiceImpl CampaignService
        {
            get
            {
                return Get<ICampaignServiceImpl>(CAMPAIGN_SERVICE_NAME);
            }
        }

        public static ICompanyServiceImpl CompanyService
        {
            get
            {
                return Get<ICompanyServiceImpl>(COMPANY_SERVICE_NAME);
            }
        }

        public static ICustomerServiceImpl CustomerService
        {
            get
            {
                return Get<ICustomerServiceImpl>(CUSTOMER_SERVICE_NAME);
            }
        }
        public static IMissionServiceImpl MissionService
        {
            get
            {
                return Get<IMissionServiceImpl>(MISSION_SERVICE_NAME);
            }
        }

        public static ISubscriptionServiceImpl SubscriptionService
        {
            get
            {
                return Get<ISubscriptionServiceImpl>(SUBSCRIPTION_SERVICE_NAME);
            }
        }

        public static ITargetServiceImpl TargetService
        {
            get
            {
                return Get<ITargetServiceImpl>(TARGET_SERVICE_NAME);
            }
        }
        #endregion IProperties

        #region IMethods

        /// <summary>
        /// Gets the specified component name.
        /// </summary>
        /// <typeparam name="TComponent">The type of the component.</typeparam>
        /// <param name="componentName">Name of the component.</param>
        /// <returns>An instance of TComponent.</returns>
        protected static TComponent Get<TComponent>(string componentName) where TComponent : class
        {
            if (s_instance.m_serviceFactories.ContainsKey(componentName))
            {
                var factory = s_instance.m_serviceFactories[componentName] as ChannelFactory;

                if (factory != null)
                {
                    var type =
                        typeof(ChannelFactory<>).MakeGenericType(
                            factory.Endpoint.Contract.ContractType);
                    MethodInfo info = type.GetMethod("CreateChannel", new Type[] { });

                    return info.Invoke(factory, new object[0]) as TComponent;
                }
            }

            return null;
        }

        #endregion IMethods
    }
}
