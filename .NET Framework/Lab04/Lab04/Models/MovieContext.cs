using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data.Entity.SqlServer;

namespace Lab04.Models
{
    public class MovieContext : DbContext
    {

        // Constructor to use on a DbConnection that is already opened
        public MovieContext(string connectionString) : base(connectionString)
        {
            if(null == connectionString)
            {
                
            }
            Database.SetInitializer(new MovieDBInitializer());
            //   this.Database.CreateIfNotExists();
        }
        public DbSet<Movie> Movies { get; set; }


    }

    public class MovieDBInitializer : CreateDatabaseIfNotExists<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            IList<Movie> movies = new List<Movie>();
            movies.Add(new Movie() { Id = 1, DateCreated = System.DateTime.Now, Name = "Avengers" });
            movies.Add(new Movie() { Id = 1, DateCreated = System.DateTime.Now, Name = "Six Sense" });

            context.Movies.AddRange(movies);

            base.Seed(context);
        }
    }
}