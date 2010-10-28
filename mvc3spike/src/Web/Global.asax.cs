using mvc3spike.Controllers;
using mvc3spike.Core.Extensions;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using Castle.MicroKernel.Registration;
using Castle.Windsor;
using mvc3spike.Core.IoC;
using mvc3spike.Models;
using mvc3spike.Models.Services;

namespace mvc3spike
{
    public class MvcApplication : HttpApplication, IContainerAccessor
    {
        IWindsorContainer _container; 

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        protected void Application_Start()
        {
            _container = new WindsorContainer();
            
            _container.RegisterControllers(typeof(HomeController).Assembly.GetExportedTypes());
            _container.Register(Component.For<IControllerFactory>().Instance(new WindsorControllerFactory(_container)));
            

            DependencyResolver.SetResolver(new WindsorDependencyResolver(_container));
            AreaRegistration.RegisterAllAreas();

            RegisterComponents();
            RegisterFilterProviders(FilterProviders.Providers);
            RegisterGlobalFilters(GlobalFilters.Filters);
            RegisterRoutes(RouteTable.Routes);
        }
        
        public void RegisterComponents()
        {
            Container.Register
            (
                Component.For<ITrackerService>().ImplementedBy<TrackerService>()
            );
        }

        public void RegisterFilterProviders(FilterProviderCollection providers)
        {
            providers.Remove<FilterAttributeFilterProvider>();
            providers.Add(new WindsorFilterProvider(Container));
        }
        public void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
            filters.Add(new TrackVisitors(Container.Resolve<ITrackerService>()));
        }
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("favicon.ico");
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = UrlParameter.Optional } );
        }
    }
}