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
          //  Database.SetInitializer<MovieContext>(new CreateDatabaseIfNotExists<MovieContext>());
            Database.SetInitializer(new MovieDBInitializer());
            //   this.Database.CreateIfNotExists();
        }
        public DbSet<Movie> Movies { get; set; }

        
    }

    public class MovieDBInitializer : DropCreateDatabaseAlways<MovieContext>
    {
        protected override void Seed(MovieContext context)
        {
            IList<Movie> defaultStandards = new List<Movie>();
            defaultStandards.Add(new Movie() { Id = 1, DateCreated = System.DateTime.Now, Name = "test" });
          //  defaultStandards.Add(new Standard() { StandardName = "Standard 1", Description = "First Standard" });
          //defaultStandards.Add(new Standard() { StandardName = "Standard 2", Description = "Second Standard" });
          // defaultStandards.Add(new Standard() { StandardName = "Standard 3", Description = "Third Standard" });

            context.Movies.AddRange(defaultStandards);

            base.Seed(context);
        }
    }


}