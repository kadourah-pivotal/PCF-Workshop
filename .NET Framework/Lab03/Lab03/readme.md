1.  Add Nuget
Steeltoe.CloudFoundry.ConnectorAutofac
	MySql.Data
	MySql.Data.Entity
	Autofac.Mvc5
	
	Autofac.WebApi2
	
2.  Add ServerConfig.cs under app_start





public static class ServerConfig
    {

        public static IConfigurationRoot Configuration { get; set; }

        public static void RegisterConfig(string environment)
        {

            // Set up configuration sources.
            var builder = new ConfigurationBuilder()
                .SetBasePath(GetContentRoot())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: false)
                .AddJsonFile($"appsettings.{environment}.json", optional: true)
                .AddCloudFoundry()
                .AddEnvironmentVariables();

            Configuration = builder.Build();
        }
        public static string GetContentRoot()
        {
            var basePath = (string)AppDomain.CurrentDomain.GetData("APP_CONTEXT_BASE_DIRECTORY") ??
               AppDomain.CurrentDomain.BaseDirectory;
            return Path.GetFullPath(basePath);
        }
    }
3. add references

using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.IO;

3.  update global.asax:

ServerConfig.RegisterConfig("development");
            var builder = new ContainerBuilder();

            // Register all the controllers with Autofac
            builder.RegisterControllers(typeof(MvcApplication).Assembly);

            builder.RegisterDistributedRedisCache(ServerConfig.Configuration);
            builder.RegisterRedisConnectionMultiplexer(ServerConfig.Configuration);

            // Create the Autofac container
            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            SampleData.InitializeCache(container);

4. add references to global.asax

using Autofac;
using Autofac.Integration.Mvc;
using Steeltoe.CloudFoundry.ConnectorAutofac;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

5. Add file appsettings.json

{
  "Logging": {
    "IncludeScopes": false,
    "LogLevel": {
      "Default": "Warning"
    }
  },
  "redis": {
    "client": {
      "connectRetry": 3
    }
  }
}
