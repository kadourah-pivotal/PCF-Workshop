using System;
using System.Linq;
using Lab03.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Lab03.Models
{
    public class SeedData
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MovieContext(
                serviceProvider.GetRequiredService<DbContextOptions<MovieContext>>()))
            {
                context.Database.EnsureCreated();

                if (context.Movies.Any())
                {
                    return;
                }

                context.Movies.AddRange(
                    new Movie
                    { Id = 1, DateCreated = System.DateTime.Now, Name = "Avengers" },
                    new Movie
                    { Id = 2, DateCreated = System.DateTime.Now, Name = "Six Sense" }

                );

                context.SaveChanges();
            }
        }
    }
}
