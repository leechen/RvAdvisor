using System.Web.Http;
using Advisor.Sdk;

namespace Advisor.Api.Controllers
{
    public class AdvisorController : ApiController
    {
        private readonly IUnitOfWork uow;

        public AdvisorController(IUnitOfWork uow)
        {
            this.uow = uow;
        }
    }
}
