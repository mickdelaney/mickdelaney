using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.Query
{
    public class OrderQuery
    {
        ISessionFactory _sessionFactory;

        public OrderQuery(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Order> GetOrders()
        {
            var session = _sessionFactory.OpenSession();
            return session.Linq<Order>().ToList();
        }

        public Order Get(Guid id)
        {
            var session = _sessionFactory.OpenSession();
            return session.Linq<Order>().Where(o => o.Id == id).FirstOrDefault();
        }
    }
}
