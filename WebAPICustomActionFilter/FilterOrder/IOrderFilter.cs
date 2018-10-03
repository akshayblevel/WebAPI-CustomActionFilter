using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Http.Filters;

namespace WebAPICustomActionFilter
{
    public interface ISequenceFilter : IFilter
    {
        int Sequence { get; set; }
    }

    public class ActionFilterWithOrderAttribute : ActionFilterAttribute, ISequenceFilter
    {
        public int Sequence { get; set; }
    }

    public class AuthorizationFilterWithOrderAttribute : AuthorizationFilterAttribute, ISequenceFilter
    {
        public int Sequence { get; set; }
    }

    public class ExceptionFilterWithOrderAttribute : ExceptionFilterAttribute, ISequenceFilter
    {
        public int Sequence { get; set; }
    }
}
