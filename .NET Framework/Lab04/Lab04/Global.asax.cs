﻿using System.Web.Http;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Steeltoe.CloudFoundry.ConnectorAutofac;
using Steeltoe.CloudFoundry.Connector.EF6Autofac;
using Lab04.Models;
using System.Data.SqlClient;
using Steeltoe.CloudFoundry.Connector.SqlServer;
//using Steeltoe.CloudFoundry.Connector.Sql.EF6;

namespace Lab04
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            GlobalConfiguration.Configure(WebApiConfig.Register);
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);


            /*add server configuration*/
            ServerConfig.RegisterConfig("development");

            var builder = new ContainerBuilder();

            // Register all the controllers with Autofac
            builder.RegisterControllers(typeof(WebApiApplication).Assembly);
            builder.RegisterApiControllers(typeof(WebApiApplication).Assembly);

           // builder.RegisterSqlServerConnection(ServerConfig.Configuration);
            
          //  builder.RegisterDbContext<MovieContext>(ServerConfig.Configuration);
            

            // Create the Autofac container
            var container = builder.Build();
         
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));

            GlobalConfiguration.Configuration.DependencyResolver = new AutofacWebApiDependencyResolver((IContainer)container); //Set the WebApi DependencyResolver



        }
    }
}
