using System.Collections.Generic;
using System.Web.Http;

namespace Advisor.Api.Controllers
{
    public class RvParksController : ApiController
    {
        // GET: api/RvParks
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET: api/RvParks/5
        public string Get(int id)
        {
            return "value";
        }

        // POST: api/RvParks
        public void Post([FromBody]string value)
        {
        }

        // PUT: api/RvParks/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE: api/RvParks/5
        public void Delete(int id)
        {
        }
    }
}
