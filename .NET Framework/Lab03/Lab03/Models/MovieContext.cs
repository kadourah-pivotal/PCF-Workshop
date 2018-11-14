using MySql.Data.Entity;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.Entity;

namespace Lab03.Models
{
    [DbConfigurationType(typeof(MySqlEFConfiguration))]
    public class MovieContext : DbContext
    {
       
        // Constructor to use on a DbConnection that is already opened
        public MovieContext(string connectionString) : base(connectionString)
        {
            Database.SetInitializer(new MovieDBInitializer());
            //   this.Database.CreateIfNotExists();
        }
        public DbSet<Movie> Movies { get; set; }

        
    }

    public class MovieDBInitializer : DropCreateDatabaseAlways<MovieContext>
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