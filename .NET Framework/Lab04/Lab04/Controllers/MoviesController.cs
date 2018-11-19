using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data.Entity;
using Lab04.Models;
using System.Data.SqlClient;

namespace Lab04.Controllers
{
    public class MoviesController : ApiController
    {
        

        public MoviesController()
        {

        }

        public IQueryable<Movie> Get()
        {
            //IQueryable<Movie> 
            var config = ServerConfig.Configuration;
            // var section = config.GetSection("spring:cloud:config");

            //var name = ServerConfig.Configuration["vcap:services:azure-sqldb:0:name"];
            var uri = config["vcap:services:azure-sqldb:0:credentials:uri"];

            SqlConnectionStringBuilder connBuilder = new SqlConnectionStringBuilder();
            connBuilder.UserID = config["vcap:services:azure-sqldb:0:credentials:databaseLogin"];
            connBuilder.Password = config["vcap:services:azure-sqldb:0:credentials:password"];
            connBuilder.DataSource = config["vcap:services:azure-sqldb:0:credentials:sqlServerFullyQualifiedDomainName"];
            connBuilder.InitialCatalog = config["vcap:services:azure-sqldb:0:credentials:sqldbName"];

            //return connBuilder.ConnectionString;
            MovieContext context = new MovieContext(connBuilder.ConnectionString);
            var movies = context.Set<Movie>();
            return movies;
     
        }

      
    }
}
