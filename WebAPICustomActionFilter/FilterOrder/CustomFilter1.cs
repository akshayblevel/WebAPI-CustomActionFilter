﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;
using System.Web.Http.Filters;

namespace WebAPICustomActionFilter
{
    class CustomFilter1 : ActionFilterWithOrderAttribute
    {
        public override void OnActionExecuting(System.Web.Http.Controllers.HttpActionContext actionContext)
        {
            Trace.WriteLine("OnActionExecuting1");
        }

        public override void OnActionExecuted(HttpActionExecutedContext actionExecutedContext)
        {
            Trace.WriteLine("OnActionExecuted1");
        }
    }
}