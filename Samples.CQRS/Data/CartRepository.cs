using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using MD.Samples.CQRS.Orders.Domain;
using NHibernate;

namespace MD.Samples.CQRS.Data
{
    public class CartRepository : ICartRepository
    {
        private readonly ISessionFactory _sessionFactory;

        public CartRepository(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public CartItem Save(CartItem cartItem)
        {
            ISession session = _sessionFactory.OpenSession();
            session.SaveOrUpdate(cartItem);
            session.Flush();
            return cartItem;
        }
    }
}
