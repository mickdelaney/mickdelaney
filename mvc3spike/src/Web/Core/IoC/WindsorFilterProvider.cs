using System.Collections.Generic;
using System.Web.Mvc;
using Castle.Windsor;

namespace mvc3spike.Core.IoC
{
    public class WindsorFilterProvider : FilterAttributeFilterProvider
    {
        public IWindsorContainer Container { get; private set; }

        public WindsorFilterProvider(IWindsorContainer container)
        {
            Container = container;
        }

        public override IEnumerable<Filter> GetFilters(ControllerContext controllerContext, ActionDescriptor actionDescriptor)
        {
            var filters = base.GetFilters(controllerContext, actionDescriptor);

            foreach (var filter in filters)
            {
                Container.Inject(filter.Instance);
            }

            return filters;
        }
    }
}