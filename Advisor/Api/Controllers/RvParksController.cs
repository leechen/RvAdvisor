using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using Advisor.Sdk;
using Advisor.ObjectModel;
using Thinktecture.IdentityModel.WebApi;
using System.Linq;

namespace Advisor.Api.Controllers
{
    public class RvParksController : AdvisorController
    {
        public RvParksController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET: api/RvParks
        [ScopeAuthorize("read")]
        public IEnumerable<RvPark> Get()
        {
            var principal = User as ClaimsPrincipal;

            var res = uow.Get<RvPark>().ToList();

            return res;
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
