using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
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
            ApiEventSource.Log.GetBegin(log.UserName, log.Uri.AbsoluteUri);
        }

        private HttpLog GetLog(HttpActionContext actionContext)
        {
            var claimsPrincipal = actionContext.RequestContext.Principal as ClaimsPrincipal;
            var userName = claimsPrincipal?.FindFirst(
                "http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier").Value;

            if (userName == null) { userName = "anonymous"; }

            return new HttpLog(
                userName,
                actionContext.Request.Method.ToString(),
                actionContext.Request.RequestUri,
                "");
        }
    }
}