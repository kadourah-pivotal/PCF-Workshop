using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Lab03.Data;
using Lab03.Models;

namespace Lab03.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MoviesController : ControllerBase
    {
        private MovieContext _ctx;


        public MoviesController(MovieContext context)
        {
            _ctx = context;

        }

        public IQueryable<Movie> Get()
        {
            var movies = _ctx.Set<Movie>();
            return movies;
        }
    }
}