using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using Castle.Windsor;
using MD.Mvc2.WebApp;
using MD.Mvc2.WebApp.Core;
using MD.Samples.CQRS.Orders.WebApp.Controllers;
using NHibernate;
using MD.Samples.CQRS.Orders.Domain;
using Castle.MicroKernel.Registration;
using MD.Samples.CQRS.Data;
using MD.Samples.CQRS.Orders.Query;

namespace MD.Samples.CQRS.Orders.WebApp
{
    public class Global : HttpApplication, IContainerAccessor
    {
        protected IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static IBus Bus { get; private set; }

        public Global()
        {
            BeginRequest += MvcApplication_BeginRequest;
            EndRequest += MvcApplication_EndRequest;
        }

        void MvcApplication_BeginRequest(object sender, EventArgs e)
        {
        }
        void MvcApplication_EndRequest(object sender, EventArgs e)
        {
        }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{*favicon}", new { favicon = @"(.*/)?favicon.ico(/.*)?" });
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
            routes.MapRoute("Default", "{controller}/{action}/{id}", new { controller = "Home", action = "Index", id = "" });
        }

        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);

            BuildContainer();
            BuildNServiceBus();
        }

        private void BuildContainer()
        {
            _container = new WindsorContainer();
            _container.RegisterControllers(typeof(HomeController).Assembly);


            ISessionFactory sessionFactory = SqlServerConfigurator.GetSessionFactory(false, typeof(OrderRepository).Assembly);

            _container.Register
            (
                Component.For<ISessionFactory>().Instance(sessionFactory),
                Component.For<OrderQuery>(),
                Component.For<CartQuery>(),
                Component.For<ProductQuery>()
            );



            var factory = new WindsorControllerFactory(Container);
            ControllerBuilder.Current.SetControllerFactory(factory);
        }

        public void BuildNServiceBus()
        {
            Bus = Configure.WithWeb()
                           .CastleWindsorBuilder(Container)
                           .XmlSerializer()
                           .MsmqTransport()
                                .IsTransactional(false)
                                .PurgeOnStartup(false)
                           .UnicastBus()
                                .ImpersonateSender(false)
                           .CreateBus()
                           .Start();
        }
    }
}