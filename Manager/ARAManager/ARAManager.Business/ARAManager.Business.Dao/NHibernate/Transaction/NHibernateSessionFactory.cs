// --------------------------------------------------------------------------------------------------------------------
// <header file="NHibernateSessionFactory.cs" group="288-462">
//
// Last modified: 
// Author: LE Sanh Phuc - 11520288
//
// </header>
// <summary>
// Implement the NHibernateSessionFactory.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

using System.Configuration;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Globalization;
using System.Reflection;
using ARAManager.Business.Dao.NHibernate.Helper;
using NHibernate;
using NHibernate.Mapping.Attributes;

namespace ARAManager.Business.Dao.NHibernate.Transaction {
    using Configuration = global::NHibernate.Cfg.Configuration;
    using Environment = global::NHibernate.Cfg.Environment;

    /// <summary>
    /// Default implementation of the
    /// <see cref="INHibernateSessionFactory"/>
    /// contract.
    /// <para>
    /// The implementation loads the hibernate session factory configuration from the configured 
    /// file.
    /// The file is configured via application configuration app settings.
    /// </para>
    /// </summary>
    /// <remarks>
    /// <list type="bullet">
    /// <item>
    /// <term>
    /// Component dependencies:
    /// None.
    /// </term>
    /// </item>
    /// </list>
    /// </remarks>
    public class NHibernateSessionFactory : INHibernateSessionFactory {
        /// <summary>
        /// Key of Nhibernate configuration file. 
        /// </summary>
        public const string NHCONFIG_RESOURCENAME_KEY = "NHConfigResourceName";

        /// <summary>
        /// key of assembly file containing the Nhibernate configuration file
        /// </summary>
        public const string NHCONFIG_RESOURCEASSEMBLY_KEY = "NHConfigResourceAssembly";

        #region IFields

        /// <summary>
        /// Factory of session.
        /// </summary>
        private ISessionFactory m_sessionFactory;

        /// <summary>
        /// Connection string
        /// </summary>
        private ConnectionStringSettings m_connectionString;

        #endregion IFields
        #region IConstructors

        /// <summary>
        /// Initializes a new instance of the <see cref="NHibernateSessionFactory"/> class.
        /// </summary>
        public NHibernateSessionFactory() {
            Load();
        }

        #endregion IConstructors
        #region IMethods

        /// <summary>
        /// Returns the NHibernate configuration for the specified connection alias.
        /// </summary>
        /// <param name="connectionAlias">The connection alias.</param>
        /// <returns>
        /// NHibernate configuration
        /// </returns>
        public Configuration GetConfiguration(string connectionAlias) {
            Assembly asm = this.GetAssemblyForResourceAssemblyName();
            string resourceName = this.GetResourceName();
            Configuration cfg = new Configuration();
            cfg.Configure(asm, resourceName);
            if (string.Equals(cfg.GetProperty(Environment.SqlExceptionConverter), typeof(NHibernateSessionFactory).AssemblyQualifiedName))
            {
                cfg.SetProperty(
                    Environment.SqlExceptionConverter,
                    typeof(NHibernateSessionFactory).AssemblyQualifiedName);
            }

            this.SerializeDomainObjects(cfg);
            return cfg;
        }

        /// <summary>
        /// See inherited comment at
        /// <see cref="INHibernateSessionFactory.CreateSession"></see>
        /// </summary>
        /// <param name="connectionAlias">Alias of connection</param>
        /// <returns>Created session</returns>
        public ISession CreateSession(string connectionAlias) {
            IDbConnection connection = BuildConnection(connectionAlias);

            IInterceptor interceptor = GetInterceptor();
            if (interceptor != null)
            {
                return m_sessionFactory.OpenSession(connection, interceptor);
            }
            else
            {
                return m_sessionFactory.OpenSession(connection);
            }
        }

        /// <summary>
        /// See inherited comment at
        /// <see cref="INHibernateSessionFactory.DisposeSession"></see>
        /// </summary>
        /// <param name="session">session to dispose</param>
        public void DisposeSession(ISession session) {
            if (session != null)
            {
                IDbConnection connection = session.Connection;
                session.Dispose();
                connection.Close();
                connection.Dispose();
            }
        }

        /// <summary>
        /// Set the interceptor forthe Nhibernate
        /// </summary>
        /// <returns>Interceptor of NHibernate</returns>
        protected virtual IInterceptor GetInterceptor() {
            return null;
        }

        /// <summary>
        /// Serialize declared objects into the configuration of NHibernate.
        /// </summary>
        /// <param name="configuration">Nhibernate configuration</param>
        private void SerializeDomainObjects(Configuration configuration) {
            HbmSerializer.Default.Validate = true; // Enable validation (optional)
            configuration.AddInputStream(HbmSerializer.Default.Serialize(AssemblyLoadingHelper.GetOrLoadAssembly("NHibernateExampleCommon")));
        }

        /// <summary>
        /// Creates the wrapped hibernate exception.
        /// </summary>
        /// <param name="inner">The inner.</param>
        /// <returns>Exception thrown from Factory</returns>
        private System.Exception CreateWrappedHibernateException(System.Exception inner) {
            return new ConfigurationErrorsException(DataExceptionStrings.InvalidSessionFactoryConfig, inner);
        }

        /// <summary>
        /// Loads this instance.
        /// </summary>
        private void Load() {
            LoadConnectionStringsFromConfig();
            try
            {
                this.m_sessionFactory = this.CreateSessionFactory();
            }
            catch (HibernateException hibEx)
            {
                throw CreateWrappedHibernateException(hibEx);
            }
        }

