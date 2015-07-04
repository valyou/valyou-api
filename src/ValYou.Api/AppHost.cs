namespace ValYou.Api
{
    using System.Collections.Generic;

    using Akka.Actor;

    using Funq;

    using ServiceStack;
    using ServiceStack.Api.Swagger;
    using ServiceStack.Configuration;
    using ServiceStack.Data;
    using ServiceStack.MiniProfiler;
    using ServiceStack.MiniProfiler.Data;
    using ServiceStack.OrmLite;
    using ServiceStack.OrmLite.PostgreSQL;
    using ServiceStack.Text;
    using ServiceStack.Validation;

    using ValYou.Api.Actor;
    using ValYou.Api.Data;
    using ValYou.Api.ServiceInterface;

    /// <summary>
    /// The Web Application host.
    /// </summary>
    public class AppHost : AppHostBase
    {
        /// <summary>
        /// The application config parameters.
        /// </summary>
        public static AppConfig AppConfig;

        /// <summary>
        /// The application settings.
        /// </summary>
        public static AppSettings AppSettings;

        /// <summary>
        /// Initializes a new instance of the <see cref="AppHost"/> class.
        /// </summary>
        public AppHost()
            : base("ValYou REST API", typeof(ShapesService).Assembly)
        {
        }

        /// <summary>
        /// Configure the Web Application host.
        /// </summary>
        /// <param name="container">The IoC container.</param>
        public override void Configure(Container container)
        {
            // Configure ServiceStack host
            ConfigureHost(container);

            // Configure JSON serialization properties
            ConfigureSerialization(container);

            // Configure application settings and configuration parameters
            ConfigureApplication(container);

            // Configure ServiceStack database connections
            ConfigureDataConnection(container);

            // Configure Akka actors
            ConfigureActors(container);

            // Configure ServiceStack Fluent Validation plugin
            ConfigureValidation(container);

            // Configure various system tools / features
            ConfigureTools(container);
        }

        /// <summary>
        /// Configure ServiceStack host.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureHost(Container container)
        {
            SetConfig(new HostConfig
            {
                AppendUtf8CharsetOnContentTypes = new HashSet<string> { MimeTypes.Html },

                // Set to return JSON if no request content type is defined
                // e.g. text/html or application/json
                DefaultContentType = MimeTypes.Json,
#if DEBUG
                // Show StackTraces in service responses during development
                DebugMode = true,
#endif
                // Disable SOAP endpoints
                EnableFeatures = Feature.All.Remove(Feature.Soap)
            });
        }

        /// <summary>
        /// Configure JSON serialization properties.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureSerialization(Container container)
        {
            // Set JSON web services to return idiomatic JSON camelCase properties
            JsConfig.EmitCamelCaseNames = true;

            // Set JSON web services to return ISO8601 date format
            JsConfig.DateHandler = DateHandler.ISO8601;

            // Exclude type info during serialization,
            // except for UserSession DTO
            JsConfig.ExcludeTypeInfo = true;
        }

        /// <summary>
        /// Configure application settings and configuration.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureApplication(Container container)
        {
            // Set application settings
            AppSettings = new AppSettings();
            container.Register<IAppSettings>(AppSettings);

            // Set configuration parameters
            AppConfig = new AppConfig(AppSettings);
            // TODO: Inject AppConfig
        }

        private void ConfigureActors(Container container)
        {
            Global.ActorSystem.ActorOf(Props.Create(() => new CoordinatorActor(container.Resolve<IShapeRepository>())), "coord");
        }

        /// <summary>
        /// Configure database connections.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureDataConnection(Container container)
        {
            // Get connection string
            var dbConnStr = AppSettings.Get(
                "POSTGRESQL_CONNECTION_STRING",
                ConfigUtils.GetConnectionString("Data"));

            // Configure database connection settings
            var dbConn =
                new OrmLiteConnectionFactory(
                    dbConnStr,
                    PostgreSQLDialectProvider.Instance)
                {
#if DEBUG
                    ConnectionFilter = x => new ProfiledDbConnection(x, Profiler.Current)
#endif
                };

            // Register database connection factory
            container.Register<IDbConnectionFactory>(dbConn);

            // Register repositories
            container.Register<IShapeRepository>(c => new ShapeRepository(c.Resolve<IDbConnectionFactory>()));

            // NOTE: Service Interfaces are auto-injected by ServiceStack
        }

        /// <summary>
        /// Configure ServiceStack Fluent Validation plugin.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureValidation(Container container)
        {
            // Provide fluent validation functionality for web services
            Plugins.Add(new ValidationFeature());

            // TODO: Add validator's assembly for scanning
        }

        /// <summary>
        /// Configure various system tools / features.
        /// </summary>
        /// <param name="container">The DI / IoC container.</param>
        private void ConfigureTools(Container container)
        {
            // Add Postman and Swagger UI support
            Plugins.Add(new PostmanFeature());
            Plugins.Add(new SwaggerFeature());

            // Add CORS (Cross-Origin Resource Sharing) support
            Plugins.Add(new CorsFeature());
#if DEBUG
            // Development-time features
            // Add request logger
            // See: https://github.com/ServiceStack/ServiceStack/wiki/Request-logger
            Plugins.Add(new RequestLogsFeature());
#endif
        }
    }
}