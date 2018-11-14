using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Autofac;
using Microsoft.Extensions.Caching.Distributed;


using System.Text;
using Lab03.Models;

namespace Lab03.Controllers
{
    public class MoviesController : ApiController
    {

        //  private IDistributedCache _cache;
        // private IConnectionMultiplexer _conn;

        private MovieContext _ctx;
        public MoviesController(MovieContext context)
        {
            _ctx = context;

        }

        // GET api/<controller>
        public IQueryable<Movie> Get()
        {
            var movies = _ctx.Set<Movie>();
            return movies;
        }

        // GET api/<controller>/5
        public IQueryable<Movie> Get(int id)
        {
            var movies = _ctx.Movies.Where(a => a.Id == id).AsQueryable();
            return movies;

        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

            
            Movie movie = new Movie();
            movie.Id = 1;
            movie.Name = "test";
            movie.DateCreated = DateTime.Now;
            _ctx.SaveChanges();





            // _cache.SetString("key1", "test");
        }

        // PUT api/<controller>/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/<controller>/5
        public void Delete(int id)
        {
        }
    }
}