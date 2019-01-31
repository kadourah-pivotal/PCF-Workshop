using System;
using Microsoft.EntityFrameworkCore;
using Lab03.Models;

namespace Lab03.Data
{
    public class MovieContext  : DbContext
    {
        public MovieContext(DbContextOptions<MovieContext> options)
           : base(options)
        {
        }

        public DbSet<Lab03.Models.Movie> Movies { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Movie>().Property(b => b.DateCreated).HasDefaultValueSql("CURRENT_TIMESTAMP(6)");
        }
    }
}
