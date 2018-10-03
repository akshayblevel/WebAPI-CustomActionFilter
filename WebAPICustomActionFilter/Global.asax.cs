using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Filters;
using System.Web.Routing;

namespace WebAPICustomActionFilter
{
    public class WebApiApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            GlobalConfiguration.Configure(WebApiConfig.Register);

            var config = GlobalConfiguration.Configuration;
            //config.Filters.Add(new ExecutionTimeFilterAttribute());

            config.Services.Replace(typeof(IFilterProvider), new System.Web.Http.Filters.ConfigurationFilterProvider());
            config.Services.Add(typeof(IFilterProvider), new SequenceFilterProvider());

        }
    }
}
