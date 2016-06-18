using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using Advisor.Sdk;
using ObjectModel;
using Thinktecture.IdentityModel.WebApi;

namespace Advisor.Api.Controllers
{
    public class RvParksController : AdvisorController
    {
        public RvParksController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET: api/RvParks
        [ScopeAuthorize("read")]
        public IEnumerable<string> Get()
        {
            var principal = User as ClaimsPrincipal;

            var res = uow.Get<RvPark>();

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
