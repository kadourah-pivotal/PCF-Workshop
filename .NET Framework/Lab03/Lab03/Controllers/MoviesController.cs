using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

using Autofac;
using Microsoft.Extensions.Caching.Distributed;
using Microsoft.Extensions.Caching.Redis;
using StackExchange.Redis;
using System.Text;


namespace Lab03.Controllers
{
    public class MoviesController : ApiController
    {

        private IDistributedCache _cache;
        private IConnectionMultiplexer _conn;

        public MoviesController(IDistributedCache cache, IConnectionMultiplexer conn)
        {
            _cache = cache;
            _conn = conn;
        }
        

        // GET api/<controller>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<controller>/5
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<controller>
        public void Post([FromBody]string value)
        {

            _cache.SetString("key1", "test");
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