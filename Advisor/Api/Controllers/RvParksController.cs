using System.Collections.Generic;
using System.Security.Claims;
using System.Web.Http;
using Advisor.Sdk;
using Advisor.ObjectModel;
using Thinktecture.IdentityModel.WebApi;
using System.Linq;
using System.Net;
using System;
using System.Web.Http.Description;

namespace Advisor.Api.Controllers
{
    [RoutePrefix("api/rvparks")]
    public class RvParksController : AdvisorController
    {
        public RvParksController(IUnitOfWork uow) : base(uow)
        {
        }

        // GET: api/RvParks
        //[ScopeAuthorize("read")]
        [Route("")]
        public IEnumerable<RvPark> Get()
        {
            var principal = User as ClaimsPrincipal;

            var res = uow.Get<RvPark>().ToList();

            return res;
        }

        // GET: api/RvParks/5
        [Route("{id:int}", Name = "GetRvParkById")]
        public RvPark Get(int id)
        {
            return uow.Get<RvPark>(id);
        }

        // POST: api/RvParks
        [HttpPost]
        [Route("")]
        [ResponseType(typeof(RvPark))]
        public IHttpActionResult Post([FromBody]RvPark park)
        {
            try
            {
                uow.Add(park);
                uow.SaveChanges();
                return CreatedAtRoute("GetRvParkById", new { id = park.Id }, park);
            }
            catch (Exception ex)
            {
                // log
                return StatusCode(HttpStatusCode.Conflict);
            }
        }

        // PUT: api/RvParks/5
        [HttpPut]
        [ResponseType(typeof(RvPark))]
        [Route("{id:int}")]
        public IHttpActionResult Put(int id, [FromBody]RvPark park)
        {
            RvPark cur = uow.Get<RvPark>(id);

            if (cur == null)
            {
                return NotFound();
            }

            cur.Name = park.Name;
            cur.Phone = park.Phone;
            cur.Description = park.Description;
            cur.Capacity = park.Capacity;
            cur.Address = park.Address;

            uow.SaveChanges();

            return Ok(cur);
        }

        // DELETE: api/RvParks/5
        [Route("{id:int}")]
        public IHttpActionResult Delete(int id)
        {
            RvPark park = uow.Get<RvPark>(id);

            if (park == null)
            {
                return NotFound();
            }

            park.IsDeleted = true;
            uow.SaveChanges();

            return StatusCode(HttpStatusCode.NoContent);
        }
    }
}
