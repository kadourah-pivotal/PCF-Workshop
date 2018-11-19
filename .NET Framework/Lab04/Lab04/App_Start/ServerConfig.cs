﻿using Microsoft.Extensions.Configuration;
using Steeltoe.Extensions.Configuration.CloudFoundry;
using System;
using System.IO;
using Steeltoe.CloudFoundry.Connector.SqlServer;

namespace Lab04
{
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
}