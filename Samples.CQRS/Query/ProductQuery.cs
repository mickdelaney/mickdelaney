using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.Query
{
    public class ProductQuery
    {
        ISessionFactory _sessionFactory;

        public ProductQuery(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<Product> GetOrders()
        {
            var session = _sessionFactory.OpenSession();
            return session.Linq<Product>().ToList();
        }

        public Product Get(Guid id)
        {
            var session = _sessionFactory.OpenSession();
            return session.Linq<Product>().Where(p => p.Id == id).FirstOrDefault();
        }
    }
}
