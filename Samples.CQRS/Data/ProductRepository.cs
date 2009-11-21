using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MD.Samples.CQRS.Orders.Domain;
using NHibernate;
using NHibernate.Linq;

namespace MD.Samples.CQRS.Data
{
    public class ProductRepository : IProductRepository
    {
        protected ISessionFactory _sessionFactory;

        public ProductRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public Product Save(Product product)
        {
            ISession session = _sessionFactory.OpenSession();
            session.SaveOrUpdate(product);
            return product;
        }

        public Product Get(Guid Id)
        {
            ISession session = _sessionFactory.OpenSession();
            return session.Linq<Product>().Where(p => p.Id == Id).First();
        }
    }
}
