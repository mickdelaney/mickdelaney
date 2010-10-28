using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel;
using Castle.Windsor;

namespace mvc3spike.Core.IoC
{
    public class WindsorControllerFactory : IControllerFactory
    {
        private readonly IControllerFactory _defaultFactory;
        private readonly IWindsorContainer _container;

        public WindsorControllerFactory(IWindsorContainer container)
        {
            _container = container;
        }

        public WindsorControllerFactory(IWindsorContainer container, IControllerFactory defaultFactory)
        {
            _container = container;
            _defaultFactory = defaultFactory;
        }

        public IController CreateController(RequestContext requestContext, string controllerName)
        {
            try
            {
                return _container.Resolve<IController>(controllerName + "Controller".ToLowerInvariant());
            }
            catch (ComponentNotFoundException)
            {
                return _defaultFactory.CreateController(requestContext, controllerName);
            }
        }

        public void ReleaseController(IController controller)
        {
            _container.Release(controller);
        }
    }
}