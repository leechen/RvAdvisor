using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;
using Advisor.Log;

namespace Advisor.Api.Filters
{
    [AttributeUsage(AttributeTargets.Method | AttributeTargets.Class)]
    internal class LogActionAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            HttpLog log = GetLog(actionContext);
            // call EventSource to log
        }

        private HttpLog GetLog(HttpActionContext actionContext)
        {
            throw new NotImplementedException();
        }
    }
}