﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NServiceBus;
using Castle.Windsor;
using Castle.MicroKernel.Registration;
using MD.Samples.CQRS.Orders.Domain;
using MD.Samples.CQRS.Infrastructure;
using NHibernate;

namespace MD.Samples.CQRS.Orders.Command
{
    public class EndpointConfig : IConfigureThisEndpoint, IWantCustomInitialization
    {
        static WindsorContainer _container; 

        public void Init()
        {
            _container = new WindsorContainer();
            
            var sessionFactory = SqliteConfigurator.GetSessionFactory(typeof(OrderRepository).Assembly);

            _container.Register
            (
                Component.For<IOrderRepository>().ImplementedBy<OrderRepository>(),
                Component.For<ISessionFactory>().Instance(sessionFactory)
            );

            NServiceBus.Configure.With()
                .CastleWindsorBuilder(_container)
                .XmlSerializer()
                .MsmqTransport()
                    .IsTransactional(true)
                .UnicastBus()
                    .DoNotAutoSubscribe() //managed by the class Subscriber2Endpoint
                    .LoadMessageHandlers();
        }
    }
}