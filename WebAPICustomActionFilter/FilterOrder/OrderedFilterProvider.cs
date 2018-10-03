using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Http.Controllers;
using System.Web.Http.Filters;

namespace WebAPICustomActionFilter
{
    public class SequenceFilterProvider : IFilterProvider
    {
        public IEnumerable<FilterInfo> GetFilters(HttpConfiguration configuration, HttpActionDescriptor actionDescriptor)
        {
            var controllerSpecificFilters = SequenceFilters(actionDescriptor.ControllerDescriptor.GetFilters(), FilterScope.Controller);

            var actionSpecificFilters = SequenceFilters(actionDescriptor.GetFilters(), FilterScope.Action);

            return controllerSpecificFilters.Concat(actionSpecificFilters);
        }

        private IEnumerable<FilterInfo> SequenceFilters(IEnumerable<IFilter> filters, FilterScope scope)
        {
            var notOrderableFilter = filters.Where(f => !(f is ISequenceFilter))
                .Select(instance => new KeyValuePair<int, FilterInfo>(0, new FilterInfo(instance, scope)));

            var orderableFilter = filters.OfType<ISequenceFilter>().OrderBy(filter => filter.Sequence)
                .Select(instance => new KeyValuePair<int, FilterInfo>(instance.Sequence, new FilterInfo(instance, scope)));

            return notOrderableFilter.Concat(orderableFilter).OrderBy(x => x.Key).Select(y => y.Value);
        }
    }
}