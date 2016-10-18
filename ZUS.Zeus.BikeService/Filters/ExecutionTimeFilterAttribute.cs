using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace ZUS.Zeus.BikeService.Filters
{
    public class ExecutionTimeFilterAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(HttpActionContext actionContext)
        {
            base.OnActionExecuting(actionContext);

            actionContext.Request.Properties[actionContext.ActionDescriptor.ActionName] = Stopwatch.StartNew();
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            base.OnActionExecuted(actionExecutedContext);

            var stopwatch = (Stopwatch)actionExecutedContext.Request.Properties[actionExecutedContext.ActionContext.ActionDescriptor.ActionName];

            Trace.WriteLine($"{actionExecutedContext.ActionContext.ActionDescriptor.ActionName} - elapsed - {stopwatch.Elapsed}");
        }
    }
}