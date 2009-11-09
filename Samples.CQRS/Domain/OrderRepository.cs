using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace MD.Samples.CQRS.Orders.Domain
{
    public class OrderRepository : IOrderRepository
    {
        protected ISessionFactory _sessionFactory;

        public OrderRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }
        
        public Order Save(Order order)
        {
            Console.WriteLine("Order saved {0}", order);
            return order;
        }
    }
}
