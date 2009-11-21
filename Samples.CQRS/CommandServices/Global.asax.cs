using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using NServiceBus;
using Castle.Windsor;
using MD.Samples.CQRS.Data;
using NHibernate;
using MD.Samples.CQRS.Orders.Domain;
using Castle.MicroKernel.Registration;

namespace CommandServices
{
    public class MvcApplication : HttpApplication
    {
        protected IWindsorContainer _container;

        public IWindsorContainer Container
        {
            get { return _container; }
        }

        public static IBus Bus { get; private set; }

        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");
        }
        protected void Application_Start()
        {
            RegisterRoutes(RouteTable.Routes);
            BuildContainer();
            BuildNServiceBus();
        }

        private void BuildContainer()
        {
            ISessionFactory sessionFactory = SqlServerConfigurator.GetSessionFactory(false, typeof(OrderRepository).Assembly);

            _container = new WindsorContainer();
            _container.Register
            (
                Component.For<IProductRepository>().ImplementedBy<ProductRepository>(),
                Component.For<IOrderRepository>().ImplementedBy<OrderRepository>(),
                Component.For<ICartRepository>().ImplementedBy<CartRepository>(),
                Component.For<ISessionFactory>().Instance(sessionFactory)
            );
        }

        public void BuildNServiceBus()
        {
            Bus = Configure.WithWeb()
                           .CastleWindsorBuilder(Container)
                           .XmlSerializer()
                            .MsmqTransport()
                                .IsTransactional(true)
                           .UnicastBus()
                                .DoNotAutoSubscribe()
                                .LoadMessageHandlers()
                                .ImpersonateSender(false)
                           .CreateBus()
                           .Start();
        }
    }
}