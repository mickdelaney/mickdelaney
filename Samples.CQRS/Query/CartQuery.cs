using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;
using NHibernate.Linq;
using MD.Samples.CQRS.Orders.Domain;

namespace MD.Samples.CQRS.Orders.Query
{
    public class CartQuery
    {
        ISessionFactory _sessionFactory;

        public CartQuery(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<CartItem> GetCartForUser(Guid userId)
        {
            return _sessionFactory.OpenSession().Linq<CartItem>().Where(c => c.UserId == userId).ToList();
        }
    }
}
