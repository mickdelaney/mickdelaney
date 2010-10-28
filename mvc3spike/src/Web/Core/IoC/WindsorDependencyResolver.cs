using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using Castle.Windsor;

namespace mvc3spike.Core.IoC
{
    public class WindsorDependencyResolver : IDependencyResolver
    {
        private readonly IWindsorContainer _container;

        public WindsorDependencyResolver(IWindsorContainer container)
        {
            _container = container;
        }

        public object GetService(Type serviceType)
        {
            return _container.GetService(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            var services = new List<object>();
            services.AddRange(_container.ResolveAll(serviceType).Cast<object>());
            return services;
        }
   }
}