        #region ConnectionHandling

        /// <summary>
        /// Loads the Connection strings from a config file
        /// </summary>
        private void LoadConnectionStringsFromConfig() {
            if (ConfigurationManager.ConnectionStrings.Count != 1)
            {
                throw new ConfigurationErrorsException(string.Format(
                                                            CultureInfo.InvariantCulture,
                                                            DataExceptionStrings.InvalidNumberOfConnectioNStrings,
                                                            ConfigurationManager.ConnectionStrings.Count));
            }

            this.m_connectionString = ConfigurationManager.ConnectionStrings[0];
        }

        /// <summary>
        /// Creates the provider factory no connection created exception.
        /// </summary>
        /// <returns>Exception of no connection</returns>
        private System.Exception CreateProviderFactoryNoConnectionCreatedException() {
            return new ConfigurationErrorsException(DataExceptionStrings.DbConnectionCreationError);
        }

        /// <summary>
        /// Creates the invalid formatted connection string exception.
        /// </summary>
        /// <param name="connString">The conn string.</param>
        /// <returns>Exception of invalid connnection</returns>
        private System.Exception CreateInvalidFormattedConnectionStringException(string connString) {
            return
                new ConfigurationErrorsException(
                    string.Format(
                        CultureInfo.InvariantCulture,
                        DataExceptionStrings.ConnectionStringFormatException,
                        connString));
        }

        /// <summary>
        /// Builds the connection.
        /// </summary>
        /// <param name="alias">The alias.</param>
        /// <returns>DB Connection</returns>
        private DbConnection BuildConnection(string alias) {
            // use a provider instance and factory to create the connection
            string providerName = FetchProviderName(alias);
            DbConnection connection = null;
            DbProviderFactory factory = DbProviderFactories.GetFactory(providerName);
            connection = factory.CreateConnection();

            // simple connection string validation
            var builder = new DbConnectionStringBuilder {
                ConnectionString = FetchConnectionString(alias)
            };
            if (builder.ConnectionString == null) {
                throw CreateInvalidFormattedConnectionStringException(FetchConnectionString(alias));
            }

            connection.ConnectionString = builder.ConnectionString;

            if (connection == null) {
                throw this.CreateProviderFactoryNoConnectionCreatedException();
            }

            // everything ok --> hand connection to client.
            // It is neccessary to ctach exception because SQLServerExceptionConverter cannot catch the exception of connection database
            try {
                connection.Open();
            }
            catch (SqlException ex) {
                throw (new SqlServerExceptionConverter()).WrapConnectionSqlException(ex);
            }

            return connection;
        }

        /// <summary>
        /// Gets a connection string from the cached application's configuration files
        /// </summary>
        /// <param name="alias">Alias for the connection.</param>
        /// <returns>
        /// Complete connection string corresponding to the given connection alias.
        /// </returns>
        /// <remarks>
        /// To avoid storing the connection string in your code, you can retrieve
        /// it from the application's configuration file, using the
        /// <c>System.Configuration.ConnectionStrings</c> property.
        /// </remarks>
        private string FetchConnectionString(string alias) {
            ConnectionStringSettings setting = FetchConnectionStringSettings(alias);
            return setting.ConnectionString;
        }

        /// <summary>
        /// Gets the provider name for a given connection alias from the cached
        /// application's configuration files.
        /// </summary>
        /// <param name="alias">
        /// Alias for the connection.
        /// </param>
        /// <returns>
        /// Full provider name of the specified connection alias.
        /// </returns>
        private string FetchProviderName(string alias) {
            ConnectionStringSettings setting = FetchConnectionStringSettings(alias);
            return setting.ProviderName;
        }

        /// <summary>
        /// Gets the connection string settings for a given connection alias
        /// from the cached application's configuration files.
        /// </summary>
        /// <param name="alias">
        /// Alias for the connection.
        /// </param>
        /// <returns>
        /// Complete settings for a given connection alias.
        /// </returns>
        private ConnectionStringSettings FetchConnectionStringSettings(string alias) {
            return m_connectionString;
        }

        #endregion ConnectionHandling

        /// <summary>
        /// Gets the name of the resource.
        /// </summary>
        /// <returns>Resource name</returns>
        private string GetResourceName() {
            string resourceName = ConfigurationManager.AppSettings[NHCONFIG_RESOURCENAME_KEY];
            if (string.IsNullOrEmpty(resourceName)) {
                throw new ConfigurationErrorsException(DataExceptionStrings.NoSessionFactoryConfiguredForConnection);
            }

            return resourceName;
        }

        /// <summary>
        /// Gets the name of the assembly for resource assembly.
        /// </summary>
        /// <returns>Assembly of resource</returns>
        private Assembly GetAssemblyForResourceAssemblyName() {
            string resourceAsm = ConfigurationManager.AppSettings[NHCONFIG_RESOURCEASSEMBLY_KEY];
            if (string.IsNullOrEmpty(resourceAsm)) {
                throw new ConfigurationErrorsException(DataExceptionStrings.NoSessionFactoryConfiguredForConnection);
            }

            Assembly asm = AssemblyLoadingHelper.GetOrLoadAssembly(resourceAsm);
            return asm;
        }

        /// <summary>
        /// Creates the session factory.
        /// </summary>
        /// <returns>Session factory</returns>
        private ISessionFactory CreateSessionFactory() {
            Configuration cfg = this.GetConfiguration(null);
            return cfg.BuildSessionFactory();
        }

        #endregion IMethods
    }
}
