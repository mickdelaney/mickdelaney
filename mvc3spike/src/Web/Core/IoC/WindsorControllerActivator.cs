using System;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.Windsor;

namespace mvc3spike.Core.IoC
{
    public class WindsorControllerActivator : DefaultControllerFactory, IControllerActivator
    {
        private readonly IWindsorContainer _container;

        public WindsorControllerActivator(IWindsorContainer container)
        {
            _container = container;
        }

        public IController Create(RequestContext requestContext, Type controllerType)
        {
            var controller = GetControllerInstance(requestContext, controllerType);
            _container.Kernel.Inject(controller);
            return controller;
        }
    }
}