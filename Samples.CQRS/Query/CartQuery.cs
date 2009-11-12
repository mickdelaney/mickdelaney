using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using NHibernate;

namespace MD.Samples.CQRS.Orders.Query
{
    public class CartQuery
    {
        ISessionFactory _sessionFactory;

        public CartQuery(ISessionFactory sessionFactory)
        {
            _sessionFactory = sessionFactory;
        }

        public List<CartItemDTO> GetCartForUser(Guid UserId)
        {
            return new List<CartItemDTO>();
        }
    }
}
