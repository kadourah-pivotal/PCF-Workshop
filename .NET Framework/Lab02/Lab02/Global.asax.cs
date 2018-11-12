using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace Lab02
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            // Create applications configuration
            ApplicationConfig.Configure("development");


            // Create logging system using configuration
            LoggingConfig.Configure(ApplicationConfig.Configuration);
            
            // Add management endpoints to application
            ManagementConfig.ConfigureManagementActuators(
                
                ApplicationConfig.Configuration,
                LoggingConfig.LoggerProvider,
                GlobalConfiguration.Configuration.Services.GetApiExplorer(),
                LoggingConfig.LoggerFactory);

            // Start the management endpoints
            ManagementConfig.Start();
        }

        protected void Application_Stop()
        {
            ManagementConfig.Stop();
        }
    }
}
