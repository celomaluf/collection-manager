using CollectionManager.Models.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace CollectionManager.Controllers
{
    public class CollectionController : ApiController
    {
        // GET: api/Collection
        public IHttpActionResult Get()
        {
            return Ok(CollectionDTO.Collections);//it's not working
        }

        // GET: api/Collection/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/Collection
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/Collection/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/Collection/5
        public void Delete(int id)
        {
        }
    }
}
